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

      public Column( string label, int width )
      {
         this.Label = label;
         this.Width = width;
      }
   }

   static Column _columnLabel;
   static Column _columnValue;
   static Column _columnType;


   public static Vector2 columnOffset;
   public static Rect svRect;
   public static int columnHeaderHeight = 16;

   public static void BeginColumns( string col1, string col2, string col3, Vector2 offset, Rect rect )
   {
      _columnLabel = new Column( col1, 100 );
      _columnValue = new Column( col2, 100 );
      _columnType = new Column( col3, 0 );

      columnOffset = offset;
      svRect = rect;

      GUILayout.Label( string.Empty, new GUIStyle(), GUILayout.Height( columnHeaderHeight ) );
   }


   public static void EndColumns()
   {
      GUIStyle style = new GUIStyle( EditorStyles.toolbarButton );
      style.normal.background = style.onNormal.background;
      style.fontStyle = FontStyle.Bold;
      style.alignment = TextAnchor.MiddleLeft;
      style.padding = new RectOffset( 5, 8, 0, 0 );
      style.fixedHeight = columnHeaderHeight;
      style.contentOffset = new Vector2( 0, -1 );

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

      // First column
      GUI.Label( new Rect( x, y, _columnLabel.Width + 4 + 2, columnHeaderHeight), _columnLabel.Label, style );
      x += _columnLabel.Width + 2;

      // Interior column
      GUI.Label( new Rect( x, y, _columnValue.Width + 4, columnHeaderHeight), _columnValue.Label, style );
      x += _columnValue.Width + 4;

      // Last column
      // This right-most column should appear to have an expanded width
      GUI.Label( new Rect( x, y, svRect.width, columnHeaderHeight), _columnType.Label, style );
//      GUI.Label( new Rect( x, y, _columnType.Width + 4 + 2, columnHeaderHeight), _columnType.Label, style );
//      GUI.Label( new Rect( x, y, svRect.width - _columnLabel.Width - _columnValue.Width - 22 + columnOffset.x, columnHeaderHeight), _columnType.Label, style );
   }






   public static int IntField( string label, int value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.IntField( value, GUILayout.Width( _columnValue.Width ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static float FloatField( string label, float value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.FloatField( value, GUILayout.Width( _columnValue.Width ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static string TextField( string label, string value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.TextField( value, GUILayout.Width( _columnValue.Width ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static bool BoolField( string label, bool value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.Toggle( value, GUILayout.Width( _columnValue.Width) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static UnityEngine.Color ColorField( string label, Color value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         value = EditorGUILayout.ColorField( value, GUILayout.Width( _columnValue.Width ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
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


   public static Vector2 Vector2Field( string label, Vector2 value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 4; // 4 * 1
         int w = (_columnValue.Width - spacing) / 2;
         int p = (_columnValue.Width - spacing) % (w * 2);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width( w ) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width( w + p ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static Vector3 Vector3Field( string label, Vector3 value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 8; // 4 * 2
         int w = (_columnValue.Width - spacing) / 3;
         int p = (_columnValue.Width - spacing) % (w * 3);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width( w ) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width( w ) );
         value.z = EditorGUILayout.FloatField( value.z, GUILayout.Width( w + p ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static Vector4 Vector4Field( string label, Vector4 value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width( w ) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width( w ) );
         value.z = EditorGUILayout.FloatField( value.z, GUILayout.Width( w ) );
         value.w = EditorGUILayout.FloatField( value.w, GUILayout.Width( w + p ) );

         // Type
         Vector2 v = GUI.skin.GetStyle( "label" ).CalcSize( new GUIContent( value.GetType().ToString() ) );
         _columnType.Width = (int)v.x;
         GUILayout.Label( value.GetType().ToString() );
      }
      EditorGUILayout.EndHorizontal();
      return value;
   }


   public static Rect RectField( string label, Rect value )
   {
      EditorGUILayout.BeginHorizontal();
      {
         // Label
         EditorGUIUtility.LookLikeControls( _columnLabel.Width );
         EditorGUILayout.PrefixLabel( label );

         // Field
         int spacing = 12; // 4 * 3
         int w = (_columnValue.Width - spacing) / 4;
         int p = (_columnValue.Width - spacing) % (w * 4);
         value.x = EditorGUILayout.FloatField( value.x, GUILayout.Width( w ) );
         value.y = EditorGUILayout.FloatField( value.y, GUILayout.Width( w ) );
         value.width = EditorGUILayout.FloatField( value.width, GUILayout.Width( w ) );
         value.height = EditorGUILayout.FloatField( value.height, GUILayout.Width( w + p ) );

         // Type
         GUILayout.Label( value.GetType().ToString() );
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
