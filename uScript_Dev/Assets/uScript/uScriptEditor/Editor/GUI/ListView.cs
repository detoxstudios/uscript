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
      private readonly List<ListViewItem> flatItems = new List<ListViewItem>();
      private readonly List<ListViewItem> nestedItems = new List<ListViewItem>();
      private readonly List<ListViewItem> selectedItems = new List<ListViewItem>();

      private ListViewItem anchorItem;
      private Vector2 dragInitialMouse;
      private Vector2 dragInitialSize;
      private ListViewColumn draggedColumn;
      private Rect itemRowRect;
      private Vector2 listPosition = Vector2.zero;
      private Rect totalContentSize;

      // === Constructors ===============================================================

      public ListView(EditorWindow window) : this(window, typeof(ListViewItem))
      {
      }

      public ListView(EditorWindow window, Type typeListViewItem)
      {
         this.EditorWindow = window;
         
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

      public bool ContainsFocus { get; private set; }

      public EditorWindow EditorWindow { get; private set; }

      public int FirstVisibleRow { get; private set; }

      public bool Focused { get; private set; }

      public bool ForceHorizontalColumnFit { get; set; }

      public bool GridLines { get; set; }

      public bool HasFocus { get; set; }

      public bool HideSelection { get; set; }

      public bool IsHorizontalScrollbarVisible { get; private set; }

      public bool IsVerticalScrollbarVisible { get; private set; }

      public int ItemRow { get; set; }

      public List<ListViewItem> Items
      {
         get { return this.nestedItems; }
      }

      public int LastVisibleRow { get; private set; }

      public Type ListItemType { get; private set; }

      public int MinRowWidth { get; private set; }

      public bool MultiSelectEnabled { get; set; }

      public bool MultiSelect { get; set; }

      public Rect ParentPanelRect { get; set; }

      public ListViewItem PendingExecution { get; set; }

      public Rect Position { get; private set; }

      public bool Scrollable { get; set; }

      public ListViewItem[] SelectedItems
      {
         get { return this.selectedItems.ToArray(); }
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
         this.flatItems.Add((ListViewItem)Activator.CreateInstance(this.ListItemType, this, path));
      }

      public void RebuildListHierarchy()
      {
         var folderItemList = new Dictionary<string, ListViewItem>();

         foreach (ListViewItem item in this.flatItems)
         {
            ListViewItem parent = null;
            var path = string.Empty;
            var folders = new List<string>(item.Path.Split('/'));

            while (folders.Count > 1)
            {
               string folder = folders[0];
               path += folder + "/";
               folders.RemoveAt(0);

               if (folderItemList.ContainsKey(path))
               {
                  parent = folderItemList[path];
               }
               else
               {
                  var newParent = (ListViewItem)Activator.CreateInstance(this.ListItemType, this, path + "/" + folder);
                  this.AddHierarchyChild(parent, newParent);

                  folderItemList.Add(path, newParent);

                  parent = newParent;
               }
            }

            this.AddHierarchyChild(parent, item);
         }
      }

      public void ClickNewSelection(ListViewItem item)
      {
         this.SelectNone();
         this.SelectItem(item);
         this.FrameItem(item);
         this.anchorItem = item;
      }

      public void ClickToggleSelection(ListViewItem item)
      {
         if (this.selectedItems.Contains(item))
         {
            this.DeselectItem(item);
            this.EditorWindow.Repaint();
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
            this.anchorItem = this.nestedItems.First();
         }

         var anchorName = this.anchorItem == null ? "(null)" : this.anchorItem.Name;

         Debug.Log("SELECT RANGE: \t\"" + anchorName + "\"\n\t\t\t\t  TO: \t\"" + item.Name + "\"");

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
            
            if (e.type == EventType.Layout)
            {
               // TODO: Determine the height and position of each item in the list
               this.totalContentSize = new Rect();
               this.CalculateItemLayout(this.nestedItems, ref this.totalContentSize);

               // TODO: With the above information, determine the first and last visible items
            }
            else
            {
               // TODO: Replace this properties with actual pixel sizes, to support variable-height rows.
               //       The current properties assume every row has a fixed height of 16 pixels.
               this.FirstVisibleRow = (int)(this.listPosition.y / 16);
               this.LastVisibleRow = (int)((rectListView.height + this.listPosition.y) / 16);
               
               this.Position = rectListView;

               //Debug.Log("LIST VIEW RECT: " + rectListView.ToString() + "\n" + "SCROLL OFFSET: " + _listPosition.ToString());
               //Debug.Log("FIRST:\t" + _firstVisibleRow.ToString() + "\nLAST:\t\t" + _lastVisibleRow.ToString());
            }
            
            this.listPosition = EditorGUILayout.BeginScrollView(this.listPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
            {
               int totalVisibleRows = this.CountTotalVisibleRows(this.nestedItems);
               if (this.TotalVisibleItems != totalVisibleRows)
               {
                  this.TotalVisibleItems = totalVisibleRows;
                  this.EditorWindow.Repaint();
               }

               //Debug.Log("VISIBLE ROWS: " + totalVisibleRows.ToString() + "\n");
               
               var style = new GUIStyle();
               style.normal.background = GUI.skin.box.normal.background;
               style.border = GUI.skin.box.border;
               
               // Determine the width
               var rectListContent = new Rect();

               GUILayout.Box(string.Empty, GUIStyle.none, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MinHeight(this.totalContentSize.height), GUILayout.MinWidth(this.TotalColumnWidth));
               if (e.type != EventType.Layout)
               {
                  rectListContent = GUILayoutUtility.GetLastRect();
                  this.MinRowWidth = Math.Max(this.TotalColumnWidth, (int)rectListContent.width);
                  //Debug.Log("ROW WIDTH: " + MinRowWidth.ToString() + "\n");
                  
                  //Debug.Log("OTHER CALC: " + rectListContent.ToString() + "\n\tCOL WIDTH: " + this.TotalColumnWidth + ", TYPE: " + e.type.ToString());

                  rectListContent.y = this.Position.y;
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
               
               if (this.nestedItems.Count > 0)
               {
                  this.itemRowRect = new Rect(0, 0, this.MinRowWidth, 0);
                  
                  for (int i = 0; i < this.nestedItems.Count; i++)
                  {
                     //this.nestedItems[i].Draw(ref this.itemRowRect);
                     //this.itemRowRect.y += this.itemRowRect.height;

                     // TOD: Pass a referent to _itemRowRect, so that the ListView can keep track of the layout
                     // TODO: Create a Contains method that returns true if any part of a rect exists in another rect

                     ListViewItem item = this.nestedItems[i];

                     bool shouldDrawRow = this.ItemRow >= this.FirstVisibleRow && this.ItemRow <= this.LastVisibleRow;

                     if (shouldDrawRow)
                     {
                        item.Position = new Rect(0, item.Row * item.Height, this.MinRowWidth, item.Height);

                        //int top = 0;
                        //int width = 0;

                        item.Draw(ref this.itemRowRect);
                        this.itemRowRect.y += item.Height;

                        //Debug.Log("ROW: " + this.ItemRow.ToString() + ", RECT: " + this.itemRowRect.ToString() + "\n");
                     }

                     this.nestedItems[i].Row = this.ItemRow++;
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
         
         EditorGUILayout.EndVertical();
         
         // Update the listview focus
         if (e.type == EventType.MouseDown || e.type == EventType.Used)
         {
            bool focus = (GUIUtility.keyboardControl == 0) && parentPanelRect.Contains(e.mousePosition);
            if (this.HasFocus != focus)
            {
               this.EditorWindow.Repaint();
            }
            
            this.HasFocus = focus;
         }
         
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
                        
                     case KeyCode.Tab:
                        // Move focus to search control (if there is one)
                        Debug.Log("KEY: " + e.keyCode.ToString() + "\n");
                        break;
                        
                     case KeyCode.Return:
                     case KeyCode.KeypadEnter:
                        // Action performed on KeyUp
                        e.Use();
                        break;
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
                     {
                        bool changed = false;
                        foreach (ListViewItem item in this.selectedItems)
                        {
                           if (item.HasVisibleChildren && (item.Expanded == false))
                           {
                              item.Expanded = true;
                              changed = true;
                           }
                        }
                        
                        if (changed == false)
                        {
                           this.SelectNext();
                        }
                        
                        e.Use();
                        break;
                     }
                        
                     case KeyCode.LeftArrow:
                     {
                        bool changed = false;
                        foreach (ListViewItem item in this.selectedItems)
                        {
                           if (item.HasVisibleChildren && item.Expanded)
                           {
                              item.Expanded = false;
                              changed = true;
                           }
                        }
                        
                        if ((changed == false) && (this.selectedItems.Count == 1))
                        {
                           this.SelectParent();
                        }
                        
                        e.Use();
                        break;
                     }
                  }
               }
               else if (e.modifiers == EventModifiers.Shift)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Tab:
                        // Move focus to search control (if there is one)
                        Debug.Log("SHIFT KEY: " + e.keyCode.ToString() + "\n");
                        break;
                  }
               }
               else if (e.modifiers == EventModifiers.Alt)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Return:
                     case KeyCode.KeypadEnter:
                        // Action performed on KeyUp
                        e.Use();
                        break;
                  }
               }
               else if ((e.modifiers & (EventModifiers.Control | EventModifiers.FunctionKey)) == 0)
               {
                  Debug.Log("KEY: " + e.keyCode.ToString() + ", MODIFIERS: " + e.modifiers.ToString() + "\n");
               }
            }
            else if (e.type == EventType.KeyUp)
            {
               if (e.modifiers == 0)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Return:
                     case KeyCode.KeypadEnter:
                        // Duplicate the double-click behavior
                        if (this.selectedItems.Count == 1)
                        {
                           if (this.selectedItems[0].HasVisibleChildren)
                           {
                              this.selectedItems[0].Expanded = !this.selectedItems[0].Expanded;
                           }
                           else
                           {
                              Debug.Log("ADDING PENDING EXECUTION\n");
                              this.PendingExecution = this.selectedItems[0];
                           }
                        }
                        
                        e.Use();
                        break;
                  }
               }
               else if (e.modifiers == EventModifiers.Alt)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Return:
                     case KeyCode.KeypadEnter:
                        // Duplicate the middle-click behavior
                        Debug.Log("ALT KEY: " + e.keyCode.ToString() + "\n");
                        e.Use();
                        break;
                  }
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
         //                              if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].m_SceneName))
         //                              {
         //                                 scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].m_SceneName;
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

      public void FrameItem(ListViewItem item)
      {
         ////         int index = GetVisibleItemIndex(item);
         
         int yMin = item.Row * item.Height;
         int yMax = yMin + item.Height;
         
         if (this.listPosition.y > yMin)
         {
            this.listPosition.y = yMin;
         }
         else if (this.listPosition.y < yMax - this.Position.height)
         {
            this.listPosition.y = yMax - this.Position.height;
         }
         
         this.EditorWindow.Repaint();
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
                  item.Expanded = !item.Expanded;
               }
               else
               {
                  Debug.Log("Execute: " + item.Name + "\n\t MODIFIERS: " + e.modifiers);
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
      }

      public ListViewItem SelectItem(int index)
      {
         ListViewItem item = this.GetVisibleItem(index);
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
         //Debug.Log("SelectItem: " + item.Name + "\n");
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
         this.SelectNone();
         
         if (this.nestedItems.Count > 0)
         {
            ListViewItem item = this.nestedItems[0];
            this.SelectItem(item);
            this.FrameItem(item);
         }
      }
      
      public void SelectLast()
      {
         this.SelectNone();

         if (this.nestedItems.Count > 0)
         {
            ListViewItem item = this.nestedItems[this.nestedItems.Count - 1];
            this.SelectItem(item);
            this.FrameItem(item);
         }
      }
      
      public void SelectParent()
      {
         if (this.selectedItems.Count != 1)
         {
            return;
         }

         var item = this.selectedItems[0];

         if (item.Parent != null)
         {
            this.DeselectItem(item);
            this.SelectItem(item.Parent);
            this.FrameItem(item.Parent);
         }
      }
      
      public void SelectNext()
      {
         if (this.selectedItems.Count <= 0)
         {
            return;
         }

         ////         int index = GetVisibleItemIndex(_selectedItems[_selectedItems.Count - 1]) + 1;
         var index = this.selectedItems[this.selectedItems.Count - 1].Row + 1;
         ////         Debug.Log("CURRENT INDEX: " + _selectedItems[_selectedItems.Count - 1].row.ToString()
         ////            + "\nNEW: " + index.ToString());
         var lastIndex = this.CountTotalVisibleRows(this.nestedItems) - 1;
         if (index > lastIndex)
         {
            ////            Debug.Log("UPDATE: " + index.ToString() + " to " + lastIndex.ToString() + "\n");
            index = lastIndex;
         }
            
         this.SelectNone();

         var item = this.SelectItem(index);
         ////         if (item == null)
         ////         {
         ////            Debug.Log("NULL\n");
         ////         }
         this.FrameItem(item);
      }
      
      public void SelectPrevious()
      {
         if (this.selectedItems.Count > 0)
         {
            ////         int index = GetVisibleItemIndex(_selectedItems[_selectedItems.Count - 1]) - 1;
            int index = this.selectedItems[this.selectedItems.Count - 1].Row - 1;
            if (index < 0)
            {
               index = 0;
            }
            
            this.SelectNone();
            this.FrameItem(this.SelectItem(index));
         }
      }

      public void SelectAll()
      {
         Debug.Log("SelectAll()\n");
      }
      
      public void SelectNone()
      {
         for (int i = this.selectedItems.Count - 1; i >= 0; i--)
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
      }
      
      public void SelectPageUp()
      {
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
               if (currItem.Expanded)
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
               genericMenu.AddItem(new GUIContent("Load \"" + files[0].Name + "\""), false, this.ContextMenuCallback, data);
               
               //data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.PingSource, files[0]);
               //genericMenu.AddItem(new GUIContent("Ping Source \"" + files[0].text + "\""), false, this.ContextMenuCallback, data);

               genericMenu.AddDisabledItem(new GUIContent("Ping Source"));
            }
            else
            {
               foreach (var listViewItem in files)
               {
                  data = new ContextMenuCallbackData(ContextMenuCallbackData.CommandType.Load, listViewItem);
                  genericMenu.AddItem(new GUIContent(string.Format("Load/\"{0}\"", listViewItem.Name)), false, this.ContextMenuCallback, data);
               }
            }
         }
         
         genericMenu.ShowAsContext();
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
            Debug.Log("FORCE SHRINK CUSTOM COLUMNS\n");
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

      private int CountTotalVisibleRows(IEnumerable<ListViewItem> items)
      {
         var count = 0;
        
         foreach (var listViewItem in items)
         {
            count++;
            
            if (listViewItem.Children != null && listViewItem.Expanded)
            {
               count += this.CountTotalVisibleRows(listViewItem.Children);
            }
         }
        
         return count;
      }

      private void CalculateItemLayout(IEnumerable<ListViewItem> items, ref Rect totalSize)
      {
         foreach (var item in items)
         {
            item.Position = new Rect(0, totalSize.height, totalSize.width, item.Height);
            totalSize.height += item.Height;

            if (item.Children != null && item.Expanded)
            {
               this.CalculateItemLayout(item.Children, ref totalSize);
            }
         }
      }

      private void DrawColumnHeaders()
      {
         if (this.Columns == null)
         {
            return;
         }

         Event e = Event.current;

         Rect rectColumnHeaders = EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(false));
         {
            var headerPosition = new Vector2(this.listPosition.x, 0);
            EditorGUILayout.BeginScrollView(headerPosition, false, false, GUIStyle.none, GUIStyle.none, "scrollview", GUILayout.ExpandHeight(false));
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
                  var rectColumnHeader = new Rect(rectColumnHeaders.x, 0, rectColumnHeaders.width, rectColumnHeaders.height);

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
                           Debug.Log("END DRAG".NewLine());
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
                  rectColumnHeader = new Rect(rectColumnHeaders.x, 0, rectColumnHeaders.width, rectColumnHeaders.height);

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
                                 ////                              Debug.Log("SELECTED COLUMN HEADER CLICKED: " + column.Name + "\n\tRE-SORT");
                              }
                              else
                              {
                                 this.SortColumn = column;
                                 ////Debug.Log("NEW COLUMN HEADER CLICKED: " + column.Name + "\n\tRE-SORT");
                              }
                           }
                        }
                     }
                     else
                     {
                        GUI.Label(rectColumnHeader, column.Content, Style.ColumnHeader);
                     }

                     //Debug.Log("COLUMN: " + rectColumnHeader + " - " + column.ID + ", " + Event.current.type + "\n");

                     rectColumnHeader.x = rectColumnHeader.xMax;
                  }

                  // TODO: Remove this section - Temporary handle drawing
                  foreach (var rect in this.dragHandles)
                  {
                     // Set the area for the resize grab handle
                     var r = new Rect(rect);
////                     r.yMin += 10;
////                     GUI.Box(r, GUIContent.none);
////
////                     Debug.DrawLine(new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), Color.black);
////                     GUI.Box(r, GUIContent.none, uScriptGUIStyle.debugBox);
                     uScriptGUI.DebugBox(r, Color.red);
                  }

////                  // TEMP DEBUG DRAW
////                  rectColumnHeader = new Rect(rectColumnHeaders.x, 10, rectColumnHeaders.width, rectColumnHeaders.height-10);
////
////                  // Handle column resizing
////                  foreach (ListViewColumn column in Columns)
////                  {
////                     // Allocate space for the current column and prepare for the next
////                     rectColumnHeader.width = column.Width;
////                     rectColumnHeader.x = rectColumnHeader.xMax;
////
////                     // Set the area for the resize grab handle
////                     Rect rectHandle = new Rect(rectColumnHeader);
////                     rectHandle.x -= (_draggedColumn == null ? 2 : 4);
////                     rectHandle.width = (_draggedColumn == null ? 5 : 9);
////
////                     GUI.Box(rectHandle, GUIContent.none);
////                  }
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
         if (index < 0 || index > this.CountTotalVisibleRows(this.nestedItems))
         {
            uScriptDebug.Log("The specified item index is out of range.", uScriptDebug.Type.Error);
            return null;
         }

         ListViewItem item = this.GetItem(index, this.nestedItems);
         if (item == null)
         {
            uScriptDebug.Log("Could not find a ListViewItem using the specified index (" + index.ToString(CultureInfo.InvariantCulture) + ")", uScriptDebug.Type.Error);
         }

         return item;
      }

      private ListViewItem GetItem(int index, IEnumerable<ListViewItem> items)
      {
         foreach (var item in items)
         {
            if (item.Row == index)
            {
               return item;
            }

            if (item.Children != null && item.Expanded)
            {
               var result = this.GetItem(index, item.Children);
               if (result != null)
               {
                  return result;
               }
            }
         }

         return null;
      }

//   private ListViewItem GetItem(int index, List<ListViewItem> items, int startIndex)
//   {
//      for (int i = 0; i < items.Count; i++)
//      {
//         if (startIndex == index)
//         {
//            return items[i];
//         }
//
//         startIndex++;
//
//         if (items[i].children != null && items[i].expanded)
//         {
//            ListViewItem result = GetItem(index, items[i].children, startIndex);
//            if (result == null)
//            {
//               startIndex += items[i].children.Count;
//            }
//            else
//            {
//               return result;
//            }
//         }
//      }
//
//      return null;
//   }
//
//   /// <summary>Gets the index of the specified ListViewItem within the list of visible items.</summary>
//   /// <returns>The item index or a negative value when an error occurs.</returns>
//   /// <param name='item'>The ListViewItem to look for.</param>
//   public int GetVisibleItemIndex(ListViewItem item)
//   {
//      int index = GetItemIndex(item, _items);
//      if (index == -1)
//      {
//         uScriptDebug.Log("Could not find the specified ListViewItem.", uScriptDebug.Type.Warning);
//      }
//      return index;
//   }
//
//   /// <summary>Gets the index of the specified ListViewItem within a list of items.</summary>
//   /// <returns>The item index or a negative value when an error occurs.</returns>
//   /// <param name='item'>The ListViewItem to look for.</param>
//   /// <param name='items'>The list to search. This parameter is used for recursive searches.</param>
//   private int GetItemIndex(ListViewItem item, List<ListViewItem> items)
//   {
//      if (item == null)
//      {
//         uScriptDebug.Log("The specified item is invalid. Cannot search for a null ListViewItem.", uScriptDebug.Type.Error);
//         return -2;
//      }
//
//      int index = 0;
//
//      for (int i = 0; i < items.Count; i++)
//      {
//         if (items[i] == item)
//         {
//            return index;
//         }
//
//         index++;
//
//         if (items[i].children != null && items[i].expanded)
//         {
//            int result = GetItemIndex(item, items[i].children);
//            if (result == -1)
//            {
//               index += items[i].children.Count;
//            }
//            else
//            {
//               return (index + result);
//            }
//         }
//      }
//
//      return -1;
//   }

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
               foreach (var item in this.selectedItems.Where(item => item.HasVisibleChildren && item.Expanded))
               {
                  item.Expanded = false;
               }

               break;

            case ContextMenuCallbackData.CommandType.Expand:
               foreach (var item in this.selectedItems.Where(item => item.HasVisibleChildren && (item.Expanded == false)))
               {
                  item.Expanded = true;
               }

               break;

            default:
               Debug.Log("COMMAND: " + data.Command.ToString() + " on \"" + data.Items[0].Path + "\"\n");
               break;
         }
      }

      private void AddHierarchyChild(ListViewItem parent, ListViewItem child)
      {
         var index = child.Path.LastIndexOf("/", StringComparison.Ordinal) + 1;

         if (index > 0 && child.Path.Length > index)
         {
            child.Name = child.Path.Substring(index);
         }
         
         index = child.Name.LastIndexOf(".uscript", StringComparison.Ordinal);
         if (index >= 0)
         {
            child.Name = child.Name.Substring(0, index);
         }
         
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
         else
         {
            this.nestedItems.Add(child);
         }
      }
      
      // === Classes ====================================================================

      public static class Style
      {
         public const int ColumnHeaderHeight = 16;

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

      public class Content
      {
         /// <summary>
         /// Initializes a new instance of the <see cref="Content"/> class.
         /// </summary>
         public Content()
         {
            // Attempt to get the built-in folder icon
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6
            this.IconFolder = EditorGUIUtility.FindTexture("_Folder");
            this.IconFolderEmpty = this.IconFolder;
#else
            //System.Reflection.Assembly asm = typeof(UnityEditorInternal.AssetStore).Assembly;
            //if (asm != null)
            //{
            //   System.Type type = asm.GetType("UnityEditorInternal.EditorResourcesUtility");
            //   if (type != null)
            //   {
            //      System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static;
            //      System.Reflection.PropertyInfo property = type.GetProperty("folderIconName", flags);
            //      if (property != null)
            //      {
            //         iconFolder = EditorGUIUtility.FindTexture((string)property.GetValue(null, null));
            //      }

            //      property = type.GetProperty("emptyFolderIconName", flags);
            //      if (property != null)
            //      {
            //         iconFolderEmpty = EditorGUIUtility.FindTexture((string)property.GetValue(null, null));
            //      }
            //   }
            //}
            this.IconFolder = EditorGUIUtility.FindTexture("Folder Icon");
            this.IconFolderEmpty = EditorGUIUtility.FindTexture("FolderEmpty Icon");
#endif

            // TODO: These probably should be moved to uScriptGUIPanelScriptNew where the custom item renderer is located
            //uScriptGUIPanelScriptNew panel = uScriptGUIPanelScriptNew.Instance;
            //if (panel == null)
            //{
            //   Debug.Log("PANEL INSTANCE IS NULL\n");
            //}

            //if (panel.Textures == null)
            //{
            //   Debug.Log("PANEL TEXTURES ARE NULL\n");
            //}

            //Dictionary<string, Texture2D> textures = panel.Textures;
            Dictionary<string, Texture2D> textures = null;
            if (textures != null)
            {
               this.IconScript = textures["iconScript"];
               this.IconScriptNested = textures["iconScriptNested"];
   
               this.IconSourceDebug = textures["iconSourceDebug"];
               this.IconSourceMissing = textures["iconSourceMissing"];
               this.IconSourceRelease = textures["iconSourceRelease"];
            }

            //string skinPath = uScriptGUI.ImagePath;

            //iconScript = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile01.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            //iconScriptNested = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile02.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

            //iconSourceDebug = null;
            //iconSourceMissing = null;
            //iconSourceRelease = null;
         }

         public Texture2D IconFolder { get; private set; }
         
         public Texture2D IconFolderEmpty { get; private set; }
         
         public Texture2D IconScript { get; private set; }
         
         public Texture2D IconScriptNested { get; private set; }
         
         public Texture2D IconSourceDebug { get; private set; }
         
         public Texture2D IconSourceMissing { get; private set; }

         public Texture2D IconSourceRelease { get; private set; }
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
   }

//      _nodeCount = 0;
//      _propertyCount = 0;
//
//      columnOffset = offset;
//      svRect = rect;
//
//      if (null == _styleEnabled)
//      {
//         _styleEnabled = new GUIStyle(GUI.skin.toggle);
//         _styleEnabled.margin = new RectOffset(4, 0, 2, 4);
//         _styleEnabled.padding = new RectOffset(20, 0, 0, 0);
//         _styleEnabled.padding.left = 20;
//
//         _styleLabel = new GUIStyle(EditorStyles.label);
//         _styleLabel.margin.left = 0;
//
//         _styleType = new GUIStyle(EditorStyles.label);
//         _styleType.margin.left = 6;
//      }
//
//      GUILayout.Label(string.Empty, new GUIStyle(), GUILayout.Height(uScriptGUIStyle.columnHeaderHeight));
//
//      float x = 0;
//      float y = columnOffset.y;
//
//      // The columns have a margin of 4. Margins of adjacent cells overlap, so the spacing
//      // betweem columns is the width of the largest margin, not the sum.
//      //
//      //    4.[A].4
//      //          4.[B].4
//      //                4.[C].4
//      //
//      //    4.[A].4.[B].4.[C].4
//      //
//      // The result should be that when laying out each column, the left-most and right-most
//      // columns should allow for an extra 2px, while the inner columns assume that 2px will
//      // be used on each side.
//      //
//      // Finally, the left margin of the left column, and the right margin of the right column
//      // is excluded when positioning the GUI elements, since the offset is automatically applied.
//
//      //
//      // Update control focus changes
//      //
//
//      //if (Event.current.keyCode == KeyCode.Escape)
//      //{
//      //   Debug.Log("ESC was pressed\n");
//      //   Event.current.Use();
//      //}
//
//      if (GUI.GetNameOfFocusedControl() != _focusedControl)
//      {
//         uScriptDebug.Log("Control focus changed from '" + _focusedControl + "' to '" + GUI.GetNameOfFocusedControl() + "'\n", uScriptDebug.Type.Debug);
//         _previousControl = _focusedControl;
//         _focusedControl = GUI.GetNameOfFocusedControl();
//      }

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
//
// + Resizable columns
// + List sorting by column
// + Adjustable column order
// + Optional context menu support
//
//   private void DrawListView()
//   {
//      Rect listviewRect = new Rect(0, 0, 400, 200);
//      Rect listviewContentRect = new Rect(0, 0, 240, 120);
//      _scrollviewOffset = GUI.BeginScrollView(listviewRect, _scrollviewOffset, listviewContentRect);
//      GUI.Box(new Rect(0, 0, 100, 100), "Scrollview");
//      GUI.EndScrollView();
//
//      if (_listView == null)
//      {
//         _listView = new guiListView();
//      }
//   }
//
//   private guiListView _listView;
//
//   // ListViewState
//   //    Columns (list ColumnState)
//
//   //    EVENTS:
//   //       MouseIn
//   //       MouseOut
//   //
//   //    HeaderHeight
}
