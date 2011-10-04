using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

using Detox.ScriptEditor;
using Detox.FlowChart;


//
// This file contains a collection of custom uScript GUI controls for use with uScriptEditor
// _________________________________________________________________________________________
//

public static class uScriptGUI
{
   struct Column
   {
      public string Label;
      public int Width;

      public Column(string label, int width)
      {
         this.Label = label;
         this.Width = width;
      }
   }

   static Column _columnEnabled;	
   static Column _columnLabel;
   static Column _columnValue;
   static Column _columnType;

   static GUIStyle _styleEnabled;
   static GUIStyle _styleLabel;
   static GUIStyle _styleType;

   public static Vector2 columnOffset;
   public static Rect svRect;

   public static string _focusedControl = string.Empty;
   public static string _previousControl = string.Empty;

   static Dictionary<string, bool> _foldoutExpanded = new Dictionary<string, bool>();
//   static Dictionary<string, object> _modifiedValue = new Dictionary<string, object>();

   static string _nodeKey = string.Empty;
   static int _propertyCount;
   static bool _isPropertyRowEven = false;



   //
   // Enables and disables the GUI. Call this instead of GUI.enabled
   // when the state needs to change during OnGUI, especially during
   // the uScriptGUI custom control calls.
   //
   public static bool enabled
   {
      get { return GUI.enabled; }
      set
      {
         uScript instance = uScript.Instance;
         GUI.enabled = (value ? instance.isLicenseAccepted
                                && !instance.isPreferenceWindowOpen
                                && !instance.isContextMenuOpen
                                && !instance.isFileMenuOpen : false);
      }
   }

   public static void ResetFoldouts()
   {
      _foldoutExpanded.Clear();
   }

   public static void BeginColumns(string col1, string col2, string col3, Vector2 offset, Rect rect)
   {
      _columnEnabled = new Column(string.Empty, 20);
      _columnLabel = new Column(col1, 140);
      _columnValue = new Column(col2, 220);
      _columnType = new Column(col3, 0);

      _propertyCount = 0;

      columnOffset = offset;
      svRect = rect;

      if (null == _styleEnabled)
      {
         _styleEnabled = new GUIStyle(GUI.skin.toggle);
         _styleEnabled.margin = new RectOffset(4, 0, 2, 4);
         _styleEnabled.padding = new RectOffset(20, 0, 0, 0);
         _styleEnabled.padding.left = 20;

         _styleLabel = new GUIStyle(EditorStyles.label);
         _styleLabel.margin.left = 0;

         _styleType = new GUIStyle(EditorStyles.label);
         _styleType.margin.left = 6;
      }
		
      GUILayout.Label(string.Empty, new GUIStyle(), GUILayout.Height(uScriptGUIStyle.columnHeaderHeight));
   }


   public static void EndColumns()
   {
      float x = 0;
      float y = columnOffset.y;

      // The columns have a margin of 4. Margins of adjacent cells overlap, so the spacing
      // betweem columns is the width of the largest margin, not the sum.
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
      GUI.Label(new Rect(x, y, _columnEnabled.Width + 4 + 2, uScriptGUIStyle.columnHeaderHeight), _columnEnabled.Label, uScriptGUIStyle.columnHeader);
      x += _columnEnabled.Width + 2;

      // Interior column - Property name
      GUI.Label(new Rect(x, y, _columnLabel.Width + 4, uScriptGUIStyle.columnHeaderHeight), _columnLabel.Label, uScriptGUIStyle.columnHeader);
      x += _columnLabel.Width + 4;

      // Interior column - Property value
      GUI.Label(new Rect(x, y, _columnValue.Width + 4, uScriptGUIStyle.columnHeaderHeight), _columnValue.Label, uScriptGUIStyle.columnHeader);
      x += _columnValue.Width + 4;

      // Last column - Property type
      // This right-most column should appear to have an expanded width
      GUI.Label(new Rect(x, y, svRect.width, uScriptGUIStyle.columnHeaderHeight), _columnType.Label, uScriptGUIStyle.columnHeader);
//      GUI.Label(new Rect(x, y, _columnType.Width + 4 + 2, uScriptGUIStyle.columnHeaderHeight), _columnType.Label, style);
//      GUI.Label(new Rect(x, y, svRect.width - _columnLabel.Width - _columnValue.Width - 22 + columnOffset.x, uScriptGUIStyle.columnHeaderHeight), _columnType.Label, style);


      //
      // Update control focus changes
      //

      //if (Event.current.keyCode == KeyCode.Escape)
      //{
      //   Debug.Log("ESC was pressed\n");
      //   Event.current.Use();
      //}



      if (GUI.GetNameOfFocusedControl() != _focusedControl)
      {
         uScriptDebug.Log("Control focus changed from '" + _focusedControl + "' to '" + GUI.GetNameOfFocusedControl() + "'\n", uScriptDebug.Type.Debug);
         _previousControl = _focusedControl;
         _focusedControl = GUI.GetNameOfFocusedControl();
      }
   }


   public static void Separator()
   {
      GUILayout.Space(10);
   }


   public static void HR()
   {
      GUILayout.BeginHorizontal(uScriptGUIStyle.panelHR, GUILayout.ExpandWidth(true));
      {
      }
      GUILayout.EndHorizontal();
   }

   
   public static bool BeginProperty(string label, Node node)
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

      _propertyCount++;
      _nodeKey = node.Guid.ToString();
      if (false == _foldoutExpanded.ContainsKey(_nodeKey))
      {
         _foldoutExpanded[_nodeKey] = true;
      }

      GUILayout.BeginHorizontal();
      {
         //
         // Foldout
         //
         UnityEngine.Color tmpColor = GUI.color;
         UnityEngine.Color textColor = uScriptGUIStyle.nodeButtonLeft.normal.textColor;

         if (uScript.IsNodeTypeDeprecated(((DisplayNode)node).EntityNode) || m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(((DisplayNode)node).EntityNode))
         {
            GUI.color = new UnityEngine.Color(1, 0.5f, 1, 1);
            uScriptGUIStyle.nodeButtonLeft.normal.textColor = UnityEngine.Color.white;
//            label += "\t\t--- DEPRECATED: UPDATED OR REPLACE ---";
//            label += "\t\t--- DEPRECATED ---";
         }

         _foldoutExpanded[_nodeKey] = GUILayout.Toggle(_foldoutExpanded[_nodeKey], label, uScriptGUIStyle.nodeButtonLeft);

         GUI.color = tmpColor;
         uScriptGUIStyle.nodeButtonLeft.normal.textColor = textColor;

         //
         // Deprecation button
         //
         if (uScript.IsNodeTypeDeprecated(((DisplayNode)node).EntityNode) == false && m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(((DisplayNode)node).EntityNode))
         {
            if ( true == m_ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(((DisplayNode)node).EntityNode) )
            {
               if (GUILayout.Button(uScriptGUIContent.buttonNodeUpgrade, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
               {
                  System.EventHandler Click = new System.EventHandler(m_ScriptEditorCtrl.m_MenuUpgradeNode_Click);
                  if (Click != null)
                  {
                     // clear all selected nodes first
                     m_ScriptEditorCtrl.DeselectAll();
                     // toggle the clicked node
                     m_ScriptEditorCtrl.ToggleNode(node.Guid);
                     Click(null, new EventArgs());
                  }
               }
            }
            else
            {
               if (GUILayout.Button(uScriptGUIContent.buttonNodeDeleteMissing, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
               {
                  System.EventHandler Click = new System.EventHandler(m_ScriptEditorCtrl.m_MenuDeleteMissingNode_Click);
                  if (Click != null)
                  {
                     // clear all selected nodes first
                     m_ScriptEditorCtrl.DeselectAll();
                     // toggle the clicked node
                     m_ScriptEditorCtrl.ToggleNode(node.Guid);
                     Click(null, new EventArgs());
                  }
               }
            }

         }

//         //
//         // Toggle Sockets button
//         //
//         if (GUILayout.Button(uScriptGUIContent.listMiniToggle, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
//         {
////            m_ScriptEditorCtrl.ToggleNodeSockets(node);
//         }

         //
         // Search button
         //
         if (GUILayout.Button(uScriptGUIContent.buttonNodeFind, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
         {
            m_ScriptEditorCtrl.CenterOnNode(node);
         }
      }
      GUILayout.EndHorizontal();

      // add a little extra space after the node foldout
      GUILayout.Space(2);

      // begin the first property of each node as an "odd" row
      _isPropertyRowEven = false;

      return _foldoutExpanded[_nodeKey];
   }


   public static void EndProperty()
   {
      if (_foldoutExpanded[_nodeKey])
      {
         Separator();
      }
   }


   static void BeginFoldoutRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly, ref bool isExpanded)
   {
      SetupRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (isSocketExposed && isLocked || isReadOnly)
      {
         EditorGUILayout.PrefixLabel(label, _styleLabel);
      }
      else
      {
         isExpanded = GUILayout.Toggle(isExpanded, label, EditorStyles.foldout, GUILayout.Width(_columnLabel.Width - 3));
      }
      uScriptGUI.enabled = (! isReadOnly) && (! isSocketExposed || ! isLocked);
   }

   static void BeginStaticRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      SetupRow(label, ref isSocketExposed, isLocked, isReadOnly);

      EditorGUILayout.PrefixLabel(label, _styleLabel);
      uScriptGUI.enabled = (! isReadOnly) && (! isSocketExposed || ! isLocked);
   }

   static void SetupRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginHorizontal((_isPropertyRowEven ? uScriptGUIStyle.propertyRowEven : uScriptGUIStyle.propertyRowOdd));
      _isPropertyRowEven = !_isPropertyRowEven;

      if (isSocketExposed == false && isLocked)
      {
         GUILayout.Space(_columnEnabled.Width + 4);
      }
      else
      {
         uScriptGUI.enabled = false == isLocked;
         isSocketExposed = GUILayout.Toggle(isSocketExposed, string.Empty, _styleEnabled, GUILayout.Width(_columnEnabled.Width));
         uScriptGUI.enabled = true;
      }

      // Display the column label
      EditorGUIUtility.LookLikeControls(_columnLabel.Width);
   }


   static void EndRow(string type)
   {
      type = uScriptConfig.Variable.FriendlyName(type).Replace("UnityEngine.", string.Empty);
      Vector2 v = _styleType.CalcSize(new GUIContent(type));
      _columnType.Width = Mathf.Max(_columnType.Width, (int)v.x);

      uScriptGUI.enabled = true;
      GUILayout.Label(type, _styleType);
      EditorGUILayout.EndHorizontal();
   }

   private static bool IsFieldUsable(bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      if ((isSocketExposed && isLocked) || isReadOnly)
      {
         EditorGUILayout.TextField(isReadOnly ? "(read-only)" : "(socket used)", uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
         return false;
      }
      return true;
   }

   public static int IntField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      return IntField(label, value, ref isSocketExposed, isLocked, isReadOnly, int.MinValue, int.MaxValue);
   }

   public static int IntField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly, int min, int max)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.IntField(value, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static float FloatField(string label, float value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.FloatField(value, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TextField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.TextField(value, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TextArea(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.TextArea(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static bool BoolField(string label, bool value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = GUILayout.Toggle(value, GUIContent.none, uScriptGUIStyle.propertyBoolField, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static void BlankField(string label, string text, ref bool isSocketExposed, bool isLocked)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, true);

      GUI.SetNextControlName(label);
      EditorGUILayout.TextField(text, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));

      EndRow("");
   }

   public static UnityEngine.Color ColorField(string label, Color value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.ColorField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());

//      Vector4 v = value;
//      int r = (int)(255 * v.x);
//      int g = (int)(255 * v.y);
//      int b = (int)(255 * v.z);
//      int a = (int)(255 * v.w);
//
//      EditorGUILayout.LabelField(string.Empty, value.ToString());
//      EditorGUILayout.LabelField(string.Empty, v.ToString("F2"));
//      EditorGUILayout.LabelField(string.Empty, (r << 24 | g << 16 | b << 8 | a).ToString("X8"));
//      EditorGUILayout.LabelField(string.Empty, r.ToString("X2") + " " + g.ToString("X2") + " "
//                                             + b.ToString("X2") + " " + a.ToString("X2"));
//      EditorGUILayout.LabelField(string.Empty, r.ToString() + " " + g.ToString() + " "
//                                             + b.ToString() + " " + a.ToString());

      return value;
   }


   public static Vector2 Vector2Field(string label, Vector2 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 4; // 4 * 1
         int w = (_columnValue.Width - spacing) / 2;
         int p = (_columnValue.Width - spacing) % (w * 2);

         GUI.SetNextControlName(label + ".x");
         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         GUI.SetNextControlName(label + ".y");
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y]");
      return value;
   }


   public static Vector3 Vector3Field(string label, Vector3 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 8; // 4 * 2
         int w = (_columnValue.Width - spacing) / 3;
         int p = (_columnValue.Width - spacing) % (w * 3);
         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z]");
      return value;
   }


   public static Vector4 Vector4Field(string label, Vector4 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z, W]");
      return value;
   }


   public static Rect RectField(string label, Rect value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.width = EditorGUILayout.FloatField(value.width, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.height = EditorGUILayout.FloatField(value.height, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, W, H]");
      return value;
   }


   public static Quaternion QuaternionField(string label, Quaternion value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z, W]");
      return value;
   }


   public static System.Enum EnumField(string label, System.Enum value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         //int spacing = 12; // 4 * 3
         //int w = (_columnValue.Width - spacing) / 4;
         //int p = (_columnValue.Width - spacing) % (w * 4);
         //value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         //value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         //value.width = EditorGUILayout.FloatField(value.width, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         //value.height = EditorGUILayout.FloatField(value.height, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));

         value = EditorGUILayout.EnumPopup(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static int LayerField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.LayerField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TagField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.TagField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string ChoiceField(string label, string value, string[] choices, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int menuIndex = 0;
         for (int i = 0; i < choices.Length; i++)
         {
            if (choices[i] == value)
            {
               menuIndex = i;
            }
         }
         
         //send the new value to the popup and whatever it
         //returns (in case the user modified it here) is what our final value is
         menuIndex = EditorGUILayout.Popup(menuIndex, choices, GUILayout.Width(_columnValue.Width));
         value = choices[menuIndex];
      }

      EndRow(value.GetType().ToString());

      return value;
   }


   public static System.Enum EnumTextField(string label, System.Enum value, string textValue, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginVertical();
      {
         BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            //first show the text field and get back the same (or changed value)
            string userText = EditorGUILayout.TextField(textValue, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
            System.Enum newEnum;

            //try and turn the text field value back into an enum, if it doesn't work
            //then revert back to the original value
            try { newEnum = (System.Enum) System.Enum.Parse(value.GetType(), userText); }
            catch { newEnum = (System.Enum) value; }

            EndRow(textValue.GetType().ToString());

            bool tmpBool = false;

            BeginStaticRow(string.Empty, ref tmpBool, true, isReadOnly);

            //send the new value to the enum popup and whatever it
            //returns (in case the user modified it here) is what our final value is
            value = EditorGUILayout.EnumPopup(newEnum, GUILayout.Width(_columnValue.Width));
         }

         EndRow(value.GetType().ToString());
      }
      EditorGUILayout.EndVertical();
      return value;
   }


   public static string ObjectTextField(string label, UnityEngine.Object value, Type type, string textValue, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginVertical();
      {
         BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            textValue = EditorGUILayout.TextField(textValue, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
   
            EndRow(textValue.GetType().ToString());


            bool tmpBool = false;

            BeginStaticRow(string.Empty, ref tmpBool, true, isReadOnly);

            // now try and update the object browser with an instance of the specified object
            UnityEngine.Object []objects   = UnityEngine.Object.FindObjectsOfType(type);
            UnityEngine.Object unityObject = null;
   
            foreach ( UnityEngine.Object o in objects )
            {
               if ( o.name == textValue )
               {
                  unityObject = o;
                  break;
               }
            }

            // components should never be instances in the property grid
            // we must refer to (and select) their parent game object
            if ( true == typeof(Component).IsAssignableFrom(type) )
            {
               type = typeof(GameObject);
               if ( null != unityObject ) unityObject = ((Component) unityObject).gameObject;
            }

            //if we're building with 3.4 then check the client version
            //and figure out which one to display
            #if (UNITY_3_4)
               if ( uScript.UnityVersion < 3.4f )
               {
                  #pragma warning disable 618
                     unityObject = EditorGUILayout.ObjectField(unityObject, type, GUILayout.Width(_columnValue.Width)) as UnityEngine.Object;
                  #pragma warning restore 618
               }
               else
               {
                  unityObject = EditorGUILayout.ObjectField( unityObject, type, true, GUILayout.Width(_columnValue.Width) ) as UnityEngine.Object;
               }
            #else
               //if we're not building with 3.4 then default to the old one
               unityObject = EditorGUILayout.ObjectField(unityObject, type, GUILayout.Width(_columnValue.Width)) as UnityEngine.Object;
            #endif
   
            // if that object (or the changed object) does exist, use it's name to update the property value
            // if it doesn't exist then the 'val' will stay as what was entered into the TextField
            if ( unityObject != null )
            {
               textValue = unityObject.name;               
            }
         }

         EndRow(type.ToString());
      }
      EditorGUILayout.EndVertical();
      return textValue;
   }


   public static T[] ArrayFoldout<T>(string label, T[] array, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      string propertyKey = _nodeKey + "_" + label;
      bool isExpanded = (_foldoutExpanded.ContainsKey(propertyKey) ? _foldoutExpanded[propertyKey] : true);

      //
      // The Foldout row
      //
      BeginFoldoutRow(label, ref isSocketExposed, isLocked, isReadOnly, ref isExpanded);

      // Display the array info, readonly, socketUsed, or an empty area
      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUILayout.Label("... (" + array.Length + " item" + (array.Length==1 ? string.Empty : "s") + ")", _styleLabel, GUILayout.Width(_columnValue.Width));

         Rect btnRect = GUILayoutUtility.GetLastRect();
         btnRect.x = btnRect.xMax - 18;
         btnRect.width = 18;
         btnRect.height = 16;

         if (GUI.Button(btnRect, new GUIContent("+", "Add a new item to the end of the array."), uScriptGUIStyle.propertyArrayButton))
         {
            array = ArrayAppend<T>(array, default(T));
         }

         btnRect.x -= 18;

         if (GUI.Button(btnRect, new GUIContent("{ }", "Remove all items from the array."), uScriptGUIStyle.propertyArrayButton))
         {
            array = new T[]{};
         }
      }

      EndRow(array.GetType().ToString());

      //
      // The array size
      //
      if (isExpanded)
      {
         bool hideSocket = false;

         EditorGUI.indentLevel += 2;

         //
         // The elements
         //
         for (int i = 0; i < array.Length; i++)
         {
            T entry = default(T);
            if (i < array.Length)
            {
               entry = array[i];
            }
            array[i] = ArrayElementRow<T>(ref array, i, entry, ref hideSocket, true, false);
         }

         EditorGUI.indentLevel -= 2;
      }

      _foldoutExpanded[propertyKey] = isExpanded;

      return array;
   }


   static Rect _previousHotRect = new Rect();
   public static T ArrayElementRow<T>(ref T[] array, int index, T value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      Rect r1 = GUILayoutUtility.GetLastRect();
      r1.y = r1.yMax + 2;

      BeginStaticRow("["+index.ToString()+"]", ref isSocketExposed, isLocked, isReadOnly);

//      if (Event.current.type == EventType.Repaint)
//      {
         // Get the last rect to determine where we want to draw the array modifier buttons
         Rect btnRect = GUILayoutUtility.GetLastRect();
         Rect row = btnRect;

         btnRect.x = btnRect.xMax - 18;
         btnRect.width = 18;
         btnRect.height = 16;

         // Determine the rect for the entire property panel row
         row.x = uScriptGUIPanelProperty.Rect.x;
         row.width = uScriptGUIPanelProperty.Rect.width;

         // When the mouse is over the row
         if (row.Contains(Event.current.mousePosition))
         {
            // Draw once if the row has changed
            if (_previousHotRect != row)
            {
               _previousHotRect = row;
               uScript.Instance.Repaint();
            }
//
            if (GUI.Button(btnRect, new GUIContent("R", "Remove this item."), uScriptGUIStyle.propertyArrayButton))
            {
               array = ArrayRemove<T>(array, index);
            }

            btnRect.x -= 18;

            if (GUI.Button(btnRect, new GUIContent("C", "Insert a copy of this item."), uScriptGUIStyle.propertyArrayButton))
            {
               array = ArrayInsert<T>(array, index, array[index]);
            }

            btnRect.x -= 18;

            if (GUI.Button(btnRect, new GUIContent("I", "Insert a new item before this item."), uScriptGUIStyle.propertyArrayButton))
            {
               array = ArrayInsert<T>(array, index, default(T));
            }
//
         }
         else
         {
            // Draw once when the mouse is not over any row
            if (_previousHotRect != new Rect())
            {
               _previousHotRect = new Rect();
               uScript.Instance.Repaint();
            }
         }
//      }


      object t = value;
      string typeFormat = string.Empty;

      if (value is int)
      {
         t = EditorGUILayout.IntField((int)t, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }
      else if (value is float)
      {
         t = EditorGUILayout.FloatField((float)t, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }
      else if (value is string)
      {
         t = EditorGUILayout.TextField((string)t, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width));
      }
      else if (value is bool)
      {
         t = GUILayout.Toggle((bool)t, GUIContent.none, uScriptGUIStyle.propertyBoolField, GUILayout.Width(_columnValue.Width));
      }
      else if (value is System.Enum)
      {
         t = EditorGUILayout.EnumPopup((System.Enum)t, GUILayout.Width(_columnValue.Width));
      }
      else if (value is Color)
      {
         t = EditorGUILayout.ColorField((Color)t, GUILayout.Width(_columnValue.Width));
      }
      else if (value is Vector2)
      {
         Vector2 val = (Vector2)t;

         int spacing = 4; // 4 * 1
         int w = (_columnValue.Width - spacing) / 2;
         int p = (_columnValue.Width - spacing) % (w * 2);

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y]";

         t = val;
      }
      else if (value is Vector3)
      {
         Vector3 val = (Vector3)t;

         int spacing = 8; // 4 * 2
         int w = (_columnValue.Width - spacing) / 3;
         int p = (_columnValue.Width - spacing) % (w * 3);
         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z]";

         t = val;
      }
      else if (value is Vector4)
      {
         Vector4 val = (Vector4)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z, W]";

         t = val;
      }
      else if (value is Rect)
      {
         Rect val = (Rect)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.width = EditorGUILayout.FloatField(val.width, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.height = EditorGUILayout.FloatField(val.height, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, W, H]";

         t = val;
      }
      else if (value is Quaternion)
      {
         Quaternion val = (Quaternion)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.propertyTextField, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, uScriptGUIStyle.propertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z, W]";

         t = val;
      }
      else if (value is UnityEngine.Object)
      {
         Debug.LogWarning("Arrays of Object[] are not handled yet!\n");
      }
      else
      {
         Debug.LogWarning("Unhandled array type!\n");
         //throw System.ArgumentException("Unhandled type: " + value.GetType().ToString());
      }

      value = (T)t;

      EndRow(value.GetType().ToString() + typeFormat);
      return value;
   }


   static T[] ArrayAppend<T>(T[] array, T val)
   {
      List<T> list = new List<T>(array);
      list.Add(val);
      return list.ToArray();
   }

   static T[] ArrayInsert<T>(T[] array, int index, T val)
   {
      if (index < 0 || index >= array.Length)
      {
         uScriptDebug.Log("The specified index ("+index+") is out of range [0.."+(array.Length-1)+"]",uScriptDebug.Type.Error);
         return array;
      }
      List<T> list = new List<T>(array);
      list.Insert(index, val);
      return list.ToArray();
   }

   static T[] ArrayRemove<T>(T[] array, int index)
   {
      if (index < 0 || index >= array.Length)
      {
         uScriptDebug.Log("The specified index ("+index+") is out of range [0.."+(array.Length-1)+"]",uScriptDebug.Type.Error);
         return array;
      }
      List<T> list = new List<T>(array);
      list.RemoveAt(index);
      return list.ToArray();
   }


   public static string ToolbarSearchField(string value, params GUILayoutOption[] options)
	{
		// Unity's built-in search field is internal. Lame.
		//
		MethodInfo mi = typeof(EditorGUILayout).GetMethod("ToolbarSearchField",
		                                                  BindingFlags.Static|BindingFlags.NonPublic,
		                                                  null,
		                                                  new Type[] { typeof(string), typeof(GUILayoutOption[]) },
		                                                  null);
		if (mi != null)
		{
			value = (string)mi.Invoke(null, new object[] { (string)value, (GUILayoutOption[])options });
		}
		return value;
	}


   public static int ToolbarButtonGroup(string label, int index, GUIContent[] content)
   {
      if (string.IsNullOrEmpty(label) == false)
      {
         GUIStyle style1 = new GUIStyle(EditorStyles.label);
         style1.padding = new RectOffset(16, 4, 2, 2);
         style1.margin = new RectOffset();
         GUILayout.Label(label, style1);
      }

      for (int i = 0; i < content.Length; i++)
      {
         if (GUILayout.Toggle(index == i, content[i], EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
         {
            index = i;
         }
      }

      return index;
   }




   static GUIStyle hSB_LB = null;
   static GUIStyle hSB_RB = null;
   static GUIStyle hSB_TH = null;

   static GUIStyle vSB_UB = null;
   static GUIStyle vSB_DB = null;
   static GUIStyle vSB_TH = null;

   public static void HideScrollbars()
   {
      if (hSB_LB == null)
      {
         hSB_LB = new GUIStyle(GUI.skin.horizontalScrollbarLeftButton);
         hSB_RB = new GUIStyle(GUI.skin.horizontalScrollbarRightButton);
         hSB_TH = new GUIStyle(GUI.skin.horizontalScrollbarThumb);

         vSB_UB = new GUIStyle(GUI.skin.verticalScrollbarUpButton);
         vSB_DB = new GUIStyle(GUI.skin.verticalScrollbarDownButton);
         vSB_TH = new GUIStyle(GUI.skin.verticalScrollbarThumb);

         GUI.skin.horizontalScrollbarLeftButton = GUIStyle.none;
         GUI.skin.horizontalScrollbarRightButton = GUIStyle.none;
         GUI.skin.horizontalScrollbarThumb = GUIStyle.none;

         GUI.skin.verticalScrollbarUpButton = GUIStyle.none;
         GUI.skin.verticalScrollbarDownButton = GUIStyle.none;
         GUI.skin.verticalScrollbarThumb = GUIStyle.none;
      }
   }


   public static void ShowScrollbars()
   {
      if (hSB_LB != null)
      {
         GUI.skin.horizontalScrollbarLeftButton = hSB_LB;
         GUI.skin.horizontalScrollbarRightButton = hSB_RB;
         GUI.skin.horizontalScrollbarThumb = hSB_TH;

         GUI.skin.verticalScrollbarUpButton = vSB_UB;
         GUI.skin.verticalScrollbarDownButton = vSB_DB;
         GUI.skin.verticalScrollbarThumb = vSB_TH;

         hSB_LB = null;
         hSB_RB = null;
         hSB_TH = null;

         vSB_UB = null;
         vSB_DB = null;
         vSB_TH = null;
      }
   }






   static List<string> _resourcePaths = null;
//   static string[] choices = null;

   // How much deep to scan. (of course you can also pass it to the method)
   const int _maximumFolderRecursioDepth = 12;

   public static void GetResourceFolderPaths(string sourceDir, int recursionDepth)
   {
      if (recursionDepth <= _maximumFolderRecursioDepth)
      {
         // Grab the valid paths
         if ((sourceDir.EndsWith("/Resources") || sourceDir.Contains("/Resources/"))
             && sourceDir.Contains("/.svn") == false)
         {
            // get the substring we care about
            string path = sourceDir.Substring(sourceDir.IndexOf("Resources")).Replace('/', '\\');

            // add the path if it doesn't already exist
            if (_resourcePaths.Contains(path) == false)
            {
               _resourcePaths.Add(path);
            }

            // sort the list or it will place the paths in a strange order
            _resourcePaths.Sort();
         }

         // Recurse into subdirectories of this directory.
         string [] subdirEntries = Directory.GetDirectories(sourceDir);
         foreach(string subdir in subdirEntries)
         {
            // Do not iterate through reparse points
            if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
               GetResourceFolderPaths(subdir,recursionDepth+1);
            }
         }
      }
   }


   public static string ResourcePathField(string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      // Resource Path
      //
      // The control uses a standard popup control for path selection, although the current
      // selection is stored as a string.  The string array used for the popup should only
      // include all valid Resource folders under assets.
      //
      //    Popup control
      //    (exposed socket should be a string)
      //

      string label = "Resource Path";

      if (_resourcePaths == null || _resourcePaths.Count == 0)
      {
         // Create the path list and populate it with Resource folders
         _resourcePaths = new List<string>();
         GetResourceFolderPaths(Application.dataPath, 0);
//         choices = _resourcePaths.ToArray();
      }

      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int menuIndex = 0;
         for (int i = 0; i < _resourcePaths.Count; i++)
         {
            if (_resourcePaths[i] == value.Replace('/', '\\'))
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
         //
         menuIndex = EditorGUILayout.Popup(menuIndex, _resourcePaths.ToArray(), GUILayout.Width(_columnValue.Width));
         value = _resourcePaths[menuIndex].Replace('\\', '/');
      }

      EndRow(value.GetType().ToString());

//      Debug.Log("Returning: " + value + "\n");
      return value;
   }




   public static string AssetPathField(string label, AssetType assetType, string assetPath, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
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
      //

//      string label = System.Enum.GetName(typeof(AssetType), (int)assetType) + " Path";

      GUIStyle style = new GUIStyle(EditorStyles.miniButton);
      style.padding = new RectOffset(6, 6, 1, 2);
      style.margin = new RectOffset(4, 4, 2, 4);

      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         Vector2 buttonSize = style.CalcSize(new GUIContent("Browse"));

         GUI.SetNextControlName(label);
         assetPath = EditorGUILayout.TextField(assetPath, uScriptGUIStyle.propertyTextField, GUILayout.Width(_columnValue.Width - 4 - buttonSize.x));

         uScriptGUI.enabled = !AssetBrowserWindow.isOpen;

         if (GUILayout.Button("Browse", style, GUILayout.Width(buttonSize.x)))
         {
            AssetBrowserWindow.assetType = assetType;
            AssetBrowserWindow.assetFilePath = assetPath;
            AssetBrowserWindow.shouldOpen = true;
            AssetBrowserWindow.nodeKey = _nodeKey;

//            AssetBrowserWindow.Init(resourcePath, AssetBrowserWindow.AssetType.Texture);
//            AssetBrowserWindow.FocusWindowIfItsOpen<AssetBrowserWindow>();

//            Debug.Log("BUTTON PRESSED\n");
//            filepath = EditorUtility.OpenFilePanel(name, path, extension);
//            Debug.Log("Results: " + filepath + "\n");
         }

         if (AssetBrowserWindow.nodeKey == _nodeKey)
         {
            //only get it once, don't continue to get it
            //because it'll override changes from other areas
            //like undo/redo and drag/drop
            if ( "" != AssetBrowserWindow.assetFilePath )
            {
               assetPath = AssetBrowserWindow.assetFilePath;
               AssetBrowserWindow.assetFilePath = "";
            }
         }

         uScriptGUI.enabled = true;
      }

      EndRow(assetPath.GetType().ToString());

      return assetPath;
   }

   static void OpenAssetBrowserWindow(AssetType type, string currentSelection)
   {
      if (AssetBrowserWindow.isOpen)
      {
         Debug.LogWarning("The AssetBrowserWindow is already open!\n");
         return;
      }

      AssetBrowserWindow.assetType = type;

   }


   public static void PingObject(string path, Type type)
   {
      UnityEngine.Object obj = Resources.LoadAssetAtPath(path, type);
      if (obj != null)
      {
         int instanceID = obj.GetInstanceID();
         EditorGUIUtility.PingObject(instanceID);
      }
      else
      {
         Debug.Log("File not found:\t" + path + "\n");
      }
   }

   public static void PingGeneratedScript(string scriptName)
   {
      PingObject(uScript.Preferences.GeneratedScripts.Substring(Application.dataPath.Length - 6) + "/" + scriptName + ".cs", typeof(TextAsset));
   }




//               EditorGUILayout.Separator();
//               EditorGUILayout.Space();

//   Slider         Make a slider the user can drag to change a value between a min and a max.
//   IntSlider      Make a slider the user can drag to change an integer value between a min and a max.
//   MinMaxSlider   Make a special slider the user can use to specify a range between a min and a max.
//   ObjectField    Make an object drop slot field.
//   CurveField     Make a field for editing an AnimationCurve.
//   PropertyField  Make a field for SerializedProperty.




   #region Panel-Related Members and Methods

   // ================================================================================
   //
   //    Main Editor GUI Members and Methods Used During UnityEngine.OnGUI()
   //
   // ================================================================================

   //
   // Singleton pattern
   //
//   static readonly uScriptGUI _instance = new uScriptGUI();
//   public static uScriptGUI Instance { get { return _instance; } }
//   private uScriptGUI() { Init(); }


   public enum Region
   {
      Outside,
      Canvas,
      Content,
      Palette,
      Property,
      Reference,
      Script,
      HandleContainerBottom,
      HandleContainerCenter,
      HandleContainerLeft,
      HandleContainerRight,
      HandlePanelContent,
      HandlePanelPalette,
      HandlePanelProperty,
      HandlePanelReference,
      HandlePanelScript,
      Statusbar
   }

   private static Region _region = Region.Outside;
   public static Region CurrentRegion
   {
      get { return _region; }
      set { _region = value; }
   }

//   private static Region m_MouseDownRegion = Region.Outside;

   private static Dictionary<Region, Rect> _regions = new Dictionary<Region, Rect>();
   public static Dictionary<Region, Rect> Regions { get { return _regions; } }



//   public static readonly int PanelDividerSize = 4;
//
//   public static bool PanelsHidden = false;
//
//   private static GUIStyle panelStyle = GUIStyle.none;
//   private static GUIStyle boxStyle;
//
//   private static string _statusbarMessage;
//   public static string StatusbarMessage
//   {
//      get { return _statusbarMessage; }
//      set { _statusbarMessage = value; }
//   }



//   public static void Draw()
//   {
//      uScriptGUIContent.Init(uScriptGUIContent.ContentStyle.Text);
//      uScriptGUIStyle.Init();
//      InitPanels();
//
//      boxStyle = new GUIStyle();
//      boxStyle.normal.background = GUI.skin.box.normal.background;
//      boxStyle.border = GUI.skin.box.border;
//
//      GUIStyle container = new GUIStyle();
//      container.margin = new RectOffset(1, 0, 1, 0);
//
//      if (!PanelsHidden)
//      {
//         EditorGUILayout.BeginHorizontal(container);
//         {
//            DrawPanelContainerLeft();
//            DrawPanelContainerCenter();
//            DrawPanelContainerRight();
//         }
//         EditorGUILayout.EndHorizontal();
////         DrawPanelContainerBottom();
//      }
//
//      DrawStatusbar();
//
//      // @TODO: This bool flag could be removed if the GUI is repainted after the canvas stops panning
////      if (_wasMoving)
////      {
////         _wasMoving = false;
////         uScript.Instance.Repaint();
////      }
//   }

//   private static void DrawPanelContainerLeft()
//   {
//      int containerCount = PanelContainerLeft.Count;
//
//      if (containerCount > 0)
//      {
////         Rect r = EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerLeftWidth), GUILayout.ExpandHeight(true));
//         /*Rect r =*/ EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerLeftWidth), GUILayout.Height(uScript.Instance.position.height - 23));
//         {
//            PanelContainerLeft[0].Draw();
//
//            for (int i=1; i < containerCount; i++)
//            {
//               DrawHorizontalDivider(PanelContainerLeft[i-1].Region);
//
//               PanelContainerLeft[i].Draw();
//            }
//         }
//         EditorGUILayout.EndVertical();
//
////         if (Event.current.type == EventType.Repaint)
////         {
////            Debug.Log("ContainerLeft: " + r.ToString() + ", EditorPosition: " + uScript.Instance.position.ToString() + "\n");
////         }
//
//         DrawVerticalDivider(Region.HandleContainerLeft);
//      }
//   }

//   private static void DrawPanelContainerCenter()
//   {
//      EditorGUILayout.BeginVertical(panelStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
//      {
////         DrawPanel(PanelID.Canvas);
//         PanelCanvas.Draw();
////         DrawGUIContent();
//
//         int containerCount = PanelContainerCenter.Count;
//
//         if (containerCount > 0)
//         {
//            DrawHorizontalDivider(Region.HandleContainerCenter);
//
//            EditorGUILayout.BeginHorizontal(new GUIStyle(), GUILayout.ExpandWidth(true), GUILayout.Height(ContainerCenterHeight));
//            {
//               PanelContainerCenter[0].Draw();
//
//               for (int i=1; i < containerCount; i++)
//               {
//                  DrawVerticalDivider(PanelContainerCenter[i-1].Region);
//                  PanelContainerCenter[i].Draw();
//               }
//            }
//            EditorGUILayout.EndHorizontal();
//         }
//      }
//      EditorGUILayout.EndVertical();
//   }

//   private static void DrawPanelContainerRight()
//   {
//      int containerCount = PanelContainerRight.Count;
//
//      if (containerCount > 0)
//      {
//         DrawVerticalDivider(Region.HandleContainerRight);
//
//         EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerRightWidth), GUILayout.ExpandHeight(true));
//         {
//            PanelContainerRight[0].Draw();
//
//            for (int i=1; i < containerCount; i++)
//            {
//               DrawHorizontalDivider(PanelContainerRight[i-1].Region);
//
//               PanelContainerRight[i].Draw();
//            }
//         }
//         EditorGUILayout.EndVertical();
//      }
//   }

//   private static void DrawHorizontalDivider(Region region)
//   {
//      GUILayout.Box(string.Empty, uScriptGUIStyle.hDivider, GUILayout.Height(PanelDividerSize), GUILayout.ExpandWidth(true));
//
//      // If the divider directly follows a panel, map the associated handle to the panel
//      switch (region)
//      {
//         case Region.Content:    region = uScriptGUI.Region.HandlePanelContent;     break;
//         case Region.Palette:    region = uScriptGUI.Region.HandlePanelPalette;     break;
//         case Region.Property:   region = uScriptGUI.Region.HandlePanelProperty;    break;
//         case Region.Reference:  region = uScriptGUI.Region.HandlePanelReference;   break;
//         case Region.Script:     region = uScriptGUI.Region.HandlePanelScript;      break;
//      }
//
//      DefineRegion(region, MouseCursor.ResizeVertical);
//   }

//   private static void DrawVerticalDivider(Region region)
//   {
//      GUILayout.Box(string.Empty, uScriptGUIStyle.vDivider, GUILayout.Width(PanelDividerSize), GUILayout.ExpandHeight(true));
//
//      // If the divider directly follows a panel, map the associated handle to the panel
//      switch (region)
//      {
//         case Region.Content:    region = uScriptGUI.Region.HandlePanelContent;     break;
//         case Region.Palette:    region = uScriptGUI.Region.HandlePanelPalette;     break;
//         case Region.Property:   region = uScriptGUI.Region.HandlePanelProperty;    break;
//         case Region.Reference:  region = uScriptGUI.Region.HandlePanelReference;   break;
//         case Region.Script:     region = uScriptGUI.Region.HandlePanelScript;      break;
//      }
//
//      DefineRegion(region, MouseCursor.ResizeHorizontal);
//   }

//   private static void DrawStatusbar()
//   {
//      if (GUI.tooltip != _statusbarMessage || Event.current.type == EventType.MouseMove)
//      {
//         _statusbarMessage = GUI.tooltip;
//      }
//
//      EditorGUILayout.BeginHorizontal();
//      {
//         GUILayout.Label( _statusbarMessage, GUILayout.ExpandWidth( true ) );
//         GUILayout.Label( (Event.current.modifiers != 0 ? Event.current.modifiers + " :: " : "")
//                           + (int)Event.current.mousePosition.x + ", "
//                           + (int)Event.current.mousePosition.y + " (" + _region + ")",
//                           GUILayout.ExpandWidth( false ));
//      }
//      EditorGUILayout.EndHorizontal();
//
//      DefineRegion(Region.Statusbar);
//
////      if (Event.current.type == EventType.Repaint)
////      {
//////         _statusbarRect = GUILayoutUtility.GetLastRect();
////      }
////
////      //      Redraw();  // This is taking to much CPU time.
//   }


//   public static Rect GetRegion(Region region)
//   {
//      return (_regions.ContainsKey(region) ? _regions[region] : new Rect());
//   }
//
//   public static void DefineRegion(Region region)
//   {
//      DefineRegion(region, MouseCursor.Arrow);
//   }

//   public static void DefineRegion(Region region, MouseCursor cursor)
//   {
//      if (Event.current.type == EventType.Repaint)
//      {
//         _regions[region] = GUILayoutUtility.GetLastRect();
//      }
//
//      if ( (GUI.enabled) && (cursor != MouseCursor.Arrow) && (_regions.ContainsKey(region)) )
//      {
//         EditorGUIUtility.AddCursorRect( _regions[region], cursor);
//      }
//   }

//   private static bool HiddenRegion(Region region)
//   {
//      if (!PanelsHidden) return false;
//
//      return region != Region.Canvas && region != Region.Outside;
//   }

//   public static void CalculateMouseRegion()
//   {
//      foreach( KeyValuePair<Region, Rect> kvp in _regions )
//      {
//         if ( kvp.Value.Contains( Event.current.mousePosition ) && !HiddenRegion(kvp.Key) )
//         {
//            _region = kvp.Key;
//            break;
//            //EditorGUIUtility.DrawColorSwatch(_mouseRegionRect[region], UnityEngine.Color.cyan);
//         }
//      }
//   }
   #endregion











   #region Panel-Related Members and Methods

   // ================================================================================
   //
   //    Panel-Related Members and Methods
   //
   // ================================================================================

   // There are four panel containers, each of which must be able to hold all panels.
   // The size value returned applies to the axis appropraite for the container.
   // All panels within a container share the size of that axis.
   // The default container size is 250px, regardless of the axis it affects.
   //
   // There should probably be a minimum size for each container, perhaps 50 or 100px.
   // The size of a container is really a suggestion, since panels in the container
   // might require a minimum size that is greater than the user-desired size.
   //
   //    ContainerBottom   (height)
   //    ContainerCenter   (height)
   //    ContainerLeft     (width)
   //    ContainerRight    (width)
   //
   // The default size for a given panel is determined by container that holds it
   // and the number of additional panels within that container. All panels within
   // a container are evenly sized. If there is 1000px of available space, four
   // panels would default to 250px each, whereas three panels would be 333px each.
   //
   // In the event that a panel moves from one container to another, all panels in
   // the affected containers will have their size reset to the default value.
   //
   //    PanelContent
   //    PanelPalette
   //    PanelProperty
   //    PanelReference
   //    PanelScripts
   //
   // The container and panel sizes should be store in the Preferences.
   //
   // When the user manually adjusts the size of a container or panel, the new size
   // is stored in Preferences.
   //
   // Sizes that are updated automatically by GUI layout override the Preferences,
   // but are not stored.
   //
   // Only container and panel layouts should reply on these values, and it should
   // be assumed that they may be incorrect.

   public enum PanelID { Canvas, Bottom1, Bottom2, Bottom3, Left1, Left2, Left3, Right1, Right2, Right3 }
   public enum PanelType { GraphContent, NodePalette, Options, Properties, Reference, Scripts, Statusbar, Canvas }

   public enum FixedPanelSize { None, Horizontal, Vertical }

   public static int ContainerBottomHeight = 250;
   public static int ContainerCenterHeight = 250;
   public static int ContainerLeftWidth = 250;
   public static int ContainerRightWidth = 250;

   private static bool _panelsInitialized = false;

//   public static uScriptGUIPanelCanvas PanelCanvas = null;
//
//   public static List<uScriptGUIPanel> PanelContainerBottom = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerCenter = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerLeft = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerRight = new List<uScriptGUIPanel>();

   public static uScriptGUIPanel PanelReference = null;


   private static class PanelContainer
   {
//      public static Rect Rect;

      private static List<uScriptGUIPanel> _panels = new List<uScriptGUIPanel>();
      public static List<uScriptGUIPanel> Panels
      {
         get { return _panels; }
      }

//      public static uScriptGUIPanel this[int index]
//      {
//      }

//      public static int GetSizeAccrued(
   }


   public static void InitPanels()
   {
      if (_panelsInitialized)
      {
         // The panels have already been initialized
         return;
      }
      _panelsInitialized = true;

//      panelStyle = new GUIStyle();




      // Get the panel dimensions from the saved Settings or use default values

//      Rect rectArea = new Rect(0, 0, uScript.Instance.position.width, uScript.Instance.position.height /* - statusbarHeight */);

      // The initial panel dimensions should be retrieved from the Settings file
      //
      // For now, use hard coded values
      //

//      PanelCanvas = uScriptGUIPanelCanvas.Instance;
//
//      PanelContainerLeft.Add(uScriptGUIPanelScript.Instance);
//      PanelContainerLeft.Add(uScriptGUIPanelContent.Instance);
//      PanelContainerLeft.Add(uScriptGUIPanelPalette.Instance);
////      PanelContainerLeft.Add(uScriptGUIPanelProperties.Instance);
////      PanelContainerCenter.Add(uScriptGUIPanelReference.Instance);
//      PanelContainerCenter.Add(uScriptGUIPanelProperty.Instance);
//      PanelContainerCenter.Add(uScriptGUIPanelReference.Instance);

      PanelReference = uScriptGUIPanelReference.Instance;

//      // Set the panel size options
//      int i;
//
//      for (i=0; i < PanelContainerLeft.Count; i++)
//      {
//         PanelContainerLeft[i].PanelOrientation = (PanelContainerLeft.Count > i + 1 ? FixedPanelSize.Vertical : FixedPanelSize.None);
//      }
//
//      for (i=0; i < PanelContainerRight.Count; i++)
//      {
//         PanelContainerRight[i].PanelOrientation = (PanelContainerRight.Count > i + 1 ? FixedPanelSize.Vertical : FixedPanelSize.None);
//      }
//
//      for (i=0; i < PanelContainerCenter.Count; i++)
//      {
//         PanelContainerCenter[i].PanelOrientation = (PanelContainerCenter.Count > i + 1 ? FixedPanelSize.Horizontal : FixedPanelSize.None);
//      }
//
//      for (i=0; i < PanelContainerBottom.Count; i++)
//      {
//         PanelContainerBottom[i].PanelOrientation = (PanelContainerBottom.Count > i + 1 ? FixedPanelSize.Horizontal : FixedPanelSize.None);
//      }
   }

   #endregion

}
