// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoCompletePopup.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
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
         private const int MaxItems = 5;

         private static readonly List<string> List = new List<string>();

         private static readonly Dictionary<string, int> Duplicates = new Dictionary<string, int>();

         private static readonly Dictionary<string, string> MarkupText = new Dictionary<string, string>();

         private static int currentIndex;

         private static Vector2 drawOffset;

         private static string matchValue;

         private static Rect originalParentPosition;

         private static Rect parentPosition;

         private static float previousWindowPositionTop;

         private static float previousWindowWidth;

         private static Rect windowPosition;

         private static bool mouseDown;

         private static int mouseDownIndex;

         public static bool IsDrawing { get; set; }

         public static bool IsVisible { get; set; }

         public static int ParentControlID { get; set; }

         public static string SelectedItem { get; private set; }

         public static bool WasReturnPressed { get; set; }

         public static bool WasTabPressed { get; set; }

         /// <summary>
         /// If the window is visible, a cursor region will be applied to force the arrow cursor within the bounds of the window.
         /// </summary>
         public static void AddCursorRect()
         {
            if (IsVisible == false || Event.current.type != EventType.Repaint)
            {
               return;
            }

            var debugBox = new Rect(
               windowPosition.x - 2,
               windowPosition.y - 2,
               windowPosition.width + 4,
               windowPosition.height + 4);

            ////uScriptGUI.DebugBox(debugBox, Color.red);
            EditorGUIUtility.AddCursorRect(debugBox, MouseCursor.Arrow);
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
                  ////return;
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

            var outsideParent = parentPosition.Contains(e.mousePosition) == false;
            var outsideWindow = windowPosition.Contains(e.mousePosition) == false;

            // The context click always closes the window.
            if ((e.type == EventType.MouseDown && e.button == 1) || e.type == EventType.ContextClick)
            {
               IsVisible = false;
               uScript.RequestRepaint();

               // Allow the ContextClick to pass through to the parent, consume it otherwise.
               if (parentPosition.Contains(e.mousePosition) == false)
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
                  var y = e.mousePosition.y - windowPosition.y - 1;
                  var index = (int)(y / 20);
                  var maxItems = Math.Min(MaxItems, List.Count);

                  if (index < maxItems)
                  {
                     //Debug.LogFormat("MousePosition: {0} ({1}) in {2}\n", e.mousePosition, index, windowPosition);
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
                  var y = e.mousePosition.y - windowPosition.y - 1;
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

               var y = e.mousePosition.y - windowPosition.y - 1;
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

            // Automatically close the window when editing ends on the parent control.
            if (UnityEditorExtensions.IsEditingControl(ParentControlID) == false)
            {
               IsVisible = false;
               return;
            }

            // Automatically close the window when the parent control loses focus.
            ////if (FocusedControl.ID != ParentControlID)
            ////{
            ////   IsVisible = false;
            ////   return;
            ////}

            // Update the offset and recalculate only when it changes
            if (drawOffset != offset)
            {
               drawOffset = offset;

               // Update the parent position
               parentPosition = new Rect(
                  originalParentPosition.x + offset.x,
                  originalParentPosition.y + offset.y,
                  originalParentPosition.width,
                  originalParentPosition.height);

               // Update window position
               windowPosition = new Rect(
                  parentPosition.x,
                  parentPosition.yMax + 1,
                  Math.Min(originalParentPosition.width, previousWindowWidth),
                  GetWindowHeight());

               windowPosition.y = GetWindowTopValue(ShouldDrawWindowAboveParentControl());

            }

            // Hack to prevent the window width from resetting during Repaint while the EditorWindow is being resized.
            // Not sure why this is needed or what's actually causing the issue.
            if (Event.current.type == EventType.Repaint)
            {
               windowPosition.width = previousWindowWidth;
            }

            GUI.Window("AutoCompletePopup".GetHashCode(), windowPosition, Window, string.Empty, Style.Window);

            // Move the panel above the parent control, if there is limited room below it
            windowPosition.y = GetWindowTopValue(ShouldDrawWindowAboveParentControl());
            if (previousWindowPositionTop.AlmostEquals(windowPosition.y) == false)
            {
               previousWindowPositionTop = windowPosition.y;
               uScript.RequestRepaint();
            }

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
            originalParentPosition = rect;

            drawOffset = new Vector2();

            currentIndex = -1;
            IsVisible = true;
         }

         private static float GetWindowHeight()
         {
            return (Math.Min(List.Count, MaxItems) * Style.Item.fixedHeight)
                   + (MaxItems < List.Count ? Style.Message.fixedHeight + 2 : 2);
         }

         private static float GetWindowTopValue(bool shouldDrawAbove)
         {
            return shouldDrawAbove ? parentPosition.y - windowPosition.height - 1 : parentPosition.yMax + 1;
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

         private static bool ShouldDrawWindowAboveParentControl()
         {
            return uScript.Instance.position.height - (parentPosition.yMax + 1 + windowPosition.height) < 0;
         }

         private static void Window(int windowID)
         {
            uScript.GuiState.Enable();

            var maxItems = Math.Min(MaxItems, List.Count);

            if (Event.current.type == EventType.Layout)
            {
               // Calculate the dimensions of the window and its contents
               windowPosition.width = parentPosition.width;
               windowPosition.height = GetWindowHeight();

               for (var i = 0; i < maxItems; i++)
               {
                  var content = List[i];
                  var contentSize = Style.Item.CalcSize(uScriptGUIContent.Temp(content));
                  var rowWidth = contentSize.x;

                  int count;
                  if (Duplicates.TryGetValue(content, out count))
                  {
                     var warningMessage = string.Format("[{0} {1}]", count, count == 1 ? "duplicate" : "duplicates");
                     contentSize = Style.Warning.CalcSize(uScriptGUIContent.Temp(warningMessage));
                     rowWidth += contentSize.x;
                  }

                  windowPosition.width = Math.Max(windowPosition.width, rowWidth + 20);
               }

               previousWindowWidth = windowPosition.width;
            }
            else if (Event.current.type == EventType.Repaint)
            {
               // Draw the window and its content
               var rect = new Rect(1, 1, windowPosition.width - 2, Style.Item.fixedHeight);

               for (var i = 0; i < maxItems; i++)
               {
                  var content = List[i];
                  var selected = i == currentIndex;
                  var rowStyle = Style.Row(i);

                  if (selected == false)
                  {
                     // Get the marked up version of the text
                     if (MarkupText.TryGetValue(List[i], out content) == false)
                     {
                        content = List[i].HighlightMatch(matchValue);
                        MarkupText.Add(List[i], content);
                     }
                  }

                  rowStyle.Draw(rect, false, false, selected, false);

                  Style.Item.Draw(rect, content, false, false, selected, false);

                  int count;
                  if (Duplicates.TryGetValue(List[i], out count))
                  {
                     var warningMessage = string.Format("[{0} {1}]", count, count == 1 ? "duplicate" : "duplicates");
                     if (selected == false)
                     {
                        warningMessage = warningMessage.Color(Color.red);
                     }

                     Style.Warning.Draw(rect, warningMessage, false, false, false, false);
                  }

                  rect.y += rect.height;
               }

               if (maxItems < List.Count)
               {
                  rect.height = Style.Message.fixedHeight;
                  var message = string.Format("+{0} more", List.Count - maxItems);
                  Style.Message.Draw(rect, message, false, false, false, false);
               }
            }

            uScript.GuiState.Disable();
         }

         // ReSharper disable once MemberHidesStaticFromOuterClass
         private static class Style
         {
            private static readonly GUIStyle RowEven;

            private static readonly GUIStyle RowOdd;

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
                     onNormal = ((GUIStyle)"CN EntryBackEven").onNormal,
                  };

               RowOdd = new GUIStyle(RowEven)
                  {
                     normal = ((GUIStyle)"CN EntryBackodd").normal,
                     onNormal = ((GUIStyle)"CN EntryBackodd").onNormal,
                  };

               Item = new GUIStyle(GUI.skin.label)
                  {
                     name = "AutoCompletePopup.Item",
                     alignment = TextAnchor.MiddleLeft,
                     fixedHeight = 20,
                     margin = new RectOffset(),
                     padding = new RectOffset(2, 2, 1, 2),
                     onNormal = ((GUIStyle)"CN EntryBackEven").onNormal,
#if !UNITY_3_5
                     richText = true
#endif
                  };

               Message = new GUIStyle(GUI.skin.label)
                  {
                     alignment = TextAnchor.MiddleRight,
                     fixedHeight = 16,
                     fontStyle = FontStyle.Italic,
                     padding = new RectOffset(2, 8, 1, 2),
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

            public static GUIStyle Message { get; private set; }

            public static GUIStyle Warning { get; private set; }

            public static GUIStyle Window { get; private set; }

            public static GUIStyle Row(int index)
            {
               return index % 2 != 0 ? RowEven : RowOdd;
            }
         }
      }
   }
}
