using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Reflection;



// The list of asset types supported by the AssetBrowserWindow class
public enum AssetType
{
   AnimationClip,
   AudioClip,
   BinaryAsset,
   Material,
   Mesh,
   MovieTexture,
   TextAsset,
   Texture2D
//    Cubemap Texture
//    Flare
//    Font : .ttf
//    Procedural Material Assets
//    Render Texture
}




public class AssetBrowserWindow : EditorWindow
{
   const int _labelWidth = 200;
   const int _valueWidth = 110;

   const int _minGridSize = 8;
   const int _maxGridSize = 100;
   const int _minGridMajorSpacing = 1;
   const int _maxGridMagicSpacing = 10;

   RectOffset _padding = new RectOffset(16, 16, 8, 16);

   static bool _evenRow = true;

   bool _firstRun = true;
   bool _saveOnClose = false;
   Rect _position;

   static AssetBrowserWindow window = null;


   static public bool isOpen = false;
   static public bool shouldOpen = false;

   static public AssetType assetType;
   static public string assetFilePath = string.Empty;
   static public string propertyKey = string.Empty;

   static List<string> _assetExtensions = null;                // contains the extensions supported by AssetType
   static List<string> _assetFullPath = new List<string>();    // contains raw paths of all assets
   static List<string> _assetSelection = new List<string>();   // contains current selection details with conflicts

   static Dictionary<string, AssetParts> _assetParts = new Dictionary<string, AssetParts>();
   struct AssetParts
   {
      public string Name;
      public float NameWidth;
      public string Path;
      public float PathWidth;

      public AssetParts(string name, string path)
      {
         Name = name;
         Path = path;

         GUIContent content = new GUIContent(name);
         NameWidth = _styleListItemName.CalcSize(content).x;

         content.text = path;
         PathWidth = _styleListItemPath.CalcSize(content).x;
      }

      public override string ToString()
      {
         return "\"" + Name + "\" (" + NameWidth + "), \"" + Path + "\" (" + PathWidth + ")";
      }
   }

   static float _maxNameWidth = 0;        // stores the max width of all asset names
   static float _maxPathWidth = 0;        // stores the max width of the longest path
   const int _columnPadding = 32;         // extra padding between the Name and Path columns


   Vector2 _scrollviewAssets = Vector2.zero;
//   Vector2 _scrollviewDetails = Vector2.zero;

   Rect _svRect = new Rect();

   // asset list
   static string _selectedAssetPath = string.Empty;


   // How much deep to scan subfolders
   const int _maximumFolderRecursioDepth = 12;

   static System.Type _type = typeof(object);


   static GUIStyle _styleWindow;
   static GUIStyle _styleCloseButton;

   static GUIStyle _styleListHeader;
   static GUIStyle _styleListScrollView;
   static GUIStyle _styleListItemName;
   static GUIStyle _styleListItemNameEvenRow;
   static GUIStyle _styleListItemPath;

   static GUIStyle _styleWarningMessage = null;
   static GUIStyle _styleAssetPingButton = null;

   static GUIContent _contentHelpIcon = null;
   static GUIContent _contentWarningIcon = null;
   static GUIContent _contentWarningMessage = null;








   // Create the window
   public static void Init()
   {
      shouldOpen = false;

      switch (assetType)
      {
         case AssetType.AnimationClip:
            _assetExtensions = new List<string> { "anim" };
            _type = typeof(AnimationClip);
            break;
         case AssetType.AudioClip:
            _assetExtensions = new List<string> { "aif", "wav", "mp3", "ogg", "xm", "mod", "it", "s3m" };
            _type = typeof(AudioClip);
            break;
         case AssetType.BinaryAsset:
            _assetExtensions = new List<string> { "bytes" };
            _type = typeof(TextAsset);
            break;
         case AssetType.Material:
            _assetExtensions = new List<string> { "mat" };
            _type = typeof(Material);
            break;
         case AssetType.Mesh:
            _assetExtensions = new List<string> { "fbx", "dae", "3ds", "dxf", "obj" };
            _type = typeof(Mesh);
            break;
         case AssetType.MovieTexture:
            _assetExtensions = new List<string> { "mov", "mpg", "mpeg", "mp4", "avi", "asf" };
            _type = typeof(MovieTexture);
            break;
         case AssetType.TextAsset:
            _assetExtensions = new List<string> { "txt", "html", "htm", "xml" };
            _type = typeof(TextAsset);
            break;
         case AssetType.Texture2D:
            _assetExtensions = new List<string> { "psd", "tiff", "jpg", "tga", "png", "gif", "bmp", "iff", "pict" };
            _type = typeof(Texture2D);
            break;
      }

      // prepare the static content for the window
      Texture2D icon;
      icon = EditorGUIUtility.LoadRequired("Builtin Skins/Icons/_Help.png") as Texture2D;
      _contentHelpIcon = new GUIContent(icon);

      icon = EditorGUIUtility.LoadRequired("Builtin Skins/Icons/console.warnicon.png") as Texture2D;
      _contentWarningIcon = new GUIContent(icon);
      _contentWarningMessage = new GUIContent("Multiple assets with the same name resolve to a single path. Unexpected results may occur when loading this resource.");


      // Take in the original file name and path. If a match exists, that should be the default selection.
      // If there was no match, the first element should be selection initially.
      // If the list is empty, the "select" button should be disabled.
      // When the "cancel" button is clicked, the window should return the original selection information (even if invalid).
      // When the "select" button is clicked, the window should return the new selection path and name.
      // If the path is different than the original, the "Resources Path" control should be updated.


      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<AssetBrowserWindow>(true, "uScript Resource Asset Browser", true) as AssetBrowserWindow;
      window._firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
      window.Focus();
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

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         // Setup the custom GUIStyles used to layout the window
         _styleWindow = new GUIStyle();
         _styleWindow.margin = _padding;
         _styleWindow.fixedWidth = _labelWidth + _valueWidth;
   
         _styleCloseButton = new GUIStyle(GUI.skin.button);
         _styleCloseButton.fixedWidth = (_labelWidth + _valueWidth - 4 - _styleCloseButton.margin.left * 4) * 0.5f;

         _styleListHeader = new GUIStyle(GUI.skin.box);
         _styleListHeader.name = "_styleListHeader";
         _styleListHeader.overflow = new RectOffset(1, 1, 1, 1);
         _styleListHeader.margin = new RectOffset(4, 4, 4, 1);

         _styleListScrollView = new GUIStyle(GUI.skin.box);
         _styleListScrollView.name = "_styleListScrollView";
         _styleListScrollView.overflow = new RectOffset(1, 1, 1, 1);
         _styleListScrollView.margin = new RectOffset(4, 4, 1, 4);
         _styleListScrollView.padding = new RectOffset(0, 0, 0, 0);

//         uScriptGUIStyle.DebugInformation(GUI.skin.box);
//         uScriptGUIStyle.DebugInformation(uScriptGUIStyle.columnScrollView);
//         uScriptGUIStyle.DebugInformation(_styleListHeader);
//         uScriptGUIStyle.DebugInformation(_styleListScrollView);

         _styleListItemName = new GUIStyle(EditorStyles.toolbarButton);
         _styleListItemName.alignment = TextAnchor.MiddleLeft;
         _styleListItemName.active.background = _styleListItemName.normal.background;
         _styleListItemName.normal.background = null;
         _styleListItemName.fontSize = 11;
         _styleListItemName.fontStyle = FontStyle.Bold;
         _styleListItemName.contentOffset = new Vector2(0, 0);

         _styleListItemNameEvenRow = new GUIStyle(_styleListItemName);
         _styleListItemNameEvenRow.normal.background = new Texture2D(16, 16);

         _styleListItemPath = new GUIStyle(_styleListItemName);
         _styleListItemPath.fontStyle = FontStyle.Normal;

         Color color = new Color(0, 0, 0, 0.15f);
         for (int h=0; h < _styleListItemNameEvenRow.normal.background.height; h++)
         {
            for (int w=0; w < _styleListItemNameEvenRow.normal.background.width; w++)
            {
               _styleListItemNameEvenRow.normal.background.SetPixel(w, h, color);
            }
         }
         _styleListItemNameEvenRow.normal.background.Apply();

         _styleWarningMessage = new GUIStyle(uScriptGUIStyle.referenceText);
//         _styleWarningMessage.normal.background = GUI.skin.box.normal.background;
//         _styleWarningMessage.border = GUI.skin.box.border;
         _styleWarningMessage.margin = new RectOffset(4, 4, 0, 0);
         _styleWarningMessage.padding = new RectOffset(0, 0, 2, 8);

         _styleAssetPingButton = new GUIStyle(GUI.skin.button);
         _styleAssetPingButton.alignment = TextAnchor.MiddleLeft;

         GetResourceFolderPaths(Application.dataPath, 0);
      }

      if (_position != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(_position.width + _padding.left + _padding.right, _position.height + _padding.top + _padding.bottom);
         base.maxSize = base.minSize;
      }




//      EditorGUIUtility.LookLikeControls(_labelWidth, _valueWidth);

      EditorGUILayout.BeginVertical(_styleWindow);
      {
         EditorGUI.indentLevel = 1;

         // List label
         EditorGUILayout.BeginHorizontal();
         {
            // Display the name from the AssetType Enum which could differ from the actual type name
            string typeName = System.Enum.GetName(typeof(AssetType), (int)assetType);
            GUILayout.Label("Select a " + typeName + ":", EditorStyles.boldLabel, GUILayout.ExpandWidth(true));

            if (GUILayout.Button(_contentHelpIcon, GUIStyle.none, GUILayout.ExpandWidth(false)))
            {
               Help.ShowHelpPage ("file:///unity/Components/class-" + _type.Name + ".html");
            }
         }
         EditorGUILayout.EndHorizontal();


//         _maxNameWidth = 240;
//         _maxPathWidth = 100;


         // List header
         uScriptGUI.HideScrollbars();
         Vector2 svColumns = EditorGUILayout.BeginScrollView(new Vector2(_scrollviewAssets.x, 0), false, false, uScriptGUIStyle.hColumnScrollbar, uScriptGUIStyle.vColumnScrollbar, _styleListHeader, GUILayout.Height(uScriptGUIStyle.columnHeaderHeight));
         {
            BeginColumns("Asset Name", "Resource Path", svColumns, _svRect);
            {
            }
            EndColumns();
         }
         EditorGUILayout.EndScrollView();
         uScriptGUI.ShowScrollbars();

         // List content
         // Set height of the asset scrollview
         float height = _styleListItemName.CalcSize(new GUIContent("X")).y * 10;
         _scrollviewAssets = EditorGUILayout.BeginScrollView(_scrollviewAssets, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, _styleListScrollView, GUILayout.Height(height));
         {
            foreach (KeyValuePair<string,AssetParts> kvp in _assetParts)
            {
               string selectedAssetPath = (string.IsNullOrEmpty(kvp.Value.Path) ? string.Empty : kvp.Value.Path + "/") + kvp.Value.Name;
               _evenRow = !_evenRow;
               if (GUILayout.Toggle(_selectedAssetPath == selectedAssetPath, new GUIContent(kvp.Value.Name, EditorGUIUtility.ObjectContent(null, _type).image), (_evenRow ? _styleListItemNameEvenRow : _styleListItemName), GUILayout.MinWidth(_maxNameWidth + _columnPadding + _maxPathWidth)))
               {
                  _selectedAssetPath = selectedAssetPath;
                  window.Repaint();
               }
               Rect r = GUILayoutUtility.GetLastRect();

               r.x += _maxNameWidth + _columnPadding;
               r.width = _maxPathWidth;

               GUI.Label(r, kvp.Value.Path, _styleListItemPath);
            }
         }
         EditorGUILayout.EndScrollView();

         if (Event.current.type == EventType.Repaint)
         {
            _svRect = GUILayoutUtility.GetLastRect();
         }


         // Get the list of assets associated with the current selection
         _assetSelection.Clear();
         if (string.IsNullOrEmpty(_selectedAssetPath) == false)
         {
            for (int i=0; i < _assetFullPath.Count; i++)
            {
               if (_assetFullPath[i].Contains("/Resources/" + _selectedAssetPath))
               {
                  _assetSelection.Add(_assetFullPath[i].Substring(Application.dataPath.Length + 1));
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
                  GUILayout.Label(_contentWarningIcon, GUIStyle.none);
                  GUILayout.Label(_contentWarningMessage, _styleWarningMessage);
               }
               EditorGUILayout.EndHorizontal();
            }

            for (int i=0; i < _assetSelection.Count; i++)
            {
               if (GUILayout.Button(_assetSelection[i], _styleAssetPingButton))
               {
                  Object obj = Resources.LoadAssetAtPath("Assets/" + _assetSelection[i], _type);
                  if (obj != null)
                  {
                     int instanceID = obj.GetInstanceID();
                     EditorGUIUtility.PingObject(instanceID);
                  }
               }
            }
         }


         EditorGUILayout.Separator();
         EditorGUILayout.Space();
         EditorGUILayout.Separator();


         //save or cancel
         EditorGUILayout.BeginHorizontal();
         {
            if (GUILayout.Button("Cancel", _styleCloseButton, GUILayout.ExpandWidth(true)))
            {
               this.Close();
            }

            GUILayout.FlexibleSpace();

            uScriptGUI.enabled = !string.IsNullOrEmpty(_selectedAssetPath);

            if (GUILayout.Button("Select", _styleCloseButton, GUILayout.ExpandWidth(true)))
            {
               _saveOnClose = true;
               this.Close();
            }

            uScriptGUI.enabled = true;
         }
         EditorGUILayout.EndHorizontal();

         EditorGUI.indentLevel = 0;
      }
      EditorGUILayout.EndVertical();

      if (Event.current.type == EventType.Repaint)
      {
         _position = GUILayoutUtility.GetLastRect();
      }
   }




   public static void GetResourceFolderPaths(string sourceDir, int recursionDepth)
   {
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
            foreach(string fileName in fileEntries)
            {
               modified = fileName;

               // get the extension
               i = modified.LastIndexOf('.');
               ext = (i < 0 || i+1 >= modified.Length ? string.Empty : modified.Substring(i + 1)).ToLower();

               // filter by asset type extensions
               if (_assetExtensions.Contains(ext))
               {
                  _assetFullPath.Add(modified);

                  // remove the extension
                  if (i != -1)
                  {
                     modified = modified.Substring(0, i);
                  }

                  modified = modified.Substring(modified.IndexOf("/Resources/")+11);

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
                     _assetParts[assetKey] = new AssetParts(name, path);
                     _maxNameWidth = Mathf.Max(_maxNameWidth, _assetParts[assetKey].NameWidth);
                     _maxPathWidth = Mathf.Max(_maxPathWidth, _assetParts[assetKey].PathWidth);
                  }
               }
            }
         }

         // Recurse into subdirectories of this directory.
         string [] subdirEntries = Directory.GetDirectories(sourceDir);
         foreach(string subdir in subdirEntries)
         {
            // Do not iterate through reparse points
            if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
               GetResourceFolderPaths(subdir,recursionDepth+1);
            }
         }

//         // Sort the results
//         if (recursionDepth == 0)
//         {
//         }
      }
   }




   struct Column
   {
      public string Label;
      public int Width;

      public Column(string label, int width)
      {
         this.Label = label;
         this.Width = width;
      }
   }

   static Column _columnName;
   static Column _columnPath;

   static Vector2 columnOffset;
   static Rect svRect;


   public static void BeginColumns(string name, string path, Vector2 offset, Rect rect)
   {
      _columnName = new Column(name, (int)_maxNameWidth + _columnPadding);
      _columnPath = new Column(path, 0);

//      _propertyCount = 0;

      columnOffset = offset;
      svRect = rect;

      GUILayout.Label(string.Empty, GUIStyle.none, GUILayout.Height(uScriptGUIStyle.columnHeaderHeight), GUILayout.Width(_maxNameWidth + _columnPadding + _maxPathWidth));
   }


   public static void EndColumns()
   {
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

      // First column - Asset Name
      Rect r = new Rect(0, columnOffset.y, _columnName.Width + 4, uScriptGUIStyle.columnHeaderHeight);
//      GUI.Label(r, _columnName.Label, uScriptGUIStyle.columnHeader);
      if (GUI.Button(r, _columnName.Label, uScriptGUIStyle.columnHeader))
      {
         Debug.Log("SORT BY NAME\n");
      }

      // Last column - Resource Path
      // This right-most column should appear to have an expanded width
      r.x += _columnName.Width + 4;
      r.width = svRect.width;
//      GUI.Label(r, _columnPath.Label, uScriptGUIStyle.columnHeader);
      if (GUI.Button(r, _columnPath.Label, uScriptGUIStyle.columnHeader))
      {
         Debug.Log("SORT BY PATH\n");
      }
   }

}
