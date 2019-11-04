// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ReferenceWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Detox.Editor;

using UnityEditor;
using UnityEngine;

public class ReferenceWindow : EditorWindow
{
   // Layout parameters
   private const int WindowHeight = 640;
   private const int WindowWidth = 730;

   private static ReferenceWindow window;

   private bool isFirstRun;
   private bool isProSkin;
   private bool isWindows;
   private int minWidthKey;
   private Vector2 scrollviewPosition;

   // Create the window
   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = GetWindow<ReferenceWindow>(true, "uScript Quick Command Reference", true);
      window.isFirstRun = true;
   }

   public void OnGUI()
   {
      if (this.isFirstRun)
      {
         this.isFirstRun = false;

         this.isWindows = Application.platform == RuntimePlatform.WindowsEditor;

         // Set the min and max window dimensions to prevent resizing
         this.minSize = new Vector2(WindowWidth, WindowHeight);
         this.maxSize = this.minSize;

         // Force the window to a position relative to the uScript window
//         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, WINDOW_WIDTH, WINDOW_HEIGHT);

         // Make sure the skin is set at least once
         this.isProSkin = !EditorGUIUtility.isProSkin;

         if (this.isWindows)
         {
            window.Focus();
         }
      }

      if (this.isProSkin != EditorGUIUtility.isProSkin)
      {
         this.isProSkin = EditorGUIUtility.isProSkin;

         this.UpdateCustomStyles();
      }

      // Apply an content offset, because for some reason,
      // there is a 10-pixel gap between the window bar and the first row.
      GUILayout.Space(-10);

      EditorGUILayout.BeginVertical(Style.Window);
      {
         this.DrawPanelHeader();

         GUILayout.Space(16);

         EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
         {
            this.scrollviewPosition = EditorGUILayout.BeginScrollView(this.scrollviewPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
            {
               this.DrawCommandsEditor();
               this.DrawCommandsFileAccess();
               this.DrawCommandsCanvas();
               this.DrawCommandsNode();
               this.DrawCommandsNodePlacement();
            }

            EditorGUILayout.EndScrollView();
         }

         EditorGUILayout.EndVertical();
      }

      EditorGUILayout.EndVertical();
   }

   private void DrawPanelHeader()
   {
      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Label(Content.PanelIcon, Style.PanelIcon);

         EditorGUILayout.BeginVertical();
         {
            GUILayout.Label(Content.PanelTitle, Style.PanelTitle);
            GUILayout.Label(Content.PanelDescription, Style.PanelDescription);
         }

         EditorGUILayout.EndVertical();
      }

      EditorGUILayout.EndHorizontal();
   }

   private void DrawCommandsEditor()
   {
      EditorGUILayout.BeginVertical(Style.CommandSection);
      {
         GUILayout.Label("Editor Commands", Style.SectionHeader);

         this.DrawCommand("Online uScript documentation", ".Press_F1");

         EditorGUILayout.Space();

         this.DrawCommand("Toggle panel visibility", ".Press_`", ".Press_\\");

         EditorGUILayout.Space();

         this.DrawCommand("Cut", ".Press_Ctrl+X");
         this.DrawCommand("Copy", ".Press_Ctrl+C");
         this.DrawCommand("Paste", ".Press_Ctrl+V");
         this.DrawCommand("Undo", ".Press_Ctrl+Z");
         this.DrawCommand("Redo", ".Press_Ctrl+Y");

         EditorGUILayout.Space();

         this.DrawCommand("Close uScript Editor window", ".Press_Ctrl+W");
         this.DrawCommand("Context Menu", ".Click_RMB");
      }

      EditorGUILayout.EndVertical();
   }

   private void DrawCommandsCanvas()
   {
      EditorGUILayout.BeginVertical(Style.CommandSection);
      {
         GUILayout.Label("Canvas Commands", Style.SectionHeader);

         this.DrawCommand("Pan Canvas", ".Hold_Alt+LMB_.then drag");
         this.DrawCommand(string.Empty, "or_.Hold_MMB_.then drag");

         EditorGUILayout.Space();

         this.DrawCommand("Center graph at origin (0, 0)", ".Press_Home", ".Press_Ctrl+H");
         this.DrawCommand("Center graph on next Event node", ".Press_]");
         this.DrawCommand("Center graph on previous Event node", ".Press_[");

         EditorGUILayout.Space();

         this.DrawCommand("Toggle grid visibility", ".Press_Ctrl+G");
         this.DrawCommand("Toggle grid snapping", ".Press_Alt+G");
         this.DrawCommand("Snap selected nodes to grid", ".Press_Alt+End");

         EditorGUILayout.Space();

         this.DrawCommand("Reset Zoom to 100%", ".Press_0");
         this.DrawCommand("Zoom Out by 10%", ".Press_-", ".Scroll_MouseWheel_.down");
         this.DrawCommand("Zoom In by 10%", ".Press_=", ".Scroll_MouseWheel_.up");

         EditorGUILayout.Space();

         this.DrawCommand("Switch node palette to Toolbox", ".Press_Alt+T");
         this.DrawCommand("Switch node palette to Contents", ".Press_Alt+C");
         this.DrawCommand("Search in Toolbox or Contents", ".Press_Alt+M");

      }

      EditorGUILayout.EndVertical();
   }

   private void DrawCommandsNode()
   {
      EditorGUILayout.BeginVertical(Style.CommandSection);
      {
         GUILayout.Label("Node Commands", Style.SectionHeader);

         this.DrawCommand("New node selection", ".Click_LMB_.on node");
         this.DrawCommand(string.Empty, "or_.Hold_LMB_.on canvas and drag over node(s)");

         EditorGUILayout.Space();

         this.DrawCommand("Add to selection", ".Hold_Shift+LMB_.on canvas and drag over node(s)");
         this.DrawCommand("Remove from selection", ".Hold_Ctrl+LMB_.on canvas and drag over node(s)");
         this.DrawCommand("Toggle node selection", ".Press_Shift+LMB_.on node");

         EditorGUILayout.Space();

         this.DrawCommand("Move selection", ".Hold_LMB_.on selected node and drag");

         EditorGUILayout.Space();

         this.DrawCommand("Delete node selection", ".Press_Delete", ".Press_Backspace");
         this.DrawCommand("Drop node selection", ".Press_Escape", ".Click_LMB_.on canvas");

         EditorGUILayout.Space();

         this.DrawCommand("Collapse selected nodes", ".Press_<", ".Press_Shift+,");
         this.DrawCommand("Expand selected nodes", ".Press_>", ".Press_Shift+.");
         this.DrawCommand("Collapse all nodes", ".Press_Alt+<", ".Press_Shift+Alt+,");
         this.DrawCommand("Expand all nodes", ".Press_Alt+>", ".Press_Shift+Alt+.");
      }

      EditorGUILayout.EndVertical();
   }

   private void DrawCommandsFileAccess()
   {
      EditorGUILayout.BeginVertical(Style.CommandSection);
      {
         GUILayout.Label("File Menu Commands", Style.SectionHeader);

         this.DrawCommand("Open File Menu", ".Press_Alt+F", ".Press_Ctrl+F");

         EditorGUILayout.Space();

         this.DrawCommand("New uScript graph", ".Press_Alt+N");
         this.DrawCommand("Open uScript graph ...", ".Press_Alt+O");
         this.DrawCommand("Save", ".Press_Alt+S");
         this.DrawCommand("Save As ...", ".Press_Alt+A");
         this.DrawCommand("Save Quick", ".Press_Alt+Q");
         this.DrawCommand("Save Debug", ".Press_Alt+D");
         this.DrawCommand("Save Release", ".Press_Alt+R");
         this.DrawCommand("Export graph to Image (PNG)", ".Press_Alt+E");
      }

      EditorGUILayout.EndVertical();
   }

   private void DrawCommandsNodePlacement()
   {
      EditorGUILayout.BeginVertical(Style.CommandSection);
      {
         GUILayout.Label("Quick Node Placement Commands", Style.SectionHeader);

         GUILayout.Label(
            "Some nodes can be quickly placed on the graph by holding the associated key and clicking the"
            + " left mouse button where you wish the node to appear.",
            Style.CommandSectionDescription);

         this.DrawCommand("Bool variable", ".Hold_B+.click_LMB");
         this.DrawCommand("Float variable", ".Hold_F+.click_LMB");
         this.DrawCommand("GameObject variable", ".Hold_G+.click_LMB");
         this.DrawCommand("Int variable", ".Hold_I+.click_LMB");
         this.DrawCommand("Owner GameObject variable", ".Hold_O+.click_LMB");
         this.DrawCommand("String variable", ".Hold_S+.click_LMB");
         this.DrawCommand("Vector3 variable", ".Hold_V+.click_LMB");

         EditorGUILayout.Space();

         this.DrawCommand("Comment", ".Hold_C+.click_LMB");
         this.DrawCommand("External Connection", ".Hold_E+.click_LMB");
         this.DrawCommand("Log action", ".Hold_L+.click_LMB");

         EditorGUILayout.Space();

         for (var i = 1; i < 10; i++)
         {
            this.DrawCommand("Favorite " + i, ".Hold_" + i + "+.click_LMB");
         }
      }

      EditorGUILayout.EndVertical();
   }

   /// <summary>Display the formatted input action and command summary.</summary>
   /// <param name='action'>The action description.</param>
   /// <param name='commands'>Parameter list of commands. Each string represents compound input that may contain keyboard and mouse actions, as well as context. Contextual information should be preceded by an underscore.</param>
   private void DrawCommand(string action, params string[] commands)
   {
      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Label(action, GUILayout.Width(220));

         for (var c = 0; c < commands.Length; c++)
         {
            // Separate multiple commands
            if (c != 0)
            {
               GUILayout.Label("or", Style.CommandOr);
            }

            // Separate compound commands
            var keys = commands[c].Split('+');

            for (var k = 0; k < keys.Length; k++)
            {
               if (k != 0)
               {
                  GUILayout.Label("+", Style.CommandPlus);
               }

               var parts = keys[k].Split('_');

               foreach (var t in parts)
               {
                  var part = t;

                  // Expand text
                  switch (part)
                  {
                     case "LMB":
                        part = "Left Mouse Button";
                        break;
                     case "MMB":
                        part = "Middle Mouse Button";
                        break;
                     case "RMB":
                        part = "Right Mouse Button";
                        break;
                     case "MouseWheel":
                        part = "Mouse Wheel";
                        break;
                  }

                  // Determine style
                  var labelStyle = Style.CommandKey;
                  if (part.Length > 1)
                  {
                     if (part[0] == '.')
                     {
                        labelStyle = Style.CommandContext;
                        part = part.Substring(1);
                     }
                     else if (part == "or")
                     {
                        labelStyle = Style.CommandOr;
                     }
                     else if (part.ToLower().Contains("mouse"))
                     {
                        labelStyle = Style.CommandMouse;
                     }
                  }

                  // Format command keys for Mac
                  part = this.ApplyMacFormatting(part);

                  // Determine label width
                  var labelWidth = (int)Mathf.Max(this.minWidthKey, labelStyle.CalcSize(new GUIContent(part)).x);

                  GUILayout.Label(part, labelStyle, GUILayout.Width(labelWidth));
               }
            }
         }
      }

      EditorGUILayout.EndHorizontal();
   }

   private string ApplyMacFormatting(string key)
   {
      if (this.isWindows == false)
      {
         // Update key modifier when on Mac
         if (key == "Ctrl")
         {
            key = "Command";
         }

         switch (key)
         {
            case "Escape":
               return uScriptGUI.KeyEscape + " Escape";

            case "Shift":
               return uScriptGUI.KeyShift + " Shift";

            case "Ctrl":
               return uScriptGUI.KeyControl + " Control";

            case "Alt":
               return uScriptGUI.KeyOption + " Option";

            case "Command":
               return uScriptGUI.KeyCommand + " Command";

            case "Delete":
               return uScriptGUI.KeyDelete + " Delete";

            case "Backspace":
               return uScriptGUI.KeyBackspace + " Delete";

            case "Return":
               return uScriptGUI.KeyReturn + " Return";
         }
      }

      return key;
   }

   private void UpdateCustomStyles()
   {
      Style.Window.fixedHeight = this.minSize.y;
      Style.Window.fixedWidth = this.minSize.x;

      this.minWidthKey = (int)Mathf.Max(Style.CommandKey.CalcSize(new GUIContent("W")).x, Style.CommandKey.CalcSize(new GUIContent("=")).x);

      // Apply skin and platform variations
      if (this.isProSkin)
      {
         Style.CommandKey.padding = this.isWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 1, 3);
      }
      else
      {
         Style.CommandKey.padding = this.isWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 2, 2);
      }
   }

   // === Classes ====================================================================

   private static class Content
   {
      static Content()
      {
         PanelIcon = new GUIContent(uScriptGUI.GetTexture("iconWelcomeLogo"));
         PanelTitle = new GUIContent("Quick Command Reference");
         PanelDescription = new GUIContent("This is summary of the various commands available to you while using the uScript Editor.");
      }

      public static GUIContent PanelIcon { get; private set; }

      public static GUIContent PanelTitle { get; private set; }

      public static GUIContent PanelDescription { get; private set; }
   }

   private static class Style
   {
      static Style()
      {
         CommandContext = new GUIStyle(EditorStyles.label)
         {
            margin = new RectOffset(2, 2, 2, 2),
            stretchWidth = false
         };

         CommandKey = new GUIStyle(EditorStyles.miniButton)
         {
            margin = new RectOffset(0, 0, 2, 2),
            stretchWidth = false
         };

         CommandMouse = new GUIStyle(EditorStyles.boldLabel)
         {
            margin = new RectOffset(0, 0, 2, 2),
            stretchWidth = false
         };

         CommandOr = new GUIStyle(EditorStyles.label)
         {
            fontStyle = FontStyle.Italic,
            margin = new RectOffset(8, 8, 2, 2),
            stretchWidth = false
         };

         CommandPlus = new GUIStyle(EditorStyles.label)
         {
            margin = new RectOffset(0, 0, 2, 2),
            stretchWidth = false
         };

         CommandSection = new GUIStyle { margin = new RectOffset(8, 8, 0, 16), stretchWidth = true };

         CommandSectionDescription = new GUIStyle(EditorStyles.label)
         {
            margin = new RectOffset(4, 4, 4, 16),
            padding = new RectOffset(3, 3, 1, 0),
            wordWrap = true
         };

         PanelDescription = GUI.skin.GetStyle("WordWrappedLabel");

         PanelIcon = new GUIStyle { padding = new RectOffset(0, 32, 0, 0), stretchWidth = false };

         PanelTitle = new GUIStyle
         {
            fontSize = 32,
            fontStyle = FontStyle.Bold,
            normal = { textColor = EditorStyles.boldLabel.normal.textColor }
         };

         SectionHeader = new GUIStyle(EditorStyles.boldLabel)
         {
            normal = { background = uScriptGUI.GetSkinnedTexture("Underline") },
            border = new RectOffset(0, 0, 0, 2),
            padding = new RectOffset(0, 0, 2, 2)
         };

         Window = new GUIStyle { padding = new RectOffset(32, 32, 16, 32) };
      }

      public static GUIStyle CommandContext { get; private set; }

      public static GUIStyle CommandKey { get; private set; }

      public static GUIStyle CommandMouse { get; private set; }

      public static GUIStyle CommandOr { get; private set; }

      public static GUIStyle CommandPlus { get; private set; }

      public static GUIStyle CommandSection { get; private set; }

      public static GUIStyle CommandSectionDescription { get; private set; }

      public static GUIStyle PanelIcon { get; private set; }

      public static GUIStyle PanelTitle { get; private set; }

      public static GUIStyle PanelDescription { get; private set; }

      public static GUIStyle SectionHeader { get; private set; }

      public static GUIStyle Window { get; private set; }
   }
}
