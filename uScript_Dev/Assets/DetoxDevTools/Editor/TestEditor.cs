// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEditor.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the TestEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.DetoxDevTools.Editor
{
   using System.Collections;
   using System.Collections.Generic;
   using System.Reflection;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class TestEditor : EditorWindow
   {
      private readonly List<string> knownNamedTextures = new List<string>
                                                            {
                                                               "AboutWindow.MainHeader",
                                                               "AgeiaLogo",
                                                               "Animation Icon",
                                                               "animationvisibilitytoggleoff",
                                                               "animationvisibilitytoggleon",
                                                               "AudioClip Icon",
                                                               "boo Script Icon",
                                                               "CGProgram Icon",
                                                               "cs Script Icon",
                                                               "DefaultAsset Icon",
                                                               "editicon.sml",
                                                               "Favorite Icon",
                                                               "Favorite",
                                                               "FilterByLabel",
                                                               "FilterByType",
                                                               "FolderFavorite Icon",
                                                               "Font Icon",
                                                               "GameManager Icon",
                                                               "GUISkin Icon",
                                                               "Icon Dropdown",
                                                               "Js Script Icon",
                                                               "js Script Icon",
                                                               "Material Icon",
                                                               "Mesh Icon",
                                                               "MonoLogo",
                                                               "MoveTool On",
                                                               "MoveTool",
                                                               "MovieTexture Icon",
                                                               "PauseButton Anim",
                                                               "PauseButton On",
                                                               "PauseButton",
                                                               "PlayButton Anim",
                                                               "PlayButton On",
                                                               "PlayButton",
                                                               "PlayButtonProfile Anim",
                                                               "PlayButtonProfile On",
                                                               "PlayButtonProfile",
                                                               "preAudioPlayOff",
                                                               "preAudioPlayOn",
                                                               "PrefabNormal Icon",
                                                               "PreTextureAlpha",
                                                               "PreTextureMipMapHigh",
                                                               "PreTextureMipMapLow",
                                                               "PreTextureRGB",
                                                               "Profiler.NextFrame",
                                                               "Profiler.PrevFrame",
                                                               "RotateTool On",
                                                               "RotateTool",
                                                               "ScaleTool On",
                                                               "ScaleTool",
                                                               "SceneAsset Icon",
                                                               "SceneviewAudio",
                                                               "SceneviewFx",
                                                               "SceneviewLighting",
                                                               "Search Icon",
                                                               "SettingsIcon",
                                                               "Shader Icon",
                                                               "StepButton Anim",
                                                               "StepButton On",
                                                               "StepButton",
                                                               "TextAsset Icon",
                                                               "Texture Icon",
                                                               "TreeEditor.AddBranches",
                                                               "TreeEditor.AddLeaves",
                                                               "TreeEditor.Duplicate",
                                                               "TreeEditor.Refresh",
                                                               "TreeEditor.Trash",
                                                               "tree_icon",
                                                               "tree_icon_branch",
                                                               "tree_icon_branch_frond",
                                                               "tree_icon_frond",
                                                               "tree_icon_leaf",
                                                               "UnityEditor.ConsoleWindow",
                                                               "UnityEditor.DebugInspectorWindow",
                                                               //"UnityEditor.GameWindow",
                                                               "UnityEditor.HierarchyWindow",
                                                               "UnityEditor.InspectorWindow",
                                                               //"UnityEditor.ProjectWindow",
                                                               //"UnityEditor.SceneWindow",
                                                               //"UnityEditorInternal.MacroWindow",
                                                               "UnityLogo",
                                                               "ViewToolMove On",
                                                               "ViewToolMove",
                                                               "ViewToolOrbit On",
                                                               "ViewToolOrbit",
                                                               "ViewToolZoom On",
                                                               "ViewToolZoom",
                                                               //"WaitSpin00",
                                                               //"WaitSpin01",
                                                               //"WaitSpin02",
                                                               //"WaitSpin03",
                                                               //"WaitSpin04",
                                                               //"WaitSpin05",
                                                               //"WaitSpin06",
                                                               //"WaitSpin07",
                                                               //"WaitSpin08",
                                                               //"WaitSpin09",
                                                               //"WaitSpin10",
                                                               //"WaitSpin11",
                                                               //"WelcomeScreen.AssetStoreLogo",
                                                               //"WelcomeScreen.MainHeader",
                                                               //"WelcomeScreen.UnityAnswersLogo",
                                                               //"WelcomeScreen.UnityBasicsLogo",
                                                               //"WelcomeScreen.UnityForumLogo",
                                                               //"WelcomeScreen.VideoTutLogo",
                                                               //"_Help",
                                                               //"_Popup",

                                                               // Asset Store
                                                               //"AS Badge New",
                                                               //"AS Badge Delete",
                                                               //"AS Badge Move",
                                                            };


      //private Vector2 nameScrollviewPosition;
      private Vector2 listScrollviewPosition;

      [MenuItem("uScript/Internal/General Purpose Test Editor", false, 501)]
      internal static void Init()
      {
         // Get existing open window or if none, make a new one:
         GetWindow<TestEditor>("Test Editor");
      }

      internal void OnGUI()
      {
         //Debug.Log("Known texture names: " + GetIconGUIContents().Keys.Count + "\n");
         foreach (string key in GetIconGUIContents().Keys)
         {
            if (this.knownNamedTextures.Contains(key) == false)
            {
               //Debug.Log("Found unknown texture name: " + key + "\n");
            }
         }

         this.listScrollviewPosition = EditorGUILayout.BeginScrollView(this.listScrollviewPosition);

         GUILayout.Label(string.Format("IconContent(KNOWN) : {0} styles", this.knownNamedTextures.Count), EditorStyles.boldLabel);

         /*
      foreach (string icon in this.knownNamedTextures)
      {
         EditorGUILayout.BeginHorizontal();
         GUIContent content = IconContent(icon);
         if (content == null)
         {
            GUILayout.Space(20);
         }
         else
         {
            //GUILayout.Box(content, GUILayout.Width(20), GUILayout.Height(20));
            GUILayout.Box(content);
         }

         GUILayout.Label(icon);
         EditorGUILayout.EndHorizontal();
      }
*/

         //GUILayout.Space(20);

         //ICollection keys = GetIconGUIContents().Keys;
         //GUILayout.Label(string.Format("IconContent(KNOWN) : {0} styles", keys.Count), EditorStyles.boldLabel);

         //foreach (string icon in keys)
         //{
         //   EditorGUILayout.BeginHorizontal();
         //   GUIContent content = IconContent(icon);
         //   if (content == null)
         //   {
         //      GUILayout.Space(20);
         //   }
         //   else
         //   {
         //      //GUILayout.Box(content, GUILayout.Width(20), GUILayout.Height(20));
         //      GUILayout.Box(content);
         //   }

         //   GUILayout.Label(icon);
         //   EditorGUILayout.EndHorizontal();
         //}

         GUILayout.Space(20);

         //GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Game);
         //GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector); // "LightSkin"
         //GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene);     // "DarkSkin"
         var skin = GUI.skin;
         GUILayout.Label(string.Format("\"" + skin.name + "\" : {0} styles", skin.customStyles.Length), EditorStyles.boldLabel);

         foreach (GUIStyle style in skin.customStyles)
         {
            EditorGUILayout.BeginHorizontal();

            //GUILayout.Toggle(false, GUIContent.none, style, GUILayout.Width(20), GUILayout.Height(20));
            //GUILayout.Toggle(true, GUIContent.none, style, GUILayout.Width(20), GUILayout.Height(20));

            GUILayout.Label(style.name, GUILayout.Width(200));

            if (Event.current.type == EventType.Repaint)
            {
               Rect r = GUILayoutUtility.GetLastRect();
               r.x += r.width;
               r.width = 20;
               style.Draw(r, "0", false, false, false, false);

               r.x += r.width;
               style.Draw(r, "1", false, false, false, true);

               r.x += r.width;
               style.Draw(r, "2", false, false, true, false);

               r.x += r.width;
               style.Draw(r, "3", false, false, true, true);

               r.x += r.width;
               style.Draw(r, "4", false, true, false, false);

               r.x += r.width;
               style.Draw(r, "5", false, true, false, true);

               r.x += r.width;
               style.Draw(r, "6", false, true, true, false);

               r.x += r.width;
               style.Draw(r, "7", false, true, true, true);

               r.x += r.width;
               style.Draw(r, "8", true, false, false, false);

               r.x += r.width;
               style.Draw(r, "9", true, false, false, true);

               r.x += r.width;
               style.Draw(r, "A", true, false, true, false);

               r.x += r.width;
               style.Draw(r, "B", true, false, true, true);

               r.x += r.width;
               style.Draw(r, "C", true, true, false, false);

               r.x += r.width;
               style.Draw(r, "D", true, true, false, true);

               r.x += r.width;
               style.Draw(r, "E", true, true, true, false);

               r.x += r.width;
               style.Draw(r, "F", true, true, true, true);
            }

            EditorGUILayout.EndHorizontal();
         }

         EditorGUILayout.EndScrollView();
      }

      private static GUIContent IconContent(string name)
      {
         // internal static GUIContent IconContent(string name)

         var mi = typeof(EditorGUIUtility).GetMethod(
            "IconContent", BindingFlags.Static | BindingFlags.NonPublic, null, new System.Type[] { typeof(string) }, null);
         if (mi != null)
         {
            return (GUIContent)mi.Invoke(null, new object[] { (string)name });
         }

         uScriptDebug.Log("Could not find IconContent named \"" + name + "\".", uScriptDebug.Type.Error);
         return null;
      }

      private static Hashtable GetIconGUIContents()
      {
         var fi = typeof(EditorGUIUtility).GetField(
            "s_IconGUIContents", BindingFlags.Static | BindingFlags.NonPublic);

         if (fi != null)
         {
            return (Hashtable)fi.GetValue(null);
         }

         return null;
      }
   }
}
