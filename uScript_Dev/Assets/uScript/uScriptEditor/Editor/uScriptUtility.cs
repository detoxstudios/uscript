using UnityEngine;
using UnityEditor;
using System.Collections;
//using System.Collections.Generic;

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
   public static int _col1 = 100;
   public static int _col2 = 100;


   public static int IntField(string label, int value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.IntField( value, GUILayout.Width(_col2) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static float FloatField(string label, float value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.FloatField( value, GUILayout.Width(_col2) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static string TextField(string label, string value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.TextField( value, GUILayout.Width(_col2) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static bool BoolField(string label, bool value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.Toggle( value, GUILayout.Width(_col2) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static UnityEngine.Color ColorField(string label, Color value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.ColorField( value, GUILayout.Width(_col2) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();

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


   public static Vector2 Vector2Field(string label, Vector2 value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 4; // 4 * 1
         int w = (_col2 - spacing) / 2;
         int p = (_col2 - spacing) % (w * 2);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width(w) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width(w + p) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();

      return value;
   }


   public static Vector3 Vector3Field(string label, Vector3 value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 8; // 4 * 2
         int w = (_col2 - spacing) / 3;
         int p = (_col2 - spacing) % (w * 3);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width(w) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width(w) );
         value.z = EditorGUILayout.FloatField( value.z, GUILayout.Width(w + p) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();

      return value;
   }


   public static Vector4 Vector4Field(string label, Vector4 value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 12; // 4 * 3
         int w = (_col2 - spacing) / 4;
         int p = (_col2 - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width(w) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width(w) );
         value.z = EditorGUILayout.FloatField( value.z, GUILayout.Width(w) );
         value.w = EditorGUILayout.FloatField( value.w, GUILayout.Width(w + p) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();

      return value;
   }


   public static Rect RectField(string label, Rect value)
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls(_col1);
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 12; // 4 * 3
         int w = (_col2 - spacing) / 4;
         int p = (_col2 - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width(w) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width(w) );
         value.width = EditorGUILayout.FloatField( value.width, GUILayout.Width(w) );
         value.height = EditorGUILayout.FloatField( value.height, GUILayout.Width(w + p) );

         // Type
         GUILayout.Label(value.GetType().ToString());
      }
      EditorGUILayout.EndHorizontal();

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


