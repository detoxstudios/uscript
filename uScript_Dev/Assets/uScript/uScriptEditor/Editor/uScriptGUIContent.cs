// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIContent.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   This file contains a collection of custom uScript GUI content for use with uScriptEditor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

public static class uScriptGUIContent
{
   public static GUIContent buttonArrayAdd { get; private set; }

   public static GUIContent buttonArrayClear { get; private set; }

   public static GUIContent buttonArrayDuplicate { get; private set; }

   public static GUIContent buttonArrayInsert { get; private set; }

   public static GUIContent buttonArrayRemove { get; private set; }

   public static GUIContent buttonArraySearch { get; private set; }

   public static GUIContent buttonFileMenu { get; private set; }

   public static GUIContent buttonGridSnap { get; private set; }

   public static GUIContent buttonListCollapse { get; private set; }

   public static GUIContent buttonListExpand { get; private set; }

   public static GUIContent buttonNodeDeleteMissing { get; private set; }

   public static GUIContent buttonNodeFind { get; private set; }

   public static GUIContent buttonNodeFindDeprecated { get; private set; }

   public static GUIContent buttonNodeFixAllDeprecated { get; private set; }

   public static GUIContent buttonNodeSource { get; private set; }

   public static GUIContent buttonNodeToggle { get; private set; }

   public static GUIContent buttonNodeUpgrade { get; private set; }

   public static GUIContent buttonPreferences { get; private set; }

   public static GUIContent buttonSaveModeDebug { get; private set; }

   public static GUIContent buttonSaveModeQuick { get; private set; }

   public static GUIContent buttonSaveModeRelease { get; private set; }

   public static GUIContent buttonScriptExportPNG { get; private set; }

   public static GUIContent buttonScriptLoad { get; private set; }

   public static GUIContent buttonScriptNew { get; private set; }

   public static GUIContent buttonScriptOpen { get; private set; }

   public static GUIContent buttonScriptReload { get; private set; }

   public static GUIContent buttonScriptSave { get; private set; }

   public static GUIContent buttonScriptSaveAs { get; private set; }

   public static GUIContent buttonScriptSaveDebug { get; private set; }

   public static GUIContent buttonScriptSaveQuick { get; private set; }

   public static GUIContent buttonScriptSaveRelease { get; private set; }

   public static GUIContent buttonScriptSource { get; private set; }

   public static GUIContent buttonScriptSourceStale { get; private set; }

   public static GUIContent buttonScriptSourceDebug { get; private set; }

   public static GUIContent buttonScriptUpgradeNodes { get; private set; }

   public static GUIContent buttonScriptsRebuildAll { get; private set; }

   public static GUIContent buttonScriptsRemoveGenerated { get; private set; }

   public static GUIContent buttonWebDocumentation { get; private set; }

   public static GUIContent buttonWebForum { get; private set; }

   public static GUIContent commandReference { get; private set; }

   public static GUIContent favoritePanelCollapse { get; private set; }

   public static GUIContent favoritePanelExpand { get; private set; }

   public static GUIContent iconHelp16 { get; private set; }

   public static GUIContent iconHelp32 { get; private set; }

   public static GUIContent iconInfo16 { get; private set; }

   public static GUIContent iconInfo32 { get; private set; }

   public static GUIContent iconWarn16 { get; private set; }

   public static GUIContent iconWarn32 { get; private set; }

   public static GUIContent iconError16 { get; private set; }

   public static GUIContent iconError32 { get; private set; }

   public static GUIContent messageCompiling { get; private set; }

   public static GUIContent messagePlaying { get; private set; }

   public static GUIContent toolboxBreadcrumbs { get; private set; }

   public static GUIContent[] saveMethodList { get; private set; }

   public static void Init()
   {
      if (buttonScriptNew != null)
      {
         // The content has already been initialized
         return;
      }

      // create the objects
      buttonArrayAdd = new GUIContent("+", "Add a new item to the end of the array.");
      buttonArrayClear = new GUIContent("{ }", "Remove all items from the array.");
      buttonArrayDuplicate = new GUIContent("C", "Insert a copy of this item.");
      buttonArrayInsert = new GUIContent("I", "Insert a new item before this item.");
      buttonArrayRemove = new GUIContent("R", "Remove this item.");
      buttonArraySearch = new GUIContent(string.Empty, "Attempt to locate a GameObject in the project Hierarchy using this string.");

      buttonListCollapse = new GUIContent(string.Empty, "Collapse all node categories.");
      buttonListExpand = new GUIContent(string.Empty, "Expand all node categories.");

      buttonNodeDeleteMissing = new GUIContent(string.Empty, "Delete this missing node.");
      buttonNodeFind = new GUIContent(string.Empty, "Center the canvas on this node.");
      buttonNodeFindDeprecated = new GUIContent(string.Empty, "Center the canvas on the next deprecated node.");
      buttonNodeFixAllDeprecated = new GUIContent("Fix All", "Upgrade all deprecated nodes in this graph. If this graph is assigned to a specific Unity scene, please be sure that scene is open before doing this or you could loose work!");
      buttonNodeSource = new GUIContent("Source", "Ping the source file associated with this node.");
      buttonNodeToggle = new GUIContent(string.Empty, "Toggle socket visibility on this node (Show All or Hide Unused).");
      buttonNodeUpgrade = new GUIContent(string.Empty, "Upgrade this deprecated node.");

      buttonSaveModeDebug = new GUIContent("Debug", "When saved, the generated code will contain debug information.");
      buttonSaveModeQuick = new GUIContent("Quick", "When saved, no code will be generated.");
      buttonSaveModeRelease = new GUIContent("Release", "When saved, the generated code will be free of debug information.");

      buttonScriptExportPNG = new GUIContent("Export to Image (PNG)", "Export the graph to a PNG image. The file is placed in a \"Screenshots\" folder in the root of your Unity project.");
      buttonScriptLoad = new GUIContent("Load", "Load this uScript.");
      buttonScriptNew = new GUIContent("New", "Create a new uScript.  The active uScript will be closed automatically.");
      buttonScriptOpen = new GUIContent("Open...", "Open a uScript using the file browser.");
      buttonScriptReload = new GUIContent("Reload", "Reload this uScript.");
      buttonScriptSave = new GUIContent("Save", "Save this uScript using the specified 'save method'.");
      buttonScriptSaveAs = new GUIContent("Save As...", "Save the current uScript through the file browser using the specified 'save method'.");
      buttonScriptSaveDebug = new GUIContent("Save Debug", "Save the current uScript and generate debug code.");
      buttonScriptSaveQuick = new GUIContent("Save Quick", "Save the current uScript without generating code.");
      buttonScriptSaveRelease = new GUIContent("Save Release", "Save the current uScript and generate code.");
      buttonScriptSource = new GUIContent("Source", "Ping the source file associated with this uScript.");
      buttonScriptSourceStale = new GUIContent("Source", "Ping the source file associated with this uScript.  Save using Release or Debug to generate code for this script.");
      buttonScriptSourceDebug = new GUIContent("Source", "Ping the source file associated with this uScript.  This script contains Debug information.");
      buttonScriptUpgradeNodes = new GUIContent("Upgrade Deprecated Nodes", "Upgrade all deprecated nodes in this graph. If this graph is assigned to a specific Unity scene, please be sure that scene is open before doing this or you could loose work!");

      buttonFileMenu = new GUIContent("File Menu", "Opens the file menu.");
      buttonGridSnap = new GUIContent("Grid Snap", "Toggles grid snapping.");
      buttonPreferences = new GUIContent("Preferences...", "Opens the preferences.");

      saveMethodList = new GUIContent[]
      {
         new GUIContent("Quick Save", "When saved, no code will be generated."),
         new GUIContent("Debug Save", "When saved, the generated code will contain debug information."),
         new GUIContent("Release Save", "When saved, the generated code will be free of debug information.")
      };

      buttonScriptsRebuildAll = new GUIContent("Rebuild All uScripts", "Rebuild all uScripts in the Unity project. For best results, have an empty/blank Unity scene loaded when performing this action. Note: this could take a while if you have many large graphs!");
      buttonScriptsRemoveGenerated = new GUIContent("Remove Generated Code", "Removes all the generated script files created by uScript. For best results, have an empty/blank Unity scene loaded when performing this action. Note: Your uScript graphs will not work until they have been rebuilt/re-saved!");

      buttonWebDocumentation = new GUIContent("Online Reference", "Open the online uScript reference in the default web browser.");
      buttonWebForum = new GUIContent("Forum", "Open the online forum in the default web browser.");

      commandReference = new GUIContent(string.Empty, "Open the Quick Command Reference window.");

      favoritePanelCollapse = new GUIContent(string.Empty, "Collapse this list.");
      favoritePanelExpand = new GUIContent(string.Empty, "Expand this list.");

      messageCompiling = new GUIContent("The Unity Editor is compiling one or more scripts. Please wait.");
      messagePlaying = new GUIContent("The Unity Editor is in play mode!");

      toolboxBreadcrumbs = new GUIContent(string.Empty, "Search for this node in the Toolbox.");

//#if (UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4)
//      iconHelp = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/_Help.png") as Texture2D);
//      iconInfo = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.infoicon.png") as Texture2D);
//      iconInfoSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.infoicon.sml.png") as Texture2D);
//      iconWarning = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.warnicon.png") as Texture2D);
//      iconWarningSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.warnicon.sml.png") as Texture2D);
//      iconError = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.erroricon.png") as Texture2D);
//      iconErrorSmall = new GUIContent(EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.erroricon.sml.png") as Texture2D);
//#else
//      // Use abhorrent reflection to access internal editor textures that were once readily available
//      iconHelp = typeof(EditorGUIUtility).InvokeMember("IconContent", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { "_Help" }) as GUIContent;
//
//      System.Type consoleWindow = Assembly.GetAssembly(typeof(EditorWindow)).GetType("UnityEditor.ConsoleWindow");
//      BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;
//
//      consoleWindow.InvokeMember("LoadIcons", flags | BindingFlags.InvokeMethod, null, null, null);
//      iconInfo = new GUIContent(consoleWindow.GetField("iconInfo", flags).GetValue(null) as Texture2D);
//      iconInfoSmall = new GUIContent(consoleWindow.GetField("iconInfoSmall", flags).GetValue(null) as Texture2D);
//      iconWarning = new GUIContent(consoleWindow.GetField("iconWarn", flags).GetValue(null) as Texture2D);
//      iconWarningSmall = new GUIContent(consoleWindow.GetField("iconWarnSmall", flags).GetValue(null) as Texture2D);
//      iconError = new GUIContent(consoleWindow.GetField("iconError", flags).GetValue(null) as Texture2D);
//      iconErrorSmall = new GUIContent(consoleWindow.GetField("iconErrorSmall", flags).GetValue(null) as Texture2D);
//#endif

      buttonArraySearch.image = uScriptGUI.GetSkinnedTexture("iconMiniSearch");
      buttonListCollapse.image = uScriptGUI.GetSkinnedTexture("iconExpand");
      buttonListExpand.image = uScriptGUI.GetSkinnedTexture("iconCollapse");
      buttonNodeFind.image = uScriptGUI.GetSkinnedTexture("iconMiniSearch");
      buttonNodeFindDeprecated.image = buttonNodeFind.image;
      buttonNodeToggle.image = uScriptGUI.GetSkinnedTexture("iconMiniToggle");
      buttonNodeUpgrade.image = uScriptGUI.GetSkinnedTexture("iconMiniUpgrade");
      buttonNodeDeleteMissing.image = uScriptGUI.GetSkinnedTexture("iconMiniDelete");

      commandReference.image = uScriptGUI.GetSkinnedTexture("iconKeyboard");

      favoritePanelCollapse.image = buttonListCollapse.image;
      favoritePanelExpand.image = buttonListExpand.image;

      iconHelp16 = new GUIContent(uScriptGUI.GetTexture("iconHelp16"));
      iconHelp32 = new GUIContent(uScriptGUI.GetTexture("iconHelp32"));
      iconInfo16 = new GUIContent(uScriptGUI.GetTexture("iconInfo16"));
      iconInfo32 = new GUIContent(uScriptGUI.GetTexture("iconInfo32"));
      iconWarn16 = new GUIContent(uScriptGUI.GetTexture("iconWarn16"));
      iconWarn32 = new GUIContent(uScriptGUI.GetTexture("iconWarn32"));
      iconError16 = new GUIContent(uScriptGUI.GetTexture("iconError16"));
      iconError32 = new GUIContent(uScriptGUI.GetTexture("iconError32"));

      toolboxBreadcrumbs.image = uScriptGUI.GetSkinnedTexture("iconSearch");
   }

   public static void ChangeTooltip(string tooltip)
   {
      buttonWebDocumentation.tooltip = tooltip;
   }

//   public static GUIContent IconContent(string name)
//   {
//      // internal static GUIContent IconContent(string name)
//
//      MethodInfo mi = typeof(EditorGUIUtility).GetMethod("IconContent",
//                                                         BindingFlags.Static | BindingFlags.NonPublic,
//                                                         null,
//                                                         new System.Type[] { typeof(string) },
//                                                         null);
//      if (mi != null)
//      {
//         return (GUIContent)mi.Invoke(null, new object[] { (string)name });
//      }
//
//      uScriptDebug.Log("Could not find IconContent named \"" + name + "\".", uScriptDebug.Type.Error);
//      return null;
//   }
//
//   public static GUIContent TextContent(string name)
//   {
//      // internal static GUIContent TextContent(string name)
//
//      MethodInfo mi = typeof(EditorGUIUtility).GetMethod("TextContent",
//                                                         BindingFlags.Static | BindingFlags.NonPublic,
//                                                         null,
//                                                         new System.Type[] { typeof(string) },
//                                                         null);
//      if (mi != null)
//      {
//         return (GUIContent)mi.Invoke(null, new object[] { (string)name });
//      }
//
//      uScriptDebug.Log("Could not find TextContent named \"" + name + "\".", uScriptDebug.Type.Error);
//      return null;
//   }
}
