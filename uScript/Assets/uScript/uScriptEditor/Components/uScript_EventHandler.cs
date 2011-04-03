// uScript uScript_EventHandler.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_EventHandler contains event handeling and configuration code.
//       This does NOT need to be attached to any GameObject in your project.

#define ENABLE_LOG

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AttributeUsage(AttributeTargets.All)]
public class FriendlyName : Attribute
{
   public FriendlyName(string name) { Name = name; }
   public string Name;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeComponentType : Attribute
{
   public NodeComponentType(Type type) { ComponentType = type; }
   public Type ComponentType;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodePath : Attribute
{
   public NodePath(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeLicense : Attribute
{
   public NodeLicense(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeCopyright : Attribute
{
   public NodeCopyright(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeToolTip : Attribute
{
   public NodeToolTip(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeDescription : Attribute
{
   public NodeDescription(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeAuthor : Attribute
{
   public NodeAuthor(string value, string url) { Value = value; URL = url; }
   public string Value;
   public string URL;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeHelp : Attribute
{
   public NodeHelp(string value) { Value = value; }
   public string Value;
}



public class uScriptCode : MonoBehaviour
{
}

public class uScriptEvent : MonoBehaviour
{
}


public abstract class uScriptLogic : ScriptableObject
{
   public virtual void _InternalAwake() { }
   public virtual void _InternalDestroy() { }
   public virtual void _InternalUpdate() { }
}

public class uScriptDebug : MonoBehaviour
{

   public enum Type
   {
      Message,
      Warning,
      Error
   }

   public static void Log(string msgString)
   {
      Log(msgString, Type.Message);
   }

   /// <summary>
   /// Displays a uScript message in Unity's console window.
   /// </summary>
   /// <param name="msgString">Message string to output to the console.</param>
   /// <param name="msgType">Message type to output (0 = message, 1 = warning, 2 = error).</param>
   public static void Log(string msgString, Type msgType)
   {
#if ( ENABLE_LOG )
      string appName = "uScript: ";
      string msgOutput = appName + msgString;

      switch (msgType)
      {
         case Type.Message:
            {
               Debug.Log(msgOutput);
               break;
            }
         case Type.Warning:
            {
               Debug.LogWarning(msgOutput);
               break;
            }
         case Type.Error:
            {
               Debug.LogError(msgOutput);
               break;
            }
         default:
            {
               Debug.Log(msgOutput);
               break;
            }
      }
#endif
   }
}


public struct uScriptConfigBlock
{
   public Type Type;
   public string FriendlyName;
   public string Category;
   public Color Color;
   public string Description;
   public string URL;

   public uScriptConfigBlock(Type type, string friendlyName)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = "";
      Color = new Color(196, 196, 196);
      Description = "";
      URL = "";
   }

   public uScriptConfigBlock(Type type, string friendlyName, string category)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = category;
      Color = new Color(196, 196, 196);
      Description = "";
      URL = "";
   }

   public uScriptConfigBlock(Type type, string friendlyName, string category, Color color)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = category != null ? category : "";
      Color = color;
      Description = "";
      URL = "";
   }

   public uScriptConfigBlock(Type type, string friendlyName, string category, Color color, string description)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = category != null ? category : "";
      Color = color;
      Description = description != null ? description : "";
      URL = "";
   }

   public uScriptConfigBlock(Type type, string friendlyName, string category, Color color, string description, string url)
   {
      Type = type != null ? type : typeof(Type);
      FriendlyName = friendlyName != null ? friendlyName : "";
      Category = category != null ? category : "";
      Color = color;
      Description = description != null ? description : "";
      URL = url != null ? url : "";
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

         return type;
      }
      
      public static Type GetObjectFieldType(Type type)
      {
         if ( null == type ) return type;

         if ( false == typeof(UnityEngine.Object).IsAssignableFrom(type) ) return null;

         foreach (uScriptConfigBlock filter in uScriptConfig.Variables)
         {
            if (filter.Type == type)
            {
               return filter.Type;
            }
         }

         return null;
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

   public abstract int BottomSocketLabelGapSize { get; }
   public abstract int BottomSocketBorderAdjustmentPad { get; }
   public abstract int SideSocketToBottomSocketPad { get; }
   public abstract int BottomSocketLabelGap { get; }
   public abstract int TopPad   { get; }
   public abstract int LeftPad  { get; }
   //public abstract int LeftPadBottom  { get; }
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
      element.padding.top = -12;
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
      element.padding.top = -12;
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
      element.normal.textColor = nodeTextGrey;
      element.border.left = 25;
      element.border.right = 31;
      element.border.top = 25;
      element.border.bottom = 31;
      element.padding.left = 0;
      element.padding.right = 0;
      element.padding.top = 0;
      element.padding.bottom = 0;
      element.fixedHeight = 0;
      element.fixedWidth = 0f;
	   element.alignment = TextAnchor.UpperCenter;
      element.fontStyle = FontStyle.Normal;
	   element.fontSize = 0;
      elementSettings["variable"] = element;


      string assetPath = uScriptConfig.Paths.SkinPath + "/elements";

      System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo( assetPath );
      System.IO.FileInfo [] files = directory.GetFiles( );

      string relativePath = uScriptConfig.Paths.RelativePath(assetPath);

      foreach (System.IO.FileInfo file in files)
      {
         string name = System.IO.Path.GetFileName(file.Name);

         Texture2D styleBackground = AssetDatabase.LoadAssetAtPath(relativePath + "/" + name, typeof(Texture2D)) as Texture2D;
         styleBackground.wrapMode = TextureWrapMode.Clamp;
			
         name = System.IO.Path.GetFileNameWithoutExtension( name );

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
         else if (true == name.Contains("comment") &&
			         false == name.Contains("selected"))
		   {
            key = "comment";
         }
		   else if (true == name.Contains("comment_selected"))
         {
            key = "comment_selected";
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
         GUIStyle style = new GUIStyle( );
         style.name = name;
         style.normal.textColor = Color.black;
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
   }

   public override GUIStyle Get(string name)
   {
      if ( null == name ) name = "";

      if (m_Styles.ContainsKey(name)) return m_Styles[name];

	  //uScriptDebug( "Can not find style: " + name, uScriptDebug.Type.Warning );

      if (false == name.Contains("socket") &&
          true == name.Contains("node") &&
		  false == name.Contains("selected"))
      {
         return m_Styles[ "node_default" ];
      }
		else if (true == name.Contains("node_selected"))
      {
         return m_Styles[ "node_selected" ];
      }
      else if (true == name.Contains("socket"))
      {
         return m_Styles[ "node_default_socket_io" ];
      }
      else if (true == name.Contains("icon"))
      {
         return m_Styles[ "icon_lock_open" ];
      }
      else if (true == name.Contains("comment") &&
			   false == name.Contains("selected"))
      {
         return m_Styles[ "comment" ];
      }
	  else if (true == name.Contains("comment_selected"))
      {
         return m_Styles[ "comment_selected" ];
      }
      else if (true == name.Contains("property"))
      {
         return m_Styles[ "property_default" ];
      }
	  else
	  {
         return m_Styles[ "variable_default" ];
	  }
   }

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
	
	//how many pixels to pad bottom objects from the left of the node // WAS NOT USED
   //public override int LeftPadBottom  { get { return 14; } }

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