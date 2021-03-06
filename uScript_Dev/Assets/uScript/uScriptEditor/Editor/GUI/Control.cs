// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Control.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBePartlyConvertedToQuery

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using System.Globalization;
   using System.Linq;

   using Detox.Editor.Extensions;

   using UnityEditor;

   using UnityEngine;

   public static partial class Control
   {
      private static readonly GUIContent SearchButton;

      private static bool hierarchyChanged;

      private static List<string> paths = new List<string>();

      static Control()
      {
         EditorApplication.hierarchyWindowChanged += OnHierarchyChange;

         SearchButton = new GUIContent(
            uScriptGUI.GetSkinnedTexture("iconSearch"),
            "Locate the object in the Hierarchy window.");
      }

      internal delegate UnityEngine.Object SceneObjectPathFieldValidator(
         UnityEngine.Object[] references,
         Type type,
         SerializedProperty property);

      public static string SceneObjectPathField(string text, Type type, params GUILayoutOption[] options)
      {
         var position = UnityEditorExtensions.GetControlRect(false, 16f, EditorStyles.textField, options);
         return SceneObjectPathField(position, text, type);
      }

      public static string SceneObjectPathField(
         string text,
         Type type,
         [DefaultValue("EditorStyles.textField")] GUIStyle style,
         params GUILayoutOption[] options)
      {
         var position = UnityEditorExtensions.GetControlRect(false, 16f, style, options);
         return SceneObjectPathField(position, text, type, style);
      }

      public static string SceneObjectPathField(Rect position, string text, Type type)
      {
         var style = EditorStyles.textField;
         return SceneObjectPathField(position, text, type, style);
      }

      public static string SceneObjectPathField(
         Rect position,
         string text,
         Type type,
         [DefaultValue("EditorStyles.textField")] GUIStyle style)
      {
         position = EditorGUI.IndentedRect(position);

         var name = Property.GetControlName();
         var id = GUIUtility.GetControlID(name.GetHashCode(), FocusType.Keyboard, position);
         GUI.SetNextControlName(name);

         // Associate the id with the control name
         //ControlIDList[controlID] = controlName;

         //WatchedControlName = GetControlName();

         // The popup needs to intercept some keyboard input before it reaches the text field
         AutoCompletePopup.InterceptKeyboardInput(id);

         //var hasObjectThumbnail = EditorGUIUtility.HasObjectThumbnail(type);
         //Debug.Log(type + " hasObjectThumbnail: " + hasObjectThumbnail + "\n");

         //var iconSize = EditorGUIUtility.GetIconSize();
         //Debug.Log("iconSize: " + iconSize + "\n");
         //EditorGUIUtility.SetIconSize(new Vector2(12f, 12f));

         // Handle Drag and Drop
         var fieldPosition = new Rect(position.x, position.y, position.width - 18, position.height);

         if (Event.current.type == EventType.DragUpdated || Event.current.type == EventType.DragPerform)
         {
            if (fieldPosition.Contains(Event.current.mousePosition) && GUI.enabled)
            {
               var objectReferences = DragAndDrop.objectReferences;
               var validator = new SceneObjectPathFieldValidator(ValidateSceneObjectPathFieldAssignment);
               var target = validator(objectReferences, type, null);
               if (target != null)
               {
                  DragAndDrop.visualMode = DragAndDropVisualMode.Link;
                  if (Event.current.type == EventType.DragPerform)
                  {
                     var component = target as Component;
                     if (component != null)
                     {
                        text = uScriptUtility.GetHierarchyPath(component.transform);
                     }
                     else
                     {
                        var gameObject = (GameObject)target;
                        text = uScriptUtility.GetHierarchyPath(gameObject.transform);
                     }

                     GUI.changed = true;
                     DragAndDrop.AcceptDrag();
                     DragAndDrop.activeControlID = 0;
                  }
                  else
                  {
                     DragAndDrop.activeControlID = id;
                  }
                  Event.current.Use();
               }
            }
         }
         else if (Event.current.type == EventType.Repaint)
         {
            if (GUI.enabled && id == DragAndDrop.activeControlID && fieldPosition.Contains(Event.current.mousePosition))
            {
               if (DragAndDrop.visualMode != DragAndDropVisualMode.None
                   && DragAndDrop.visualMode != DragAndDropVisualMode.Rejected)
               {
                  EditorGUI.DrawRect(fieldPosition, Color.white);
               }
            }
         }

         // Tint the control red, if the object cannot be found in the hierarchy
         var originalColor = GUI.backgroundColor;
         if (Cache.SceneObjectFound(name, text) == false)
         {
            GUI.backgroundColor = new Color(1, 0.5f, 0.5f, 1);
         }

         const string DefaultMessage = "\u0002(type to search)\u0003";

         var changed = false;
         var value = text;

         // When the text is longer than the field width, we want to draw it using Ellipsis at the beginning of the string.
         // This should be done only during Repaint and when the control is not being edited.
         if (Event.current.type == EventType.Repaint && UnityEditorExtensions.IsEditingControl(id) == false)
         {
            if (text == string.Empty)
            {
               text = DefaultMessage;
               style = new GUIStyle(style) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Italic };
            }

            var shortened = Ellipsis.Compact(text, style, fieldPosition, Ellipsis.Format.Start);
            GUI.Label(fieldPosition, shortened, style);
         }
         else
         {
            // Call the internal Unity control
            value = UnityEditorExtensions.DoTextField(id, fieldPosition, text, style, out changed);
         }

         if (text == DefaultMessage && value == DefaultMessage)
         {
            changed = false;
            value = string.Empty;
         }

         // Reset the tint
         GUI.backgroundColor = originalColor;

         // If the control is active and a selection has been made ...
         if (id == AutoCompletePopup.ParentControlID && string.IsNullOrEmpty(AutoCompletePopup.SelectedItem) == false)
         {
            value = AutoCompletePopup.SelectedItem;
            changed = true;
         }

         // The search button
         var buttonPosition = new Rect(position.xMax - 16, position.y, 16, position.height);
         if (GUI.Button(buttonPosition, SearchButton, Style.SceneObjectFieldSearchButton))
         {
            var hierarchyGameObject = GameObject.Find(value);
            if (hierarchyGameObject != null)
            {
               EditorGUIUtility.PingObject(hierarchyGameObject);
            }
         }

         // Refresh the cache if the node selection has changed
         Cache.Refresh();

         // Generate the object list, if necessary
         if (Cache.SceneObjects.ContainsKey(type) == false)
         {
            //Debug.Log(string.Format("GETTING OBJECTS FOR TYPE: {0}\n", type));

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

            objectPaths.Sort();

            var dictionary = new Dictionary<string, Cache.SceneObject>();
            for (var i = 0; i < objectPaths.Count; i++)
            {
               var objectPath = objectPaths[i];

               Cache.SceneObject sceneObject;
               if (dictionary.TryGetValue(objectPath, out sceneObject))
               {
                  sceneObject.ReferenceCount++;
               }
               else
               {
                  dictionary.Add(objectPath, new Cache.SceneObject(objectPath));
               }
            }

            Cache.SceneObjects.Add(type, dictionary);
         }

         // Update the auto-complete list, if the text has changed
         if (changed || hierarchyChanged)
         {
            hierarchyChanged = false;

            // Get the list of object we've already generated
            paths = Cache.SceneObjects[type].Keys.ToList();

            AutoCompletePopup.Reset();

            if (value != string.Empty)
            {
               for (var i = 0; i < paths.Count; i++)
               {
                  var path = paths[i];
                  var index = CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                     path,
                     value,
                     CompareOptions.OrdinalIgnoreCase);

                  var sceneObject = Cache.SceneObjects[type][path];
                  sceneObject.Matched = index > -1;

                  if (index > -1)
                  {
                     AutoCompletePopup.Add(sceneObject);
                  }
               }
            }

            AutoCompletePopup.Update(fieldPosition, value);
         }

         return value;
      }

      internal static void OnHierarchyChange()
      {
         Cache.Refresh(true);
         hierarchyChanged = true;

         // Repaint so the editor looks more responsive. The focus is generally on the Hierarchy
         // window when the event is triggered, which would normally delay the uScript Editor
         // window repaint.
         uScript.RequestRepaint();
      }

      // ReSharper disable once RedundantNameQualifier
      private static UnityEngine.Object ValidateSceneObjectPathFieldAssignment(
         UnityEngine.Object[] references,
         Type type,
         SerializedProperty property)
      {
         // This validator accepts any number of UnityEngine.Objects
         // and returns the first compatible object in the array.

         if (references.Length <= 0)
         {
            return null;
         }

         if (typeof(Component).IsAssignableFrom(type))
         {
            // We want a component, so accept nothing other than a component.
            foreach (var reference in references)
            {
               var gameObject = reference as GameObject;
               if (gameObject != null && EditorUtility.IsPersistent(gameObject) == false)
               {
                  var components = gameObject.GetComponents(typeof(Component));
                  foreach (var component in components.Where(type.IsInstanceOfType))
                  {
                     return component;
                  }
               }
            }

            return null;
         }

         // ... otherwise return the first GameObject in the array.
         for (var i = 0; i < references.Length; i++)
         {
            var gameObject = references[i] as GameObject;
            if (gameObject != null && EditorUtility.IsPersistent(gameObject) == false)
            {
               return gameObject;
            }
         }

         return null;
      }

      public static class Cache
      {
         private static readonly Dictionary<string, Dictionary<string, bool>> GameObjectFindCache;

         private static List<Guid> selectedObjects;

         static Cache()
         {
            SceneObjects = new Dictionary<Type, Dictionary<string, SceneObject>>();
            selectedObjects = new List<Guid>();

            GameObjectFindCache = new Dictionary<string, Dictionary<string, bool>>();
         }

         public static Dictionary<Type, Dictionary<string, SceneObject>> SceneObjects { get; private set; }

         public static bool SceneObjectFound(string propertyName, string hierarchyPath)
         {
            if (GameObjectFindCache.ContainsKey(propertyName) == false)
            {
               GameObjectFindCache.Add(
                  propertyName,
                  new Dictionary<string, bool> { { hierarchyPath, GameObject.Find(hierarchyPath) } });
            }
            else if (GameObjectFindCache[propertyName].ContainsKey(hierarchyPath) == false)
            {
               GameObjectFindCache[propertyName].Clear();
               GameObjectFindCache[propertyName].Add(hierarchyPath, GameObject.Find(hierarchyPath));
            }

            return GameObjectFindCache[propertyName][hierarchyPath];
         }

         public static void Refresh(bool ignoreSelection = false)
         {
            if (ignoreSelection == false)
            {
               var newSelection = uScript.Instance.ScriptEditorCtrl.PropertyGrid.SelectedGuidArray.OrderBy(t => t);
               if (selectedObjects.SequenceEqual(newSelection))
               {
                  return;
               }

               selectedObjects = newSelection.ToList();
            }

            GameObjectFindCache.Clear();
            SceneObjects.Clear();
         }

         public class SceneObject
         {
            public SceneObject(string path)
            {
               this.Path = path;
               this.ReferenceCount = 1;
            }

            public string Markup { get; set; }

            public bool Matched { get; set; }

            public string Path { get; private set; }

            public int ReferenceCount { get; set; }
         }
      }

      private static class Style
      {
         static Style()
         {
            SceneObjectFieldSearchButton = new GUIStyle(GUI.skin.button)
               {
                  padding = new RectOffset(0, 0, 0, 0),
                  contentOffset = new Vector2(1, 0),
                  normal = EditorStyles.label.normal,
                  active = EditorStyles.label.active,
               };
         }

         public static GUIStyle SceneObjectFieldSearchButton { get; private set; }
      }
   }
}
