using UnityEditor;
using UnityEngine;

public class ReferenceWindow : EditorWindow
{
   static ReferenceWindow window = null;
   bool isFirstRun = false;

   // Layout parameters
   const int WINDOW_WIDTH = 730;
   const int WINDOW_HEIGHT = 640;
   Vector2 scrollviewPosition;
   bool isWindows = false;
   bool isProSkin = false;
   int minWidthKey = 0;

   // Custom Content
   GUIContent contentPanelIcon;
   GUIContent contentPanelTitle;
   GUIContent contentPanelDescription;

   // Custom styles
   GUIStyle styleWindow;
   GUIStyle stylePanelIcon;
   GUIStyle stylePanelTitle;
   GUIStyle stylePanelDescription;
   GUIStyle styleCommandSection;
   GUIStyle styleCommandSectionDescription;
   GUIStyle styleCommandKey;
   GUIStyle styleCommandMouse;
   GUIStyle styleCommandContext;
   GUIStyle styleCommandOr;
   GUIStyle styleCommandPlus;

   // Create the window
   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<ReferenceWindow>(true, "uScript Quick Command Reference", true) as ReferenceWindow;
      window.isFirstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
   }

   public void OnGUI()
   {
      if (isFirstRun)
      {
         isFirstRun = false;

         isWindows = Application.platform == RuntimePlatform.WindowsEditor;

         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);
         base.maxSize = base.minSize;

         // Force the window to a position relative to the uScript window
//         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, WINDOW_WIDTH, WINDOW_HEIGHT);

         // Make sure the skin is set at least once
         isProSkin = !EditorGUIUtility.isProSkin;

         if (isWindows)
         {
            window.Focus();
         }
      }

      if (isProSkin != EditorGUIUtility.isProSkin)
      {
         isProSkin = EditorGUIUtility.isProSkin;

         UpdateCustomStyles();
      }

      // Apply an content offset, because for some reason,
      // there is a 10-pixel gap between the window bar and the first row.
      GUILayout.Space(-10);

      EditorGUILayout.BeginVertical(styleWindow);
      {
         DrawPanelHeader();

         GUILayout.Space(16);

         EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
         {
            scrollviewPosition = EditorGUILayout.BeginScrollView(scrollviewPosition, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               DrawCommands_Editor();
               DrawCommands_FileAccess();
               DrawCommands_Canvas();
               DrawCommands_Node();
               DrawCommands_NodePlacement();
            }
            EditorGUILayout.EndScrollView();
         }
         EditorGUILayout.EndVertical();

//         GUILayout.Space(8);
//         EditorGUILayout.BeginHorizontal();
//         {
//            GUILayout.FlexibleSpace();
//            GUILayout.Label(position.ToString());
//         }
//         EditorGUILayout.EndHorizontal();
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawPanelHeader()
   {
      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Label(contentPanelIcon, stylePanelIcon);

         EditorGUILayout.BeginVertical();
         {
            GUILayout.Label(contentPanelTitle, stylePanelTitle);
            GUILayout.Label(contentPanelDescription, stylePanelDescription);

//            EditorGUILayout.Space();
//
//            EditorGUILayout.BeginHorizontal();
//            {
//               GUILayout.FlexibleSpace();
//               if (GUILayout.Button("Click here for more inforation and an assortment of helpful links"))
//               {
//                  WelcomeWindow.Init();
//               }
//               GUILayout.FlexibleSpace();
//            }
//            EditorGUILayout.EndHorizontal();
         }
         EditorGUILayout.EndVertical();
      }
      EditorGUILayout.EndHorizontal();
   }

   private void DrawCommands_Editor()
   {
      EditorGUILayout.BeginVertical(styleCommandSection);
      {
         GUILayout.Label("Editor Commands", uScriptGUIStyle.referenceName);

         DrawCommand("Online uScript documentation", ".Press_F1");

         EditorGUILayout.Space();

         DrawCommand("Toggle panel visibility", ".Press_`", ".Press_\\");

         EditorGUILayout.Space();

         DrawCommand("Cut", ".Press_Ctrl+X");
         DrawCommand("Copy", ".Press_Ctrl+C");
         DrawCommand("Paste", ".Press_Ctrl+V");
         DrawCommand("Undo", ".Press_Ctrl+Z");
         DrawCommand("Redo", ".Press_Ctrl+Y");

         EditorGUILayout.Space();

         DrawCommand("Close uScript Editor window", ".Press_Ctrl+W");
         DrawCommand("Context Menu", ".Click_RMB");
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawCommands_Canvas()
   {
      EditorGUILayout.BeginVertical(styleCommandSection);
      {
         GUILayout.Label("Canvas Commands", uScriptGUIStyle.referenceName);

         DrawCommand("Pan Canvas", ".Hold_Alt+LMB_.then drag");
         DrawCommand(string.Empty, "or_.Hold_MMB_.then drag");

         EditorGUILayout.Space();

         DrawCommand("Center graph at origin (0, 0)", ".Press_Home", ".Press_Ctrl+H");
         DrawCommand("Center graph on next Event node", ".Press_]");
         DrawCommand("Center graph on previous Event node", ".Press_[");

         EditorGUILayout.Space();

         DrawCommand("Toggle grid visibility", ".Press_Ctrl+G");
         DrawCommand("Toggle grid snapping", ".Press_Alt+G");
         DrawCommand("Snap selected nodes to grid", ".Press_Alt+End");

         EditorGUILayout.Space();

         DrawCommand("Reset Zoom to 100%", ".Press_0");
         DrawCommand("Zoom Out by 10%", ".Press_-", ".Scroll_MouseWheel_.down");
         DrawCommand("Zoom In by 10%", ".Press_=", ".Scroll_MouseWheel_.up");
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawCommands_Node()
   {
      EditorGUILayout.BeginVertical(styleCommandSection);
      {
         GUILayout.Label("Node Commands", uScriptGUIStyle.referenceName);

         DrawCommand("New node selection", ".Click_LMB_.on node");
         DrawCommand(string.Empty, "or_.Hold_LMB_.on canvas and drag over node(s)");

         EditorGUILayout.Space();

         DrawCommand("Add to selection", ".Hold_Shift+LMB_.on canvas and drag over node(s)");
         DrawCommand("Remove from selection", ".Hold_Ctrl+LMB_.on canvas and drag over node(s)");
         DrawCommand("Toggle node selection", ".Press_Shift+LMB_.on node");

         EditorGUILayout.Space();

         DrawCommand("Move selection", ".Hold_LMB_.on selected node and drag");

         EditorGUILayout.Space();

         DrawCommand("Delete node selection", ".Press_Delete", ".Press_Backspace");
         DrawCommand("Drop node selection", ".Press_Escape", ".Click_LMB_.on canvas");
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawCommands_FileAccess()
   {
      EditorGUILayout.BeginVertical(styleCommandSection);
      {
         GUILayout.Label("File Menu Commands", uScriptGUIStyle.referenceName);

         DrawCommand("Open File Menu", ".Press_Alt+F", ".Press_Ctrl+F");

         EditorGUILayout.Space();

         DrawCommand("New uScript graph", ".Press_Alt+N");
         DrawCommand("Open uScript graph ...", ".Press_Alt+O");
         DrawCommand("Save", ".Press_Alt+S");
         DrawCommand("Save As ...", ".Press_Alt+A");
         DrawCommand("Save Quick", ".Press_Alt+Q");
         DrawCommand("Save Debug", ".Press_Alt+D");
         DrawCommand("Save Release", ".Press_Alt+R");
         DrawCommand("Export graph to Image (PNG)", ".Press_Alt+E");
      }
      EditorGUILayout.EndVertical();
   }

   private void DrawCommands_NodePlacement()
   {
      EditorGUILayout.BeginVertical(styleCommandSection);
      {
         GUILayout.Label("Quick Node Placement Commands", uScriptGUIStyle.referenceName);

         GUILayout.Label("Some nodes can be quickly placed on the graph by holding the associated key and clicking the"
            + " left mouse button where you wish the node to appear.", styleCommandSectionDescription);

         DrawCommand("Bool variable", ".Hold_B+.click_LMB");
         DrawCommand("Float variable", ".Hold_F+.click_LMB");
         DrawCommand("GameObject variable", ".Hold_G+.click_LMB");
         DrawCommand("Int variable", ".Hold_I+.click_LMB");
         DrawCommand("Object variable", ".Hold_O+.click_LMB");
         DrawCommand("String variable", ".Hold_S+.click_LMB");
         DrawCommand("Vector3 variable", ".Hold_V+.click_LMB");

         EditorGUILayout.Space();

         DrawCommand("Comment", ".Hold_C+.click_LMB");
         DrawCommand("External Connection", ".Hold_E+.click_LMB");
         DrawCommand("Log action", ".Hold_L+.click_LMB");
      }
      EditorGUILayout.EndVertical();
   }

   /// <summary>Display the formatted input action and command summary.</summary>
   /// <param name='action'>The action description.</param>
   /// <param name='cmds'>Parameter list of commands. Each string represents compound input that may contain keyboard and mouse actions, as well as context. Contextual information should be preceeded by an underscore.</param>
   private void DrawCommand(string action, params string[] cmds)
   {
      GUIStyle labelStyle = styleCommandKey;

      EditorGUILayout.BeginHorizontal();
      {
         GUILayout.Label(action, GUILayout.Width(220));

         for (int c = 0; c < cmds.Length; c++)
         {
            // Separate multiple commands
            if (c != 0)
            {
               GUILayout.Label("or", styleCommandOr);
            }

            // Separate compound commands
            string[] keys = cmds[c].Split('+');

            for (int k = 0; k < keys.Length; k++)
            {
               if (k != 0)
               {
                  GUILayout.Label("+", styleCommandPlus);
               }

               string[] parts = keys[k].Split('_');

               for (int p = 0; p < parts.Length; p++)
               {
                  string part = parts[p];

                  // Expand text
                  if (part == "LMB")
                  {
                     part = "Left Mouse Button";
                  }
                  else if (part == "MMB")
                  {
                     part = "Middle Mouse Button";
                  }
                  else if (part == "RMB")
                  {
                     part = "Right Mouse Button";
                  }
                  else if (part == "MouseWheel")
                  {
                     part = "Mouse Wheel";
                  }

                  // Determine style
                  if (part[0] == '.' && part.Length > 1)
                  {
                     labelStyle = styleCommandContext;
                     part = part.Substring(1);
                  }
                  else if (part == "or")
                  {
                     labelStyle = styleCommandOr;
                  }
                  else if (part.ToLower().Contains("mouse"))
                  {
                     labelStyle = styleCommandMouse;
                  }
                  else
                  {
                     labelStyle = styleCommandKey;
                  }

                  // Format command keys for Mac
                  part = ApplyMacFormatting(part);

                  // Determine label width
                  int labelWidth = (int)Mathf.Max(minWidthKey, labelStyle.CalcSize(new GUIContent(part)).x);

                  GUILayout.Label(part, labelStyle, GUILayout.Width(labelWidth));
               }
            }
         }
      }
      EditorGUILayout.EndHorizontal();
   }

   private string ApplyMacFormatting(string key)
   {
      if (isWindows == false)
      {
         // Update key modifier when on Mac
         if (key == "Ctrl")
         {
            key = "Command";
         }

         switch (key)
         {
            case "Escape":
               return uScriptGUI.keyEscape + " Escape";

            case "Shift":
               return uScriptGUI.keyShift + " Shift";

            case "Ctrl":
               return uScriptGUI.keyControl + " Control";

            case "Alt":
               return uScriptGUI.keyOption + " Option";

            case "Command":
               return uScriptGUI.keyCommand + " Command";

            case "Delete":
               return uScriptGUI.keyDelete + " Delete";

            case "Backspace":
               return uScriptGUI.keyBackspace + " Delete";

            case "Return":
               return uScriptGUI.keyReturn + " Return";
         }
      }
      return key;
   }

   private void UpdateCustomStyles()
   {
      // Setup the custom styles for this window
      styleWindow = new GUIStyle();
      styleWindow.fixedHeight = base.minSize.y;
      styleWindow.fixedWidth = base.minSize.x;
      styleWindow.padding = new RectOffset(32, 32, 16, 32);

      stylePanelIcon = new GUIStyle();
      stylePanelIcon.padding = new RectOffset(0, 32, 0, 0);
      stylePanelIcon.stretchWidth = false;

      stylePanelTitle = new GUIStyle();
      stylePanelTitle.fontSize = 32;
      stylePanelTitle.fontStyle = FontStyle.Bold;
      stylePanelTitle.normal.textColor = EditorStyles.boldLabel.normal.textColor;

      stylePanelDescription = GUI.skin.GetStyle("WordWrappedLabel");

      styleCommandSection = new GUIStyle();
      styleCommandSection.margin = new RectOffset(8, 8, 0, 16);
      styleCommandSection.stretchWidth = true;

      styleCommandSectionDescription = new GUIStyle(EditorStyles.label);
      styleCommandSectionDescription.margin = new RectOffset(4, 4, 4, 16);
      styleCommandSectionDescription.padding = new RectOffset(3, 3, 1, 0);
      styleCommandSectionDescription.wordWrap = true;

      styleCommandKey = new GUIStyle(EditorStyles.miniButton);
      styleCommandKey.margin = new RectOffset(0, 0, 2, 2);
      styleCommandKey.stretchWidth = false;

      styleCommandMouse = new GUIStyle(EditorStyles.boldLabel);
      styleCommandMouse.margin = new RectOffset(0, 0, 2, 2);
      styleCommandMouse.stretchWidth = false;

      styleCommandContext = new GUIStyle(EditorStyles.label);
      styleCommandContext.margin = new RectOffset(2, 2, 2, 2);
      styleCommandContext.stretchWidth = false;

      styleCommandOr = new GUIStyle(EditorStyles.label);
      styleCommandOr.fontStyle = FontStyle.Italic;
      styleCommandOr.margin = new RectOffset(8, 8, 2, 2);
      styleCommandOr.stretchWidth = false;

      styleCommandPlus = new GUIStyle(EditorStyles.label);
      styleCommandPlus.margin = new RectOffset(0, 0, 2, 2);
      styleCommandPlus.stretchWidth = false;

      contentPanelIcon = new GUIContent(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/iconWelcomeLogo.png", typeof(UnityEngine.Texture)) as UnityEngine.Texture);
      contentPanelTitle = new GUIContent("Quick Command Reference");
      contentPanelDescription = new GUIContent("This is summary of the various commands available to you while using the uScript Editor.");

      minWidthKey = (int)Mathf.Max(styleCommandKey.CalcSize(new GUIContent("W")).x, styleCommandKey.CalcSize(new GUIContent("=")).x);

      // Apply skin and platform variations
      if (isProSkin)
      {
         styleCommandKey.padding = (isWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 1, 3));
      }
      else
      {
         styleCommandKey.padding = (isWindows ? new RectOffset(4, 7, 2, 2) : new RectOffset(5, 7, 2, 2));
      }
   }

}
