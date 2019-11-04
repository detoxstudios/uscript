// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotkeyWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptHotkeyWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI.Windows
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text.RegularExpressions;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class HotkeyWindow : EditorWindow
   {
      // Layout parameters
      private const int WindowHeight = 200;
      private const int WindowWidth = 250;

      private static HotkeyWindow instance;

      private readonly Dictionary<KeyCode, bool> keyDown = new Dictionary<KeyCode, bool>();

      private bool isFirstRun;
      private bool isProSkin;
      private Vector2 scrollviewPosition;

      private Rect panelOptionsRect;

      public static HotkeyWindow Instance
      {
         get
         {
            if (instance == null)
            {
               Open();
            }

            return instance;
         }
      }

      private static bool IsWindows
      {
         get
         {
            return Application.platform == RuntimePlatform.WindowsEditor;
         }
      }

      private static bool LeftMouseButtonPrimary
      {
         get
         {
            return Preferences.LeftMouseButtonPrimary;
         }

         set
         {
            if (Preferences.LeftMouseButtonPrimary == value)
            {
               return;
            }

            Preferences.LeftMouseButtonPrimary = value;
         }
      }

      private static bool ShouldShowAllHotkeys
      {
         get
         {
            return Preferences.ShowAllHotkeys;
         }

         set
         {
            if (Preferences.ShowAllHotkeys == value)
            {
               return;
            }

            Preferences.ShowAllHotkeys = value;
         }
      }

      public static void Open()
      {
         instance = GetWindow<HotkeyWindow>(false, "Hotkeys", false);
         instance.isFirstRun = true;
         instance.titleContent = new GUIContent("Hotkeys", uScriptGUI.GetTexture("iconScriptFile02"));
      }

      internal void OnEnable()
      {
         uScript.HotkeyWindow = this;

         ShouldShowAllHotkeys = Preferences.ShowAllHotkeys;
      }

      internal void OnDisable()
      {
         uScript.HotkeyWindow = null;
      }

      internal void OnGUI()
      {
         this.ProcessInputChanges();

         var e = Event.current;

         if (this.isFirstRun)
         {
            this.isFirstRun = false;

            // Set the min and max window dimensions to prevent resizing
            this.minSize = new Vector2(WindowWidth, WindowHeight);

            // Make sure the skin is set at least once
            this.isProSkin = !EditorGUIUtility.isProSkin;

            if (IsWindows)
            {
               Instance.Focus();
            }
         }

         if (this.isProSkin != EditorGUIUtility.isProSkin)
         {
            this.isProSkin = EditorGUIUtility.isProSkin;

            this.UpdateCustomStyles();
         }

         EditorGUILayout.BeginVertical();
         {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            {
               GUILayout.Label("uScript Hotkeys", uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

               var iconPaneOptions = GUI.skin.FindStyle("PaneOptions").normal.background;
               if (GUILayout.Button(iconPaneOptions, Style.ButtonToolbarDropDown))
               {
                  ContextMenuCreate(this.panelOptionsRect);
               }

               if (e.type != EventType.Layout && e.type != EventType.Used)
               {
                  this.panelOptionsRect = GUILayoutUtility.GetLastRect();
               }
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
            {
               this.scrollviewPosition = EditorGUILayout.BeginScrollView(this.scrollviewPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
               {
                  //this.DrawVirtualKeyboard();
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

         if (e.type == EventType.Repaint)
         {
            // Disable the "drag" and "mouse wheel" keycodes after repainting.
            this.keyDown[KeyCode.Mouse5] = false;
            this.keyDown[KeyCode.Mouse6] = false;
         }
      }

      private static void CommandHotkeysFilterContext()
      {
         ShouldShowAllHotkeys = false;
      }

      private static void CommandHotkeysShowAll()
      {
         ShouldShowAllHotkeys = true;
      }

      private static void CommandMouseLeftPrimary()
      {
         LeftMouseButtonPrimary = true;
      }

      private static void CommandMouseLeftSecondary()
      {
         LeftMouseButtonPrimary = false;
      }

      private static void ContextMenuCreate(Rect rect)
      {
         var menu = new GenericMenu();

         menu.AddItem(new GUIContent("Filter Hotkeys/Show All"), ShouldShowAllHotkeys, CommandHotkeysShowAll);
         menu.AddItem(new GUIContent("Filter Hotkeys/Contextual"), !ShouldShowAllHotkeys, CommandHotkeysFilterContext);
         menu.AddSeparator(string.Empty);

         menu.AddItem(new GUIContent("Primary Mouse Button/Left"), LeftMouseButtonPrimary, CommandMouseLeftPrimary);
         menu.AddItem(new GUIContent("Primary Mouse Button/Right"), !LeftMouseButtonPrimary, CommandMouseLeftSecondary);

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

      private static string GetKeyName(KeyCode keyCode)
      {
         switch (keyCode)
         {
            case KeyCode.Alpha0:
               return "0";
            case KeyCode.Alpha1:
               return "1";
            case KeyCode.Alpha2:
               return "2";
            case KeyCode.Alpha3:
               return "3";
            case KeyCode.Alpha4:
               return "4";
            case KeyCode.Alpha5:
               return "5";
            case KeyCode.Alpha6:
               return "6";
            case KeyCode.Alpha7:
               return "7";
            case KeyCode.Alpha8:
               return "8";
            case KeyCode.Alpha9:
               return "9";
            case KeyCode.Minus:
               return "-";
            case KeyCode.Equals:
               return "=";
            case KeyCode.BackQuote:
               return "`";
            case KeyCode.Escape:
               return "Esc";
            case KeyCode.Semicolon:
               return ";";
            case KeyCode.Quote:
               return "'";
            case KeyCode.LeftBracket:
               return "[";
            case KeyCode.RightBracket:
               return "]";
            case KeyCode.Backslash:
               return "\\";
            case KeyCode.Slash:
               return "/";
            case KeyCode.Greater:
               return ">";
            case KeyCode.Less:
               return "<";
            case KeyCode.Comma:
               return ",";
            case KeyCode.Period:
               return ".";
            case KeyCode.LeftShift:
            case KeyCode.RightShift:
               return "Shift";
            case KeyCode.LeftControl:
            case KeyCode.RightControl:
               return "Ctrl";
            case KeyCode.LeftAlt:
            case KeyCode.RightAlt:
               return IsWindows ? "Alt" : "Opt";
            case KeyCode.LeftCommand:
            case KeyCode.RightCommand:
            case KeyCode.LeftWindows:
            case KeyCode.RightWindows:
               return IsWindows ? "Win" : "Cmd";
            case KeyCode.Mouse0:
               return LeftMouseButtonPrimary ? "LMB" : "RMB";
            case KeyCode.Mouse1:
               return LeftMouseButtonPrimary ? "RMB" : "LMB";
            case KeyCode.Mouse2:
               return "MMB";
            case KeyCode.Mouse5:
               return "drag";
            case KeyCode.Mouse6:
               return "Mouse Wheel";
         }

         return keyCode.ToString();
      }

      private string ApplyMacFormatting(string key)
      {
         if (IsWindows)
         {
            return key;
         }

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

         return key;
      }

      private void DrawCommand(string label, params string[] commands)
      {
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label(label, GUILayout.Width(180));

            for (var c = 0; c < commands.Length; c++)
            {
               // Separate multiple commands
               if (c != 0 || string.IsNullOrEmpty(label))
               {
                  GUILayout.Label("or", Style.CommandOr);
               }

               // Separate compound commands
               var parts = Regex.Split(commands[c], "(\\[\\w*\\])");

               foreach (var part in parts.Where(s => s != string.Empty))
               {
                  var action = part.Trim();

                  // Determine style
                  var labelStyle = Style.CommandText;

                  if (action == "+")
                  {
                     labelStyle = Style.CommandPlus;
                  }
                  else if (action.StartsWith("[") && action.EndsWith("]"))
                  {
                     action = action.Trim('[', ']');

                     var keyCode = KeyCode.None;

                     switch (action.ToUpper())
                     {
                        case "LMB":
                           keyCode = KeyCode.Mouse0;
                           break;
                        case "RMB":
                           keyCode = KeyCode.Mouse1;
                           break;
                        case "MMB":
                           keyCode = KeyCode.Mouse2;
                           break;
                        case "DRAG":
                           keyCode = KeyCode.Mouse5;
                           break;
                        case "WHEEL":
                           keyCode = KeyCode.Mouse6;
                           break;
                        case "ALT":
                           keyCode = KeyCode.LeftAlt;
                           break;
                        case "CTRL":
                           keyCode = IsWindows ? KeyCode.LeftControl : KeyCode.LeftWindows;
                           break;
                        case "SHIFT":
                           keyCode = KeyCode.LeftShift;
                           break;
                     }

                     if (keyCode == KeyCode.None)
                     {
                        if (Enum.IsDefined(typeof(KeyCode), action))
                        {
                           keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), action);
                        }
                        else
                        {
                           Debug.Log("Invalid KeyCode: \"" + action + "\"\n");
                        }
                     }

                     var inputName = GetKeyName(keyCode);
                     var inputActive = this.keyDown.ContainsKey(keyCode) && this.keyDown[keyCode];

                     var keyStyle = keyCode != KeyCode.Mouse0 && keyCode != KeyCode.Mouse1 && keyCode != KeyCode.Mouse2 && keyCode != KeyCode.Mouse5 && keyCode != KeyCode.Mouse6;
                     var styleUp = keyStyle ? Style.CommandKey : Style.CommandMouse;
                     var styleDown = keyStyle ? Style.CommandKeyDown : Style.CommandMouseDown;

                     action = inputName;
                     labelStyle = inputActive ? styleDown : styleUp;
                  }

                  // Format command keys for Mac
                  //action = this.ApplyMacFormatting(action);

                  // Determine label width
                  //var labelWidth = (int)Mathf.Max(this.minWidthKey, labelStyle.CalcSize(new GUIContent(action)).x);

                  //// TODO: is this needed?
                  //GUILayout.Label(action, labelStyle, GUILayout.Width(labelWidth));
                  GUILayout.Label(action, labelStyle);
               }
            }
         }

         EditorGUILayout.EndHorizontal();
      }

      private void DrawCommandBasic(string command, params KeyCode[][] keycodes)
      {
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label(command, GUILayout.Width(180));

            for (var setIndex = 0; setIndex < keycodes.Length; setIndex++)
            {
               for (var keyIndex = 0; keyIndex < keycodes[setIndex].Length; keyIndex++)
               {
                  var keyCode = keycodes[setIndex][keyIndex];

                  var inputName = GetKeyName(keycodes[setIndex][keyIndex]);
                  var inputActive = this.keyDown.ContainsKey(keyCode) && this.keyDown[keyCode];

                  GUILayout.Label(
                     inputName,
                     inputActive ? EditorStyles.boldLabel : EditorStyles.label,
                     GUILayout.ExpandWidth(false));
               }
            }
         }

         EditorGUILayout.EndHorizontal();
      }

      private void DrawCommandsCanvas()
      {
         EditorGUILayout.BeginVertical(Style.CommandSection);
         {
            GUILayout.Label("Canvas Commands", Style.SectionHeader);

            this.DrawCommand("Pan Canvas", "[Alt]+[LMB] then [drag]");
            this.DrawCommand(string.Empty, "[MMB] then [drag]");

            EditorGUILayout.Space();

            this.DrawCommand("Go to graph origin", "[Home]", "[Ctrl]+[H]");
            this.DrawCommand("Go to next Event node", "[RightBracket]");
            this.DrawCommand("Go to previous Event node", "[LeftBracket]");

            EditorGUILayout.Space();

            this.DrawCommand("Toggle grid visibility", "[Ctrl]+[G]");
            this.DrawCommand("Toggle grid snapping", "[Alt]+[G]");
            this.DrawCommand("Snap selected nodes to grid", "[Alt]+[End]");

            EditorGUILayout.Space();

            this.DrawCommand("Reset Zoom to 100%", "[Alpha0]");
            this.DrawCommand("Zoom Out by 10%", "[Minus]", "Scroll [Wheel] down");
            this.DrawCommand("Zoom In by 10%", "[Equals]", "Scroll [Wheel] up");

            EditorGUILayout.Space();

            this.DrawCommand("Switch node palette to Toolbox", "[alt]+[T]");
            this.DrawCommand("Switch node palette to Contents", "[Alt]+[C]");
            this.DrawCommand("Search in Toolbox or Contents", "[Alt]+[M]");
         }

         EditorGUILayout.EndVertical();
      }

      private void DrawCommandsEditor()
      {
         EditorGUILayout.BeginVertical(Style.CommandSection);
         {
            GUILayout.Label("Editor Commands", Style.SectionHeader);

            this.DrawCommand("Online uScript documentation", "[F1]");

            EditorGUILayout.Space();

            this.DrawCommand("Toggle panel visibility", "[BackQuote]", "[Backslash]");

            EditorGUILayout.Space();

            this.DrawCommand("Cut", "[Ctrl]+[X]");
            this.DrawCommand("Copy", "[Ctrl]+[C]");
            this.DrawCommand("Paste", "[Ctrl]+[V]");
            this.DrawCommand("Undo", "[Ctrl]+[Z]");
            this.DrawCommand("Redo", "[Ctrl]+[Y]");

            EditorGUILayout.Space();

            this.DrawCommand("Close uScript Editor window", "[Ctrl]+[W]");
            this.DrawCommand("Context Menu", "[RMB]");
         }

         EditorGUILayout.EndVertical();
      }

      private void DrawCommandsFileAccess()
      {
         EditorGUILayout.BeginVertical(Style.CommandSection);
         {
            GUILayout.Label("File Menu Commands", Style.SectionHeader);

            this.DrawCommand("Open File Menu", "[Alt]+[F]", "[Ctrl]+[F]");

            EditorGUILayout.Space();

            this.DrawCommand("New uScript graph", "[Alt]+[N]");
            this.DrawCommand("Open uScript graph ...", "[Alt]+[O]");
            this.DrawCommand("Save", "[Alt]+[S]");
            this.DrawCommand("Save As ...", "[Alt]+[A]");
            this.DrawCommand("Save Quick", "[Alt]+[Q]");
            this.DrawCommand("Save Debug", "[Alt]+[D]");
            this.DrawCommand("Save Release", "[Alt]+[R]");
            this.DrawCommand("Export graph to Image (PNG)", "[Alt]+[E]");
         }

         EditorGUILayout.EndVertical();
      }

      private void DrawCommandsNode()
      {
         EditorGUILayout.BeginVertical(Style.CommandSection);
         {
            GUILayout.Label("Node Commands", Style.SectionHeader);

            this.DrawCommand("New node selection", "[LMB] on node");
            this.DrawCommand(string.Empty, "[LMB] on canvas and [drag] over node(s)");

            EditorGUILayout.Space();

            this.DrawCommand("Add to selection", "[Shift]+[LMB] on canvas and [drag] over node(s)");
            this.DrawCommand("Remove from selection", "[Ctrl]+[LMB] on canvas and [drag] over node(s)");
            this.DrawCommand("Toggle node selection", "[Shift]+[LMB] on node");

            EditorGUILayout.Space();

            this.DrawCommand("Move selection", "[LMB] on selected node and [drag]");

            EditorGUILayout.Space();

            this.DrawCommand("Delete node selection", "[Delete]", "[Backspace]");
            this.DrawCommand("Drop node selection", "[Escape]", "[LMB] on canvas");

            EditorGUILayout.Space();

            this.DrawCommand("Collapse selected nodes", "[Less]", "[Shift]+[Comma]");
            this.DrawCommand("Expand selected nodes", "[Greater]", "[Shift]+[Period]");
            this.DrawCommand("Collapse all nodes", "[Alt]+[Less]", "[Shift]+[Alt]+[Comma]");
            this.DrawCommand("Expand all nodes", "[Alt]+[Greater]", "[Shift]+[Alt]+[Period]");
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

            this.DrawCommand("Bool variable", "[B]+[LMB]");
            this.DrawCommand("Float variable", "[F]+[LMB]");
            this.DrawCommand("GameObject variable", "[G]+[LMB]");
            this.DrawCommand("Int variable", "[I]+[LMB]");
            this.DrawCommand("Owner GameObject variable", "[O]+[LMB]");
            this.DrawCommand("String variable", "[S]+[LMB]");
            this.DrawCommand("Vector3 variable", "[V]+[LMB]");

            EditorGUILayout.Space();

            this.DrawCommand("Comment", "[C]+[LMB]");
            this.DrawCommand("External Connection", "[E]+[LMB]");
            this.DrawCommand("Log node", "[L]+[LMB]");

            EditorGUILayout.Space();

            for (var i = 1; i < 10; i++)
            {
               this.DrawCommand("Favorite " + i, "[Alpha" + i + "]+[LMB]");
            }
         }

         EditorGUILayout.EndVertical();
      }

      private void DrawVirtualKeyboard()
      {
         EditorGUILayout.BeginVertical(Style.CommandSection);
         {
            GUILayout.Label("Virtual Keyboard and Mouse Buttons", Style.SectionHeader);

            this.DrawCommandBasic("LINE 1", new[] { KeyCode.Escape, KeyCode.F1, KeyCode.F2, KeyCode.F3, KeyCode.F4, KeyCode.F5, KeyCode.F6, KeyCode.F7, KeyCode.F8, KeyCode.F9, KeyCode.F10, KeyCode.F11, KeyCode.F12 });
            this.DrawCommandBasic("LINE 2", new[] { KeyCode.BackQuote, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Minus, KeyCode.Equals, KeyCode.Backspace });
            this.DrawCommandBasic("LINE 3", new[] { KeyCode.Tab, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Backslash });
            this.DrawCommandBasic("LINE 4", new[] { KeyCode.CapsLock, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote, KeyCode.Return });
            this.DrawCommandBasic("LINE 5", new[] { KeyCode.LeftShift, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Comma, KeyCode.Period, KeyCode.Slash, KeyCode.RightShift });

            if (IsWindows)
            {
               this.DrawCommandBasic("LINE 6", new[] { KeyCode.LeftControl, 
               KeyCode.LeftCommand,
               KeyCode.LeftAlt, KeyCode.Space, KeyCode.RightAlt,
               KeyCode.RightCommand,
               KeyCode.Menu, KeyCode.RightControl });
            }
            else
            {
               this.DrawCommandBasic("LINE 6", new[] { KeyCode.LeftControl, KeyCode.LeftAlt, 
               KeyCode.LeftCommand,
               KeyCode.Space,
               KeyCode.RightCommand,
               KeyCode.RightAlt, KeyCode.RightControl });
            }

            EditorGUILayout.Space();

            var mouseButtons = LeftMouseButtonPrimary
                  ? new[] { KeyCode.Mouse0, KeyCode.Mouse2, KeyCode.Mouse1 }
                  : new[] { KeyCode.Mouse1, KeyCode.Mouse2, KeyCode.Mouse0 };

            this.DrawCommandBasic("Mouse", mouseButtons);
         }

         EditorGUILayout.EndVertical();
      }

      private void ProcessInputChanges()
      {
         var e = Event.current;
         var eventType = e.type;
         var keyCode = e.keyCode;

         if (e.isKey && keyCode != KeyCode.None)
         {
            if ((eventType == EventType.KeyDown)
                && (this.keyDown.ContainsKey(keyCode) == false || this.keyDown[keyCode] == false))
            {
               this.keyDown[keyCode] = true;
               this.Repaint();
               e.Use();
            }
            else if ((eventType == EventType.KeyUp) && this.keyDown.ContainsKey(keyCode) && this.keyDown[keyCode])
            {
               this.keyDown[keyCode] = false;
               this.Repaint();
               e.Use();
            }
         }
         else if (eventType == EventType.MouseDown)
         {
            var mouseButton = KeyCode.Mouse0 + e.button;

            if (this.keyDown.ContainsKey(mouseButton) == false || this.keyDown[mouseButton] == false)
            {
               this.keyDown[mouseButton] = true;
               this.Repaint();
            }
         }
         else if (eventType == EventType.MouseUp)
         {
            var mouseButton = KeyCode.Mouse0 + e.button;

            if (this.keyDown.ContainsKey(mouseButton) && this.keyDown[mouseButton])
            {
               this.keyDown[mouseButton] = false;
               this.Repaint();
            }
         }
         else if (eventType == EventType.MouseDrag)
         {
            // HACK: Use "Mouse5" for the drag event
            this.keyDown[KeyCode.Mouse5] = true;
            this.Repaint();
         }
         else if (eventType == EventType.ScrollWheel)
         {
            // HACK: Use "Mouse6" for the scroll wheel event
            this.keyDown[KeyCode.Mouse6] = true;
            this.Repaint();
         }

         // Handle "shift" input manually, because Unity does not correctly
         // send KeyDown and KeyUp messages for the Shift keys.
         var exists = this.keyDown.ContainsKey(KeyCode.LeftShift);
         if ((exists == false && e.shift) || (exists && this.keyDown[KeyCode.LeftShift] != e.shift))
         {
            this.keyDown[KeyCode.LeftShift] = e.shift;
            this.Repaint();
         }
      }

      private void UpdateCustomStyles()
      {
         Style.Window.fixedHeight = this.minSize.y;
         Style.Window.fixedWidth = this.minSize.x;

         // Apply skin and platform variations
         if (this.isProSkin)
         {
            Style.CommandKey.padding = IsWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 1, 3);
         }
         else
         {
            Style.CommandKey.padding = IsWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 2, 2);
         }
      }

      // === Classes ====================================================================

      private static class Style
      {
         static Style()
         {
            ButtonToolbarDropDown = new GUIStyle(EditorStyles.toolbarButton)
            {
               contentOffset = new Vector2(0, 2),
               stretchWidth = false
            };

            CommandKey = new GUIStyle(EditorStyles.miniButton)
            {
               margin = new RectOffset(0, 0, 2, 2),
               stretchWidth = false
            };

            CommandKeyDown = new GUIStyle(EditorStyles.miniButton)
            {
               //normal = EditorStyles.miniButton.active,
               normal = EditorStyles.miniButton.onNormal,
               margin = new RectOffset(0, 0, 2, 2),
               stretchWidth = false
            };

            CommandMouse = new GUIStyle(EditorStyles.label)
            {
               margin = new RectOffset(0, 0, 2, 2),
               stretchWidth = false
            };

            CommandMouseDown = new GUIStyle(EditorStyles.boldLabel)
            {
               //fontStyle = FontStyle.Bold,
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

            CommandText = new GUIStyle(EditorStyles.label)
            {
               margin = new RectOffset(2, 2, 2, 2),
               stretchWidth = false
            };

            CommandSection = new GUIStyle { margin = new RectOffset(8, 8, 0, 16), stretchWidth = true };

            CommandSectionDescription = new GUIStyle(EditorStyles.label)
            {
               margin = new RectOffset(4, 4, 4, 16),
               padding = new RectOffset(3, 3, 1, 0),
               wordWrap = true
            };

            SectionHeader = new GUIStyle(EditorStyles.boldLabel)
            {
               normal = { background = uScriptGUI.GetSkinnedTexture("Underline") },
               border = new RectOffset(0, 0, 0, 2),
               padding = new RectOffset(0, 0, 2, 2)
            };

            Window = new GUIStyle { padding = new RectOffset(32, 32, 16, 32) };
         }

         public static GUIStyle ButtonToolbarDropDown { get; private set; }

         public static GUIStyle CommandSection { get; private set; }

         public static GUIStyle CommandSectionDescription { get; private set; }

         public static GUIStyle CommandKey { get; private set; }

         public static GUIStyle CommandKeyDown { get; private set; }

         public static GUIStyle CommandMouse { get; private set; }

         public static GUIStyle CommandMouseDown { get; private set; }

         public static GUIStyle CommandOr { get; private set; }

         public static GUIStyle CommandPlus { get; private set; }

         public static GUIStyle CommandText { get; private set; }

         public static GUIStyle SectionHeader { get; private set; }

         public static GUIStyle Window { get; private set; }
      }
   }
}
