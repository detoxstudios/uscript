using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

//
// This file contains a collection of utility classes for use with uScript
// _______________________________________________________________________
//

public class uScriptUtility
{
}




//
// Custom GUI Controls
//
public static class CustomGUI
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

   public static void BeginColumns(string col1, string col2, string col3, Vector2 offset, Rect rect)
   {
      _columnEnabled = new Column(string.Empty, 20);
      _columnLabel = new Column(col1, 100);
      _columnValue = new Column(col2, 100);
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
         Debug.Log("Control focus changed from '" + _focusedControl + "' to '" + GUI.GetNameOfFocusedControl() + "'\n");
         _previousControl = _focusedControl;
         _focusedControl = GUI.GetNameOfFocusedControl();
      }
   }


   static void Separator()
   {
      GUILayout.Space(10);
   }


   public static bool BeginProperty(string label, string id)
   {
      _propertyCount++;
//      if (++_propertyCount > 1)
//      {
//         Separator();
//      }
//
      _propertyKey = label + "_" + id;
      if (false == _foldoutExpanded.ContainsKey(_propertyKey))
      {
         _foldoutExpanded[_propertyKey] = true;
      }

//      GUIStyle style = new GUIStyle(EditorStyles.miniButton);
      GUIStyle style = new GUIStyle(GUI.skin.button);
      style.alignment = TextAnchor.MiddleLeft;


      _foldoutExpanded[_propertyKey] = GUILayout.Toggle(_foldoutExpanded[_propertyKey], label + "_" + id, style);

      return _foldoutExpanded[_propertyKey];
   }


   public static void EndProperty()
   {
      if (_foldoutExpanded[_propertyKey])
      {
         Separator();
      }
   }


   static void BeginRow(string label, ref bool enabled, bool locked)
   {
      EditorGUILayout.BeginHorizontal();
      //GUILayout.Space(EditorGUI.indentLevel * 15);
      if (enabled && locked)
      {
         GUILayout.Space(_columnEnabled.Width + 4);
      }
      else
      {
         if (locked)
         {
            GUI.enabled = enabled;
         }
         enabled = GUILayout.Toggle(enabled, string.Empty, _styleEnabled, GUILayout.Width(_columnEnabled.Width));
         GUI.enabled = true;
      }
      //EditorGUIUtility.LookLikeInspector();
      EditorGUIUtility.LookLikeControls(_columnLabel.Width);
      EditorGUILayout.PrefixLabel(label, _styleLabel);
      GUI.enabled = enabled;
   }


   static void EndRow(string type)
   {
      Vector2 v = _styleType.CalcSize(new GUIContent(type));
      _columnType.Width = Mathf.Max(_columnType.Width, (int)v.x);
		
      GUI.enabled = true;
      GUILayout.Label(type, _styleType);
      EditorGUILayout.EndHorizontal();
   }


   public static int IntField(string label, int value, ref bool enabled, bool locked)
   {
      return IntField(label, value, ref enabled, locked, int.MinValue, int.MaxValue);
   }

   public static int IntField(string label, int value, ref bool enabled, bool locked, int min, int max)
   {
      BeginRow(label, ref enabled, locked);

      GUI.SetNextControlName(label);
      value = EditorGUILayout.IntField(value, GUILayout.Width(_columnValue.Width));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static float FloatField(string label, float value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      GUI.SetNextControlName(label);
      value = EditorGUILayout.FloatField(value, GUILayout.Width(_columnValue.Width));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static string TextField(string label, string value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      GUI.SetNextControlName(label);
      value = EditorGUILayout.TextField(value, GUILayout.Width(_columnValue.Width));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static bool BoolField(string label, bool value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      GUI.SetNextControlName(label);
      value = EditorGUILayout.Toggle(value, GUILayout.Width(_columnValue.Width));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static UnityEngine.Color ColorField(string label, Color value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      GUI.SetNextControlName(label);
      value = EditorGUILayout.ColorField(value, GUILayout.Width(_columnValue.Width));

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


   public static Vector2 Vector2Field(string label, Vector2 value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      int spacing = 4; // 4 * 1
      int w = (_columnValue.Width - spacing) / 2;
      int p = (_columnValue.Width - spacing) % (w * 2);
      GUI.SetNextControlName(label + ".x");
      value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
      GUI.SetNextControlName(label + ".y");
      value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w + p));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static Vector3 Vector3Field(string label, Vector3 value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      int spacing = 8; // 4 * 2
      int w = (_columnValue.Width - spacing) / 3;
      int p = (_columnValue.Width - spacing) % (w * 3);
      value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
      value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
      value.z = EditorGUILayout.FloatField(value.z, GUILayout.Width(w + p));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static Vector4 Vector4Field(string label, Vector4 value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      int spacing = 12; // 4 * 3
      int w = (_columnValue.Width - spacing) / 4;
      int p = (_columnValue.Width - spacing) % (w * 4);
      value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
      value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
      value.z = EditorGUILayout.FloatField(value.z, GUILayout.Width(w));
      value.w = EditorGUILayout.FloatField(value.w, GUILayout.Width(w + p));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static Rect RectField(string label, Rect value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      int spacing = 12; // 4 * 3
      int w = (_columnValue.Width - spacing) / 4;
      int p = (_columnValue.Width - spacing) % (w * 4);
      value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
      value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
      value.width = EditorGUILayout.FloatField(value.width, GUILayout.Width(w));
      value.height = EditorGUILayout.FloatField(value.height, GUILayout.Width(w + p));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static System.Enum EnumField(string label, System.Enum value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      //int spacing = 12; // 4 * 3
      //int w = (_columnValue.Width - spacing) / 4;
      //int p = (_columnValue.Width - spacing) % (w * 4);
      //value.x = EditorGUILayout.FloatField(value.x, GUILayout.Width(w));
      //value.y = EditorGUILayout.FloatField(value.y, GUILayout.Width(w));
      //value.width = EditorGUILayout.FloatField(value.width, GUILayout.Width(w));
      //value.height = EditorGUILayout.FloatField(value.height, GUILayout.Width(w + p));

      value = EditorGUILayout.EnumPopup(value, GUILayout.Width(_columnValue.Width));

      EndRow(value.GetType().ToString());
      return value;
   }


   public static T[] ArrayFoldout<T>(string label, T[] array, ref bool foldout, ref bool enabled, bool locked)
   {
      T[] newArray = array;
      int arraySize;
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

      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Space(_columnEnabled.Width + 4);
         foldout = GUILayout.Toggle(foldout, label, EditorStyles.foldout);

         if (foldout)
         {
            GUILayout.Space(_columnValue.Width + 4);
         }
         else
         {
            GUILayout.Label("(" + arraySize + " item" + (arraySize==1 ? string.Empty : "s") + ")", _styleLabel, GUILayout.Width(_columnValue.Width));
         }
//         GUILayout.Label(array.GetType().ToString(), GUILayout.ExpandWidth(true));

         string type = array.GetType().ToString();
         v = _styleType.CalcSize(new GUIContent(type));
         _columnType.Width = Mathf.Max(_columnType.Width, (int)v.x);

         GUI.enabled = true;
         GUILayout.Label(type, _styleType);
      }
      EditorGUILayout.EndHorizontal();


      EditorGUILayout.BeginVertical();
      {
         if (foldout)
         {
            EditorGUI.indentLevel += 3;

            BeginRow("Size", ref enabled, true);







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







            v = _styleType.CalcSize(new GUIContent(arraySize.GetType().ToString()));
            _columnType.Width = Mathf.Max(_columnType.Width, (int)v.x);

            EndRow(arraySize.GetType().ToString());






            for (int i = 0; i < newArray.Length; i++)
            {
               T entry = default(T);
               if (i < array.Length)
               {
                  entry = array[i];
               }
               bool tmpBool = true;
               newArray[i] = PropertyRow<T>("Element " + i, entry, ref tmpBool, true);
            }

            EditorGUI.indentLevel -= 3;
         }




         ////EditorGUIUtility.LookLikeControls();


         //   EditorGUILayout.Space();
         //   EditorGUILayout.BeginVertical();

         //   EditorGUILayout.EndVertical();



      }
      EditorGUILayout.EndVertical();

      return newArray;
   }

   public static int ArraySizeField(int size)
   {
      //int newSize = 



      return size;
   }

   public static T PropertyRow<T>(string label, T value, ref bool enabled, bool locked)
   {
      BeginRow(label, ref enabled, locked);

      if (value is int)
      {
      }
      else if (value is float)
      {
      }
      else if (value is string)
      {
      }
      else if (value is bool)
      {
      }
      else if (value is System.Enum)
      {
         object t = value;
         t = EditorGUILayout.EnumPopup((System.Enum)t, GUILayout.Width(_columnValue.Width));
         value = (T)t;
      }
      else
      {
         //throw System.ArgumentException("Unhandled type: " + value.GetType().ToString());
      }

      EndRow(value.GetType().ToString());
      return value;
   }








//               EditorGUILayout.Separator();
//               EditorGUILayout.Space();

//   TextArea       Make a text area.
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
}
