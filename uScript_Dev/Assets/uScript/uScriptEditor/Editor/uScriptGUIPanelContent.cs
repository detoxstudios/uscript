// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelContent.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#if !RELEASE
#define UNITY_STORE_PRO
#endif

using System;
using System.Collections.Generic;
using System.Linq;

using Detox.Editor;
using Detox.Editor.GUI;
using Detox.ScriptEditor;

using UnityEditor;

using UnityEngine;
using Detox.FlowChart;

public sealed class uScriptGUIPanelContent : uScriptGUIPanel
{
   private const int ButtonPadding = 4;
   private const int RowHeight = 19;

   private static readonly Dictionary<string, bool> CategoryFoldout = new Dictionary<string, bool>();

   private static Rect scrollviewRect;

   private int filterMatches;
   private bool foldoutExpanded;
   private string panelFilterText = string.Empty;

   private GUIStyle stylePadding;
   private Rect buttonRect;
   private int listItemRowCount;
   private int listItemRowWidth;

   public bool FocusSearchBox { get; set; }

   public override bool InUScriptPanel {
      set
      {
         _inUScriptPanel = value;
         if (uScriptGUIPanelToolbox.Instance != null && uScriptGUIPanelToolbox.Instance.InUScriptPanel != value) uScriptGUIPanelToolbox.Instance.InUScriptPanel = value;
      }
   }

   static uScriptGUIPanelContent()
   {
      Instance = new uScriptGUIPanelContent();
   }

   private uScriptGUIPanelContent()
   {
      InUScriptPanel = true;
      this.Init();
   }

   public static uScriptGUIPanelContent Instance { get; private set; }

   public void Init()
   {
      this.Name = "Contents";
   }

   public void ClearSearchFilter()
   {
      this.panelFilterText = string.Empty;
   }

   public override void Draw()
   {
      // Called during OnGUI()

      // Local references to uScript
      var uScriptInstance = uScript.WeakInstance;

      // Initialize the style used for scrollview "padding"
      if (this.stylePadding == null)
      {
         this.stylePadding = new GUIStyle(GUIStyle.none) { stretchWidth = true };
      }

      if (uScriptInstance == null && !InUScriptPanel)
      {
         EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
         {
            // draw empty panel
            this.DrawOrphanNotification();
         }
         EditorGUILayout.EndVertical();
      }
      else
      {
         if (InUScriptPanel && !uScriptInstance.IsOnlyBottomPanelVisible(GetType().ToString()))
         {
            uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.PanelLeftWidth));
         }
         else
         {
            uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
         }
         {
            uScript.Instance.paletteRect = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
            {
               this.DrawToolbar();

               if (uScriptInstance.wasCanvasDragged && Preferences.DrawPanelsOnUpdate == false)
               {
                  this.DrawHiddenNotification();
               }
               else
               {
                  // Graph Contents list
                  //
                  // Every node in the graph should be listed here, categorized by type.

                  // Process all nodes and place them in the appropriate list
                  var categories = new Dictionary<string, Dictionary<string, List<DisplayNode>>>
               {
                  { "Comments", new Dictionary<string, List<DisplayNode>>() },
                  { "Actions", new Dictionary<string, List<DisplayNode>>() },
                  { "Conditions", new Dictionary<string, List<DisplayNode>>() },
                  { "Events", new Dictionary<string, List<DisplayNode>>() },
                  { "Properties", new Dictionary<string, List<DisplayNode>>() },
                  { "Variables", new Dictionary<string, List<DisplayNode>>() },
                  { "Miscellaneous", new Dictionary<string, List<DisplayNode>>() }
               };

                  if (CategoryFoldout.Count == 0)
                  {
                     foreach (var kvpCategory in categories)
                     {
                        // Default each foldout to "expanded"
                        CategoryFoldout.Add(kvpCategory.Key, true);
                     }
                  }

                  // TODO: clean up this code
                  foreach (var node in uScript.Instance.ScriptEditorCtrl.FlowChart.Nodes)
                  {
                     var displayNode = node as DisplayNode;
                     var category = "Miscellaneous";
                     var key = string.Empty;
                     var comment = string.Empty;

                     var eventDisplayNode = displayNode as EntityEventDisplayNode;
                     if (eventDisplayNode != null)
                     {
                        category = "Events";
                        key = eventDisplayNode.EntityEvent.FriendlyType;
                        comment = eventDisplayNode.EntityEvent.Comment.Default;
                     }
                     else
                     {
                        var nodeDisplayNode = displayNode as LogicNodeDisplayNode;
                        if (nodeDisplayNode != null)
                        {
                           category = "Actions";
                           key = nodeDisplayNode.LogicNode.FriendlyName;
                           comment = nodeDisplayNode.LogicNode.Comment.Default;
                        }
                        else
                        {
                           var localNodeDisplayNode = displayNode as LocalNodeDisplayNode;
                           if (localNodeDisplayNode != null)
                           {
                              category = "Variables";
                              key = localNodeDisplayNode.LocalNode.Value.Type; // get FriendlyName
                              key = uScriptConfig.Variable.FriendlyName(key).Replace("UnityEngine.", string.Empty);

                              var value = localNodeDisplayNode.LocalNode.Value.Default;
                              if (key == "String")
                              {
                                 value = string.Format("\"{0}\"", localNodeDisplayNode.LocalNode.Value.Default);
                              }

                              key = string.Format("{0} ({1})", key, value);
                              comment = localNodeDisplayNode.LocalNode.Name.Default;
                           }
                           else
                           {
                              var commentDisplayNode = displayNode as CommentDisplayNode;
                              if (commentDisplayNode != null)
                              {
                                 category = "Comments";
                                 key = commentDisplayNode.Comment.TitleText.FriendlyName;
                                 comment = commentDisplayNode.Comment.TitleText.Default;
                              }
                              else
                              {
                                 var propertyDisplayNode = displayNode as EntityPropertyDisplayNode;
                                 if (propertyDisplayNode != null)
                                 {
                                    category = "Properties";
                                    key = propertyDisplayNode.DisplayName.Replace("\n", ": ");
                                    comment = propertyDisplayNode.DisplayValue;
                                 }
                                 else
                                 {
                                    var methodDisplayNode = displayNode as EntityMethodDisplayNode;
                                    if (methodDisplayNode != null)
                                    {
                                       category = "Actions";
                                       key = methodDisplayNode.EntityMethod.Input.FriendlyName;
                                       comment = methodDisplayNode.EntityMethod.Comment.Default;
                                    }
                                    else if (displayNode is OwnerConnectionDisplayNode)
                                    {
                                       category = "Variables";
                                       key = "Owner GameObject";
                                       ////comment = ((OwnerConnectionDisplayNode)displayNode).OwnerConnection.Instance.FriendlyName;
                                    }
                                 }
                              }
                           }
                        }
                     }

                     // Validate strings
                     key = string.IsNullOrEmpty(key) ? "UNKNOWN" : key;
                     key += string.IsNullOrEmpty(comment) ? string.Empty : string.Format(" ({0})", comment);

                     // Apply the filter now, to ignore items that are not matched
                     if (string.IsNullOrEmpty(this.panelFilterText) || this.IncludeAsMenuItem(key, false, node))
                     {
                        //this.filterMatches++;

                        if (categories[category].ContainsKey(key) == false)
                        {
                           categories[category].Add(key, new List<DisplayNode>());
                        }

                        // Add the node to the list
                        categories[category][key].Add(displayNode);
                     }
                  }

                  // Examine the final filtered categories to determine how many items will be drawn
                  this.DetermineListStats(categories);

                  // Draw the list
                  this.ScrollviewOffset = EditorGUILayout.BeginScrollView(
                     this.ScrollviewOffset,
                     false,
                     false,
                     uScriptGUIStyle.HorizontalScrollbar,
                     uScriptGUIStyle.VerticalScrollbar,
                     "scrollview",
                     GUILayout.ExpandWidth(true));
                  {
                     // Draw the padding box to establish the row width (excluding scrollbar)
                     // and force the scrollview content height
                     GUILayout.Box(
                        string.Empty,
                        this.stylePadding,
                        GUILayout.Height(Math.Max(0, (RowHeight * this.listItemRowCount) - 10)),
                        GUILayout.Width(this.listItemRowWidth));
                     GUILayout.Box(string.Empty, this.stylePadding, GUILayout.Height(10), GUILayout.ExpandWidth(true));

                     // Prepare to draw each row of the filtered list
                     // From this point on, the contents of the scrollview should
                     // never use GUILayout, so we can safely skip EventType.Layout.
                     if (Event.current.type != EventType.Layout)
                     {
                        // Make sure the we get the width of the last GUILayout.Box
                        // just in case it is wider than the widest button below
                        this.listItemRowWidth = Math.Max(this.listItemRowWidth, (int)GUILayoutUtility.GetLastRect().width);

                        this.buttonRect = new Rect(0, 0, 0, RowHeight);
                        this.filterMatches = 0;

                        // Draw all the palette items
                        foreach (var category in categories)
                        {
                           this.filterMatches += this.DrawCategoryItems(category);
                        }
                     }

                     // Display a message if no filter matches were found.
                     if (this.filterMatches == 0)
                     {
                        GUILayout.Label("The search found no matches!", uScriptGUIStyle.PanelMessageBold);
                     }
                  }
                  EditorGUILayout.EndScrollView();

                  if (Event.current.type == EventType.Repaint)
                  {
                     scrollviewRect = GUILayoutUtility.GetLastRect();
                  }
               }
            }
            EditorGUILayout.EndVertical();
         }
         EditorGUILayout.EndVertical();

         if ((int)uScript.Instance.paletteRect.width != 0 && (int)uScript.Instance.paletteRect.width != uScriptGUI.PanelLeftWidth)
         {
            // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
            uScriptGUI.PanelLeftWidth = (int)uScript.Instance.paletteRect.width;
         }

         ////uScriptGUI.DefineRegion(uScriptGUI.Region.Palette);
         if (InUScriptPanel) uScriptInstance.SetMouseRegion(uScript.MouseRegion.Palette);
      }
   }

   // Use recursion to set all menu item foldouts in the node palette
   private static void ExpandMenuFoldouts(bool state)
   {
      var keys = CategoryFoldout.Keys.ToArray();
      foreach (var key in keys)
      {
         CategoryFoldout[key] = state;
      }
   }

   private void DetermineListStats(Dictionary<string, Dictionary<string, List<DisplayNode>>> categories)
   {
      this.listItemRowCount = 0;
      this.listItemRowWidth = 100;

      if (categories == null)
      {
         return;
      }

      foreach (var category in categories)
      {
         var categoryName = category.Key;
         var categoryContent = category.Value;

         if (categoryContent.Count > 0)
         {
            // Include the foldout
            this.listItemRowCount++;

            // If the foldout is expanded ...
            if (CategoryFoldout[categoryName])
            {
               // Include every item in the category content
               foreach (var kvp in categoryContent)
               {
                  this.listItemRowCount += kvp.Value.Count;

                  // TODO: If we want to use ellipses, this is the place to do it
               }
            }
         }
      }

      //if (categories.Items == null)
      //{
      //   // This is a simple menu item
      //   if (categories.Width == 0)
      //   {
      //      categories.Width = (int)uScriptGUIStyle.PaletteButton.CalcSize(new GUIContent(categories.Name)).x;
      //   }
      //}
      //else
      //{
      //   // This is should be a folding menu item that contains more buttons
      //   if (categories.Width == 0)
      //   {
      //      categories.Width = (int)uScriptGUIStyle.PaletteFoldout.CalcSize(new GUIContent(categories.Name)).x;
      //   }

      //   if (CategoryFoldout[categories.Path])
      //   {
      //      foreach (var subitem in categories.Items)
      //      {
      //         this.DetermineListStats(subitem);
      //      }
      //   }
      //}
   }

   private int DrawCategoryItems(KeyValuePair<string, Dictionary<string, List<DisplayNode>>> kvpCategory)
   {
      var nodeButtonContent = new GUIContent(string.Empty, "Click to select node. Shift-click to toggle the selection.");

      var categoryName = kvpCategory.Key;
      var categoryContent = kvpCategory.Value;

      if (categoryContent.Count <= 0)
      {
         return 0;
      }

      // The category contains at least one item to show
      var rows = 1;

      // This is should be a folding menu item that contains more buttons
      var tmpStyle = new GUIStyle(uScriptGUIStyle.PaletteFoldout);
      tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (0 * 12), 0, 0, 0);

      this.buttonRect.x = ButtonPadding;
      this.buttonRect.width = this.listItemRowWidth - ButtonPadding - ButtonPadding;

      // Determine if the item should be drawn
      if (this.ShouldDraw())
      {
         CategoryFoldout[categoryName] = GUI.Toggle(
            this.buttonRect,
            CategoryFoldout[categoryName],
            categoryName,
            tmpStyle);
      }

      this.buttonRect.y += this.buttonRect.height;

      if (CategoryFoldout[categoryName])
      {
         var nodeList = categoryContent.Keys.ToList();
         nodeList.Sort();

         foreach (var s in nodeList)
         {
            var nodes = categoryContent[s];

            // Show each node
            foreach (var dn in nodes)
            {
               if (this.ShouldDraw())
               {
                  // We must draw from right to left, so that the buttons overlap each other correctly,
                  // but we need to know if the optional deprecated button will be drawn first.
                  var isTypeDeprecated = uScript.IsNodeTypeDeprecated(dn.EntityNode);
                  var isInstanceDeprecated =
                     uScript.Instance.ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(dn.EntityNode);

                  var rightButton = this.buttonRect;
                  rightButton.xMin = rightButton.xMax - 20;

                  var leftButton = this.buttonRect;
                  leftButton.xMax -= rightButton.width;

                  if (isTypeDeprecated == false && isInstanceDeprecated)
                  {
                     leftButton.xMax -= rightButton.width;
                  }

                  // Update button color when the node is deprecated
                  var tmpColor = GUI.color;
                  var textColor = uScriptGUIStyle.NodeButtonLeft.normal.textColor;

                  if (isTypeDeprecated || isInstanceDeprecated)
                  {
                     GUI.color = new Color(1, 0.5f, 1, 1);
                     uScriptGUIStyle.NodeButtonLeft.normal.textColor = Color.white;
                  }

                  // Draw the button label
                  if (Event.current.type == EventType.Repaint)
                  {
                     nodeButtonContent.text = s;
                  }

                  // Draw the button as a toggle
                  var selected = GUI.Toggle(leftButton, dn.Selected, nodeButtonContent, uScriptGUIStyle.NodeButtonLeft);

                  if (selected != dn.Selected)
                  {
                     FocusedControl.Clear();

                     // is the shift key modifier being used?
                     if (Event.current.modifiers != EventModifiers.Shift)
                     {
                        // clear all selected nodes first
                        uScript.Instance.ScriptEditorCtrl.DeselectAll();
                     }

                     // toggle the clicked node
                     uScript.Instance.ScriptEditorCtrl.ToggleNode(dn.Guid);
                  }

                  // Draw the right-most Search button
                  if (GUI.Button(rightButton, uScriptGUIContent.buttonNodeFind, uScriptGUIStyle.NodeButtonRight))
                  {
                     uScript.Instance.ScriptEditorCtrl.CenterOnNode(uScript.Instance.ScriptEditorCtrl.GetNode(dn.Guid));
                  }

                  // Draw the optional Fix Deprecation button
                  if (isTypeDeprecated == false && isInstanceDeprecated)
                  {
                     rightButton.x -= rightButton.width;

                     if (uScript.Instance.ScriptEditorCtrl.ScriptEditor.CanUpgradeNode(dn.EntityNode))
                     {
                        if (GUI.Button(
                           rightButton,
                           uScriptGUIContent.buttonNodeUpgrade,
                           uScriptGUIStyle.NodeButtonMiddle))
                        {
                           FocusedControl.Clear();

                           var click = new EventHandler(uScript.Instance.ScriptEditorCtrl.m_MenuUpgradeNode_Click);

                           // clear all selected nodes first
                           uScript.Instance.ScriptEditorCtrl.DeselectAll();

                           // toggle the clicked node
                           uScript.Instance.ScriptEditorCtrl.ToggleNode(dn.Guid);
                           click(this, new EventArgs());
                        }
                     }
                     else
                     {
                        if (GUI.Button(
                           rightButton,
                           uScriptGUIContent.buttonNodeDeleteMissing,
                           uScriptGUIStyle.NodeButtonMiddle))
                        {
                           FocusedControl.Clear();

                           var click = new EventHandler(uScript.Instance.ScriptEditorCtrl.m_MenuDeleteMissingNode_Click);

                           // clear all selected nodes first
                           uScript.Instance.ScriptEditorCtrl.DeselectAll();

                           // toggle the clicked node
                           uScript.Instance.ScriptEditorCtrl.ToggleNode(dn.Guid);
                           click(this, new EventArgs());
                        }
                     }
                  }

                  // Reset the colors for the next menu item
                  GUI.color = tmpColor;
                  uScriptGUIStyle.NodeButtonLeft.normal.textColor = textColor;
               }

               this.buttonRect.y += this.buttonRect.height;
               rows++;
            }
         }
      }

      return rows;
   }

   private void DrawToolbar()
   {
      // Toolbar
      EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
      {
         // Unlike standard panels, this panel shares the same area as the
         // Graph Contents panel.  For now, use a DropDown control instead
         // of the typical Label for the panel title.
         var options = new[] { "Toolbox", "Contents" };
         var size = uScriptGUIStyle.PanelTitleDropDown.CalcSize(new GUIContent(options[1]));
         var index = EditorGUILayout.Popup(
            uScript._paletteMode,
            options,
            uScriptGUIStyle.PanelTitleDropDown,
            GUILayout.Width(size.x));
         if (uScript._paletteMode != index)
         {
            uScript.SetPaletteMode(index);
         }

         //if (uScript.IsDevelopmentBuild)
         //{
         //   GUILayout.Label(string.Format("({0})", this.listItemRowCount), uScriptGUIStyle.ToolbarLabel);
         //}

         GUILayout.FlexibleSpace();

         // Toggle hierarchy foldouts
         var toggleContent = this.foldoutExpanded
                                ? uScriptGUIContent.buttonListCollapse
                                : uScriptGUIContent.buttonListExpand;
         var expanded = GUILayout.Toggle(
            this.foldoutExpanded,
            toggleContent,
            uScriptGUIStyle.PaletteToolbarFoldoutButton,
            GUILayout.ExpandWidth(false));
         if (this.foldoutExpanded != expanded)
         {
            this.foldoutExpanded = expanded;
            ExpandMenuFoldouts(this.foldoutExpanded);
         }

         if (FocusSearchBox)
         {
             FocusSearchBox = false;
             EditorGUI.FocusTextInControl("ContentFilterSearch");
         }

         GUI.SetNextControlName("ContentFilterSearch");
         var filterText = uScriptGUI.ToolbarSearchField(
            this.panelFilterText,
            GUILayout.MinWidth(50),
            GUILayout.MaxWidth(100));

         if (this.panelFilterText != filterText)
         {
            // Drop focus if the user inserted a newline (hit enter)
            if (filterText.Contains("\n"))
            {
               FocusedControl.Clear();
            }

            // Trim leading whitespace
            filterText = filterText.TrimStart();

            this.panelFilterText = filterText;

            //this.FilterMenuItems(filterText, false);
         }

         if (InUScriptPanel)
         {
            if (GUILayout.Button(Content.ButtonPopout, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonPopout).x)))
            {
               if (uScript.GetUScriptGUIPanelWindow<uScriptGUIPanelContent>() == null) uScript.OpenPopOutWindow(this);
               uScript.Instance.CommandCanvasShowPalettePanel();
            }
            if (GUILayout.Button(Content.ButtonClose, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonClose).x)))
            {
               uScript.Instance.CommandCanvasShowPalettePanel();
            }
         }
      }
      EditorGUILayout.EndHorizontal();
   }

   /// <summary>Filters the toolbox menu item, hiding it if any words in the search query were not found in the item's Name.</summary>
   /// <returns>True if the parent or item should be hidden, otherwise False</returns>
   /// <param name='label'>The Toolbox menu item to examine.</param>
   /// <param name='shouldForceVisible'>When True, the menu item will always be visible.</param>
   private bool IncludeAsMenuItem(string label, bool shouldForceVisible, Node node)
   {
      var words = this.panelFilterText.ToLower().Split();

      // The user can now enter keywords in any order to find matches
      var matchFound = words.All(word => label.ToLower().Contains(word));

      if (!matchFound && Preferences.EnableContentsFieldSearch)
      {
         EntityNode entityNode = ((DisplayNode)node).EntityNode;

         // check comment...
         var comment = entityNode.Comment;
         if (!string.IsNullOrEmpty(comment.Type))
         {
            string commentString = (string)comment.DefaultAsObject;
            if (!string.IsNullOrEmpty(commentString))
            {
               matchFound = words.All(word => commentString.ToLower().Contains(word));
            }
         }

         // ...and all string params for the search term(s) as well
         if (!matchFound)
         {
            var parameters = entityNode.Parameters;
            foreach (var param in parameters)
            {
               if (param.Type == "System.String" || param.Type == "TextArea")
               {
                  matchFound = words.All(word => ((string)param.DefaultAsObject).ToLower().Contains(word));
                  if (matchFound) return true;
               }
               else if (param.Type == "System.Object[]")
               {
                  // check any string arrays (which are typed as System.Object[])
                  object[] objects = (object[])param.DefaultAsObject;
                  foreach (object o in objects)
                  {
                     string s = o as string;
                     if (!string.IsNullOrEmpty(s)) matchFound = words.All(word => s.ToLower().Contains(word));
                     if (matchFound) return true;     
                  }
               }
            }
         }
      }

      return shouldForceVisible || matchFound;
   }

   private bool ShouldDraw()
   {
      if (this.ScrollviewOffset.y <= this.buttonRect.yMax)
      {
         if (this.ScrollviewOffset.y + scrollviewRect.height > this.buttonRect.yMin)
         {
            return true;
         }
      }
      return false;
   }

   private static class Content
   {
      static Content()
      {
         ButtonPopout = new GUIContent
         {
            image = uScriptGUI.GetSkinnedTexture("iconPopout"),
            tooltip = "Open a standalone window with this panel's contents within it."
         };

         ButtonClose = new GUIContent
         {
            image = uScriptGUI.GetSkinnedTexture("iconMiniDelete"),
            tooltip = "Close this panel."
         };
      }

      public static GUIContent ButtonPopout { get; private set; }
      public static GUIContent ButtonClose { get; private set; }
   }
}
