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
            new uScriptConfigBlock( typeof(UnityEngine.AudioClip), "Audio Clip", "Variables" ),
         };
      }
   }

   //public static uScriptConfigBlock [] Filters
   //{
   //   get
   //   {
   //      return new uScriptConfigBlock []
   //      {
   //         // Nodes
   //         // Action
   //         // Action/Audio
   //         new uScriptConfigBlock( typeof(uScriptAct_SetActiveAudioListener), "Set Active AudioListener", "Action/Audio", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Action/Camera
   //         new uScriptConfigBlock( typeof(uScriptAct_SwitchCamera), "Switch Camera", "Action/Cameras", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetCameraDepth), "Set Camera Depth", "Action/Cameras", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Action/Events
   //         new uScriptConfigBlock( typeof(uScriptAct_OnKeyPressFilter), "OnKeyPress Event Filter", "Action/Events", UnityEngine.Color.grey, "Allows you to listen for a specific key code when used with InKeyPressed event.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScript_Triggers), "Trigger", "Action/Events", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         //Action/GameObjects
   //         new uScriptConfigBlock( typeof(uScriptAct_AttachScript), "Attach Script", "Action/GameObjects", UnityEngine.Color.grey, "Allows you to attach a script to a GameObject at runtime.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_AttachToGameObject), "Attach To GameObject", "Action/GameObjects", UnityEngine.Color.grey, "Attaches one GameObject to anther, creating a parent/child relationship.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Destroy), "Destroy", "Action/GameObjects", UnityEngine.Color.grey, "Destroys the target GameObject. Can optionally set a delay.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_DestroyComponent), "Destory Component", "Action/GameObjects", UnityEngine.Color.grey, "Removes the specified Component from then target GameObject. Can optionally set a delay.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_GetDistance), "Get Distance", "Action/GameObjects", UnityEngine.Color.grey, "Returns the distance between two GameObjects as a float.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_GetPositionAndRotation), "Get Position and Rotation", "Action/GameObjects", UnityEngine.Color.grey, "Gets the position and rotation (in quaternion and euler angle formats) of a GameObject.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_LookAt), "Look At", "Action/GameObjects", UnityEngine.Color.grey, "Tells a GameObject to look at another GameObject transform or Vector3 position.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_MoveToLocation), "Move To Location", "Action/GameObjects", UnityEngine.Color.grey, "Moves a GameObject to a Vector3 Location. Can optionally Lerp.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_PlayAnimation), "Play Animation", "Action/GameObjects", UnityEngine.Color.grey, "Play the specified animation on the target object.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetGameObjectEulerAngles), "Set Euler Angles", "Action/GameObjects", UnityEngine.Color.grey, "Sets the world coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees (0-360 degrees).", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetGameObjectPosition), "Set Position", "Action/GameObjects", UnityEngine.Color.grey, "Sets the position (Vector3) of a GameObject as world coordinates.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SpawnPrefab), "Spawn Prefab", "Action/GameObjects", UnityEngine.Color.grey, "Create (instantiate) an instance of a Prefab at the specified spawn point GameObject at runtime (must be in the Resources folder structure).", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Teleport), "Teleport", "Action/GameObjects", UnityEngine.Color.grey, "Causes the targeted GameObject to be relocated to the destination GameObject.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Action/Math
   //         new uScriptConfigBlock( typeof(uScriptAct_AddFloat), "Add Float", "Action/Math", UnityEngine.Color.grey, "Adds two float variables together and returns the result.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_AddInt), "Add Int", "Action/Math", UnityEngine.Color.grey, "Adds two integer variables together and returns the result.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_AddVector3), "Add Vector3", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_AddVector4), "Add Vector4", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_ConvertVariable), "Convert Variable", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_DivideFloat), "Divide Float", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_DivideInt), "Divide Int", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_GetStringLength), "Get StringLength", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_GetVector3Components), "Get Vector3 Components", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_GetVector4Components), "Get Vector4 Components", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertBool), "Invert Bool", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertFloat), "Invert Float", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertInt), "Invert Int", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertString), "Invert String", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertVector3), "Invert Vector3", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_InvertVector4), "Invert Vector4", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_MultiplyFloat), "Multiply Float", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_MultiplyInt), "Multiply Int", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetVector3Components), "Set Vector3 Components", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetVector4Components), "Set Vector4 Components", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SubtractFloat), "Subtract Float", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SubtractInt), "Subtract Int", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SubtractVector3), "Subtract Vector3", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SubtractVector4), "Subtract Vector4", "Action/Math", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   
   //         // Action/Misc
   //         new uScriptConfigBlock( typeof(uScriptAct_Concatenate), "Concatenate", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_CountTime), "Count Time", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Delay), "Delay", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Gate), "Gate", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Log), "Log", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Action/Particles

   //         // Action/Physics
   //         new uScriptConfigBlock( typeof(uScriptAct_GetRigidbodyVelocity), "Get Rigidbody Velocity", "Action/Physics", UnityEngine.Color.grey, "Gets the velocity of a GameObject's Rigidbody as a Vector3.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_Raycast), "Raycast", "Action/Physics", UnityEngine.Color.grey, "Performs a ray trace from the starting point to the end point, determines if anything was hit along the way, and fires the associated output link.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetRigidbodyVelocity), "Set Rigidbody Velocity", "Action/Physics", UnityEngine.Color.grey, "Sets the velocity of a GameObject's Rigidbody as a Vector3.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
            
   //         // Action/Player

   //         // Action/Scene

   //         // Action/Set Variable
   //         new uScriptConfigBlock( typeof(uScriptAct_SetBool), "Bool", "Action/Set Variable", UnityEngine.Color.grey, "Sets a Bool to the definded value.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetFloat), "Float", "Action/Set Variable", UnityEngine.Color.grey, "Sets a Float to the defined value.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetGameObject), "GameObject", "Action/Set Variable", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetInt), "Int", "Action/Set Variable", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetString), "String", "Action/Set Variable", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetVector3), "Vector3", "Action/Set Variable", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptAct_SetVector4), "Vector4", "Action/Set Variable", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Action/Switch

   //         // Action/Toggle
   //         new uScriptConfigBlock( typeof(uScriptAct_Toggle), "Toggle", "Action/Misc", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Conditions
   //         // Conditions/Comparison
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareBool), "Bool", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareFloat), "Float", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareGameObjects), "GameObjects", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareInt), "Int", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareString), "String", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareVector3), "Vector3", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CompareVector4), "Vector4", "Conditions/Compare", UnityEngine.Color.grey, "NEED DESCRIPTION", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_CheckDistance), "Check Distance", "Conditions", UnityEngine.Color.grey, "Checks the distance of two GameObjects and fires the appropriate output.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),

   //         // Conditions/Counter
   //         new uScriptConfigBlock( typeof(uScriptCon_IntCounter), "Int", "Conditions/Counter", UnityEngine.Color.grey, "Increments the first attached integer variable and then performs a comparison with the second attached integer variable and fires the appropriate output links based on that comparison.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
   //         new uScriptConfigBlock( typeof(uScriptCon_FloatCounter), "Float", "Conditions/Counter", UnityEngine.Color.grey, "Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output links based on that comparison.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
            
   //         // Conditions/Switch

   //         // Debug
   //         new uScriptConfigBlock( typeof(uScriptAct_PrintList), "Print List [Debug]", "Debug", UnityEngine.Color.red, "Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output links based on that comparison.", "http://www.detoxstudios.com:8080/display/UT/Visual+Scriptor" ),
                        
   //      };
   //   }
   //}

   public static Type [] Exclude
   {
      get
      {
         return new Type[]
         {
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