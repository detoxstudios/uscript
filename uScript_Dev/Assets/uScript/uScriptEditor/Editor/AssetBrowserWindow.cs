// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetBrowserWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the AssetBrowserWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

using Detox.Editor;

using UnityEditor;

using UnityEngine;

public class AssetBrowserWindow : EditorWindow
{
   public static bool isOpen = false;
   public static bool shouldOpen = false;

   public static AssetType assetType;
   public static string assetFilePath = string.Empty;
   public static string nodeKey = string.Empty;

   // extra padding between the Name and Path columns
   private const int ColumnPadding = 32;
   private const int MaximumFolderRecursionDepth = 12;

   // Assets
   private static Dictionary<string, AssetParts> assetParts = new Dictionary<string, AssetParts>();
   private static List<string> assetExtensions; // extensions supported by AssetType
   private static List<string> assetFullPath = new List<string>(); // raw asset paths
   private static List<string> assetSelection = new List<string>();   // selection details

   private static bool evenRow = true;

   private static System.Type type = typeof(object);
   private static string selectedAssetPath = string.Empty;

   // Pre-calculated layout and style data
   private static GUIStyle styleWindow;
   private static GUIStyle styleListView;
   private static GUIStyle styleListHeader;
   private static GUIStyle styleListItemOdd;
   private static GUIStyle styleListItemEven;
   private static GUIStyle styleListItemPath;
   private static GUIStyle styleAssetPingButton;
   private static GUIStyle styleCloseButton;
   private static GUIStyle styleWarningMessage;
   private static GUIContent contentWarningMessage;

   // Window
   private static AssetBrowserWindow window;

   private bool firstRun = true;
   private bool saveOnClose;
   private RectOffset windowPadding = new RectOffset(16, 16, 8, 16);
   private Rect windowPosition;

   // Scrollview
   private Vector2 scrollviewHeaderPosition;
   private Vector2 scrollviewListPosition;
   private float scrollviewFixedHeight;

   // ListItems
   private float maxNameWidth;   // stores the width of the longest asset name
   private float maxPathWidth;   // stores the width of the longest path
   private float listItemWidth;  // calculated (maxNameWidth + columnPadding + maxPathWidth)

   // Create the window
   public static void Init()
   {
      shouldOpen = false;

      switch (assetType)
      {
         case AssetType.AnimationClip:
            assetExtensions = new List<string> { "anim" };
            type = typeof(AnimationClip);
            break;
         case AssetType.AudioClip:
            assetExtensions = new List<string> { "aif", "wav", "mp3", "ogg", "xm", "mod", "it", "s3m" };
            type = typeof(AudioClip);
            break;
         case AssetType.Cubemap:
            assetExtensions = new List<string> { "cubemap" };
            type = typeof(Cubemap);
            break;
         case AssetType.Flare:
            assetExtensions = new List<string> { "flare" };
            type = typeof(Flare);
            break;
         case AssetType.Font:
            assetExtensions = new List<string> { "otf", "ttf" };
            type = typeof(Font);
            break;
         case AssetType.GUISkin:
            assetExtensions = new List<string> { "guiskin" };
            type = typeof(GUISkin);
            break;
         case AssetType.Material:
            assetExtensions = new List<string> { "mat" };
            type = typeof(Material);
            break;
         case AssetType.Mesh:
            assetExtensions = new List<string> { "fbx", "dae", "3ds", "dxf", "obj" };
            type = typeof(Mesh);
            break;
         case AssetType.MovieTexture:
            assetExtensions = new List<string> { "ogg", "mov", "mpg", "mpeg", "mp4", "avi", "asf" };
            type = typeof(MovieTexture);
            break;
         case AssetType.PhysicMaterial:
            assetExtensions = new List<string> { "physicmaterial" };
            type = typeof(PhysicMaterial);
            break;
         case AssetType.Prefab:
            assetExtensions = new List<string> { "prefab" };
            type = typeof(GameObject);
            break;
         case AssetType.RenderTexture:
            assetExtensions = new List<string> { "rendertexture" };
            type = typeof(RenderTexture);
            break;
         case AssetType.Shader:
            assetExtensions = new List<string> { "shader" };
            type = typeof(Shader);
            break;
         case AssetType.TextAsset:
            assetExtensions = new List<string> { "txt", "html", "htm", "xml", "bytes" };
            type = typeof(TextAsset);
            break;
         case AssetType.Texture2D:
            assetExtensions = new List<string> { "psd", "tiff", "jpg", "tga", "png", "gif", "bmp", "iff", "pict" };
            type = typeof(Texture2D);
            break;
      }

      // prepare the static content for the window
      contentWarningMessage = new GUIContent("Multiple assets with the same name resolve to a single path. Unexpected results may occur when loading this resource.");

      // Take in the original file name and path. If a match exists, that should be the default selection.
      // If there was no match, the first element should be selection initially.
      // If the list is empty, the "select" button should be disabled.
      // When the "cancel" button is clicked, the window should return the original selection information (even if invalid).
      // When the "select" button is clicked, the window should return the new selection path and name.
      // If the path is different than the original, the "Resources Path" control should be updated.

      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<AssetBrowserWindow>(true, "uScript Resource Asset Browser", true) as AssetBrowserWindow;
      window.firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
      window.Focus();
   }

   internal void Update()
   {
      if (isOpen && (focusedWindow != null) && (focusedWindow.GetType() != typeof(AssetBrowserWindow)))
      {
         EditorWindow.FocusWindowIfItsOpen<AssetBrowserWindow>();
      }
   }

   internal void OnEnable()
   {
      isOpen = true;
      selectedAssetPath = assetFilePath;
   }

   internal void OnDisable()
   {
      if (this.saveOnClose)
      {
         assetFilePath = selectedAssetPath;
      }

      isOpen = false;
      selectedAssetPath = string.Empty;
   }

   void OnGUI()
   {
      if (this.firstRun)
      {
         this.firstRun = false;

         int _windowFixedWidth = 310;

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         // Setup the custom GUIStyles used to layout the window
         styleWindow = new GUIStyle();
         styleWindow.margin = this.windowPadding;
         styleWindow.fixedWidth = _windowFixedWidth;

         styleListView = new GUIStyle(GUI.skin.box);
         styleListView.overflow = new RectOffset(1, 1, 1, 1);
         styleListView.margin = new RectOffset(4, 4, 1, 4);
         styleListView.padding = new RectOffset(0, 0, 0, 0);

         styleListHeader = new GUIStyle(GUI.skin.box);
         styleListHeader.overflow = new RectOffset(1, 1, 1, 1);
         styleListHeader.margin = new RectOffset(4, 4, 4, 1);

         styleListItemOdd = new GUIStyle(EditorStyles.toolbarButton);
         styleListItemOdd.alignment = TextAnchor.MiddleLeft;
         styleListItemOdd.active.background = styleListItemOdd.normal.background;
         styleListItemOdd.normal.background = null;
         styleListItemOdd.fontSize = 11;
         styleListItemOdd.fontStyle = FontStyle.Bold;
         styleListItemOdd.contentOffset = new Vector2(0, 0);

         styleListItemEven = new GUIStyle(styleListItemOdd);
         styleListItemEven.normal.background = uScriptGUIStyle.PropertyRowEven.normal.background;

         styleListItemPath = new GUIStyle(styleListItemOdd);
         styleListItemPath.fontStyle = FontStyle.Normal;

         styleAssetPingButton = new GUIStyle(GUI.skin.button);
         styleAssetPingButton.alignment = TextAnchor.MiddleLeft;

         styleCloseButton = new GUIStyle(GUI.skin.button);
         styleCloseButton.fixedWidth = (_windowFixedWidth - 20) * 0.5f;

         styleWarningMessage = new GUIStyle(uScriptGUIStyle.ReferenceText);
         styleWarningMessage.margin = new RectOffset(4, 4, 0, 0);
         styleWarningMessage.padding = new RectOffset(0, 0, 2, 8);

         GetResourceFolderPaths(Application.dataPath, 0);

         // Set height of the asset scrollview
         this.scrollviewFixedHeight = styleListItemOdd.CalcSize(new GUIContent("W")).y * 10;
      }

      if (this.windowPosition != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(this.windowPosition.width + this.windowPadding.left + this.windowPadding.right, this.windowPosition.height + this.windowPadding.top + this.windowPadding.bottom);
         base.maxSize = base.minSize;
      }

      EditorGUILayout.BeginVertical(styleWindow);
      {
         EditorGUI.indentLevel = 1;

         // List label
         EditorGUILayout.BeginHorizontal();
         {
            // Display the name from the AssetType Enum which could differ from the actual type name
            string typeName = System.Enum.GetName(typeof(AssetType), (int)assetType);
            GUILayout.Label("Select a " + typeName + ":", EditorStyles.boldLabel, GUILayout.ExpandWidth(true));

            if (GUILayout.Button(uScriptGUIContent.iconHelp16, GUIStyle.none, GUILayout.ExpandWidth(false)))
            {
               Help.ShowHelpPage("file:///unity/Components/class-" + type.Name + ".html");
            }
         }
         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Space();

         // List header
         uScriptGUI.HideScrollbars();
         this.scrollviewHeaderPosition.x = this.scrollviewListPosition.x;
         EditorGUILayout.BeginScrollView(this.scrollviewHeaderPosition, false, false, uScriptGUIStyle.HorizontalColumnScrollbar, uScriptGUIStyle.VerticalColumnScrollbar, styleListHeader, GUILayout.Height(uScriptGUIStyle.ColumnHeaderHeight));
         {
            DrawColumns();
         }
         EditorGUILayout.EndScrollView();
         uScriptGUI.ShowScrollbars();

         // List content
         this.scrollviewListPosition = EditorGUILayout.BeginScrollView(this.scrollviewListPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, styleListView, GUILayout.Height(this.scrollviewFixedHeight));
         {
            foreach (KeyValuePair<string, AssetParts> kvp in assetParts)
            {
               evenRow = !evenRow;
               if (GUILayout.Toggle(kvp.Value.FullPath == selectedAssetPath, kvp.Value.Content, (evenRow ? styleListItemEven : styleListItemOdd), GUILayout.MinWidth(this.listItemWidth)))
               {
                  selectedAssetPath = kvp.Value.FullPath;
                  window.Repaint();
               }
               Rect r = GUILayoutUtility.GetLastRect();

               r.x += this.maxNameWidth + ColumnPadding;
               r.width = this.maxPathWidth;

               GUI.Label(r, kvp.Value.Path, styleListItemPath);
            }
         }
         EditorGUILayout.EndScrollView();

         // Get the list of assets associated with the current selection
         assetSelection.Clear();
         if (string.IsNullOrEmpty(selectedAssetPath) == false)
         {
            string path;
            for (int i=0; i < assetFullPath.Count; i++)
            {
               path = assetFullPath[i];
               // adding the "." is a hack to avoid "AssetName.ext" matching "AssetName2.ext"
               if (path.Contains("/Resources/" + selectedAssetPath + "."))
               {
                  assetSelection.Add(path.Substring(Application.dataPath.Length + 1));
               }
            }
         }

         if (assetSelection.Count > 0)
         {
            EditorGUILayout.Separator();
   
            GUILayout.Label("Selection details:", EditorStyles.boldLabel);

            if (assetSelection.Count > 1)
            {
               EditorGUILayout.BeginHorizontal();
               {
                  GUILayout.Label(uScriptGUIContent.iconWarn32, GUIStyle.none);
                  GUILayout.Label(contentWarningMessage, styleWarningMessage);
               }
               EditorGUILayout.EndHorizontal();
            }

            for (int i=0; i < assetSelection.Count; i++)
            {
               if (GUILayout.Button(assetSelection[i], styleAssetPingButton))
               {
                  uScriptGUI.PingObject("Assets/" + assetSelection[i], type);
               }
            }
         }

         EditorGUILayout.Separator();
         EditorGUILayout.Space();
         EditorGUILayout.Separator();

         //save or cancel
         EditorGUILayout.BeginHorizontal();
         {
            if (GUILayout.Button("Cancel", styleCloseButton))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            uScriptGUI.Enabled = !string.IsNullOrEmpty(selectedAssetPath);

            if (GUILayout.Button("Select", styleCloseButton))
            {
               this.saveOnClose = true;
               this.Close();
            }

            uScriptGUI.Enabled = true;
         }
         EditorGUILayout.EndHorizontal();

         EditorGUI.indentLevel = 0;
      }
      EditorGUILayout.EndVertical();

      if (Event.current.type == EventType.Repaint)
      {
         this.windowPosition = GUILayoutUtility.GetLastRect();
      }
   }

   private void GetResourceFolderPaths(string sourceDir, int recursionDepth)
   {
      sourceDir = sourceDir.Replace('\\', '/');

      if (recursionDepth == 0)
      {
         assetFullPath.Clear();
         assetParts.Clear();
         assetSelection.Clear();
      }

      if (recursionDepth <= MaximumFolderRecursionDepth)
      {
         // Grab the valid paths
         if ((sourceDir.EndsWith("/Resources") || sourceDir.Contains("/Resources/"))
             && sourceDir.Contains("/.svn") == false)
         {
            string modified;
            string path;
            string name;
            string ext;
            int i;

            // Process the list of files found in the directory.
            string [] fileEntries = Directory.GetFiles(sourceDir);
            foreach (string fileName in fileEntries)
            {
               modified = fileName.Replace('\\', '/');

               // get the extension
               i = modified.LastIndexOf('.');
               ext = (i < 0 || i + 1 >= modified.Length ? string.Empty : modified.Substring(i + 1)).ToLower();

               // filter by asset type extensions
               if (assetExtensions.Contains(ext))
               {
                  assetFullPath.Add(modified);

                  // remove the extension
                  if (i != -1)
                  {
                     modified = modified.Substring(0, i);
                  }

                  modified = modified.Substring(modified.IndexOf("/Resources/") + 11);

                  // get the name
                  i = modified.LastIndexOf('/');

                  if (i < 0)
                  {
                     name = modified;
                     path = string.Empty;
                  }
                  else
                  {
                     name = modified.Substring(i + 1);
                     path = modified.Substring(0, i);
                  }

                  // add the asset to the list
                  string assetKey = name + "/" + path;

                  if (assetParts.ContainsKey(assetKey) == false)
                  {
                     assetParts[assetKey] = new AssetParts(name, path, type);

                     this.maxNameWidth = Mathf.Max(this.maxNameWidth, assetParts[assetKey].NameWidth);
                     this.maxPathWidth = Mathf.Max(this.maxPathWidth, assetParts[assetKey].PathWidth);
                     this.listItemWidth = (this.maxNameWidth + ColumnPadding + this.maxPathWidth);
                  }
               }
            }
         }

         // Recurse into subdirectories of this directory.
         string [] subdirEntries = Directory.GetDirectories(sourceDir);
         foreach (string subdir in subdirEntries)
         {
            // Do not iterate through reparse points
            if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
               GetResourceFolderPaths(subdir, recursionDepth + 1);
            }
         }

//         // Sort the results
//         if (recursionDepth == 0)
//         {
//         }
      }
   }

   private void DrawColumns()
   {
      // Block out an area for the column header using GUILayout
      GUILayout.Label(string.Empty, GUIStyle.none, GUILayout.Height(uScriptGUIStyle.ColumnHeaderHeight), GUILayout.Width(this.listItemWidth));

      // The columns have a margin of 4. Margins of adjacent cells overlap, so the spacing
      // betweem columns is the width of the largest margin, not the sum.
      //
      //    4.[A].4
      //          4.[B].4
      //
      //    4.[A].4.[B].4
      //
      // The result should be that when laying out each column, the left-most and right-most
      // columns should allow for an extra 2px, while the inner columns assume that 2px will
      // be used on each side.
      //
      // Finally, the left margin of the left column, and the right margin of the right column
      // is excluded when positioning the GUI elements, since the offset is automatically applied.

      Rect r = new Rect(0, 0, (this.maxNameWidth + ColumnPadding + 4), uScriptGUIStyle.ColumnHeaderHeight);
      GUI.Label(r, "Asset Name", uScriptGUIStyle.ColumnHeader);

      // This right-most column should appear to have an expanded width
      r.x += (this.maxNameWidth + ColumnPadding + 4);
      r.width = Mathf.Max(this.maxPathWidth, styleWindow.fixedWidth);
      GUI.Label(r, "Resource Path", uScriptGUIStyle.ColumnHeader);
   }

   struct AssetParts
   {
      public GUIContent Content { get; private set; }

      public string Name
      {
         get
         {
            return Content.text;
         }
      }

      public string Path { get; private set; }

      public string FullPath { get; private set; }

      public float NameWidth { get; private set; }

      public float PathWidth { get; private set; }

      public AssetParts(string name, string path, System.Type type)
         : this()
      {
         Path = path;

         Content = new GUIContent(path);
         PathWidth = styleListItemPath.CalcSize(Content).x;

         Content.text = name;
         NameWidth = styleListItemOdd.CalcSize(Content).x;

         Content.image = EditorGUIUtility.ObjectContent(null, type).image;

         FullPath = (string.IsNullOrEmpty(path) ? string.Empty : path + "/") + name;
      }
   }
}
