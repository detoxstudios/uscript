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
   private uScriptGUIPanelPalette() { Init(); }


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
      if ( _stylePadding == null )
      {
         _stylePadding = new GUIStyle( GUIStyle.none );
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


      uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelLeftWidth));
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

            GUILayout.FlexibleSpace();

            // Toggle hierarchy foldouts
            bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle,
                                                   (_paletteFoldoutToggle ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand),
                                                   uScriptGUIStyle.paletteToolbarButton,
                                                   GUILayout.ExpandWidth(false));
            if (_paletteFoldoutToggle != newToggleState)
            {
               _paletteFoldoutToggle = newToggleState;
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

               _paletteFoldoutToggle = _panelFilterText != string.Empty;
               ExpandPaletteMenuItemFoldouts(_paletteFoldoutToggle);
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

      if ((int)uScript.Instance.paletteRect.width != 0 && (int)uScript.Instance.paletteRect.width != uScriptGUI.panelLeftWidth)
      {
         // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
         uScriptGUI.panelLeftWidth = (int)uScript.Instance.paletteRect.width;
      }

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Palette);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Palette);
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
               // This is should be a folding menu item that contains more buttons
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
      if ( _isMouseOverScrollview && buttonRect.Contains(Event.current.mousePosition) )
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


   public void BuildPaletteMenu()
   {
      BuildPaletteMenu(null, null, string.Empty);
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
            paletteMenuItem.Tooltip = uScript.FindNodeToolTip(ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode));
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag = contextMenuItem.Tag;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

}
