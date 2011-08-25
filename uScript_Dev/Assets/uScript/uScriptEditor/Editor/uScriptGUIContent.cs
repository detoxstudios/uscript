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

   private static GUIContent _toolbarButtonNew;
   public static GUIContent toolbarButtonNew
   {
      get { return _toolbarButtonNew; }
   }

   private static GUIContent _toolbarButtonOpen;
   public static GUIContent toolbarButtonOpen
   {
      get { return _toolbarButtonOpen; }
   }

   private static GUIContent _toolbarButtonSave;
   public static GUIContent toolbarButtonSave
   {
      get { return _toolbarButtonSave; }
   }

   private static GUIContent _toolbarButtonSaveAs;
   public static GUIContent toolbarButtonSaveAs
   {
      get { return _toolbarButtonSaveAs; }
   }

   private static GUIContent _toolbarButtonQuickSave;
   public static GUIContent toolbarButtonQuickSave
   {
      get { return _toolbarButtonQuickSave; }
   }

   private static GUIContent _toolbarButtonRebuildAll;
   public static GUIContent toolbarButtonRebuildAll
   {
      get { return _toolbarButtonRebuildAll; }
   }

   private static GUIContent _toolbarButtonRemoveGenerated;
   public static GUIContent toolbarButtonRemoveGenerated
   {
      get { return _toolbarButtonRemoveGenerated; }
   }

   private static GUIContent _toolbarButtonPreferences;
   public static GUIContent toolbarButtonPreferences
   {
      get { return _toolbarButtonPreferences; }
   }

   private static GUIContent _toolbarButtonCollapse;
   public static GUIContent toolbarButtonCollapse
   {
      get { return _toolbarButtonCollapse; }
   }

   private static GUIContent _toolbarButtonExpand;
   public static GUIContent toolbarButtonExpand
   {
      get { return _toolbarButtonExpand; }
   }

   private static GUIContent _toolbarButtonOnlineForum;
   public static GUIContent toolbarButtonOnlineForum
   {
      get { return _toolbarButtonOnlineForum; }
   }

   private static GUIContent _toolbarButtonOnlineReference;
   public static GUIContent toolbarButtonOnlineReference
   {
      get { return _toolbarButtonOnlineReference; }
   }

   private static GUIContent _listMiniSearch;
   public static GUIContent listMiniSearch
   {
      get { return _listMiniSearch; }
   }

   private static GUIContent _listMiniToggle;
   public static GUIContent listMiniToggle
   {
      get { return _listMiniToggle; }
   }

   private static GUIContent _listMiniUpgrade;
   public static GUIContent listMiniUpgrade
   {
      get { return _listMiniUpgrade; }
   }

   private static GUIContent _listMiniDeleteMissing;
   public static GUIContent listMiniDeleteMissing
   {
      get { return _listMiniDeleteMissing; }
   }




   static Texture2D _texture_toolbarButtonCollapse = null;
   static Texture2D _texture_toolbarButtonExpand = null;
   static Texture2D _texture_listMiniSearch = null;
   static Texture2D _texture_listMiniToggle = null;
   static Texture2D _texture_listMiniUpgrade = null;
   static Texture2D _texture_listMiniDeleteMissing = null;




   public static void Init ()
   {
      if (_currentSkin != GUI.skin.name)
      {
         // the skin has been changed
         _currentSkin = GUI.skin.name;

         // reload all custom GUI textures to match the new skin
         string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + _currentSkin + "_";

         _texture_toolbarButtonCollapse = AssetDatabase.LoadAssetAtPath(skinPath + "iconCollapse.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_toolbarButtonExpand = AssetDatabase.LoadAssetAtPath(skinPath + "iconExpand.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_listMiniSearch = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniSearch.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_listMiniToggle = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniToggle.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_listMiniUpgrade = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniUpgrade.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_listMiniDeleteMissing = AssetDatabase.LoadAssetAtPath(skinPath + "iconMiniDelete.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

         // icons only
         _toolbarButtonCollapse = new GUIContent(_texture_toolbarButtonCollapse, "Collapse all node categories.");
         _toolbarButtonExpand = new GUIContent(_texture_toolbarButtonExpand, "Expand all node categories.");

         _listMiniSearch = new GUIContent(_texture_listMiniSearch, "Center the canvas on this node.");
         _listMiniToggle = new GUIContent(_texture_listMiniToggle, "Toggle socket visibility on this node (Show All or Hide Unused).");
         _listMiniUpgrade = new GUIContent(_texture_listMiniUpgrade, "Upgrade this deprecated node.");
         _listMiniDeleteMissing = new GUIContent(_texture_listMiniDeleteMissing, "Delete this missing node.");
      }
      else if (_toolbarButtonNew != null)
      {
         // The content has already been initialized
         return;
      }

      // text only
      _toolbarButtonNew = new GUIContent("New", "Create a new uScript. The active uScript will be closed automatically.");
      _toolbarButtonOpen = new GUIContent("Open...", "Open a uScript using the file browser.");
      _toolbarButtonSave = new GUIContent("Save", "Save the current uScript.");
      _toolbarButtonSaveAs = new GUIContent("Save As...", "Save the current uScript using the file browser.");
      _toolbarButtonQuickSave = new GUIContent("Quick Save", "Save the current uScript without generating code.");
      _toolbarButtonRebuildAll = new GUIContent("Rebuild All uScripts", "Rebuild all uScripts in the scene.");
      _toolbarButtonRemoveGenerated = new GUIContent("Remove Generated Code", "Removes all code generated by uScript.");
      _toolbarButtonPreferences = new GUIContent("Preferences...", "Opens the preferences.");
      _toolbarButtonOnlineForum = new GUIContent("Forum", "Open the online forum in the default web browser.");
      _toolbarButtonOnlineReference = new GUIContent("Online Reference", "Open the online uScript reference in the default web browser.");
   }

   public static void ChangeTooltip (string tooltip)
   {
      _toolbarButtonOnlineReference.tooltip = tooltip;
   }
}
