// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Property type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using System.Globalization;
   using System.IO;
   using System.Linq;
   using System.Reflection;

   using Detox.FlowChart;
   using Detox.ScriptEditor;

   using UnityEditor;

   using UnityEngine;

   public static class Property
   {
      public static readonly Dictionary<string, bool> FoldoutExpanded = new Dictionary<string, bool>();

      // How deep to scan (of course you can also pass it to the method).
      private const int MaximumFolderRecursionDepth = 12;

      private static readonly Dictionary<int, string> ControlIDList = new Dictionary<int, string>();

      private static int propertyCount;   // Needed for VariableNameField()

      private static Column columnEnabled;
      private static Column columnLabel;
      private static Column columnValue;
      private static Column columnType;

      private static string nodeKey = string.Empty;
      private static int focusedControlID = -1;

      private static Vector2 columnOffset;
      private static Rect scrollviewRect;
      private static string focusedControl = string.Empty;

      private static Type guiLayoutOptionEnumType;
      private static string[] guiLayoutOptionEnumOptions;
      private static string[] guiLayoutOptionDisplayNames;

      private static List<string> resourcePaths;

      /// <summary>
      /// Gets a string array containing the display name of each selectable GUILayoutOption.Type option.
      /// </summary>
      public static string[] GUILayoutOptionDisplayNames
      {
         get
         {
            if (guiLayoutOptionDisplayNames == null)
            {
               var names = new List<string>();
               foreach (var option in GUILayoutOptionEnumNames)
               {
                  switch (option)
                  {
                     case "fixedWidth":
                        names.Add("Width");
                        break;

                     case "fixedHeight":
                        names.Add("Height");
                        break;

                     case "minWidth":
                        names.Add("MinWidth");
                        break;

                     case "maxWidth":
                        names.Add("MaxWidth");
                        break;

                     case "minHeight":
                        names.Add("MinHeight");
                        break;

                     case "maxHeight":
                        names.Add("MaxHeight");
                        break;

                     case "stretchWidth":
                        names.Add("ExpandWidth");
                        break;

                     case "stretchHeight":
                        names.Add("ExpandHeight");
                        break;

                     default:
                        Debug.LogError("Unhandled GUILayoutOption.Type value: \"" + option + "\"\n");
                        break;
                  }
               }

               guiLayoutOptionDisplayNames = names.ToArray();
            }

            return guiLayoutOptionDisplayNames;
         }
      }

      /// <summary>
      /// Gets a string array containing the enumeration name of each selectable GUILayoutOption.Type option.
      /// </summary>
      public static string[] GUILayoutOptionEnumNames
      {
         get
         {
            if (guiLayoutOptionEnumOptions == null)
            {
               // Filter out all unnecessary options
               var names = new List<string>();
               foreach (var option in Enum.GetNames(GUILayoutOptionEnumType))
               {
                  switch (option)
                  {
                     case "fixedWidth":
                     case "fixedHeight":
                     case "minWidth":
                     case "maxWidth":
                     case "minHeight":
                     case "maxHeight":
                     case "stretchWidth":
                     case "stretchHeight":
                        names.Add(option);
                        break;
                  }
               }

               guiLayoutOptionEnumOptions = names.ToArray();
            }

            return guiLayoutOptionEnumOptions;
         }
      }

      private static Type GUILayoutOptionEnumType
      {
         get
         {
            if (guiLayoutOptionEnumType == null)
            {
               var option = GUILayout.Width(0);
               var fields = option.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

               // should have two fields "type" and "value" ... we just care about "type"
               foreach (var field in fields.Where(field => field.Name == "type"))
               {
                  guiLayoutOptionEnumType = field.GetValue(option).GetType();
               }
            }

            return guiLayoutOptionEnumType;
         }
      }

      private static string WatchedControlName { get; set; }

      public static void BeginColumns(string col1, string col2, string col3, Vector2 offset, Rect rect)
      {
         columnEnabled = new Column(string.Empty, 20);
         columnLabel = new Column(col1, 140);
         columnValue = new Column(col2, 220);
         columnType = new Column(col3, 0);

         propertyCount = 0;   // Needed for VariableNameField()

         columnOffset = offset;
         scrollviewRect = rect;

         GUILayout.Label(string.Empty, new GUIStyle(), GUILayout.Height(Style.ColumnHeaderHeight));

         Style.Label.fixedWidth = columnLabel.Width;
      }

      public static bool BeginPropertyList(string label, Node node)
      {
         ScriptEditorCtrl scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
         EntityNode entityNode = null;

         nodeKey = node != null ? node.Guid.ToString() : "UNKNOWN";
         if (false == FoldoutExpanded.ContainsKey(nodeKey))
         {
            FoldoutExpanded[nodeKey] = true;
         }

         var isFoldoutExpanded = FoldoutExpanded[nodeKey];

         GUILayout.BeginHorizontal();
         {
            // Foldout
            var tmpColor = GUI.color;
            var textColor = uScriptGUIStyle.NodeButtonLeft.normal.textColor;

            if (null != node)
            {
               entityNode = ((DisplayNode)node).EntityNode;

               if (uScript.IsNodeTypeDeprecated(entityNode) || scriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(entityNode))
               {
                  GUI.color = new Color(1, 0.5f, 1, 1);
                  uScriptGUIStyle.NodeButtonLeft.normal.textColor = Color.white;
               }
            }

            // Socket segment
            GUILayout.Box(GUIContent.none, Style.ButtonLeft);

#if UNITY_3_5
   // EditorGUI.showMixedValue was introduced in Unity 3.5

   // Display socket toggle, if appropriate
         if (isFoldoutExpanded)
         {
            if (node != null)
            {
               int expandCount = 0;
               int collapseCount = 0;

               foreach (Parameter p in entityNode.Parameters)
               {
                  if (scriptEditorCtrl.CanExpandParameter(p))
                  {
                     expandCount++;
                  }
                  else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, p))
                  {
                     collapseCount++;
                  }
               }

               if (scriptEditorCtrl.CanExpandParameter(entityNode.Instance))
               {
                  expandCount++;
               }
               else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, entityNode.Instance))
               {
                  collapseCount++;
               }

               if (expandCount != 0 || collapseCount != 0)
               {
                  Rect toggleRect = GUILayoutUtility.GetLastRect();
                  toggleRect.x += 3;
                  toggleRect.y += 1;
                  toggleRect.width = 20;
                  toggleRect.height = 20;

                  bool toggleState = (collapseCount > 0);

                  if (expandCount > 0 && collapseCount > 0)
                  {
                     EditorGUI.showMixedValue = true;
                  }

                  // The "ToggleMixed" style does not exist in Unity 3.x
                  GUIStyle toggleStyle = UnityEngine.GUI.skin.toggle;

                  EditorGUI.BeginChangeCheck();
                  toggleState = UnityEngine.GUI.Toggle(toggleRect, toggleState, GUIContent.none, toggleStyle);
                  if (EditorGUI.EndChangeCheck())
                  {
                     // When showing a mixed value on Unity 3.x, the toggle returns True when pressed.
                     // It returns False on Unity 4.x.
                     if (EditorGUI.showMixedValue)
                     {
                        toggleState = !toggleState;
                     }

                     if (toggleState)
                     {
                        scriptEditorCtrl.ExpandNode(node);
                     }
                     else
                     {
                        scriptEditorCtrl.CollapseNode(node);
                     }
                  }

                  EditorGUI.showMixedValue = false;
               }
            }
         }
#endif

            // Name segment
            if (uScript.IsDevelopmentBuild)
            {
               // Add the node key for development builds
               label += string.Format("\t\t[{0}]", nodeKey);
            }

            isFoldoutExpanded = GUILayout.Toggle(
               isFoldoutExpanded,
               label,
               node == null ? Style.ButtonRightName : Style.ButtonMiddleName);

            // Node buttons
            if (null != node)
            {
               // Deprecation button
               if (uScript.IsNodeTypeDeprecated(entityNode) == false && scriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(entityNode))
               {
                  if (scriptEditorCtrl.ScriptEditor.CanUpgradeNode(entityNode))
                  {
                     if (GUILayout.Button(uScriptGUIContent.buttonNodeUpgrade, Style.BttonMiddleDeprecated))
                     {
                        var click = new EventHandler(scriptEditorCtrl.m_MenuUpgradeNode_Click);

                        // clear all selected nodes first
                        scriptEditorCtrl.DeselectAll();

                        // toggle the clicked node
                        scriptEditorCtrl.ToggleNode(node.Guid);
                        click(null, new EventArgs());
                     }
                  }
                  else
                  {
                     if (GUILayout.Button(uScriptGUIContent.buttonNodeDeleteMissing, Style.BttonMiddleDeprecated))
                     {
                        var click = new EventHandler(scriptEditorCtrl.m_MenuDeleteMissingNode_Click);

                        // clear all selected nodes first
                        scriptEditorCtrl.DeselectAll();

                        // toggle the clicked node
                        scriptEditorCtrl.ToggleNode(node.Guid);
                        click(null, new EventArgs());
                     }
                  }
               }

               // Favorite button
               var favoriteNodeType = uScript.GetNodeSignature(entityNode);
               var favoriteNodes = uScript.Preferences.FavoriteNodes;
               var favoriteIndex = Array.IndexOf(favoriteNodes, favoriteNodeType) + 1;

               var newIndex = EditorGUILayout.Popup(favoriteIndex, uScriptGUIPanelPalette.Instance.FavoritePopupOptions, Style.ButtonMiddleFavorite, GUILayout.Width(30));
               if (newIndex != favoriteIndex)
               {
                  if (favoriteIndex == 0)
                  {
                     uScript.Preferences.UpdateFavoriteNode(newIndex, favoriteNodeType);
                  }
                  else if (newIndex == 0)
                  {
                     uScript.Preferences.UpdateFavoriteNode(favoriteIndex, string.Empty);
                  }
                  else
                  {
                     uScript.Preferences.SwapFavoriteNodes(favoriteIndex, newIndex);
                  }

                  uScriptGUIPanelPalette.Instance.BuildFavoritesMenu();
               }

               // Favorite star
               var popupRect = GUILayoutUtility.GetLastRect();

               GUI.Label(popupRect, new GUIContent("\u2605"), Style.ButtonMiddleFavoriteStar);

               // Search button
               if (GUILayout.Button(uScriptGUIContent.buttonNodeFind, Style.ButtonRightSearch))
               {
                  scriptEditorCtrl.CenterOnNode(node);
               }

               GUI.color = tmpColor;
               uScriptGUIStyle.NodeButtonLeft.normal.textColor = textColor;
            }  // Node buttons
         }

         GUILayout.EndHorizontal();

         // add a little extra space after the node foldout
         GUILayout.Space(2);

         // begin the first property of each node as an "odd" row
         Style.ResetBackground();

         // store the foldout state for future use
         FoldoutExpanded[nodeKey] = isFoldoutExpanded;

         return isFoldoutExpanded;
      }

      /// <summary>Creates a GUILayoutOption object using the specified parameters.</summary>
      /// <returns>A GUILayoutOption object.</returns>
      /// <param name='optionIndex'>The GUILayoutOption enumeration index.</param>
      /// <param name='optionValue'>The GUILayoutOption value as an integer.</param>
      public static GUILayoutOption CreateGUILayoutOption(int optionIndex, int optionValue)
      {
         return CreateGUILayoutOption(GUILayoutOptionDisplayNames[optionIndex], optionValue);
      }

      public static GUILayoutOption CreateGUILayoutOption(string optionName, int optionValue)
      {
         switch (optionName)
         {
            case "Width":
               return GUILayout.Width(optionValue);

            case "Height":
               return GUILayout.Height(optionValue);

            case "MinWidth":
               return GUILayout.MinWidth(optionValue);

            case "MaxWidth":
               return GUILayout.MaxWidth(optionValue);

            case "MinHeight":
               return GUILayout.MinHeight(optionValue);

            case "MaxHeight":
               return GUILayout.MaxHeight(optionValue);

            case "ExpandWidth":
               return GUILayout.ExpandWidth(optionValue != 0);

            case "ExpandHeight":
               return GUILayout.ExpandHeight(optionValue != 0);
         }

         Debug.LogError("Unhandled option type: " + optionName + "\n");
         return null;
      }

      /// <summary>Deconstructs the specified GUILayoutOption object into individual variables.</summary>
      /// <returns>True if the deconstruction succeeded, False otherwise.</returns>
      /// <param name='option'>The GUILayoutOption object to split.</param>
      /// <param name='optionIndex'>The GUILayoutOption enumeration index.</param>
      /// <param name='optionValue'>The GUILayoutOption value as an integer.</param>
      public static bool DeconstructGUILayoutOption(GUILayoutOption option, out int optionIndex, out int optionValue)
      {
         var optionType = string.Empty;
         optionValue = 0;

         var fields = option.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

         // should have two fields "type" and "value"
         foreach (var field in fields)
         {
            switch (field.Name)
            {
               case "type":
                  optionType = field.GetValue(option).ToString();
                  break;

               case "value":
                  optionValue = Convert.ToInt32(field.GetValue(option));
                  break;

               default:
                  Debug.LogError("Unknown field found in GUILayoutOption!\n");
                  break;
            }
         }

         optionIndex = Array.IndexOf(GUILayoutOptionEnumNames, optionType);
         if (optionIndex == -1)
         {
            optionIndex = 0;
            optionValue = 0;
            return false;
         }

         return true;
      }

      public static object Draw(string label, object value, State state)
      {
         Type unityObjectType;

         if (value is Array)
         {
            if (value is bool[])
            {
               value = ArrayFoldout(label, (bool[])value, state);
            }
            else if (value is int[])
            {
               value = ArrayFoldout(label, (int[])value, state);
            }
            else if (value is float[])
            {
               value = ArrayFoldout(label, (float[])value, state);
            }
            else if (value is double[])
            {
               value = ArrayFoldout(label, (double[])value, state);
            }
            else if (value is Vector2[])
            {
               value = ArrayFoldout(label, (Vector2[])value, state);
            }
            else if (value is Vector3[])
            {
               value = ArrayFoldout(label, (Vector3[])value, state);
            }
            else if (value is Vector4[])
            {
               value = ArrayFoldout(label, (Vector4[])value, state);
            }
            else if (value is Rect[])
            {
               value = ArrayFoldout(label, (Rect[])value, state);
            }
            else if (value is Quaternion[])
            {
               value = ArrayFoldout(label, (Quaternion[])value, state);
            }
            else if (value is Color[])
            {
               value = ArrayFoldout(label, (Color[])value, state);
            }
            else if (value is GUILayoutOption[])
            {
               value = ArrayFoldout(label, (GUILayoutOption[])value, state);
            }
            else if (value is LayerMask[])
            {
               value = ArrayFoldout(label, (LayerMask[])value, state);
            }
            else if (value is Enum[])
            {
               // Use state.Type to figure out the specific enum type
               var enumType = uScript.Instance.GetType(state.Type.Replace("[]", string.Empty));
               value = ArrayFoldout(label, (Enum[])value, state, enumType);
            }
            else if (TryParseUnityObjectArrayType(state.Type, out unityObjectType))
            {
               // Arrays are stored as comma delimited string, so parse it now
               var values = Parameter.StringToArray(state.DefaultValueAsString);
               values = ArrayFoldout(label, values, state, unityObjectType.GetElementType());
               value = Parameter.ArrayToString(values);
            }
            else if (state.Type.Contains("[]"))
            {
               var values = Parameter.StringToArray(state.DefaultValueAsString);
               value = ArrayFoldout(label, values, state);
            }

            return value;
         }

         // Handle AssetPathFields separately, since they have custom behavior.
         if (AssetType.Invalid != uScript.GetAssetPathField(state.EntityNode, state.Name))
         {
            return AssetPathField(
               label,
               uScript.GetAssetPathField(state.EntityNode, state.Name),
               state.DefaultValueAsString,
               state);
         }

         var type = value.GetType().ToString();
         var width = columnValue.Width;

         BeginRow(label, state);
         {
            if (state.IsSocketExposed && (state.IsLocked || state.IsReadOnly))
            {
               var text = state.IsReadOnly ? "(read-only)" : "(socket used)";
               EditorGUILayout.TextField(text, Style.TextField, GUILayout.Width(width));
            }
            else
            {
               if (value is bool)
               {
                  value = BoolField((bool)value);
               }
               else if (value is int)
               {
                  value = IntField((int)value);
               }
               else if (value is float)
               {
                  value = FloatField((float)value);
               }
               else if (value is double)
               {
                  value = (double)FloatField((float)value);
               }
               else if (value is Vector2)
               {
                  value = Vector2Field((Vector2)value);
                  type = string.Format("{0} [X, Y]", value.GetType());
               }
               else if (value is Vector3)
               {
                  value = Vector3Field((Vector3)value);
                  type = string.Format("{0} [X, Y, Z]", value.GetType());
               }
               else if (value is Vector4)
               {
                  value = Vector4Field((Vector4)value);
                  type = string.Format("{0} [X, Y, Z, W]", value.GetType());
               }
               else if (value is Rect)
               {
                  value = RectField((Rect)value);
                  type = string.Format("{0} [X, Y, W, H]", value.GetType());
               }
               else if (value is Quaternion)
               {
                  value = QuaternionField((Quaternion)value);
                  type = string.Format("{0} [X, Y, Z, W]", value.GetType());
               }
               else if (value is Color)
               {
                  value = ColorField((Color)value);
               }
               else if (value is GUILayoutOption)
               {
                  value = GUILayoutOptionField((GUILayoutOption)value);
                  type = "GUILayoutOption";
               }
               else if (value is LayerMask)
               {
                  value = LayerMaskField((LayerMask)value);
               }
               else if (value is Enum)
               {
                  value = EnumField((Enum)value);
               }
               else if (TryParseUnityObjectType(state.Type, out unityObjectType))
               {
                  if (value.ToString() != state.DefaultValueAsString)
                  {
                     Debug.LogWarning(string.Format("value ({0}) does not equal state.Default ({1})\n", value, state.DefaultValueAsString));
                  }

                  value = UnityObjectField((string)value, unityObjectType);
                  type = unityObjectType.ToString();
               }
               else
               {
                  // Treat everything else as a string

                  if (value.ToString() != state.DefaultValueAsString)
                  {
                     Debug.LogWarning(string.Format("value ({0}) does not equal state.Default ({1})\n", value, state.DefaultValueAsString));
                  }

                  if (uScriptConfig.Variable.FriendlyName(state.Type) == "TextArea")
                  {
                     // Should "state.Default" be passed instead of "value"?
                     value = TextArea((string)value);
                  }
                  else if (label == "Name" || label == "Friendly Name")
                  {
                     // Should "state.Default" be passed instead of "value"?
                     value = TextField((string)value);

                     // TODO: Disable VariableNameField until needed, as Unity 4.1 has issues.
                     //value = VariableNameField(label, p.Default, state);
                  }
                  else
                  {
                     // Should "state.Default" be passed instead of "value"?
                     value = TextArea((string)value);
                  }
               }
            }
         }
         EndRow(type);

         return value;
      }

      public static void DrawText(string label, string text, State state)
      {
         var tempState = new State(state.IsSocketExposed, state.IsLocked, true);
         BeginRow(label, tempState);
         state.IsSocketExposed = tempState.IsSocketExposed;

         EditorGUILayout.TextField(text, Style.TextField, GUILayout.Width(columnValue.Width));

         EndRow(string.Empty);
      }

      public static void EndColumns()
      {
         var x = 0;
         var y = columnOffset.y;

         // The columns have a margin of 4. Margins of adjacent cells overlap, so the spacing
         // between columns is the width of the largest margin, not the sum.
         //
         //    4.[A].4
         //          4.[B].4
         //                4.[C].4
         //
         //    4.[A].4.[B].4.[C].4
         //
         // The result should be that when laying out each column, the left-most and right-most
         // columns should allow for an extra 2px, while the inner columns assume that 2px will
         // be used on each side.
         //
         // Finally, the left margin of the left column, and the right margin of the right column
         // is excluded when positioning the GUI elements, since the offset is automatically applied.

         // First column - Checkbox
         GUI.Label(new Rect(x, y, columnEnabled.Width + 4 + 2, Style.ColumnHeaderHeight), columnEnabled.Label, Style.ColumnHeader);
         x += columnEnabled.Width + 2;

         // Interior column - Property name
         GUI.Label(new Rect(x, y, columnLabel.Width + 4, Style.ColumnHeaderHeight), columnLabel.Label, Style.ColumnHeader);
         x += columnLabel.Width + 4;

         // Interior column - Property value
         GUI.Label(new Rect(x, y, columnValue.Width + 4, Style.ColumnHeaderHeight), columnValue.Label, Style.ColumnHeader);
         x += columnValue.Width + 4;

         // Last column - Property type
         // This right-most column should appear to have an expanded width

         var position = new Rect(x, y, scrollviewRect.width, Style.ColumnHeaderHeight);
         GUI.Label(position, columnType.Label, Style.ColumnHeader);

         //      GUI.Label(new Rect(x, y, _columnType.Width + 4 + 2, columnHeaderHeight), _columnType.Label, style);
         //      GUI.Label(new Rect(x, y, svRect.width - _columnLabel.Width - ValueColumn.Width - 22 + columnOffset.x, columnHeaderHeight), _columnType.Label, style);

         // Update control focus changes

         //if (Event.current.keyCode == KeyCode.Escape)
         //{
         //   Debug.Log("ESC was pressed\n");
         //   Event.current.Use();
         //}

         if (GUI.GetNameOfFocusedControl() != focusedControl)
         {
            uScriptDebug.Log("Control focus changed from '" + focusedControl + "' to '" + GUI.GetNameOfFocusedControl() + "'\n", uScriptDebug.Type.Debug);

            //previousControl = focusedControl;
            focusedControl = GUI.GetNameOfFocusedControl();
         }
      }

      public static void EndPropertyList()
      {
         if (FoldoutExpanded[nodeKey])
         {
            GUILayout.Space(10);
         }
      }

      public static void MonitorGUIControlFocusChanges()
      {
         // TODO: Disable or comment out until needed. Only used by VariableNameField()
         if (GUIUtility.keyboardControl != focusedControlID)
         {
            if (ControlIDList.ContainsKey(focusedControlID))
            {
               var oldControlName = ControlIDList[focusedControlID];

               //            string newName = "UNKNOWN";
               //            if (controlIDList.ContainsKey(GUIUtility.keyboardControl))
               //            {
               //               newName = controlIDList[GUIUtility.keyboardControl];
               //            }
               //            Debug.Log("FOCUS CHANGED: \t" + focusedControlID.ToString() + " (" + oldName + ") -> " + GUIUtility.keyboardControl.ToString() + " (" + newName + ")\n");

               // When specific fields lose focus, send out an event
               if (oldControlName == WatchedControlName)
               {
                  uScriptDebug.Log(
                     string.Format(
                        "The control lost focus: {0} (\"{1}\")\n",
                        focusedControlID.ToString(CultureInfo.InvariantCulture),
                        WatchedControlName),
                     uScriptDebug.Type.Debug);
               }
            }

            focusedControlID = GUIUtility.keyboardControl;
         }
      }

      public static void ResetFoldouts()
      {
         FoldoutExpanded.Clear();
      }

      private static T[] ArrayAppend<T>(IEnumerable<T> array, T val)
      {
         var list = new List<T>(array) { val };
         return list.ToArray();
      }

      private static T ArrayElementRow<T>(ref T[] array, int index, T value, State state, Type type)
      {
         var r1 = GUILayoutUtility.GetLastRect();
         r1.y = r1.yMax + 2;

         EditorGUI.indentLevel += 2;

         BeginRow(string.Format("[{0}]", index.ToString(CultureInfo.InvariantCulture)), state);

         EditorGUI.indentLevel -= 2;

         // Get the last rect to determine where we want to draw the array modifier buttons
         var row = GUILayoutUtility.GetLastRect();

         var btnRect = row;
         btnRect.x = btnRect.xMax - 30;
         btnRect.width = 18;
         btnRect.height = 16;

         // Determine the rect for the entire property panel row
         row.x = uScriptGUIPanel.Rect.x;
         row.width = uScriptGUIPanel.Rect.width;

         if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayRemove, Style.ArrayTextButton))
         {
            GUIUtility.keyboardControl = 0;
            array = ArrayRemove(array, index);
         }

         btnRect.x -= 18;

         if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayDuplicate, Style.ArrayTextButton))
         {
            GUIUtility.keyboardControl = 0;
            array = ArrayInsert(array, index, array[index]);
         }

         btnRect.x -= 18;

         if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayInsert, Style.ArrayTextButton))
         {
            GUIUtility.keyboardControl = 0;

            // Special conversion case for strings and GUILayoutOption objects
            var element = typeof(T) == typeof(string)
                             ? (T)(object)string.Empty
                             : (typeof(T) == typeof(GUILayoutOption)
                                   ? (T)(object)GUILayout.Width(0)
                                   : default(T));

            array = ArrayInsert(array, index, element);
         }

         object t = value;
         var typeFormat = string.Empty;

         if (value is int)
         {
            t = IntField((int)t);
         }
         else if (value is float)
         {
            t = FloatField((float)t);
         }
         else if (value is bool)
         {
            t = BoolField((bool)t);
         }
         else if (value is Enum)
         {
            t = EnumField((Enum)t);
         }
         else if (value is GUILayoutOption)
         {
            t = GUILayoutOptionField((GUILayoutOption)t);
         }
         else if (value is Color)
         {
            t = ColorField((Color)t);
         }
         else if (value is Vector2)
         {
            t = Vector2Field((Vector2)t);
            typeFormat = " [X, Y]";
         }
         else if (value is Vector3)
         {
            t = Vector3Field((Vector3)t);
            typeFormat = " [X, Y, Z]";
         }
         else if (value is Vector4)
         {
            t = Vector4Field((Vector4)t);
            typeFormat = " [X, Y, Z, W]";
         }
         else if (value is Rect)
         {
            t = RectField((Rect)t);
            typeFormat = " [X, Y, W, H]";
         }
         else if (value is Quaternion)
         {
            t = QuaternionField((Quaternion)t);
            typeFormat = " [X, Y, Z, W]";
         }
         else if (type != null && typeof(UnityEngine.Object).IsAssignableFrom(type))
         {
            t = UnityObjectField((string)t, type);
         }
         else if (value is string)
         {
            //if (type != null)
            //{
            //   Debug.LogWarning("This is obsolete\n");

            //   EditorGUILayout.BeginHorizontal(GUILayout.Width(columnValue.Width));
            //   {
            //      t = EditorGUILayout.TextField((string)t, Style.TextField, GUILayout.ExpandWidth(true));
            //      var r = GUILayoutUtility.GetLastRect();

            //      if (r.Contains(Event.current.mousePosition) && GUI.enabled)
            //      {
            //         var objectReferences = DragAndDrop.objectReferences;

            //         if (objectReferences.Length == 1)
            //         {
            //            if (objectReferences[0] is GameObject)
            //            {
            //               var go = objectReferences[0] as GameObject;

            //               DragAndDrop.visualMode = DragAndDropVisualMode.Link;

            //               if (Event.current.type == EventType.DragPerform)
            //               {
            //                  t = uScriptUtility.GetHierarchyPath(go.transform);
            //                  GUI.changed = true;
            //                  DragAndDrop.AcceptDrag();
            //                  DragAndDrop.activeControlID = 0;
            //               }
            //            }

            //            Event.current.Use();
            //         }
            //      }

            //      uScriptGUI.Enabled = string.IsNullOrEmpty((string)t) == false;

            //      if (GUILayout.Button(uScriptGUIContent.buttonArraySearch, Style.ArrayIconButton))
            //      {
            //         GUIUtility.keyboardControl = 0;
            //         GameObject go = GameObject.Find((string)t);
            //         if (go != null)
            //         {
            //            EditorGUIUtility.PingObject(go);
            //         }
            //         else
            //         {
            //            Debug.LogWarning(
            //               string.Format(
            //                  "No GameObject matching \"{0}\" was found in the Scene.\n\tAn associated Game Object may not yet exist, or might not be active.  Game Object names may contain leading and trailing whitespace.\n",
            //                  t));
            //         }
            //      }

            //      uScriptGUI.Enabled = true;
            //   }

            //   EditorGUILayout.EndHorizontal();
            //}

            t = TextArea((string)t, minLines: 1, maxLines: 5);
         }
         else
         {
            Debug.LogWarning(string.Format("Unhandled array type: {0}\n", value.GetType()));

            //throw System.ArgumentException("Unhandled type: " + value.GetType().ToString());
         }

         value = (T)t;

         EndRow(type != null ? type.ToString() : value.GetType() + typeFormat);
         return value;
      }

      private static T[] ArrayFoldout<T>(string label, T[] array, State state, Type type = null)
      {
         var propertyKey = string.Format("{0}_{1}", nodeKey, label);
         var isExpanded = !FoldoutExpanded.ContainsKey(propertyKey) || FoldoutExpanded[propertyKey];

         // The Foldout row
         BeginFoldoutRow(label, state, ref isExpanded);

         // Display the array info, readonly, socketUsed, or an empty area
         var isFieldUsable = IsFieldUsable(state);
         if (isFieldUsable)
         {
            var text = string.Format("... ({0} {1})", array.Length, array.Length == 1 ? "item" : "items");
            GUILayout.Label(text, Style.Label, GUILayout.Width(columnValue.Width));

            var btnRect = GUILayoutUtility.GetLastRect();
            btnRect.x = btnRect.xMax - 18;
            btnRect.width = 18;
            btnRect.height = 16;

            if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayAdd, Style.ArrayTextButton))
            {
               GUIUtility.keyboardControl = 0;

               // Special conversion case for strings and GUILayoutOption objects
               var element = typeof(T) == typeof(string)
                                ? (T)(object)string.Empty
                                : (typeof(T) == typeof(GUILayoutOption) ? (T)(object)GUILayout.Width(0) : default(T));
               array = ArrayAppend(array, element);
            }

            btnRect.x -= 18;

            if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayClear, Style.ArrayTextButton))
            {
               GUIUtility.keyboardControl = 0;
               array = new T[] { };
            }
         }

         EndRow(type != null ? string.Format("{0}[]", type) : array.GetType().ToString());

         // The array size
         if (isExpanded && isFieldUsable)
         {
            // The elements
            for (var i = 0; i < array.Length; i++)
            {
               var entry = default(T);

               if (i < array.Length)
               {
                  entry = array[i];
               }

               if (ReferenceEquals(entry, null))
               {
                  if (typeof(T) == typeof(Enum) && type != null)
                  {
                     entry = (T)Enum.Parse(type, Enum.GetNames(type)[0]);
                  }
               }

               var tempState = new State(false, true, false);
               array[i] = ArrayElementRow(ref array, i, entry, tempState, type);
            }
         }

         FoldoutExpanded[propertyKey] = isExpanded;

         return array;
      }

      private static T[] ArrayInsert<T>(T[] array, int index, T val)
      {
         if (index < 0 || index >= array.Length)
         {
            var log = string.Format("The specified index ({0}) is out of range [0..{1}]", index, array.Length - 1);
            uScriptDebug.Log(log, uScriptDebug.Type.Error);
            return array;
         }

         var list = new List<T>(array);
         list.Insert(index, val);
         return list.ToArray();
      }

      private static T[] ArrayRemove<T>(T[] array, int index)
      {
         if (index < 0 || index >= array.Length)
         {
            var log = string.Format("The specified index ({0}) is out of range [0..{1}]", index, array.Length - 1);
            uScriptDebug.Log(log, uScriptDebug.Type.Error);
            return array;
         }

         var list = new List<T>(array);
         list.RemoveAt(index);
         return list.ToArray();
      }

      private static string AssetPathField(string label, AssetType assetType, string assetPath, State state)
      {
         // Asset File Name
         //
         // The browser to default to the specific Resource folder path.
         // Once a file has been selected, validate that it exists in the previously specified
         // path. If not, make sure it exists under any Resource folder path, and update the
         // path control.
         //
         //    String field
         //    Button to launch file browser
         //    (exposed socket should be a string)

         //      string label = System.Enum.GetName(typeof(AssetType), (int)assetType) + " Path";

         var style = new GUIStyle(EditorStyles.miniButton)
         {
            margin = new RectOffset(4, 4, 2, 4),
            padding = new RectOffset(6, 6, 1, 2)
         };

         BeginRow(label, state);

         if (IsFieldUsable(state))
         {
            var buttonSize = style.CalcSize(new GUIContent("Browse"));

            assetPath = EditorGUILayout.TextField(assetPath, Style.TextField, GUILayout.Width(columnValue.Width - 4 - buttonSize.x));

            uScriptGUI.Enabled = !AssetBrowserWindow.isOpen;

            if (GUILayout.Button("Browse", style, GUILayout.Width(buttonSize.x)))
            {
               AssetBrowserWindow.assetType = assetType;
               AssetBrowserWindow.assetFilePath = assetPath;
               AssetBrowserWindow.shouldOpen = true;
               AssetBrowserWindow.nodeKey = nodeKey;

               //               AssetBrowserWindow.Init(resourcePath, AssetBrowserWindow.AssetType.Texture);
               //               AssetBrowserWindow.FocusWindowIfItsOpen<AssetBrowserWindow>();

               //               Debug.Log("BUTTON PRESSED\n");
               //               filepath = EditorUtility.OpenFilePanel(name, path, extension);
               //               Debug.Log("Results: " + filepath + "\n");
            }

            if (AssetBrowserWindow.nodeKey == nodeKey && AssetBrowserWindow.assetFilePath != string.Empty)
            {
               // Only get it once. Don't continue to get it, because it'll override
               // changes from other areas like undo/redo and drag/drop
               assetPath = AssetBrowserWindow.assetFilePath;
               AssetBrowserWindow.assetFilePath = string.Empty;
            }

            uScriptGUI.Enabled = true;
         }

         EndRow(assetPath.GetType().ToString());

         return assetPath;
      }

      private static void BeginFoldoutRow(string label, State state, ref bool isExpanded)
      {
         SetupRow(state);

         if (state.IsSocketExposed && (state.IsLocked || state.IsReadOnly))
         {
            EditorGUILayout.PrefixLabel(label, Style.Label);
         }
         else
         {
            isExpanded = GUILayout.Toggle(
               isExpanded,
               label,
               EditorStyles.foldout,
               GUILayout.Width(columnLabel.Width - 3));
         }

         uScriptGUI.Enabled = (!state.IsReadOnly) && (!state.IsSocketExposed || !state.IsLocked);
      }

      private static void BeginRow(string label, State state)
      {
         SetupRow(state);

         var enabled = (!state.IsReadOnly) && (!state.IsSocketExposed || !state.IsLocked);
         if (enabled)
         {
            EditorGUILayout.PrefixLabel(string.IsNullOrEmpty(label) ? " " : label, Style.Label);
         }
         else
         {
            GUILayout.Label(string.IsNullOrEmpty(label) ? " " : label, Style.Label);
         }

         uScriptGUI.Enabled = enabled;
      }

      private static bool BoolField(bool value)
      {
         return EditorGUILayout.Toggle(value, Style.BoolField, GUILayout.Width(columnValue.Width));
      }

      private static Color ColorField(Color value)
      {
         return EditorGUILayout.ColorField(value, GUILayout.Width(columnValue.Width));
      }

      private static void EndRow(string type)
      {
         type = uScriptConfig.Variable.FriendlyName(type).Replace("UnityEngine.", string.Empty);
         var v = Style.Type.CalcSize(new GUIContent(type));
         columnType.Width = Mathf.Max(columnType.Width, (int)v.x);

         uScriptGUI.Enabled = true;
         GUILayout.Label(type, Style.Type);
         EditorGUILayout.EndHorizontal();

         propertyCount++;  // Needed for VariableNameField()
      }

      private static Enum EnumField(Enum value)
      {
         return EditorGUILayout.EnumPopup(value, GUILayout.Width(columnValue.Width));
      }

      private static float FloatField(float value)
      {
         return EditorGUILayout.FloatField(value, Style.TextField, GUILayout.Width(columnValue.Width));
      }

      private static string GetControlName()
      {
         return GetControlName(string.Empty);
      }

      private static string GetControlName(string suffix)
      {
         return string.Format("{0}[{1}]{2}", nodeKey, propertyCount.ToString(CultureInfo.InvariantCulture), suffix);
      }

      private static T GetFieldValue<T>(Type type, string fieldName, BindingFlags bindingFlags)
      {
         var fieldInfo = type.GetField(fieldName, bindingFlags);
         uScriptDebug.Assert(fieldInfo != null, string.Format("Unable to access a field named \"{0}\"", fieldName));
         return (T)fieldInfo.GetValue(null);
      }

      private static T GetPropertyValue<T>(Type type, string propertyName, BindingFlags bindingFlags)
      {
         var propertyInfo = type.GetProperty(propertyName, bindingFlags);
         uScriptDebug.Assert(
            propertyInfo != null,
            string.Format("Unable to access a property named \"{0}\"", propertyName));
         return (T)propertyInfo.GetValue(null, null);
      }

      private static void GetResourceFolderPaths(string sourceDir, int recursionDepth)
      {
         if (recursionDepth > MaximumFolderRecursionDepth)
         {
            return;
         }

         // Grab the valid paths
         if ((sourceDir.EndsWith("/Resources") || sourceDir.Contains("/Resources/"))
             && sourceDir.Contains("/.svn") == false)
         {
            // get the substring we care about
            var path = sourceDir.Substring(sourceDir.IndexOf("Resources", StringComparison.Ordinal)).Replace('/', '\\');

            // add the path if it doesn't already exist
            if (resourcePaths.Contains(path) == false)
            {
               resourcePaths.Add(path);
            }

            // sort the list or it will place the paths in a strange order
            resourcePaths.Sort();
         }

         // Recurse into subdirectories of this directory.
         var directories = Directory.GetDirectories(sourceDir);
         foreach (var directory in directories.Where(path => (File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint))
         {
            GetResourceFolderPaths(directory, recursionDepth + 1);
         }
      }

      private static GUILayoutOption GUILayoutOptionField(GUILayoutOption value)
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);

         int index;
         int optionValue;

         DeconstructGUILayoutOption(value, out index, out optionValue);

         index = EditorGUILayout.Popup(index, GUILayoutOptionDisplayNames, GUILayout.Width(w));

         var optionName = GUILayoutOptionDisplayNames[index];
         if (optionName == "ExpandWidth" || optionName == "ExpandHeight")
         {
            var toggle = optionValue != 0;
            toggle = GUILayout.Toggle(toggle, GUIContent.none, Style.BoolField, GUILayout.Width(w + p));
            optionValue = toggle ? 1 : 0;
         }
         else
         {
            optionValue = EditorGUILayout.IntField(optionValue, Style.TextField, GUILayout.Width(w + p));
            optionValue = Math.Max(optionValue, 0);
         }

         return CreateGUILayoutOption(index, optionValue);
      }

      private static int IntField(int value)
      {
         return EditorGUILayout.IntField(value, Style.TextField, GUILayout.Width(columnValue.Width));
      }

      private static bool IsFieldUsable(State state)
      {
         if (!state.IsSocketExposed || (!state.IsLocked && !state.IsReadOnly))
         {
            return true;
         }

         EditorGUILayout.TextField(
            state.IsReadOnly ? "(read-only)" : "(socket used)",
            Style.TextField,
            GUILayout.Width(columnValue.Width));
         return false;
      }

      private static object LayerMaskField(LayerMask value)
      {
         //  0         1    Default
         //  1         2    TransparentFX
         //  2         4    Ignore Raycast
         //  3         8
         //  4        16    Water
         //  5        32
         //  6        64
         //  7       128
         //  8       256
         //  9       512
         // 10      1024    TEN

         var layer = uScriptUtility.Log2((uint)value.value);
         layer = EditorGUILayout.LayerField(layer, GUILayout.Width(columnValue.Width));
         return 1 << layer;

         // Later, if we support actual LayerMask fields, the popup control should
         // use labels like "xxx" or "xxx, xxx" or "xxx, xxx, xxx" or "Mixed ..."
         //
         // See the Camera Culling Mask in the Inspector for example
         //
         //      Nothing            0
         //      Everything        -1
         //   0  Default            1
         //   1  TransparentFX      2
         //   2  Ignore Raycast     4
         // ...
         //  31  Unnamed 31
      }

      private static Quaternion QuaternionField(Quaternion value)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, Style.TextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, Style.TextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, Style.TextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, Style.TextField, GUILayout.Width(w + p));

         return value;
      }

      private static Rect RectField(Rect value)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, Style.TextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, Style.TextField, GUILayout.Width(w));
         value.width = EditorGUILayout.FloatField(value.width, Style.TextField, GUILayout.Width(w));
         value.height = EditorGUILayout.FloatField(value.height, Style.TextField, GUILayout.Width(w + p));

         return value;
      }

      private static string ResourcePathField(string value, State state)
      {
         // Resource Path
         //
         // The control uses a standard popup control for path selection, although the current
         // selection is stored as a string.  The string array used for the popup should only
         // include all valid Resource folders under assets.
         //
         //    Popup control
         //    (exposed socket should be a string)

         if (resourcePaths == null || resourcePaths.Count == 0)
         {
            // Create the path list and populate it with Resource folders
            resourcePaths = new List<string>();
            GetResourceFolderPaths(Application.dataPath, 0);

            //         choices = _resourcePaths.ToArray();
         }

         BeginRow("Resource Path", state);

         if (IsFieldUsable(state))
         {
            var menuIndex = 0;
            for (var i = 0; i < resourcePaths.Count; i++)
            {
               if (resourcePaths[i] == value.Replace('/', '\\'))
               {
                  menuIndex = i;
               }
            }

            //send the new value to the popup and whatever it
            //returns (in case the user modified it here) is what our final value is
            //
            // When the popup control has options that include '/' characters, it automatically
            // creates subfolders for the popup. This is undesirable. Therefore, all '/' has been
            // replaced with '\', but the string returned by this function should use '/'.

            menuIndex = EditorGUILayout.Popup(menuIndex, resourcePaths.ToArray(), GUILayout.Width(columnValue.Width));
            value = resourcePaths[menuIndex].Replace('\\', '/');
         }

         EndRow(value.GetType().ToString());

         //      Debug.Log("Returning: " + value + "\n");
         return value;
      }

      private static void SetupRow(State state)
      {
         EditorGUILayout.BeginHorizontal(Style.RowBackground);

         if (state.IsSocketExposed == false && state.IsLocked)
         {
            GUILayout.Space(columnEnabled.Width + 4);
         }
         else
         {
            uScriptGUI.Enabled = state.IsLocked == false;
            state.IsSocketExposed = GUILayout.Toggle(
               state.IsSocketExposed,
               string.Empty,
               Style.Enabled,
               GUILayout.Width(columnEnabled.Width));
            uScriptGUI.Enabled = true;
         }

         // Display the column label
#if UNITY_3_5
         EditorGUIUtility.LookLikeControls(columnLabel.Width);
#else
         EditorGUIUtility.labelWidth = columnLabel.Width;
#endif
      }

      private static string TextArea(string value, int minLines = 2, int maxLines = 10)
      {
         const int LineHeight = 13;
         const int Padding = 3;

         var minLineHeight = Padding + (LineHeight * minLines);
         var maxLineHeight = Padding + (LineHeight * maxLines);

         var content = new GUIContent(value);
         var height = Mathf.Clamp(Style.TextArea.CalcHeight(content, columnValue.Width), minLineHeight, maxLineHeight);

         value = EditorGUILayout.TextArea(
            value,
            Style.TextArea,
            GUILayout.Width(columnValue.Width),
            GUILayout.Height(height));

         return value;
      }

      private static string TextField(string value)
      {
         return EditorGUILayout.TextField(value, Style.TextField, GUILayout.Width(columnValue.Width));
      }

      private static bool TryParseUnityObjectArrayType(string typeName, out Type type)
      {
         type = uScript.Instance.GetType(typeName);
         type = type != null && typeof(UnityEngine.Object[]).IsAssignableFrom(type) ? type : null;

         return type != null;
      }

      private static bool TryParseUnityObjectType(string typeName, out Type type)
      {
         type = uScript.Instance.GetType(typeName);
         type = type != null && typeof(UnityEngine.Object).IsAssignableFrom(type) ? type : null;

         return type != null;
      }

      private static string UnityObjectField(string value, Type type)
      {
         var objects = UnityEngine.Object.FindObjectsOfType(type);
         var unityObject = objects.FirstOrDefault(o => o.name == value);

         // Components should never be instances in the property grid.
         // We must refer to (and select) their parent game object
         if (typeof(Component).IsAssignableFrom(type))
         {
            if (null != unityObject)
            {
               unityObject = ((Component)unityObject).gameObject;
            }
         }

         unityObject = EditorGUILayout.ObjectField(unityObject, type, true, GUILayout.Width(columnValue.Width));

         // if that object (or the changed object) does exist, use it's name to update the property value
         // if it doesn't exist then the 'val' will stay as what was entered into the TextField
         return unityObject != null ? unityObject.name : string.Empty;
      }

      //private static string UnityObjectField_ORIGINAL(string value, Type type)
      //{
      //   // now try and update the object browser with an instance of the specified object
      //   var objects = UnityEngine.Object.FindObjectsOfType(type);
      //   var unityObject = objects.FirstOrDefault(o => o.name == value);

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
      //   return unityObject != null ? unityObject.name : string.Empty;
      //}

      private static string VariableNameField(string label, string value, State state)
      {
         BeginRow(label, state);

         if (IsFieldUsable(state))
         {
            // FIXME: Unity 4.1 has issues here as well, which should be fixed before this control is used.  See: http://uscript.net/forum/viewtopic.php?f=11&t=2434

            // Rebuild the functionality of the Unity TextField so that we can
            // assign the ControlID ourselves, and keep track if it for later use

            // Use reflection to access some internal or sealed members from
            // EditorGUI ... why Unity? Why?
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;

            // Unity 3.x uses a FIELD, whereas Unity 4.x uses a PROPERTY. Ugh.
            var maxWidth = uScript.UnityVersion < 4.0f
                              ? GetFieldValue<float>(typeof(EditorGUILayout), "kLabelFloatMaxW", Flags)
                              : GetPropertyValue<float>(typeof(EditorGUILayout), "kLabelFloatMaxW", Flags);
            var minWidth = GetFieldValue<float>(typeof(EditorGUI), "kNumberW", Flags);

            var style = Style.TextField;
            var position = GUILayoutUtility.GetRect(minWidth, maxWidth, 16f, 16f, style, GUILayout.Width(columnValue.Width));
            var controlName = GetControlName();
            var id = GUIUtility.GetControlID(controlName.GetHashCode(), FocusType.Keyboard, position);

            var fieldInfo = typeof(EditorGUI).GetField("s_RecycledEditor", Flags);
            uScriptDebug.Assert(fieldInfo != null, "Unable to access the RecycledEditor field.");

            var parameters = new[]
                                {
                                   fieldInfo.GetValue(null),           // RecycledTextEditor editor
                                   id,                                 // int id
                                   EditorGUI.IndentedRect(position),   // Rect position
                                   value,                              // string text
                                   style,                              // GUIStyle style
                                   null,                               // string allowedLetters
                                   false,                              // out bool changed
                                   false,                              // bool reset
                                   false,                              // bool multi-line
                                   false                               // bool passwordField
                                };

            var methodInfo = typeof(EditorGUI).GetMethod("DoTextField", Flags);
            value = (string)methodInfo.Invoke(null, parameters);

            // Associate the id with the control name
            ControlIDList[id] = controlName;

            WatchedControlName = GetControlName();
         }

         EndRow(value.GetType().ToString());
         return value;
      }

      private static Vector2 Vector2Field(Vector2 value)
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);

         value.x = EditorGUILayout.FloatField(value.x, Style.TextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, Style.TextField, GUILayout.Width(w + p));

         return value;
      }

      private static Vector3 Vector3Field(Vector3 value)
      {
         const int Spacing = 8; // 4 * 2
         var w = (columnValue.Width - Spacing) / 3;
         var p = (columnValue.Width - Spacing) % (w * 3);

         value.x = EditorGUILayout.FloatField(value.x, Style.TextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, Style.TextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, Style.TextField, GUILayout.Width(w + p));

         return value;
      }

      private static Vector4 Vector4Field(Vector4 value)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, Style.TextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, Style.TextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, Style.TextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, Style.TextField, GUILayout.Width(w + p));

         return value;
      }

      private struct Column
      {
         public readonly string Label;
         public int Width;

         public Column(string label, int width)
         {
            this.Label = label;
            this.Width = width;
         }
      }

      public class State
      {
         public readonly string DefaultValueAsString;

         public readonly EntityNode EntityNode;

         public readonly bool IsLocked;

         public readonly bool IsReadOnly;

         public readonly string Name;

         public readonly string Type;

         public State(bool isSocketExposed, bool isLocked, bool isReadOnly)
            : this(isSocketExposed, isLocked, isReadOnly, string.Empty, string.Empty, string.Empty, null)
         {
         }

         public State(
            bool isSocketExposed,
            bool isLocked,
            bool isReadOnly,
            string name,
            string type,
            string defaultValue,
            EntityNode entityNode)
         {
            this.IsSocketExposed = isSocketExposed;
            this.IsLocked = isLocked;
            this.IsReadOnly = isReadOnly;

            this.Name = name;
            this.Type = type;
            this.DefaultValueAsString = defaultValue;
            this.EntityNode = entityNode;
         }

         public bool IsSocketExposed { get; set; }
      }

      private static class Style
      {
         public const int ColumnHeaderHeight = 16;

         private static bool isRowEven = true;

         static Style()
         {
            var texturePropertyRowEven = uScriptGUI.GetSkinnedTexture("LineItem");

            ArrayIconButton = new GUIStyle(EditorStyles.miniButton)
            {
               margin = new RectOffset(4, 4, 2, 2),
               padding = new RectOffset(3, 3, 2, 2),
               stretchWidth = false
            };

            ArrayTextButton = new GUIStyle(EditorStyles.miniButton)
            {
               fontStyle = FontStyle.Bold,
               padding = new RectOffset(0, 2, 1, 1),
               contentOffset = new Vector2(0, 1),
               alignment = TextAnchor.UpperCenter
            };

            BoolField = new GUIStyle(EditorStyles.toggle) { margin = new RectOffset(4, 4, 1, 1) };

            ButtonLeft = new GUIStyle("ButtonLeft")
            {
               name = "uScript_propertyButtonLeft",
               fixedHeight = 20,
               fixedWidth = 20,
               fontStyle = FontStyle.Bold,
               margin = new RectOffset(4, 0, 0, 0)
            };

            BttonMiddleDeprecated = new GUIStyle("ButtonMid")
            {
               name = "uScript_propertyButtonMiddleDeprecated",
               fixedHeight = 20,
               fontStyle = FontStyle.Bold,
               margin = new RectOffset()
            };

            ButtonMiddleFavorite = new GUIStyle(BttonMiddleDeprecated)
            {
               name = "uScript_propertyButtonMiddleFavorite",
               alignment = TextAnchor.MiddleLeft,
               contentOffset = new Vector2(6, 0),
               fixedWidth = 30,
               padding = new RectOffset(12, 6, 2, 3)
            };

            ButtonMiddleFavoriteStar = new GUIStyle(EditorStyles.largeLabel)
            {
               name = "uScript_propertyButtonMiddleFavoriteStar",
               padding = new RectOffset(4, 4, 0, 0),
               fontSize = 15
            };

            ButtonMiddleName = new GUIStyle(BttonMiddleDeprecated)
            {
               name = "uScript_propertyButtonMiddleName",
               alignment = TextAnchor.MiddleLeft,
               fixedWidth = 0,
               contentOffset = Vector2.zero
            };

            ButtonRightSearch = new GUIStyle("ButtonRight")
            {
               name = "uScript_propertyButtonRightSearch",
               fixedHeight = 20,
               fixedWidth = 20,
               fontStyle = FontStyle.Bold,
               margin = new RectOffset(0, 4, 0, 0),
               padding = new RectOffset()
            };

            ButtonRightName = new GUIStyle(ButtonRightSearch)
            {
               name = "uScript_propertyButtonRightName",
               alignment = TextAnchor.MiddleLeft,
               fixedWidth = 0,
               padding = ((GUIStyle)"ButtonRight").padding
            };

            ColumnHeader = new GUIStyle(EditorStyles.toolbarButton)
            {
               name = "columnHeader",
               fontStyle = FontStyle.Bold,
               alignment = TextAnchor.MiddleLeft,
               padding = new RectOffset(5, 8, 0, 0),
               fixedHeight = ColumnHeaderHeight,
               contentOffset = new Vector2(0, -1)
            };
            ColumnHeader.normal.background = ColumnHeader.onNormal.background;

            Enabled = new GUIStyle(GUI.skin.toggle)
            {
               margin = new RectOffset(4, 0, 2, 4),
               padding = new RectOffset(20, 0, 0, 0)
            };

            RowOdd = new GUIStyle(GUIStyle.none); /* fixedHeight = 20 */
            RowEven = new GUIStyle(RowOdd) { normal = { background = texturePropertyRowEven } };

            Label = new GUIStyle(EditorStyles.label) { margin = { left = 0 } };

            TextField = new GUIStyle(EditorStyles.textField) { margin = new RectOffset(4, 4, 2, 2) };
            TextArea = new GUIStyle(TextField) { wordWrap = true, stretchHeight = true };

            Type = new GUIStyle(EditorStyles.label) { margin = { left = 6 } };
         }

         public static GUIStyle ArrayIconButton { get; private set; }

         public static GUIStyle ArrayTextButton { get; private set; }

         public static GUIStyle BoolField { get; private set; }

         public static GUIStyle ButtonLeft { get; private set; }

         public static GUIStyle BttonMiddleDeprecated { get; private set; }

         public static GUIStyle ButtonMiddleFavorite { get; private set; }

         public static GUIStyle ButtonMiddleFavoriteStar { get; private set; }

         public static GUIStyle ButtonMiddleName { get; private set; }

         public static GUIStyle ButtonRightSearch { get; private set; }

         public static GUIStyle ButtonRightName { get; private set; }

         public static GUIStyle ColumnHeader { get; private set; }

         public static GUIStyle Enabled { get; private set; }

         public static GUIStyle RowBackground
         {
            get
            {
               isRowEven = !isRowEven;
               return isRowEven ? RowEven : RowOdd;
            }
         }

         public static GUIStyle RowEven { get; private set; }

         public static GUIStyle RowOdd { get; private set; }

         public static GUIStyle Label { get; private set; }

         public static GUIStyle TextArea { get; private set; }

         public static GUIStyle TextField { get; private set; }

         public static GUIStyle Type { get; private set; }

         public static void ResetBackground()
         {
            isRowEven = true;
         }
      }
   }
}
