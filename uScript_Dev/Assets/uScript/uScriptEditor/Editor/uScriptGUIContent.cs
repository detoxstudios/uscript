using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

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

   private static GUIContent _buttonScriptsRebuildAll;
   public static GUIContent buttonScriptsRebuildAll { get { return _buttonScriptsRebuildAll; } }

   private static GUIContent _buttonScriptsRemoveGenerated;
   public static GUIContent buttonScriptsRemoveGenerated { get { return _buttonScriptsRemoveGenerated; } }

   private static GUIContent _buttonWebDocumentation;
   public static GUIContent buttonWebDocumentation { get { return _buttonWebDocumentation; } }

   private static GUIContent _buttonWebForum;
   public static GUIContent buttonWebForum { get { return _buttonWebForum; } }




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

      _buttonScriptLoad             = new GUIContent("Load",                  "Load this uScript.");
      _buttonScriptNew              = new GUIContent("New",                   "Create a new uScript. The active uScript will be closed automatically.");
      _buttonScriptOpen             = new GUIContent("Open...",               "Open a uScript using the file browser.");
      _buttonScriptReload           = new GUIContent("Reload",                "Reload this uScript.");
      _buttonScriptSave             = new GUIContent("Save",                  "Save this uScript using the specified 'save method'.");
      _buttonScriptSaveAs           = new GUIContent("Save As...",            "Save the current uScript through the file browser using the specified 'save method'.");
      _buttonScriptSaveDebug        = new GUIContent("Debug Save",            "Save the current uScript and generate debug code.");
      _buttonScriptSaveQuick        = new GUIContent("Quick Save",            "Save the current uScript without generating code.");
      _buttonScriptSaveRelease      = new GUIContent("Release Save",          "Save the current uScript and generate code.");
      _buttonScriptSource           = new GUIContent("Source",                "Ping the source file associated with this uScript.");

      _buttonScriptsRebuildAll      = new GUIContent("Rebuild All uScripts",  "Rebuild all uScripts in the scene.");
      _buttonScriptsRemoveGenerated = new GUIContent("Remove Generated Code", "Removes all code generated by uScript.");

      _buttonWebDocumentation       = new GUIContent("Online Reference",      "Open the online uScript reference in the default web browser.");
      _buttonWebForum               = new GUIContent("Forum",                 "Open the online forum in the default web browser.");


      // add images to the GUIContent objects
      if (_currentSkin != GUI.skin.name)
      {
         // the skin has been changed
         _currentSkin = GUI.skin.name;

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
