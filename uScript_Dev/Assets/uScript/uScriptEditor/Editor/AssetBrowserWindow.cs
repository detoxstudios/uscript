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
   private static GUIContent contentWarningMessage;

   // Window
   private static AssetBrowserWindow window;

   private bool firstRun = true;
   private bool saveOnClose;
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

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         GetResourceFolderPaths(Application.dataPath, 0);

         // Set height of the asset scrollview
         this.scrollviewFixedHeight = Style.ListItemOdd.CalcSize(new GUIContent("W")).y * 10;
      }

      if (this.windowPosition != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(this.windowPosition.width + Style.WindowPadding.left + Style.WindowPadding.right, this.windowPosition.height + Style.WindowPadding.top + Style.WindowPadding.bottom);
         base.maxSize = base.minSize;
      }

      EditorGUILayout.BeginVertical(Style.Window);
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
         EditorGUILayout.BeginScrollView(this.scrollviewHeaderPosition, false, false, uScriptGUIStyle.HorizontalColumnScrollbar, uScriptGUIStyle.VerticalColumnScrollbar, Style.ListHeader, GUILayout.Height(Style.ColumnHeaderHeight));
         {
            DrawColumns();
         }
         EditorGUILayout.EndScrollView();
         uScriptGUI.ShowScrollbars();

         // List content
         this.scrollviewListPosition = EditorGUILayout.BeginScrollView(this.scrollviewListPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, Style.ListView, GUILayout.Height(this.scrollviewFixedHeight));
         {
            foreach (KeyValuePair<string, AssetParts> kvp in assetParts)
            {
               evenRow = !evenRow;
               if (GUILayout.Toggle(kvp.Value.FullPath == selectedAssetPath, kvp.Value.Content, (evenRow ? Style.ListItemEven : Style.ListItemOdd), GUILayout.MinWidth(this.listItemWidth)))
               {
                  selectedAssetPath = kvp.Value.FullPath;
                  window.Repaint();
               }
               Rect r = GUILayoutUtility.GetLastRect();

               r.x += this.maxNameWidth + ColumnPadding;
               r.width = this.maxPathWidth;

               GUI.Label(r, kvp.Value.Path, Style.ListItemPath);
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
                  GUILayout.Label(contentWarningMessage, Style.WarningMessage);
               }
               EditorGUILayout.EndHorizontal();
            }

            for (int i=0; i < assetSelection.Count; i++)
            {
               if (GUILayout.Button(assetSelection[i], Style.AssetPingButton))
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
            if (GUILayout.Button("Cancel", Style.CloseButton))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            uScriptGUI.Enabled = !string.IsNullOrEmpty(selectedAssetPath);

            if (GUILayout.Button("Select", Style.CloseButton))
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
      GUILayout.Label(string.Empty, GUIStyle.none, GUILayout.Height(Style.ColumnHeaderHeight), GUILayout.Width(this.listItemWidth));

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

      var r = new Rect(0, 0, this.maxNameWidth + ColumnPadding + 4, Style.ColumnHeaderHeight);
      GUI.Label(r, "Asset Name", Style.ColumnHeader);

      // This right-most column should appear to have an expanded width
      r.x += this.maxNameWidth + ColumnPadding + 4;
      r.width = Mathf.Max(this.maxPathWidth, Style.Window.fixedWidth);
      GUI.Label(r, "Resource Path", Style.ColumnHeader);
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
         PathWidth = Style.ListItemPath.CalcSize(Content).x;

         Content.text = name;
         NameWidth = Style.ListItemOdd.CalcSize(Content).x;

         Content.image = EditorGUIUtility.ObjectContent(null, type).image;

         FullPath = (string.IsNullOrEmpty(path) ? string.Empty : path + "/") + name;
      }
   }

   private static class Style
   {
      public const int ColumnHeaderHeight = 16;

      static Style()
      {
         const int WindowFixedWidth = 310;

         var texturePropertyRowEven = uScriptGUI.GetSkinnedTexture("LineItem");

         WindowPadding = new RectOffset(16, 16, 8, 16);

         ColumnHeader = new GUIStyle(EditorStyles.toolbarButton)
                           {
                              name = "columnHeader",
                              fontStyle = FontStyle.Bold,
                              alignment = TextAnchor.MiddleLeft,
                              padding = new RectOffset(5, 8, 0, 0),
                              fixedHeight = ColumnHeaderHeight,
                              contentOffset = new Vector2(0, -1)
                           };
         ColumnHeader.normal.background = ColumnHeader.onNormal.background;

         Window = new GUIStyle { margin = WindowPadding, fixedWidth = WindowFixedWidth };

         ListView = new GUIStyle(GUI.skin.box)
                       {
                          overflow = new RectOffset(1, 1, 1, 1),
                          margin = new RectOffset(4, 4, 1, 4),
                          padding = new RectOffset(0, 0, 0, 0)
                       };

         ListHeader = new GUIStyle(GUI.skin.box)
                         {
                            overflow = new RectOffset(1, 1, 1, 1),
                            margin = new RectOffset(4, 4, 4, 1)
                         };

         ListItemOdd = new GUIStyle(EditorStyles.toolbarButton)
                          {
                             alignment = TextAnchor.MiddleLeft,
                             fontSize = 11,
                             fontStyle = FontStyle.Bold,
                             contentOffset = new Vector2(0, 0)
                          };
         ListItemOdd.active.background = ListItemOdd.normal.background;
         ListItemOdd.normal.background = null;

         ListItemEven = new GUIStyle(ListItemOdd) { normal = { background = texturePropertyRowEven } };

         ListItemPath = new GUIStyle(ListItemOdd) { fontStyle = FontStyle.Normal };

         AssetPingButton = new GUIStyle(GUI.skin.button) { alignment = TextAnchor.MiddleLeft };

         CloseButton = new GUIStyle(GUI.skin.button) { fixedWidth = (WindowFixedWidth - 20) * 0.5f };

         WarningMessage = new GUIStyle(uScriptGUIStyle.ReferenceText)
                             {
                                margin = new RectOffset(4, 4, 0, 0),
                                padding = new RectOffset(0, 0, 2, 8)
                             };
      }

      public static GUIStyle AssetPingButton { get; private set; }

      public static GUIStyle CloseButton { get; private set; }

      public static GUIStyle ColumnHeader { get; private set; }

      public static GUIStyle ListHeader { get; private set; }
      
      public static GUIStyle ListItemEven { get; private set; }
      
      public static GUIStyle ListItemOdd { get; private set; }
      
      public static GUIStyle ListItemPath { get; private set; }

      public static GUIStyle ListView { get; private set; }

      public static GUIStyle WarningMessage { get; private set; }

      public static GUIStyle Window { get; private set; }

      public static RectOffset WindowPadding { get; private set; }
   }
}
