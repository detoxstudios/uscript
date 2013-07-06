// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScriptCurrent.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.Collections.Generic;

   using Detox.ScriptEditor;

   using UnityEditor;
   
   using UnityEngine;

   public sealed partial class PanelScript
   {
      private class PanelScriptCurrent
      {
         // === Constants ==================================================================

         // === Fields =====================================================================

         private static ScriptEditorCtrl scriptEditorCtrl;

         private static Dictionary<string, string> scenePaths;

         private string currentSceneName = string.Empty;
         private string scriptFileName = string.Empty;
         private string scriptName = string.Empty;
         private string scriptSceneName = string.Empty;

         private bool sourceMissing;

         // === Constructors ===============================================================

         public PanelScriptCurrent()
         {
            //uScriptInstance = uScript.Instance;
            //scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
         }

         // === Properties =================================================================

         // === Methods ====================================================================

         public void Draw()
         {
            uScriptInstance = uScript.Instance;
            scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

            EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);

            this.EvaluateScriptSceneData();

            this.DrawToolbar();

            var rect = EditorGUILayout.BeginVertical();

            // Context menu must go before any buttons that will appear in the region
            var e = Event.current;
            if (e.type == EventType.ContextClick || (e.type == EventType.MouseUp && e.button == 1))
            {
               if (rect.Contains(e.mousePosition))
               {
                  this.ContextMenuCreate(new Rect(e.mousePosition.x, e.mousePosition.y, 0, 0));
               }
            }

            this.DrawScriptName();
            this.DrawSceneName();
            this.DrawSceneMessage();

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();
         }

         public void RefreshSourceState()
         {
            this.sourceMissing = uScriptGUI.IsGeneratedScriptMissing(this.scriptName);

            GetScenePaths();
         }

         private static void GetScenePaths()
         {
            // TODO: Replace this logic, because it's slow. If we stored the full scene path with the script, this wouldn't be needed.

            scenePaths = new Dictionary<string, string>();

            // get every single one of the files in the Assets folder.
            var files = uScriptGUI.GetFilesFromDirectory(new System.IO.DirectoryInfo(Application.dataPath), "*.unity");

            foreach (var fi in files)
            {
               if (fi.Name.StartsWith("."))
               {
                  // Unity ignores dotfiles
                  continue;
               }

               var obj = AssetDatabase.LoadMainAssetAtPath(uScriptGUI.GetRelativeAssetPath(fi.FullName));
               var path = AssetDatabase.GetAssetPath(obj);
               var name = System.IO.Path.GetFileNameWithoutExtension(path);

               System.Diagnostics.Debug.Assert(name != null, "name != null");

               if (scenePaths.ContainsKey(name))
               {
                  Debug.LogWarning("The project contains multiple scenes with the same name: \"" + name + "\".\n");
               }

               scenePaths.Add(name, path);
            }
         }

         private void CommandSceneAttach()
         {
         }

         private void CommandSceneDetach()
         {
         }

         private void CommandSceneLocate()
         {
            if (scenePaths == null)
            {
               GetScenePaths();
            }

            System.Diagnostics.Debug.Assert(scenePaths != null, "scenePaths should not be null here!");

            if (string.IsNullOrEmpty(this.scriptSceneName))
            {
               return;
            }

            if (scenePaths.ContainsKey(this.scriptSceneName))
            {
               if (uScriptGUI.PingScene(scenePaths[this.scriptSceneName]) == false)
               {
                  Debug.LogWarning("Could not find the scene asset in the Project.\n");
               }
            }
            else
            {
               Debug.LogWarning("The scene does not appear to exist in the project: \"" + this.scriptSceneName + "\".\n");
            }
         }

         private void CommandScriptLocate()
         {
            if (string.IsNullOrEmpty(scriptEditorCtrl.ScriptName))
            {
               return;
            }

            uScriptGUI.PingScript(scriptEditorCtrl.ScriptName);
         }

         private void CommandScriptReload()
         {
            var path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, this.scriptFileName);
            if (path != string.Empty)
            {
               uScriptInstance.OpenScript(path);
            }
         }

         private void CommandScriptSave()
         {
            uScriptInstance.RequestSave(
               uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
               uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
               false);
         }

         private void CommandScriptSaveAs()
         {
            uScriptInstance.RequestSave(
               uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
               uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
               true);
         }

         private void CommandScriptSaveDebug()
         {
            uScriptInstance.RequestSave(false, true, false);
         }

         private void CommandScriptSaveQuick()
         {
            uScriptInstance.RequestSave(true, false, false);
         }

         private void CommandScriptSaveRelease()
         {
            uScriptInstance.RequestSave(false, false, false);
         }

         private void CommandSourceLocate()
         {
            this.sourceMissing = uScriptGUI.PingGeneratedScript(this.scriptName) == false;
         }

         private void CommandSourceRemove()
         {
         }

         private void ContextMenuCreate(Rect rect)
         {
            var menu = new GenericMenu();

            //var saveLabel = uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
            //                   ? "Quick Save"
            //                   : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
            //                         ? "Debug Save"
            //                         : "Release Save");

            menu.AddItem(new GUIContent("Save"), false, this.CommandScriptSave);
            menu.AddItem(new GUIContent("Save/Quick"), false, this.CommandScriptSaveQuick);
            menu.AddItem(new GUIContent("Save/Debug"), false, this.CommandScriptSaveDebug);
            menu.AddItem(new GUIContent("Save/Release"), false, this.CommandScriptSaveRelease);
            menu.AddItem(new GUIContent("Save As..."), false, this.CommandScriptSaveAs);
            menu.AddSeparator(string.Empty);

            // RELOAD
            if (scriptEditorCtrl.IsDirty)
            {
               menu.AddItem(new GUIContent("Reload"), false, this.CommandScriptReload);
            }
            else
            {
               menu.AddDisabledItem(new GUIContent("Reload"));
            }

            menu.AddSeparator(string.Empty);

            // SCENE
            if (string.IsNullOrEmpty(this.scriptSceneName))
            {
               menu.AddDisabledItem(new GUIContent("Scene/Locate in Project"));
            }
            else
            {
               menu.AddItem(new GUIContent("Scene/Locate in Project"), false, this.CommandSceneLocate);
            }

            menu.AddDisabledItem(new GUIContent("Scene/Attach to Script"));
            //menu.AddItem(new GUIContent("Scene/Attach to Script"), false, this.CommandSceneAttach);
            menu.AddDisabledItem(new GUIContent("Scene/Detach from Script"));
            //menu.AddItem(new GUIContent("Scene/Detach from Script"), false, this.CommandSceneDetach);
            menu.AddSeparator(string.Empty);
            
            // SOURCE
            if (this.sourceMissing)
            {
               menu.AddDisabledItem(new GUIContent("Source/Locate in Project"));
               menu.AddDisabledItem(new GUIContent("Source/Remove from Project"));
            }
            else
            {
               menu.AddItem(new GUIContent("Source/Locate in Project"), false, this.CommandSourceLocate);
               menu.AddDisabledItem(new GUIContent("Source/Remove from Project"));
               //menu.AddItem(new GUIContent("Source/Remove from Project"), false, this.CommandSourceRemove);
            }

            if (rect.width > 0)
            {
               menu.DropDown(rect);
            }
            else
            {
               menu.ShowAsContext();
            }

            Event.current.Use();
         }

         private void DrawSceneMessage()
         {
            if (this.scriptSceneName == string.Empty)
            {
               GUILayout.Label(Content.MessageNoScene, Style.ScriptMessage);
            }
            else if (this.scriptSceneName != this.currentSceneName)
            {
               GUILayout.Label(Content.MessageWrongScene, Style.ScriptMessage);
            }
            else
            {
               GUILayout.Space(2);
            }
         }

         private void DrawSceneName()
         {
            GUILayout.Label(GUIContent.none, GUILayout.Height(Content.IconScriptLogo.height));

            // No GUILayout beyong this point, and ignore all non-left mouse clicks
            if (Event.current.type == EventType.Layout || (Event.current.isMouse && Event.current.button != 0))
            {
               return;
            }

            var sceneRect = GUILayoutUtility.GetLastRect();
            var commandRect = sceneRect;

            // Script icon
            commandRect.xMin = commandRect.xMax - 44;
            commandRect.y -= 1;
            commandRect.width = 24;
            GUI.DrawTexture(commandRect, Content.IconSourceType, ScaleMode.ScaleToFit);

            // State icon
            //if (this.IsScriptNew)
            //{
            //   this.sourceMissing = true;
            //}

            var stateButtonContent = this.sourceMissing
               ? Content.ButtonScriptSourceMissing
               : (uScriptInstance.IsStale(this.scriptName)
                  ? Content.ButtonScriptSourceStale
                  : (uScriptInstance.HasDebugCode(this.scriptName)
                     ? Content.ButtonScriptSourceDebug
                     : Content.ButtonScriptSourceRelease));

            commandRect.x += commandRect.width;
            commandRect.width = stateButtonContent.image.width + 2;
            commandRect.height = stateButtonContent.image.height + 2;

            sceneRect.width -= 56;

            if (GUI.Button(commandRect, stateButtonContent, Style.ButtonSourceState))
            {
               this.CommandSourceLocate();
            }

            // Scene icon
            GUI.Label(sceneRect, Content.IconUnityScene, GUIStyle.none);

            // Scene name
            sceneRect.xMin += Content.IconUnityScene.width + 4;
            var label = string.IsNullOrEmpty(this.scriptSceneName) ? "(none)" : this.scriptSceneName;
            var isScriptAttachToScene = this.scriptSceneName == this.currentSceneName;

            if (GUI.Button(
               sceneRect,
               Ellipsis.Compact(label, Style.ButtonSceneName, sceneRect, Ellipsis.Format.Middle),
               isScriptAttachToScene || this.scriptSceneName == string.Empty ? Style.ButtonSceneName : Style.ButtonSceneNameError))
            {
               this.CommandSceneLocate();
            }
         }

         private void DrawScriptName()
         {
            GUILayout.Label(GUIContent.none, GUILayout.Height(Content.IconScriptLogo.height));

            // No GUILayout beyong this point, and ignore all non-left mouse clicks
            if (Event.current.type == EventType.Layout || (Event.current.isMouse && Event.current.button != 0))
            {
               return;
            }

            var nameRect = GUILayoutUtility.GetLastRect();

            // Script Icon
            GUI.Label(nameRect, Content.IconScriptLogo, GUIStyle.none);

            nameRect.xMin += Content.IconScriptLogo.width + 4;

            System.Diagnostics.Debug.Assert(scriptEditorCtrl != null, "scriptEditorCtrl is null");
            var label = string.Format(
               "{0}{1}",
               string.IsNullOrEmpty(this.scriptFileName) ? "(new)" : this.scriptName,
               scriptEditorCtrl.IsDirty ? " *" : string.Empty);

            // Script Name
            if (GUI.Button(
               nameRect, Ellipsis.Compact(label, Style.ButtonScriptName, nameRect, Ellipsis.Format.Middle), Style.ButtonScriptName))
            {
               this.CommandScriptLocate();
            }
         }

         private void DrawToolbar()
         {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            GUILayout.Label("Current Graph", uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            this.DrawToolbarButtons();

            EditorGUILayout.EndHorizontal();
         }

         private void DrawToolbarButtons()
         {
            var rect = EditorGUILayout.BeginHorizontal();

            // Save button
            var saveButtonContent = uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                                       ? uScriptGUIContent.buttonScriptSaveQuick
                                       : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                                          ? uScriptGUIContent.buttonScriptSaveDebug
                                          : uScriptGUIContent.buttonScriptSaveRelease);

            if (GUILayout.Button(saveButtonContent, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(uScriptGUIContent.buttonScriptSaveRelease).x)))
            {
               uScriptInstance.RequestSave(
                  uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                  uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
                  false);
            }

            // Miscellaneous file commands
            var iconScriptCommands = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle("PaneOptions").normal.background;
            if (GUILayout.Button(iconScriptCommands, Style.ButtonToolbarDropDown))
            {
               this.ContextMenuCreate(rect);
            }

            EditorGUILayout.EndHorizontal();
         }

         private void EvaluateScriptSceneData()
         {
            if (this.scriptFileName != scriptEditorCtrl.ScriptName)
            {
               this.scriptFileName = scriptEditorCtrl.ScriptName;
               this.scriptName = System.IO.Path.GetFileNameWithoutExtension(this.scriptFileName);
               this.sourceMissing = false;
            }

            if (string.IsNullOrEmpty(this.scriptFileName))
            {
               this.scriptFileName = string.Empty;
               this.sourceMissing = true;
            }

            this.scriptSceneName = scriptEditorCtrl.ScriptEditor.SceneName;

            //if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(this.scriptFileName))
            //{
            //   if (string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[this.scriptFileName].m_SceneName) == false)
            //   {
            //      this.scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[this.scriptFileName].m_SceneName;
            //   }
            //}

            this.currentSceneName = System.IO.Path.GetFileNameWithoutExtension(EditorApplication.currentScene);
         }

         // === Structs ====================================================================

         // === Classes ====================================================================

         private static class Content
         {
            static Content()
            {
               ButtonScriptSourceRelease = new GUIContent(
                  uScriptGUI.GetTexture("iconScriptStatusRelease"),
                  "Ping the source file associated with this uScript.");
               
               ButtonScriptSourceDebug = new GUIContent(
                  uScriptGUI.GetTexture("iconScriptStatusDebug"),
                  ButtonScriptSourceRelease.tooltip + " This script contains Debug information.");

               ButtonScriptSourceStale = new GUIContent(
                  uScriptGUI.GetTexture("iconScriptStatusMissing"),
                  ButtonScriptSourceRelease.tooltip + " Save using Release or Debug to generate code for this script.");

               ButtonScriptSourceMissing = new GUIContent(
                  uScriptGUI.GetTexture("iconScriptStatusUnknown"),
                  "No source file was found. Save using Release or Debug to generate code for this script.");

               MessageNoScene = new GUIContent("This script is not attached to any scene. It may be used with Prefabs or as a Nested Script.");
               MessageWrongScene = new GUIContent("This uScript file was previously attached to a different Unity Scene. It may not be compatible with the current Unity Scene, and may not run correctly, if edited while this scene is open.");

               //IconScriptFile = uScriptGUI.GetTexture("iconScriptFile01");
               IconScriptLogo = uScriptGUI.GetTexture("iconScriptFile02");
               IconSourceType = EditorGUIUtility.FindTexture("cs Script Icon");
               IconUnityScene = uScriptGUI.GetSkinnedTexture("UnityScene");
            }

            public static GUIContent ButtonScriptSourceDebug { get; private set; }

            public static GUIContent ButtonScriptSourceMissing { get; private set; }

            public static GUIContent ButtonScriptSourceRelease { get; private set; }

            public static GUIContent ButtonScriptSourceStale { get; private set; }

            public static Texture2D IconScriptLogo { get; private set; }

            public static Texture2D IconSourceType { get; private set; }

            public static Texture2D IconUnityScene { get; private set; }

            public static GUIContent MessageNoScene { get; private set; }

            public static GUIContent MessageWrongScene { get; private set; }
         }

         private static class Style
         {
            static Style()
            {
               ButtonSceneName = new GUIStyle(EditorStyles.label)
               {
                  border = new RectOffset(6, 6, 4, 4),
                  active = { background = GUI.skin.button.active.background }
               };

               ButtonSceneNameError = new GUIStyle(ButtonSceneName)
               {
                  normal = { textColor = Color.red }
               };

               ButtonScriptName = new GUIStyle(EditorStyles.boldLabel)
               {
                  border = new RectOffset(6, 6, 4, 4),
                  active = { background = GUI.skin.button.active.background }
               };

               ButtonSourceState = new GUIStyle
               {
                  border = new RectOffset(6, 6, 4, 4),
                  padding = new RectOffset(1, 1, 1, 1),
                  active = { background = GUI.skin.button.active.background }
               };

               ButtonToolbarDropDown = new GUIStyle(EditorStyles.toolbarButton) { contentOffset = new Vector2(0, 2) };

               ScriptMessage = new GUIStyle(EditorStyles.miniLabel) { margin = { left = 24 }, wordWrap = true };
            }

            public static GUIStyle ButtonSceneName { get; private set; }

            public static GUIStyle ButtonSceneNameError { get; private set; }

            public static GUIStyle ButtonScriptName { get; private set; }

            public static GUIStyle ButtonSourceState { get; private set; }

            public static GUIStyle ButtonToolbarDropDown { get; private set; }

            public static GUIStyle ScriptMessage { get; private set; }
         }
      }
   }
}
