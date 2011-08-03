using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

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

   static GUIStyle _styleColumnHeader;
   static GUIStyle _styleEnabled;
   static GUIStyle _styleLabel;
   static GUIStyle _styleType;

   public static Vector2 columnOffset;
   public static Rect svRect;
   public static int columnHeaderHeight = 16;

   public static string _focusedControl = string.Empty;
   public static string _previousControl = string.Empty;

   static Dictionary<string, bool> _foldoutExpanded = new Dictionary<string, bool>();
   static Dictionary<string, object> _modifiedValue = new Dictionary<string, object>();

   static string _propertyKey = string.Empty;
   static int _propertyCount;



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
         GUI.enabled = (value ? !uScript.Instance.isPreferenceWindowOpen : false);
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

      if (null == _styleColumnHeader)
      {
         _styleColumnHeader = new GUIStyle(EditorStyles.toolbarButton);
         _styleColumnHeader.normal.background = _styleColumnHeader.onNormal.background;
         _styleColumnHeader.fontStyle = FontStyle.Bold;
         _styleColumnHeader.alignment = TextAnchor.MiddleLeft;
         _styleColumnHeader.padding = new RectOffset(5, 8, 0, 0);
         _styleColumnHeader.fixedHeight = columnHeaderHeight;
         _styleColumnHeader.contentOffset = new Vector2(0, -1);

         _styleEnabled = new GUIStyle(GUI.skin.toggle);
         _styleEnabled.margin = new RectOffset(4, 0, 2, 4);
         _styleEnabled.padding = new RectOffset(20, 0, 0, 0);
         _styleEnabled.padding.left = 20;

         _styleLabel = new GUIStyle(EditorStyles.label);
         _styleLabel.margin.left = 0;

         _styleType = new GUIStyle(EditorStyles.label);
         _styleType.margin.left = 6;
			
      }
		
      GUILayout.Label(string.Empty, new GUIStyle(), GUILayout.Height(columnHeaderHeight));
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
      GUI.Label(new Rect(x, y, _columnEnabled.Width + 4 + 2, columnHeaderHeight), _columnEnabled.Label, _styleColumnHeader);
      x += _columnEnabled.Width + 2;

      // Interior column - Property name
      GUI.Label(new Rect(x, y, _columnLabel.Width + 4, columnHeaderHeight), _columnLabel.Label, _styleColumnHeader);
      x += _columnLabel.Width + 4;

      // Interior column - Property value
      GUI.Label(new Rect(x, y, _columnValue.Width + 4, columnHeaderHeight), _columnValue.Label, _styleColumnHeader);
      x += _columnValue.Width + 4;

      // Last column - Property type
      // This right-most column should appear to have an expanded width
      GUI.Label(new Rect(x, y, svRect.width, columnHeaderHeight), _columnType.Label, _styleColumnHeader);
//      GUI.Label(new Rect(x, y, _columnType.Width + 4 + 2, columnHeaderHeight), _columnType.Label, style);
//      GUI.Label(new Rect(x, y, svRect.width - _columnLabel.Width - _columnValue.Width - 22 + columnOffset.x, columnHeaderHeight), _columnType.Label, style);


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


   static void Separator()
   {
      GUILayout.Space(10);
   }


   public static bool BeginProperty(string label, Node node)
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

      _propertyCount++;
      _propertyKey = node.Guid.ToString();
      if (false == _foldoutExpanded.ContainsKey(_propertyKey))
      {
         _foldoutExpanded[_propertyKey] = true;
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

         _foldoutExpanded[_propertyKey] = GUILayout.Toggle(_foldoutExpanded[_propertyKey], label, uScriptGUIStyle.nodeButtonLeft);

         GUI.color = tmpColor;
         uScriptGUIStyle.nodeButtonLeft.normal.textColor = textColor;

         //
         // Deprecation button
         //
         if (uScript.IsNodeTypeDeprecated(((DisplayNode)node).EntityNode) == false && m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(((DisplayNode)node).EntityNode))
         {
            if ( true == m_ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(((DisplayNode)node).EntityNode) )
            {
               if (GUILayout.Button(uScriptGUIContent.listMiniUpgrade, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
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
               if (GUILayout.Button(uScriptGUIContent.listMiniDeleteMissing, uScriptGUIStyle.nodeButtonMiddle, GUILayout.Width(20)))
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
         if (GUILayout.Button(uScriptGUIContent.listMiniSearch, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
         {
            m_ScriptEditorCtrl.CenterOnNode(node);
         }
      }
      GUILayout.EndHorizontal();

      return _foldoutExpanded[_propertyKey];
   }


   public static void EndProperty()
   {
      if (_foldoutExpanded[_propertyKey])
      {
         Separator();
      }
   }
   

   static void BeginRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginHorizontal();
      //GUILayout.Space(EditorGUI.indentLevel * 15);
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
      //EditorGUIUtility.LookLikeInspector();
      EditorGUIUtility.LookLikeControls(_columnLabel.Width);
      EditorGUILayout.PrefixLabel(label, _styleLabel);
      
      uScriptGUI.enabled = (! isReadOnly) && (! isSocketExposed || ! isLocked);
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
         EditorGUILayout.TextField(isReadOnly ? "(read-only)" : "(socket used)", GUILayout.Width(_columnValue.Width));
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
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.IntField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static float FloatField(string label, float value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.FloatField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TextField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.TextField(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TextArea(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

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
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         GUI.SetNextControlName(label);
         value = EditorGUILayout.Toggle(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static UnityEngine.Color ColorField(string label, Color value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

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
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 4; // 4 * 1
         int w = (_columnValue.Width - spacing) / 2;
         int p = (_columnValue.Width - spacing) % (w * 2);

         GUI.SetNextControlName(label + ".x");
         value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         GUI.SetNextControlName(label + ".y");
         value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y]");
      return value;
   }


   public static Vector3 Vector3Field(string label, Vector3 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 8; // 4 * 2
         int w = (_columnValue.Width - spacing) / 3;
         int p = (_columnValue.Width - spacing) % (w * 3);
         value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z]");
      return value;
   }


   public static Vector4 Vector4Field(string label, Vector4 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z, W]");
      return value;
   }


   public static Rect RectField(string label, Rect value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
         value.width = EditorGUILayout.FloatField(value.width, GUILayout.Width(w));
         value.height = EditorGUILayout.FloatField(value.height, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, W, H]");
      return value;
   }


   public static Quaternion QuaternionField(string label, Quaternion value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, GUILayout.Width(w + p));
      }

      EndRow(value.GetType().ToString() + " [X, Y, Z, W]");
      return value;
   }


   public static System.Enum EnumField(string label, System.Enum value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         //int spacing = 12; // 4 * 3
         //int w = (_columnValue.Width - spacing) / 4;
         //int p = (_columnValue.Width - spacing) % (w * 4);
         //value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
         //value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
         //value.width = EditorGUILayout.FloatField(value.width, GUILayout.Width(w));
         //value.height = EditorGUILayout.FloatField(value.height, GUILayout.Width(w + p));

         value = EditorGUILayout.EnumPopup(value, GUILayout.Width(_columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string ChoiceField(string label, string value, string[] choices, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

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
         BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            //first show the text field and get back the same (or changed value)
            string userText = EditorGUILayout.TextField(textValue, GUILayout.Width(_columnValue.Width));
            System.Enum newEnum;

            //try and turn the text field value back into an enum, if it doesn't work
            //then revert back to the original value
            try { newEnum = (System.Enum) System.Enum.Parse(value.GetType(), userText); }
            catch { newEnum = (System.Enum) value; }

            EndRow(textValue.GetType().ToString());

            bool tmpBool = false;

            BeginRow(string.Empty, ref tmpBool, true, isReadOnly);

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
         BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            // game objects are held/treated as strings
            // but we will custom convert them to actual game objects (if they exist)
            // so we can use the game object browser
            //
            // first show the text field and get back the same (or changed value)
            if ( true == uScriptConfig.ShouldAutoPackage(type) )
            {
               string labelValue = textValue;
            
               int index = labelValue.LastIndexOf("/") + 1;
               if ( index > 0 ) 
               {
                  labelValue = labelValue.Substring( index, labelValue.Length - index );
               }
   
               EditorGUILayout.LabelField(labelValue, "", GUILayout.Width(_columnValue.Width));
            }
            else
            {
               textValue = EditorGUILayout.TextField(textValue, GUILayout.Width(_columnValue.Width));
            }
   
            EndRow(textValue.GetType().ToString());


            bool tmpBool = false;

            BeginRow(string.Empty, ref tmpBool, true, isReadOnly);

            // now try and update the object browser with an instance of the specified object
            UnityEngine.Object []objects   = UnityEngine.Object.FindObjectsOfType(type);
            UnityEngine.Object unityObject = null;
   
            if ( true == uScriptConfig.ShouldAutoPackage(type) )
            {
               foreach ( UnityEngine.Object o in objects )
               {
                  string key = uScriptConfig.GetAssetPackageKey(o, o.GetType());
                  
                  if ( key == textValue )
                  {
                     unityObject = o;
                     break;
                  }
               }
            }
            else
            {
               foreach ( UnityEngine.Object o in objects )
               {
                  if ( o.name == textValue )
                  {
                     unityObject = o;
                     break;
                  }
               }
            }

            // components should never be instances in the property grid
            // we must refer to (and select) their parent game object
            if ( true == typeof(Component).IsAssignableFrom(type) )
            {
               type = typeof(GameObject);
               if ( null != unityObject ) unityObject = ((Component) unityObject).gameObject;
            }

   #if UNITY_3_3
            unityObject = EditorGUILayout.ObjectField( unityObject, type, GUILayout.Width(_columnValue.Width) ) as UnityEngine.Object;
   #elif UNITY_3_4
            unityObject = EditorGUILayout.ObjectField( unityObject, type, true, GUILayout.Width(_columnValue.Width) ) as UnityEngine.Object;
   #endif

            // if that object (or the changed object) does exist, use it's name to update the property value
            // if it doesn't exist then the 'val' will stay as what was entered into the TextField
            if ( unityObject != null )
            {
               if ( true == uScriptConfig.ShouldAutoPackage(type) )
               {
                  //we have to package now because the returned parameter is just the string representation
                  //and it won't always be able to reference back to the actual object
                  textValue = uScript.PackageAsset(unityObject, type);
               }
               else
               {
                  textValue = unityObject.name;               
               }
            }
         }

         EndRow(type.ToString());
      }
      EditorGUILayout.EndVertical();
      return textValue;
   }


   public static T[] ArrayFoldout<T>(string label, T[] array, ref bool foldout, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      T[] newArray = array;
      int arraySize;
      string type;
      Vector2 v;




      if (_modifiedValue.ContainsKey(label))
      {
         arraySize = (int)_modifiedValue[label];
      }
      else
      {
         arraySize = array.Length;
         _modifiedValue.Add(label, arraySize);
      }




      //
      // The Foldout row
      //
      EditorGUILayout.BeginHorizontal();
      {
         // Display the socket toggle
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

         // Display the foldout
         EditorGUIUtility.LookLikeControls(_columnLabel.Width);

         if (isSocketExposed && isLocked || isReadOnly)
         {
            EditorGUILayout.PrefixLabel(label, _styleLabel);
         }
         else
         {
            foldout = GUILayout.Toggle(foldout, label, EditorStyles.foldout, GUILayout.Width(_columnLabel.Width - 3));
         }

         uScriptGUI.enabled = (! isReadOnly) && (! isSocketExposed || ! isLocked);

         // Display the array info, readonly, socketUsed, or an empty area
         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            if (foldout)
            {
               GUILayout.Space(_columnValue.Width + 4);
            }
            else
            {
               GUILayout.Label("(" + arraySize + " item" + (arraySize==1 ? string.Empty : "s") + ")", _styleLabel, GUILayout.Width(_columnValue.Width));
            }

         }

         // Display the type column
         type = array.GetType().ToString().Replace("UnityEngine.", string.Empty);
         v = _styleType.CalcSize(new GUIContent(type));
         _columnType.Width = Mathf.Max(_columnType.Width, (int)v.x);

         uScriptGUI.enabled = true;
         GUILayout.Label(type, _styleType);
      }
      EditorGUILayout.EndHorizontal();

      //
      // The array size
      //
      EditorGUILayout.BeginVertical();
      {
         if (foldout)
         {
            bool hideSocket = false;

            EditorGUI.indentLevel += 3;

            BeginRow("Size", ref hideSocket, true, false);

            GUI.SetNextControlName(label+"_ArraySize");
            arraySize = EditorGUILayout.IntField(arraySize, GUILayout.Width(_columnValue.Width));

            // Handle keyboard events while the control is focused
            if (Event.current.type == EventType.KeyDown && GUI.GetNameOfFocusedControl() == label+"_ArraySize")
            {
               // TAB
               if (Event.current.keyCode == KeyCode.Tab)
               {
                  Debug.Log("============== TAB was pressed to change the control\n" + Event.current.type.ToString());
                  _previousControl = GUI.GetNameOfFocusedControl();
               }

               // ENTER
               if (Event.current.keyCode == KeyCode.Escape ||
                   Event.current.keyCode == KeyCode.KeypadEnter ||
                   Event.current.keyCode == KeyCode.Return)
               {
                  Debug.Log("=============== '"+Event.current.keyCode.ToString()+"' was pressed\n");
               }
            }

//            if (_focusedControl != GUI.GetNameOfFocusedControl())
//            {
//               Debug.Log("============== Changed");
//            }

            if (_previousControl == (label+"_ArraySize") && arraySize != array.Length)
            {
               _previousControl = string.Empty;
               Debug.Log("Committing change to '"+label+"_ArraySize with "+ arraySize +"\n");
               Debug.Log( "arraySize:"+arraySize+" is not equal to array.Length:"+array.Length+"\n");

               arraySize = Mathf.Clamp(arraySize, 0, 32);

               newArray = new T[arraySize];
               if (_modifiedValue.ContainsKey(label))
               {
                  _modifiedValue.Remove(label);
               }
            }
            else
            {
               _modifiedValue[label] = arraySize;
            }

            // Display the type column
            EndRow(arraySize.GetType().ToString());

            //
            // The elements
            //
            for (int i = 0; i < newArray.Length; i++)
            {
               T entry = default(T);
               if (i < array.Length)
               {
                  entry = array[i];
               }
               newArray[i] = PropertyRow<T>("Element " + i, entry, ref hideSocket, true, false);
            }

            EditorGUI.indentLevel -= 3;
         }
      }
      EditorGUILayout.EndVertical();

      return newArray;
   }

   public static int ArraySizeField(int size)
   {
      //int newSize = 



      return size;
   }

   public static T PropertyRow<T>(string label, T value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginRow(label, ref isSocketExposed, isLocked, isReadOnly);

      object t = value;
      string typeFormat = string.Empty;

      if (value is int)
      {
         t = EditorGUILayout.IntField((int)t, GUILayout.Width(_columnValue.Width));
      }
      else if (value is float)
      {
         t = EditorGUILayout.FloatField((float)t, GUILayout.Width(_columnValue.Width));
      }
      else if (value is string)
      {
         t = EditorGUILayout.TextField((string)t, GUILayout.Width(_columnValue.Width));
      }
      else if (value is bool)
      {
         t = EditorGUILayout.Toggle((bool)t, GUILayout.Width(_columnValue.Width));
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

         val.x = EditorGUILayout.FloatField(val.x, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, GUILayout.Width(w + p));
         typeFormat = " [X, Y]";

         t = val;
      }
      else if (value is Vector3)
      {
         Vector3 val = (Vector3)t;

         int spacing = 8; // 4 * 2
         int w = (_columnValue.Width - spacing) / 3;
         int p = (_columnValue.Width - spacing) % (w * 3);
         val.x = EditorGUILayout.FloatField(val.x, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z]";

         t = val;
      }
      else if (value is Vector4)
      {
         Vector4 val = (Vector4)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z, W]";

         t = val;
      }
      else if (value is Rect)
      {
         Rect val = (Rect)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, GUILayout.Width(w));
         val.width = EditorGUILayout.FloatField(val.width, GUILayout.Width(w));
         val.height = EditorGUILayout.FloatField(val.height, GUILayout.Width(w + p));
         typeFormat = " [X, Y, W, H]";

         t = val;
      }
      else if (value is Quaternion)
      {
         Quaternion val = (Quaternion)t;

         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         val.x = EditorGUILayout.FloatField(val.x, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, GUILayout.Width(w + p));
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





//               EditorGUILayout.Separator();
//               EditorGUILayout.Space();

//   Slider         Make a slider the user can drag to change a value between a min and a max.
//   IntSlider      Make a slider the user can drag to change an integer value between a min and a max.
//   MinMaxSlider   Make a special slider the user can use to specify a range between a min and a max.
//   Popup          Make a generic popup selection field.
//   EnumPopup      Make an enum popup selection field.
//   IntPopup       Make an integer popup selection field.
//   TagField       Make a tag selection field.
//   LayerField     Make a layer selection field.
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
//      uScriptGUIContent.Init((uScriptGUIContent.ContentStyle)uScript.Preferences.ToolbarButtonStyle);
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
