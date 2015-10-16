// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorSkinIconViewer.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// <summary>
//   Based on a free editor script by Zack Aikman called "EditorIconViewer".
//      https://github.com/zaikman/UnityPublic/blob/master/EditorIconViewer.cs
//
//   Like all code under the DetoxDevTools folder, this script is not distributed to the public.
//   It's included in the project for development use only.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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

   // Names of known style states that have a texture present in the 'background' field but
   // whose icons show up as empty images when renderered.
   private static readonly bool HideBlacklistedIcons = false;
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

   private List<IconGroup> iconGroups;

   private GUISkin editorSkin;
   private string selectedRow;
   private GUIStyle selectedStyle;
   private Vector2 scrollPos;

   private Texture2D blackTexture;
   private Texture2D whiteTexture;
   private string grabName;
   private Rect grabRect;
   private bool shouldGrab;
   private Rect viewportRect;

   [MenuItem("uScript/Internal/Test Windows/Editor Skin Icon Viewer", false, 200)]
   internal static void Init()
   {
      var window = GetWindow<EditorSkinIconViewer>(true, "Skin Icons");
      window.position = new Rect(150, 150, 700, 400);
   }

   internal void OnEnable()
   {
      //this.editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Game);
      this.editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
      //this.editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene);
      this.scrollPos = Vector2.zero;
      this.SetSelectedStyle(null);

      this.iconGroups = new List<IconGroup>();

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

                  if (HideBlacklistedIcons && IconBlacklist.Contains(style.name))
                  {
                     return false;
                  }

                  return true;
               }).OrderBy(style => style.normal.background.height).ToArray();

         var maxWidth = @group.IconData.Aggregate<GUIStyle, float>(0, (current, style) => (style.normal.background.width > current) ? style.normal.background.width : current);
         group.MaxWidth = maxWidth;

         this.iconGroups.Add(group);
      }

      this.blackTexture = new Texture2D(1, 1);
      this.blackTexture.SetPixel(0, 0, Color.black);
      this.blackTexture.Apply();

      this.whiteTexture = new Texture2D(1, 1);
      this.whiteTexture.SetPixel(0, 0, Color.white);
      this.whiteTexture.Apply();
   }

   internal void OnDisable()
   {
      // ReSharper disable RedundantNameQualifier
      // ReSharper disable ArrangeStaticMemberQualifier
      UnityEngine.Object.DestroyImmediate(this.blackTexture);
      UnityEngine.Object.DestroyImmediate(this.whiteTexture);
      // ReSharper restore ArrangeStaticMemberQualifier
      // ReSharper restore RedundantNameQualifier
   }

   internal void OnGUI()
   {
      var sidePanelWidth = this.CalculateSidePanelWidth();
      GUILayout.BeginArea(new Rect(0, 0, sidePanelWidth, this.position.height), GUI.skin.box);
      this.DrawIconDisplay(this.selectedStyle);
      GUILayout.EndArea();

      GUI.BeginGroup(new Rect(sidePanelWidth, 0, this.position.width - sidePanelWidth, this.position.height));
      this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, true, true, GUILayout.MaxWidth(this.position.width - sidePanelWidth));

      for (var i = 0; i < this.iconGroups.Count; ++i)
      {
         var group = this.iconGroups[i];
         EditorGUILayout.LabelField(group.Name);
         this.DrawIconSelectionGrid(group.IconData, group.MaxWidth);

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
      return Mathf.Clamp(this.position.width * 0.21f, SidePanelMinWidth, SidePanelMaxWidth);
   }

   private void DrawIconDisplayRow(string key, Texture2D texture)
   {
      if (string.IsNullOrEmpty(key) || texture == null)
      {
         return;
      }

      if (string.IsNullOrEmpty(this.selectedRow))
      {
         this.selectedRow = key;
      }

      var backgroundColor = GUI.backgroundColor;

      if (this.selectedRow == key)
      {
         GUI.backgroundColor = new Color(0.8f, 0.8f, 1, 1);
      }

      var rowRect = EditorGUILayout.BeginVertical(EditorStyles.helpBox);
      {
         GUILayout.Label(key);

         if (Event.current.type == EventType.Repaint)
         {
            var lastRect = GUILayoutUtility.GetLastRect();
            var rightAligned = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperRight };
            GUI.Label(lastRect, string.Format("{0} x {1}", texture.width, texture.height), rightAligned);
         }

         GUILayout.Box(texture, GUIStyle.none);
      }
      EditorGUILayout.EndVertical();

      if (GUI.Button(rowRect, string.Empty, GUIStyle.none))
      {
         this.selectedRow = key;
      }

      GUI.backgroundColor = backgroundColor;
   }

   private void DrawIconDisplay(GUIStyle style)
   {
      if (style == null)
      {
         this.DrawCenteredMessage("No icon selected");
         GUILayout.FlexibleSpace();
         this.DrawHelpIcon();
         return;
      }

      this.viewportRect = EditorGUILayout.BeginVertical();

      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.FlexibleSpace();
         GUILayout.Label(string.Format("\"{0}\"", style.name), EditorStyles.boldLabel);
         GUILayout.FlexibleSpace();
      }
      EditorGUILayout.EndHorizontal();

      var backgrounds = new Dictionary<string, Texture2D>
      {
         { "normal", style.normal.background },
         { "onNormal", style.onNormal.background },
         { "hover", style.hover.background },
         { "onHover", style.onHover.background },
         { "active", style.active.background },
         { "onActive", style.onActive.background },
         { "focused", style.focused.background },
         { "onFocused", style.onFocused.background }
      };

      foreach (var kvp in backgrounds.Where(kvp => kvp.Value != null))
      {
         this.DrawIconDisplayRow(kvp.Key, kvp.Value);
      }

      if (string.IsNullOrEmpty(this.selectedRow) == false)
      {
         this.ExportIconSection(string.Format("{0}_{1}", style.name, this.selectedRow), backgrounds[this.selectedRow]);
      }

      GUILayout.FlexibleSpace();

      this.DrawHelpIcon();

      EditorGUILayout.EndVertical();
   }

   private void ExportIconSection(string textureName, Texture texture)
   {
      GUILayout.Space(30);

      // Export the image with 8-bit alpha
      var pad1 = 0;
      var pad2 = pad1 * 2;

      if (Event.current.type == EventType.Repaint)
      {
         var panelWidth = this.viewportRect.width - 7;

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

   private void SetSelectedStyle(GUIStyle style)
   {
      this.selectedStyle = style;
      this.selectedRow = string.Empty;
   }

   private void DrawIconSelectionGrid(GUIStyle[] styles, float maxIconWidth)
   {
      var sidePanelWidth = this.CalculateSidePanelWidth();
      var count = Mathf.FloorToInt((this.position.width - sidePanelWidth - ScrollbarWidth) / (maxIconWidth + SelectionGridPadding));

      var textures = styles.Select(style => style.normal.background as Texture).ToArray();

      var selected = GUILayout.SelectionGrid(-1, textures, count, GUI.skin.box);

      if (selected > -1)
      {
         this.SetSelectedStyle(styles[selected]);
      }
   }

   private void DrawCenteredMessage(string msg)
   {
      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.FlexibleSpace();
         EditorGUILayout.BeginVertical();
         {
            GUILayout.FlexibleSpace();
            GUILayout.Label(msg);
            GUILayout.FlexibleSpace();
         }
         EditorGUILayout.EndVertical();
         GUILayout.FlexibleSpace();
      }
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
