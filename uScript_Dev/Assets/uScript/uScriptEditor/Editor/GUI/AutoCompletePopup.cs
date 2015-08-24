// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoCompletePopup.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;

   using Detox.Editor.Extensions;

   using UnityEditor;

   using UnityEngine;

   public static partial class Control
   {
      public static class AutoCompletePopup
      {
         // TODO: Limit the results to immediate children, if possible. So, "/Parent/Ch" will match "/Parent/Child 1" and "/Parent/Child 2", but not "/Parent/Child 1/Pet" and other subitems.

         // TODO: If there are multiple identical final matches, notify the user of the situation.

         private const int MaxItems = 5;

         private static readonly List<string> List = new List<string>();

         private static readonly Dictionary<string, int> Duplicates = new Dictionary<string, int>();

         private static readonly Dictionary<string, string> MarkupText = new Dictionary<string, string>();

         private static int currentIndex;

         private static string matchValue;

         private static Rect offsetParentPosition;

         private static Rect offsetPosition;

         private static Rect parentPosition;

         private static Rect position;

         private static bool mouseDown;
         private static int mouseDownIndex;

         private static string selectedItem;

         private static Vector2 drawOffset;

         public static Vector2 DrawOffset
         {
            get
            {
               return drawOffset;
            }

            set
            {
               drawOffset = value;

               // Account for the parent button width
               offsetParentPosition = new Rect(
                  parentPosition.x + DrawOffset.x,
                  parentPosition.y + DrawOffset.y,
                  parentPosition.width - 18,
                  parentPosition.height);

               offsetPosition = new Rect(
                  position.x + DrawOffset.x,
                  position.y + DrawOffset.y,
                  position.width,
                  position.height);
            }
         }

         public static bool IsDrawing { get; set; }

         public static bool IsVisible { get; set; }

         public static int ParentControlID { get; set; }

         //public static string SelectedItem { get; private set; }
         public static string SelectedItem
         {
            get
            {
               return selectedItem;
            }

            private set
            {
               //Debug.LogFormat("SelectedItem changed from '{0}' to '{1}'\n", SelectedItem, value);
               selectedItem = value;
            }
         }

         public static bool WasReturnPressed { get; set; }

         public static bool WasTabPressed { get; set; }

         /// <summary>
         /// If the window is visible, a cursor region will be applied to force the arrow cursor within the bounds of the window.
         /// </summary>
         public static void AddCursorRect()
         {
            if (IsVisible == false)
            {
               return;
            }

            EditorGUIUtility.AddCursorRect(position, MouseCursor.Arrow);
         }

         public static void Add(string label)
         {
            if (List.Contains(label))
            {
               if (Duplicates.ContainsKey(label))
               {
                  Duplicates[label]++;
               }
               else
               {
                  Duplicates.Add(label, 1);
               }

               return;
            }

            List.Add(label);
         }

         /// <summary>
         /// Before drawing the associated TextField control, certain characters need to be handled for autocomplete list operation.
         /// </summary>
         public static void InterceptKeyboardInputArrows()
         {
            var e = Event.current;

            if (IsVisible == false || e.type != EventType.KeyDown)
            {
               return;
            }

            if (e.keyCode == KeyCode.DownArrow)
            {
               NextIndex();
               e.Use();
            }
            else if (e.keyCode == KeyCode.UpArrow)
            {
               PreviousIndex();
               e.Use();
            }
         }

         public static void InterceptKeyboardInput(int controlID)
         {
            var e = Event.current;
            if (e.type != EventType.KeyDown)
            {
               return;
            }

            // DownArrow
            if (InputStateMatched(controlID, true, true, EventType.KeyDown, KeyCode.DownArrow, 0))
            {
               NextIndex();
               e.Use();
               return;
            }

            // UpArrow
            if (InputStateMatched(controlID, true, true, EventType.KeyDown, KeyCode.UpArrow, 0))
            {
               PreviousIndex();
               e.Use();
               return;
            }

            // Return
            if (InputStateMatched(controlID, true, true, EventType.KeyDown, KeyCode.Return, 0))
            {
               if (currentIndex >= 0)
               {
                  WasReturnPressed = true;
                  SelectedItem = List[currentIndex];
                  e.Use();
                  return;
               }
            }
            else if (InputStateMatched(controlID, true, false, EventType.KeyDown, KeyCode.None, 10))
            {
               if (WasReturnPressed)
               {
                  WasReturnPressed = false;
                  UnityEditorExtensions.ReplaceRecycledTextEditorContents(SelectedItem);
                  e.Use();
                  return;
               }
            }

            // Tab
            if (InputStateMatched(controlID, false, true, EventType.KeyDown, KeyCode.Tab, 0)
                || InputStateMatched(controlID, false, true, EventType.KeyDown, KeyCode.None, 9))
            {
               if (currentIndex >= 0)
               {
                  SelectedItem = List[currentIndex];
                  WasTabPressed = true;
                  e.Use();
                  return;
               }
            }

            //var isEditing = UnityEditorExtensions.IsEditingControl(controlID);
            //Debug.Log(
            //   string.Format(
            //      "InterceptKeyboardInput({0})\n    Editing:{1}, Visible:{2}, Event:({3},{4},'{5}'), ReturnPressed:{6}\n",
            //      controlID,
            //      isEditing,
            //      IsVisible,
            //      e.type,
            //      e.keyCode,
            //      (int)e.character,
            //      WasReturnPressed));
         }

         public static void InterceptMouseInput()
         {
            if (IsVisible == false)
            {
               return;
            }

            var e = Event.current;

            var outsideParent = offsetParentPosition.Contains(e.mousePosition) == false;
            var outsideWindow = offsetPosition.Contains(e.mousePosition) == false;

            // The context click always closes the window.
            if ((e.type == EventType.MouseDown && e.button == 1) || e.type == EventType.ContextClick)
            {
               IsVisible = false;
               uScript.RequestRepaint();

               // Allow the ContextClick to pass through to the parent, consume it otherwise.
               if (offsetParentPosition.Contains(e.mousePosition) == false)
               {
                  e.Use();
               }
            }

            // Handle regular mouse clicks
            if (e.type == EventType.MouseDown && e.button == 0)
            {
               // If the mouse is clicked outside the window AND outside the parent, close the window
               if (outsideWindow && outsideParent)
               {
                  IsVisible = false;
                  uScript.RequestRepaint();
               }
               else if (outsideWindow == false)
               {
                  // When over a menu item, select it
                  var y = e.mousePosition.y - offsetPosition.y - 1;
                  var index = (int)(y / 20);
                  var maxItems = Math.Min(MaxItems, List.Count);

                  if (index < maxItems)
                  {
                     //Debug.LogFormat("MousePosition: {0} ({1}) in {2}\n", e.mousePosition, index, offsetPosition);
                     mouseDown = true;
                     mouseDownIndex = index;
                     currentIndex = mouseDownIndex;
                  }

                  e.Use();
               }
            }

            if (e.type == EventType.MouseUp && e.button == 0)
            {
               // If released outside the window, ignore the click
               if (outsideWindow)
               {
                  mouseDown = false;
               }
               else
               {
                  var y = e.mousePosition.y - offsetPosition.y - 1;
                  var index = (int)(y / 20);

                  // If over the same index, select it.
                  if (index == mouseDownIndex)
                  {
                     SelectedItem = List[mouseDownIndex];
                  }
               }

               e.Use();
            }

            if (e.type == EventType.MouseDrag)
            {
               currentIndex = -1;

               if (outsideWindow || mouseDown == false)
               {
                  return;
               }

               var y = e.mousePosition.y - offsetPosition.y - 1;
               var index = (int)(y / 20);

               // If over the same index, select it.
               if (index == mouseDownIndex)
               {
                  currentIndex = mouseDownIndex;
               }

               uScript.RequestRepaint();
            }
         }

         /// <summary>
         /// If the window is visible, it will be drawn using the specified offset.
         /// </summary>
         /// <param name="offset">The drawing offset, which is typically associated with the parent container.</param>
         public static void Draw(Vector2 offset)
         {
            if (IsVisible == false)
            {
               return;
            }

            DrawOffset = offset;

            var popupRect = position;
            popupRect.x += offset.x;
            popupRect.y += offset.y;

            // TODO: move the panel above the parent control if there is limited room below it

            GUILayout.Window("AutoCompletePopup".GetHashCode(), popupRect, Window, string.Empty, Style.Window);

            uScript.GuiState.Enable();
         }

         public static void Reset()
         {
            currentIndex = -1;
            List.Clear();
            MarkupText.Clear();
            Duplicates.Clear();
            IsVisible = false;

            if (WasReturnPressed == false)
            {
               SelectedItem = string.Empty;
            }
         }

         public static void Update(Rect rect, string matchPattern)
         {
            IsVisible = false;

            if (List.Count <= 0)
            {
               return;
            }

            matchValue = matchPattern;

            if (List.Contains(matchPattern))
            {
               return;
            }

            List.Sort();

            ParentControlID = FocusedControl.ID;
            parentPosition = rect;
            position = new Rect(rect.x, rect.yMax + 1, rect.width, 0);

            currentIndex = -1;
            IsVisible = true;
         }

         private static bool InputStateMatched(
            int controlID,
            bool isEditing,
            bool isVisible,
            EventType eventType,
            KeyCode keycode,
            int charValue)
         {
            var e = Event.current;
            return UnityEditorExtensions.IsEditingControl(controlID) == isEditing && IsVisible == isVisible
                   && e.type == eventType && e.keyCode == keycode && e.character == charValue;
         }

         private static void NextIndex()
         {
            currentIndex++;

            var last = Math.Min(List.Count, MaxItems);
            if (currentIndex >= last)
            {
               currentIndex = 0;
            }
         }

         private static void PreviousIndex()
         {
            currentIndex--;

            var last = Math.Min(List.Count - 1, MaxItems - 1);
            if (currentIndex < 0)
            {
               currentIndex = last;
            }
         }

         private static void Window(int windowID)
         {
            uScript.GuiState.Enable();

            var maxItems = Math.Min(MaxItems, List.Count);
            for (var i = 0; i < maxItems; i++)
            {
               var content = List[i];
               var selected = i == currentIndex;
               var rowStyle = Style.Row(i, selected);

               if (selected == false)
               {
                  // Get the marked up version of the text
                  if (MarkupText.TryGetValue(List[i], out content) == false)
                  {
                     content = List[i].HighlightMatch(matchValue);
                     MarkupText.Add(List[i], content);
                  }
               }

               EditorGUILayout.BeginHorizontal(rowStyle);
               {
                  GUILayout.Label(content, selected ? Style.ItemSelected : Style.Item);

                  var count = 0;
                  if (Duplicates.TryGetValue(List[i], out count))
                  {
                     var warningMessage = string.Format("[{0} {1}]", count, count == 1 ? "duplicate" : "duplicates");
                     if (selected == false)
                     {
                        warningMessage = warningMessage.Color(Color.red);
                     }

                     GUILayout.Label(warningMessage, Style.Warning);
                  }
               }
               EditorGUILayout.EndHorizontal();
            }

            if (maxItems < List.Count)
            {
               GUILayout.Label(string.Format("+{0} more", List.Count - maxItems), Style.Message);
            }

            uScript.GuiState.Disable();
         }

         private static class Style
         {
            private static readonly GUIStyle RowEven;

            private static readonly GUIStyle RowOdd;

            private static readonly GUIStyle RowSelected;

            static Style()
            {
               var windowBackground = uScriptGUI.GetSkinnedTexture("MenuContext");

               RowEven = new GUIStyle(GUI.skin.button)
               {
                  alignment = TextAnchor.MiddleLeft,
                  fixedHeight = 20,
                  margin = new RectOffset(),
                  padding = new RectOffset(),
                  overflow = new RectOffset(),
                  focused = GUI.skin.button.normal,
                  normal = ((GUIStyle)"CN EntryBackEven").normal,
               };

               RowOdd = new GUIStyle(RowEven) { normal = ((GUIStyle)"CN EntryBackodd").normal, };

               RowSelected = new GUIStyle(RowEven) { normal = ((GUIStyle)"CN EntryBackodd").onNormal, };

               Item = new GUIStyle(GUI.skin.button)
               {
                  alignment = TextAnchor.MiddleLeft,
                  fixedHeight = 20,
                  margin = new RectOffset(),
                  overflow = new RectOffset(),
                  normal = EditorStyles.label.normal,
                  onNormal = RowSelected.onNormal,
#if !UNITY_3_5
                  richText = true
#endif
               };

               ItemSelected = new GUIStyle(Item) { normal = RowSelected.normal };

               Message = new GUIStyle(GUI.skin.label)
               {
                  alignment = TextAnchor.MiddleRight,
                  fontStyle = FontStyle.Italic
               };

               Warning = new GUIStyle(Item) { alignment = TextAnchor.MiddleRight };

               Window = new GUIStyle(GUI.skin.window)
               {
                  normal = { background = windowBackground },
                  onNormal = { background = windowBackground },
                  border = new RectOffset(10, 10, 10, 10),
                  padding = new RectOffset(1, 1, 1, 1),
                  overflow = new RectOffset(6, 6, 6, 6),
                  contentOffset = Vector2.zero,
               };
            }

            public static GUIStyle Item { get; private set; }

            public static GUIStyle ItemSelected { get; private set; }

            public static GUIStyle Message { get; private set; }

            public static GUIStyle Warning { get; private set; }

            public static GUIStyle Window { get; private set; }

            public static GUIStyle Row(int index, bool selected)
            {
               return selected ? RowSelected : (index % 2 != 0 ? RowEven : RowOdd);
            }
         }
      }

   }
}
