// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScriptCurrent.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using Detox.ScriptEditor;

   using UnityEditor;
   
   using UnityEngine;

   public sealed partial class PanelScript
   {
      private class PanelScriptCurrent
      {
         private static ScriptEditorCtrl scriptEditorCtrl;

         private string currentSceneName = string.Empty;

         private string graphFile = string.Empty;
         private string graphFileName = string.Empty;
         private string graphSceneName = string.Empty;

         private bool sourceMissing;

         public void Draw(PanelScript parent)
         {
            var uScriptInstance = uScript.WeakInstance;

            if (uScriptInstance != null)
            {
               scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

               EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);

               this.EvaluateScriptSceneData();

               this.DrawToolbar(parent);

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

               this.DrawGraphName();
               this.DrawSceneName();
               this.DrawSceneMessage();

               EditorGUILayout.EndVertical();

               EditorGUILayout.EndVertical();
            }
         }

         public void RefreshSourceState()
         {
            this.sourceMissing = uScriptGUI.IsGeneratedScriptMissing(this.graphFile);
         }

         private void CommandGraphLocate()
         {
            uScriptGUI.PingProjectGraph(uScriptBackgroundProcess.GraphInfoList[this.graphFileName].GraphPath);
         }

         private void CommandGraphReload()
         {
            uScript.Instance.OpenGraph(uScriptBackgroundProcess.GraphInfoList[this.graphFileName].GraphPath, false);
         }

         private void CommandGraphSave()
         {
            uScript.Instance.RequestSave(
               Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
               Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
               false, false);
         }

         private void CommandGraphSaveAs()
         {
            uScript.Instance.RequestSave(
               Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
               Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
               true, false);
         }

         private void CommandGraphSaveDebug()
         {
            uScript.Instance.RequestSave(false, true, false, false);
         }

         private void CommandGraphSaveQuick()
         {
            uScript.Instance.RequestSave(true, false, false, false);
         }

         private void CommandGraphSaveRelease()
         {
            uScript.Instance.RequestSave(false, false, false, false);
         }

         private void CommandSceneLocate()
         {
            uScriptGUI.PingProjectScene(this.graphSceneName);
         }

         private void CommandSourceLocate()
         {
            this.sourceMissing = uScriptGUI.PingProjectScript(this.graphFileName) == false;
         }

         private void ContextMenuCreate(Rect rect)
         {
            var menu = new GenericMenu();

            //var saveLabel = Preferences.SaveMethod == Preferences.SaveMethodType.Quick
            //                   ? "Quick Save"
            //                   : (Preferences.SaveMethod == Preferences.SaveMethodType.Debug
            //                         ? "Debug Save"
            //                         : "Release Save");

            menu.AddItem(new GUIContent("Save"), false, this.CommandGraphSave);
            menu.AddItem(new GUIContent("Save/Quick"), false, this.CommandGraphSaveQuick);
            menu.AddItem(new GUIContent("Save/Debug"), false, this.CommandGraphSaveDebug);
            menu.AddItem(new GUIContent("Save/Release"), false, this.CommandGraphSaveRelease);
            menu.AddItem(new GUIContent("Save As..."), false, this.CommandGraphSaveAs);
            menu.AddSeparator(string.Empty);

            // RELOAD
            if (scriptEditorCtrl.IsDirty)
            {
               menu.AddItem(new GUIContent("Reload"), false, this.CommandGraphReload);
            }
            else
            {
               menu.AddDisabledItem(new GUIContent("Reload"));
            }

            menu.AddSeparator(string.Empty);

            // SCENE
            if (string.IsNullOrEmpty(this.graphSceneName))
            {
               menu.AddDisabledItem(new GUIContent("Scene/Locate in Project"));
            }
            else
            {
               menu.AddItem(new GUIContent("Scene/Locate in Project"), false, this.CommandSceneLocate);
            }

            //menu.AddDisabledItem(new GUIContent("Scene/Attach to Script"));
            //menu.AddItem(new GUIContent("Scene/Attach to Script"), false, this.CommandSceneAttach);
            //menu.AddDisabledItem(new GUIContent("Scene/Detach from Script"));
            //menu.AddItem(new GUIContent("Scene/Detach from Script"), false, this.CommandSceneDetach);
            menu.AddSeparator(string.Empty);
            
            // SOURCE
            if (this.sourceMissing)
            {
               menu.AddDisabledItem(new GUIContent("Source/Locate in Project"));
               ////menu.AddDisabledItem(new GUIContent("Source/Remove from Project"));
            }
            else
            {
               menu.AddItem(new GUIContent("Source/Locate in Project"), false, this.CommandSourceLocate);
               ////menu.AddDisabledItem(new GUIContent("Source/Remove from Project"));
               ////menu.AddItem(new GUIContent("Source/Remove from Project"), false, this.CommandSourceRemove);
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

         private void DrawGraphName()
         {
            GUILayout.Label(GUIContent.none, GUILayout.Height(Content.IconScriptLogo.height));

            // No GUILayout beyond this point, and ignore all non-left mouse clicks
            if (Event.current.type == EventType.Layout || (Event.current.isMouse && Event.current.button != 0))
            {
               return;
            }

            var nameRect = GUILayoutUtility.GetLastRect();

            // Script Icon
            GUI.Label(nameRect, Content.IconScriptLogo, GUIStyle.none);

            nameRect.xMin += Content.IconScriptLogo.width + 4;

            uScriptDebug.Assert(scriptEditorCtrl != null, "scriptEditorCtrl is null");

            //var graphName = string.IsNullOrEmpty(scriptEditorCtrl.ScriptEditor.FriendlyName.Default)
            //   ? this.graphFileName
            //   : scriptEditorCtrl.ScriptEditor.FriendlyName.Default;

            var label = string.Format(
               "{0}{1}",
               string.IsNullOrEmpty(this.graphFile) ? "(new)" : this.graphFileName,
               scriptEditorCtrl.IsDirty ? " *" : string.Empty);

            // Script Name
            if (GUI.Button(
               nameRect, Ellipsis.Compact(label, Style.ButtonScriptName, nameRect, Ellipsis.Format.Middle), Style.ButtonScriptName))
            {
               this.CommandGraphLocate();
            }
         }

         private void DrawSceneMessage()
         {
            if (this.graphSceneName == string.Empty)
            {
               GUILayout.Label(Content.MessageNoScene, Style.ScriptMessage);
            }
            else if (this.graphSceneName != this.currentSceneName)
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
            var uScriptInstance = uScript.WeakInstance;

            if (uScriptInstance != null)
            {
               GUILayout.Label(GUIContent.none, GUILayout.Height(Content.IconScriptLogo.height));

               // No GUILayout beyond this point, and ignore all non-left mouse clicks
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
               var stateButtonContent = this.sourceMissing
                  ? SourceStateContent.Missing
                  : (uScriptInstance.IsStale(this.graphFileName)
                     ? SourceStateContent.Stale
                     : (uScriptInstance.HasDebugCode(this.graphFileName)
                        ? SourceStateContent.Debug
                        : SourceStateContent.Release));

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
               var label = string.IsNullOrEmpty(this.graphSceneName) ? "(none)" : this.graphSceneName;
               var isScriptAttachToScene = this.graphSceneName == this.currentSceneName;

               if (GUI.Button(
                  sceneRect,
                  Ellipsis.Compact(label, Style.ButtonSceneName, sceneRect, Ellipsis.Format.Middle),
                  isScriptAttachToScene || this.graphSceneName == string.Empty ? Style.ButtonSceneName : Style.ButtonSceneNameError))
               {
                  this.CommandSceneLocate();
               }
            }
         }

         private void DrawToolbar(PanelScript parent)
         {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            GUILayout.Label("Current Graph", uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            this.DrawToolbarButtons();

            if (parent.InUScriptPanel)
            {
               if (GUILayout.Button(Content.ButtonPopout, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonPopout).x)))
               {
                  if (uScript.GetUScriptGUIPanelWindow<PanelScript>() == null) uScript.OpenPopOutWindow(parent);
                  uScript.Instance.CommandCanvasShowFileListPanel();
               }
               if (GUILayout.Button(Content.ButtonClose, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonClose).x)))
               {
                  uScript.Instance.CommandCanvasShowFileListPanel();
               }
            }

            EditorGUILayout.EndHorizontal();
         }

         private void DrawToolbarButtons()
         {
            var uScriptInstance = uScript.WeakInstance;

            if (uScriptInstance != null)
            {
               var rect = EditorGUILayout.BeginHorizontal();

               // Save button
               var saveButtonContent = Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                                          ? uScriptGUIContent.buttonScriptSaveQuick
                                          : (Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                                             ? uScriptGUIContent.buttonScriptSaveDebug
                                             : uScriptGUIContent.buttonScriptSaveRelease);

               if (GUILayout.Button(saveButtonContent, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(uScriptGUIContent.buttonScriptSaveRelease).x)))
               {
                  uScriptInstance.RequestSave(
                     Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                     Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
                     false, false);
               }

               // Miscellaneous file commands
               var iconScriptCommands = GUI.skin.FindStyle("PaneOptions").normal.background;
               if (GUILayout.Button(iconScriptCommands, Style.ButtonToolbarDropDown))
               {
                  this.ContextMenuCreate(rect);
               }

               EditorGUILayout.EndHorizontal();
            }
         }

         private void EvaluateScriptSceneData()
         {
            if (this.graphFile != scriptEditorCtrl.ScriptName)
            {
               this.graphFile = scriptEditorCtrl.ScriptName;
               this.sourceMissing = false;
            }

            if (string.IsNullOrEmpty(this.graphFile))
            {
               this.graphFile = string.Empty;
               this.sourceMissing = true;
            }

            this.graphFileName = System.IO.Path.GetFileNameWithoutExtension(this.graphFile);

            this.graphSceneName = scriptEditorCtrl.ScriptEditor.SceneName;

            //if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(this.graphFile))
            //{
            //   if (string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[this.graphFile].SceneName) == false)
            //   {
            //      this.graphSceneName = uScriptBackgroundProcess.s_uScriptInfo[this.graphFile].SceneName;
            //   }
            //}

            UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
            this.currentSceneName = scene.name;
         }

         private static class Content
         {
            static Content()
            {
               MessageNoScene = new GUIContent("This script is not attached to any scene. It may be used with Prefabs or as a Nested Script.");
               MessageWrongScene = new GUIContent("This uScript file was previously attached to a different Unity Scene. It may not be compatible with the current Unity Scene, and may not run correctly, if edited while this scene is open.");

               //IconScriptFile = uScriptGUI.GetTexture("iconScriptFile01");
               IconScriptLogo = uScriptGUI.GetTexture("iconScriptFile02");
               IconSourceType = EditorGUIUtility.FindTexture("cs Script Icon");
               IconUnityScene = uScriptGUI.GetSkinnedTexture("UnityScene");
               ButtonPopout = new GUIContent
               {
                  image = uScriptGUI.GetSkinnedTexture("iconPopout"),
                  tooltip = "Open a standalone window with this panel's contents within it."
               };

               ButtonClose = new GUIContent
               {
                  image = uScriptGUI.GetSkinnedTexture("iconMiniDelete"),
                  tooltip = "Close this panel."
               };
            }

            public static Texture2D IconScriptLogo { get; private set; }

            public static Texture2D IconSourceType { get; private set; }

            public static Texture2D IconUnityScene { get; private set; }

            public static GUIContent MessageNoScene { get; private set; }

            public static GUIContent MessageWrongScene { get; private set; }

            public static GUIContent ButtonPopout { get; private set; }

            public static GUIContent ButtonClose { get; private set; }
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
