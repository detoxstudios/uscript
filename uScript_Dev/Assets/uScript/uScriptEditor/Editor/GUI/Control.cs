// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Control.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Control type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using System.Globalization;
   using System.Linq;

   using Detox.Editor.Extensions;

   using UnityEditor;

   using UnityEngine;

   public static class Control
   {
      private static List<string> paths = new List<string>();

      private static GUIContent sceneObjectFieldSearchButton;

      static Control()
      {
         sceneObjectFieldSearchButton = new GUIContent(uScriptGUI.GetSkinnedTexture("iconSearch"), "Locate the object in the Hierarchy window.");
      }

      public static string SceneObjectPathField(string text, Type type, params GUILayoutOption[] options)
      {
         var position = UnityEditorExtensions.GetControlRect(false, 16f, Style.SceneObjectField(text), options);
         return SceneObjectPathField(position, text, type);
      }

      public static string SceneObjectPathField(string text, Type type, GUIStyle style, params GUILayoutOption[] options)
      {
         var position = UnityEditorExtensions.GetControlRect(false, 16f, style, options);
         return SceneObjectPathField(position, text, type, style);
      }

      public static string SceneObjectPathField(Rect position, string text, Type type)
      {
         var style = Style.SceneObjectField(text);
         return SceneObjectPathField(position, text, type, style);
      }

      public static string SceneObjectPathField(Rect position, string text, Type type, GUIStyle style)
      {
         var fieldPosition = position;
         fieldPosition.width -= 18;

         var buttonPosition = position;
         buttonPosition.xMin = buttonPosition.xMax - 16;

         // The popup needs to intercept some keyboard input before it reaches the text field
         AutoCompletePopup.InterceptKeyboardInput();

         var controlName = Property.GetControlName();
         var controlID = GUIUtility.GetControlID(controlName.GetHashCode(), FocusType.Keyboard, position);

         //Debug.Log("CONTROL: " + controlName + "\n");

         GUI.SetNextControlName(controlName);

         if (style == null)
         {
            Debug.Log("STYLE IS NULL\n");
            style = Style.SceneObjectField(text);
         }

         var originalGUIColor = GUI.color;
         if (style.name == "invalid")
         {
            GUI.color = new Color(1, 0.5f, 0.5f, 1);
         }

         bool changed;
         var value = UnityEditorExtensions.DoTextField(
            controlID,
            EditorGUI.IndentedRect(fieldPosition),
            text,
            style,
            null,
            out changed,
            false,
            false,
            false);

         GUI.color = originalGUIColor;

         // Associate the id with the control name
         //ControlIDList[controlID] = controlName;

         //WatchedControlName = GetControlName();

         if (string.IsNullOrEmpty(AutoCompletePopup.SelectedItem) == false)
         {
            value = AutoCompletePopup.SelectedItem;
            changed = true;
         }

         if (GUI.Button(buttonPosition, sceneObjectFieldSearchButton, Style.SceneObjectFieldSearchButton))
         {
            var hierarchyGameObject = GameObject.Find(value);
            if (hierarchyGameObject != null)
            {
               EditorGUIUtility.PingObject(hierarchyGameObject);
            }
         }

         // Refresh the cache if the node selection has changed
         // TODO: Do this also when the scene hierarchy changes.
         Cache.Refresh();

         // Generate the object list, if necessary
         if (Cache.SceneObjects.ContainsKey(type) == false)
         {
            Debug.Log(string.Format("GETTING OBJECTS FOR TYPE: {0}\n", type));

            var objectPaths = new List<string>();
            var objects = UnityEngine.Object.FindObjectsOfType(type);

            foreach (var o in objects)
            {
               GameObject go = null;

               var gameObject = o as GameObject;
               if (gameObject != null)
               {
                  go = gameObject;
               }
               else
               {
                  var component = o as Component;
                  if (component != null)
                  {
                     go = component.gameObject;
                  }
                  else
                  {
                     Debug.LogWarning(string.Format("Unhandled UnityEngine.Object type: {0}\n", o));
                  }
               }

               if (go != null)
               {
                  objectPaths.Add(uScriptUtility.GetHierarchyPath(go.transform));
               }
            }

            Cache.SceneObjects.Add(type, objectPaths);
         }

         // Get the list of object we've already generated
         paths = Cache.SceneObjects[type];

         // Update the auto-complete list, if the text has changed
         // TODO: Do this once also when the scene hierarchy changes.
         if (changed)
         {
            AutoCompletePopup.Reset();

            if (value != string.Empty)
            {
               foreach (var path in paths)
               {
                  var index = CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                     path,
                     value,
                     CompareOptions.OrdinalIgnoreCase);

                  if (index > -1)
                  {
                     AutoCompletePopup.Add(path);
                  }
               }
            }

            AutoCompletePopup.Update(position, value);
         }

         var isEditing = UnityEditorExtensions.IsEditingControl(AutoCompletePopup.ParentControlID);

         //if (isEditing)
         //{
         //   Debug.Log(
         //      string.Format("EDITING: '{0}' ({1})\n", GUI.GetNameOfFocusedControl(), AutoCompletePopup.ParentControlID));
         //}



         //var objects = UnityEngine.Object.FindObjectsOfType(type);
         //var unityObject = objects.FirstOrDefault(o => o.name == value);

         //// Components should never be instances in the property grid.
         //// We must refer to (and select) their parent game object
         //if (typeof(Component).IsAssignableFrom(type))
         //{
         //   if (null != unityObject)
         //   {
         //      unityObject = ((Component)unityObject).gameObject;
         //   }
         //}

         //unityObject = EditorGUILayout.ObjectField(unityObject, type, true, GUILayout.Width(columnValue.Width));

         //// if that object (or the changed object) does exist, use it's name to update the property value
         //// if it doesn't exist then the 'val' will stay as what was entered into the TextField
         //return unityObject != null ? unityObject.name : string.Empty;

         //BeginStaticRow(label, state);

         //if (IsFieldUsable(state))
         //{
         //   textValue = EditorGUILayout.TextField(textValue, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));

         //   EndRow(textValue.GetType().ToString());

         //   var tempState = new Property.State(false, true, state.IsReadOnly);
         //   BeginStaticRow(string.Empty, tempState);

         //   // now try and update the object browser with an instance of the specified object
         //   var objects = UnityEngine.Object.FindObjectsOfType(type);
         //   var unityObject = objects.FirstOrDefault(o => o.name == textValue);

         //   // components should never be instances in the property grid
         //   // we must refer to (and select) their parent game object
         //   if (typeof(Component).IsAssignableFrom(type))
         //   {
         //      //type = typeof(GameObject);
         //      if (null != unityObject)
         //      {
         //         unityObject = ((Component)unityObject).gameObject;
         //      }
         //   }

         //   unityObject = EditorGUILayout.ObjectField(unityObject, type, true, GUILayout.Width(columnValue.Width));

         //   // if that object (or the changed object) does exist, use it's name to update the property value
         //   // if it doesn't exist then the 'val' will stay as what was entered into the TextField
         //   if (unityObject != null)
         //   {
         //      textValue = unityObject.name;
         //   }
         //}

         //EndRow(type.ToString());

         return value;
      }

      public static class AutoCompletePopup
      {
         // TODO: Consider a cap. Limit the results to 5-10 items? Include a "... plus X more" at the end.

         // TODO: Limit the results to immediate children, if possible. So, "/Parent/Ch" will match "/Parent/Child 1" and "/Parent/Child 2", but not "/Parent/Child 1/Pet" and other subitems.

         // TODO: when the results window is up and the textField is selected, the down key moves focus to the popup list, and the up key will move back to the textField when pressed while one the first item in the popup list.

         // TODO: popup list contins buttons for the list items. then can be clicked or the enter key or maybe also (shift) tab can be used to make a selection.

         // TODO: If there are multiple identical final matches, notify the user of the situation.

         private const int MaxItems = 5;

         private static readonly List<string> List = new List<string>();

         private static readonly Dictionary<string, string> MarkupText = new Dictionary<string, string>();

         private static int currentIndex;

         private static string matchValue;

         private static Rect parentPosition;

         private static Rect position;

         public static int ParentControlID { get; set; }

         public static string SelectedItem { get; private set; }

         public static bool Visible { get; set; }

         /// <summary>
         /// If the window is visible, a cursor region will be applied to force the arrow cursor within the bounds of the window.
         /// </summary>
         public static void AddCursorRect()
         {
            if (Visible == false)
            {
               return;
            }

            EditorGUIUtility.AddCursorRect(position, MouseCursor.Arrow);
         }

         public static void Add(string label)
         {
            List.Add(label);
         }

         /// <summary>
         /// Before drawing the associated TextField control, certain characters need to be handled for autocomplete list operation.
         /// </summary>
         public static void InterceptKeyboardInput()
         {
            var e = Event.current;

            if (Visible == false || e.type != EventType.KeyDown)
            {
               return;
            }

            switch (e.keyCode)
            {
               case KeyCode.DownArrow:
                  NextIndex();
                  e.Use();
                  break;

               case KeyCode.UpArrow:
                  PreviousIndex();
                  e.Use();
                  break;

               case KeyCode.Return:
                  if (currentIndex >= 0)
                  {
                     SelectedItem = List[currentIndex];
                     e.Use();
                  }
                  break;

               case KeyCode.Tab:
                  Debug.Log(string.Format("Unhandled Key: {0}\n", e.keyCode));
                  break;

               case KeyCode.KeypadEnter:
                  Debug.Log(string.Format("Unhandled Key: {0}\n", e.keyCode));
                  break;

               default:
                  Debug.Log("Control: " + FocusedControl.ID + "\n");
                  break;
            }
         }

         /// <summary>
         /// If the window is visible, it will be drawn using the specified offset.
         /// </summary>
         /// <param name="drawingOffset">The drawing offset, which is typically associated with the parent container.</param>
         public static void Draw(Vector2 drawingOffset)
         {
            if (Visible == false)
            {
               return;
            }

            var popupRect = position;
            popupRect.x += drawingOffset.x;
            popupRect.y += drawingOffset.y;

            var id = "AutoCompletePopup".GetHashCode();
            var tmpRect = GUILayout.Window(id, popupRect, Window, string.Empty, Style.Window);

            uScript.GuiState.Enable();

            var e = Event.current;

            if (e.type == EventType.MouseDown || e.type == EventType.ContextClick)
            {
               if (tmpRect.Contains(e.mousePosition))
               {
                  e.Use();
               }
               else
               {
                  Visible = false;
                  uScript.RequestRepaint();
               }
            }
         }

         public static void Reset()
         {
            currentIndex = -1;
            List.Clear();
            MarkupText.Clear();
            SelectedItem = string.Empty;
            Visible = false;
         }

         public static void Update(Rect rect, string matchValue)
         {
            if (List.Count <= 0)
            {
               return;
            }

            AutoCompletePopup.matchValue = matchValue;

            if (List.Contains(matchValue))
            {
               return;
            }

            List.Sort();

            ParentControlID = FocusedControl.ID;
            parentPosition = rect;
            position = new Rect(rect.x, rect.yMax + 1, rect.width, 0);

            currentIndex = -1;
            Visible = true;
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
               var style = Style.Row(i, selected);

               if (selected == false)
               {
                  // Get the marked up version of the text
                  //if (MarkupText.ContainsKey(content) == false)
                  //{
                  //   MarkupText.Add(content, content.HighlightMatch(string.Empty));
                  //}

                  if (MarkupText.TryGetValue(List[i], out content) == false)
                  {
                     content = List[i].HighlightMatch(matchValue);
                     MarkupText.Add(List[i], content);
                  }

                  //content = MarkupText[content];
               }

               if (GUILayout.Button(content, style))
               {
                  Visible = false;
               }
            }

            if (maxItems < List.Count)
            {
               GUILayout.Label(string.Format("+{0} more", List.Count - maxItems), Style.Message);
            }

            uScript.GuiState.Disable();
         }

         private static class Style
         {
            private static readonly GUIStyle ItemEven;

            private static readonly GUIStyle ItemOdd;

            private static readonly GUIStyle ItemSelected;

            static Style()
            {
               var windowBackground = uScriptGUI.GetSkinnedTexture("MenuContext");

               ItemOdd = new GUIStyle(GUI.skin.button)
               {
                  alignment = TextAnchor.MiddleLeft,
                  fixedHeight = 20,
                  margin = new RectOffset(),
                  overflow = new RectOffset(),
                  focused = GUI.skin.button.normal,
                  normal = ((GUIStyle)"CN EntryBackodd").normal,
#if !UNITY_3_5
                  richText = true
#endif
               };

               ItemEven = new GUIStyle(ItemOdd) { normal = ((GUIStyle)"CN EntryBackEven").normal };

               ItemSelected = new GUIStyle(ItemEven)
               {
                  normal = ((GUIStyle)"CN EntryBackodd").onNormal,
                  richText = false
               };

               Message = new GUIStyle(GUI.skin.label)
               {
                  alignment = TextAnchor.MiddleRight,
                  fontStyle = FontStyle.Italic
               };

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

            public static GUIStyle Message { get; private set; }

            public static GUIStyle Window { get; private set; }

            public static GUIStyle Row(int index, bool selected)
            {
               return selected ? ItemSelected : (index % 2 != 0 ? ItemEven : ItemOdd);
            }
         }
      }

      private static class Cache
      {
         private static List<Guid> selectedObjects;

         static Cache()
         {
            SceneObjects = new Dictionary<Type, List<string>>();
            selectedObjects = new List<Guid>();
         }

         public static Dictionary<Type, List<string>> SceneObjects { get; private set; }

         public static void Refresh()
         {
            var newSelection = uScript.Instance.ScriptEditorCtrl.PropertyGrid.SelectedGuidArray.OrderBy(t => t);
            var equal = selectedObjects.SequenceEqual(newSelection);
            if (equal == false)
            {
               selectedObjects = newSelection.ToList();
               SceneObjects.Clear();
            }
         }
      }

      private static class Style
      {
         private static readonly GUIStyle InvalidMatch;

         private static readonly GUIStyle ValidMatch;

         private static string sceneObjectFieldPreviousValue;

         private static GameObject sceneObjectFieldPreviousObject;

         static Style()
         {
            ValidMatch = new GUIStyle(EditorStyles.textField);
            InvalidMatch = new GUIStyle(ValidMatch) { name = "invalid" };

            SceneObjectFieldSearchButton = new GUIStyle(GUI.skin.button)
            {
               padding = new RectOffset(0, 0, 0, 0),
               contentOffset = new Vector2(1, 0),
               normal = EditorStyles.label.normal,
               active = EditorStyles.label.active,
            };
         }

         public static GUIStyle SceneObjectFieldSearchButton { get; private set; }

         public static GUIStyle SceneObjectField(string value)
         {
            // TODO: Fix this. It doesn't work efficiently with array, since it's constantly reset.
            if (sceneObjectFieldPreviousValue != value)
            {
               sceneObjectFieldPreviousValue = value;
               sceneObjectFieldPreviousObject = GameObject.Find(value);
            }

            return sceneObjectFieldPreviousObject == null ? InvalidMatch : ValidMatch;
         }
      }
   }
}
