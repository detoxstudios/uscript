using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;

//
// This file contains a collection of custom uScript GUI content for use with uScriptEditor
// ________________________________________________________________________________________
//

public static class uScriptGUIContent
{
   static string _currentSkin = string.Empty;

   private static GUIContent _buttonArrayAdd;
   public static GUIContent buttonArrayAdd { get { return _buttonArrayAdd; } }

   private static GUIContent _buttonArrayClear;
   public static GUIContent buttonArrayClear { get { return _buttonArrayClear; } }

   private static GUIContent _buttonArrayDuplicate;
   public static GUIContent buttonArrayDuplicate { get { return _buttonArrayDuplicate; } }

   private static GUIContent _buttonArrayInsert;
   public static GUIContent buttonArrayInsert { get { return _buttonArrayInsert; } }

   private static GUIContent _buttonArrayRemove;
   public static GUIContent buttonArrayRemove { get { return _buttonArrayRemove; } }

   private static GUIContent _buttonArraySearch;
   public static GUIContent buttonArraySearch { get { return _buttonArraySearch; } }

   private static GUIContent _buttonListCollapse;
   public static GUIContent buttonListCollapse { get { return _buttonListCollapse; } }

   private static GUIContent _buttonListExpand;
   public static GUIContent buttonListExpand { get { return _buttonListExpand; } }

   private static GUIContent _buttonNodeDeleteMissing;
   public static GUIContent buttonNodeDeleteMissing { get { return _buttonNodeDeleteMissing; } }

   private static GUIContent _buttonNodeFind;
   public static GUIContent buttonNodeFind { get { return _buttonNodeFind; } }

   private static GUIContent _buttonNodeSource;
   public static GUIContent buttonNodeSource { get { return _buttonNodeSource; } }

   private static GUIContent _buttonNodeToggle;
   public static GUIContent buttonNodeToggle { get { return _buttonNodeToggle; } }

   private static GUIContent _buttonNodeUpgrade;
   public static GUIContent buttonNodeUpgrade { get { return _buttonNodeUpgrade; } }

   private static GUIContent _buttonPreferences;
   public static GUIContent buttonPreferences { get { return _buttonPreferences; } }

   private static GUIContent _buttonSaveModeDebug;
   public static GUIContent buttonSaveModeDebug { get { return _buttonSaveModeDebug; } }

   private static GUIContent _buttonSaveModeQuick;
   public static GUIContent buttonSaveModeQuick { get { return _buttonSaveModeQuick; } }

   private static GUIContent _buttonSaveModeRelease;
   public static GUIContent buttonSaveModeRelease { get { return _buttonSaveModeRelease; } }

   private static GUIContent _buttonScriptExportPNG;
   public static GUIContent buttonScriptExportPNG { get { return _buttonScriptExportPNG; } }

   private static GUIContent _buttonScriptLoad;
   public static GUIContent buttonScriptLoad { get { return _buttonScriptLoad; } }

   private static GUIContent _buttonScriptNew;
   public static GUIContent buttonScriptNew { get { return _buttonScriptNew; } }

   private static GUIContent _buttonScriptOpen;
   public static GUIContent buttonScriptOpen { get { return _buttonScriptOpen; } }

   private static GUIContent _buttonScriptReload;
   public static GUIContent buttonScriptReload { get { return _buttonScriptReload; } }

   private static GUIContent _buttonScriptSave;
   public static GUIContent buttonScriptSave { get { return _buttonScriptSave; } }

   private static GUIContent _buttonScriptSaveAs;
   public static GUIContent buttonScriptSaveAs { get { return _buttonScriptSaveAs; } }

   private static GUIContent _buttonScriptSaveDebug;
   public static GUIContent buttonScriptSaveDebug { get { return _buttonScriptSaveDebug; } }

   private static GUIContent _buttonScriptSaveQuick;
   public static GUIContent buttonScriptSaveQuick { get { return _buttonScriptSaveQuick; } }

   private static GUIContent _buttonScriptSaveRelease;
   public static GUIContent buttonScriptSaveRelease { get { return _buttonScriptSaveRelease; } }

   private static GUIContent _buttonScriptSource;
   public static GUIContent buttonScriptSource { get { return _buttonScriptSource; } }

   private static GUIContent _buttonScriptSourceStale;
   public static GUIContent buttonScriptSourceStale { get { return _buttonScriptSourceStale; } }

   private static GUIContent _buttonScriptSourceDebug;
   public static GUIContent buttonScriptSourceDebug { get { return _buttonScriptSourceDebug; } }

   private static GUIContent _buttonScriptUpgradeNodes;
   public static GUIContent buttonScriptUpgradeNodes { get { return _buttonScriptUpgradeNodes; } }

   private static GUIContent _buttonScriptsRebuildAll;
   public static GUIContent buttonScriptsRebuildAll { get { return _buttonScriptsRebuildAll; } }

   private static GUIContent _buttonScriptsRemoveGenerated;
   public static GUIContent buttonScriptsRemoveGenerated { get { return _buttonScriptsRemoveGenerated; } }

   private static GUIContent _buttonWebDocumentation;
   public static GUIContent buttonWebDocumentation { get { return _buttonWebDocumentation; } }

   private static GUIContent _buttonWebForum;
   public static GUIContent buttonWebForum { get { return _buttonWebForum; } }

   private static GUIContent _messageCompiling;
   public static GUIContent messageCompiling { get { return _messageCompiling; } }

   private static GUIContent _messagePlaying;
   public static GUIContent messagePlaying { get { return _messagePlaying; } }

   private static GUIContent _iconHelp;
   public static GUIContent iconHelp { get { return _iconHelp; } }

   private static GUIContent _iconInfo;
   public static GUIContent iconInfo { get { return _iconInfo; } }

   private static GUIContent _iconInfoSmall;
   public static GUIContent iconInfoSmall { get { return _iconInfoSmall; } }

   private static GUIContent _iconWarning;
   public static GUIContent iconWarning { get { return _iconWarning; } }

   private static GUIContent _iconWarningSmall;
   public static GUIContent iconWarningSmall { get { return _iconWarningSmall; } }

   private static GUIContent _iconError;
   public static GUIContent iconError { get { return _iconError; } }

   private static GUIContent _iconErrorSmall;
   public static GUIContent iconErrorSmall { get { return _iconErrorSmall; } }




   public static void Init ()
   {
      if (_buttonScriptNew != null)
      {
         // The content has already been initialized
         return;
      }

      // create the objects
      _buttonArrayAdd               = new GUIContent("+",                     "Add a new item to the end of the array.");
      _buttonArrayClear             = new GUIContent("{ }",                   "Remove all items from the array.");
      _buttonArrayDuplicate         = new GUIContent("C",                     "Insert a copy of this item.");
      _buttonArrayInsert            = new GUIContent("I",                     "Insert a new item before this item.");
      _buttonArrayRemove            = new GUIContent("R",                     "Remove this item.");
      _buttonArraySearch            = new GUIContent(string.Empty,            "Attempt to locate a GameObject in the project Hierarchy using this string.");

      _buttonListCollapse           = new GUIContent(string.Empty,            "Collapse all node categories.");
      _buttonListExpand             = new GUIContent(string.Empty,            "Expand all node categories.");

      _buttonNodeDeleteMissing      = new GUIContent(string.Empty,            "Delete this missing node.");
      _buttonNodeFind               = new GUIContent(string.Empty,            "Center the canvas on this node.");
      _buttonNodeSource             = new GUIContent("Source",                "Ping the source file associated with this node.");
      _buttonNodeToggle             = new GUIContent(string.Empty,            "Toggle socket visibility on this node (Show All or Hide Unused).");
      _buttonNodeUpgrade            = new GUIContent(string.Empty,            "Upgrade this deprecated node.");

      _buttonPreferences            = new GUIContent("Preferences...",        "Opens the preferences.");

      _buttonSaveModeDebug          = new GUIContent("Debug",                 "When saved, the generated code will contain debug information.");
      _buttonSaveModeQuick          = new GUIContent("Quick",                 "When saved, no code will be generated.");
      _buttonSaveModeRelease        = new GUIContent("Release",               "When saved, the generated code will be free of debug information.");

      _buttonScriptExportPNG        = new GUIContent("Export to Image (PNG)", "Export the graph to a PNG image. The file is placed in a \"Screenshots\" folder in the root of your Unity project.");
      _buttonScriptLoad             = new GUIContent("Load",                  "Load this uScript.");
      _buttonScriptNew              = new GUIContent("New",                   "Create a new uScript.  The active uScript will be closed automatically.");
      _buttonScriptOpen             = new GUIContent("Open...",               "Open a uScript using the file browser.");
      _buttonScriptReload           = new GUIContent("Reload",                "Reload this uScript.");
      _buttonScriptSave             = new GUIContent("Save",                  "Save this uScript using the specified 'save method'.");
      _buttonScriptSaveAs           = new GUIContent("Save As...",            "Save the current uScript through the file browser using the specified 'save method'.");
      _buttonScriptSaveDebug        = new GUIContent("Save Debug",            "Save the current uScript and generate debug code.");
      _buttonScriptSaveQuick        = new GUIContent("Save Quick",            "Save the current uScript without generating code.");
      _buttonScriptSaveRelease      = new GUIContent("Save Release",          "Save the current uScript and generate code.");
      _buttonScriptSource           = new GUIContent("Source",                "Ping the source file associated with this uScript.");
      _buttonScriptSourceStale      = new GUIContent("Source",                "Ping the source file associated with this uScript.  Save using Release or Debug to generate code for this script.");
      _buttonScriptSourceDebug      = new GUIContent("Source",                "Ping the source file associated with this uScript.  This script contains Debug information.");
      _buttonScriptUpgradeNodes      = new GUIContent("Upgrade Deprecated Nodes", "Upgrade all deprecated nodes in this graph. If this graph is assigned to a specific Unity scene, please be sure that scene is open before doing this or you could loose work!");

      _buttonScriptsRebuildAll      = new GUIContent("Rebuild All uScripts",  "Rebuild all uScripts in the Unity project. For best results, have an empty/blank Unity scene loaded when performing this action. Note: this could take a while if you have many large graphs!");
      _buttonScriptsRemoveGenerated = new GUIContent("Remove Generated Code", "Removes all the generated script files created by uScript. For best results, have an empty/blank Unity scene loaded when performing this action. Note: Your uScript graphs will not work until they have been rebuilt/re-saved!");

      _buttonWebDocumentation       = new GUIContent("Online Reference",      "Open the online uScript reference in the default web browser.");
      _buttonWebForum               = new GUIContent("Forum",                 "Open the online forum in the default web browser.");

      _messageCompiling = new GUIContent("The Unity Editor is compiling one or more scripts. Please wait.");
      _messagePlaying = new GUIContent("The Unity Editor is in play mode!");

#if (UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4)
      _iconHelp = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/_Help.png") as Texture2D);
      _iconInfo = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.infoicon.png") as Texture2D);
      _iconInfoSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.infoicon.sml.png") as Texture2D);
      _iconWarning = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.warnicon.png") as Texture2D);
      _iconWarningSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.warnicon.sml.png") as Texture2D);
      _iconError = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.erroricon.png") as Texture2D);
      _iconErrorSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.erroricon.sml.png") as Texture2D);
#else
      // Use abhorrent reflection to access internal editor textures that were once readily available
      _iconHelp = typeof(EditorGUIUtility).InvokeMember("IconContent", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { "_Help" }) as GUIContent;

      System.Type consoleWindow = Assembly.GetAssembly(typeof(EditorWindow)).GetType("UnityEditor.ConsoleWindow");
      BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;

      consoleWindow.InvokeMember("LoadIcons", flags | BindingFlags.InvokeMethod, null, null, null);
      _iconInfo = new GUIContent(consoleWindow.GetField("iconInfo", flags).GetValue(null) as Texture2D);
      _iconInfoSmall = new GUIContent(consoleWindow.GetField("iconInfoSmall", flags).GetValue(null) as Texture2D);
      _iconWarning = new GUIContent(consoleWindow.GetField("iconWarn", flags).GetValue(null) as Texture2D);
      _iconWarningSmall = new GUIContent(consoleWindow.GetField("iconWarnSmall", flags).GetValue(null) as Texture2D);
      _iconError = new GUIContent(consoleWindow.GetField("iconError", flags).GetValue(null) as Texture2D);
      _iconErrorSmall = new GUIContent(consoleWindow.GetField("iconErrorSmall", flags).GetValue(null) as Texture2D);
#endif


      // add images to the GUIContent objects
      if (_currentSkin != GUI.skin.name)
      {
         // the skin has been changed
         _currentSkin = GUI.skin.name;

         if (_currentSkin == "SceneGUISkin")
         {
            _currentSkin = "DarkSkin";
         }
         else if (_currentSkin == "InspectorGUISkin")
         {
            _currentSkin = "LightSkin";
         }

         // reload all custom GUI textures to match the new skin
         string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + _currentSkin + "_";

         _buttonArraySearch.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniSearch.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonListCollapse.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconCollapse.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonListExpand.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconExpand.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonNodeFind.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniSearch.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonNodeToggle.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniToggle.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonNodeUpgrade.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniUpgrade.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _buttonNodeDeleteMissing.image = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniDelete.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
      }
   }

   public static void ChangeTooltip (string tooltip)
   {
      _buttonWebDocumentation.tooltip = tooltip;
   }
}
