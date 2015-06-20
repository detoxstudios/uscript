// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelPalette.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelPalette type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using Detox.Drawing;
using Detox.Editor;
using Detox.ScriptEditor;
using Detox.Windows.Forms;

using UnityEditor;

using UnityEngine;

public sealed class uScriptGUIPanelPalette : uScriptGUIPanel
{
   private const int ButtonIndent = 12;
   private const int ButtonPadding = 4;
   private const int RowHeight = 17;

   private static readonly Dictionary<string, bool> PaletteMenuItemFoldout = new Dictionary<string, bool>();

   private static bool isMouseOverScrollview;
   private static Rect scrollviewRect;

   private int filterMatches;
   private bool paletteFoldoutToggle;
   private string panelFilterText = string.Empty;

   private GUIStyle stylePadding;
   private Rect buttonRect;
   private int listItemRowCount;
   private int listItemRowWidth;
   private List<PaletteMenuItem> paletteMenuItems;
   private List<PaletteMenuItem> favoriteMenuItems;

   private EntityNode tempHotSelection;

   static uScriptGUIPanelPalette()
   {
      Instance = new uScriptGUIPanelPalette();
   }

   private uScriptGUIPanelPalette()
   {
      this.Init();
   }

   public static int PaletteMenuItemCount { get; private set; }

   public static uScriptGUIPanelPalette Instance { get; private set; }

   public string[] FavoritePopupOptions { get; private set; }

   public EntityNode HotSelection { get; private set; }

   // Methods common to the panel classes
   public void Init()
   {
      this._name = "Toolbox";
   }

   public void Update()
   {
      // Called whenever member data should be updated
      this.BuildPaletteMenu();
   }

   public void ClearSearchFilter()
   {
      this.panelFilterText = string.Empty;
   }

   public override void Draw()
   {
      // Called during OnGUI()

      // Local references to uScript
      var uScriptInstance = uScript.Instance;

      // Initialize the style used for scrollview "padding"
      if (this.stylePadding == null)
      {
         this.stylePadding = new GUIStyle(GUIStyle.none) { stretchWidth = true };
      }
  
      uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.PanelLeftWidth));
      {
         uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
         {
            // Toolbar
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
            {
               // Unlike standard panels, this panel shares the same area as the
               // Graph Contents panel.  For now, use a DropDown control instead
               // of the typical Label for the panel title.
               var options = new[] { "Toolbox", "Contents" };
               var size = uScriptGUIStyle.PanelTitleDropDown.CalcSize(new GUIContent(options[1]));
               uScript._paletteMode = EditorGUILayout.Popup(uScript._paletteMode, options, uScriptGUIStyle.PanelTitleDropDown, GUILayout.Width(size.x));

               ////if (uScript.IsDevelopmentBuild)
               ////{
               ////   GUILayout.Label("(" + paletteMenuItemCount.ToString() + " items)", uScriptGUIStyle.toolbarLabel);
               ////}

               GUILayout.FlexibleSpace();

               // Toggle hierarchy foldouts
               var toggleContent = this.paletteFoldoutToggle ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand;
               var toggle = GUILayout.Toggle(this.paletteFoldoutToggle, toggleContent, uScriptGUIStyle.PaletteToolbarFoldoutButton, GUILayout.ExpandWidth(false));
               if (this.paletteFoldoutToggle != toggle)
               {
                  this.paletteFoldoutToggle = toggle;
                  ExpandPaletteMenuItemFoldouts(this.paletteFoldoutToggle);
               }

               GUI.SetNextControlName("PaletteFilterSearch");
               var filterText = uScriptGUI.ToolbarSearchField(this.panelFilterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));

               if (filterText != this.panelFilterText)
               {
                  // Drop focus if the user inserted a newline (hit enter)
                  if (filterText.Contains("\n"))
                  {
                     GUIUtility.keyboardControl = 0;
                  }
   
                  // Trim leading whitespace
                  filterText = filterText.TrimStart();
   
                  this.FilterToolboxMenuItems(filterText, false);
               }
            }
            EditorGUILayout.EndHorizontal();

            if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
            {
               this.DrawHiddenNotification();
            }
            else
            {
               // Draw the contents
   
               // Node list
               this._scrollviewOffset = EditorGUILayout.BeginScrollView(this._scrollviewOffset, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview", GUILayout.ExpandWidth(true));
               {
                  this.listItemRowCount = 0;
                  this.listItemRowWidth = 0;
   
                  // Apply the filter and determine how many items will be drawn.
                  if (this.paletteMenuItems == null)
                  {
                     GUILayout.Label("\n\tERROR:\n\n\t\tFailed to initialize the node palette!", EditorStyles.boldLabel);
                  }
                  else
                  {
                     foreach (var item in this.paletteMenuItems)
                     {
                        this.DetermineListStats(item);
                     }
      
                     // Draw the padding box to establish the row width (excluding scrollbar)
                     // and force the scrollview content height
                     GUILayout.Box(string.Empty, this.stylePadding, GUILayout.Height(Math.Max(0, (RowHeight * this.listItemRowCount) - 10)), GUILayout.Width(this.listItemRowWidth));
                     GUILayout.Box(string.Empty, this.stylePadding, GUILayout.Height(10), GUILayout.ExpandWidth(true));
      
                     // Prepare to draw each row of the filtered list
                     // From this point on, the contents of the scrollview should
                     // never use GUILayout, so we can safely skip EventType.Layout.
                     if (Event.current.type != EventType.Layout)
                     {
                        // Make sure the we get the width of the last GUILayout.Box
                        // just in case it is wider than the widest button below
                        this.listItemRowWidth = Math.Max(this.listItemRowWidth, (int)GUILayoutUtility.GetLastRect().width);
      
                        // Reset some variables we'll use later
                        this.buttonRect = new Rect(0, 0, 0, RowHeight);
                        this.filterMatches = 0;
      
                        // Reset the temporary hot selection at the beginning of each pass
                        if (Event.current.modifiers != EventModifiers.Alt)
                        {
                           this.tempHotSelection = null;
                        }
      
                        // Draw all the palette items
                        foreach (var item in this.paletteMenuItems)
                        {
                           if (this.DrawPaletteMenu(item))
                           {
                              this.filterMatches++;
                           }
                        }
      
                        // Check here for possible repaint needed for hot tips
                        if (this.HotSelection != this.tempHotSelection)
                        {
                           this.HotSelection = this.tempHotSelection;
                           uScript.RequestRepaint();
                        }
                     }

                     // Display a message if no filter matches were found.
                     // The filterMatches variable is reset to zero right before the menu items are
                     // drawn when Event.current.type != EventType.Layout
                     if (this.filterMatches == 0)
                     {
                        GUILayout.Label("The search found no matches!", uScriptGUIStyle.PanelMessageBold);
                     }
                  }
               }
               EditorGUILayout.EndScrollView();
   
               if (Event.current.type == EventType.Repaint)
               {
                  scrollviewRect = GUILayoutUtility.GetLastRect();
               }
   
               isMouseOverScrollview = scrollviewRect.Contains(Event.current.mousePosition);
            }
         }
         EditorGUILayout.EndVertical();

#if DETOX_STORE_BASIC || UNITY_STORE_BASIC
       
#else
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label(uScriptInstance.ScriptEditorCtrl.ScriptEditor.EntityDescs.Length + " Reflected Types");

            var toggleState = GUILayout.Toggle(uScript.Preferences.AutoUpdateReflection, "Auto", EditorStyles.miniButtonLeft, GUILayout.ExpandWidth(false));
            if (uScript.Preferences.AutoUpdateReflection != toggleState)
            {
               uScript.Preferences.AutoUpdateReflection = toggleState;
               uScript.Preferences.Save();

               if (uScript.Preferences.AutoUpdateReflection)
               {
                  uScript.Instance.UpdateReflectedTypes();
               }
            }

            var originalState = GUI.enabled;
            GUI.enabled = originalState && !uScript.Preferences.AutoUpdateReflection;

            if (GUILayout.Button("Refresh", EditorStyles.miniButtonRight, GUILayout.ExpandWidth(false)))
            {
               uScript.Instance.UpdateReflectedTypes();
            }

            GUI.enabled = originalState;
         }
         EditorGUILayout.EndHorizontal();
#endif

         this.DrawFavoritesPanel();
      }
      EditorGUILayout.EndVertical();
      
      if ((int)uScript.Instance.paletteRect.width != 0 && (int)uScript.Instance.paletteRect.width != uScriptGUI.PanelLeftWidth)
      {
         // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
         uScriptGUI.PanelLeftWidth = (int)uScript.Instance.paletteRect.width;
      }

      ////uScriptGUI.DefineRegion(uScriptGUI.Region.Palette);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Palette);
   }

   public void FilterToolboxMenuItems(string filterText, bool forceExpandToolbox)
   {
      this.panelFilterText = filterText;

      foreach (var item in this.paletteMenuItems)
      {
         item.Hidden = this.FilterToolboxMenuItem(item, false);
      }

      if (uScript.Preferences.AutoExpandToolbox || forceExpandToolbox)
      {
         this.paletteFoldoutToggle = this.panelFilterText != string.Empty;
         ExpandPaletteMenuItemFoldouts(this.paletteFoldoutToggle);
      }
   }

   public PaletteMenuItem GetToolboxMenuItem(string nodeSignature)
   {
      if (this.paletteMenuItems == null)
      {
         return null;
      }

      foreach (var item in this.paletteMenuItems)
      {
         var menuItem = GetToolboxMenuItem(nodeSignature, item);
         if (menuItem != null)
         {
            return menuItem;
         }
      }

      return null;
   }

   public EntityNode GetToolboxNode(string nodeSignature)
   {
      var menuItem = GetToolboxMenuItem(nodeSignature);
      return menuItem != null ? ((EntityNode)menuItem.Tag).Copy(false) : null;
   }

   public void BuildPaletteMenu()
   {
      this.BuildPaletteMenu(null, null, string.Empty);
      this.BuildFavoritesMenu();
   }

   public void BuildFavoritesMenu()
   {
      const int MaxNumFavorites = 9;

      if (this.favoriteMenuItems == null)
      {
         this.favoriteMenuItems = new List<PaletteMenuItem>(MaxNumFavorites);
         for (var i = 0; i < MaxNumFavorites; i++)
         {
            this.favoriteMenuItems.Add(null);
         }

         this.FavoritePopupOptions = new string[MaxNumFavorites + 1];
         this.FavoritePopupOptions[0] = "-";
      }

      for (var i = 0; i < MaxNumFavorites; i++)
      {
         var nodeSignature = uScript.Preferences.GetFavoriteNode(i + 1);

         if (string.IsNullOrEmpty(nodeSignature))
         {
            this.favoriteMenuItems[i] = null;
         }
         else
         {
            if (this.favoriteMenuItems[i] == null
               || uScript.GetNodeSignature((EntityNode)this.favoriteMenuItems[i].Tag) != nodeSignature)
            {
               this.favoriteMenuItems[i] = GetToolboxMenuItem(nodeSignature);

               //// TODO: Don't use the actual palette menu item, duplicate it instead.
               ////       Then update the name for EntityMethod, EntityProperty, and perhaps other nodes

               if (this.favoriteMenuItems[i] == null)
               {
                  // If the menu item is still null, the nodeSignature was not found.
                  // Create a dummy favorite menu item to inform the user.
                  this.favoriteMenuItems[i] = new PaletteMenuItem { Name = "(\u2718) " + nodeSignature };
               }
            }
         }
      }

      for (var i = 0; i < MaxNumFavorites; i++)
      {
         this.FavoritePopupOptions[i + 1] = string.Format("{0}    {1}", i + 1, this.favoriteMenuItems[i] == null ? "-" : this.favoriteMenuItems[i].Name);
      }
   }

   private static void CreateNode(EntityNode node)
   {
      if (node == null)
      {
         uScriptDebug.Log(
            "The node associated with this Favorite shortcut was not found in the Toolbox.\n\t"
            + "It may have pointed to a reflected object that no longer exists in the scene.",
            uScriptDebug.Type.Warning);
      }
      else
      {
         var nodeSignature = uScript.GetNodeSignature(node);
         uScript.Instance.PlaceNodeOnCanvas(nodeSignature, false);
      }
   }

   // Use recursion to set all menu item foldouts in the node palette
   private static void ExpandPaletteMenuItemFoldouts(bool state)
   {
      var keys = PaletteMenuItemFoldout.Keys.ToArray();
      foreach (var key in keys)
      {
         PaletteMenuItemFoldout[key] = state;
      }
   }

   private static PaletteMenuItem GetToolboxMenuItem(string nodeSignature, PaletteMenuItem currentMenuItem)
   {
      if (currentMenuItem == null)
      {
         return null;
      }

      if (currentMenuItem.Items != null && currentMenuItem.Items.Count > 0)
      {
         foreach (var item in currentMenuItem.Items)
         {
            var menuItem = GetToolboxMenuItem(nodeSignature, item);
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

   private void BuildPaletteMenu(ToolStripItem contextMenuItem, PaletteMenuItem paletteMenuItem, string paletteMenuItemParent)
   {
      if (contextMenuItem == null || paletteMenuItem == null)
      {
         // Create a new palette menu, destroying the old one
         this.paletteMenuItems = new List<PaletteMenuItem>();

         var items = uScript.Instance.ScriptEditorCtrl.ContextMenuWithReflection.Items;
         foreach (var item in items)
         {
            if ((item is ToolStripMenuItem) && (item.Text == "Add..."))
            {
               foreach (var subitem in ((ToolStripMenuItem)item).DropDownItems)
               {
                  var paletteItem = new PaletteMenuItem { Indent = 0 };

                  this.BuildPaletteMenu(subitem, paletteItem, string.Empty);

                  this.paletteMenuItems.Add(paletteItem);
               }
            }
         } 
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Count > 0)
         {
            // This is a foldout
            paletteMenuItem.Name = contextMenuItem.Text.Replace("...", string.Empty);
            paletteMenuItem.Path = (string.IsNullOrEmpty(paletteMenuItemParent) ? string.Empty : paletteMenuItemParent + "/") + paletteMenuItem.Name;
            paletteMenuItem.Items = new List<PaletteMenuItem>();

            if (PaletteMenuItemFoldout.ContainsKey(paletteMenuItem.Path) == false)
            {
               PaletteMenuItemFoldout.Add(paletteMenuItem.Path, false);
            }

            foreach (var item in ((ToolStripMenuItem)contextMenuItem).DropDownItems)
            {
               var newItem = new PaletteMenuItem { Indent = paletteMenuItem.Indent + 1 };
               if (item == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildPaletteMenu()!", uScriptDebug.Type.Error);
                  return;
               }

               this.BuildPaletteMenu(item, newItem, paletteMenuItem.Path);
               paletteMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            // This is a menu item
            paletteMenuItem.Name = contextMenuItem.Text.Replace("&", string.Empty);
            paletteMenuItem.Path = (string.IsNullOrEmpty(paletteMenuItemParent) ? string.Empty : string.Format("{0}/", paletteMenuItemParent)) + paletteMenuItem.Name;
            paletteMenuItem.Tooltip = uScript.FindNodeToolTip(ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode));
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag = contextMenuItem.Tag;

            PaletteMenuItemCount++;
         }
      }
      else
      {
         uScriptDebug.Log(string.Format("The contextMenuItem ({0}) is a {1} and is unhandled!", contextMenuItem.Text, contextMenuItem.GetType()), uScriptDebug.Type.Warning);
      }
   }

   private void DetermineListStats(PaletteMenuItem item)
   {
      if (item.Hidden)
      {
         return;
      }

      if (item.Items == null)
      {
         // This is a simple menu item
         if (item.Width == 0)
         {
            item.Width = (int)uScriptGUIStyle.PaletteButton.CalcSize(new GUIContent(item.Name)).x;
         }
      }
      else
      {
         // This is should be a folding menu item that contains more buttons
         if (item.Width == 0)
         {
            item.Width = (int)uScriptGUIStyle.PaletteFoldout.CalcSize(new GUIContent(item.Name)).x;
         }

         if (PaletteMenuItemFoldout[item.Path])
         {
            foreach (var subitem in item.Items)
            {
               this.DetermineListStats(subitem);
            }
         }
      }

      item.X = ButtonPadding + (item.Indent * ButtonIndent);

      this.listItemRowWidth = Math.Max(this.listItemRowWidth, item.X + item.Width + ButtonPadding);
      this.listItemRowCount++;
   }

   private void DrawFavoritesPanel()
   {
      var favoriteNodeCount = this.favoriteMenuItems.Count(item => item != null);
      if (favoriteNodeCount <= 0)
      {
         return;
      }

      GUILayout.Space(uScriptGUI.PanelDividerThickness);

      var isPanelExpanded = uScript.Preferences.ExpandFavoritePanel;

      EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
      {
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label("Favorites", uScriptGUIStyle.PanelTitle);

            var toggleContent = isPanelExpanded ? uScriptGUIContent.buttonListCollapse : uScriptGUIContent.buttonListExpand;
            var toggle = GUILayout.Toggle(isPanelExpanded, toggleContent, uScriptGUIStyle.FavoriteButtonFoldout, GUILayout.ExpandWidth(false));
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
            var areaRect = EditorGUILayout.BeginVertical(GUILayout.Height((favoriteNodeCount * RowHeight) + 9));
            {
               GUILayout.FlexibleSpace();

               if (Event.current.type != EventType.Layout)
               {
                  // We're using 5 for (buttonMargin + buttonVerticalOverflow)
                  var rowRect = new Rect(areaRect.x, areaRect.y + 5, 0, RowHeight);

                  var popupWidth = (int)uScriptGUIStyle.FavoriteButtonNumber.CalcSize(new GUIContent("0")).x;

                  for (var i = 0; i < this.favoriteMenuItems.Count; i++)
                  {
                     var menuItem = this.favoriteMenuItems[i];

                     // && menuItem.Tag != null)
                     if (menuItem != null)
                     {
                        // Favorite number
                        rowRect.x = uScriptGUIStyle.FavoriteButtonNumber.margin.left;
                        rowRect.width = popupWidth;

                        var favoriteIndex = i + 1;

                        var newIndex = EditorGUI.Popup(rowRect, favoriteIndex, this.FavoritePopupOptions, uScriptGUIStyle.FavoriteButtonNumber);
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

                           Instance.BuildFavoritesMenu();
                        }

                        // Favorite name
                        var nodeName = menuItem.Name;

                        rowRect.x += rowRect.width;
                        rowRect.width = areaRect.width - rowRect.x - uScriptGUIStyle.FavoriteButtonName.margin.right;

                        if (menuItem.Tag == null)
                        {
                           GUI.color = new UnityEngine.Color(1, 0.5f, 0.5f, 1);
                        }

                        if (GUI.Button(rowRect, nodeName, uScriptGUIStyle.FavoriteButtonName))
                        {
                           CreateNode((EntityNode)menuItem.Tag);
                        }

                        GUI.color = UnityEngine.Color.white;

                        rowRect.y += RowHeight;
                     }
                  }
               }
            }
            EditorGUILayout.EndVertical();
         }
      }
      EditorGUILayout.EndVertical();
   }

   private bool DrawPaletteMenu(PaletteMenuItem item)
   {
      // This method should never be called when Event.current.type == EventType.Layout
      if (item.Hidden)
      {
         return false;
      }

      // Update button rect before drawing the control
      this.buttonRect.x = item.X;
      this.buttonRect.width = this.listItemRowWidth - item.X - ButtonPadding;

      // Determine if the item should be drawn
      if (_scrollviewOffset.y <= this.buttonRect.yMax)
      {
         // draw
         if (_scrollviewOffset.y + scrollviewRect.height > this.buttonRect.yMin)
         {
            // Draw the foldout or menu item button
            if (item.Items == null)
            {
               // This is a simple menu item
               if (GUI.Button(this.buttonRect, new GUIContent(item.Name, item.Tooltip), uScriptGUIStyle.PaletteButton))
               {
                  if (item.Click != null)
                  {
                     // Create the node on the canvas
                     var halfWidth = (int)(uScript.Instance.NodeWindowRect.width * 0.5f);
                     var halfHeight = (int)(uScript.Instance.NodeWindowRect.height * 0.5f);
                     var center = new Point(halfWidth, halfHeight);
                     uScript.Instance.ScriptEditorCtrl.ContextCursor = center;
                     item.OnClick();
                     uScriptDebug.Log(string.Format("Clicked '{0}'", item.Name), uScriptDebug.Type.Debug);
                  }
                  else
                  {
                     uScriptDebug.Log(string.Format("Cannot execute menu item: {0}", item.Name), uScriptDebug.Type.Debug);
                  }
               }
            }
            else
            {
               // This is a folding menu item that contains more buttons
               PaletteMenuItemFoldout[item.Path] = GUI.Toggle(this.buttonRect, PaletteMenuItemFoldout[item.Path], item.Name, uScriptGUIStyle.PaletteFoldout);
            }
         }
      }

      // Always perform the non-drawing functions

      // Handle mouse hovering
      if (isMouseOverScrollview && this.buttonRect.Contains(Event.current.mousePosition))
      {
         this.tempHotSelection = item.Tag as EntityNode;
      }

      // Prepare for the next control
      this.buttonRect.y += RowHeight;

      // If the item is an expanded foldout, draw its contents
      if (item.Items != null && PaletteMenuItemFoldout[item.Path])
      {
         foreach (var subitem in item.Items)
         {
            this.DrawPaletteMenu(subitem);
         }
      }

      return true;
   }

   /// <summary>Filters the toolbox menu item, hiding it if any words in the search query were not found in the item's Name.</summary>
   /// <returns>True if the parent or item should be hidden, otherwise False</returns>
   /// <param name='paletteMenuItem'>The Toolbox menu item to examine.</param>
   /// <param name='shouldForceVisible'>When True, the menu item will always be visible.</param>
   private bool FilterToolboxMenuItem(PaletteMenuItem paletteMenuItem, bool shouldForceVisible)
   {
      var words = this.panelFilterText.ToLower().Split();

      // The user can now enter keywords in any order to find matches
      var matchFound = words.All(word => paletteMenuItem.Name.ToLower().Contains(word));

      if (shouldForceVisible || matchFound)
      {
         // This and all children should be visible
         if (paletteMenuItem.Items != null)
         {
            foreach (var item in paletteMenuItem.Items)
            {
               item.Hidden = this.FilterToolboxMenuItem(item, true);
            }
         }

         return false;
      }

      if (paletteMenuItem.Items != null)
      {
         // Check each child to see if this should be visible
         var shouldHideParent = true;
         foreach (var item in paletteMenuItem.Items)
         {
            item.Hidden = this.FilterToolboxMenuItem(item, false);
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

   public class PaletteMenuItem : Detox.Windows.Forms.MenuItem
   {
      public string Name { get; set; }

      public string Tooltip { get; set; }

      public string Path { get; set; }
      
      public List<PaletteMenuItem> Items { get; set; }
      
      public EventHandler Click { get; set; }
      
      public bool Hidden { get; set; }
      
      public int Indent { get; set; }
      
      public int X { get; set; }
      
      public int Width { get; set; }

      public void OnClick()
      {
         if (this.Click != null)
         {
            this.Click(this, new EventArgs());
         }
      }
   }
}
