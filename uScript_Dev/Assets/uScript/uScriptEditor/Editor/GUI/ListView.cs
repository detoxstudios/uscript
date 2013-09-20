//-----------------------------------------------------------------------
// <copyright file="ListView.cs" company="Detox Studios, LLC">
//     Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using System.Globalization;
   using System.Linq;

   using UnityEditor;
   using UnityEngine;

   public class ListView
   {
      // === Fields =====================================================================

      private readonly List<Rect> dragHandles = new List<Rect>();

      private readonly List<ListViewItem> seedItems = new List<ListViewItem>();
      private readonly List<ListViewItem> filteredItems = new List<ListViewItem>();
      private readonly List<ListViewItem> visibleItems = new List<ListViewItem>(); 
      private readonly List<ListViewItem> selectedItems = new List<ListViewItem>();

      private readonly Dictionary<string, FolderInfo> folderItems = new Dictionary<string, FolderInfo>();

      private readonly int controlID;

      private ListViewItem anchorItem;
      private Vector2 dragInitialMouse;
      private Vector2 dragInitialSize;
      private ListViewColumn draggedColumn;
      private Rect itemRowRect;

      private Vector2 listOffset = Vector2.zero;

      private bool shouldRebuildVisibleList;

      private Rect totalContentSize;

      // === Constructors ===============================================================

      public ListView(EditorWindow window) : this(window, typeof(ListViewItem))
      {
      }

      public ListView(EditorWindow window, Type typeListViewItem)
      {
         this.EditorWindow = window;
         this.controlID = GUIUtility.GetControlID(FocusType.Keyboard);
         
         if (typeof(ListViewItem).IsAssignableFrom(typeListViewItem))
         {
            this.ListItemType = typeListViewItem;
         }
         else
         {
            uScriptDebug.Log("The specified type is not a ListViewItem type.", uScriptDebug.Type.Error);
         }
      }

      // === Properties =================================================================

      public bool AllowColumnReorder { get; set; }

      public bool AlternateRowBackground { get; set; }

      public Rect Bounds { get; private set; }

      public bool CanSelect { get; set; }

      public Rect ClientRect { get; private set; }

      public List<ListViewColumn> Columns { get; private set; }

      public EditorWindow EditorWindow { get; private set; }

      public int FirstVisibleRow { get; private set; }

      public bool ForceHorizontalColumnFit { get; set; }

      public bool HasFocus { get; set; }

      public Rect HeaderPosition { get; private set; }

      public bool IsHorizontalScrollbarVisible { get; private set; }

      public bool IsVerticalScrollbarVisible { get; private set; }

      public int ItemRow { get; set; }

      public bool ItemRowEven { get; private set; }

      public int LastVisibleRow { get; private set; }

      public Type ListItemType { get; private set; }

      public Vector2 ListOffset
      {
         get
         {
            return this.listOffset;
         }

         private set
         {
            if (this.listOffset != value)
            {
               this.EditorWindow.Repaint();
            }

            this.listOffset = value;
         }
      }

      public Rect ListPosition { get; private set; }

      public int MinRowWidth { get; private set; }

      public bool MultiSelectEnabled { get; set; }

      public bool MultiSelect { get; set; }

      public Rect ParentPanelRect { get; set; }

      public ListViewItem PendingExecution { get; set; }

      public Rect Position { get; private set; }

      public bool Scrollable { get; set; }

      public ListViewItem[] SelectedItems
      {
         get
         {
            return this.selectedItems.ToArray();
         }
      }

//      public ListViewItem SelectedID
//      {
//         get { return this.selectedItems.Count > 0 ? this.selectedItems[0] : null; }
//      }

      public bool ShowColumnHeaders { get; set; }

      public bool SortByColumn { get; set; }

      public ListViewColumn SortColumn { get; private set; }

      public int TotalColumnWidth { get; private set; }

      public int TotalVisibleItems { get; private set; }

      // === Methods ====================================================================

      public void AddColumn(ListViewColumn column)
      {
         if (this.Columns == null)
         {
            this.Columns = new List<ListViewColumn>();
         }

         if (column == null)
         {
            throw new ArgumentException("The specified column is null.", "column");
         }

         if (this.Columns.Any(element => element.ID == column.ID))
         {
            throw new ArgumentException("A column with the specified ID already exists: \"" + column.ID + "\"", "column");
         }

         this.Columns.Add(column);

         if (column.IsSelectable && this.SortColumn == null)
         {
            this.SortColumn = column;
         }
      }

      public void AddItem(string path)
      {
         this.AddItem((ListViewItem)Activator.CreateInstance(this.ListItemType, this, path));
      }

      public void AddItem(ListViewItem item)
      {
         this.seedItems.Add(item);
      }

      public void ClearItems()
      {
         this.seedItems.Clear();
         this.filteredItems.Clear();
         this.visibleItems.Clear();
      }

      public void ClickNewSelection(ListViewItem item)
      {
         //Debug.Log("ClickNewSelection(): " + item.ItemPath + "\n" + "\t"
         //   + "filteredItems.Count: " + this.filteredItems.Count + ", visibleItems.Count: " + this.visibleItems.Count);

         this.SelectNone();
         this.SelectItem(item);
         this.FrameItem(item);
         this.anchorItem = item;
      }

      public void ClickToggleSelection(ListViewItem item)
      {
         //Debug.Log("ClickToggleSelection(): " + item.ItemPath + "\n");

         if (this.selectedItems.Contains(item))
         {
            this.DeselectItem(item);
            this.EditorWindow.Repaint(); // Required to avoid delayed refresh
         }
         else
         {
            this.SelectItem(item);
            this.FrameItem(item);
            this.anchorItem = item;
         }
      }

      public void ClickRangeSelection(ListViewItem item)
      {
         // The behavior for range selection closely resembles standard Windows selection as seen in Explorer.
         // Mac Finder has a much more complicated selection system, and Unity has one that isn't fully understood.

         this.SelectNone();

         // When an item is sent to ClickSelect or ClickToggle, the anchor is set
         // If there is no anchor, the first item in the list is used
         if (this.anchorItem == null)
         {
            this.anchorItem = this.visibleItems.First();
         }

         // TODO: Remove the following debug logic
         var anchorName = this.anchorItem == null ? "(null)" : this.anchorItem.ItemName;
         Debug.Log("SELECT RANGE: \t\"" + anchorName + "\"\n\t\t\t\t  TO: \t\"" + item.ItemName + "\"");

         // TODO: Add the specified range to the selection
      }

      public void Draw(Rect parentPanelRect)
      {
         var e = Event.current;

         ////hasFocus = EditorWindow.focusedWindow == EditorWindow;
         
         var rectListView = EditorGUILayout.BeginVertical();
         {
            if (this.ShowColumnHeaders)
            {
               this.DrawColumnHeaders();
            }

            // Get the visibleItems, if necessary
            if (this.shouldRebuildVisibleList)
            {
               this.BuildVisibleList();
            }

            if (e.type == EventType.Layout)
            {
               // TODO: Determine the height and position of each item in the list

               // TODO: With the above information, determine the first and last visible items
            }
            else
            {
               // TODO: Replace this properties with actual pixel sizes, to support variable-height rows.
               //       The current properties assume every row has a fixed height of 16 pixels.
               this.FirstVisibleRow = (int)(this.ListOffset.y / 16);
               this.LastVisibleRow = (int)((rectListView.height + this.ListOffset.y) / 16);

               this.Position = rectListView;

               //Debug.Log("LIST VIEW RECT: " + rectListView.ToString() + "\n" + "SCROLL OFFSET: " + _listPosition.ToString());
               //Debug.Log("FIRST:\t" + _firstVisibleRow.ToString() + "\nLAST:\t\t" + _lastVisibleRow.ToString());
            }

            // Check to see if the control focus is gained or lost
            this.UpdateFocus(parentPanelRect);

            Rect listPosition = EditorGUILayout.BeginVertical();
            {
               this.ListOffset = EditorGUILayout.BeginScrollView(
                  this.ListOffset,
                  false,
                  false,
                  uScriptGUIStyle.HorizontalScrollbar,
                  uScriptGUIStyle.VerticalScrollbar,
                  "scrollview");
               {
                  var totalVisibleRows = this.visibleItems.Count;
                  if (this.TotalVisibleItems != totalVisibleRows)
                  {
                     this.TotalVisibleItems = totalVisibleRows;
                     this.EditorWindow.Repaint();
                  }

                  //Debug.Log("VISIBLE ROWS: " + totalVisibleRows.ToString() + "\n");

                  // Determine the width by drawing a non-visible box using the GUILayout system
                  GUILayout.Box(
                     string.Empty,
                     GUIStyle.none,
                     GUILayout.ExpandWidth(true),
                     GUILayout.ExpandHeight(true),
                     GUILayout.MinHeight(this.totalContentSize.height),
                     GUILayout.MinWidth(this.TotalColumnWidth));

                  if (e.type != EventType.Layout)
                  {
                     this.MinRowWidth = Math.Max(this.TotalColumnWidth, (int)GUILayoutUtility.GetLastRect().width);
                  }

                  if (this.Position != new Rect() && e.type != EventType.Layout)
                  {
                     var rectScrollView = new Rect(this.Position);
                     rectScrollView.yMin += 16;

                     this.IsHorizontalScrollbarVisible = false;
                     this.IsVerticalScrollbarVisible = false;

                     if (rectScrollView.height < this.totalContentSize.height)
                     {
                        this.IsHorizontalScrollbarVisible = rectScrollView.width < this.MinRowWidth + 15;
                        this.IsVerticalScrollbarVisible = true;
                     }

                     if (rectScrollView.width < this.MinRowWidth)
                     {
                        this.IsHorizontalScrollbarVisible = true;
                        this.IsVerticalScrollbarVisible = rectScrollView.height < this.totalContentSize.height + 15;
                     }

                     //Debug.Log("SCROLLBARS:  " + (isHorizontalScrollbarVisible && isVerticalScrollbarVisible ? "BOTH"
                     //   : (isHorizontalScrollbarVisible ? "HORIZONTAL"
                     //      : (isVerticalScrollbarVisible ? "VERTICAL"
                     //         : "NONE"))) + "\n");
                  }

                  this.ItemRow = 0;
                  this.ItemRowEven = false;

                  if (this.visibleItems.Count > 0)
                  {
                     this.itemRowRect = new Rect(0, 0, this.MinRowWidth, 0);

                     for (var i = 0; i < this.visibleItems.Count; i++)
                     {
                        // TODO: Pass a reference to _itemRowRect, so that the ListView can keep track of the layout
                        // TODO: Create a Contains method that returns true if any part of a rect exists in another rect

                        ListViewItem item = this.visibleItems[i];

                        bool shouldDrawRow = this.ItemRow >= this.FirstVisibleRow && this.ItemRow <= this.LastVisibleRow;

                        if (shouldDrawRow)
                        {
                           // TODO: Figure out if we're using item.Position or this.itemRowRect ... leaning towards item.Position
                           item.Position = new Rect(0, item.Row * item.Height, this.MinRowWidth, item.Height);
                           this.itemRowRect.height = item.Height;

                           //int top = 0;
                           //int width = 0;

                           //Debug.Log("DRAWING ITEM: \"" + item.ItemName + "\"\n");

                           item.Draw(ref this.itemRowRect);
                           this.itemRowRect.y += item.Height;

                           //Debug.Log("ROW: " + this.ItemRow.ToString() + ", RECT: " + this.itemRowRect.ToString() + "\n");
                        }

                        this.visibleItems[i].Row = this.ItemRow++;
                        this.ItemRowEven = !this.ItemRowEven;
                     }

                     if (e.type == EventType.MouseDown && e.button == 0)
                     {
                        this.SelectNone();
                        e.Use();
                     }
                  }
                  else
                  {
                     // TODO: update the appearance of this message
                     GUILayout.Label("No uScript graphs were found.");
                  }
               }

               EditorGUILayout.EndScrollView();
            }

            if (e.type != EventType.Layout && e.type != EventType.Used && e.type != EventType.Ignore)
            {
               this.ListPosition = listPosition;
            }

            EditorGUILayout.EndVertical();
         }
         
         EditorGUILayout.EndVertical();
         
         // Process keyboard input
         if (this.HasFocus)
         {
            if (e.type == EventType.KeyDown)
            {
               // SelectAll (Cmd+A / Ctrl+A) is handled differently
               if (e.modifiers == 0)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Escape:
                        this.SelectNone();
                        e.Use();
                        break;
                        
            //         case KeyCode.Tab:
            //            // Move focus to search control (if there is one)
            //            Debug.Log("KEY: " + e.keyCode.ToString() + "\n");
            //            break;
                        
            //         case KeyCode.Return:
            //         case KeyCode.KeypadEnter:
            //            // Action performed on KeyUp
            //            e.Use();
            //            break;
                  }
               }
               else if (e.modifiers == EventModifiers.FunctionKey)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Home:
                        this.SelectFirst();
                        e.Use();
                        break;

                     case KeyCode.End:
                        this.SelectLast();
                        e.Use();
                        break;

                     case KeyCode.UpArrow:
                        this.SelectPrevious();
                        e.Use();
                        break;

                     case KeyCode.DownArrow:
                        this.SelectNext();
                        e.Use();
                        break;

                     case KeyCode.PageUp:
                        this.SelectPageUp();
                        e.Use();
                        break;

                     case KeyCode.PageDown:
                        this.SelectPageDown();
                        e.Use();
                        break;

                     case KeyCode.RightArrow:
                        if (this.selectedItems.Count > 0)
                        {
                           if (this.selectedItems.Count > 1)
                           {
                              // When multiple items are selected, expand all selected folders
                              foreach (var item in this.selectedItems)
                              {
                                 if (this.IsFolder(item))
                                 {
                                    this.ExpandFolder(item);
                                 }
                              }
                           }
                           else
                           {
                              // A single item is selected. If it's a folder, then expand if collapsed, or select the next item
                              var item = this.selectedItems.First();
                              if (this.IsFolder(item))
                              {
                                 if (this.IsFolderExpanded(item))
                                 {
                                    this.SelectNext();
                                 }
                                 else
                                 {
                                    this.ExpandFolder(item);
                                 }
                              }
                           }
                        }

                        e.Use();
                        break;
                        
                     case KeyCode.LeftArrow:
                        if (this.selectedItems.Count > 0)
                        {
                           if (this.selectedItems.Count > 1)
                           {
                              //TODO: create an ExpandSelectedFolders() and CollapseSelectedFolders()
                              // When multiple items are selected, collapse all selected folders
                              foreach (var item in this.selectedItems)
                              {
                                 if (this.IsFolder(item))
                                 {
                                    this.CollapseFolder(item);
                                 }
                              }
                              // TODO: The CollapseSelectedFolders() method should collapse folders and then look through verify that all selected items are still visible, removing those that are not hidden. This pruning logic should be triggered after all Collapse actions and after filter updates as well.
                           }
                           else
                           {
                              // A single item is selected. If it's a folder and expanded then collapse else select the parent item, if there is one
                              var item = this.selectedItems.First();
                              if (this.IsFolder(item) && this.IsFolderExpanded(item))
                              {
                                 this.CollapseFolder(item);
                              }
                              else
                              {
                                 this.SelectParent(item);
                              }
                           }
                        }

                        e.Use();
                        break;

                     default:
                        Debug.Log(e.type + ": " + e.keyCode + ", MODIFIERS: " + e.modifiers + "\n");
                        break;
                  }
               }
               else if (e.modifiers == EventModifiers.Shift)
               {
            //      switch (e.keyCode)
            //      {
            //         case KeyCode.Tab:
            //            // Move focus to search control (if there is one)
            //            Debug.Log("SHIFT KEY: " + e.keyCode.ToString() + "\n");
            //            break;
            //      }
               }
               else if (e.modifiers == EventModifiers.Alt)
               {
            //      switch (e.keyCode)
            //      {
            //         case KeyCode.Return:
            //         case KeyCode.KeypadEnter:
            //            // Action performed on KeyUp
            //            e.Use();
            //            break;
            //      }
               }
               else if ((e.modifiers & (EventModifiers.Control | EventModifiers.FunctionKey)) == 0)
               {
                  Debug.Log("KEY: " + e.keyCode + ", MODIFIERS: " + e.modifiers + "\n");
               }
            }
            else if (e.type == EventType.KeyUp)
            {
               if (e.modifiers == 0)
               {
            //      switch (e.keyCode)
            //      {
            //         case KeyCode.Return:
            //         case KeyCode.KeypadEnter:
            //            // Duplicate the double-click behavior
            //            if (this.selectedItems.Count == 1)
            //            {
            //               if (this.selectedItems[0].HasVisibleChildren)
            //               {
            //                  this.selectedItems[0].Expanded = !this.selectedItems[0].Expanded;
            //               }
            //               else
            //               {
            //                  Debug.Log("ADDING PENDING EXECUTION\n");
            //                  this.PendingExecution = this.selectedItems[0];
            //               }
            //            }
                        
            //            e.Use();
            //            break;
            //      }
               }
               else if (e.modifiers == EventModifiers.Alt)
               {
            //      switch (e.keyCode)
            //      {
            //         case KeyCode.Return:
            //         case KeyCode.KeypadEnter:
            //            // Duplicate the middle-click behavior
            //            Debug.Log("ALT KEY: " + e.keyCode.ToString() + "\n");
            //            e.Use();
            //            break;
            //      }
               }
            }
         }

         // x
         //      AssetDatabase.GetCachedIcon(
         //      AssetDatabase.GetAssetPath(
         //
         //               _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
         //               {
         //   //               // Debug
         //   //               if (debugScript.svOffset != _scrollviewOffset)
         //   //               {
         //   //                  Debug.Log("Offset delta: " + (_scrollviewOffset.y - debugScript.svOffset.y).ToString() + ", Event: " + Event.current.type.ToString() + "\n");
         //   //               }
         //   //               _debugScript.svOffset = _scrollviewOffset;
         //   
         //   
         //                  // Commonly used variables
         //                  List<string> keylist = new List<string>();
         //                  keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
         //                  string[] keys = keylist.ToArray();
         //   
         //                  string scriptName = string.Empty;
         //                  int listItem_count = 0;
         //                  int listItem_yMin = 0;
         //                  int listItem_yMax = 0;
         //                  bool isListRowEven = false;
         //   
         //   
         //                  // Apply the filter and determine how many items will be drawn.
         //                  //
         //                  foreach (string scriptFileName in keys)
         //                  {
         //                     scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);
         //   
         //                     if (scriptName != _currentScriptName                                 // is not the loaded script
         //                         && (String.IsNullOrEmpty(_panelFilterText)                       // there is no filter text
         //                             || scriptName.ToLower().Contains(_panelFilterText.ToLower()) // or the filter text matches the scriptName
         //                            )
         //                        )
         //                     {
         //                        listItem_count++;
         //                     }
         //                  }
         //   
         //                  // Draw the padding box to establish the row width (excluding scrollbar)
         //                  // and force the scrollview content height
         //                  //
         //                  GUIStyle padding = new GUIStyle(GUIStyle.none);
         //                  padding.stretchWidth = true;
         //   //               padding.margin = new RectOffset();
         //   
         //                  GUILayout.Box(string.Empty, padding, GUILayout.Height(ROW_HEIGHT * listItem_count));
         //                  if (Event.current.type == EventType.Repaint)
         //                  {
         //                     _previousRowWidth = GUILayoutUtility.GetLastRect().width;
         //                  }
         //   
         //   
         //                  // Prepare to draw each row of the filtered list
         //                  //
         //                  Rect rowRect = new Rect(0, 0, _previousRowWidth, ROW_HEIGHT);
         //                  listItem_count = 0;
         //   
         //                  // The following button rect are initialized in this specific
         //                  // order, because later initializations refer to earlier ones.
         //                  Rect rectLoadButton = new Rect(_previousRowWidth - _widthButtonLoad - BUTTON_PADDING, 1, _widthButtonLoad, BUTTON_HEIGHT);
         //                  Rect rectSourceButton = new Rect(rectLoadButton.x - _widthButtonSource, 1, _widthButtonSource, BUTTON_HEIGHT);
         //                  Rect rectLabelButton = new Rect(BUTTON_PADDING, 1, _previousRowWidth - _widthButtonSource - _widthButtonLoad - (BUTTON_PADDING * 3), ROW_HEIGHT);
         //   
         //                  foreach (string scriptFileName in keys)
         //                  {
         //                     scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);
         //                     listItem_yMin = ROW_HEIGHT * listItem_count;
         //                     listItem_yMax = listItem_yMin + ROW_HEIGHT;
         //   
         //                     if (scriptName != _currentScriptName                                 // is not the loaded script
         //                         && (String.IsNullOrEmpty(_panelFilterText)                       // there is no filter text
         //                             || scriptName.ToLower().Contains(_panelFilterText.ToLower()) // or the filter text matches the scriptName
         //                            )
         //                        )
         //                     {
         //                        if (_scrollviewOffset.y <= listItem_yMax)
         //                        {
         //                           // draw
         //                           if (_scrollviewOffset.y + _scrollviewRect.height > listItem_yMin)
         //                           {
         //   //                           _mListData_count++;
         //   //                           _mListData_height = listItem_yMax - 0 - _tListData_height;
         //   
         //                              //
         //                              // draw the row normally
         //                              //
         //   
         //                              // the script path
         //                              string path = null;
         //   
         //                              // Draw the row background
         //                              if (isListRowEven && Event.current.type == EventType.Repaint)
         //                              {
         //                                 uScriptGUIStyle.listRow.Draw(rowRect, false, false, true, false);
         //                              }
         //   
         //                              // uScript Label
         //                              scriptSceneName = "None";
         //                              if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].SceneName))
         //                              {
         //                                 scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].SceneName;
         //                              }
         //   
         //                              if (Event.current.type == EventType.Layout)
         //                              {
         //                                 scriptName = string.Empty;
         //                              }
         //   
         //                              // prepare for double-click
         //                              bool wasClicked = false;
         //                              if (_clickedControl == scriptName)
         //                              {
         //                                 if ((EditorApplication.timeSinceStartup - _clickTime) < _doubleClickTime)
         //                                 {
         //                                    wasClicked = true;
         //                                    uScript.RequestRepaint();
         //                                 }
         //                              }
         //   
         //                              // Source button
         //                              if (_uScriptInstance.IsStale(scriptName))
         //                              {
         //                                 contentSourceButton = uScriptGUIContent.buttonScriptSourceStale;
         //                                 GUI.backgroundColor = UnityEngine.Color.red;
         //                              }
         //                              else if (_uScriptInstance.HasDebugCode(scriptName))
         //                              {
         //                                 contentSourceButton = uScriptGUIContent.buttonScriptSourceDebug;
         //                                 GUI.backgroundColor = UnityEngine.Color.yellow;
         //                              }
         //                              else
         //                              {
         //                                 contentSourceButton = uScriptGUIContent.buttonScriptSource;
         //                              }
         //   
         //                              if (GUI.Button(rectSourceButton, contentSourceButton, this.styleMiniButtonLeft))
         //                              {
         //                                 uScriptGUI.PingGeneratedScript(scriptName);
         //                              }
         //                              GUI.backgroundColor = UnityEngine.Color.white;
         //   
         //                              // Load button
         //                              if (GUI.Button(rectLoadButton, uScriptGUIContent.buttonScriptLoad, this.styleMiniButtonRight))
         //                              {
         //                                 if ( null == path ) path = _uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);
         //   
         //                                 if (false == string.IsNullOrEmpty(path))
         //                                 {
         //                                    _uScriptInstance.OpenScript(path);
         //                                 }
         //                              }
         //   
         //                              // Script Label buton
         //                              if (GUI.Button(rectLabelButton, scriptName + (scriptSceneName == "None" ? string.Empty : " (" + scriptSceneName + ")"), (wasClicked ? this.styleScriptListBold : this.styleScriptListNormal)))
         //                              {
         //                                 path = _uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);
         //   
         //                                 if (wasClicked)
         //                                 {
         //                                    // double-click
         //                                    _clickTime = EditorApplication.timeSinceStartup - _clickTime; // prevents multiple double-clicks
         //                                    if (false == string.IsNullOrEmpty(path))
         //                                    {
         //                                       _uScriptInstance.OpenScript(path);
         //                                    }
         //                                 }
         //                                 else
         //                                 {
         //                                    // single-click
         //                                    _clickTime = EditorApplication.timeSinceStartup;
         //                                    _clickedControl = scriptName;
         //                                 }
         //                              }
         //                           }
         //   //                        else
         //   //                        {
         //   //                           // skip the items below the viewable area
         //   //                           _bListData_count++;
         //   //                           _bListData_height = listItem_yMax - 0 - _tListData_height - _mListData_height;
         //   //                        }
         //                        }
         //   //                     else
         //   //                     {
         //   //                        // skip the items above the viewable area
         //   //                        _tListData_count++;
         //   //                        _tListData_height = listItem_yMax - 0;
         //   //                     }
         //   
         //   
         //   //                     // Debug
         //   //                     _debugScript.Top = new Vector2(_tListData_count, _tListData_height);
         //   //                     _debugScript.Middle = new Vector2(_mListData_count, _mListData_height);
         //   //                     _debugScript.Bottom = new Vector2(_bListData_count, _bListData_height);
         //   
         //   
         //                        // Prepare for the next row
         //                        listItem_count++;
         //                        isListRowEven = !isListRowEven;
         //                        rowRect.y += ROW_HEIGHT;
         //   
         //                        rectLabelButton.y += ROW_HEIGHT;
         //                        rectLoadButton.y += ROW_HEIGHT;
         //                        rectSourceButton.y += ROW_HEIGHT;
         //                     }
         //                  }
         //   
         //                  // Display a message if there were no matches
         //                  if (listItem_count == 0)
         //                  {
         //                     GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
         //                     style.alignment = TextAnchor.MiddleCenter;
         //                     GUILayout.Label("The search found no matches!", style);
         //                  }
         //               }
         //               EditorGUILayout.EndScrollView();
         //   
         //               if (Event.current.type == EventType.Repaint)
         //               {
         //                  _scrollviewRect = GUILayoutUtility.GetLastRect();
         //               }
         //   
         //   //            _isMouseOverScrollview = _scrollviewRect.Contains(Event.current.mousePosition);
      }

      public void CollapseAllFolders()
      {
         foreach (var item in this.folderItems)
         {
            item.Value.Expanded = false;
         }

         this.SaveFolderStates();

         this.shouldRebuildVisibleList = true;
      }

      public void CollapseFolder(ListViewItem item)
      {
         if (this.IsFolder(item) == false)
         {
            uScriptDebug.Log("The specified ListViewItem does not appear to be a folder: " + item.ItemName, uScriptDebug.Type.Error);
            return;
         }

         if (this.folderItems[item.ItemPath].Expanded == false)
         {
            return;  // The folder is already collapsed, so abort
         }

         this.folderItems[item.ItemPath].Expanded = false;
         this.SaveFolderStates();

         this.shouldRebuildVisibleList = true;
      }

      public void ExpandAllFolders()
      {
         foreach (var item in this.folderItems)
         {
            item.Value.Expanded = true;
         }

         this.SaveFolderStates();

         this.shouldRebuildVisibleList = true;
      }

      public void ExpandFolder(ListViewItem item)
      {
         if (this.IsFolder(item) == false)
         {
            uScriptDebug.Log("The specified ListViewItem does not appear to be a folder: " + item.ItemPath, uScriptDebug.Type.Error);
            return;
         }

         if (this.folderItems[item.ItemPath].Expanded)
         {
            return;  // The folder is already expanded, so abort
         }

         this.folderItems[item.ItemPath].Expanded = true;
         this.SaveFolderStates();

         this.shouldRebuildVisibleList = true;
      }

      public void ToggleFolder(ListViewItem item)
      {
         if (this.IsFolder(item) == false)
         {
            uScriptDebug.Log("The specified ListViewItem does not appear to be a folder: " + item.ItemPath, uScriptDebug.Type.Error);
            return;
         }

         this.folderItems[item.ItemPath].Expanded = !this.folderItems[item.ItemPath].Expanded;
         this.SaveFolderStates();

         this.shouldRebuildVisibleList = true;
      }

      public bool IsFolder(ListViewItem item)
      {
         return this.folderItems.ContainsKey(item.ItemPath);
      }

      public bool IsFolderExpanded(ListViewItem item)
      {
         if (this.IsFolder(item))
         {
            return this.folderItems[item.ItemPath].Expanded;
         }

         uScriptDebug.Log("The specified ListViewItem does not appear to be a folder: " + item.ItemPath, uScriptDebug.Type.Error);
         return false;
      }

      public void FilterItems(string match)
      {
         // TODO: Delegate the work, passing the seedItems
         // TODO: Should the filterText apply to SceneName as well?

         // TODO: IsFiltered should be used to mean that the item was included by the search filter.
         // TODO: IsVisible should mean just that. The item is visible in the list (taking foldouts into account. Truly visible.

         // TODO: FilterItem() > BuildFilteredList() > create filteredItems, clear visibleItems > create visibleItems > draw visibleItems
         // TODO: All keyboard navigation commands should use the visibleItems list, since that accurately represents the current foldout states
         // TODO: When moving selection up, down, or collapsing or expanding (left or right), ...
         // TODO: If a selected item is under a collapsed folder, deselect it

         // Filter the list, hiding every item that does not contain the user-specified filter text
         match = match.ToLower();

         foreach (var item in this.seedItems)
         {
            item.IsVisible = false;
            item.IsFiltered = string.IsNullOrEmpty(match)
                              || item.ItemPath.Substring(0, item.ItemPath.Length - 8).ToLower().Contains(match);
         }

         this.BuildFilteredList();
      }

      public void FrameItem(ListViewItem item)
      {
         var offset = this.ListOffset;

         if (offset.y > item.Position.yMin)
         {
            offset.y = item.Position.yMin;
         }
         else if (offset.y + this.ListPosition.height < item.Position.yMax)
         {
            offset.y += item.Position.yMax - (offset.y + this.ListPosition.height);
         }

         this.ListOffset = offset;
      }

      public void HandleMouseInput(ListViewItem item)
      {
         var e = Event.current;

         if (e.modifiers == 0)
         {
            if (!item.Selected || this.SelectedItems.Length > 1)
            {
               this.ClickNewSelection(item);
            }
            else if (item.ClickCount == 2)
            {
               if (item.HasChildren)
               {
                  this.ToggleFolder(item);
               }
               else
               {
                  uScript.Instance.OpenScript(uScriptBackgroundProcess.GraphInfoList[item.ItemName].GraphPath);
               }
            }
         }
         else if ((e.modifiers == EventModifiers.Control && Application.platform == RuntimePlatform.WindowsEditor)
                  || (e.modifiers == EventModifiers.Command && Application.platform == RuntimePlatform.OSXEditor))
         {
            if (!this.MultiSelectEnabled && !item.Selected)
            {
               this.ClickNewSelection(item);
            }
            else
            {
               this.ClickToggleSelection(item);
            }
         }
         else if (e.modifiers == EventModifiers.Shift)
         {
            if (this.MultiSelectEnabled)
            {
               this.ClickRangeSelection(item);
            }
            else
            {
               this.ClickNewSelection(item);
            }
         }

         e.Use();
      }

      public ListViewItem SelectItem(int index)
      {
         var item = this.GetVisibleItem(index);
         if (item == null)
         {
            uScriptDebug.Log("No item was found at the specified list index (" + index.ToString(CultureInfo.InvariantCulture) + ").", uScriptDebug.Type.Error);
            return null;
         }
         
         this.SelectItem(item);
         return item;
      }
      
      public void SelectItem(ListViewItem item)
      {
         //Debug.Log("SelectItem: " + item.ItemName + "\n");
         item.Selected = true;
         this.selectedItems.Add(item);
      }
      
      public void DeselectItem(ListViewItem item)
      {
         item.Selected = false;
         this.selectedItems.Remove(item);
      }
      
      public void SelectFirst()
      {
         if (this.visibleItems.Count == 0)
         {
            return;
         }

         this.SelectNone();

         var item = this.visibleItems.First();
         this.SelectItem(item);
         this.FrameItem(item);
      }
      
      public void SelectLast()
      {
         if (this.visibleItems.Count == 0)
         {
            return;
         }

         this.SelectNone();

         var item = this.visibleItems.Last();
         this.SelectItem(item);
         this.FrameItem(item);
      }
      
      public void SelectParent(ListViewItem item)
      {
         if (item.Parent == null)
         {
            return;
         }

         this.SelectNone();
         this.SelectItem(item.Parent);
         this.FrameItem(item.Parent);
      }
      
      public void SelectNext()
      {
         if (this.selectedItems.Count == 0)
         {
            this.SelectFirst();
            return;
         }

         var index = this.selectedItems.Last().Row + 1;
         var lastIndex = this.visibleItems.Count - 1;
         if (index > lastIndex)
         {
            index = lastIndex;
         }
            
         this.SelectNone();
         this.FrameItem(this.SelectItem(index));
      }
      
      public void SelectPrevious()
      {
         if (this.selectedItems.Count == 0)
         {
            this.SelectFirst();
            return;
         }

         var index = this.selectedItems.Last().Row - 1;
         if (index < 0)
         {
            index = 0;
         }
            
         this.SelectNone();
         this.FrameItem(this.SelectItem(index));
      }

      public void SelectAll()
      {
         Debug.Log("SelectAll()\n");
      }
      
      public void SelectNone()
      {
         for (var i = this.selectedItems.Count - 1; i >= 0; i--)
         {
            this.DeselectItem(this.selectedItems[i]);
         }
         
         // TODO: If needed, remove focus from the ListView.
         //       This might not be needed, as there are no items selected,
         //       and there will be no way to visibly determine focus.
         this.EditorWindow.Repaint();
      }
      
      public void SelectPageDown()
      {
         if (this.selectedItems.Count == 0)
         {
            this.SelectFirst();
            return;
         }

         // Current item index
         var item = this.selectedItems.Last();

         // Locate the next item located approximately a full ListView height below the current item
         var nextItem = this.visibleItems.Last();
         for (var index = item.Row + 1; index < this.visibleItems.Count; index++)
         {
            // Has the search gone too far?
            if (this.visibleItems[index].Position.yMin > item.Position.yMin + this.ListPosition.height)
            {
               nextItem = this.visibleItems[index - 1];
               break;
            }
         }

         this.SelectNone();
         this.SelectItem(nextItem);
         this.FrameItem(nextItem);
      }
      
      public void SelectPageUp()
      {
         if (this.selectedItems.Count == 0)
         {
            this.SelectFirst();
            return;
         }

         // Current item index
         var item = this.selectedItems.Last();

         // Locate the next item located approximately a full ListView height below the current item
         var nextItem = this.visibleItems.First();
         for (var index = item.Row - 1; index >= 0; index--)
         {
            // Has the search gone too far?
            if (this.visibleItems[index].Position.yMin < item.Position.yMax - this.ListPosition.height)
            {
               nextItem = this.visibleItems[index];
               break;
            }
         }

         this.SelectNone();
         this.SelectItem(nextItem);
         this.FrameItem(nextItem);
      }

      private void SaveFolderStates()
      {
         var expandedFolders = (from item in this.folderItems where item.Value.Expanded select item.Key).ToList();
         var serialized = string.Join("\n", expandedFolders.ToArray());

         uScript.Preferences.GraphListFolderStates = serialized;
         uScript.Preferences.Save();
      }

      private void RestoreFolderStates()
      {
         var serialized = uScript.Preferences.GraphListFolderStates;
         var expandedFolders = serialized.Split('\n');

         foreach (var folder in expandedFolders.Where(key => this.folderItems.ContainsKey(key)))
         {
            this.folderItems[folder].Expanded = true;
         }
      }

      public void DrawContextMenu(ListViewItem item)
      {
         // If the item is not in the current selection,
         // replace the selection with the new item.
         if (this.selectedItems.Contains(item) == false)
         {
            this.ClickNewSelection(item);
         }
         
         // TODO: Should we do some type of sorting?  The items appear
         //       in the order they were selected, otherwise.
         var genericMenu = new GenericMenu();
         
         // Add folder expand and collapse options, if needed
         var expandCount = 0;
         var collapseCount = 0;
         
         var files = new List<ListViewItem>();
         ContextMenuCallbackData data;
         
         foreach (var currItem in this.selectedItems)
         {
            if (currItem.HasVisibleChildren)
            {
               if (this.IsFolderExpanded(currItem))
               {
                  collapseCount++;
               }
               else
               {
                  expandCount++;
               }
            }
            else
            {
               files.Add(currItem);
            }
         }
         
         ////         Expand,
         ////         ExpandChildren,
         ////         ExpandAll,
         ////         Collapse,
         ////         CollapseChildren,
         ////         CollapseAll,
         
         data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Expand, this.selectedItems.ToArray());
         genericMenu.AddItem(new GUIContent("Test/Test/"), false, this.ContextMenuCallback, data);
         
         data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Expand, this.selectedItems.ToArray());
         genericMenu.AddItem(new GUIContent("Test/Test/Item1"), false, this.ContextMenuCallback, data);
         
         data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Expand, this.selectedItems.ToArray());
         genericMenu.AddItem(new GUIContent("Test/Test/Item2"), false, this.ContextMenuCallback, data);
         
         if (expandCount > 0)
         {
            data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Expand, this.selectedItems.ToArray());
            genericMenu.AddItem(new GUIContent(expandCount > 1 ? "Expand Folders" : "Expand Folder"), false, this.ContextMenuCallback, data);
         }
         
         if (collapseCount > 0)
         {
            data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Collapse, this.selectedItems.ToArray());
            genericMenu.AddItem(new GUIContent(collapseCount > 1 ? "Collapse Folders" : "Collapse Folder"), false, this.ContextMenuCallback, data);
         }
         
         // Add file-related options
         if (files.Count > 0)
         {
            if ((expandCount + collapseCount) > 0)
            {
               genericMenu.AddSeparator(string.Empty);
            }
            
            ////         Load,
            ////         PingSource,
            ////         SaveQuick,
            ////         SaveDebug,
            ////         SaveRelease,
            ////         Clean,
            ////         CleanChildren,
            ////         CleanAll,
            ////         Rebuild,
            ////         RebulidChildren,
            ////         RebulidAll
            
            if (files.Count == 1)
            {
               data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Load, files[0]);
               genericMenu.AddItem(new GUIContent("Load \"" + files[0].ItemName + "\""), false, this.ContextMenuCallback, data);
               
               //data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.PingSource, files[0]);
               //genericMenu.AddItem(new GUIContent("Ping Source \"" + files[0].text + "\""), false, this.ContextMenuCallback, data);

               genericMenu.AddDisabledItem(new GUIContent("Ping Source"));
            }
            else
            {
               foreach (var listViewItem in files)
               {
                  data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Load, listViewItem);
                  genericMenu.AddItem(new GUIContent(string.Format("Load/\"{0}\"", listViewItem.ItemName)), false, this.ContextMenuCallback, data);
               }
            }
         }
         
         genericMenu.ShowAsContext();
      }

      private void AddHierarchyChild(ListViewItem parent, ListViewItem child)
      {
         if (parent != null)
         {
            if (parent.Children == null)
            {
               parent.Children = new List<ListViewItem>();
            }

            child.Parent = parent;
            child.Depth = parent.Depth + 1;
            parent.Children.Add(child);
         }

         this.filteredItems.Add(child);
      }

      private void AutoSizeColumns(int availableWidth)
      {
         // There are three types of columns, which behave differently when being autosized.
         //
         // 1. Fixed - The most rigid, with a fixed, non-changable width.
         // 2. Fluid - The most flexable. They have minWith and maxWidth properties, but will expand to fill any extra
         //       space. The right-most Fluid column does not observe its maxWidth property, and instead expands to fill
         //       the remaining space, regardless of size.
         // 3. Resizable - The most complicated. The user specifies the desired with within the available range, but the
         //       colum is autosized (shrunk) if needed. This would occur when all fixed and fluid columns are at their
         //       minimum widths and the combined desired widths of the Custom columns exceeds the avilable space.

         // cycle through columns right to left
         //    for each fixed width column, subtract its width from the total available width, then remove from collection
         //    total all fluid column minWidths
         //    total all resize column minWidths
         //    total all resize column widths
         var columns = new List<ListViewColumn>(this.Columns);
         var minWidthFluidColumns = 0;
         var minWidthCustomColumns = 0;
         var widthFixedColumns = 0;
         //var widthFluidColumns = 0;
         var widthCustomColumns = 0;

         for (var columnIndex = columns.Count - 1; columnIndex >= 0; columnIndex--)
         {
            var column = columns[columnIndex];

            if (column.IsFixed)
            {
               widthFixedColumns += (int)column.Width;
               columns.RemoveAt(columnIndex);
            }
            else if (column.IsFluid)
            {
               minWidthFluidColumns += column.MinWidth;
               column.Width = 0;
            }
            else
            {
               minWidthCustomColumns += column.MinWidth;
               widthCustomColumns += (int)column.Width;
            }
         }

         //Debug.Log(
         //   "AVAILABLE WIDTH: " + availableWidth + "\n widthFixedColumns: " + widthFixedColumns
         //   + "\n minWidthFluidColumns: " + minWidthFluidColumns + "\n widthFluidColumns: " + widthFluidColumns
         //   + "\n minWidthCustomColumns: " + minWidthCustomColumns + "\n widthCustomColumns: " + widthCustomColumns);

         // Is there enough space for the minimum column sizes?
         if (availableWidth < widthFixedColumns + minWidthFluidColumns + minWidthCustomColumns)
         {
            // Houston, we have a problem. The combined minWidth of all columns is greater than the available space.
            // TODO: Either break the rightAlign or start dropping right-most columns
            //uScriptDebug.Log("The ListView columns do not fit in the available space.", uScriptDebug.Type.Error);
            Debug.LogError("The ListView columns do not fit in the available space.");
         }

         //Debug.Log(string.Format("COLUMN INFO: Total minWidths: {0}, availableWidth: {1}\n", widthFixedColumns + minWidthFluidColumns + minWidthCustomColumns, availableWidth));

         // Is there enough space for the full Custom column widths?
         if (availableWidth < widthFixedColumns + minWidthFluidColumns + widthCustomColumns)
         {
            //Debug.Log("FORCE SHRINK CUSTOM COLUMNS\n");
            //    we need to use the minWidth for the fluid columns
            //    we need to force shrink resize columns as well
            //       get remaining of (availSpace - minWidthFluidColumns - widthFixedColumns - widthCustomColumns)
            //       cycle left to right
            //          apply as much remaining space as you can so that the column reaches the user-specified Width
            //          subtract the amount used from remaining
            //          if nothing is remaining, we're done
            //          this should have the left-most columns closest to the desired size, while shrinking the right-most columns to their MinWidth
         }
         else
         {
            // The user-specified custom column widths will be used along with the fixed width columns
            columns.RemoveAll(item => item.IsFluid == false);

            foreach (var column in columns)
            {
               column.Width = column.MinWidth;
               //Debug.Log("COLUMN " + column.ID + " is initialized to " + column.Width + "px\n");
            }

            // The remaining free space should be split among the fluid columns
            var remaining = availableWidth - widthCustomColumns - widthFixedColumns - minWidthFluidColumns;

            if (remaining > 0)
            {
               // Sort fluid columns by MaxWidth, largest first
               columns.Sort((x, y) => y.MaxWidth.CompareTo(x.MaxWidth));

               // Distribute the amount over the fluid columns until MaxWidths are hit
               while (remaining > 0)
               {
                  //Debug.Log("REMAINING: " + remaining + "px\n");

                  var portion = remaining / columns.Count;
                  var lastDiff = columns.Last().MaxWidth - columns.Last().MinWidth;

                  if (columns.Count == 1)
                  {
                     var column = columns[0];

                        //Debug.Log("LAST COLUMN is getting " + portion + ", even though it can handle " + lastDiff + "\n");
                        column.Width += remaining;
                        //columns.RemoveAt(columns.Count - 1);
                        remaining = 0;
                  }
                  else if (portion < lastDiff)
                  {
                     //Debug.Log("SPREADING PORTION of " + portion + "px\n");
                     remaining -= portion * columns.Count;

                     foreach (var listViewColumn in columns)
                     {
                        listViewColumn.Width += portion;
                        //Debug.Log("COLUMN " + listViewColumn.ID + " is now " + listViewColumn.Width + "px\n");
                     }
                  }
                  else
                  {
                     //Debug.Log("PORTION " + portion + " is more than " + lastDiff + "\n");
                     columns.Last().Width += lastDiff;
                     columns.RemoveAt(columns.Count - 1);
                     remaining -= lastDiff;
                  }
               }
            }
         }
      }

      private void BuildFilteredList()
      {
         this.filteredItems.Clear();

         this.shouldRebuildVisibleList = true;

         foreach (var item in this.seedItems.Where(item => item.IsFiltered))
         {
            ListViewItem parent = null;
            var path = string.Empty;
            var folders = new List<string>(item.ItemPath.Split('/'));

            while (folders.Count > 1)
            {
               var folder = folders[0];
               path += folder + "/";
               folders.RemoveAt(0);

               // TODO: Ideally, the key would be just "path"

               if (this.folderItems.ContainsKey(path + folder))
               {
                  parent = this.folderItems[path + folder].Item;

                  if (this.filteredItems.Contains(parent) == false)
                  {
                     this.filteredItems.Add(parent);
                  }
               }
               else
               {
                  var child = (ListViewItem)Activator.CreateInstance(this.ListItemType, this, path + folder);

                  this.AddHierarchyChild(parent, child);

                  this.folderItems.Add(path + folder, new FolderInfo(child));

                  parent = child;
               }
            }

            this.AddHierarchyChild(parent, item);
         }

         this.RestoreFolderStates();
      }

      private void BuildVisibleList()
      {
         this.visibleItems.Clear();
         this.shouldRebuildVisibleList = false;
         this.totalContentSize = new Rect();

         var skipPath = string.Empty;

         foreach (var item in this.filteredItems)
         {
            if (string.IsNullOrEmpty(skipPath) == false && item.ItemPath.StartsWith(skipPath))
            {
               continue;
            }

            if (item.Children != null && this.IsFolderExpanded(item) == false)
            {
               skipPath = item.ItemPath.Substring(0, item.ItemPath.LastIndexOf("/", StringComparison.Ordinal));
            }

            item.IsVisible = true;

            item.Position = new Rect(0, this.totalContentSize.height, this.totalContentSize.width, item.Height);
            this.totalContentSize.height += item.Height;

            this.visibleItems.Add(item);
         }
      }

      //private int CountTotalVisibleRows(IEnumerable<ListViewItem> items)
      //{
      //   var count = 0;
        
      //   foreach (var listViewItem in items)
      //   {
      //      count++;

      //      if (listViewItem.Children != null && this.IsFolderExpanded(listViewItem))
      //      {
      //         count += this.CountTotalVisibleRows(listViewItem.Children);
      //      }
      //   }
        
      //   return count;
      //}

      private void DrawColumnHeaders()
      {
         if (this.Columns == null)
         {
            return;
         }

         Event e = Event.current;

         var headerPosition = EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(false));
         {
            var scrollPosition = new Vector2(this.ListOffset.x, 0);
            EditorGUILayout.BeginScrollView(scrollPosition, false, false, GUIStyle.none, GUIStyle.none, "scrollview", GUILayout.ExpandHeight(false));
            {
               this.TotalColumnWidth = 0;
               foreach (var column in this.Columns)
               {
                  this.TotalColumnWidth += (int)column.Width;
               }

               // The base column background claims space in the GUILayout system
               GUILayout.Box(GUIContent.none, Style.ColumnHeader, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true), GUILayout.MinWidth(this.TotalColumnWidth));

               if (e.type != EventType.Layout && e.type != EventType.Used && e.type != EventType.Ignore)
               {
                  this.HeaderPosition = headerPosition;

                  var rectColumnHeader = new Rect(0, 0, headerPosition.width, headerPosition.height);

                  this.dragHandles.Clear();

                  if (this.ForceHorizontalColumnFit)
                  {
                     var width = (int)rectColumnHeader.width;
                     if (this.IsVerticalScrollbarVisible)
                     {
                        width -= (int)GUI.skin.verticalScrollbar.fixedWidth;
                     }

                     this.AutoSizeColumns(width);
                  }

                  // Handle column resizing
                  foreach (ListViewColumn column in this.Columns)
                  {
                     // Allocate space for the current column and prepare for the next
                     rectColumnHeader.width = column.Width;
                     rectColumnHeader.x = rectColumnHeader.xMax;

                     if (column.IsResizeable == false)
                     {
                        continue;
                     }

                     // Set the area for the resize grab handle

                     // If a column is being dragged, only create a resize handle for it,
                     //    otherwise, create a handle for all.
                     if (this.draggedColumn == null || this.draggedColumn == column)
                     {
                        Rect rectHandle = new Rect(rectColumnHeader);
                        rectHandle.x -= 2;
                        rectHandle.width = 5;

                        // If a column is being dragged, make it's handle grow in the direction of the drag
                        //    to avoid the mouse flicker.
                        if (this.draggedColumn != null)
                        {
                           // TODO: make it so that the cursor doesn't change until the column
                           // can actually be resized.
                           if (column.Width > column.MinWidth)
                           {
                              rectHandle.xMin -= 20;
                           }

                           if (column.Width < column.MaxWidth)
                           {
                              rectHandle.xMax += 20;
                           }
////                           rectHandle.x -= 10;
////                           rectHandle.width += 20;

////                           if (e.delta.x > 0)
////                           {
////                              Debug.Log("+".NewLine());
////                              rectHandle.xMax += 20;
////                           }
////                           else if (e.delta.x < 0)
////                           {
////                              Debug.Log("-".NewLine());
////                              rectHandle.xMin -= 20;
////                           }
                        }

                        this.dragHandles.Add(rectHandle);

                        EditorGUIUtility.AddCursorRect(rectHandle, MouseCursor.ResizeHorizontal);
   
                        if (e.type == EventType.MouseDown && rectHandle.Contains(e.mousePosition))
                        {
                           // Begin drag
                           this.draggedColumn = column;
                           this.dragInitialMouse = e.mousePosition;
                           this.dragInitialSize = new Vector2(column.Width, 0);
                           this.EditorWindow.Repaint();
                           e.Use();
                        }
                        else if (e.type == EventType.MouseUp && this.draggedColumn != null)
                        {
                           // End drag
                           //Debug.Log("END DRAG".NewLine());
                           this.draggedColumn = null;
                           this.EditorWindow.Repaint();
////                           e.Use();
                        }
                        else if (e.type == EventType.MouseDrag && this.draggedColumn != null && this.draggedColumn == column)
                        {
                           // Handle drag
                           if ((e.delta.x > 0 && e.mousePosition.x > rectHandle.x)
                              || (e.delta.x < 0 && e.mousePosition.x < rectHandle.xMax))
                           {
                              Vector2 dragDelta = e.mousePosition - this.dragInitialMouse;
                              column.Width = Math.Max(column.MinWidth, Math.Min(column.MaxWidth, this.dragInitialSize.x + dragDelta.x));
                              this.EditorWindow.Repaint();
                           }

                           e.Use();
                        }
                     }
                  }

                  // Draw the headers now
                  rectColumnHeader = new Rect(0, 0, headerPosition.width, headerPosition.height);

                  foreach (ListViewColumn column in this.Columns)
                  {
                     rectColumnHeader.width = column.Width;

                     if (this.SortByColumn)
                     {
                        bool isSelectedColumn = column.IsSelectable && this.SortColumn == column;

                        var columnStyle = isSelectedColumn == false
                                             ? Style.ColumnHeaderButton
                                             : column.IsSortDirectionFixed
                                                  ? Style.ColumnHeaderSelected
                                                  : column.IsSortDescending
                                                       ? Style.ColumnHeaderDescending
                                                       : Style.ColumnHeaderAscending;

                        if (column.IsSelectable == false || (isSelectedColumn && column.IsSortDirectionFixed))
                        {
                           GUI.Label(rectColumnHeader, column.Content.text, columnStyle);
                        }
                        else
                        {
                           if (GUI.Button(rectColumnHeader, column.Content.text, columnStyle))
                           {
                              if (isSelectedColumn && column.IsSortDirectionFixed == false)
                              {
                                 column.IsSortDescending = !column.IsSortDescending;
                                 ////                              Debug.Log("SELECTED COLUMN HEADER CLICKED: " + column.ItemName + "\n\tRE-SORT");
                              }
                              else
                              {
                                 this.SortColumn = column;
                                 ////Debug.Log("NEW COLUMN HEADER CLICKED: " + column.ItemName + "\n\tRE-SORT");
                              }
                           }
                        }
                     }
                     else
                     {
                        GUI.Label(rectColumnHeader, column.Content, Style.ColumnHeader);
                     }

                     rectColumnHeader.x = rectColumnHeader.xMax;
                  }

                  // TODO: Remove this section - Temporary handle drawing
//                  foreach (var rect in this.dragHandles)
//                  {
//                     // Set the area for the resize grab handle
//                     var r = new Rect(rect);
//////                     r.yMin += 10;
//////                     GUI.Box(r, GUIContent.none);
//////
//////                     Debug.DrawLine(new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), Color.black);
//////                     GUI.Box(r, GUIContent.none, uScriptGUIStyle.debugBox);
//                     uScriptGUI.DebugBox(r, Color.red);
//                  }
               }
            }

            EditorGUILayout.EndScrollView();

            // If the vertical scrollbar is visible, display piece above it
            if (this.IsVerticalScrollbarVisible)
            {
               GUILayout.Box(GUIContent.none, Style.ColumnHeader, GUILayout.Width(GUI.skin.verticalScrollbar.fixedWidth - 1));
            }
         }

         EditorGUILayout.EndHorizontal();
      }

////      private void DrawItem(ListViewItem item)
////      {
////         Event e = Event.current;
////         bool isRepaint = e.type == EventType.Repaint;

////         int indentWidth = Style.Foldout.padding.left;
//////         item.Height = (int)Style.Label.fixedHeight;

////         item.rowRect = new Rect(0, item.row * item.Height, this.MinRowWidth, item.Height);
////         Rect rect = item.rowRect;

////         bool shouldDrawRow = (this.ItemRow >= this.FirstVisibleRow) && (this.ItemRow <= this.LastVisibleRow);

////         if (shouldDrawRow)
////         {
////            if (isRepaint)
////            {
////               // Draw row background
////               GUIStyle rowStyle = (item.selected == true)
////                  ? Style.RowSelected
////                  : (this.ItemRow % 2 == 0)
////                     ? Style.RowEven
////                     : Style.RowOdd;

////               // isHover, isActive, on, hasKeyboardFocus
////               //    GREY (on)
////               //    BLUE (on, hasKeyboardFocus)
////               //    RING (isHover, isActive)
////               rowStyle.Draw(item.rowRect, GUIContent.none, false, false, true, this.HasFocus);
////            }

////            int columnPadding = 2;

////            if (item.hasVisibleChildren)
////            {
////               // foldout toggle
////               rect.x = 2 + (item.depth * indentWidth);
////               rect.y--;
////               rect.width = indentWidth;
////               item.expanded = GUI.Toggle(rect, item.expanded, GUIContent.none, Style.Foldout);

////               rect.x = item.depth * indentWidth;
////               rect.y++;
////               rect.width = item.rowRect.width;

////               if (isRepaint)
////               {
////                  // icon
////                  Style.Icon.Draw(rect, this.content.IconFolder, false, false, false, false);
////                  rect.xMin += 16;

////                  // text
////                  Style.Label.Draw(rect, item.name, false, false, false, false);
////               }
////            }
////            else
////            {
////               if (isRepaint)
////               {
////                  rect = item.rowRect;

////                  // "Graph" Column
////                  rect.width = this.Columns[0].Width - columnPadding;
////                  rect.xMin = item.depth * indentWidth;

////                  // icon
////                  Style.Icon.Draw(rect, this.content.IconScript, false, false, false, false);
////                  rect.xMin += 16;

////                  // text
////                  Style.Label.Draw(rect, Ellipsis.Compact(item.name, Style.Label, rect, Ellipsis.Format.Middle), false, false, false, false);

////                  // "Scene" Column
////                  rect.x += rect.width + (columnPadding * 2);
////                  rect.width = this.Columns[1].Width - (columnPadding * 2);

////                  // filePathAndName
////                  Style.Label.Draw(rect, item.instanceID.ToString(), false, false, false, false);
////                  ////                     Style.label.Draw(rect, filePathAndName, false, false, false, false);
////                  ////                     Style.label.Draw(rect, guid.ToString(), false, false, false, false);

////                  // "State" Column
////                  rect.x += rect.width + (columnPadding * 2);
////                  rect.width = this.Columns[2].Width - (columnPadding * 2);

////                  // scriptStateIcon
////                  GUI.skin.label.Draw(rect, this.content.IconSourceRelease, false, false, false, false);
////               }
////            }
////         }

////         item.row = this.ItemRow++;

////         if (shouldDrawRow)
////         {
////            if (item.rowRect.Contains(e.mousePosition))
////            {
////               if (e.type == EventType.MouseDown)
////               {
////                  if (e.button == 0)
////                  {
////                     if (EditorGUI.actionKey && this.MultiSelectEnabled)
////                     {
////                        // (Control or Command) + Left-Click
////                        this.ClickToggleSelection(item);
////                        e.Use();
////                     }
////                     else if (e.modifiers == EventModifiers.Alt)
////                     {
////                        // (Alt or Option) + Left-Click
////                        Debug.Log("ALT LEFT-CLICK" + "\n");
////                        //// Ping source
////                        e.Use();
////                     }
////                     else if (e.modifiers != EventModifiers.Control)
////                     {
////                        // Left-Click
////                        if (e.clickCount == 1)
////                        {
////                           this.ClickNewSelection(item);
////                        }
////                        else if (e.clickCount == 2)
////                        {
////                           if (item.hasVisibleChildren)
////                           {
////                              item.expanded = !item.expanded;
////                              this.EditorWindow.Repaint();
////                           }
////                           else
////                           {
////                              Debug.Log("DOUBLE CLICK - OPEN FILE\n");
////                           }
////                        }

////                        e.Use();
////                     }
////                  }
////                  else if (e.button == 2)
////                  {
////                     // Middle-Click
////                     Debug.Log("MIDDLE-CLICK" + "\n");
////                     //// Ping source
////                     e.Use();
////                  }
////               }
////               else if (e.type == EventType.ContextClick)
////               {
////                  Debug.Log("CONTEXT CLICK\n" + "BUTTON: " + e.button.ToString() + ", MODIFIERS: " + e.modifiers.ToString());
////                  this.DrawContextMenu(item);
////                  e.Use();
////               }

////               // TODO: successive left and right clicks are combined in calculating the clickCount.
////               //       They should be separate. We should be able to quickly left click an item, and
////               //       then right click it to open the context menu.
////            }

////////            Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");
////////
////////               else
////////               {
////////                  this.EndNameEditing();
////////                  this.m_CurrentDragSelectionIDs = this.GetSelection(newHierarchyProperty, true);
////////                  GUIUtility.hotControl = controlID;
////////                  GUIUtility.keyboardControl = 0;
////////                  DragAndDropDelay stateObject = (DragAndDropDelay) GUIUtility.GetStateObject(typeof(DragAndDropDelay), controlID);
////////                  stateObject.mouseDownPosition = Event.current.mousePosition;
////////               }
////////               current.Use();
////////            }
////         }

////         if (item.hasVisibleChildren)
////         {
////            if (item.expanded)
////            {
////               foreach (ListViewItem child in item.children)
////               {
////////               child.Draw();
////                  this.DrawItem(child);
////               }
////            }
////            else if (shouldDrawRow && isRepaint)
////            {
////               // descendant count
////               rect.xMin += 100;
////               Style.Label.Draw(rect, "(" + item.children.Count.ToString() + ")", false, false, false, false);
////            }
////         }
////      }

      private ListViewItem GetVisibleItem(int index)
      {
         if (index >= 0 && index < this.visibleItems.Count)
         {
            return this.visibleItems[index];
         }

         uScriptDebug.Log("The specified item index is out of range.", uScriptDebug.Type.Error);
         return null;
      }

      private void ContextMenuCallback(object obj)
      {
         var data = obj as ContextMenuCallbackData;
         if (data == null)
         {
            uScriptDebug.Log("Invalid context menu callback data received.", uScriptDebug.Type.Error);
            return;
         }

         switch (data.Command)
         {
            case ContextMenuCallbackData.CommandType.Collapse:
               foreach (var item in this.selectedItems.Where(item => item.HasVisibleChildren && this.IsFolderExpanded(item)))
               {
                  this.CollapseFolder(item);
               }

               break;

            case ContextMenuCallbackData.CommandType.Expand:
               foreach (var item in this.selectedItems.Where(item => item.HasVisibleChildren && (this.IsFolderExpanded(item) == false)))
               {
                  this.ExpandFolder(item);
               }

               break;

            default:
               Debug.Log("COMMAND: " + data.Command.ToString() + " on \"" + data.Items[0].ItemPath + "\"\n");
               break;
         }
      }

      private void UpdateFocus(Rect parentPanelRect)
      {
         var e = Event.current;

         if (this.HasFocus)
         {
            // Verify that the control still has focus
            if (uScript.Instance.HasFocus == false)
            {
               this.HasFocus = false;
            }
            else if (GUIUtility.keyboardControl != this.controlID)
            {
               this.HasFocus = false;
            }
            else if ((e.type == EventType.MouseDown || e.type == EventType.Used) && parentPanelRect.Contains(e.mousePosition) == false)
            {
               this.HasFocus = false;
               GUIUtility.keyboardControl = 0;
            }

            if (this.HasFocus == false)
            {
               // Focus was lost
               uScript.Instance.Repaint();
               //Debug.Log("LOST FOCUS: keyboardControl: " + GUIUtility.keyboardControl + "\n");
            }
         }
         else
         {
            // Check to see if the control should get focus
            if (e.type == EventType.MouseDown && parentPanelRect.Contains(e.mousePosition))
            {
               this.HasFocus = true;
            }
            else if (GUIUtility.keyboardControl == this.controlID && uScript.Instance.HasFocus)
            {
               this.HasFocus = true;
            }

            if (this.HasFocus)
            {
               // Focus was received
               GUIUtility.keyboardControl = this.controlID;
               uScript.Instance.Repaint();
               //Debug.Log("RECEIVED FOCUS: keyboardControl: " + GUIUtility.keyboardControl + "\n");
            }
         }

         // Finally, apply the editor focus status
         // TODO: We shouldn't reference uScript here, if possible. This control should be self-contained for re-useability
         this.HasFocus = this.HasFocus && uScript.Instance.HasFocus;
      }

      // === Classes ====================================================================

      private static class Style
      {
         private const int ColumnHeaderHeight = 16;

         static Style()
         {
            RowEven = new GUIStyle();
            RowOdd = new GUIStyle();

            RowSelected = new GUIStyle("PR Label") { contentOffset = new Vector2(0, -1) };

            Foldout = new GUIStyle("IN Foldout");

            Icon = new GUIStyle("PR Label") { contentOffset = new Vector2(-2, -1) };

            Label = new GUIStyle(RowSelected);

            ColumnHeader = new GUIStyle(EditorStyles.toolbarButton)
            {
               name = "uScript_ListViewColumn-BG",
               fontStyle = FontStyle.Bold,
               alignment = TextAnchor.MiddleLeft,
               padding = new RectOffset(5, 8, 0, 0),
               fixedHeight = ColumnHeaderHeight,
               contentOffset = new Vector2(0, -1),
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-BG") },
               active = { background = null }
            };

            ColumnHeaderButton = new GUIStyle(ColumnHeader)
            {
               name = "uScript_ListViewColumn-N",
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-N0") },
               active = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-N1") }
            };

            ColumnHeaderFirst = new GUIStyle(ColumnHeader)
            {
               name = "uScript_ListViewColumn-F",
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-N2") },
               active = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-N1") }
            };

            ColumnHeaderSelected = new GUIStyle(ColumnHeader)
            {
               name = "uScript_ListViewColumn-S",
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-S0") },
               active = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-S1") }
            };

            ColumnHeaderAscending = new GUIStyle(ColumnHeader)
            {
               name = "uScript_ListViewColumn-A",
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-A0") },
               active = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-A1") },
               border = new RectOffset(3, 12, 0, 0)
            };

            ColumnHeaderDescending = new GUIStyle(ColumnHeader)
            {
               name = "uScript_ListViewColumn-D",
               normal = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-D0") },
               active = { background = uScriptGUI.GetSkinnedTexture("ListViewColumn-D1") },
               border = new RectOffset(3, 12, 0, 0)
            };
         }

         public static GUIStyle RowEven { get; private set; }

         public static GUIStyle RowOdd { get; private set; }

         public static GUIStyle RowSelected { get; private set; }

         public static GUIStyle Foldout { get; private set; }

         public static GUIStyle Icon { get; private set; }

         public static GUIStyle Label { get; private set; }

         public static GUIStyle ColumnHeader { get; private set; }

         public static GUIStyle ColumnHeaderButton { get; private set; }

         public static GUIStyle ColumnHeaderFirst { get; private set; }

         public static GUIStyle ColumnHeaderSelected { get; private set; }

         public static GUIStyle ColumnHeaderAscending { get; private set; }

         public static GUIStyle ColumnHeaderDescending { get; private set; }
      }

      private class ContextMenuCallbackData
      {
         public ContextMenuCallbackData(CommandType command, params ListViewItem[] items)
         {
            this.Command = command;
            this.Items = items;
         }

         public enum CommandType
         {
            None,
            Expand,
            ExpandChildren,
            ExpandAll,
            Collapse,
            CollapseChildren,
            CollapseAll,
            Load,
            PingSource,
            SaveQuick,
            SaveDebug,
            SaveRelease,
            Clean,
            CleanChildren,
            CleanAll,
            Rebuild,
            RebulidChildren,
            RebulidAll
         }

         public CommandType Command { get; set; }
         
         public ListViewItem[] Items { get; private set; }
      }

      private class FolderInfo
      {
         public FolderInfo(ListViewItem item)
         {
            this.Item = item;
         }

         public bool Expanded { get; set; }

         public ListViewItem Item { get; private set; }
      }
   }

// It should include features, such as:
//
// + Support for hundreds or thousands of items (ListViewItems)
// + Drawing only those items that are visible in the current list area
// + Foldout items
// + Variable-height list items
// + Embedded controls (ie, labels, buttons, text fields in an item)
// + Multiple columns
// + Column headers
// + Item selection (multi-selection)
//
// Perform all calculations during EventType.Layout
// Perform all drawing during EventType.Repaint
// Perform all input identification during input event types (keyboard and mouse)
// Perform all input processing during Update()
//
// Advanced features might include:
// + List sorting by column
// + Adjustable column order
}
