// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorSkinIconViewer.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Based on a free editor script by Zack Aikman called "EditorIconViewer".
//      https://github.com/zaikman/UnityPublic/blob/master/EditorIconViewer.cs
//
//   Like all code under the DetoxDevTools folder, this script is not distributed to the public.
//   It's included in the project for development use only.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Detox.Editor;

using UnityEditor;

using UnityEngine;

public sealed class EditorSkinIconViewer : EditorWindow
{
   private const float SidePanelMinWidth = 150;

   private const float SidePanelMaxWidth = 250;

   private const float ScrollbarWidth = 15;

   private const float SelectionGridPadding = 10;

   private const string UsageString =
      "All of the icons presented in this collection are easily accessible when writing a custom editor script, for both Inspectors and Editor Windows. "
      + "In the OnEnable method of your editor, obtain a copy of the editor's skin with the following:\n\n"
      + "GUISkin _editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);\n\n"
      + "Textures shown in this tool can be retrieved by using their style names, shown at the top of the left-hand panel when you select an icon from the grid. For example:\n\n"
      + "GUILayout.Button(_editorSkin.GetStyle(\"MeTransPlayhead\").normal.background);\n\n"
      + "Or you can simply use the style itself when rendering a control:\n\n"
      + "GUILayout.Button(\"\", _editorSkin.GetStyle(\"MeTransPlayhead\"));\n\n"
      + "If additional style states are available (such as Focused, Hover, or Active), they will appear in the panel when selected.";

   // Icons are categorized by their height, into buckets defined by
   // the two arrays below. The number of thresholds should always exceed
   // the number of group names by one.
   private static readonly float[] IconThresholds = { 0, 9, 25, 35, 100, 99999 };

   private static readonly string[] IconGroupNames = { "Mini", "Small", "Medium", "Large", "X-Large" };

   private List<IconGroup> iconGroups;

   #region Blacklisted Items
   // Names of known style states that have a texture present in the 'background' field but
   // whose icons show up as empty images when renderered.
   private bool hideBlacklistedIcons = true;

   private static readonly HashSet<string> IconBlacklist = new HashSet<string>
                                                              {
                                                                 "PlayerSettingsPlatform",
                                                                 "PreferencesSection",
                                                                 "ProfilerPaneLeftBackground",
                                                                 "flow var 0",
                                                                 "flow var 0 on",
                                                                 "flow var 1",
                                                                 "flow var 1 on",
                                                                 "flow var 2",
                                                                 "flow var 2 on",
                                                                 "flow var 3",
                                                                 "flow var 3 on",
                                                                 "flow var 4",
                                                                 "flow var 4 on",
                                                                 "flow var 5",
                                                                 "flow var 5 on",
                                                                 "flow var 6",
                                                                 "flow var 6 on",
                                                              };
   #endregion

   private GUISkin editorSkin;
   private GUIStyle selectedIcon;
   private Vector2 scrollPos;
   private float drawScale;

   private Texture2D blackTexture;
   private Texture2D whiteTexture;
   private string grabName;
   private Rect grabRect;
   private bool shouldGrab;
   private Rect viewportRect;

   [MenuItem("uScript/Internal/Editor Skin Icon Viewer")]
   internal static void Init()
   {
      var window = GetWindow<EditorSkinIconViewer>(true, "Skin Icons");
      window.position = new Rect(150, 150, 700, 400);
   }

   internal void OnEnable()
   {
      this.editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
      this.scrollPos = Vector2.zero;
      SetSelectedIcon(null);

      iconGroups = new List<IconGroup>();

      for (var i = 0; i < IconGroupNames.Length; ++i)
      {
         var group = new IconGroup();
         group.Name = IconGroupNames[i];

         var minHeight = IconThresholds[i];
         var maxHeight = IconThresholds[i + 1];

         group.IconData = this.editorSkin.customStyles.Where(
            style =>
               {
                  if (style.normal.background == null)
                  {
                     return false;
                  }

                  if (style.normal.background.height <= minHeight || style.normal.background.height > maxHeight)
                  {
                     return false;
                  }

                  if (this.hideBlacklistedIcons && IconBlacklist.Contains(style.name))
                  {
                     return false;
                  }

                  return true;
               }).OrderBy(style => style.normal.background.height).ToArray();

         var maxWidth = @group.IconData.Aggregate<GUIStyle, float>(0, (current, style) => (style.normal.background.width > current) ? style.normal.background.width : current);
         group.MaxWidth = maxWidth;

         iconGroups.Add(group);
      }

      blackTexture = new Texture2D(1, 1);
      blackTexture.SetPixel(0, 0, Color.black);
      blackTexture.Apply();

      whiteTexture = new Texture2D(1, 1);
      whiteTexture.SetPixel(0, 0, Color.white);
      whiteTexture.Apply();
   }

   internal void OnDisable()
   {
      DestroyImmediate(blackTexture);
      DestroyImmediate(whiteTexture);
   }

   internal void OnGUI()
   {
      var sidePanelWidth = CalculateSidePanelWidth();
      GUILayout.BeginArea(new Rect(0, 0, sidePanelWidth, position.height), GUI.skin.box);
      DrawIconDisplay(this.selectedIcon);
      GUILayout.EndArea();

      GUI.BeginGroup(new Rect(sidePanelWidth, 0, position.width - sidePanelWidth, position.height));
      this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, true, true, GUILayout.MaxWidth(position.width - sidePanelWidth));

      for (var i = 0; i < iconGroups.Count; ++i)
      {
         var group = iconGroups[i];
         EditorGUILayout.LabelField(group.Name);
         DrawIconSelectionGrid(group.IconData, group.MaxWidth);

         GUILayout.Space(15);
      }

      GUILayout.EndScrollView();
      GUI.EndGroup();
   }

   private static string GeneratePath(string name)
   {
      var path = uScriptConfig.ConstantPaths.Screenshots;
      Directory.CreateDirectory(path);

      var filePath = string.Format("{0}/{1}", path, string.IsNullOrEmpty(name) ? "ICON" : name);
      var testPath = string.Format("{0}.png", filePath);

      var i = 0;
      while (File.Exists(testPath))
      {
         testPath = string.Format("{0} ({1}).png", filePath, ++i);
      }

      return testPath;
   }

   private float CalculateSidePanelWidth()
   {
      return Mathf.Clamp(position.width * 0.21f, SidePanelMinWidth, SidePanelMaxWidth);
   }

   private void DrawIconDisplay(GUIStyle style)
   {
      if (style == null)
      {
         DrawCenteredMessage("No icon selected");
         GUILayout.FlexibleSpace();
         DrawHelpIcon();
         return;
      }

      var iconTexture = style.normal.background;

      viewportRect = EditorGUILayout.BeginVertical();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label(style.name, EditorStyles.boldLabel);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label("Normal");
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      const int IconOffset = 45;
      var iconWidth = iconTexture.width * this.drawScale;
      var iconHeight = iconTexture.height * this.drawScale;
      var sidePanelWidth = CalculateSidePanelWidth();
      GUI.DrawTexture(new Rect((sidePanelWidth - iconWidth) * 0.5f, IconOffset, iconWidth, iconHeight), iconTexture, ScaleMode.StretchToFill);
      GUILayout.Space(iconHeight + 10);

      EditorGUILayout.BeginHorizontal();
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 1.0f) < 0.0001f, "1x", EditorStyles.miniButtonLeft))
      {
         this.drawScale = 1.0f;
      }
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 1.5f) < 0.0001f, "1.5x", EditorStyles.miniButtonMid))
      {
         this.drawScale = 1.5f;
      }
      if (GUILayout.Toggle(Math.Abs(this.drawScale - 2.0f) < 0.0001f, "2x", EditorStyles.miniButtonRight))
      {
         this.drawScale = 2.0f;
      }
      EditorGUILayout.EndHorizontal();

      GUILayout.Space(10);

      DrawIconStyleState(style.active, "Active");
      DrawIconStyleState(style.hover, "Hover");
      DrawIconStyleState(style.focused, "Focused");

      GUILayout.Space(10);

      var rightAligned = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperRight };

#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
      EditorGUIUtility.LookLikeControls(50);
#else
      EditorGUIUtility.labelWidth = 50;
#endif
      EditorGUILayout.LabelField("Width:", string.Format("{0}px", iconTexture.width), rightAligned, GUILayout.Width(100));
      EditorGUILayout.LabelField("Height:", string.Format("{0}px", iconTexture.height), rightAligned, GUILayout.Width(100));

      this.ExportIconSection(style.name, iconTexture);

      GUILayout.FlexibleSpace();

      DrawHelpIcon();

      EditorGUILayout.EndVertical();
   }

   private void ExportIconSection(string textureName, Texture texture)
   {
      GUILayout.Space(20);

      // Export the image with 8-bit alpha
      var pad1 = 0;
      var pad2 = pad1 * 2;

      if (Event.current.type == EventType.Repaint)
      {
         var panelWidth = viewportRect.width - 7;

         var rect = GUILayoutUtility.GetLastRect();
         rect = new Rect((int)((panelWidth - texture.width) * 0.5f), rect.yMax + pad2, texture.width, texture.height);
         var backgroundRect = new Rect(rect.x - pad1, rect.y - pad1, rect.width + pad2, rect.height + pad2);

         GUI.DrawTexture(backgroundRect, this.blackTexture, ScaleMode.StretchToFill);
         GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill);
         if (pad1 > 0)
         {
            uScriptGUI.DebugBox(backgroundRect);
         }

         rect = new Rect((int)((panelWidth - texture.width) * 0.5f), rect.yMax + pad2, texture.width, texture.height);
         backgroundRect = new Rect(rect.x - pad1, rect.y - pad1, rect.width + pad2, rect.height + pad2);

         GUI.DrawTexture(backgroundRect, this.whiteTexture, ScaleMode.StretchToFill);
         GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill);
         if (pad1 > 0)
         {
            uScriptGUI.DebugBox(backgroundRect);
         }

         backgroundRect.yMin -= rect.height + pad2;
         this.grabRect = backgroundRect;
      }

      GUILayout.Space((texture.height * 2) + (pad2 * 2) + 20);

      if (GUILayout.Button("Save"))
      {
         this.grabName = textureName;
         this.shouldGrab = true;
      }

      if (this.shouldGrab && Event.current.type == EventType.Repaint)
      {
         this.shouldGrab = false;

         var exportTexture = new Texture2D((int)this.grabRect.width, (int)this.grabRect.height, TextureFormat.RGB24, false);
         exportTexture.ReadPixels(
            new Rect((int)this.grabRect.xMin, this.viewportRect.height - (int)this.grabRect.yMax + 16, exportTexture.width, exportTexture.height),
            0,
            0);
         exportTexture.Apply();

         //var path = GeneratePath(grabName);
         //exportTexture.SaveAs(path);

         var pixels = exportTexture.GetPixels32();
         var white = 0;
         var black = pixels.Length / 2;

         var export = new Color32[black];

         for (var i = 0; i < export.Length; i++)
         {
            if (pixels[white].Equals(pixels[black]))
            {
               export[white] = pixels[white];
            }
            else
            {
               var alpha = 1 - ((pixels[white].r - pixels[black].r) / 255f);
               uScriptDebug.Assert(alpha >= 0 && alpha <= 1);

               export[white].r = (byte)(pixels[black].r / alpha);
               export[white].g = (byte)(pixels[black].g / alpha);
               export[white].b = (byte)(pixels[black].b / alpha);
               export[white].a = (byte)(alpha * 255);
            }

            white++;
            black++;
         }

         exportTexture = new Texture2D((int)this.grabRect.width, (int)this.grabRect.height / 2);
         exportTexture.SetPixels32(export);
         exportTexture.Apply();

         var path = GeneratePath(this.grabName);
         exportTexture.SaveAs(path);

         Debug.Log("Exported '" + this.grabName + "' as a 32-bit PNG\n        at '" + path.RelativeProjectPath() + "'.\n");
      }
   }

   private void DrawIconStyleState(GUIStyleState state, string label)
   {
      if (state == null || state.background == null)
      {
         return;
      }

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Label(label);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      GUILayout.Box(state.background);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();
   }

   private void SetSelectedIcon(GUIStyle icon)
   {
      this.selectedIcon = icon;
      this.drawScale = 1.0f;
   }

   private void DrawIconSelectionGrid(GUIStyle[] icons, float maxIconWidth)
   {
      var sidePanelWidth = CalculateSidePanelWidth();
      var count = Mathf.FloorToInt((position.width - sidePanelWidth - ScrollbarWidth) / (maxIconWidth + SelectionGridPadding));
      var selected = GUILayout.SelectionGrid(-1, icons.Select(style => style.normal.background).ToArray(), count, GUI.skin.box);

      if (selected > -1)
      {
         SetSelectedIcon(icons[selected]);
      }
   }

   private void DrawCenteredMessage(string msg)
   {
      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      EditorGUILayout.BeginVertical();
      GUILayout.FlexibleSpace();
      GUILayout.Label(msg);
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndVertical();
      GUILayout.FlexibleSpace();
      EditorGUILayout.EndHorizontal();
   }

   private void DrawHelpIcon()
   {
      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      if (GUILayout.Button(string.Empty, this.editorSkin.GetStyle("CN EntryInfo")))
      {
         EditorUtility.DisplayDialog("Editor Icon Viewer", UsageString, "Ok");
      }
      EditorGUILayout.EndHorizontal();
   }

   public class IconGroup
   {
      public string Name { get; set; }

      public GUIStyle[] IconData { get; set; }

      public float IconWidthThreshold { get; set; }

      public float MaxWidth { get; set; }
   }
}
