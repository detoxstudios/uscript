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

      public AssetParts(string name, string path, System.Type type) : this()
      {
         Path = path;

         Content = new GUIContent(path);
         PathWidth = _styleListItemPath.CalcSize(Content).x;

         Content.text = name;
         NameWidth = _styleListItem_Odd.CalcSize(Content).x;

         Content.image = EditorGUIUtility.ObjectContent(null, type).image;

         FullPath = (string.IsNullOrEmpty(path) ? string.Empty : path + "/") + name;
      }
   }

   // Window
   static AssetBrowserWindow _window = null;
   bool _firstRun = true;
   bool _saveOnClose = false;
   static public bool isOpen = false;
   static public bool shouldOpen = false;
   RectOffset _windowPadding = new RectOffset(16, 16, 8, 16);
   Rect _windowPosition;

   // Scrollview
   Vector2 _svHeaderPosition;
   Vector2 _svListPosition;
   float _svFixedHeight;

   // ListItems
   static bool _evenRow = true;
   float _maxNameWidth;                   // stores the width of the longest asset name
   float _maxPathWidth;                   // stores the width of the longest path
   float _listItemWidth;                  // calculated (_maxNameWidth + _columnPadding + _maxPathWidth)
   const int _columnPadding = 32;         // extra padding between the Name and Path columns


   // Assets
   static Dictionary<string, AssetParts> _assetParts = new Dictionary<string, AssetParts>();
   static List<string> _assetExtensions = null;                // contains the extensions supported by AssetType
   static List<string> _assetFullPath = new List<string>();    // contains raw paths of all assets
   static List<string> _assetSelection = new List<string>();   // contains current selection details with conflicts

   static public AssetType assetType;
   static public string assetFilePath = string.Empty;
   static public string nodeKey = string.Empty;
   static System.Type _assetType = typeof(object);
   static string _selectedAssetPath = string.Empty;
   const int _maximumFolderRecursioDepth = 12;

   // Pre-calculated layout and style data
   static GUIStyle _styleWindow;
   static GUIStyle _styleListView;
   static GUIStyle _styleListHeader;
   static GUIStyle _styleListItem_Odd;
   static GUIStyle _styleListItem_Even;
   static GUIStyle _styleListItemPath;
   static GUIStyle _styleAssetPingButton = null;
   static GUIStyle _styleCloseButton;
   static GUIStyle _styleWarningMessage = null;
   static GUIContent _contentWarningMessage = null;

   // Create the window
   public static void Init()
   {
      shouldOpen = false;

      switch (assetType)
      {
         case AssetType.AnimationClip:
            _assetExtensions = new List<string> { "anim" };
            _assetType = typeof(AnimationClip);
            break;
         case AssetType.AudioClip:
            _assetExtensions = new List<string> { "aif", "wav", "mp3", "ogg", "xm", "mod", "it", "s3m" };
            _assetType = typeof(AudioClip);
            break;
         case AssetType.Cubemap:
            _assetExtensions = new List<string> { "cubemap" };
            _assetType = typeof(Cubemap);
            break;
         case AssetType.Flare:
            _assetExtensions = new List<string> { "flare" };
            _assetType = typeof(Flare);
            break;
         case AssetType.Font:
            _assetExtensions = new List<string> { "otf", "ttf" };
            _assetType = typeof(Font);
            break;
         case AssetType.GUISkin:
            _assetExtensions = new List<string> { "guiskin" };
            _assetType = typeof(GUISkin);
            break;
         case AssetType.Material:
            _assetExtensions = new List<string> { "mat" };
            _assetType = typeof(Material);
            break;
         case AssetType.Mesh:
            _assetExtensions = new List<string> { "fbx", "dae", "3ds", "dxf", "obj" };
            _assetType = typeof(Mesh);
            break;
         case AssetType.MovieTexture:
            _assetExtensions = new List<string> { "ogg", "mov", "mpg", "mpeg", "mp4", "avi", "asf" };
            _assetType = typeof(MovieTexture);
            break;
         case AssetType.PhysicMaterial:
            _assetExtensions = new List<string> { "physicmaterial" };
            _assetType = typeof(PhysicMaterial);
            break;
         case AssetType.Prefab:
            _assetExtensions = new List<string> { "prefab" };
            _assetType = typeof(GameObject);
            break;
         case AssetType.RenderTexture:
            _assetExtensions = new List<string> { "rendertexture" };
            _assetType = typeof(RenderTexture);
            break;
         case AssetType.Shader:
            _assetExtensions = new List<string> { "shader" };
            _assetType = typeof(Shader);
            break;
         case AssetType.TextAsset:
            _assetExtensions = new List<string> { "txt", "html", "htm", "xml", "bytes" };
            _assetType = typeof(TextAsset);
            break;
         case AssetType.Texture2D:
            _assetExtensions = new List<string> { "psd", "tiff", "jpg", "tga", "png", "gif", "bmp", "iff", "pict" };
            _assetType = typeof(Texture2D);
            break;
      }

      // prepare the static content for the window
      _contentWarningMessage = new GUIContent("Multiple assets with the same name resolve to a single path. Unexpected results may occur when loading this resource.");


      // Take in the original file name and path. If a match exists, that should be the default selection.
      // If there was no match, the first element should be selection initially.
      // If the list is empty, the "select" button should be disabled.
      // When the "cancel" button is clicked, the window should return the original selection information (even if invalid).
      // When the "select" button is clicked, the window should return the new selection path and name.
      // If the path is different than the original, the "Resources Path" control should be updated.

      // Get existing open window or if none, make a new one:
      _window = EditorWindow.GetWindow<AssetBrowserWindow>(true, "uScript Resource Asset Browser", true) as AssetBrowserWindow;
      _window._firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
      _window.Focus();
   }

   void Update()
   {
      if (isOpen && (focusedWindow != null) && (focusedWindow.GetType() != typeof(AssetBrowserWindow)))
      {
         EditorWindow.FocusWindowIfItsOpen<AssetBrowserWindow>();
      }
   }

   void OnEnable()
   {
      isOpen = true;
      _selectedAssetPath = assetFilePath;
   }

   void OnDisable()
   {
      if (_saveOnClose)
      {
         assetFilePath = _selectedAssetPath;
      }

      isOpen = false;
      _selectedAssetPath = string.Empty;
   }

   void OnGUI()
   {
      if (_firstRun)
      {
         _firstRun = false;

         int _windowFixedWidth = 310;

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         // Setup the custom GUIStyles used to layout the window
         _styleWindow = new GUIStyle();
         _styleWindow.margin = _windowPadding;
         _styleWindow.fixedWidth = _windowFixedWidth;

         _styleListView = new GUIStyle(GUI.skin.box);
         _styleListView.overflow = new RectOffset(1, 1, 1, 1);
         _styleListView.margin = new RectOffset(4, 4, 1, 4);
         _styleListView.padding = new RectOffset(0, 0, 0, 0);

         _styleListHeader = new GUIStyle(GUI.skin.box);
         _styleListHeader.overflow = new RectOffset(1, 1, 1, 1);
         _styleListHeader.margin = new RectOffset(4, 4, 4, 1);

         _styleListItem_Odd = new GUIStyle(EditorStyles.toolbarButton);
         _styleListItem_Odd.alignment = TextAnchor.MiddleLeft;
         _styleListItem_Odd.active.background = _styleListItem_Odd.normal.background;
         _styleListItem_Odd.normal.background = null;
         _styleListItem_Odd.fontSize = 11;
         _styleListItem_Odd.fontStyle = FontStyle.Bold;
         _styleListItem_Odd.contentOffset = new Vector2(0, 0);

         _styleListItem_Even = new GUIStyle(_styleListItem_Odd);
         _styleListItem_Even.normal.background = uScriptGUIStyle.PropertyRowEven.normal.background;

         _styleListItemPath = new GUIStyle(_styleListItem_Odd);
         _styleListItemPath.fontStyle = FontStyle.Normal;

         _styleAssetPingButton = new GUIStyle(GUI.skin.button);
         _styleAssetPingButton.alignment = TextAnchor.MiddleLeft;

         _styleCloseButton = new GUIStyle(GUI.skin.button);
         _styleCloseButton.fixedWidth = (_windowFixedWidth - 20) * 0.5f;

         _styleWarningMessage = new GUIStyle(uScriptGUIStyle.ReferenceText);
         _styleWarningMessage.margin = new RectOffset(4, 4, 0, 0);
         _styleWarningMessage.padding = new RectOffset(0, 0, 2, 8);

         GetResourceFolderPaths(Application.dataPath, 0);

         // Set height of the asset scrollview
         _svFixedHeight = _styleListItem_Odd.CalcSize(new GUIContent("W")).y * 10;
      }

      if (_windowPosition != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(_windowPosition.width + _windowPadding.left + _windowPadding.right, _windowPosition.height + _windowPadding.top + _windowPadding.bottom);
         base.maxSize = base.minSize;
      }

      EditorGUILayout.BeginVertical(_styleWindow);
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
               Help.ShowHelpPage("file:///unity/Components/class-" + _assetType.Name + ".html");
            }
         }
         EditorGUILayout.EndHorizontal();

         EditorGUILayout.Space();

         // List header
         uScriptGUI.HideScrollbars();
         _svHeaderPosition.x = _svListPosition.x;
         EditorGUILayout.BeginScrollView(_svHeaderPosition, false, false, uScriptGUIStyle.HorizontalColumnScrollbar, uScriptGUIStyle.VerticalColumnScrollbar, _styleListHeader, GUILayout.Height(uScriptGUIStyle.ColumnHeaderHeight));
         {
            DrawColumns();
         }
         EditorGUILayout.EndScrollView();
         uScriptGUI.ShowScrollbars();

         // List content
         _svListPosition = EditorGUILayout.BeginScrollView(_svListPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, _styleListView, GUILayout.Height(_svFixedHeight));
         {
            foreach (KeyValuePair<string, AssetParts> kvp in _assetParts)
            {
               _evenRow = !_evenRow;
               if (GUILayout.Toggle(kvp.Value.FullPath == _selectedAssetPath, kvp.Value.Content, (_evenRow ? _styleListItem_Even : _styleListItem_Odd), GUILayout.MinWidth(_listItemWidth)))
               {
                  _selectedAssetPath = kvp.Value.FullPath;
                  _window.Repaint();
               }
               Rect r = GUILayoutUtility.GetLastRect();

               r.x += _maxNameWidth + _columnPadding;
               r.width = _maxPathWidth;

               GUI.Label(r, kvp.Value.Path, _styleListItemPath);
            }
         }
         EditorGUILayout.EndScrollView();

         // Get the list of assets associated with the current selection
         _assetSelection.Clear();
         if (string.IsNullOrEmpty(_selectedAssetPath) == false)
         {
            string path;
            for (int i=0; i < _assetFullPath.Count; i++)
            {
               path = _assetFullPath[i];
               // adding the "." is a hack to avoid "AssetName.ext" matching "AssetName2.ext"
               if (path.Contains("/Resources/" + _selectedAssetPath + "."))
               {
                  _assetSelection.Add(path.Substring(Application.dataPath.Length + 1));
               }
            }
         }

         if (_assetSelection.Count > 0)
         {
            EditorGUILayout.Separator();
   
            GUILayout.Label("Selection details:", EditorStyles.boldLabel);

            if (_assetSelection.Count > 1)
            {
               EditorGUILayout.BeginHorizontal();
               {
                  GUILayout.Label(uScriptGUIContent.iconWarn32, GUIStyle.none);
                  GUILayout.Label(_contentWarningMessage, _styleWarningMessage);
               }
               EditorGUILayout.EndHorizontal();
            }

            for (int i=0; i < _assetSelection.Count; i++)
            {
               if (GUILayout.Button(_assetSelection[i], _styleAssetPingButton))
               {
                  uScriptGUI.PingObject("Assets/" + _assetSelection[i], _assetType);
               }
            }
         }

         EditorGUILayout.Separator();
         EditorGUILayout.Space();
         EditorGUILayout.Separator();

         //save or cancel
         EditorGUILayout.BeginHorizontal();
         {
            if (GUILayout.Button("Cancel", _styleCloseButton))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            uScriptGUI.Enabled = !string.IsNullOrEmpty(_selectedAssetPath);

            if (GUILayout.Button("Select", _styleCloseButton))
            {
               _saveOnClose = true;
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
         _windowPosition = GUILayoutUtility.GetLastRect();
      }
   }

   private void GetResourceFolderPaths(string sourceDir, int recursionDepth)
   {
      sourceDir = sourceDir.Replace('\\', '/');

      if (recursionDepth == 0)
      {
         _assetFullPath.Clear();
         _assetParts.Clear();
         _assetSelection.Clear();
      }

      if (recursionDepth <= _maximumFolderRecursioDepth)
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
               if (_assetExtensions.Contains(ext))
               {
                  _assetFullPath.Add(modified);

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

                  if (_assetParts.ContainsKey(assetKey) == false)
                  {
                     _assetParts[assetKey] = new AssetParts(name, path, _assetType);

                     _maxNameWidth = Mathf.Max(_maxNameWidth, _assetParts[assetKey].NameWidth);
                     _maxPathWidth = Mathf.Max(_maxPathWidth, _assetParts[assetKey].PathWidth);
                     _listItemWidth = (_maxNameWidth + _columnPadding + _maxPathWidth);
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
      GUILayout.Label(string.Empty, GUIStyle.none, GUILayout.Height(uScriptGUIStyle.ColumnHeaderHeight), GUILayout.Width(_listItemWidth));

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

      Rect r = new Rect(0, 0, (_maxNameWidth + _columnPadding + 4), uScriptGUIStyle.ColumnHeaderHeight);
      GUI.Label(r, "Asset Name", uScriptGUIStyle.ColumnHeader);

      // This right-most column should appear to have an expanded width
      r.x += (_maxNameWidth + _columnPadding + 4);
      r.width = Mathf.Max(_maxPathWidth, _styleWindow.fixedWidth);
      GUI.Label(r, "Resource Path", uScriptGUIStyle.ColumnHeader);
   }

}
