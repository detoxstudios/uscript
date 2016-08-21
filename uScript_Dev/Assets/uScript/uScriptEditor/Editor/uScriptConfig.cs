// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptConfig.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   uScript's configuration file. Edit settings here to configure the uScript visual scripting tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !RELEASE
#define ENABLE_DEBUG_LOG
#endif

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public struct uScriptConfigBlock
{
   public Type Type;
   public string FriendlyName;
   public string Category;

   public uScriptConfigBlock(Type type, string friendlyName, string category)
   {
      this.Type = type ?? typeof(Type);
      this.FriendlyName = friendlyName ?? string.Empty;
      this.Category = category;
   }
}

public static class uScriptConfig
{
#if (UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
   public const float BezierPenWidth = 2.75f;
   public const float BezierPenWidthSelected = 3.0f;
#else
   public const float BezierPenWidth = 1.25f;
   public const float BezierPenWidthSelected = 1.5f;
#endif
   public const int MinResizeX = 60;
   public const int MinResizeY = 16;

   //private static Texture2D nodeDefaultTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/uscript_node_default_color.png", typeof(Texture2D)) as Texture2D;
   //private static Texture2D nodeEventTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/uscript_node_event_color.png", typeof(Texture2D)) as Texture2D;
   //private static Texture2D nodeVariableTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/uscript_node_variable_color.png", typeof(Texture2D)) as Texture2D;
   //private static Texture2D minimapScreenBorder = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/uscript_minimap_screen_border.png", typeof(Texture2D)) as Texture2D;

   static uScriptConfig()
   {
      CanvasBackgroundTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/uscript_background.png", typeof(Texture2D)) as Texture2D;
      LineTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/icons/uscript_line.png", typeof(Texture2D)) as Texture2D;
      PointerLineEnd = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/icons/uscript_pointer_line_end.png", typeof(Texture2D)) as Texture2D;
      ResizeTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.Skin) + "/icons/uscript_icon_resize_comment.png", typeof(Texture2D)) as Texture2D;

      Style = new uScriptDefaultStyle();

      Variables = new[]
                     {
                        new uScriptConfigBlock(typeof(bool), "Bool", "Variables"),
                        new uScriptConfigBlock(typeof(bool[]), "Bool List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(int), "Int", "Variables"),
                        new uScriptConfigBlock(typeof(int[]), "Int List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(float), "Float", "Variables"),
                        new uScriptConfigBlock(typeof(float[]), "Float List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(string), "String", "Variables"),
                        new uScriptConfigBlock(typeof(string[]), "String List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(AnimationClip), "AnimationClip", "Variables"),
                        new uScriptConfigBlock(typeof(Camera), "Camera", "Variables"),
                        new uScriptConfigBlock(typeof(Camera[]), "Camera List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Color), "Color", "Variables"),
                        new uScriptConfigBlock(typeof(Color[]), "Color List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(AudioClip), "AudioClip", "Variables"),
                        new uScriptConfigBlock(typeof(AudioClip[]), "AudioClip List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(GameObject), "GameObject", "Variables"),
                        new uScriptConfigBlock(typeof(GameObject[]), "GameObject List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(GUILayoutOption), "GUILayoutOption", "Variables"),
                        new uScriptConfigBlock(typeof(GUILayoutOption[]), "GUILayoutOption List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(uScript_Lerper.LoopType), "Loop Type", "Variables"),
                        new uScriptConfigBlock(typeof(Material), "Material", "Variables"),
                        new uScriptConfigBlock(typeof(Material[]), "Material List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Quaternion), "Quaternion", "Variables"),
                        new uScriptConfigBlock(typeof(Ray), "Ray", "Variables"),
                        new uScriptConfigBlock(typeof(RaycastHit), "RaycastHit", "Variables"),
                        new uScriptConfigBlock(typeof(Rect), "Rect", "Variables"),
                        new uScriptConfigBlock(typeof(Rect[]), "Rect List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Transform), "Transform", "Variables"),
                        new uScriptConfigBlock(typeof(Transform[]), "Transform List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Texture2D), "Texture2D", "Variables"),
                        new uScriptConfigBlock(typeof(Texture2D[]), "Texture2D List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Vector2), "Vector2", "Variables"),
                        new uScriptConfigBlock(typeof(Vector2[]), "Vector2 List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Vector3), "Vector3", "Variables"),
                        new uScriptConfigBlock(typeof(Vector3[]), "Vector3 List", "Variables/Lists"),
                        new uScriptConfigBlock(typeof(Vector4), "Vector4", "Variables"),
                        new uScriptConfigBlock(typeof(Vector4[]), "Vector4 List", "Variables/Lists")
                     };

      VariableStyleTypes = new[]
                              {
                                 "variable_default", "variable_string", "variable_bool", "variable_float", "variable_int",
                                 "variable_vector3", "variable_gameobject", "variable_object", "variable_selected"
                              };

      PropertyStyleTypes = new[]
                              {
                                 "property_default", "property_string", "property_bool", "property_float", "property_int",
                                 "property_vector3", "property_gameobject", "property_object", "property_selected"
                              };

      LineColors = new[]
                      {
                         new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f),
                         new Color(109.0f / 255.0f, 224.0f / 255.0f, 120.0f / 255.0f),
                         new Color(255.0f / 255.0f, 58.0f / 255.0f, 58.0f / 255.0f),
                         new Color(72.0f / 255.0f, 115.0f / 255.0f, 255.0f / 255.0f),
                         new Color(0.0f / 255.0f, 222.0f / 255.0f, 255.0f / 255.0f),
                         new Color(243.0f / 255.0f, 204.0f / 255.0f, 110.0f / 255.0f),
                         new Color(200.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f),
                         new Color(247.0f / 255.0f, 194.0f / 255.0f, 255.0f / 255.0f),
                         new Color(255.0f / 255.0f, 255.0f / 255.0f, 196.0f / 255.0f)
                      };

#if (UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
      LineWidths = new[] { 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.75f };
#else
      LineWidths = new[] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f };
#endif
   }

   public static Texture2D CanvasBackgroundTexture { get; private set; }
   
   public static Texture2D LineTexture { get; private set; }

   public static Texture2D PointerLineEnd { get; private set; }

   public static Texture2D ResizeTexture { get; private set; }

   public static Color[] LineColors { get; private set; }

   public static float[] LineWidths { get; private set; }

   public static string[] PropertyStyleTypes { get; private set; }

   public static uScriptStyle Style { get; private set; }

   public static uScriptConfigBlock[] Variables { get; private set; }

   public static string[] VariableStyleTypes { get; private set; }

   public static Color GetStyleColor(string style)
   {
      var index = VariableStyleTypes.TakeWhile(s => s != style).Count();

      if (index == VariableStyleTypes.Length)
      {
         index = PropertyStyleTypes.TakeWhile(s => s != style).Count();

         if (index == PropertyStyleTypes.Length)
         {
            index = 0;
         }
      }

      return LineColors[index];
   }

   public struct Files
   {
      public static string SettingsFile { get { return "uScriptSettings.settings"; } }

      public static string GeneratedComponentExtension { get { return "_Component"; } }

      public static string GeneratedCodeExtension { get { return string.Empty; } }
   }

   //do not override in the preferences path, 
   //these are accessed outside the scope of uScript.cs and our preferences file
   public static class ConstantPaths
   {
      static ConstantPaths()
      {
         var assets = Application.dataPath;
         var uscript = assets + "/uScript";
         var asblyPath = typeof(uScript).Assembly.Location;

         // if we're in a dll, we need to locate the root install directory
         if (asblyPath.ToLower().Contains("uscript.dll"))
         {
            // go from [path-to-unity-project]/Assets/path/to/uscript/uScriptEditor/Editor/uScript.dll
            //      to [path-to-unity-project]/Assets/path/to/uscript
            uscript = asblyPath;
            for (int i = 0; i < 3; i++)
            {
               if (uscript.LastIndexOf("/") == -1)
               {
                  uscript = uscript.Substring(0, uscript.LastIndexOf("\\"));
               }
               else
               {
                  uscript = uscript.Substring(0, uscript.LastIndexOf("/"));
               }
            }  
         }
         // else - assume uScript root is [path-to-unity-project]/Assets/uscript

         Editor = string.Format("{0}/uScriptEditor", uscript);
         RuntimeNodes = string.Format("{0}/uScriptRuntime/Nodes", uscript);

         Gizmos = string.Format("{0}/Editor/_Gizmos", Editor);
         Skin = string.Format("{0}/Editor/_GUI/uScriptDefault", Editor);
         Skins = string.Format("{0}/Editor/Skins", Editor);
         Templates = string.Format("{0}/Editor/_Templates", Editor);

         Screenshots = string.Format("{0}/Screenshots", assets);
      }

      public static string Editor { get; private set; }

      public static string Gizmos { get; private set; }

      public static string RuntimeNodes { get; private set; }

      public static string Skin { get; private set; }

      public static string Skins { get; private set; }

      public static string Screenshots { get; private set; }

      public static string Templates { get; private set; }

      public static string RelativePath(string absolutePath)
      {
         absolutePath = absolutePath.Replace('\\', '/');
         return absolutePath.StartsWith(Application.dataPath)
                   ? absolutePath.Substring(Application.dataPath.Length - "Assets".Length)
                   : absolutePath;
      }

      public static string RelativePathInAssets(string absolutePath)
      {
         absolutePath = absolutePath.Replace('\\', '/');
         return absolutePath.StartsWith(Application.dataPath)
                   ? absolutePath.Substring(Application.dataPath.Length)
                   : absolutePath;
      }
   }

   public class Variable
   {
      public static bool Exists(string type)
      {
         return Variables.Any(filter => filter.Type.ToString() == type);
      }

      public static string FriendlyName(string type)
      {
         foreach (var filter in Variables.Where(filter => filter.Type.ToString() == type))
         {
            return filter.FriendlyName;
         }

         if (type != null)
         {
            var formatted = type.Replace("+", ".");

            //Template type
            if (formatted.Contains("`2["))
            {
               var newString = string.Empty;
               var values = formatted.Split(new[] { "`2[" }, StringSplitOptions.None);

               foreach (var v in values)
               {
                  var value = v + "<";
                  var newValue = value;

                  int i, open = 1;

                  for (i = 1; i < value.Length; i++)
                  {
                     if (value[i] == ']')
                     {
                        open--;
                     }
                     else if (value[i] == '[')
                     {
                        open++;
                     }

                     if (0 == open) 
                     {
                        newValue = value.Substring(0, i);
                        newValue += '>';

                        if (value.Length > i + 1)
                        {
                           newValue += value.Substring(i + 1);
                        }
                        break;
                     }
                  }

                  newString += newValue;
               }

               //remove last alligator we appended during the foreach
               formatted = newString.TrimEnd(new[] { '<' });
            }

            return formatted;
         }

         return "null";
      }
      
      //return a style based on the friendly name,
      //but if the friendly name can't be found return "default"
      public static string FriendlyStyleName(string type)
      {
         //uScriptDebug.Log( "uScript_EventHandler.cs: " + type );
         type = type.Replace("[]", string.Empty);

         var friendly = FriendlyName(type);
         if (type == friendly)
         {
            friendly = "default";
         }

         return friendly.ToLower();
      }

      public static string Category(string type)
      {
         foreach (var filter in Variables.Where(filter => filter.Type.ToString() == type))
         {
            return filter.Category;
         }

         return string.Empty;
      }
   }
}

public abstract class uScriptStyle
{
   public abstract int SocketValueTextHorizontalOffset { get; }

   public abstract int SocketValueTextVerticalOffset { get; }

   public abstract int BottomSocketLabelGapSize { get; }

   public abstract int BottomSocketBorderAdjustmentPad { get; }

   public abstract int SideSocketToBottomSocketPad { get; }

   public abstract int BottomSocketLabelGap { get; }

   public abstract int TopPad { get; }

   public abstract int LeftPad { get; }

   public abstract int RightPad { get; }

   public abstract int BottomPad { get; }

   public abstract int PointSize { get; }

   public abstract int TitleTopBottomPad { get; }

   public abstract int TitleLeftRightPad { get; }

   public abstract int RightShadow { get; }

   public abstract int BottomShadow { get; }

   public abstract int OutputOnlyPointOffset { get; }

   public abstract int IoSocketLabelVerticalOffset { get; }

   public abstract int IoSocketLabelHorizontalOffset { get; }

   public abstract int GridSize { get; }

   public abstract int GridSubdivisions { get; }

   public abstract Color GridColorMajor { get; }

   public abstract Color GridColorMinor { get; }

   public abstract bool ShowGrid { get; }

   public abstract GUIStyle Get(string name);
}

public class uScriptDefaultStyle : uScriptStyle
{
   private readonly Dictionary<string, GUIStyle> styles = new Dictionary<string, GUIStyle>();

   //how many pixels to adjust the variable socket value text left (+) or right (-) (horizontal)
   public override int SocketValueTextHorizontalOffset { get { return 2; } }
    
   //how many pixels between the variable socket and the value text (vertical)
   public override int SocketValueTextVerticalOffset { get { return 15; } }
    
   //how many pixels between variable socket labels (horizontal)
   public override int BottomSocketLabelGapSize { get { return 4; } }
    
   //how many pixels to adjust between variable socket labels and side borders (vertical)
   public override int BottomSocketBorderAdjustmentPad { get { return 6; } }
    
   //how many pixels between variable socket labels and In/Out sockets (vertical)
   public override int SideSocketToBottomSocketPad { get { return 16; } }
    
   //how many pixels between a variable socket and its label (vertical)
   public override int BottomSocketLabelGap { get { return 2; } }
    
   //how many pixels to pad objects from the top of the node (vertical)
   public override int TopPad { get { return 2; } }

   //how many pixels to pad objects from the left of the node (horizontal)
   public override int LeftPad { get { return 2; } }
    
   //how many pixels to pad objects from the right of the node (horizontal)
   public override int RightPad { get { return 7; } }

   //how many pixels to pad objects from the bottom of the node  (vertical)
   public override int BottomPad { get { return 7; } }

   //how big (in pixels) the link points should be (used for spacing and hit detection)
   public override int PointSize { get { return 13; } }

   //top and bottom padding for titles (vertical)
   public override int TitleTopBottomPad { get { return 18; } }

   //left and right padding for title labels (horizontal)
   public override int TitleLeftRightPad { get { return 18; } }

   //right shadow width (horizontal)
   public override int RightShadow { get { return 6; } }

   //bottom shadow height (vertical)
   public override int BottomShadow { get { return 6; } }

   //when rendering output only nodes, any additional offset
   //because they can be different style/shape than input/output (vertical)
   public override int OutputOnlyPointOffset { get { return 5; } }
    
   // sets and additional vertical offset for IO socket labels (vertical)
   public override int IoSocketLabelVerticalOffset { get { return 2; } }
    
   // sets and additional horizontal offset for IO socket labels (horizontal)
   public override int IoSocketLabelHorizontalOffset { get { return -2; } }

   public override bool ShowGrid { get { return true; } }

   //background grid size
   public override int GridSize { get { return 20; } }

   public override int GridSubdivisions { get { return 4; } }

   public override Color GridColorMajor { get { return new Color(87 / 255f, 96 / 255f, 110 / 255f); } }

   public override Color GridColorMinor { get { return new Color(95 / 255f, 103 / 255f, 118 / 255f); } }

   public void CreateDefaultStyles()
   {
      var defaultStyles = new Dictionary<string, GUIStyle>();
      var nodeTextGrey = new Color(188 / 255.0f, 188 / 255.0f, 188 / 255.0f);

      //Color nodeTextLightGrey = new Color(215 / 255.0f, 220 / 255.0f, 240 / 255.0f);

      defaultStyles["node"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(9, 15, 23, 15),
         padding = new RectOffset(-6, 0, 2, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperCenter,
         fontStyle = FontStyle.Bold,
         fontSize = 12
      };

      defaultStyles["node_selected"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(9, 15, 23, 15),
         padding = new RectOffset(-6, 0, 2, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperCenter,
         fontStyle = FontStyle.Bold,
         fontSize = 12
      };

      defaultStyles["static"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(),
         padding = new RectOffset(),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperCenter,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      defaultStyles["comment"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(0, 0, -14, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Bold,
         fontSize = 0
      };

      defaultStyles["selectionbox"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(0, 0, -14, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Bold,
         fontSize = 0
      };

      defaultStyles["comment_selected"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(0, 0, -14, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Bold,
         fontSize = 0
      };

      defaultStyles["property"] = new GUIStyle
      {
         normal = { textColor = nodeTextGrey },
         border = new RectOffset(6, 12, 6, 12),
         padding = new RectOffset(),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperCenter,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      defaultStyles["variable"] = new GUIStyle
      {
         normal = { textColor = Color.white },
         border = new RectOffset(25, 31, 25, 31),
         padding = new RectOffset(-139, -128, 0, -12),
         fixedHeight = 0,
         fixedWidth = 0f,
         alignment = TextAnchor.LowerCenter,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      defaultStyles["externalconnection"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(26, 34, 26, 32),
         padding = new RectOffset(-139, -128, 0, -12),
         fixedHeight = 0,
         fixedWidth = 0f,
         alignment = TextAnchor.LowerCenter,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      defaultStyles["externalconnection_selected"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(26, 34, 26, 32),
         padding = new RectOffset(-139, -128, 0, -12),
         fixedHeight = 0,
         fixedWidth = 0f,
         alignment = TextAnchor.LowerCenter,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      var assetPath = uScriptConfig.ConstantPaths.Skin + "/elements";
      assetPath = uScriptConfig.ConstantPaths.RelativePath(assetPath);

      var directory = new System.IO.DirectoryInfo(assetPath);
      var files = directory.GetFiles("*.png");

      var relativePath = uScriptConfig.ConstantPaths.RelativePath(assetPath);

      foreach (var file in files)
      {
         var name = System.IO.Path.GetFileName(file.Name);

         var styleBackground = UnityEditor.AssetDatabase.LoadAssetAtPath(relativePath + "/" + name, typeof(Texture2D)) as Texture2D;
         uScriptDebug.Assert(styleBackground != null, string.Format("The style background texture could not be loaded: {0}", name));
         styleBackground.wrapMode = TextureWrapMode.Clamp;

         name = System.IO.Path.GetFileNameWithoutExtension(name);

         if (name.StartsWith("uscript_"))
         {
            name = name.Substring("uscript_".Length);
         }

         string key;

         if (false == name.Contains("socket") &&
             name.Contains("node") &&
             false == name.Contains("selected"))
         {
            key = "node";
         }
         else if (name.Contains("node_selected"))
         {
            key = "node_selected";
         }
         else if (name.Contains("socket"))
         {
            key = "static";
         }
         else if (name.Contains("icon"))
         {
            key = "static";
         }
         else if (name.Contains("selectionbox"))
         {
            key = "selectionbox";
         }
         else if (name.Contains("comment") &&
                  false == name.Contains("selected"))
         {
            key = "comment";
         }
         else if (name.Contains("comment_selected"))
         {
            key = "comment_selected";
         }
         else if (name.Contains("externalconnection") &&
               false == name.Contains("selected"))
         {
            key = "externalconnection";
         }
         else if (name.Contains("externalconnection_selected"))
         {
            key = "externalconnection_selected";
         }
         else if (name.Contains("property"))
         {
            key = "property";
         }
         else if (name.Contains("variable") &&
            false == name.Contains("node"))
         {
            key = "variable";
         }
         else
         {
            uScriptDebug.Log("Can't find element setttings for " + name + ", defaulting to 'node'", uScriptDebug.Type.Error);
            key = "node";
         }

         var settings = defaultStyles[key];
         this.styles[name] = new GUIStyle
         {
            name = name,
            border = settings.border,
            padding = settings.padding,
            fixedHeight = settings.fixedHeight,
            fixedWidth = settings.fixedWidth,
            alignment = settings.alignment,
            fontStyle = settings.fontStyle,
            fontSize = settings.fontSize,
            normal = { background = styleBackground, textColor = settings.normal.textColor }
         };
      }

      var style = new GUIStyle
      {
         wordWrap = true,
         normal = { textColor = nodeTextGrey },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };
      this.styles["socket_text"] = style;
      this.styles["clear_socket"] = style;
      this.styles["clear_socket_connecting"] = style;
      this.styles["clear_socket_selected"] = style;

      this.styles["socket_text_bold"] = new GUIStyle
      {
         normal = { textColor = nodeTextGrey },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Bold,
         fontSize = 0
      };

      this.styles["comment_body_text"] = new GUIStyle
      {
         wordWrap = true,
         normal = { textColor = nodeTextGrey },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(8, 8, 8, 8),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      this.styles["title_comment"] = new GUIStyle
      {
         normal = { textColor = Color.black },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(0, 0, -14, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };

      this.styles["value_text"] = new GUIStyle
      {
         normal = { textColor = new Color(0.15f, 0.15f, 0.15f, 1f) },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(0, 0, -14, 0),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Italic,
         fontSize = 0
      };

      this.styles["externalconnection_text"] = new GUIStyle
      {
         wordWrap = true,
         normal = { textColor = Color.black },
         border = new RectOffset(6, 6, 6, 6),
         padding = new RectOffset(),
         fixedHeight = 0f,
         fixedWidth = 0f,
         alignment = TextAnchor.UpperLeft,
         fontStyle = FontStyle.Normal,
         fontSize = 0
      };
   }

   public override GUIStyle Get(string name)
   {
      if (this.styles == null || this.styles.Count == 0)
      {
         CreateDefaultStyles();
      }

      name = name ?? string.Empty;

      if (this.styles.ContainsKey(name))
      {
         return this.styles[name];
      }

      if (false == name.Contains("socket") &&
          name.Contains("node") &&
          false == name.Contains("selected"))
      {
         return this.styles["node_default"];
      }

      if (name.Contains("node_selected"))
      {
         return this.styles["node_selected"];
      }

      if (name.Contains("socket"))
      {
         if (name.Contains("_io"))
         {
            return this.styles["node_default_socket_io"];
         }

         var type = "default";
         if (name.Contains("_event_"))
         {
            type = "event";
         }

         var socket = string.Format(
            "node_{0}_socket_{1}variable_default",
            type,
            name.Contains("_out_") ? "out_" : string.Empty);
         return this.styles[socket];
      }

      if (name.Contains("icon"))
      {
         return this.styles["icon_lock_open"];
      }

      if (name.Contains("comment") &&
          false == name.Contains("selected"))
      {
         return this.styles["comment"];
      }

      if (name.Contains("comment_selected"))
      {
         return this.styles["comment_selected"];
      }

      if (name.Contains("externalconnection") &&
          false == name.Contains("selected"))
      {
         return this.styles["externalconnection"];
      }

      if (name.Contains("externalconnection_selected"))
      {
         return this.styles["externalconnection_selected"];
      }

      if (name.Contains("property"))
      {
         return this.styles["property_default"];
      }

      return this.styles["variable_default"];
   }
}
