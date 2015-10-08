// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptEditor.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Plug type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.ScriptEditor
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   using System.Reflection;

   using Detox.Data;
   using Detox.Data.ScriptEditor;
   using Detox.Drawing;
   using Detox.Editor;
   using Detox.Editor.GUI;
   using Detox.Utility;

   using UnityEngine;

   public struct Plug
   {
      public string Name;
      public string FriendlyName;

      public Detox.Data.ScriptEditor.Plug ToPlugData( )
      {
         Detox.Data.ScriptEditor.Plug data = new Detox.Data.ScriptEditor.Plug( );

         data.Name = Name;
         data.FriendlyName = FriendlyName;

         return data;
      }

      public Plug( Detox.Data.ScriptEditor.Plug plugData )
      {
         Name = plugData.Name;
         FriendlyName = plugData.FriendlyName;
      }

      public override int GetHashCode( )
      {
         return base.GetHashCode( );
      }

      public override bool Equals(object o)
      {
         if ( false == (o is Plug) ) return false;
         
         return (((Plug)o) == this);
      }

      public static bool operator == (Plug a, Plug b)
      {
         if ( a.Name != b.Name ) return false; 
         
         return true;
      }

      public static bool operator != (Plug a, Plug b)
      {
         return ! (a == b);
      }
   }

   public struct Parameter
   {
      [Flags]
      public enum VisibleState
      {
         Visible = 0x1,
         Hidden  = 0x2,
         Locked  = 0x4,
      }

      public static Parameter Empty;

      public VisibleState State;
      public string       Name;
      public string       FriendlyName;
      public string       Default;
      public string       Type;
      public string       AutoLinkType;
      public string       ReferenceGuid;
      public bool         Input;
      public bool         Output;

      public bool IsVisible( ) { return 0 != (State & VisibleState.Visible); }
      public bool IsHidden( )  { return 0 != (State & VisibleState.Hidden); }
      public bool IsLocked( )  { return 0 != (State & VisibleState.Locked); }

      public static char ArrayDelimeter { get { return Detox.Data.ScriptEditor.Parameter.ArrayDelimeter; } }

      public static string[] StringToArray(string value)
      {
         string []array;

         if ( value.Length > 0 && value[0] == Parameter.ArrayDelimeter )
         {
            array = value.Substring( 1 ).Split( Parameter.ArrayDelimeter );
         }
         else
         {
            array = new string[0];
         }

         return array;
      }

      public static string ArrayToString(string []array)
      {
         string val = "";

         if ( array.Length > 0 )
         {
            val = Parameter.ArrayDelimeter + string.Join( Parameter.ArrayDelimeter.ToString(), array );
         }

         return val;
      }

      public static string FormatArrayString(string value)
      {
         if ( value.Length > 0 && value[0] == Parameter.ArrayDelimeter )
         {
            value = value.Substring( 1 ).Replace( Parameter.ArrayDelimeter, ',' );
         }
         return value;
      }

      public static string []FlattenStringArrays(string []values, char delimiter)
      {
         List<string> list = new List<string>( );

         foreach ( string v in values )
         {
            string [] scalars = v.Split( delimiter );

            foreach ( string s in scalars )
            {
               list.Add( s );
            }
         }

         return list.ToArray( );
      }

      private object ParseArray(string t, string value)
      {
         string []values = Parameter.StringToArray( value );

         if ( t == typeof(bool[]).ToString() )
         {
            try
            {
               bool[] array = new bool[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = "true" == values[ i ];
               }

               return array;
            }
            catch { return new bool[0]; }
         }

         if ( t == typeof(GUILayoutOption[]).ToString() )
         {
            try
            {
               GUILayoutOption[] array = new GUILayoutOption[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  string[] tokens = values[i].Split(':');

                  if (tokens[1] == "true")
                  {
                     tokens[1] = "1";
                  }
                  else if (tokens[1] == "false")
                  {
                     tokens[1] = "0";
                  }

                  int optionValue = int.Parse(tokens[1]);
                  array[i] = Property.CreateGUILayoutOption(tokens[0], optionValue);
               }

               return array;
            }
            catch  { return new GUILayoutOption[0]; }
         }

         if ( t == typeof(UnityEngine.Color[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );

               int num = (values.Length) / 4;

               UnityEngine.Color[] array = new UnityEngine.Color[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new UnityEngine.Color( Single.Parse(values[i*4+0]), Single.Parse(values[i*4+1]), Single.Parse(values[i*4+2]), Single.Parse(values[i*4+3]) );
               }

               return array;
            }
            catch { return new UnityEngine.Color[0]; }
         }

         if ( t == typeof(float[]).ToString() )
         {
            try
            {
               float[] array = new float[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = Single.Parse(values[i]);
               }

               return array;
            }
            catch { return new float[0]; }
         }

         if ( t == typeof(int[]).ToString() )
         {
            try
            {
               int[] array = new int[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = Int32.Parse(values[i]);
               }

               return array;
            }
            catch { return new int[0]; }
         }

         if ( t == typeof(Vector2[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );

               int num = (values.Length) / 2;

               Vector2[] array = new Vector2[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new Vector2( Single.Parse(values[i*2+0]), Single.Parse(values[i*2+1]) );
               }

               return array;
            }
            catch { return new Vector2[0]; }
         }

         if ( t == typeof(Vector3[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );
               
               int num = (values.Length) / 3;

               Vector3[] array = new Vector3[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new Vector3( Single.Parse(values[i*3+0]), Single.Parse(values[i*3+1]), Single.Parse(values[i*3+2]) );
               }

               return array;
            }
            catch { return new Vector3[0]; }
         }

         if ( t == typeof(Vector4[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );

               int num = (values.Length) / 4;

               Vector4[] array = new Vector4[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new Vector4( Single.Parse(values[i*4+0]), Single.Parse(values[i*4+1]), Single.Parse(values[i*4+2]), Single.Parse(values[i*4+3]) );
               }

               return array;
            }
            catch { return new Vector4[0]; }
         }

         if ( t == typeof(Rect[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );

               int num = (values.Length) / 4;

               Rect[] array = new Rect[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new Rect( Single.Parse(values[i*4+0]), Single.Parse(values[i*4+1]), Single.Parse(values[i*4+2]), Single.Parse(values[i*4+3]) );
               }

               return array;
            }
            catch { return new Rect[0]; }
         }

         if ( t == typeof(Quaternion[]).ToString() )
         {
            try
            {
               values = FlattenStringArrays( values, ',' );

               int num = (values.Length) / 4;

               Quaternion[] array = new Quaternion[ num ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = new Quaternion( Single.Parse(values[i*4+0]), Single.Parse(values[i*4+1]), Single.Parse(values[i*4+2]), Single.Parse(values[i*4+3]) );
               }

               return array;
            }
            catch { return new Quaternion[0]; }
         }

         if ( t == typeof(LayerMask[]).ToString() )
         {
            try
            {
               LayerMask[] array = new LayerMask[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = Int32.Parse(values[i]);
               }

               return array;
            }
            catch { return new LayerMask[0]; }
         }
         
         if ( t == typeof(String[]).ToString() )
         {
            try
            {
               String[] array = new String[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  array[ i ] = values[i];
               }
               
               return array;
            }
            catch { return new String[0]; }
         }

         if ( t == typeof(Resolution[]).ToString() )
         {
            return new Resolution[0];
         }

         System.Type eType = uScript.Instance.GetType(t.Replace("[]", ""));
   
         if (eType == null)
         {
            eType = uScriptUtils.GetAssemblyQualifiedType(this.Type);

            if (eType != null)
            {
               uScript.Instance.AddType(eType);
            }
         }
         
         if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
         {
            try
            {
               System.Enum[] array = new System.Enum[ values.Length ];

               for ( int i = 0; i < array.Length; i++ )
               {
                  try
                  {
                     array[ i ] = (System.Enum) System.Enum.Parse(eType, values[i]);
                  }
                  catch
                  {
                     array[ i ] = (System.Enum) System.Enum.Parse(eType, System.Enum.GetNames(eType)[0]);
                  }
               }

               return array;
            }
            catch 
            {
               return new System.Enum[0];
            }
         }

         return values;
      }

      public string ArrayToString(string t, object values)
      {
         string result = "";

         if ( t == typeof(bool[]).ToString() )
         {
            try
            {
               bool [] array = (bool[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( bool a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }

         if ( t == typeof(GUILayoutOption[]).ToString() )
         {
            try
            {
               GUILayoutOption[] array = (GUILayoutOption[]) values;
               if (array.Length > 0) result = Parameter.ArrayDelimeter.ToString();

               foreach (GUILayoutOption a in array)
               {
                  int optionIndex, optionValue;
                  Property.DeconstructGUILayoutOption(a, out optionIndex, out optionValue);
                  string optionDisplayName = Property.GUILayoutOptionDisplayNames[optionIndex];

                  if (optionDisplayName == "ExpandWidth" || optionDisplayName == "ExpandHeight")
                  {
                     result += optionDisplayName + ":" + (optionValue != 0 ? "true" : "false") + Parameter.ArrayDelimeter;
                  }
                  else
                  {
                     result += optionDisplayName + ":" + optionValue.ToString() + Parameter.ArrayDelimeter;
                  }
               }

               if (result.Length > 0) result = result.Substring(0, result.Length - 1);

               return result;
            }
            catch { return ""; }
         }

         if ( t == typeof(UnityEngine.Color[]).ToString() )
         {
            try
            {
               UnityEngine.Color [] array = (UnityEngine.Color[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( UnityEngine.Color a in array )
               {
                  result += a.r + "," + a.g + "," + a.b + "," + a.a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(float[]).ToString() )
         {
            try
            {
               float [] array = (float[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( float a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(int[]).ToString() )
         {
            try
            {
               int [] array = (int[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( int a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );
               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(UnityEngine.Vector2[]).ToString() )
         {
            try
            {
               Vector2 [] array = (Vector2[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( Vector2 a in array )
               {
                  result += a.x + "," + a.y + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(UnityEngine.Vector3[]).ToString() )
         {
            try
            {
               Vector3 [] array = (Vector3[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( Vector3 a in array )
               {
                  result += a.x + "," + a.y + "," + a.z + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(Vector4[]).ToString() )
         {
            try
            {
               Vector4 [] array = (Vector4[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( Vector4 a in array )
               {
                  result += a.x + "," + a.y + "," + a.z + "," + a.w + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(Rect[]).ToString() )
         {
            try
            {
               Rect [] array = (Rect[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( Rect a in array )
               {
                  result += a.x + "," + a.y + "," + a.width + "," + a.height + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(Quaternion[]).ToString() )
         {
            try
            {
               Quaternion [] array = (Quaternion[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( Quaternion a in array )
               {
                  result += a.x + "," + a.y + "," + a.z + "," + a.w + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(LayerMask[]).ToString() )
         {
            try
            {
               LayerMask [] array = (LayerMask[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( LayerMask a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if ( t == typeof(String[]).ToString() )
         {
            try
            {
               string [] array = (string[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( string a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );
               return result;
            }
            catch { return ""; }
         }

         System.Type eType = uScript.Instance.GetType(t.Replace("[]", ""));

         if (eType == null)
         {
            eType = uScriptUtils.GetAssemblyQualifiedType(this.Type);
            if (eType != null)
            {
               uScript.Instance.AddType(eType);
            }
         }
         
         if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
         {
            try
            {
               object [] array = (object[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( object a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );

               return result;
            }
            catch { return ""; }
         }
         if (t == typeof(Resolution[]).ToString() )
         {
            return "";
         }

         if ( t == typeof(object[]).ToString() )
         {
            try
            {
               object [] array = (object[]) values;
               if ( array.Length > 0 ) result = Parameter.ArrayDelimeter.ToString( );

               foreach ( object a in array )
               {
                  result += a + "" + Parameter.ArrayDelimeter;
               }

               if ( result.Length > 0 ) result = result.Substring( 0, result.Length - 1 );
               return result;
            }
            catch { return ""; }
         }


         return values.ToString( );
      }

      public object DefaultAsKnownObject
      {
         get
         {
            if ( Type.Contains("[]") )
            {
               return ParseArray( Type, Default );
            }

            if ( Type == typeof(bool).ToString( ) )
            {
               return "true" == Default;
            }

            if ( Type == typeof(GUILayoutOption).ToString() )
            {
               try
               {
                  string[] tokens = Default.Split(':');
                  int value = (tokens[1] == "true" ? 1 : (tokens[1] == "false" ? 0 : int.Parse(tokens[1])));

                  switch (tokens[0])
                  {
                     case "Width": return GUILayout.Width(value);
                     case "Height": return GUILayout.Height(value);
                     case "MinWidth": return GUILayout.MinWidth(value);
                     case "MaxWidth": return GUILayout.MaxWidth(value);
                     case "MinHeight": return GUILayout.MinHeight(value);
                     case "MaxHeight": return GUILayout.MaxHeight(value);
                     case "ExpandWidth": return GUILayout.ExpandWidth(value != 0);
                     case "ExpandHeight": return GUILayout.ExpandHeight(value != 0);
                     default:
                        uScriptDebug.Log("Unknown GUILayoutOption.Type value: \"" + tokens[0] + "\"\n", uScriptDebug.Type.Error);
                        break;
                  }
               }
               catch
               {
                  return GUILayout.Width(0);
               }
            }

            if ( Type == typeof(UnityEngine.Color).ToString( ) )
            {
               try
               {
                  string[] values = Default.Split( ',' );
                  return new UnityEngine.Color( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 1 );
               }
               catch 
               {
                  return new UnityEngine.Color(0, 0, 0);
               }
            }

            if ( Type == typeof(float).ToString( )  )
            {
               try
               {
                  return Single.Parse(Default);
               }
               catch 
               {
                  return 0.0f;
               }
            }

            if ( Type == typeof(int).ToString( )  )
            {
               try
               {
                  return Int32.Parse(Default);
               }
               catch 
               {
                  return 0.0f;
               }
            }

            if ( Type == typeof(Vector2).ToString( )  )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector2( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0 );
               }
               catch 
               {
                  return new Vector2(0, 0);
               }
            }

            if ( Type == typeof(Vector3).ToString( )  )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector3( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, values.Length > 2 ? Single.Parse(values[2]) : 0 );
               }
               catch 
               {
                  return new Vector3(0, 0, 0);
               }
            }

            if ( Type == typeof(Vector4).ToString( )  )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector4( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Vector4(0, 0, 0, 0);
               }
            }

            if ( Type == typeof(Rect).ToString( )  )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Rect( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Rect(0, 0, 0, 0);
               }
            }

            if ( Type == typeof(Quaternion).ToString( )  )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Quaternion( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Quaternion(0, 0, 0, 0);
               }
            }

            if ( Type == typeof(LayerMask).ToString( )  )
            {
               try
               {
                  return (UnityEngine.LayerMask)Int32.Parse(Default);
               }
               catch
               {
                  return (UnityEngine.LayerMask)0;
               }
            }

            if ( Type == typeof(String).ToString( ) )
            {
               return Default;
            }
           
            System.Type eType = uScript.Instance.GetType(this.Type);
   
            if (eType == null)
            {
               eType = uScriptUtils.GetAssemblyQualifiedType(this.Type);
               if (eType != null)
               {
                  uScript.Instance.AddType(eType);
               }
            }
            
            if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
            {
               try
               {
                  return System.Enum.Parse(eType, Default);
               }
               catch 
               {
                  return System.Enum.Parse(eType, System.Enum.GetNames(eType)[0]);
               }
            }

            return null;
         }
      }

      public object DefaultAsObject
      {
         //hardcoded mappings to/from property grid types
         //this should be stored in a mapping file
         get 
         { 
            object v = DefaultAsKnownObject;
            //if we don't know it then just return it as a string
            if ( null == v ) v = Default;

            return v;
         }
         set
         {
            if (null == value)
            {
               Default = "";
               return;
            }

            if ( Type.Contains("[]") )
            {
               Default = ArrayToString( Type, value );
               return;
            }

            if ( Type == typeof(bool).ToString( ) )  
            {
               try
               {
                  Default = ((bool)value) == true ? "true" : "false";
               }
               catch (Exception)
               {
                  Default = "false";
               }
               return;
            }

            if ( Type == typeof(float).ToString( )  )
            {
               Default = "" + value;
               return;
            }

            if ( Type == typeof(int).ToString( ) )
            {
               Default = "" + value;
               return;
            }

            if ( Type == typeof(Vector2).ToString( )  )
            {
               try
               {
                  Vector2 v = (Vector2) value;
                  Default = v.x + "," + v.y;
               }
               catch ( Exception )
               {
                  Default = "0,0";
               }
               return;
            }

            if ( Type == typeof(Vector3).ToString( )  )
            {
               try
               {
                  Vector3 v = (Vector3) value;
                  Default = v.x + "," + v.y + "," + v.z;
               }
               catch ( Exception )
               {
                  Default = "0,0,0";
               }
               return;
            }

            if ( Type == typeof(Vector4).ToString( )  )
            {
               try
               {
                  Vector4 v = (Vector4) value;
                  Default = v.x + "," + v.y + "," + v.z + "," + v.w;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }

            if ( Type == typeof(Rect).ToString( )  )
            {
               try
               {
                  Rect v = (Rect) value;
                  Default = v.x + "," + v.y + "," + v.width + "," + v.height;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }
            
            if ( Type == typeof(Quaternion).ToString( )  )
            {
               try
               {
                  Quaternion v = (Quaternion) value;
                  Default = v.x + "," + v.y + "," + v.z + "," + v.w;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }

            if ( Type == typeof(GUILayoutOption).ToString() )
            {
               try
               {
                  GUILayoutOption option = (GUILayoutOption)value;

                  string optionEnumName = string.Empty;
                  int optionValue = 0;

                  FieldInfo[] fields = option.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                  foreach (FieldInfo field in fields)
                  {
                     if (field.Name == "type")
                     {
                        optionEnumName = field.GetValue(option).ToString();
                     }
                     else if (field.Name == "value")
                     {
                        optionValue = Convert.ToInt32(field.GetValue(option));
                     }
                  }

                  int optionEnumIndex = Array.IndexOf(Property.GUILayoutOptionEnumNames, optionEnumName);
                  if (optionEnumIndex == -1)
                  {
                     throw new System.MissingMemberException("Unable to identify the GUILayoutOption type member");
                  }

                  if (optionEnumName == "stretchWidth" || optionEnumName == "stretchHeight")
                  {
                     Default = Property.GUILayoutOptionDisplayNames[optionEnumIndex] + ":" + (optionValue != 0 ? "true" : "false");
                  }
                  else
                  {
                     Default = Property.GUILayoutOptionDisplayNames[optionEnumIndex] + ":" + optionValue.ToString();
                  }
               }
               catch
               {
                  Default = "Width:0";
               }
               return;
            }

            if ( Type == typeof(UnityEngine.Color).ToString( ) )
            {
               try
               {
                  UnityEngine.Color v = (UnityEngine.Color) value;
                  Default = v.r + "," + v.g + "," + v.b + "," + v.a;
               }
               catch ( Exception )
               {
                  Default = "0,0,0";
               }
               return;
            }

            if ( Type == typeof(String).ToString( )  )
            {
               Default = value.ToString( );
               return;
            }

            System.Type eType = uScript.Instance.GetType(this.Type);
            if (eType == null)
            {
               eType = uScriptUtils.GetAssemblyQualifiedType(this.Type);
               if (eType != null)
               {
                  uScript.Instance.AddType(eType);
               }
            }
            
            if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
            {
               Default = value.ToString();
               return;
            }

            // should never get here...
            Default = value.ToString( );
            return;
         }
      }
      
      public override int GetHashCode( )
      {
         return base.GetHashCode( );
      }

      public override bool Equals(object o)
      {
         if ( false == (o is Parameter) ) return false;
         
         return (((Parameter)o) == this);
      }

      public static bool operator == (Parameter a, Parameter b)
      {
         if ( a.Output != b.Output  ) return false; 
         if ( a.Input  != b.Input   ) return false; 
         if ( a.Name   != b.Name    ) return false; 
         if ( a.Type   != b.Type    ) return false; 
         if ( a.Default!= b.Default ) return false; 
         if ( a.State  != b.State   ) return false;
         if ( a.ReferenceGuid != b.ReferenceGuid ) return false;
         if ( a.FriendlyName != b.FriendlyName )   return false; 
         
         return true;
      }

      public static bool operator != (Parameter a, Parameter b)
      {
         return ! (a == b);
      }

      public bool IsCompatibleWith(Parameter p)
      {
         if ( Output != p.Output  ) return false; 
         if ( Input  != p.Input   ) return false; 
         if ( Name   != p.Name    ) return false; 
         if ( Type   != p.Type    ) return false; 

         return true;
      }

      public Detox.Data.ScriptEditor.Parameter ToParameterData( )
      {
         Detox.Data.ScriptEditor.Parameter data = new Detox.Data.ScriptEditor.Parameter( );

         data.Output  = Output;
         data.Input   = Input;
         data.Default = Default;
         data.Name    = Name;
         data.Type    = Type;
         data.State   = State != 0 ? (Detox.Data.ScriptEditor.Parameter.VisibleState) (int) State : Detox.Data.ScriptEditor.Parameter.VisibleState.Visible;
         data.ReferenceGuid = ReferenceGuid;
         data.FriendlyName  = FriendlyName;

         return data;
      }

      public Parameter( Detox.Data.ScriptEditor.Parameter parameterData )
      {
         Output  = parameterData.Output;
         Input   = parameterData.Input;
         Default = parameterData.Default;
         Name    = parameterData.Name;
         Type    = parameterData.Type;
         State   = parameterData.State != 0 ? (Parameter.VisibleState) parameterData.State : Parameter.VisibleState.Visible;
         ReferenceGuid = parameterData.ReferenceGuid;
         FriendlyName  = parameterData.FriendlyName;
         
         // This will get overridden by the newly reflected node 
         // so it doesn't need to be saved/loaded
         AutoLinkType = parameterData.Type;
      }
   }

   public interface EntityNode
   {
      Guid Guid { get; set; }
      Point Position { get; set; }
      EntityNodeData NodeData { get; } 
      Parameter[] Parameters { get; set; }

      Parameter ShowComment { get; set; }
      Parameter Comment { get; set; }
      Parameter Instance { get; set; }
      bool IsStatic { get; }

      EntityNode Copy( bool preserveGuid );
   }

   public struct EntityDesc
   {
      public EntityMethod   [] Methods;
      public EntityEvent    [] Events;
      public EntityProperty [] Properties;
      public string Type;
   }

   class ArrayUtil
   {
      static public Parameter[] CopyCompatibleParameters(Parameter []reflectedParameters, Parameter []savedParameters)
      {
         List<Parameter> parameters = new List<Parameter>( );

         foreach ( Parameter reflectedParameter in reflectedParameters )
         {
            bool found = false;

            foreach ( Parameter savedParameter in savedParameters )
            {
               if ( true == reflectedParameter.IsCompatibleWith(savedParameter) )
               {
                  Parameter clone = reflectedParameter;
                  
                  clone.Default       = savedParameter.Default;
                  clone.State         = savedParameter.State;
                  clone.ReferenceGuid = savedParameter.ReferenceGuid;

                  parameters.Add( clone );                  
                  found = true;

                  break;
               }
            }

            //can't find a matching default
            //then use the blank one
            if ( false == found )
            {               
               parameters.Add( reflectedParameter );
            }
         }

         return parameters.ToArray( );
      }
      
      static public bool ParametersAreCompatible(Parameter []a, Parameter []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( false == a[i].IsCompatibleWith(b[i]) ) return false;
         }

         return true;
      }

      static public bool ArraysAreEqual(string []a, string []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false; 
         }

         return true;
      }

      static public bool ArraysAreEqual(Parameter []a, Parameter []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false;
         }

         return true;
      }

      static public bool ArraysAreEqual(Plug []a, Plug []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false;
         }

         return true;
      }

      static public Detox.Data.ScriptEditor.Parameter []ToParameterDatas(Parameter []p)
      {
         List<Detox.Data.ScriptEditor.Parameter> data = new List<Detox.Data.ScriptEditor.Parameter>( );

         foreach ( Parameter parameter in p )
         {
            data.Add( parameter.ToParameterData( ) );
         }

         return data.ToArray( );
      }

      static public Parameter []ToParameters(Detox.Data.ScriptEditor.Parameter []p)
      {
         List<Parameter> parameters = new List<Parameter>( );

         foreach ( Detox.Data.ScriptEditor.Parameter data in p )
         {
            parameters.Add( new Parameter(data) );
         }

         return parameters.ToArray( );
      }

      static public Detox.Data.ScriptEditor.Plug []ToPlugDatas(Plug []p)
      {
         List<Detox.Data.ScriptEditor.Plug> data = new List<Detox.Data.ScriptEditor.Plug>( );

         foreach ( Plug plug in p )
         {
            data.Add( plug.ToPlugData( ) );
         }

         return data.ToArray( );
      }

      static public Plug []ToPlugs(Detox.Data.ScriptEditor.Plug []p)
      {
         List<Plug> plugs = new List<Plug>( );

         foreach ( Detox.Data.ScriptEditor.Plug data in p )
         {
            plugs.Add( new Plug(data) );
         }

         return plugs.ToArray( );
      }
   }

   public struct LinkNode : EntityNode
   {
      public struct Connection
      {
         public Guid   Guid;
         public string Anchor;
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LinkNode) ) return false;

         LinkNode node = (LinkNode) obj;

         if ( Source.Anchor != node.Source.Anchor ) return false;
         if ( Source.Guid   != node.Source.Guid )   return false;

         if ( Destination.Anchor != node.Destination.Anchor ) return false;
         if ( Destination.Guid   != node.Destination.Guid )   return false;

         if ( Guid != node.Guid ) return false;

         return true;
      }

      public bool IsStatic { get { return false; } }

      public Parameter Instance { get { return Parameter.Empty; } set {} }
      public Parameter[] Parameters { get { return new Parameter[ 0 ]; } set { } }

      public EntityNode Copy( bool preserveGuid )
      {
         LinkNode linkNode   = new LinkNode( );
         linkNode.Source     = Source;
         linkNode.Destination= Destination;
         linkNode.Guid       = preserveGuid ? Guid : Guid.NewGuid( );

         return linkNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LinkNodeData nodeData = new LinkNodeData( );
            nodeData.Guid     = m_Guid;
            nodeData.Source.Guid   = Source.Guid;
            nodeData.Source.Anchor = Source.Anchor;
            nodeData.Destination.Guid   = Destination.Guid;
            nodeData.Destination.Anchor = Destination.Anchor;

            return nodeData;
         }
      }


      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public Connection Source;
      public Connection Destination;

      public Point Position { get { throw new Exception("Link has no position"); } set { throw new Exception("Link has no position"); } }

      public LinkNode(Guid source, string sourceAnchor, Guid dest, string destAnchor )
      {
         m_Guid = Guid.NewGuid( );
 
         Source.Guid   = source;
         Source.Anchor = sourceAnchor;

         Destination.Guid  = dest;
         Destination.Anchor= destAnchor;
      }

      public LinkNode(LinkNodeData data)
      {
         m_Guid = data.Guid;
         Source.Guid   = data.Source.Guid;
         Source.Anchor = data.Source.Anchor;
         Destination.Guid   = data.Destination.Guid;
         Destination.Anchor = data.Destination.Anchor;
      }
   }

   public struct ExternalConnection : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         ExternalConnection connection = new ExternalConnection( );
         connection.Connection     = Connection;
         connection.Position       = Position;
         connection.Guid           = preserveGuid ? Guid : Guid.NewGuid( );
         connection.Name           = Name;
         connection.ShowComment    = ShowComment;
         connection.Comment        = Comment;
         connection.Description    = Description;
         connection.Order          = Order;

         return connection;
      }
   
      public EntityNodeData NodeData
      {
         get
         {
            ExternalConnectionData nodeData = new ExternalConnectionData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Name       = Name.ToParameterData( );
            nodeData.Guid       = Guid;
            nodeData.ShowComment= ShowComment.ToParameterData( );
            nodeData.Comment    = Comment.ToParameterData( );
            nodeData.Description= Description.ToParameterData( );
            nodeData.Order      = Order.ToParameterData( );
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(ExternalConnection) ) return false;

         ExternalConnection node = (ExternalConnection) obj;

         if ( Connection    != node.Connection    ) return false;
         if ( Guid          != node.Guid )          return false;
         if ( Position      != node.Position )      return false;

         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         return true;
      }
      
      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter Name;
      public Parameter Order;
      public Parameter Description;

      public Parameter[] Parameters 
      { 
         get { return new Parameter[] { Name, Order, Description }; } 
         set { Name = value[ 0 ]; Order = value[ 1 ]; Description = value[ 2 ]; }
      }
      
      public string Connection;

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      public bool IsStatic { get { return false; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public ExternalConnection( Guid guid )
      {
         m_Guid = guid;
         m_Position = Point.Empty;
         Connection = "Connection";

         Name = new Parameter( );
         Name.Name    = "Name";
         Name.FriendlyName = "Name";
         Name.Default = "";
         Name.Type    = typeof(String).ToString( );
         Name.Input   = true;
         Name.Output  = false;
         Name.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         Name.AutoLinkType = Name.Type;

         Order = new Parameter( );
         Order.Name    = "Order";
         Order.FriendlyName = "Order";
         Order.Default = "-1";
         Order.Type    = typeof(int).ToString( );
         Order.Input   = true;
         Order.Output  = false;
         Order.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         Order.AutoLinkType = Order.Type;

         Description = new Parameter( );
         Description.Name    = "Description";
         Description.FriendlyName = "Description";
         Description.Default = "";
         Description.Type    = typeof(string).ToString( );
         Description.Input   = true;
         Description.Output  = false;
         Description.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         Description.AutoLinkType = Description.Type;

         m_ShowComment = new Parameter( );
         m_ShowComment.Name         = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = typeof(bool).ToString( );
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_ShowComment.AutoLinkType = m_ShowComment.Type;

         m_Comment = new Parameter( );
         m_Comment.Name          = "Comment";
         m_Comment.FriendlyName  = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = typeof(String).ToString( );
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Comment.AutoLinkType = m_Comment.Type;
      }
   }

   public struct OwnerConnection : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         OwnerConnection connection = new OwnerConnection( );
         connection.Connection     = Connection;
         connection.Position       = Position;
         connection.Guid           = preserveGuid ? Guid : Guid.NewGuid( );
         connection.ShowComment    = ShowComment;
         connection.Comment        = Comment;

         return connection;
      }
   
      public EntityNodeData NodeData
      {
         get
         {
            OwnerConnectionData nodeData = new OwnerConnectionData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;
            nodeData.ShowComment= ShowComment.ToParameterData( );
            nodeData.Comment    = Comment.ToParameterData( );
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(OwnerConnection) ) return false;

         OwnerConnection node = (OwnerConnection) obj;

         if ( Connection    != node.Connection    ) return false;
         if ( Guid          != node.Guid )          return false;
         if ( Position      != node.Position )      return false;
         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         return true;
      }
      
      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter Connection;

      public bool IsStatic { get { return false; } }

      public Parameter[] Parameters 
      { 
         get { return new Parameter[1] { Connection }; } 
         set { }
      }
      
      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public OwnerConnection( Guid guid )
      {
         m_Guid = guid;
         m_Position = Point.Empty;
      
         m_ShowComment = new Parameter( );
         m_ShowComment.Name         = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = typeof(bool).ToString( );
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;;

         m_Comment = new Parameter( );
         m_Comment.Name          = "Comment";
         m_Comment.FriendlyName  = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = typeof(String).ToString( );
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;;

         Connection = new Parameter( );
         Connection.Name = "Connection";
         Connection.FriendlyName = "Connection";
         Connection.Default = "";
         Connection.State  = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         Connection.Input  = false;
         Connection.Output = true;
         Connection.Type   = typeof(UnityEngine.GameObject).ToString( );
      }
   }
   
   public struct EntityMethod : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         EntityMethod method = new EntityMethod( );
         method.Instance  = Instance;
         method.Parameters= Parameters;
         method.Input     = Input;
         method.Output    = Output;
         method.Position  = Position;
         method.IsStatic  = IsStatic;
         method.Guid      = preserveGuid ? Guid : Guid.NewGuid( );
         method.ComponentType = ComponentType;
         return method;
      }

      public EntityNodeData NodeData 
      { 
         get
         {
            EntityMethodData nodeData = new EntityMethodData( );
            nodeData.Instance      = Instance.ToParameterData( );
            nodeData.ComponentType = ComponentType;
            nodeData.Input     = Input.ToPlugData( );
            nodeData.Output    = Output.ToPlugData( );
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.IsStatic  = IsStatic;
            nodeData.Guid      = Guid;
            nodeData.Parameters  = ArrayUtil.ToParameterDatas( Parameters );

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityMethod) ) return false;

         EntityMethod node = (EntityMethod) obj;

         if ( Instance != node.Instance ) return false;
         if ( ComponentType != node.ComponentType ) return false;
         
         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;

         if ( Input  != node.Input ) return false;
         if ( Output != node.Output ) return false;
         if ( Guid   != node.Guid ) return false;
         if ( IsStatic != node.IsStatic ) return false;
         if ( Position != node.Position ) return false;
         if ( Comment != node.Comment ) return false;
         if ( ShowComment != node.ShowComment ) return false;
         return true;
      }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      private bool m_IsStatic;
      public bool IsStatic
      {
         get { return m_IsStatic; }
         set
         {
            m_IsStatic = value;
            m_Instance.Input = false == value;
         }
      }


      public Plug Input;
      public Plug Output;

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      private Parameter[] m_Parameters;
      public Parameter[] Parameters { get { return (Parameter[]) m_Parameters.Clone( ); } set { m_Parameters = (Parameter[]) value.Clone( ); } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public string ComponentType;

      public EntityMethod(string componentType, string name, string friendlyName)       
      { 
         ComponentType = componentType;

         m_Instance.Default = "";
         m_Instance.ReferenceGuid = "";
         m_Instance.Type   = typeof(UnityEngine.GameObject).ToString( );
         m_Instance.Input  = true;
         m_Instance.Output = false;
         m_Instance.State  = Parameter.VisibleState.Visible;
         m_Instance.Name         = "Instance";
         m_Instance.FriendlyName = "Instance";
         m_Instance.AutoLinkType = m_Instance.Type;

         m_ShowComment = new Parameter( );
         m_ShowComment.ReferenceGuid = "";
         m_ShowComment.Name         = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = typeof(bool).ToString( );
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.AutoLinkType = m_ShowComment.Type;

         m_Comment = new Parameter( );
         m_Comment.ReferenceGuid = "";
         m_Comment.Name          = "Comment";
         m_Comment.FriendlyName  = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = typeof(String).ToString( );
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Comment.AutoLinkType = m_Comment.Type;

         m_Guid = Guid.NewGuid( );

         Input.Name = name;
         Input.FriendlyName = name;

         Output.Name = "Output";
         Output.FriendlyName = "Output";

         m_Position   = Point.Empty; 
         m_Parameters = new Parameter[ 0 ];
         m_IsStatic   = false;
      }

      public EntityMethod(EntityMethodData data)       
      { 
         ComponentType = data.ComponentType;

         m_Instance    = new Parameter( data.Instance );
         m_ShowComment = new Parameter( data.ShowComment );
         m_Comment     = new Parameter( data.Comment );

         m_Guid = data.Guid;

         Input  = new Plug( data.Input );
         Output = new Plug( data.Output );

         m_Position   = data.Position; 
         m_Parameters = ArrayUtil.ToParameters( data.Parameters );
         m_IsStatic   = data.IsStatic;
      }
   }

   public struct CommentNode : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         CommentNode commentNode = new CommentNode( );
         commentNode.Parameters = Parameters;
         commentNode.Position   = Position;
         commentNode.Guid       = preserveGuid ? Guid : Guid.NewGuid( );

         commentNode.NodeColor      = NodeColor;
         commentNode.TitleTextColor = TitleTextColor;
         commentNode.BodyTextColor  = BodyTextColor;
 
         return commentNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            CommentNodeData nodeData = new CommentNodeData( );
            nodeData.BodyText       = BodyText.ToParameterData( );
            nodeData.BodyTextColor  = BodyTextColor.ToParameterData( );
            nodeData.TitleText      = TitleText.ToParameterData( );
            nodeData.TitleTextColor = TitleTextColor.ToParameterData( );
            nodeData.NodeColor      = NodeColor.ToParameterData( );
            nodeData.Width      = Width.ToParameterData( );
            nodeData.Height     = Height.ToParameterData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;
         
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(CommentNode) ) return false;

         CommentNode node = (CommentNode) obj;

         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;
         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         return true;
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      private Parameter m_BodyText;
      private Parameter m_BodyTextColor;
      private Parameter m_TitleText;
      private Parameter m_TitleTextColor;
      private Parameter m_NodeColor;
      private Parameter m_Width;
      private Parameter m_Height;

      public bool IsStatic { get { return false; } }

      public Parameter[] Parameters 
      { 
         get { return new Parameter[] { m_TitleText, m_BodyText, m_Width, m_Height, m_NodeColor, m_BodyTextColor}; } 
         set { m_TitleText = value[ 0 ]; m_BodyText = value[ 1 ]; m_Width = value[ 2 ]; m_Height = value[ 3 ]; m_NodeColor = value[4]; m_BodyTextColor = value[5];} 
      }
      
      public Parameter BodyText       { get { return m_BodyText; } set { m_BodyText = value; } }
      public Parameter BodyTextColor  { get { return m_BodyTextColor; } set { m_BodyTextColor = value; } }
      public Parameter TitleText      { get { return m_TitleText; } set { m_TitleText = value; } }
      public Parameter TitleTextColor { get { return m_TitleTextColor; } set { m_TitleTextColor = value; } }
      public Parameter NodeColor      { get { return m_NodeColor; } set { m_NodeColor= value; } }

      public Parameter Width { get { return m_Width; } set { m_Width = value; } }
      public Parameter Height { get { return m_Height; } set { m_Height = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public CommentNode(string titleText)
      { 
         m_Position = Point.Empty;
         m_Guid     = Guid.NewGuid( );

         m_TitleText = new Parameter( );
         m_TitleText.State = Parameter.VisibleState.Visible;
         m_TitleText.Name = "Title";
         m_TitleText.FriendlyName = "Title";
         m_TitleText.Default = "Comment";
         m_TitleText.Type = typeof(String).ToString( );
         m_TitleText.Input = true;
         m_TitleText.Output = false;
         m_TitleText.AutoLinkType = m_TitleText.Type;

         m_TitleTextColor = new Parameter( );
         m_TitleTextColor.State = Parameter.VisibleState.Visible;
         m_TitleTextColor.Name = "TitleColor";
         m_TitleTextColor.FriendlyName = "Title Color";
         m_TitleTextColor.Default = ".2, .2, .5";
         m_TitleTextColor.Type = typeof(UnityEngine.Color).ToString( );
         m_TitleTextColor.Input = true;
         m_TitleTextColor.Output = false;
         m_TitleTextColor.AutoLinkType = m_TitleTextColor.Type;

         m_BodyText = new Parameter( );
         m_BodyText.State = Parameter.VisibleState.Visible;
         m_BodyText.Name = "Body";
         m_BodyText.FriendlyName = "Body";
         m_BodyText.Default = "";
         m_BodyText.Type = "TextArea";
         m_BodyText.Input = true;
         m_BodyText.Output = false;
         m_BodyText.AutoLinkType = m_BodyText.Type;

         m_BodyTextColor = new Parameter( );
         m_BodyTextColor.State = Parameter.VisibleState.Visible;
         m_BodyTextColor.Name = "BodyColor";
         m_BodyTextColor.FriendlyName = "Body Text Color";
         m_BodyTextColor.Default = "1.0, 1.0, 1.0";
         m_BodyTextColor.Type = typeof(UnityEngine.Color).ToString( );
         m_BodyTextColor.Input = true;
         m_BodyTextColor.Output = false;
         m_BodyTextColor.AutoLinkType = m_BodyTextColor.Type;

         m_NodeColor = new Parameter( );
         m_NodeColor.State = Parameter.VisibleState.Visible;
         m_NodeColor.Name = "NodeColor";
         m_NodeColor.FriendlyName = "Node Color";
         m_NodeColor.Default = "1.0, 1.0, 1.0";
         m_NodeColor.Type = typeof(UnityEngine.Color).ToString( );
         m_NodeColor.Input = true;
         m_NodeColor.Output = false;
         m_NodeColor.AutoLinkType = m_NodeColor.Type;

         m_Width.Name  = "Width";
         m_Width.State = Parameter.VisibleState.Visible;
         m_Width.FriendlyName = "Width";
         m_Width.Type  = typeof(int).ToString( );
         m_Width.ReferenceGuid = "";
         m_Width.Input = true;
         m_Width.Output= false;
         m_Width.Default = "0";
         m_Width.AutoLinkType = m_Width.Type;

         m_Height.Name  = "Height";
         m_Height.ReferenceGuid = "";
         m_Height.State = Parameter.VisibleState.Visible;
         m_Height.FriendlyName = "Height";
         m_Height.Type  = typeof(int).ToString( );
         m_Height.Input = true;
         m_Height.Output= false;
         m_Height.Default = "0";
         m_Height.AutoLinkType = m_Height.Type;
      }
   }

   public struct EntityEvent : EntityNode
   {
      //assumes the caller knows the parameters match up
      //and the entities should be consolidated
      public static EntityEvent Consolidator(EntityEvent []events)
      {
         EntityEvent consolidatedEvent = events[ 0 ];

         List<Plug> outputs = new List<Plug>( );

         foreach ( EntityEvent entityEvent in events )
         {
            foreach ( Plug output in entityEvent.Outputs )
            {
               outputs.Add( output );
            }
         }

         consolidatedEvent.Outputs = outputs.ToArray( );

         return consolidatedEvent;
      }

      public EntityNode Copy( bool preserveGuid )
      {
         EntityEvent entityEvent   = new EntityEvent( );
         entityEvent.Instance      = Instance;
         entityEvent.EventArgs     = EventArgs;
         entityEvent.Parameters    = Parameters;
         entityEvent.Position      = Position;
         entityEvent.FriendlyType  = FriendlyType;
         entityEvent.ComponentType = ComponentType;
         entityEvent.Outputs       = Outputs;
         entityEvent.Guid          = preserveGuid ? Guid : Guid.NewGuid( );
         entityEvent.Comment       = Comment;
         entityEvent.ShowComment   = ShowComment;
         entityEvent.IsStatic      = IsStatic;
      
         return entityEvent;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            EntityEventData nodeData = new EntityEventData( );
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.EventArgs = EventArgs;
            nodeData.Instance  = Instance.ToParameterData( );
            nodeData.Outputs   = ArrayUtil.ToPlugDatas( Outputs );
            nodeData.Guid      = Guid;
            nodeData.Parameters= ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Comment       = Comment.ToParameterData( );
            nodeData.ShowComment   = ShowComment.ToParameterData( );
            nodeData.ComponentType = ComponentType;

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }
         
      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityEvent) ) return false;

         EntityEvent node = (EntityEvent) obj;

         if ( Instance != node.Instance ) return false;

         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;

         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         if ( false == ArrayUtil.ArraysAreEqual(Outputs, node.Outputs) ) return false;

         if ( ShowComment != node.ShowComment ) return false;
         if ( Comment != node.Comment ) return false;

         if ( IsStatic != node.IsStatic ) return false;

         if ( ComponentType != node.ComponentType ) return false;

         return true;
      }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public string EventArgs;
      public string FriendlyType;

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      public Plug []Outputs;
      
      private Parameter[] m_Parameters;
      public Parameter[] Parameters { get { return (Parameter[]) m_Parameters.Clone( ); } set { m_Parameters = (Parameter[]) value.Clone( ); } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private bool m_IsStatic;
      public bool IsStatic
      {
         get { return m_IsStatic; }
         set
         {
            m_IsStatic = value;
            m_Instance.Input = false == value;
         }
      }

      public string ComponentType;

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public EntityEvent(string componentType, string friendlyType, Plug [] outputs)
      { 
         Outputs = outputs;

         FriendlyType  = friendlyType;
         ComponentType = componentType;

         m_Instance.Name            = "Instance";
         m_Instance.ReferenceGuid   = "";
         m_Instance.State           = Parameter.VisibleState.Visible;
         m_Instance.FriendlyName    = "Instance";
         m_Instance.Type            = typeof(UnityEngine.GameObject).ToString( );
         m_Instance.Input           = true;
         m_Instance.Output          = false;
         m_Instance.Default         = "";
         m_Instance.AutoLinkType    = m_Instance.Type;

         m_Guid = Guid.NewGuid( );
         
         m_Position = Point.Empty; 
         m_Parameters  = new Parameter[ 0 ];

         m_ShowComment              = new Parameter( );
         m_ShowComment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_ShowComment.Name         = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default      = "false";
         m_ShowComment.Type         = typeof(bool).ToString( );
         m_ShowComment.Input        = true;
         m_ShowComment.Output       = false;
         m_ShowComment.AutoLinkType = m_ShowComment.Type;

         m_Comment                  = new Parameter( );
         m_Comment.State            = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Comment.Name             = "Comment";
         m_Comment.FriendlyName     = "Comment";
         m_Comment.Default          = "";
         m_Comment.Type             = typeof(String).ToString( );
         m_Comment.Input            = true;
         m_Comment.Output           = false;
         m_Comment.AutoLinkType     = m_Comment.Type;

         EventArgs = "System.EventArgs";
         m_IsStatic= false;
      }

      public EntityEvent(EntityEventData data)
      { 
         Outputs = ArrayUtil.ToPlugs( data.Outputs );

         FriendlyType  = data.ComponentType;
         ComponentType = data.ComponentType;

         m_Guid     = data.Guid; 
         m_Position = data.Position; 

         m_Instance    = new Parameter( data.Instance );
         m_ShowComment = new Parameter( data.ShowComment );
         m_Comment     = new Parameter( data.Comment );
         m_Parameters  = ArrayUtil.ToParameters( data.Parameters );

         EventArgs = data.EventArgs;
         m_IsStatic= false;
      }
   }

   public struct LogicNode : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         LogicNode node = new LogicNode( );
         node.Type      = Type;
         node.FriendlyName = FriendlyName;
         node.Inputs    = Inputs;         
         node.Parameters= Parameters;        
         node.EventArgs = EventArgs;
         node.Outputs   = Outputs;
         node.Position  = Position;
         node.Events    = Events;
         node.Drivens   = Drivens;
         node.Guid      = preserveGuid ? Guid : Guid.NewGuid( );
         node.Comment    = Comment;
         node.InspectorName  = InspectorName;
         node.RequiredMethods= RequiredMethods;
         node.ShowComment    = ShowComment;
         node.EventParameters= EventParameters;
         node.IsNestedNode = IsNestedNode;

         return node;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LogicNodeData nodeData = new LogicNodeData( );
            nodeData.Type      = Type;
            nodeData.FriendlyName = FriendlyName;
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.Parameters= ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Inputs    = ArrayUtil.ToPlugDatas( Inputs );
            nodeData.Outputs   = ArrayUtil.ToPlugDatas( Outputs );
            nodeData.Events    = ArrayUtil.ToPlugDatas( Events );
            nodeData.Drivens   = Drivens;
            nodeData.Guid      = Guid;
            nodeData.InspectorName   = InspectorName.ToParameterData( );
            nodeData.Comment         = Comment.ToParameterData( );
            nodeData.ShowComment     = ShowComment.ToParameterData( );
            nodeData.RequiredMethods = RequiredMethods;
            nodeData.EventArgs       = EventArgs;
            nodeData.EventParameters = ArrayUtil.ToParameterDatas( EventParameters );

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LogicNode) ) return false;

         LogicNode node = (LogicNode) obj;

         if ( Type != node.Type ) return false;
         if ( FriendlyName != node.FriendlyName ) return false;
         
         if ( false == ArrayUtil.ArraysAreEqual(node.Inputs, Inputs) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Outputs, Outputs) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Events, Events) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Drivens, Drivens) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.EventParameters, EventParameters) ) return false;

         //don't compare required methods because these come straight from Unity
         //and are only saved so parent scripts can check nested ones 
         //without using reflection

         if ( EventArgs != node.EventArgs ) return false;
         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;
         if ( InspectorName != node.InspectorName ) return false;

         if ( ShowComment != node.ShowComment ) return false;
         if ( Comment != node.Comment ) return false;

         if ( IsNestedNode != node.IsNestedNode ) return false;

         return true;
      }

      public string      Type;
      public string      FriendlyName;
      public string      EventArgs;
      public Plug      []Inputs;
      public Plug      []Outputs;
      public Plug      []Events;
      public string    []Drivens;
      public Parameter []EventParameters;
      public bool        IsNestedNode;

      //used only if this logic node is wrapping
      //a nested script and that nested script
      //code has been deleted so we can't reflect the data
      public string  []RequiredMethods;

      public bool IsStatic { get { return false; } }

      private Parameter m_ShowComment;
      private Parameter m_Comment;
      private Parameter m_InspectorName;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter InspectorName
      {
         get { return m_InspectorName; }
         set { m_InspectorName = value; } 
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter[] m_Parameters;
      public Parameter[] Parameters { get { return (Parameter[]) m_Parameters.Clone( ); } set { m_Parameters = (Parameter[]) value.Clone( ); } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;

      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public LogicNode(string type, string friendlyName)       
      { 
         Type = type;
         FriendlyName = friendlyName;

         m_Guid = Guid.NewGuid( );

         RequiredMethods = new string[ 0 ];
         Drivens         = new string[ 0 ];
         Inputs          = new Plug[ 0 ];
         Outputs         = new Plug[ 0 ];
         Events          = new Plug[ 0 ];
         IsNestedNode    = false;
         m_Parameters    = new Parameter[ 0 ];

         EventArgs       = "System.EventArgs";
         EventParameters = new Parameter[ 0 ];

         m_Position = Point.Empty; 

         m_ShowComment = new Parameter( );
         m_ShowComment.Name         = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = typeof(bool).ToString( );
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_Comment = new Parameter( );
         m_Comment.Name          = "Comment";
         m_Comment.FriendlyName  = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = typeof(String).ToString( );
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_InspectorName = new Parameter( );
         m_InspectorName.Name         = "Inspector Name";
         m_InspectorName.FriendlyName = "Inspector Name";
         m_InspectorName.Type         = typeof(string).ToString( );
         m_InspectorName.Input        = true;
         m_InspectorName.Output       = false;
         m_InspectorName.Default      = "";
         m_InspectorName.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
      }

      public LogicNode(LogicNodeData data)       
      { 
         Type = data.Type; 
         FriendlyName = data.FriendlyName;
         IsNestedNode = false;
         RequiredMethods = data.RequiredMethods;

         m_Guid = data.Guid;

         Drivens   = data.Drivens;
         EventArgs = data.EventArgs;
         
         Inputs       = ArrayUtil.ToPlugs(data.Inputs);
         Outputs      = ArrayUtil.ToPlugs(data.Outputs);
         Events       = ArrayUtil.ToPlugs(data.Events);
         m_Parameters = ArrayUtil.ToParameters(data.Parameters);
         EventParameters = ArrayUtil.ToParameters(data.EventParameters);

         m_Position = data.Position; 

         m_ShowComment   = new Parameter(data.ShowComment);
         m_Comment       = new Parameter(data.Comment);
         m_InspectorName = new Parameter(data.InspectorName);
      }
   }

   public struct EntityProperty : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         EntityProperty entityProperty = new EntityProperty( );
         entityProperty.ComponentType = ComponentType;
         entityProperty.Instance      = Instance;
         entityProperty.Parameter     = Parameter;
         entityProperty.Position      = Position;
         entityProperty.Guid          = preserveGuid ? Guid : Guid.NewGuid( );
         entityProperty.IsStatic      = IsStatic;
         return entityProperty;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            EntityPropertyData nodeData = new EntityPropertyData( );
            nodeData.Instance      = Instance.ToParameterData( );
            nodeData.Parameter     = Parameter.ToParameterData( );
            nodeData.ComponentType = ComponentType;
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.Guid      = Guid;
            
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityProperty) ) return false;

         EntityProperty node = (EntityProperty) obj;

         if ( Instance      != node.Instance ) return false;
         if ( ComponentType != node.ComponentType ) return false;
         if ( Parameter     != node.Parameter ) return false;
         if ( Position      != node.Position ) return false;
         if ( IsStatic      != node.IsStatic ) return false;
         if ( Guid          != node.Guid ) return false;

         return true;
      }

      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public string ComponentType;

      private Parameter m_Parameter;
      public Parameter[] Parameters { get { return new Parameter[] { m_Parameter }; } set { m_Parameter = value[ 0 ]; } }
      public Parameter Parameter { get { return m_Parameter; } set { m_Parameter = value; } }

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private bool m_IsStatic;
      public bool IsStatic
      {
         get { return m_IsStatic; }
         set
         {
            m_IsStatic = value;
            m_Instance.Input = false == value;
         }
      }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public EntityProperty(string name, string friendlyName, string componentType, string valueType, bool input, bool output)
      { 
         ComponentType = componentType;

         m_Instance.Name         = "Instance";
         m_Instance.ReferenceGuid = "";
         m_Instance.FriendlyName = "Instance";
         m_Instance.State  = Parameter.VisibleState.Hidden;
         m_Instance.Type   = typeof(UnityEngine.GameObject).ToString( );
         m_Instance.Input  = true;
         m_Instance.Output = false;
         m_Instance.Default= "";
         m_Instance.AutoLinkType = m_Instance.Type;

         m_Parameter = new Parameter( );
         m_Parameter.Name    = name;
         m_Parameter.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Parameter.FriendlyName = friendlyName;
         m_Parameter.Input   = input;
         m_Parameter.Output  = output;
         m_Parameter.Default = "";
         m_Parameter.Type    = valueType;
         m_Parameter.AutoLinkType = m_Parameter.Type;

         m_Position = Point.Empty; 
         m_Guid     = Guid.NewGuid( ); 
         m_IsStatic = false;
      }

      public EntityProperty(EntityPropertyData data)
      { 
         m_Instance  = new Parameter( data.Instance );
         m_Parameter = new Parameter( data.Parameter );
         
         ComponentType = data.ComponentType;
         
         m_Position      = data.Position; 
         m_Guid          = data.Guid; 
         m_IsStatic      = false;
      }
   }

   public struct LocalNode : EntityNode
   {
      public EntityNode Copy( bool preserveGuid )
      {
         LocalNode localNode  = new LocalNode( );
         localNode.Parameters = Parameters;
         localNode.Position   = Position;
         localNode.Guid       = preserveGuid ? Guid : Guid.NewGuid( );
         
         return localNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LocalNodeData nodeData = new LocalNodeData( );
            nodeData.Parameters = ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LocalNode) ) return false;

         LocalNode node = (LocalNode) obj;

         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;
         
         return true;
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      public Parameter[] Parameters { get { return new Parameter[] {m_Name, m_Value, m_Externaled, m_HideInInspector}; } set { m_Name = value[0]; m_Value = value[1]; m_Externaled = value[2]; m_HideInInspector = value[3];} }

      public bool IsStatic { get { return false; } }

      private Parameter m_Name;
      private Parameter m_Value;
      private Parameter m_Externaled;
      private Parameter m_HideInInspector;

      public Parameter Name
      {
         get { return m_Name; }
         set { m_Name = value; }
      }

      public Parameter Externaled
      {
         get { return m_Externaled; }
         set { m_Externaled = value; }
      }

      public Parameter Value
      {
         get { return m_Value; }
         set { m_Value = value; }
      }

      public Parameter HideInInspector
      {
         get { return m_HideInInspector; }
         set { m_HideInInspector = value; }
      }
      
      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }
      
      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public LocalNode(string name, string type, string defaultValue)
      { 
         m_Value.Default = defaultValue;
         m_Value.ReferenceGuid = "";
         m_Value.FriendlyName = "Value";
         m_Value.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Value.Input   = true;
         m_Value.Output  = true;
         m_Value.Name    = "Value";
         m_Value.Type    = type;
         m_Value.AutoLinkType = m_Value.Type;

         m_Name.Default = name;
         m_Name.ReferenceGuid = "";
         m_Name.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Name.Input   = true;
         m_Name.Output  = false;
         m_Name.Name    = "Name";
         m_Name.FriendlyName = "Name";
         m_Name.Type    = typeof(String).ToString( );
         m_Name.AutoLinkType = m_Name.Type;

         m_Externaled.Default = "false";
         m_Externaled.ReferenceGuid = "";
         m_Externaled.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Externaled.Input   = true;
         m_Externaled.Output  = false;
         m_Externaled.Name    = "Make Public";
         m_Externaled.FriendlyName = "Make Public";
         m_Externaled.Type    = typeof(bool).ToString( );
         m_Externaled.AutoLinkType = m_Externaled.Type;

         m_HideInInspector.Default = "false";
         m_HideInInspector.ReferenceGuid = "";
         m_HideInInspector.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_HideInInspector.Input   = true;
         m_HideInInspector.Output  = false;
         m_HideInInspector.Name    = "Hide In Inspector";
         m_HideInInspector.FriendlyName = "Hide In Inspector";
         m_HideInInspector.Type    = typeof(bool).ToString( );
         m_HideInInspector.AutoLinkType = m_HideInInspector.Type;
         
         m_Position = Point.Empty; 
         m_Guid = Guid.NewGuid( ); 
      }
   }

   public class ScriptEditor
   {
      public Parameter FriendlyName;
      public Parameter Description;

      private bool m_GeneratedCodeIsStale = false;
      private bool m_SavedForDebugging    = false;

      private string m_Name  = "";

      public EntityNode [] DirectEntityNodes
      {
         get
         {
             return m_Nodes.Nodes;
         }
      }

      public EntityNode [] EntityNodes
      {
         get
         {
            List<EntityNode> nodes = new List<EntityNode>( );
            foreach ( EntityNode n in m_Nodes.Nodes )
            {
               nodes.Add( n.Copy(true) );
            }

            return nodes.ToArray( );
         }
      }

      public EntityNode [] DeprecatedNodes
      {
         get 
         {
            List<EntityNode> nodes = new List<EntityNode>( );
            
            foreach( EntityNode node in m_DeprecatedNodes.Values )
            {
               nodes.Add( node );
            }

            return nodes.ToArray( );
         }
      }

      public CommentNode [] Comments
      {
         get 
         {
            List<CommentNode> comments = new List<CommentNode>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is CommentNode ) comments.Add( (CommentNode) node );
            }

            return comments.ToArray( );
         }
      }

      public EntityEvent [] Events
      {
         get 
         {
            List<EntityEvent> events = new List<EntityEvent>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is EntityEvent ) events.Add( (EntityEvent) node );
            }

            return events.ToArray( );
         }
      }

      public EntityMethod [] Methods
      {
         get 
         {
            List<EntityMethod> methods = new List<EntityMethod>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is EntityMethod ) methods.Add( (EntityMethod) node );
            }

            return methods.ToArray( );
         }
      }

      public EntityProperty [] Properties
      {
         get 
         {
            List<EntityProperty> properties = new List<EntityProperty>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is EntityProperty ) properties.Add( (EntityProperty) node );
            }

            return properties.ToArray( );
         }
      }

      public LogicNode [] Logics
      {
         get 
         {
            List<LogicNode> logics = new List<LogicNode>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is LogicNode ) logics.Add( (LogicNode) node );
            }

            return logics.ToArray( );
         }
      }

      int ExternalSorter( ExternalConnection a, ExternalConnection b )
      {
         return (int) a.Order.DefaultAsObject - (int) b.Order.DefaultAsObject;
      }

      public ExternalConnection [] Externals
      {
         get 
         {
            List<ExternalConnection> externals = new List<ExternalConnection>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is ExternalConnection ) externals.Add( (ExternalConnection) node );
            }

            ExternalConnection [] sorted = externals.ToArray( );

            Array.Sort( sorted, ExternalSorter );
            return sorted;
         }
      }

      public OwnerConnection [] Owners
      {
         get 
         {
            List<OwnerConnection> owners = new List<OwnerConnection>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is OwnerConnection ) owners.Add( (OwnerConnection) node );
            }

            return owners.ToArray( );
         }
      }

      public LocalNode [] Locals
      {
         get 
         {
            List<LocalNode> locals = new List<LocalNode>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is LocalNode ) locals.Add( (LocalNode) node );
            }

            return locals.ToArray( );
         }
      }

      public LocalNode [] UniqueLocals
      {
         get 
         {
            Dictionary<string, LocalNode> uniqueLocals = new Dictionary<string, LocalNode>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is LocalNode ) 
               {
                  LocalNode local = (LocalNode) node;
                  
                  if ( "" != local.Name.Default )
                  {
                     uniqueLocals[ local.Name.Default + local.Value.Type ] = local;
                  }
                  else
                  {
                     uniqueLocals[ local.Guid.ToString( ) ] = local;
                  }
               }
            }

            return uniqueLocals.Values.ToArray( );
         }
      }

      public LinkNode [] Links
      {
         get 
         {
            List<LinkNode> links = new List<LinkNode>( );
            
            foreach( EntityNode node in m_Nodes.Nodes )
            {
               if ( node is LinkNode ) links.Add( (LinkNode) node );
            }

            return links.ToArray( );
         }
      }

      public bool GeneratedCodeIsStale
      {
         get { return m_GeneratedCodeIsStale; }
      }

      public bool SavedForDebugging
      {
         get { return m_SavedForDebugging; }
      }

      public string Name 
      { 
         get { return m_Name; } 
      }

      public string SceneName = "";

      public class OrderedHash
      {
         private Hashtable m_Hash = new Hashtable();
         private List<EntityNode> m_List = new List<EntityNode>();

         public EntityNode[] Nodes { get { return m_List.ToArray(); } }
         public int Count { get { return m_List.Count; } }

         public bool Contains(Guid guid) { return m_Hash.Contains(guid); }
         public EntityNode Get(Guid guid) { return m_Hash[guid] as EntityNode; }

         public void Remove(Guid guid)
         {
            m_Hash.Remove(guid);

            int i;
            for (i = 0; i < m_List.Count; i++)
            {
               if (m_List[i].Guid == guid)
               {
                  break;
               }
            }

            if (i < m_List.Count)
            {
               m_List.RemoveAt(i);
            }
         }

         public void Add(EntityNode node)
         {
            m_Hash[node.Guid] = node;

            int i;
            for (i = 0; i < m_List.Count; i++)
            {
               if (m_List[i].Guid == node.Guid)
               {
                  m_List[i] = node;
                  break;
               }
            }

            if (i == m_List.Count)
            {
               m_List.Add(node);
            }
         }
      }

      private static Dictionary<string, ScriptEditorData> s_Cache = new Dictionary<string,ScriptEditorData>();

      OrderedHash m_Nodes = new OrderedHash();
      Hashtable m_DeprecatedNodes = new Hashtable();
  
      public bool IsNodeInstanceDeprecated( EntityNode node )
      {
         return m_DeprecatedNodes.Contains(node.Guid);
      }

      private EntityDesc []m_EntityDescs = new EntityDesc[ 0 ];
      private LogicNode  []m_LogicNodes  = new LogicNode [ 0 ];

      public EntityDesc [] EntityDescs
      {
         get { return m_EntityDescs; }
         set { this.m_EntityDescs = value; }
      }

      public LogicNode [] LogicNodes
      {
         get { return m_LogicNodes; }
         set { this.m_LogicNodes = value; }
      }

      public string [] Types
      {
         get 
         { 
            Hashtable typeHash = new Hashtable( );
            
            if ( null != EntityDescs )
            {
               foreach ( EntityDesc desc in EntityDescs )
               {
                  foreach ( EntityEvent node in desc.Events )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                     typeHash[ node.ComponentType ] = node.ComponentType;
                  }

                  foreach ( EntityMethod node in desc.Methods )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                     typeHash[ node.ComponentType ] = node.ComponentType;
                  }

                  foreach ( EntityProperty node in desc.Properties )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                     typeHash[ node.ComponentType ] = node.ComponentType;
                  }
               }

               foreach ( LogicNode node in LogicNodes )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Type ] = node.Type;
               }
            }
            else
            {
               foreach ( EntityEvent node in Events )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
                  typeHash[ node.ComponentType ] = node.ComponentType;
               }

               foreach ( EntityMethod node in Methods )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
                  typeHash[ node.ComponentType ] = node.ComponentType;
               }

               foreach ( EntityProperty node in Properties )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
                  typeHash[ node.ComponentType ] = node.ComponentType;
               }

               foreach ( LogicNode node in Logics )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Type ] = node.Type;
               }
            }

            List<string> types = new List<string>( );

            foreach ( object o in typeHash.Values )
            {
               types.Add( (string) o );
            }

            return types.ToArray( );
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         ScriptEditor script = obj as ScriptEditor;
         if ( null == script ) return false;

         if ( script.m_Nodes.Count != m_Nodes.Count ) return false;

         if ( script.FriendlyName != FriendlyName ) return false;
         if ( script.Description  != Description )  return false;

         foreach ( EntityNode node in m_Nodes.Nodes )
         {
            if ( false == script.m_Nodes.Contains(node.Guid) ) return false;             
            if ( false == node.Equals(script.m_Nodes.Get(node.Guid)) ) return false;
         }

         return true;
      }

      public ScriptEditor(string name, EntityDesc []descs, LogicNode []nodes)
      {
         m_Name = name;
         m_EntityDescs = descs;
         m_LogicNodes  = nodes;

         FriendlyName = new Parameter( );
         FriendlyName.Name = "FriendlyName";
         FriendlyName.FriendlyName = "Friendly Name";
         FriendlyName.Default = "Untitled";
         FriendlyName.Type    = typeof(string).ToString( );
         FriendlyName.Input   = true;
         FriendlyName.Output  = false;
         FriendlyName.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         Description = new Parameter( );
         Description.Name = "Description";
         Description.FriendlyName = "Description";
         Description.Default = "";
         Description.Type    = typeof(string).ToString( );
         Description.Input   = true;
         Description.Output  = false;
         Description.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
      }

      public bool IsEventDriven( LinkNode link, Hashtable checkedHash )
      {
         //if node can't be found we won't need to fail on the backtrace
         if ( false == m_Nodes.Contains(link.Source.Guid) ) return true;
      
         EntityNode node = m_Nodes.Get(link.Source.Guid) as EntityNode;
         
         //local nodes trigger no signals, so we can stop here
         if ( node is LocalNode ) return false;

         //if it's linked to parameter we can stop here
         //because that's not a signaled event output
         foreach (Parameter p in node.Parameters)
         {
            if (link.Source.Anchor == p.Name) return false;
         }


         if ( node is EntityEvent )
         {
            EntityEvent entityEvent = (EntityEvent) node;
            
            foreach (Plug p in entityEvent.Outputs)
            {
               if (p.Name == link.Source.Anchor) return true;
            }
         }

         if ( node is LogicNode )
         {
            LogicNode logic = (LogicNode) node;

            foreach ( Plug eventPlug in logic.Events )
            {
               if ( eventPlug.Name == link.Source.Anchor )
               {
                  return true;
               }
            }
         }

         foreach ( LinkNode sourceLink in Links )
         {
            if ( sourceLink.Destination.Guid == node.Guid )
            {
               string key = sourceLink.Destination.Guid + sourceLink.Destination.Anchor;

               if ( false == checkedHash.Contains(key) )
               {
                  checkedHash[key] = true;

                  bool result = IsEventDriven( sourceLink, checkedHash );            
                  if ( true == result ) return true;
               }
            }
         }

         return false;
      }

      public bool IsEventDriven(LinkNode link)
      {
         //if node can't be found we won't need to fail on the backtrace
         if ( false == m_Nodes.Contains(link.Source.Guid) ) return false;
      
         EntityNode node = m_Nodes.Get(link.Source.Guid) as EntityNode;
      
         Hashtable checkedHash = new Hashtable( );

         //if its first output is a method
         //then see if it'll get hung up on an event
         if ( node is EntityMethod || node is LogicNode )
         {
            //if it's linked to parameter we can stop here
            //because that's not a signaled event output
            foreach (Parameter p in node.Parameters)
            {
               if (link.Source.Anchor == p.Name) return false;
            }

            if ( node is LogicNode )
            {
               LogicNode logic = (LogicNode) node;

               //if it's hooked up to a logic event
               //that's ok because the user doesn't assume
               //it's an immediate output
               foreach ( Plug eventPlug in logic.Events )
               {
                  if ( eventPlug.Name == link.Source.Anchor )
                  {
                     return true;
                  }
               }
            }

            foreach ( LinkNode sourceLink in Links )
            {
               if ( sourceLink.Destination.Guid == node.Guid )
               {
                  bool result = IsEventDriven( sourceLink, checkedHash );            
                  if ( true == result ) return true;
               }
            }
         }

         return false;
      }

      public Parameter FindNodeParameter(EntityNode node, string parameterName)
      {
         foreach ( Parameter p in node.Parameters )
         {
            if ( p.Name == parameterName ) return p;
         }

         if ( node.Instance.Name == parameterName ) return node.Instance;

         return Parameter.Empty;
      }

      public bool IsSourceLinkEvent(LinkNode link)
      {
         EntityNode node = GetNode( link.Source.Guid );
         
         if ( node is EntityEvent )  return true;
         if ( node is EntityMethod ) return false;

         if ( node is LogicNode )
         {
            LogicNode logic = (LogicNode) node;
            
            foreach ( Plug p in logic.Events )
            {
               if ( p.Name == link.Source.Anchor ) return true;
            }
         }

         return false;
      }

      public void VerifyAllLinks( )
      {
         //re-add the links
         //to make sure all the node connections still exist
         LinkNode []links = this.Links;

         foreach ( LinkNode link in links )
         {
            RemoveNode( link );
         }

         foreach ( LinkNode link in links )
         {
            AddNode( link );
         }
      }
      
      public bool VerifyLink( LinkNode link, out string reason )
      {
         reason = "";

         if ( false == m_Nodes.Contains(link.Source.Guid) ||
              false == m_Nodes.Contains(link.Destination.Guid) ) 
         {
            reason = "Node cannot be found";
            return false;
         }

         //fail if a link already exists
         foreach ( LinkNode existingLink in Links )
         {
            if ( existingLink.Source.Guid        == link.Source.Guid &&
                 existingLink.Source.Anchor      == link.Source.Anchor &&
                 existingLink.Destination.Guid   == link.Destination.Guid &&
                 existingLink.Destination.Anchor == link.Destination.Anchor ) 
            {
               reason = "Link already exists (" + existingLink.Source.Anchor + " to " + existingLink.Destination.Anchor + ")";
               return false;
            }
         }

         EntityNode source = (EntityNode) m_Nodes.Get(link.Source.Guid);
         EntityNode dest   = (EntityNode) m_Nodes.Get(link.Destination.Guid);

         //if something is already connected to this destination
         //then see if the dest can handle multiple inputs
         foreach ( LinkNode existingLink in Links )
         {
            if ( existingLink.Destination.Guid   == link.Destination.Guid &&
                 existingLink.Destination.Anchor == link.Destination.Anchor ) 
            {
               Parameter p = this.FindNodeParameter( dest, link.Destination.Anchor );

               if ( p != Parameter.Empty )
               {
                  if ( false == p.Type.Contains("[]") && true == p.Input && false == p.Output )
                  {
                     reason = "There is already a connection to " + p.FriendlyName;
                     return false;
                  }
               }
            }
         }



         //if a link already exists in the other direction
         //allow the bi-directional link regardless of if the parameters match up
         //for example a string might go into an object in/out
         foreach ( LinkNode existingLink in Links )
         {
            if ( existingLink.Source.Guid        == link.Destination.Guid &&
                 existingLink.Source.Anchor      == link.Destination.Anchor &&
                 existingLink.Destination.Guid   == link.Source.Guid &&
                 existingLink.Destination.Anchor == link.Source.Anchor ) 
            {
               Parameter destP   = FindNodeParameter(dest,   link.Destination.Anchor);
               Parameter sourceP = FindNodeParameter(source, link.Source.Anchor);
            
               if ( destP.Input == true && sourceP.Output == true ) return true;
            }
         }

         if ( source is ExternalConnection )
         {
            ExternalConnection externalSource = (ExternalConnection) source;
            
            foreach ( LinkNode existingLinks in Links )
            {
               bool checkTypes = existingLinks.Source.Guid == source.Guid;
               bool nameAlreadyUsed = false;

               if ( false == checkTypes )
               {
                  EntityNode node = GetNode( existingLinks.Source.Guid );
   
                  //if there is an external sharing the same name
                  //treat it as the same external
                  if ( node is ExternalConnection )
                  {
                     ExternalConnection e = (ExternalConnection) node;
                     checkTypes = ((ExternalConnection)source).Name.Default == e.Name.Default;
                  
                     if ( true == checkTypes )
                     {
                        nameAlreadyUsed = true;
                     }
                  }
               }

               //new link and existing link are both sources so make sure the destination connections
               //are the same type
               if ( true == checkTypes )
               {
                  //we already source out to another one
                  //let's see if the dest types match
                  EntityNode node = GetNode( existingLinks.Destination.Guid );

                  Parameter existingParam = FindNodeParameter(node, existingLinks.Destination.Anchor);
                  Parameter myParam       = FindNodeParameter(dest, link.Destination.Anchor);

                  //externals as sources into parameters no longer have to type match
                  //when it comes to scalar verses array.  any other type of external
                  //still needs to type match (even with arrays) support for others can
                  //come on with an as-needed basis
                  
                  //types could be null if it is a left or right socket
                  string existingType = existingParam.Type != null ? existingParam.Type.Replace("[]", "") : "";
                  string newType      = myParam.Type != null ? myParam.Type.Replace("[]", "") : "";

                  bool typeIsSuperclass = false;

                  if ( null != existingType && null != newType )
                  {
                     Type et = uScriptUtils.GetAssemblyQualifiedType(existingType);
                     Type nt = uScriptUtils.GetAssemblyQualifiedType(newType);

                     if ( et != null && nt != null )
                     {
                        if (et.IsAssignableFrom(nt) || nt.IsAssignableFrom(et) )
                           typeIsSuperclass = true;
                     }
                  }

                  if ( existingType != newType && false == typeIsSuperclass )
                  {
                     if ( true == nameAlreadyUsed )
                     {
                        reason = "An External Node with the same name (" + externalSource.Name.Default + ") already exists and is connected to a different type  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                     }
                     else
                     {
                        reason = "An External Node (" + externalSource.Name.Default + ") can't link to two different types  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                     }

                     return false;
                  }                  
               }
               else
               {
                  checkTypes = existingLinks.Destination.Guid == source.Guid ;
                  nameAlreadyUsed = false;

                  if ( false == checkTypes )
                  {
                     EntityNode node = GetNode( existingLinks.Destination.Guid );

                     //if there is an external sharing the same name
                     //treat it as the same external
                     if ( node is ExternalConnection )
                     {
                        ExternalConnection e = (ExternalConnection) node;
                        checkTypes = ((ExternalConnection)source).Name.Default == e.Name.Default;

                        if ( true == checkTypes )
                        {
                           nameAlreadyUsed = true;
                        }
                     }
                  }

                  //new link is a source and existing link is a destination
                  //this is ok (it will generate as a ref) if the types are the same
                  if (true == checkTypes)
                  {
                     //someone is linking to us so
                     //see if their source matches our dest type
                     EntityNode node = GetNode( existingLinks.Source.Guid );

                     Parameter existingParam = FindNodeParameter(node, existingLinks.Source.Anchor);
                     Parameter myParam       = FindNodeParameter(dest, link.Destination.Anchor);

                     if ( Parameter.Empty == existingParam )
                     {
                        if ( true == nameAlreadyUsed )
                        {
                           reason = "An External Node with the same name (" + externalSource.Name.Default + ") already exists and is connected is connected to an Input";
                        }
                        else
                        {
                           reason = "An External Node (" + externalSource.Name.Default + ") can't link to an input and an output";
                        }

                        return false;
                     }
                     else if ( existingParam.Type != myParam.Type )
                     {
                        if ( true == nameAlreadyUsed )
                        {
                           reason = "An External Node with the same name (" + externalSource.Name.Default + ") already exists and is connected to a different type.  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                        }
                        else
                        {
                           reason = "An External Node (" + externalSource.Name.Default + ") can't link to two different types  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                        }

                        return false;
                     }
                  }
               }
            }
         }

         if ( dest is ExternalConnection )
         {
            ExternalConnection externalDest = (ExternalConnection) dest;

            foreach ( LinkNode existingLinks in Links )
            {
               bool checkTypes = existingLinks.Source.Guid == dest.Guid;
               bool nameAlreadyUsed = false;

               if (false == checkTypes)
               {
                  EntityNode node = GetNode( existingLinks.Source.Guid );
   
                  //if there is an external sharing the same name
                  //treat it as the same external
                  if ( node is ExternalConnection )
                  {
                     ExternalConnection e = (ExternalConnection) node;
                     checkTypes = ((ExternalConnection)dest).Name.Default == e.Name.Default;

                     if ( true == checkTypes )
                     {
                        nameAlreadyUsed = true;
                     }
                  }
               }
               
               //new link is a destination and existing link is a source
               //this is ok we'll generate it as a 'ref' but make sure the types match 
               if (true == checkTypes)
               {
                  //someone is linking to us so
                  //see if their dest matches our source type
                  EntityNode node = GetNode( existingLinks.Destination.Guid );

                  Parameter existingParam = FindNodeParameter(node,   existingLinks.Destination.Anchor);
                  Parameter myParam       = FindNodeParameter(source, link.Source.Anchor);

                  //if the existing link is an Input we can't allow that
                  //because we are an Output or an out parameter
                  if ( existingParam == Parameter.Empty )
                  {
                     if ( true == nameAlreadyUsed )
                     {
                        reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to an Output";
                     }
                     else
                     {
                        reason = "An External Node (" + externalDest.Name.Default + ") can't link to an Input and a output parameter or an Output";
                     }

                     return false;
                  }

                  //if we are an Output we can't be allowed because
                  //there is already some source connected to us
                  if ( myParam == Parameter.Empty )
                  {
                     if ( true == nameAlreadyUsed )
                     {
                        reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to a parameter";
                     }
                     else
                     {
                        reason = "An External Node (" + externalDest.Name.Default + ") can't link to an Output and an input parameter or an Input";
                     }

                     return false;
                  }

                  //ok we know they're both parameters, and we know we are an output
                  //and this is an input, this is allowed as long as the types match
                  if ( existingParam.Type != myParam.Type )
                  {
                     if ( true == nameAlreadyUsed )
                     {
                        reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to a different type  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                     }
                     else
                     {
                        reason = "An External Node (" + externalDest.Name.Default + ") can't link to two different types  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                     }

                     return false;
                  }
               }
               else
               {
                  
                  checkTypes = existingLinks.Destination.Guid == dest.Guid;
                  nameAlreadyUsed = false;

                  if (false == checkTypes)
                  {
                     EntityNode node = GetNode( existingLinks.Destination.Guid );

                     //if there is an external sharing the same name
                     //treat it as the same external
                     if ( node is ExternalConnection )
                     {
                        ExternalConnection e = (ExternalConnection) node;
                        checkTypes = ((ExternalConnection)dest).Name.Default == e.Name.Default;
                     
                        if ( true == checkTypes )
                        {
                           nameAlreadyUsed = true;
                        }
                     }
                  }

                  //new link is a destination and existing link is a destination
                  //make sure the types match
                  if (true == checkTypes)
                  {
                     //we already dest out to another one
                     //let's see if the source types match
                     EntityNode node = GetNode( existingLinks.Source.Guid );

                     Parameter existingParam = FindNodeParameter(node,   existingLinks.Source.Anchor);
                     Parameter myParam       = FindNodeParameter(source, link.Source.Anchor);

                     if ( Parameter.Empty == existingParam )
                     {
                        bool isEventA = IsSourceLinkEvent(existingLinks);
                        bool isEventB = IsSourceLinkEvent(link);

                        if ( isEventA != isEventB )
                        {
                           if ( true == nameAlreadyUsed )
                           {
                              if ( true == isEventA )
                              {
                                 reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to an Event output";
                              }
                              else
                              {
                                 reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is not connected to an Event output";
                              }
                           }
                           //else
                           //{
                           //   reason = "An External Node (" + externalDest.Name.Default + ") can't link to an event output and an immediate output";
                           //   return false;
                           //}
                        }
                        else if ( Parameter.Empty != myParam )
                        {
                           if ( true == nameAlreadyUsed )
                           {
                              reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to an Input";
                           }
                           else
                           {
                              reason = "An External Node (" + externalDest.Name.Default + ") can't link to an output and a parameter";
                              return false;
                           }
                        }
                     }
                     else
                     {
                        //we know the existing link is a parameter
                        if ( Parameter.Empty == myParam )
                        {
                           if ( true == nameAlreadyUsed ) 
                           {
                              reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to a parameter";
                           }
                           else
                           {
                              reason = "An External Node (" + externalDest.Name.Default + ") can't link to an output and a parameter";
                              return false;
                           }
                        }

                        //ok we know they're both parameters, and we know we are both outputs
                        else if ( existingParam.Type != myParam.Type )
                        {
                           if ( true == nameAlreadyUsed )
                           {
                              reason = "An External Node with the same name (" + externalDest.Name.Default + ") already exists and is connected to a different type  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                           }
                           else
                           {
                              reason = "An External Node (" + externalDest.Name.Default + ") can't link to two different types  (" + 
                                    "Existing type " + uScriptConfig.Variable.FriendlyName(existingParam.Type) + ", New type " + uScriptConfig.Variable.FriendlyName(myParam.Type) + ")";
                           }

                           return false;
                        }
                     }
                  }
               }
            }

            if ( source is EntityEvent )
            {
               ExternalConnection destConnection = (ExternalConnection) dest;

               EntityEvent sourceEvent = (EntityEvent) source;

               foreach ( Parameter p in sourceEvent.Parameters )
               {
                  if ( p.Output == false ) continue;

                  //don't allow parameter outputs of events to be exposed externally
                  //it makes the nested script node too confusing as to which are output parameters
                  //and which are event output parameters
                  //plus it makes the code more complex to generate
                  if ( p.Name == link.Source.Anchor && 
                       destConnection.Connection == link.Destination.Anchor )
                  {
                     reason = "Externals cannot connect to Event Node Parameters";
                     return false;
                  }
               }
            }
         }

         Parameter sourceParam = new Parameter( );

         Parameter destParam  = sourceParam;
         Parameter emptyParam = sourceParam;

         foreach ( Parameter p in source.Parameters )
         {
            if ( link.Source.Anchor == p.Name )
            {
               sourceParam = p;
               break;
            }
         }

         if ( sourceParam == Parameter.Empty && source is LogicNode )
         {
            foreach ( Parameter p in ((LogicNode)source).EventParameters )
            {
               if ( link.Source.Anchor == p.Name )
               {
                  sourceParam = p;
                  break;
               }
            }
         }

         if ( link.Destination.Anchor == "Instance" )
         {
            if ( dest is EntityMethod )
            {
               destParam = ((EntityMethod)dest).Instance;
            }
            else if ( dest is EntityEvent )
            {
               destParam = ((EntityEvent)dest).Instance;
            
               if ( source is ExternalConnection )
               {
                  reason = "An External Connection can't be used as the Instance for an event";
                  return false;
               }
            }
            else if ( dest is EntityProperty )
            {
               destParam = ((EntityProperty)dest).Instance;

               if ( "" != destParam.Default )
               {
                  reason = "There is already an Instance specified in the Property Panel.  Only one Instance can exist because the property can return values, " +
                           "with multiple Instances we would not know which Instance's value to return.";
                  return false;
               }

               //fail if something is already linked to our instance socket
               //only one is allowed because properties can return information
               foreach ( LinkNode existingLink in Links )
               {
                  if ( existingLink.Destination.Guid   == link.Destination.Guid &&
                       existingLink.Destination.Anchor == link.Destination.Anchor ) 
                  {
                     reason = "Only one link can be connected per Instance socket because the property can return values, " +
                              "with multiple Instances we would not know which Instance's value to return.";
                     return false;
                  }
               }
            }

            if ( dest is EntityMethod )
            {
               EntityMethod em = (EntityMethod) dest;

               bool allowOnlyOne = false;

               foreach ( Parameter parameter in em.Parameters )
               {
                  if ( true == parameter.Output &&
                       false== parameter.Input  &&
                       parameter.Name == "Return"
                     )
                  {
                     allowOnlyOne = true;
                     break;
                  }
               }

               if ( true == allowOnlyOne )
               {
                  //fail if something is already linked to our instance socket
                  foreach ( LinkNode existingLink in Links )
                  {
                     if ( existingLink.Destination.Guid   == link.Destination.Guid &&
                          existingLink.Destination.Anchor == link.Destination.Anchor ) 
                     {
                        reason = "Only one link can be connected per Instance socket if the destination has a return value";
                        return false;
                     }
                  }
               }
            }
         }
         else
         {
            foreach ( Parameter p in dest.Parameters )
            {
               if ( link.Destination.Anchor == p.Name )
               {
                  destParam = p;
                  break;
               }
            }
         }

         if ( source is ExternalConnection && dest is ExternalConnection ) 
         {
            reason = "External Connections cannot be linked together";
            return false;
         }

         if ( source is OwnerConnection && dest is ExternalConnection ) 
         {
            reason = "Owners and External Connections cannot be linked together";
            return false;
         }

         if ( source is ExternalConnection ) return true;
         
         if ( dest is ExternalConnection ) return true;
         //{
         //   if ( false == BacktraceExternalOutput(link) )
         //   {
         //      reason = "External Connections linked to an immediate output cannot also have an event in the same link chain. " +
         //               "This is because the parent script will be expecting an immediate output however the nested script will block on the event.";
         //      return false;
         //   }

         //   return true;
         //}

         //Out socket (right side) connected to an In (left side)
         if ( sourceParam == emptyParam &&
              destParam   == emptyParam )
         {
            bool sourceFound = false;

            if ( source is EntityMethod )
            {
               if ( link.Source.Anchor == ((EntityMethod)source).Output.Name ) 
               {
                  sourceFound = true;
               }
            }
            else if ( source is LogicNode )
            {
               LogicNode logic = (LogicNode) source;

               foreach ( Plug output in logic.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }

               foreach ( Plug eventPlug in logic.Events )
               {
                  if ( link.Source.Anchor == eventPlug.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }
            }
            else if ( source is EntityEvent )
            {
               EntityEvent entityEvent = (EntityEvent) source;
      
               foreach ( Plug output in entityEvent.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }
            }

            if ( false == sourceFound )
            {
               reason = "Output socket " + link.Source.Anchor + " on " + ScriptEditor.FindNodeType(source) + " is no longer available";
               return false;
            }

            bool destFound = false;

            if ( dest is EntityMethod )
            {
               if ( link.Destination.Anchor == ((EntityMethod)dest).Input.Name ) 
               {
                  destFound = true;
               }
            }
            else if ( dest is LogicNode )
            {
               LogicNode logic = (LogicNode) dest;

               foreach ( Plug input in logic.Inputs )
               {
                  if ( link.Destination.Anchor == input.Name )
                  {
                     destFound = true;
                     break;
                  }
               }
            }

            if ( false == destFound )
            {
               reason = "Input socket " + link.Source.Anchor + " is no longer available";
               return false;
            }

            return true;
         }
         
         //don't let parameters hook directly to others without going throug a variable
         //this fixes some script generation errors when dealing with outputting and inputting arrays
         if ( (source is EntityMethod || source is EntityEvent || source is LogicNode) &&
              (dest   is EntityMethod || dest   is EntityEvent || dest   is LogicNode) ) 
         {
            reason = "Parameters must be linked to Variable Nodes, they cannot be linked directly to other Action Nodes";
            return false;
         }

         //source must be output and dest must be input
         if ( true != sourceParam.Output || true != destParam.Input ) 
         {
//            UnityEngine.Debug.Log( "source = " + sourceParam.Name );
             //UnityEngine.Debug.Log( "dest   = " + destParam.Input );

            reason = "The source link must allow an output and the destination must allow an input";
            return false;
         }

         //if source param is an array and dest param is an array
         //remove both array qualifiers because we only care if the types are compatible
         if ( true == destParam.Type.Contains("[]") &&
              true == sourceParam.Type.Contains("[]") )
         {
            destParam.Type   = destParam.Type.Replace("[]", "");
            sourceParam.Type = sourceParam.Type.Replace("[]", "");
         }

         //else if source isn't an array but dest is, remove the array qualifier
         //because source doesn't have to be an array to be a compatible type
         //as long as dest isn't a local node.  If dest is a local node it has to match
         //because that means it's a variable and not a logic/method input
         else if ( true == destParam.Type.Contains("[]") && false == (dest is LocalNode) )
         {
            destParam.Type = destParam.Type.Replace("[]", "");
         }
         
         //if strings aren't exactly equal
         //try and parse the type to see if they can be
         //assigned together
         if ( sourceParam.Type != destParam.Type )
         {
            //query unity objects which might not be loaded yet so we can't just use Type.GetType
            Type sourceType = uScript.Instance.GetType( sourceParam.Type );
            Type destType   = uScript.Instance.GetType( destParam.Type );

            if ( null == destType ) 
            {
               reason = "Type " + destParam.Type + " could not be found in the Unity system";
               return false;
            }

            if ( null == sourceType ) 
            {
               reason = "Type " + sourceParam.Type + " could not be found in the Unity system";
               return false;
            }

            //allow link if the types are compatible somewhere in the derived chain
            if ( false == destType.IsAssignableFrom(sourceType) )
            {
               reason = "Type " + destType + " cannot be assigned from " + sourceType;
               return false;
            }
         }

         return true;
      }

      public void AddNode(EntityNode node)
      {
         AddNode( node, true );
      }

      public void TrustedUpdate(EntityNode node)
      {
         m_Nodes.Add(node);
      }

      public void AddNode(EntityNode node, bool verifyExternal)
      {
         bool allow = true;

         if ( node is LinkNode )
         {
            string reason;
            allow = VerifyLink( (LinkNode) node, out reason );

            if ( false == allow )
            {
               //Debug.Log( Name + " " + reason );
               Status.Info( Name + " " + reason );
            }
         }

         if ( true == allow )
         {
            if ( node is LocalNode )
            {
               LocalNode localNode = (LocalNode) node;

               bool isGlobal = ("" != localNode.Name.Default);

               if ( true == isGlobal )
               {
                  //Assume we do not propagate it to the other nodes
                  bool propagateValue = false;//("" != localNode.Value.Default);
                  
                  //if ( false == hasValue )
                  //{
                  //   ////if it already exists and the name matches the currently existing one 
                  //   ////then see if the externaled value changed, this would mean it's been updated
                  //   ////even if the value is blank
                  //   //if ( true == m_Nodes.Contains(node.Guid) )
                  //   //{
                  //   //   LocalNode clone = (LocalNode) m_Nodes.Get(node.Guid);
                  //   //   hasValue = clone.Externaled != localNode.Externaled;
                  //   //}
                  //}

                  //if it's not a new node and this update hasn't changed the name
                  //then something else about it changed so propagate the value
                  if ( true == m_Nodes.Contains(node.Guid) )
                  {
                     LocalNode clone = (LocalNode) m_Nodes.Get(node.Guid);
                     propagateValue = clone.Name == localNode.Name;
                  }
 
                  //if they modified a local node
                  //go through the list and update all matching nodes

                  //if hasValue is false then it was a new node they are placing
                  //and we don't want to use its values and clear out all the globals
                  if ( true == propagateValue )
                  {
                     List<LocalNode> updates = new List<LocalNode>( );

                     foreach ( LocalNode clone in Locals )
                     {
                        //if the node has a shared name with other nodes
                        //of that type, then update their values
                        if ( localNode.Name.Default == clone.Name.Default &&
                             localNode.Value.Type   == clone.Value.Type )
                        {
                           LocalNode copy = clone;

                           copy.Parameters = localNode.Parameters;
                           updates.Add( copy );
                        }
                     }

                     foreach ( LocalNode clone in updates )
                     {
                        m_Nodes.Add(clone);
                     }
                  }
                  else
                  {
                     //it's a blank node so if there is a matchine name/type
                     //update our value
                     foreach ( LocalNode existing in Locals )
                     {
                        if ( localNode.Name.Default == existing.Name.Default &&
                             localNode.Value.Type   == existing.Value.Type )
                        {
                           node.Parameters = existing.Parameters;
                           break;
                        }
                     }
                  }
               }
            }

            //sync all external connections with the same name
            if ( node is ExternalConnection )
            {
               ExternalConnection externalNode = (ExternalConnection) node;

               bool hasValue = "" != externalNode.Description.Default || "-1" != externalNode.Order.Default;

               //if they modified an external node
               //go through the list and update all matching nodes

               //if hasValue is false then it was a new node they are placing
               //and we don't want to use its values and clear out all the globals
               if ( true == hasValue )
               {
                  List<ExternalConnection> updates = new List<ExternalConnection>( );

                  foreach ( ExternalConnection clone in Externals )
                  {
                     //if the node has a shared name with other nodes
                     //of that type, then update their values
                     if ( externalNode.Name.Default == clone.Name.Default )
                     {
                        ExternalConnection copy = clone;

                        copy.Parameters = externalNode.Parameters;
                        updates.Add( copy );
                     }
                  }

                  foreach ( ExternalConnection clone in updates )
                  {
                     m_Nodes.Add(clone);
                  }
               }
               else
               {
                  //it's a blank node so if there is a matchine name/type
                  //update our value
                  foreach ( ExternalConnection existing in Externals )
                  {
                     if ( externalNode.Name.Default == existing.Name.Default )
                     {
                        node.Parameters = existing.Parameters;
                        break;
                     }
                  }
               }
            }

            m_Nodes.Add(node);
           
            if ( node is ExternalConnection && true == verifyExternal )
            {
               VerifyAllLinks( );
            }
         }
      }

      public LinkNode []GetLinksByDestination(Guid destGuid, string destAnchor)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in this.Links )
         {
            if ( link.Destination.Guid == destGuid )
            {
               if ( null == destAnchor || link.Destination.Anchor == destAnchor )
               {
                  links.Add( link );
               }
            }
         }

         return links.ToArray( );
      }

      public LinkNode []GetLinksBySource(Guid sourceGuid, string sourceAnchor)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in this.Links )
         {
            if ( link.Source.Guid == sourceGuid )
            {
               if ( null == sourceAnchor || link.Source.Anchor == sourceAnchor )
               {
                  links.Add( link );
               }
            }
         }

         return links.ToArray( );
      }

      public EntityNode GetNode(Guid guid)
      {
         if ( m_Nodes.Contains(guid) )
         {
            return (EntityNode) m_Nodes.Get(guid);
         }

         return null;
      }

      public void RedirectLinks(Guid fromNode, Guid toNode)
      {
         LinkNode [] links;
         
         links = GetLinksByDestination( fromNode, null );
         
         foreach ( LinkNode link in links )
         {
            if ( link.Destination.Guid != toNode )
            {
               LinkNode clone = link;
   
               RemoveNode( link );
               
               clone.Destination.Guid = toNode;

               AddNode( clone );
            }
         }

         links = GetLinksBySource( fromNode, null );
         
         foreach ( LinkNode link in links )
         {
            if ( link.Source.Guid != toNode )
            {
               LinkNode clone = link;

               RemoveNode( link );
               clone.Source.Guid = toNode;

               AddNode( clone );
            }
         }
      }

      public void RemoveNode(EntityNode removeNode)
      {
         List<EntityNode> references = new List<EntityNode>( );

         if ( m_Nodes.Contains(removeNode.Guid) )
         {
            references.Add( removeNode );
         }

         foreach ( EntityNode node in m_Nodes.Nodes )
         {
            if ( node is LinkNode )
            {
               if ( ((LinkNode)node).Destination.Guid == removeNode.Guid )
               {
                  references.Add( node );
               }
               else if ( ((LinkNode)node).Source.Guid == removeNode.Guid )
               {
                  references.Add( node );
               }
            }
         }

         foreach( EntityNode node in references )
         {
            m_Nodes.Remove( node.Guid );
         }

         if ( m_DeprecatedNodes.Contains(removeNode.Guid) )
         {
            m_DeprecatedNodes.Remove(removeNode.Guid);
         }
      }

      public bool CanUpgradeNode( EntityNode oldNode )
      {
         bool canUpgrade = false;
         if ( m_DeprecatedNodes.Contains(oldNode.Guid) )
         {         
            Type newType = uScript.GetNodeUpgradeType(oldNode);
            if ( null == newType ) newType = uScriptUtils.GetAssemblyQualifiedType(ScriptEditor.FindNodeType(oldNode));

            if ( null != newType )
            {               
               foreach ( EntityDesc desc in EntityDescs )
               {
                  foreach ( EntityEvent eventNode in desc.Events )
                  {
                     if ( ScriptEditor.FindNodeType(eventNode) == newType.ToString( ) )
                     {
                        canUpgrade = true;
                        break;
                     }
                  }
               }

               foreach ( LogicNode logicNode in LogicNodes )
               {
                  if ( ScriptEditor.FindNodeType(logicNode) == newType.ToString( ) )
                  {
                     canUpgrade = true;
                     break;
                  }
               }
            }
            else
            {
               //if deprecated attribute exists then we can upgrade to a brand new type
               if ( true == uScript.IsNodeTypeDeprecated(oldNode) )
               {
                  canUpgrade = true;
               }
            }
         }

         return canUpgrade;
      }
      
      public void UpgradeNode( EntityNode oldNode )
      {
         if ( m_DeprecatedNodes.Contains(oldNode.Guid) )
         {         
            Type newType = uScript.GetNodeUpgradeType(oldNode);
            if ( null == newType ) newType = uScriptUtils.GetAssemblyQualifiedType(ScriptEditor.FindNodeType(oldNode));

            if ( null != newType )
            {
               bool upgraded = false;
               
               foreach ( EntityDesc desc in EntityDescs )
               {
                  foreach ( EntityEvent eventNode in desc.Events )
                  {
                     if ( ScriptEditor.FindNodeType(eventNode) == newType.ToString( ) )
                     {
                        EntityEvent cloned = (EntityEvent) eventNode.Copy( true );
                        
                        //copy everything compatible from the old node to the new node
                        cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, oldNode.Parameters );
                        cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                                new Parameter[]{oldNode.Instance} )[ 0 ];

                        if ( oldNode is EntityEvent )
                        {
                           cloned.EventArgs = ((EntityEvent)oldNode).EventArgs;
                        }
                        
                        cloned.Guid        = oldNode.Guid;
                        cloned.Position    = oldNode.Position;
                        cloned.ShowComment = oldNode.ShowComment;
                        cloned.Comment     = oldNode.Comment;         
                     
                        //guid matches the old one so this will replace the old node
                        AddNode( cloned );
                        VerifyAllLinks( );

                        upgraded = true;
                        break;
                     }
                  }
               }

               foreach ( LogicNode logicNode in LogicNodes )
               {
                  if ( ScriptEditor.FindNodeType(logicNode) == newType.ToString( ) )
                  {
                     LogicNode cloned = (LogicNode) logicNode.Copy( true );

                     //copy everything compatible from the old node to the new node
                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, oldNode.Parameters);                  

                     cloned.Guid       = oldNode.Guid;
                     cloned.Position   = oldNode.Position;
                     cloned.ShowComment= oldNode.ShowComment;
                     cloned.Comment    = oldNode.Comment;

                     //guid matches the old one so this will replace the old node
                     AddNode( cloned );
                     VerifyAllLinks( );

                     upgraded = true;
                     break;
                  }
               }

               if ( true == upgraded )
               {
                  m_DeprecatedNodes.Remove( oldNode.Guid );
               }
               else
               {
                  Status.Error( "Node " + ScriptEditor.FindNodeType(oldNode) + " could not automatically upgraded" );
               }
            }
            else
            {
               //if deprecated attribute doesn't exist then the reflection values changed and the script hasn't been resaved
               //we know the user acknowledged it - so now allow them to upgrade it
               if ( false == uScript.IsNodeTypeDeprecated(oldNode) )
               {
                  m_DeprecatedNodes.Remove( oldNode.Guid );
               }
               else
               {
                  Status.Error( "Node " + ScriptEditor.FindNodeType(oldNode) + " had no registered upgradable type" );
               }
            }
         }
      }

      public EntityNode CreateEntityNode( EntityNodeData data )
      {
         EntityNode node = null;

         if ( data is EntityEventData )
         {
            node = CreateEntityEvent( data as EntityEventData );
         }
         else if ( data is CommentNodeData )
         {
            node = CreateCommentNode( data as CommentNodeData );
         }
         else if ( data is LinkNodeData )
         {
            node = CreateLinkNode( data as LinkNodeData );
         }
         else if ( data is EntityMethodData )
         {
            node = CreateEntityMethod( data as EntityMethodData );
         }
         else if ( data is LocalNodeData )
         {
            node = CreateLocalNode( data as LocalNodeData );
         }
         else if ( data is EntityPropertyData )
         {
            node = CreateEntityProperty( data as EntityPropertyData );
         }
         else if ( data is LogicNodeData )
         {
            node = CreateLogicNode( data as LogicNodeData );
         }
         else if ( data is ExternalConnectionData )
         {
            node = CreateExternalConnection( data as ExternalConnectionData );
         }
         else if ( data is OwnerConnectionData )
         {
            node = CreateOwnerConnection( data as OwnerConnectionData );
         }
         else
         {
            Status.Error( "Unrecognized script node " + data.GetType().ToString() );
         }

         return node;
      }

      public ScriptEditorData ScriptEditorData
      {
         get 
         { 
            ScriptEditorData data = new ScriptEditorData( );

            List<EntityNodeData> nodeDatas = new List<EntityNodeData>( );

            foreach ( object value in m_Nodes.Nodes )
            {
               EntityNode node = (EntityNode) value;
               nodeDatas.Add( node.NodeData );
            }

            data.NodeDatas = nodeDatas.ToArray( );
            data.SceneName = SceneName;
            data.GeneratedCodeIsStale = GeneratedCodeIsStale;
            data.SavedForDebugging = SavedForDebugging;
            data.Description  = Description.ToParameterData( );
            data.FriendlyName = FriendlyName.ToParameterData( );

            return data;
         }

         set
         {
            foreach ( EntityNodeData data in value.NodeDatas )
            {
               EntityNode node = CreateEntityNode( data );
               
               if ( null != node )
               {
                  m_Nodes.Add( node );
               }
            }

            m_GeneratedCodeIsStale = value.GeneratedCodeIsStale;
            m_SavedForDebugging    = value.SavedForDebugging;

            Description  = new Parameter( value.Description );
            FriendlyName = new Parameter( value.FriendlyName );
            SceneName = value.SceneName;
         }
      }

      public bool Read(string cacheName, MemoryStream stream)
      {
         ScriptEditorData cachedData;

         Profile p;

         if (null != cacheName) cacheName = cacheName.RelativeAssetPath();

         if (null != cacheName && s_Cache.TryGetValue(cacheName, out cachedData))
         {
            p = new Profile("Read Cache " + cacheName);
            ScriptEditorData = cachedData as ScriptEditorData;
         }
         else
         {
            p = new Profile("Read " + cacheName);
            BinaryReader reader = new BinaryReader( stream );
            object data = null;

            ObjectSerializer serializer = new ObjectSerializer( );
            if ( false == serializer.Load(reader, out data) ) return false;

            ScriptEditorData readData = data as ScriptEditorData;
            if ( null == readData ) return false;

            ScriptEditorData = data as ScriptEditorData;

            if (null != cacheName) s_Cache[cacheName] = data as ScriptEditorData;
            //VerifyAllLinks( );
         }

          p.End();

         return true;
      }

      public bool Write(string cacheName, MemoryStream stream)
      {
         BinaryWriter writer = new BinaryWriter( stream );

         ObjectSerializer serializer = new ObjectSerializer( );
         if ( false == serializer.Save(writer, ScriptEditorData) ) return false;

         if (null != cacheName)
         {
            cacheName = cacheName.RelativeAssetPath();
            s_Cache[cacheName] = ScriptEditorData;
         }

         return true;
      }

      public string ToBase64(string cacheName)
      {
         MemoryStream stream = new MemoryStream( );

         if ( false == Write(cacheName, stream) ) 
         {
            Status.Error( "Could not write script data to a memory stream" );
            return null;
         }

         string base64 = Convert.ToBase64String( stream.GetBuffer( ) );

         stream.Close( );

         return base64;
      }

      public bool OpenFromBase64(string cacheName, string name, string base64)
      {
         try
         {
            Profile p = new Profile( "Open from Base64 " + cacheName );
            string contents = base64;

            byte[] binary = Convert.FromBase64String( contents );

            MemoryStream stream = new MemoryStream( binary );
            if ( false == Read(cacheName, stream) ) 
            {
               Status.Error( "Failed to load " + name );
               return false;
            }

            m_Name = name;
            p.End();

            return true;
         }
         catch (Exception e)
         {
            Status.Error( "Failed to load " + name + ". Exception: " + e.Message );
            return false;
         }
      }

      public bool Open(string fullPath)
      {
         StreamReader streamReader = null;

         try
         {
            streamReader = File.OpenText(fullPath);
            var contents = streamReader.ReadToEnd();

            streamReader.Close();

            const string Start = "/*[[BEGIN BASE64\r\n";
            const string End = "\r\nEND BASE64]]*/";

            if (contents.IndexOf(Start, StringComparison.Ordinal) == -1)
            {
               const string OtherStart = "/*[[BEGIN BASE64\n";
               const string OtherEnd = "\nEND BASE64]]*/";
               contents = contents.Substring(contents.IndexOf(OtherStart, StringComparison.Ordinal));
               contents = contents.Substring(OtherStart.Length);
               contents = contents.Substring(0, contents.Length - OtherEnd.Length);
            }
            else
            {
               contents = contents.Substring(contents.IndexOf(Start, StringComparison.Ordinal));
               contents = contents.Substring(Start.Length);
               contents = contents.Substring(0, contents.Length - End.Length);
            }

            var result = this.OpenFromBase64(fullPath, Path.GetFileName(fullPath), contents);

            return result;
         }
         catch (Exception e)
         {
            if (null != streamReader)
            {
               streamReader.Close();
            }

            Status.Error(string.Format("Failed to load {0}. Exception: {1}", fullPath, e.Message));
            return false;
         }
      }

      public ScriptEditor Copy( )
      {
         ScriptEditor script = new ScriptEditor( Name, EntityDescs, LogicNodes );
         script.ScriptEditorData = ScriptEditorData;
      
         return script;
      }

      private bool SaveTextFile(string path, string fileContents)
      {
         StreamWriter streamWriter = null;
         bool inVC = false;

         try
         {
            inVC = uScript.IsFileInSourceControl(path);

            streamWriter = File.CreateText(path);
            streamWriter.Write(fileContents);
            streamWriter.Close();

            if (!inVC)
            {
               // this will do nothing if source control is not available
               uScript.MasterComponent.AddFileToVersionControl(path.RelativeAssetPath());
            }
         }
         catch (Exception e)
         {
            if (null != streamWriter) streamWriter.Close();

            Status.Error("Failed to write to " + path + ". Exception: " + e.Message);
            return false;
         }

         return true;
      }

      public bool Save(string binaryFile)
      {
         m_GeneratedCodeIsStale = true;

         string base64 = ToBase64( binaryFile );

         try
         {
            m_Name = Path.GetFileName( binaryFile );
         }
         catch (Exception e)
         {
            Status.Error( "Failed to write to " + binaryFile + ". Exception: " + e.Message );
            return false;
         }

         return SaveTextFile(binaryFile, "/*[[BEGIN BASE64\r\n" + base64 + "\r\nEND BASE64]]*/");
      }

      public bool Save(string binaryFile, string logicFile, string wrapperFile, bool saveForDebugging, bool stubCode)
      {
         m_SavedForDebugging    = saveForDebugging;
         m_GeneratedCodeIsStale = false;

         string base64 = ToBase64( binaryFile );

         try
         {
            m_Name = Path.GetFileName( binaryFile );
         }
         catch (Exception e)
         {
            Status.Error( "Failed to write to " + binaryFile + ". Exception: " + e.Message );
            return false;
         }

         // save .uscript file
         if (!SaveTextFile(binaryFile, "/*[[BEGIN BASE64\r\n" + base64 + "\r\nEND BASE64]]*/"))
         {
            Status.Error("Failed to write to " + binaryFile + ".");
            return false;
         }

         // save _component file
         string logicClass = System.IO.Path.GetFileNameWithoutExtension( logicFile );
         UnityCSharpGenerator wrapperCodeGenerator = new UnityCSharpGenerator( );
         if (!SaveTextFile(wrapperFile, wrapperCodeGenerator.GenerateGameObjectScript(logicClass, this, stubCode)))
         {
            m_GeneratedCodeIsStale = true;

            Status.Error("Failed to write to " + wrapperFile + ".");
            return false;
         }

         // save logic file
         UnityCSharpGenerator logicCodeGenerator = new UnityCSharpGenerator( );
         if (!SaveTextFile(logicFile, logicCodeGenerator.GenerateLogicScript(logicClass, this, saveForDebugging, stubCode)))
         {
            m_GeneratedCodeIsStale = true;

            Status.Error( "Failed to write to " + logicFile + ".");
            return false;
         }

         return true;
      }

      public string [] Filter( string [] assets, string filter )
      {
         List<string> results = new List<string>( );

         foreach ( string asset in assets )
         {
            if ( asset.EndsWith(filter) )
            {
               results.Add( asset );
            }
         }

         return results.ToArray( );
      }

      private CommentNode CreateCommentNode( CommentNodeData data )
      {
         CommentNode local = new CommentNode( "" );
         local.Guid        = data.Guid;
         local.Position    = data.Position;
         local.Width       = new Parameter( data.Width );
         local.Height      = new Parameter( data.Height );
         local.ShowComment = new Parameter( data.ShowComment );
         local.Comment     = new Parameter( data.Comment );
         local.BodyText    = new Parameter( data.BodyText );
         local.BodyTextColor  = new Parameter( data.BodyTextColor );
         local.TitleText      = new Parameter( data.TitleText );
         local.TitleTextColor = new Parameter( data.TitleTextColor );
         local.NodeColor      = new Parameter( data.NodeColor );
         return local;
      }

      private EntityEvent CreateEntityEvent( EntityEventData data )
      {
         EntityEvent cloned;

         if ( null == m_EntityDescs )
         {
            cloned = new EntityEvent( data );
         }
         else
         {
            cloned = new EntityEvent( data.ComponentType, data.ComponentType, ArrayUtil.ToPlugs(data.Outputs) );
            
            bool exactMatch = false;
            bool found      = false;

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityEvent entityEvent in desc.Events )
               {
                  if ( entityEvent.Instance.Type == data.Instance.Type &&
                       entityEvent.ComponentType == data.ComponentType &&
                       true == ArrayUtil.ArraysAreEqual(entityEvent.Outputs, ArrayUtil.ToPlugs(data.Outputs)) )
                  {
                     cloned = entityEvent;
                     found  = true;

                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), entityEvent.Parameters) )
                     {
                        exactMatch = true;
                     }

                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
                     break;
                  }
               }
            }

            if ( true == found )
            {
               cloned.EventArgs   = data.EventArgs;
               cloned.Guid        = data.Guid;
               cloned.Position    = data.Position;
               cloned.ShowComment = new Parameter( data.ShowComment );
               cloned.Comment     = new Parameter( data.Comment );         
            }
            else
            {
               cloned = new EntityEvent( data );
            }

            if ( false == found || false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityEvent " + data.ComponentType + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private EntityMethod CreateEntityMethod( EntityMethodData data )
      {
         EntityMethod cloned;
         
         if ( null == m_EntityDescs )
         {
            cloned = new EntityMethod( data );
         }
         else
         {
            cloned = new EntityMethod( data.ComponentType, data.Input.Name, data.Input.FriendlyName );
            bool exactMatch = false;
            bool found      = false;

            //entities might have overloaded methods so we need to go through all
            //and if we don't find an exact match then just use the first potential one we come across
            List<EntityMethod> potentialMatches = new List<EntityMethod>( );

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityMethod entityMethod in desc.Methods )
               {
                  if ( entityMethod.ComponentType == data.ComponentType &&
                       entityMethod.Instance.Type == data.Instance.Type &&
                       entityMethod.Input.Name == data.Input.Name )
                  {
                     cloned = entityMethod;
                     found  = true;
                     
                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), entityMethod.Parameters) )
                     {
                        exactMatch = true;
                     }
                     else
                     {
                        potentialMatches.Add(entityMethod);                     
                        continue;
                     }

                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
                     break;
                  }
               }
            }


            if ( false == exactMatch )
            {
               if ( potentialMatches.Count > 0 )
               {
                  cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                  cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                           ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
               }
            }

            if ( true == found )
            {
               cloned.Guid        = data.Guid;
               cloned.Position    = data.Position;
               cloned.ShowComment = new Parameter( data.ShowComment );
               cloned.Comment     = new Parameter( data.Comment );
               cloned.IsStatic    = data.IsStatic;
            }
            else
            {
               cloned = new EntityMethod( data );
            }

            if ( false == found || false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityMethod " + data.ComponentType + " " + data.Input.Name + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private EntityProperty CreateEntityProperty( EntityPropertyData data )
      {
         EntityProperty cloned;
         
         if ( null == m_EntityDescs )
         {
            cloned = new EntityProperty( data );
         }
         else
         {
            cloned = new EntityProperty( data.Parameter.Name, data.Parameter.FriendlyName, data.ComponentType, 
                                         data.Parameter.Default, data.Parameter.Input, data.Parameter.Output );
            bool exactMatch = false;
            bool found = false;

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityProperty entityProperty in desc.Properties )
               {
                  if ( entityProperty.Instance.Type  == data.Instance.Type  &&
                       entityProperty.Parameter.Name == data.Parameter.Name &&
                       entityProperty.ComponentType  == data.ComponentType )
                  {
                     cloned = entityProperty;
                     found  = true;
                     
                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Parameter}), 
                                                                    new Parameter[]{entityProperty.Parameter}) )
                     {
                        exactMatch = true;
                     }

                     cloned.Parameter  = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Parameter}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Parameter}) )[ 0 ];
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];

                     break;
                  }
               }
            }

            if ( true == found )
            {
               cloned.Guid        = data.Guid;
               cloned.Position    = data.Position;
               cloned.ShowComment = new Parameter( data.ShowComment );
               cloned.Comment     = new Parameter( data.Comment );
            }
            else
            {
               cloned = new EntityProperty( data );
            }

            if ( false == found || false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityProperty " + data.Instance.Name + " " + data.Parameter.Name + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private LogicNode CreateLogicNode( LogicNodeData data )
      {
         LogicNode cloned;

         //no reflection information so use
         //everything straight from the data file
         if ( null == m_LogicNodes )
         {
            cloned = new LogicNode( data );
         }
         else
         {
            cloned = new LogicNode( data.Type, data.FriendlyName );

            bool found = false;
            bool exactMatch = false;
   
            foreach ( LogicNode node in m_LogicNodes )
            {
               if ( node.Type == data.Type )
               {
                  found  = true;
                  cloned = node;
                  
                  //don't compare event parameters or event args when checking for an exact match
                  //because they aren't a supported feature and are only used for nested scripts
                  //if we support them for users in the future we'll want to add the compare
                  if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), node.Parameters) &&                       
                       true == ArrayUtil.ArraysAreEqual(node.Inputs, ArrayUtil.ToPlugs(data.Inputs)) &&
                       true == ArrayUtil.ArraysAreEqual(node.Outputs, ArrayUtil.ToPlugs(data.Outputs)) &&                       
                       true == ArrayUtil.ArraysAreEqual(node.Events, ArrayUtil.ToPlugs(data.Events)) )
                  {
                     exactMatch = true;
                  }

                  cloned.EventParameters= ArrayUtil.CopyCompatibleParameters(cloned.EventParameters, ArrayUtil.ToParameters(data.EventParameters) );                  
                  cloned.Parameters     = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );                  
                  cloned.InspectorName  = new Parameter( data.InspectorName );
                  cloned.EventArgs  = data.EventArgs;
                  break;
               }
            }

            if ( true == found )
            {
               cloned.Guid       = data.Guid;
               cloned.Position   = data.Position;
               cloned.ShowComment= new Parameter( data.ShowComment );
               cloned.Comment    = new Parameter( data.Comment );
            }
            else
            {
               cloned = new LogicNode( data );
            }

            if ( false == found || false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching LogicNode " + data.Type + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }
      
      private ExternalConnection CreateExternalConnection( ExternalConnectionData data )
      {
         ExternalConnection external = new ExternalConnection( );

         external.Connection = "Connection";
         external.Guid       = data.Guid;
         external.Position   = data.Position;
         external.Name       = new Parameter( data.Name );
         external.Order      = new Parameter( data.Order );
         external.Description= new Parameter( data.Description );
         external.ShowComment= new Parameter( data.ShowComment );
         external.Comment    = new Parameter( data.Comment );

         return external;
      }

      private OwnerConnection CreateOwnerConnection( OwnerConnectionData data )
      {
         OwnerConnection owner = new OwnerConnection( data.Guid );

         owner.Guid       = data.Guid;
         owner.Position   = data.Position;
         owner.ShowComment= new Parameter( data.ShowComment );
         owner.Comment    = new Parameter( data.Comment );

         return owner;
      }

      private LocalNode CreateLocalNode( LocalNodeData data )
      {
         LocalNode local  = new LocalNode( );
         local.Guid       = data.Guid;
         local.Position   = data.Position;
         local.Parameters = ArrayUtil.ToParameters( data.Parameters );
         local.ShowComment= new Parameter( data.ShowComment );
         local.Comment    = new Parameter( data.Comment );

         return local;
      }

      private LinkNode CreateLinkNode( LinkNodeData data )
      {
         return new LinkNode( data );
      }

      public static string FindNodeType(EntityNode node)
      {
         if (node is EntityEvent)
         {
            return ((EntityEvent)node).ComponentType;
         }

         if (node is LogicNode)
         {
            return ((LogicNode)node).Type;
         }
         
         if (node is EntityProperty)
         {
            return ((EntityProperty)node).ComponentType;
         }
         
         if (node is EntityMethod)
         {
            return ((EntityMethod)node).ComponentType;
         }

         return string.Empty;
      }
   }
}
