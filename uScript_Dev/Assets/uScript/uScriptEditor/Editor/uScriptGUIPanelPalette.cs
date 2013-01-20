using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.Drawing;
using Detox.FlowChart;
using Detox.ScriptEditor;
using Detox.Windows.Forms;

//using Detox.Data.Tools;
using System.Linq;

public sealed class uScriptGUIPanelPalette : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelPalette _instance = new uScriptGUIPanelPalette();

   public static uScriptGUIPanelPalette Instance { get { return _instance; } }

   private uScriptGUIPanelPalette()
   {
      Init();
   }


   //
   // Members specific to this panel class
   //

   // Toolbar
   public string _panelFilterText = string.Empty;
   bool _paletteFoldoutToggle = false;
   int filterMatches;

   // Scrollview
   static Rect _scrollviewRect = new Rect();
   static bool _isMouseOverScrollview = false;

   // Scrollview contents
   const int ROW_HEIGHT = 17;
   const int BUTTON_INDENT = 12;
   const int BUTTON_PADDING = 4;
   GUIStyle _stylePadding;
   private Rect buttonRect;
   int listItem_rowCount;
   int listItem_rowWidth;
   private static Dictionary<string, bool> _paletteMenuItemFoldout = new Dictionary<string, bool>();
   private List<PaletteMenuItem> _paletteMenuItems;
   private List<PaletteMenuItem> _favoriteMenuItems;
   public string[] favoritePopupOptions;

   public static int paletteMenuItemCount { get; private set; }

   public class PaletteMenuItem : Detox.Windows.Forms.MenuItem
   {
      public String Name;
      public String Tooltip;
      public string Path;
      public List<PaletteMenuItem> Items;
      public System.EventHandler Click;
      public bool Hidden;
      public int Indent;
      public int x;
      public int width;

      public void OnClick()
      {
         if (Click != null)
         {
            Click(this, new EventArgs());
         }
      }
   }

   // Reference panel hot tips
   public EntityNode _hotSelection = null;
   private EntityNode _tempHotSelection = null;

   // Debugging variables used with the "LocalTestDebug" script
//   LocalTestDebug _debugScript;
//   float _debug_TopCount;
//   float _debug_TopHeight;
//   float _debug_MiddleCount;
//   float _debug_MiddleHeight;
//   float _debug_BottomCount;
//   float _debug_BottomHeight;


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Toolbox";
//      _size = 250;
//      _region = uScriptGUI.Region.Palette;

//      Update();
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
      BuildPaletteMenu();
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;

      // Initialize the style used for scrollview "padding"
      if (_stylePadding == null)
      {
         _stylePadding = new GUIStyle(GUIStyle.none);
         _stylePadding.stretchWidth = true;
//         padding.normal.background = GUI.skin.box.normal.background;
//         padding.border = GUI.skin.box.border;
      }
  
      



//      // Grab the deubgging script
//      if (_debugScript == null)
//      {
//         _debugScript = GameObject.Find("_uScript").GetComponent(typeof(LocalTestDebug)) as LocalTestDebug;
//      }
//      _debugScript.Top = Vector2.zero;
//      _debugScript.Middle = Vector2.zero;
//      _debugScript.Bottom = Vector2.zero;
//      _debugScript.svRect = _scrollviewRect;
//
//      // Update debug data
//      _debug_TopCount = 0;
//      _debug_MiddleCount = 0;
//      _debug_BottomCount = 0;


      uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.panelLeftWidth));
      {
         uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
         {
            // Toolbar
            //
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
            {
               // Unlike standard panels, this panel shares the same area as the
               // Graph Contents panel.  For now, use a DropDown control instead
               // of the typical Label for the panel title.
               //
               string[] options = new string[] { "Toolbox", "Contents" };
               Vector2 size = uScriptGUIStyle.panelTitleDropDown.CalcSize(new GUIContent(options[1]));
               uScript._paletteMode = EditorGUILayout.Popup(uScript._paletteMode, options, uScriptGUIStyle.panelTitleDropDown, GUILayout.Width(size.x));
               //            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

//               if (uScript.IsDevelopmentBuild)
//               {
//                  GUILayout.Label("(" + paletteMenuItemCount.ToString() + " items)", uScriptGUIStyle.toolbarLabel);
//               }

               GUILayout.FlexibleSpace();

               // Toggle hierarchy foldouts
               GUIContent toggleContent = (_paletteFoldoutToggle ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand);
               bool toggle = GUILayout.Toggle(_paletteFoldoutToggle, toggleContent, uScriptGUIStyle.paletteToolbarFoldoutButton, GUILayout.ExpandWidth(false));
               if (_paletteFoldoutToggle != toggle)
               {
                  _paletteFoldoutToggle = toggle;
                  ExpandPaletteMenuItemFoldouts(_paletteFoldoutToggle);
               }

               GUI.SetNextControlName("PaletteFilterSearch");
               string _filterText = uScriptGUI.ToolbarSearchField(_panelFilterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
               //            GUI.SetNextControlName("");
               if (_filterText != _panelFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (_filterText.Contains("\n"))
                  {
                     GUIUtility.keyboardControl = 0;
                  }
   
                  // Trim leading whitespace
                  _filterText = _filterText.TrimStart();
   
                  _panelFilterText = _filterText;
                  FilterToolboxMenuItems();

                  if (uScript.Preferences.AutoExpandToolbox)
                  {
                     _paletteFoldoutToggle = _panelFilterText != string.Empty;
                     ExpandPaletteMenuItemFoldouts(_paletteFoldoutToggle);
                  }
               }
            }
            EditorGUILayout.EndHorizontal();

            if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
            {
               DrawHiddenNotification();
            }
            else
            {
               // Draw the contents
               //
   
   
               // Node list
               //
               _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
               {
                  //               // Debug
                  //               if (debugScript.svOffset != _scrollviewOffset)
                  //               {
                  //                  Debug.Log("Offset delta: " + (_scrollviewOffset.y - debugScript.svOffset.y).ToString() + ", Event: " + Event.current.type.ToString() + "\n");
                  //               }
                  //               _debugScript.svOffset = _scrollviewOffset;
   
   
                  // Commonly used variables
                  listItem_rowCount = 0;
                  listItem_rowWidth = 0;
   
                  // Apply the filter and determine how many items will be drawn.
                  //
                  if (_paletteMenuItems == null)
                  {
                     GUILayout.Label("\n\tERROR:\n\n\t\tFailed to initialize the node palette!", EditorStyles.boldLabel);
                  }
                  else
                  {
                     foreach (PaletteMenuItem item in _paletteMenuItems)
                     {
                        DetermineListStats(item);
                     }
      
                     // Draw the padding box to establish the row width (excluding scrollbar)
                     // and force the scrollview content height
                     //
                     GUILayout.Box(string.Empty, _stylePadding, GUILayout.Height(Math.Max(0, ROW_HEIGHT * listItem_rowCount - 10)), GUILayout.Width(listItem_rowWidth));
                     GUILayout.Box(string.Empty, _stylePadding, GUILayout.Height(10), GUILayout.ExpandWidth(true));
      
                     // Prepare to draw each row of the filtered list
                     //
                     // From this point on, the contents of the scrollview should
                     // never use GUILayout, so we can safely skip EventType.Layout.
                     //
                     if (Event.current.type != EventType.Layout)
                     {
                        // Make sure the we get the width of the last GUILayout.Box
                        // just in case it is wider than the widest button below
                        listItem_rowWidth = Math.Max(listItem_rowWidth, (int)GUILayoutUtility.GetLastRect().width);
      
                        // Reset some variables we'll use later
                        buttonRect = new Rect(0, 0, 0, ROW_HEIGHT);
                        filterMatches = 0;
      
                        // Reset the temporary hot selection at the beginning of each pass
                        if (Event.current.modifiers != EventModifiers.Alt)
                        {
                           _tempHotSelection = null;
                        }
      
                        // Draw all the palette items
                        foreach (PaletteMenuItem item in _paletteMenuItems)
                        {
                           if (DrawPaletteMenu(item))
                           {
                              filterMatches++;
                           }
                        }
      
                        // Check here for possible repaint needed for hot tips
                        if (_hotSelection != _tempHotSelection)
                        {
                           _hotSelection = _tempHotSelection;
                           uScript.RequestRepaint();
                        }
      
                     }
      
                     // Display a message if no filter matches were found.
                     //
                     // The filterMatches variable is reset to zero right before the menu items are
                     // drawn when Event.current.type != EventType.Layout
                     //
                     if (filterMatches == 0)
                     {
                        GUILayout.Label("The search found no matches!", uScriptGUIStyle.panelMessageBold);
                     }
                  }
   
                  //               // Debug
                  //               _debugScript.Top = new Vector2(_debug_TopCount, _debug_TopHeight);
                  //               _debugScript.Middle = new Vector2(_debug_MiddleCount, _debug_MiddleHeight);
                  //               _debugScript.Bottom = new Vector2(_debug_BottomCount, _debug_BottomHeight);
               }
               EditorGUILayout.EndScrollView();
   
               if (Event.current.type == EventType.Repaint)
               {
                  _scrollviewRect = GUILayoutUtility.GetLastRect();
               }
   
               _isMouseOverScrollview = _scrollviewRect.Contains(Event.current.mousePosition);
            }
         }
         EditorGUILayout.EndVertical();

         DrawFavoritesPanel();
      }
      EditorGUILayout.EndVertical();
      
      if ((int)uScript.Instance.paletteRect.width != 0 && (int)uScript.Instance.paletteRect.width != uScriptGUI.panelLeftWidth)
      {
         // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
         uScriptGUI.panelLeftWidth = (int)uScript.Instance.paletteRect.width;
      }

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Palette);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Palette);
   }


   private void DrawFavoritesPanel()
   {
      int favoriteNodeCount = 0;
      foreach (PaletteMenuItem item in _favoriteMenuItems)
      {
         if (item != null)
         {
            favoriteNodeCount++;
         }
      }

      if (favoriteNodeCount > 0)
      {
         GUILayout.Space(uScriptGUI.panelDividerThickness);

         bool isPanelExpanded = uScript.Preferences.ExpandFavoritePanel;

         EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
         {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
            {
               GUILayout.Label("Favorites", uScriptGUIStyle.panelTitle);

//               if (favoritesPanelExpanded == false)
//               {
//                  int buttonWidth = (int)uScriptGUIStyle.favoriteButtonMiddle.CalcSize(new GUIContent("0")).x;
//                  for (int i = 0; i < _favoriteMenuItems.Count; i++)
//                  {
//                     GUIStyle buttonStyle = (i == 0
//                                             ? uScriptGUIStyle.favoriteButtonLeft
//                                             : (i == _favoriteMenuItems.Count - 1
//                                                ? uScriptGUIStyle.favoriteButtonRight
//                                                : uScriptGUIStyle.favoriteButtonMiddle));
//
//                     if (_favoriteMenuItems[i] == null)
//                     {
//                        GUI.color = new UnityEngine.Color(0.9f, 0.9f, 0.9f, 1);
//                        GUILayout.Label("-", buttonStyle, GUILayout.Width(buttonWidth));
//                        GUI.color = UnityEngine.Color.white;
//                     }
//                     else if (GUILayout.Button((i + 1).ToString(), buttonStyle, GUILayout.Width(buttonWidth)))
//                     {
//                        CreateNode((EntityNode)_favoriteMenuItems[i].Tag);
//                     }
//                  }
//               }

               GUIContent toggleContent = (isPanelExpanded ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand);
               bool toggle = GUILayout.Toggle(isPanelExpanded, toggleContent, uScriptGUIStyle.favoriteButtonFoldout, GUILayout.ExpandWidth(false));
               if (isPanelExpanded != toggle)
               {
                  isPanelExpanded = toggle;
                  uScript.Preferences.ExpandFavoritePanel = isPanelExpanded;
                  uScript.Preferences.Save();
               }
            }
            EditorGUILayout.EndHorizontal();

            if (isPanelExpanded)
            {
               // We're using 9 for (buttonMargin * 2 + buttonVerticalOverflow)
               Rect areaRect = EditorGUILayout.BeginVertical(GUILayout.Height(favoriteNodeCount * ROW_HEIGHT + 9));
               {
                  GUILayout.FlexibleSpace();

                  if (Event.current.type != EventType.Layout)
                  {
                     // We're using 5 for (buttonMargin + buttonVerticalOverflow)
                     Rect rowRect = new Rect(areaRect.x, areaRect.y + 5, 0, ROW_HEIGHT);

                     int popupWidth = (int)uScriptGUIStyle.favoriteButtonNumber.CalcSize(new GUIContent("0")).x;

                     for (int i = 0; i < _favoriteMenuItems.Count; i++)
                     {
                        PaletteMenuItem menuItem = _favoriteMenuItems[i];

                        if (menuItem != null)  // && menuItem.Tag != null)
                        {
                           // Favorite number
                           rowRect.x = uScriptGUIStyle.favoriteButtonNumber.margin.left;
                           rowRect.width = popupWidth;

                           int favoriteIndex = i + 1;

                           int newIndex = EditorGUI.Popup(rowRect, favoriteIndex, favoritePopupOptions, uScriptGUIStyle.favoriteButtonNumber);
                           if (newIndex != favoriteIndex)
                           {
                              if (newIndex == 0)
                              {
                                 uScript.Preferences.UpdateFavoriteNode(favoriteIndex, string.Empty);
                              }
                              else
                              {
                                 uScript.Preferences.SwapFavoriteNodes(favoriteIndex, newIndex);
                              }

                              uScriptGUIPanelPalette.Instance.BuildFavoritesMenu();
                           }

                           // Favorite name
                           string nodeName = menuItem.Name;

                           rowRect.x += rowRect.width;
                           rowRect.width = (areaRect.width - rowRect.x - uScriptGUIStyle.favoriteButtonName.margin.right);

                           if (menuItem.Tag == null)
                           {
                              GUI.color = new UnityEngine.Color(1, 0.5f, 0.5f, 1);
                           }
   
                           if (GUI.Button(rowRect, nodeName, uScriptGUIStyle.favoriteButtonName))
                           {
                              CreateNode((EntityNode)menuItem.Tag);
                           }
   
                           GUI.color = UnityEngine.Color.white;
   
                           rowRect.y += ROW_HEIGHT;
                        }
                     }
                  }
               }
               EditorGUILayout.EndVertical();
            }
         }
         EditorGUILayout.EndVertical();
      }
   }


   private void CreateNode(EntityNode node)
   {
      if (node == null)
      {
         uScriptDebug.Log("The node associated with this Favorite shortcut was not found in the Toolbox.\n\t"
            + "It may have pointed to a reflected object that no longer exists in the scene.", uScriptDebug.Type.Warning);
      }
      else
      {
         string nodeSignature = uScript.GetNodeSignature((EntityNode)node);
         uScript.Instance.PlaceNodeOnCanvas(nodeSignature, false);
      }
   }

   private bool DetermineListStats(PaletteMenuItem item)
   {
      if (item.Hidden)
      {
         return false;
      }

      if (item.Items == null)
      {
         // This is a simple menu item
         if (item.width == 0)
         {
            item.width = (int)uScriptGUIStyle.paletteButton.CalcSize(new GUIContent(item.Name)).x;
         }
      }
      else
      {
         // This is should be a folding menu item that contains more buttons
         if (item.width == 0)
         {
            item.width = (int)uScriptGUIStyle.paletteFoldout.CalcSize(new GUIContent(item.Name)).x;
         }

         if (_paletteMenuItemFoldout[item.Path])
         {
            foreach (PaletteMenuItem subitem in item.Items)
            {
               DetermineListStats(subitem);
            }
         }
      }

      item.x = BUTTON_PADDING + (item.Indent * BUTTON_INDENT);

      listItem_rowWidth = Math.Max(listItem_rowWidth, item.x + item.width + BUTTON_PADDING);
      listItem_rowCount++;

      return true;
   }

   private bool DrawPaletteMenu(PaletteMenuItem item)
   {
      //
      // This method should never be called when Event.current.type == EventType.Layout
      //

      if (item.Hidden)
      {
         return false;
      }

      // Update button rect before drawing the control
      buttonRect.x = item.x;
      buttonRect.width = listItem_rowWidth - item.x - BUTTON_PADDING;

      // Determine if the item should be drawn
      if (_scrollviewOffset.y <= buttonRect.yMax)
      {
         // draw
         if (_scrollviewOffset.y + _scrollviewRect.height > buttonRect.yMin)
         {
//            _debug_MiddleCount++;
//            _debug_MiddleHeight = buttonRect.yMax - _debug_TopHeight;

            // Draw the foldout or menu item button
            if (item.Items == null)
            {
               // This is a simple menu item
               if (GUI.Button(buttonRect, new GUIContent(item.Name, item.Tooltip), uScriptGUIStyle.paletteButton))
               {
                  if (item.Click != null)
                  {
                     // Create the node on the canvas
                     int halfWidth = (int)(uScript.Instance.NodeWindowRect.width * 0.5f);
                     int halfHeight = (int)(uScript.Instance.NodeWindowRect.height * 0.5f);
                     Point center = new Point(halfWidth, halfHeight);
                     uScript.Instance.ScriptEditorCtrl.ContextCursor = center;
                     item.OnClick();
                     uScriptDebug.Log("Clicked '" + item.Name + "'\n", uScriptDebug.Type.Debug);
                  }
                  else
                  {
                     uScriptDebug.Log("Cannot execute menu item: " + item.Name + "\n", uScriptDebug.Type.Debug);
                  }
               }
            }
            else
            {
               // This is a folding menu item that contains more buttons
               _paletteMenuItemFoldout[item.Path] = GUI.Toggle(buttonRect, _paletteMenuItemFoldout[item.Path], item.Name, uScriptGUIStyle.paletteFoldout);
            }
         }
         else
         {
            // skip the items below the viewable area
//            _debug_BottomCount++;
//            _debug_BottomHeight = buttonRect.yMax - _debug_TopHeight - _debug_MiddleHeight;
         }
      }
      else
      {
         // skip the items above the viewable area
//         _debug_TopCount++;
//         _debug_TopHeight = buttonRect.yMax;
      }

      //
      // Always perform the non-drawing functions
      //

      // Handle mouse hovering
      if (_isMouseOverScrollview && buttonRect.Contains(Event.current.mousePosition))
      {
         _tempHotSelection = item.Tag as EntityNode;
      }

      // Prepare for the next control
      buttonRect.y += ROW_HEIGHT;

      // If the item is an expanded foldout, draw its contents
      if (item.Items != null && _paletteMenuItemFoldout[item.Path])
      {
         foreach (PaletteMenuItem subitem in item.Items)
         {
            DrawPaletteMenu(subitem);
         }
      }

      return true;
   }


   //
   // Use recursion to set all menu item foldouts in the node palette
   //
   private void ExpandPaletteMenuItemFoldouts(bool state)
   {
      string[] keys = _paletteMenuItemFoldout.Keys.ToArray();
      foreach (string key in keys)
      {
         _paletteMenuItemFoldout[key] = state;
      }
   }

   private void FilterToolboxMenuItems()
   {
      foreach (PaletteMenuItem item in _paletteMenuItems)
      {
         item.Hidden = FilterToolboxMenuItem(item, false);
      }
   }

   /// <summary>Filters the toolbox menu item, hiding it if any words in the search query were not found in the item's Name.</summary>
   /// <returns>True if the parent or item should be hidden, otherwise False</returns>
   /// <param name='paletteMenuItem'>The Toolbox menu item to examine.</param>
   /// <param name='shouldForceVisible'>When True, the menu item will always be visible.</param>
   private bool FilterToolboxMenuItem(PaletteMenuItem paletteMenuItem, bool shouldForceVisible)
   {
      bool matchFound = true;
      string[] words = _panelFilterText.ToLower().Split();

      // The user can now enter keywords in any order to find matches
      foreach (string word in words)
      {
         if (paletteMenuItem.Name.ToLower().Contains(word) == false)
         {
            matchFound = false;
            break;
         }
      }

      if (shouldForceVisible || matchFound)
      {
         // This and all children should be visible
         if (paletteMenuItem.Items != null)
         {
            foreach (PaletteMenuItem item in paletteMenuItem.Items)
            {
               item.Hidden = FilterToolboxMenuItem(item, true);
            }
         }
         return false;
      }
      else if (paletteMenuItem.Items != null)
      {
         // Check each child to see if this should be visible
         bool shouldHideParent = true;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            item.Hidden = FilterToolboxMenuItem(item, false);
            if (item.Hidden == false)
            {
               shouldHideParent = false;
            }
         }

         return shouldHideParent;
      }

      // has no children and wasn't a match
      return true;
   }

   public PaletteMenuItem GetToolboxMenuItem(string nodeSignature)
   {
      if (_paletteMenuItems == null)
      {
         return null;
      }

      PaletteMenuItem menuItem = null;

      foreach (PaletteMenuItem item in _paletteMenuItems)
      {
         menuItem = GetToolboxMenuItem(nodeSignature, item);
         if (menuItem != null)
         {
            return menuItem;
         }
      }

      return null;
   }

   private PaletteMenuItem GetToolboxMenuItem(string nodeSignature, PaletteMenuItem currentMenuItem)
   {
      if (currentMenuItem == null)
      {
         return null;
      }

      if (currentMenuItem.Items != null && currentMenuItem.Items.Count > 0)
      {
         PaletteMenuItem menuItem = null;

         foreach (PaletteMenuItem item in currentMenuItem.Items)
         {
            menuItem = GetToolboxMenuItem(nodeSignature, item);
            if (menuItem != null)
            {
               return menuItem;
            }
         }
      }
      else if (currentMenuItem.Tag != null
         && uScript.GetNodeSignature((EntityNode)currentMenuItem.Tag) == nodeSignature)
      {
         return currentMenuItem;
      }

      return null;
   }

   public EntityNode GetToolboxNode(string nodeSignature)
   {
      PaletteMenuItem menuItem = GetToolboxMenuItem(nodeSignature);
      if (menuItem != null)
      {
         return ((EntityNode)menuItem.Tag).Copy(false);
      }

      return null;
   }


   public void BuildPaletteMenu()
   {
      BuildPaletteMenu(null, null, string.Empty);

      BuildFavoritesMenu();
   }

   private void BuildPaletteMenu(ToolStripItem contextMenuItem, PaletteMenuItem paletteMenuItem, string paletteMenuItemParent)
   {
      if (contextMenuItem == null || paletteMenuItem == null)
      {
         //
         // Create a new palette menu, destroying the old one
         //
         _paletteMenuItems = new List<PaletteMenuItem>();

         List<Detox.Windows.Forms.ToolStripItem> items = uScript.Instance.ScriptEditorCtrl.ContextMenu.Items.Items;
         foreach (ToolStripItem item in items)
         {
            if ((item is ToolStripMenuItem) && (item.Text == "Add..."))
            {
               foreach (ToolStripItem subitem in ((ToolStripMenuItem)item).DropDownItems.Items)
               {
                  PaletteMenuItem paletteItem = new PaletteMenuItem();
                  paletteItem.Indent = 0;

                  BuildPaletteMenu(subitem, paletteItem, string.Empty);

                  _paletteMenuItems.Add(paletteItem);
               }
            }
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            // This is a foldout
            paletteMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            paletteMenuItem.Path = (string.IsNullOrEmpty(paletteMenuItemParent) ? string.Empty : paletteMenuItemParent + "/") + paletteMenuItem.Name;
            paletteMenuItem.Items = new List<PaletteMenuItem>();

            if (_paletteMenuItemFoldout.ContainsKey(paletteMenuItem.Path) == false)
            {
               _paletteMenuItemFoldout.Add(paletteMenuItem.Path, false);
            }

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               PaletteMenuItem newItem = new PaletteMenuItem();
               newItem.Indent = paletteMenuItem.Indent + 1;
               if (item == null || newItem == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildPaletteMenu()!\n", uScriptDebug.Type.Error);
                  return;
               }
               BuildPaletteMenu(item, newItem, paletteMenuItem.Path);
               paletteMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            // This is a menu item
            paletteMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            paletteMenuItem.Path = (string.IsNullOrEmpty(paletteMenuItemParent) ? string.Empty : paletteMenuItemParent + "/") + paletteMenuItem.Name;
            paletteMenuItem.Tooltip = uScript.FindNodeToolTip(ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode));
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag = contextMenuItem.Tag;

            paletteMenuItemCount++;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

   public void BuildFavoritesMenu()
   {
      if (_favoriteMenuItems == null)
      {
         favoritePopupOptions = new string[10];

         _favoriteMenuItems = new List<PaletteMenuItem>(9);
         for (int i = 0; i < 9; i++)
         {
            _favoriteMenuItems.Add(null);
         }
      }

      favoritePopupOptions[0] = "-";

      for (int i = 0; i < 9; i++)
      {
         string nodeSignature = uScript.Preferences.GetFavoriteNode(i + 1);

         PaletteMenuItem item = GetToolboxMenuItem(nodeSignature);
         favoritePopupOptions[i + 1] = (i + 1).ToString() + "    " + (item != null ? item.Name : "-");

         if (string.IsNullOrEmpty(nodeSignature))
         {
            _favoriteMenuItems[i] = null;
         }
         else
         {
            if (_favoriteMenuItems[i] == null
               || uScript.GetNodeSignature((EntityNode)_favoriteMenuItems[i].Tag) != nodeSignature)
            {
               _favoriteMenuItems[i] = GetToolboxMenuItem(nodeSignature);

               // TODO: Don't use the actual palette menu item, duplicate it instead
               //       Then update the name for EntityMethod, EntityProperty, and perhaps other nodes

               if (_favoriteMenuItems[i] == null)
               {
                  // If the menu item is still null, the nodeSignature was not found.
                  // Create a dummy favorite menu item to inform the user.
                  _favoriteMenuItems[i] = new PaletteMenuItem();
                  _favoriteMenuItems[i].Name = nodeSignature;
               }
            }
         }
      }
   }
}
