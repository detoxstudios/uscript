// uScript uScriptConfig.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript's configuration file. Edit settings here to configure the uScript visual scripting tool.

#define ENABLE_DEBUG_LOG
// Public beta reminders:
// 1. Disable above define(s)
// 2. Increment build number
// 3. Optionally increase end date


using System;
using System.Collections.Generic;

using UnityEngine;

// uScript uScript_EventHandler.cs
// (C) 2010 Detox Studios LLC

public struct uScriptConfigBlock
{
   public Type Type;
   public string FriendlyName;
   public string Category;

   public uScriptConfigBlock(Type type, string friendlyName, string category)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = category;
   }
}

public partial class uScriptConfig
{
   public class Variable
   {
      public static bool Exists(string type)
      {
         foreach (uScriptConfigBlock filter in uScriptConfig.Variables)
         {
            if (filter.Type.ToString() == type)
            {
               return true;
            }
         }

         return false;
      }

      public static string FriendlyName(string type)
      {
         foreach (uScriptConfigBlock filter in uScriptConfig.Variables)
         {
            if (filter.Type.ToString() == type)
            {
               return filter.FriendlyName;
            }
         }

         return null == type ? "null" : type;
      }
      
      //return a style based on the friendly name,
      //but if the friendly name can't be found return "default"
      public static string FriendlyStyleName(string type)
      {
         //uScriptDebug.Log( "uScript_EventHandler.cs: " + type );
         type = type.Replace( "[]", "" );

         string friendly = FriendlyName( type );
         if ( type == friendly ) friendly = "default";

         return friendly.ToLower( );
      }

      public static string Category(string type)
      {
         foreach (uScriptConfigBlock filter in uScriptConfig.Variables)
         {
            if (filter.Type.ToString() == type)
            {
               return filter.Category;
            }
         }

         return "";
      }
   }
}
public abstract class uScriptStyle
{
   public abstract GUIStyle Get(string name);
	
   public abstract int SocketValueTextHorizontalOffset { get; }	
   public abstract int SocketValueTextVerticalOffset { get; }		
   public abstract int BottomSocketLabelGapSize { get; }
   public abstract int BottomSocketBorderAdjustmentPad { get; }
   public abstract int SideSocketToBottomSocketPad { get; }
   public abstract int BottomSocketLabelGap { get; }
   public abstract int TopPad   { get; }
   public abstract int LeftPad  { get; }
   public abstract int RightPad { get; }
   public abstract int BottomPad{ get; }
   public abstract int PointSize{ get; }
   public abstract int TitleTopBottomPad { get; }
   public abstract int TitleLeftRightPad { get; }
   public abstract int RightShadow { get; }
   public abstract int BottomShadow{ get; }
   public abstract int OutputOnlyPointOffset { get; }
   public abstract int IOSocketLabelVerticalOffset { get; }
   public abstract int IOSocketLabelHorizontalOffset { get; }
   public abstract float GridSizeVertical   { get; }
   public abstract float GridSizeHorizontal { get; }
   public abstract Color GridColorMajor { get; }
   public abstract Color GridColorMinor { get; }
   public abstract int GridMajorLineSpacing { get; }
   public abstract bool ShowGrid { get; }
}

public class uScriptDefaultStyle : uScriptStyle
{
   private Dictionary<string, GUIStyle> m_Styles = new Dictionary<string, GUIStyle>();

   public uScriptDefaultStyle()
   {
      Dictionary<string, GUIStyle> elementSettings = new Dictionary<string, GUIStyle>();
      Color nodeTextGrey = new Color(188 / 255.0f, 188 / 255.0f, 188 / 255.0f);
      //Color nodeTextLightGrey = new Color(215 / 255.0f, 220 / 255.0f, 240 / 255.0f);

      GUIStyle element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 9;
      element.border.right = 15;
      element.border.top = 23;
      element.border.bottom = 15;
      element.padding.left = -6;
      element.padding.right = 0;
      element.padding.top = 2;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
	  element.alignment = TextAnchor.UpperCenter;
	  element.fontStyle = FontStyle.Bold;
	  element.fontSize = 12;
      elementSettings["node"] = element;
		
	  element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 9;
      element.border.right = 15;
      element.border.top = 23;
      element.border.bottom = 15;
      element.padding.left = -6;
      element.padding.right = 0;
      element.padding.top = 2;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
	  element.alignment = TextAnchor.UpperCenter;
	  element.fontStyle = FontStyle.Bold;
	  element.fontSize = 12;
      elementSettings["node_selected"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 0;
      element.border.right = 0;
      element.border.top = 0;
      element.border.bottom = 0;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
	  element.alignment = TextAnchor.UpperCenter;
      element.fontStyle = FontStyle.Normal;
	  element.fontSize = 0;
      elementSettings["static"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = -14;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
	   element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Bold;
	   element.fontSize = 0;
      elementSettings["comment"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = -14;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Bold;
      element.fontSize = 0;
      elementSettings["selectionbox"] = element;
		
	  element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = -14;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Bold;
	   element.fontSize = 0;
      elementSettings["comment_selected"] = element;

      element = new GUIStyle();
      element.normal.textColor = nodeTextGrey;
      element.border.left = 6;
      element.border.right = 12;
      element.border.top = 6;
      element.border.bottom = 12;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
	   element.alignment = TextAnchor.UpperCenter;
	   element.fontStyle = FontStyle.Normal;
	   element.fontSize = 0;
      elementSettings["property"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.white;
      element.border.left = 25;
      element.border.right = 31;
      element.border.top = 25;
      element.border.bottom = 31;
      element.padding.left = -139;
      element.padding.right = -128;
      element.padding.top = 0;
      element.padding.bottom = -12;
      element.fixedHeight = 0;
      element.fixedWidth = 0f;
	   element.alignment = TextAnchor.LowerCenter;
      element.fontStyle = FontStyle.Normal;
	   element.fontSize = 0;
      elementSettings["variable"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 26;
      element.border.right = 34;
      element.border.top = 26;
      element.border.bottom = 32;
      element.padding.left = -139;
      element.padding.right = -128;
      element.padding.top = 0;
      element.padding.bottom = -12;
      element.fixedHeight = 0;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.LowerCenter;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      elementSettings["externalconnection"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 26;
      element.border.right = 34;
      element.border.top = 26;
      element.border.bottom = 32;
      element.padding.left = -139;
      element.padding.right = -128;
      element.padding.top = 0;
      element.padding.bottom = -12;
      element.fixedHeight = 0;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.LowerCenter;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      elementSettings["externalconnection_selected"] = element;


      string assetPath = uScriptConfig.ConstantPaths.SkinPath + "/elements";
      assetPath = uScriptConfig.ConstantPaths.RelativePath(assetPath);

      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( assetPath );
      System.IO.FileInfo [] files = directory.GetFiles( "*.png" );

      string relativePath = uScriptConfig.ConstantPaths.RelativePath(assetPath);

      foreach (System.IO.FileInfo file in files)
      {
         string name = System.IO.Path.GetFileName(file.Name);
         
         Texture2D styleBackground = UnityEditor.AssetDatabase.LoadAssetAtPath(relativePath + "/" + name, typeof(Texture2D)) as Texture2D;
         styleBackground.wrapMode = TextureWrapMode.Clamp;

         name = System.IO.Path.GetFileNameWithoutExtension(name);

         if (name.StartsWith("uscript_"))
         {
            name = name.Substring("uscript_".Length);
         }

         string key = "";

         if (false == name.Contains("socket") &&
             true == name.Contains("node") &&
             false == name.Contains("selected"))
         {
            key = "node";
         }
         else if (true == name.Contains("node_selected"))
         {
            key = "node_selected";
         }
         else if (true == name.Contains("socket"))
         {
            key = "static";
         }
         else if (true == name.Contains("icon"))
         {
            key = "static";
         }
         else if (true == name.Contains("selectionbox"))
         {
            key = "selectionbox";
         }
         else if (true == name.Contains("comment") &&
                  false == name.Contains("selected"))
         {
            key = "comment";
         }
         else if (true == name.Contains("comment_selected"))
         {
            key = "comment_selected";
         }
         else if (true == name.Contains("externalconnection") &&
               false == name.Contains("selected"))
         {
            key = "externalconnection";
         }
         else if (true == name.Contains("externalconnection_selected"))
         {
            key = "externalconnection_selected";
         }
         else if (true == name.Contains("property"))
         {
            key = "property";
         }
         else if (true == name.Contains("variable") &&
            false == name.Contains("node"))
         {
            key = "variable";
         }
         else
         {
            uScriptDebug.Log("Can't find element setttings for " + name + ", defaulting to 'node'", uScriptDebug.Type.Error);
            key = "node";
         }

         GUIStyle settings = elementSettings[key];
         GUIStyle style = new GUIStyle();
         style.name = name;
         style.normal.textColor = settings.normal.textColor;
         style.border.left = settings.border.left;
         style.border.right = settings.border.right;
         style.border.top = settings.border.top;
         style.border.bottom = settings.border.bottom;
         style.padding.left = settings.padding.left;
         style.padding.right = settings.padding.right;
         style.padding.top = settings.padding.top;
         style.padding.bottom = settings.padding.bottom;
         style.fixedHeight = settings.fixedHeight;
         style.fixedWidth = settings.fixedWidth;
         style.normal.background = styleBackground;
         style.alignment = settings.alignment;
         style.fontStyle = settings.fontStyle;
         style.fontSize = settings.fontSize;

         m_Styles[name] = style;

      }

      element = new GUIStyle();
      element.wordWrap = true;
      element.normal.textColor = nodeTextGrey;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      m_Styles["socket_text"] = element;
      
      m_Styles["clear_socket"] = element;
      m_Styles["clear_socket_connecting"] = element;
      m_Styles["clear_socket_selected"] = element;

      element = new GUIStyle();
      element.normal.textColor = nodeTextGrey;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Bold;
      element.fontSize = 0;
      m_Styles["socket_text_bold"] = element;

      element = new GUIStyle();
      element.wordWrap = true;
      element.normal.textColor = nodeTextGrey;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 8;
      element.padding.right = 8;
      element.padding.top = 8;
      element.padding.bottom = 8;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      m_Styles["comment_body_text"] = element;

      element = new GUIStyle();
      element.normal.textColor = Color.black;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = -14;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      m_Styles["title_comment"] = element;
		
	  element = new GUIStyle();
      element.normal.textColor = new UnityEngine.Color(0.15f, 0.15f, 0.15f, 1f);
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = -14;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Italic;
      element.fontSize = 0;
      m_Styles["value_text"] = element;
      
      element = new GUIStyle();
      element.wordWrap = true;
      element.normal.textColor = Color.black;
      element.border.left = 6;
      element.border.right = 6;
      element.border.top = 6;
      element.border.bottom = 6;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0f;
      element.fixedWidth = 0f;
      element.alignment = TextAnchor.UpperLeft;
      element.fontStyle = FontStyle.Normal;
      element.fontSize = 0;
      m_Styles["externalconnection_text"] = element;
   }

   public override GUIStyle Get(string name)
   {
      if ( null == name ) name = "";

      if (m_Styles.ContainsKey(name)) return m_Styles[name];

	   //Debug.Log( "Can not find style: " + name );

      if (false == name.Contains("socket") &&
          true == name.Contains("node") &&
		  false == name.Contains("selected"))
      {
   	   //Debug.Log( "returning node_default" );
         return m_Styles[ "node_default" ];
      }
		else if (true == name.Contains("node_selected"))
      {
   	   //Debug.Log( "returning node_selected" );
         return m_Styles[ "node_selected" ];
      }
      else if (true == name.Contains("socket"))
      {
         if ( true == name.Contains("_io") )
         {
   	      //Debug.Log( "node_default_socket_io" );
            return m_Styles[ "node_default_socket_io" ];
         }
         else
         {
            string type = "default";
            if ( true == name.Contains("_event_") ) type = "event";

            if ( true == name.Contains("_out_") )
            {
   	         //Debug.Log( "node_default_socket_io" );
               return m_Styles[ "node_" + type + "_socket_out_variable_default" ];
            }
            else
            {
               return m_Styles[ "node_" + type + "_socket_variable_default" ];
            }
         }
      }
      else if (true == name.Contains("icon"))
      {
   	   //Debug.Log( "icon_lock_open" );
         return m_Styles[ "icon_lock_open" ];
      }
      else if (true == name.Contains("comment") &&
			   false == name.Contains("selected"))
      {
   	   //Debug.Log( "comment" );
         return m_Styles[ "comment" ];
      }
	  else if (true == name.Contains("comment_selected"))
      {
   	   //Debug.Log( "comment_selected" );
         return m_Styles[ "comment_selected" ];
      }
      else if (true == name.Contains("externalconnection") &&
         false == name.Contains("selected"))
      {
         //Debug.Log( "externalconnection" );
         return m_Styles["externalconnection"];
      }
      else if (true == name.Contains("externalconnection_selected"))
      {
         //Debug.Log( "externalconnection_selected" );
         return m_Styles["externalconnection_selected"];
      }
      else if (true == name.Contains("property"))
      {
   	   //Debug.Log( "property_default" );
         return m_Styles[ "property_default" ];
      }
	  else
	  {
   	   //Debug.Log( "variable_default" );
         return m_Styles[ "variable_default" ];
	  }
   }
	
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
   public override int TopPad   { get { return 2; } }

   //how many pixels to pad objects from the left of the node (horizontal)
   public override int LeftPad  { get { return 2; } }
	
   //how many pixels to pad objects from the right of the node (horizontal)
   public override int RightPad { get { return 7; } }

   //how many pixels to pad objects from the bottom of the node  (vertical)
   public override int BottomPad{ get { return 7; } }

   //how big (in pixels) the link points should be (used for spacing and hit detection)
   public override int PointSize{ get { return 13; } }

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
   public override int IOSocketLabelVerticalOffset { get { return 2; } }
	
   // sets and additional horizontal offset for IO socket labels (horizontal)
   public override int IOSocketLabelHorizontalOffset { get { return -2; } }

   //background grid size
   public override bool ShowGrid { get { return true; } }
   public override float GridSizeVertical   { get { return 20; } }
   public override float GridSizeHorizontal { get { return 20; } }
   public override int GridMajorLineSpacing   { get { return 4; } }
   public override Color GridColorMajor { get { return new Color((87/255f), (96/255f), (110/255f)); } }
   public override Color GridColorMinor { get { return new Color((95/255f), (103/255f), (118/255f)); } }
}

public partial class uScriptConfig
{
   public static uScriptConfigBlock [] Variables
   {
      get
      {
         return new uScriptConfigBlock []
         {
            // Variables
            new uScriptConfigBlock( typeof(System.Int32), "Int", "Variables" ),
            new uScriptConfigBlock( typeof(System.Single), "Float", "Variables" ),
            new uScriptConfigBlock( typeof(System.Single[]), "Float List", "Variables/Lists" ),
            new uScriptConfigBlock( typeof(System.Boolean), "Bool", "Variables" ),
            new uScriptConfigBlock( typeof(System.String), "String", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Color), "Color", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Vector2), "Vector2", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Vector3), "Vector3", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Vector4), "Vector4", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Quaternion), "Quaternion", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Rect), "Rect", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.GameObject), "GameObject", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.GameObject[]), "GameObject List", "Variables/Lists" ),
            new uScriptConfigBlock( typeof(UnityEngine.Camera), "Camera", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.RaycastHit), "RaycastHit", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Ray), "Ray", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Camera[]), "Camera List", "Variables/Lists" ),
            new uScriptConfigBlock( typeof(uScript_Lerper.LoopType), "Loop Type", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Material), "Material", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Texture2D), "Texture2D", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.AnimationClip), "AnimationClip", "Variables" ),
         };
      }
   }

   //do not override in the preferences path, 
   //these are accessed outside the scope of uScript.cs and out preferences file
   public struct ConstantPaths
   {
      public static string SettingsPath      { get {return UnityEngine.Application.dataPath + "/uScriptProjectFiles"; } } 
      public static string RootFolder        { get {return UnityEngine.Application.dataPath + "/uScript";} }
      public static string RuntimeFolder     { get {return RootFolder      + "/uScriptRuntime";} }
      public static string uScriptEditor     { get {return RootFolder      + "/uScriptEditor";} }
      public static string uScriptNodes      { get {return RuntimeFolder   + "/Nodes";} }
      public static string GuiPath           { get {return uScriptEditor   + "/Editor/_GUI"; } }
      public static string SkinPath          { get {return GuiPath         + "/uScriptDefault"; } }
      public static string Gizmos            { get {return uScriptEditor    + "/Editor/_Gizmos"; } }
   
      public static string RelativePath(string absolutePath)
      {
         absolutePath = absolutePath.Replace( '\\', '/' );

         if ( absolutePath.StartsWith(UnityEngine.Application.dataPath) )
         {
            return absolutePath.Substring( UnityEngine.Application.dataPath.Length - "Assets".Length );
         }
         else
         {
            return absolutePath;
         }
      }
      public static string RelativePathInAssets(string absolutePath)
      {
         absolutePath = absolutePath.Replace( '\\', '/' );

         if ( absolutePath.StartsWith(UnityEngine.Application.dataPath) )
         {
            return absolutePath.Substring( UnityEngine.Application.dataPath.Length );
         }
         else
         {
            return absolutePath;
         }
      }
   }

   public struct Files
   {
      //uScript files
      public static string SettingsFile                { get { return "uScriptSettings.settings"; } }
      public static string GeneratedComponentExtension { get { return "_Component"; } }
      public static string GeneratedCodeExtension      { get { return ""; } }
      
   }
   
   public static uScriptStyle Style = new uScriptDefaultStyle( );
   public static UnityEngine.Texture2D canvasBackgroundTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/uscript_background.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D nodeDefaultTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/uscript_node_default_color.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D nodeEventTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/uscript_node_event_color.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D nodeVariableTexture = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/uscript_node_variable_color.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D minimapScreenBorder = UnityEditor.AssetDatabase.LoadAssetAtPath(ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/uscript_minimap_screen_border.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D lineTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/icons/uscript_line.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D PointerLineEnd = UnityEditor.AssetDatabase.LoadAssetAtPath( ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/icons/uscript_pointer_line_end.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D ResizeTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( ConstantPaths.RelativePath(ConstantPaths.SkinPath) + "/icons/uscript_icon_resize_comment.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static int   MinResizeX = 60;
   public static int   MinResizeY = 16;
   public static float bezierPenWidth = 1.25f;
   public static float bezierPenWidthSelected = 1.5f;

   public static String[] VariableStyleTypes = 
                                    {
                                       "variable_default",
                                       "variable_string",
                                       "variable_bool",
                                       "variable_float",
                                       "variable_int",
                                       "variable_vector3",
                                       "variable_gameobject",
                                       "variable_object",
                                       "variable_selected"
                                    };
   public static String[] PropertyStyleTypes = 
                                    {
                                       "property_default",
                                       "property_string",
                                       "property_bool",
                                       "property_float",
                                       "property_int",
                                       "property_vector3",
                                       "property_gameobject",
                                       "property_object",
                                       "property_selected"
                                    };
   public static UnityEngine.Color[] LineColors = 
                                    {
                                       new UnityEngine.Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(109.0f/255.0f, 224.0f/255.0f, 120.0f/255.0f),
                                       new UnityEngine.Color(255.0f/255.0f, 58.0f/255.0f, 58.0f/255.0f),
                                       new UnityEngine.Color(72.0f/255.0f, 115.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(0.0f/255.0f, 222.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(243.0f/255.0f, 204.0f/255.0f, 110.0f/255.0f),
                                       new UnityEngine.Color(200.0f/255.0f, 100.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(247.0f/255.0f, 194.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(255.0f/255.0f, 255.0f/255.0f, 196.0f/255.0f)
                                    };

   public static float[] LineWidths = 
                              {
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.0f,
                                 1.25f
                              };
}

