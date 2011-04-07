// uScript uScriptConfig.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript's configuration file. Edit settings here to configure the uScript visual scripting tool.

using System;
using System.Collections.Generic;

public partial class uScriptConfig
{
	// What GameObject to create/use for the master uScript object in the scene.
	public static string MasterObjectName = "_uScript";
	
	
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
            new uScriptConfigBlock( typeof(UnityEngine.GameObject), "GameObject", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.GameObject[]), "GameObject List", "Variables/Lists" ),
            new uScriptConfigBlock( typeof(UnityEngine.Camera), "Camera", "Variables" ),
            new uScriptConfigBlock( typeof(UnityEngine.Camera[]), "Camera List", "Variables/Lists" ),           
            new uScriptConfigBlock( typeof(uScript_Triggers), "Trigger Object", "Variables" ),
            new uScriptConfigBlock( typeof(uScript_Global), "Global Events", "Variables" ),
            new uScriptConfigBlock( typeof(uScript_Input), "Input Events", "Variables" ),
         };
      }
   }

   public struct Paths
   {
      //uScriptEditor paths
      public static string RootFolder        { get {return UnityEngine.Application.dataPath + "/uScript";} }
      public static string uScriptNodes      { get {return uScriptEditor + "/Nodes";} }
      public static string ProjectFiles      { get {return RootFolder + "/ProjectFiles";} }
      public static string uScriptEditor     { get {return RootFolder + "/uScriptEditor";} }

      //user paths
      public static string UserScripts       { get {return ProjectFiles     + "/uScripts";} }
      public static string UserNodes         { get {return ProjectFiles     + "/Nodes";} }
      public static string GeneratedScripts  { get {return UserScripts      + "/~GeneratedScripts";} }
      public static string SubsequenceScripts{ get {return GeneratedScripts + "/SubSeq";} }
      public static string GuiPath           { get {return uScriptEditor    + "/Editor/_GUI"; } }
      public static string SkinPath          { get {return GuiPath          + "/uScriptDefault"; } } 
      //public static string TutorialFiles     { get {return RootFolder + "/TutorialFiles";} }
   
      public static string RelativePath(string absolutePath)
      {
         return absolutePath.Substring( UnityEngine.Application.dataPath.Length - "Assets".Length );
      }
   }

   public static uScriptStyle Style = new uScriptDefaultStyle( );
   public static UnityEngine.Texture2D canvasBackgroundTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( Paths.RelativePath(Paths.SkinPath) + "/uscript_background.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D lineTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( Paths.RelativePath(Paths.SkinPath) + "/icons/uscript_line.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D PointerLineEnd = UnityEditor.AssetDatabase.LoadAssetAtPath( Paths.RelativePath(Paths.SkinPath) + "/icons/uscript_pointer_line_end.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static UnityEngine.Texture2D ResizeTexture = UnityEditor.AssetDatabase.LoadAssetAtPath( Paths.RelativePath(Paths.SkinPath) + "/icons/uscript_icon_resize_comment.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
   public static int   MinResizeX = 60;
   public static int   MinResizeY = 16;
   public static float bezierPenWidth = 1.25f;
   public static float bezierPenWidthSelected = 1.5f;

   public static String[] StyleTypes = {
                                       "variable_string",
                                       "variable_bool",
                                       "variable_float",
                                       "variable_int",
                                       "variable_default",
                                       "variable_vector3",
                                       "variable_gameobject",
                                       "variable_object",
                                       "variable_selected"
                                    };
   public static UnityEngine.Color[] LineColors = 
                                    {
                                       new UnityEngine.Color(109.0f/255.0f, 224.0f/255.0f, 120.0f/255.0f),
                                       new UnityEngine.Color(255.0f/255.0f, 58.0f/255.0f, 58.0f/255.0f),
                                       new UnityEngine.Color(72.0f/255.0f, 115.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(0.0f/255.0f, 222.0f/255.0f, 255.0f/255.0f),
                                       new UnityEngine.Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f),
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