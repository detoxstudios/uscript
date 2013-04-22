namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using UnityEngine;
   using UnityEditor;

   public class ListView
   {
      public List<ListViewColumn> Columns { get; private set; }

      public UnityEditor.EditorWindow EditorWindow;

      // System.Windows.Forms.ListView Members

      /// <summary>
      /// Gets or sets a value indicating whether the user can drag column headers to reorder columns in the control.
      /// </summary>
      /// <value>
      /// <c>true</c> if drag-and-drop column reordering is allowed; otherwise, <c>false</c>. The default is <c>false</c>.
      /// </value>
      public bool AllowColumnReorder { get; set; }

      /// <summary>
      /// Gets the size and location of the control relative to the parent control. The <see cref="Rect"/> includes the nonclient elements such as scrollbars, borders, and column headers.
      /// </summary>
      /// <value>
      /// A <see cref="Rect" /> in pixels relative to the parent control that represents the size and location of the control including its nonclient elements.
      /// </value>
      public Rect Bounds { get; private set; }

      /// <summary>
      /// Gets or sets a value indicating whether the control can be selected.
      /// </summary>
      /// <value>
      /// <c>true</c> if the control can be selected; otherwise, <c>false</c>.
      /// </value>
      public bool CanSelect { get; set; }

      /// <summary>
      /// <para>
      ///   Gets the <see cref="Rect" /> that represents the client area of the control.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   The client area of a control is the bounds of the control, minus the nonclient elements such as scrollbars,
      ///   borders, and column headers. Because client coordinates are relative to the upper-left corner of the client
      ///   area of the control, the coordinates of the upper-left corner of the rectangle returned by this property are
      ///   (0,0). You can use this property to obtain the size and coordinates of the client area of the control for
      ///   tasks such as drawing on the surface of the control.
      /// </para>
      /// </summary>
      /// <value>
      /// A <see cref="Rect" /> that represents the client area of the control.
      /// </value>
      public Rect ClientRect { get; private set; }

      /// <summary>
      /// <para>
      ///   Gets a value indicating whether the control, or one of its child controls, currently has the input focus.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   To determine whether the control has focus, regardless of whether any of its child controls have focus, use
      ///   the <see cref="Focused" /> property. To give a control the input focus, use the <see cref="Focus" /> or
      ///   <see cref="Select" /> methods.
      /// </para>
      /// </summary>
      /// <value>
      /// <c>true</c> if the control or one of its child controls currently has the input focus; otherwise, <c>false</c>.
      /// </value>
      public bool ContainsFocus { get; private set; }

      /// <summary>
      /// Gets a value indicating whether the control has input focus.
      /// </summary>
      /// <value>
      /// <c>true</c> if the control has focus; otherwise, <c>false</c>.
      /// </value>
      public bool Focused { get; private set; }

      /// <summary>
      /// Gets or sets a value indicating whether different background colors should be used for alternating rows in the control.
      /// </summary>
      /// <value>
      /// <c>true</c> if alternating row background colors are used; otherwise, <c>false</c>. The default is <c>false</c>.
      /// </value>
      public bool AlternateRowBackground { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether grid lines appear between the rows and columns containing the items and subitems in the control.
      /// </summary>
      /// <value>
      /// <c>true</c> if grid lines are drawn around items and subitems; otherwise, <c>false</c>. The default is <c>false</c>.
      /// </value>
      public bool GridLines { get; set; }

      /// <summary>
      /// <para>
      ///   Gets or sets a value indicating whether the selected item in the control remains highlighted when the control loses focus.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   When this property is set to <c>false</c>, selected items in the ListView control remain highlighted in a
      ///   different color than the current selection color specified by the operating system when the ListView control
      ///   loses focus. You can use this property to keep items that are selected by the user visible when the user
      ///   clicks a different control on the form or moves to a different window.
      /// </para>
      /// </summary>
      /// <value>
      /// <c>true</c> if the selected item does not appear highlighted when the control loses focus; <c>false</c> if the selected item still appears highlighted when the control loses focus. The default is <c>false</c>.
      /// </value>
      public bool HideSelection { get; set; }

      /// <summary>
      /// <para>
      ///   Gets or sets a value indicating whether multiple items can be selected.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   When the <see cref="MultiSelect" /> property is set to <c>true</c>, multiple items can be selected in the
      ///   <see cref="ListView" /> control. To select multiple items, the user must hold down the CTRL key while clicking
      ///   the items to select. Consecutive items can be selected by clicking the first item to select and then, while
      ///   holding down the SHIFT key, clicking the last item to select. You can use the multiple selection feature to
      ///   select multiple items in the <see cref="ListView" /> control and perform an operation on all the items
      ///   selected. For example, the user could select multiple items and then right-click a selected item to display a
      ///   shortcut menu that displays a set of tasks that can be performed on the selected items.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   To determine which items are selected in the <see cref="ListView" /> control, use the
      ///   <see cref="SelectedItems" /> property. The <see cref="SelectedItems" /> property allows you to access the
      ///   <see cref="ListView.SelectedListViewItemCollection" /> that contains a list of the selected items. If you want
      ///   the index positions in the <see cref="ListView.ListViewItemCollection" /> instead of the items, you can use
      ///   the <see cref="SelectedIndices" /> property to access the <see cref="ListView.SelectedIndexCollection" />.
      /// </para>
      /// </summary>
      /// <value>
      /// <c>true</c> if multiple items in the control can be selected at one time; otherwise, <c>false</c>. The default is <c>false</c>.
      /// </value>
      public bool MultiSelect { get; set; }

      /// <summary>
      /// <para>
      ///   Gets or sets a value indicating whether scrollbars are added to the control when there is not enough room to display all items.
      /// </para>
      /// <para>&#160;</para>
      /// <para>
      ///   When this property is set to <c>true</c>, the <see cref="ListView" /> displays scrollbars to use when the
      ///   number of items exceeds the size of the client area of the control. You can use this property to ensure that
      ///   the user can access all items that are available in the <see cref="ListView" /> control.
      /// </para>
      /// </summary>
      /// <value>
      /// <c>true</c> if scrollbars are added to the control when necessary to allow the user to see all the items; otherwise, <c>false</c>. The default is <c>true</c>.
      /// </value>
      public bool Scrollable { get; set; }




      // List members
      private UnityEngine.Vector2 _listPosition = UnityEngine.Vector2.zero;
      private List<ListViewItem> _selectedItems = new List<ListViewItem>();

      public ListViewItem[] selectedItems { get { return _selectedItems.ToArray(); } }

      public ListViewItem selectedID { get { return (_selectedItems.Count > 0 ? _selectedItems[0] : null); } }

      private List<ListViewItem> _flatList;

      public List<ListViewItem> FlatList { get { return _flatList; } }

      public void AddColumn(string name, GUIContent content, int width, int minWidth, int maxWidth, bool isResizeable)
      {
         if (Columns == null)
         {
            Columns = new List<ListViewColumn>();
         }

         if (string.IsNullOrEmpty(name))
         {
            throw new System.ArgumentException("The column name cannot be null or empty.", "name");
         }

         foreach (ListViewColumn column in Columns)
         {
            if (column.Name == name)
            {
               throw new System.ArgumentException("A column with the specified name already exists: \"" + name + "\"", "name");
            }
         }

         Columns.Add(new ListViewColumn(name, content, width, minWidth, maxWidth, isResizeable));

         if (string.IsNullOrEmpty(SortColumn))
         {
            SortColumn = name;
         }
      }

      public void AddItem(string path)
      {
         AddItem(path, null);
      }

      public void AddItem(string path, ListViewItemData data)
      {
         _flatList.Add(new ListViewItem(this, path, data));
      }

      private List<ListViewItem> _items;

      public List<ListViewItem> Items { get { return _items; } }

      public int TotalVisibleItems { get; private set; }

      public int ItemRow { get; set; }

      public int MinRowWidth { get; private set; }

      public bool hasFocus { get; set; }

      public bool isHorizontalScrollbarVisible { get; private set; }

      public bool isVerticalScrollbarVisible { get; private set; }

      public CustomStyle Style;
      public CustomContent Content;

      public int FirstVisibleRow { get; private set; }

      public int LastVisibleRow { get; private set; }

      public Rect Position { get; private set; }

      public Rect ParentPanelRect { get; set; }

      public ListViewItem PendingExecution { get; set; }

      public bool ShowColumnHeaders { get; set; }

      public bool SortByColumn { get; set; }

      public string SortColumn { get; private set; }

      public int TotalColumnWidth { get; private set; }

      private ListViewColumn draggedColumn = null;

//      public Rect Position;
//      public Vector2 ScrollPos;
//      public int ID;
//      public int Row;
//      public int RowHeight;
//      public int TotalRows;
//      public bool SelectionChanged;
//
//       public bool HasUniformRowHeights
      public bool MultiSelectEnabled { get; set; }

      private ListViewItemDraw DrawItemCallback;

      // The ListView utilizes a ScrollView control that contains numerous ListViewItems.
      // Each ListViewItem may contain more or more GUI controls, and even a sublist of
      // ListViewItems, which can be used along with foldouts.

      public ListView(EditorWindow window, ListViewItemDraw drawCallback)
      {
         EditorWindow = window;
         _items = new List<ListViewItem>();

         Style = new CustomStyle();
         Content = new CustomContent();

         DrawItemCallback = drawCallback;
      }

      public void Init()
      {
         _items = new List<ListViewItem>();
         _flatList = new List<ListViewItem>();
      }

      public void RebuildHierarchy()
      {
         Dictionary<string, ListViewItem> folderItemList = new Dictionary<string, ListViewItem>();
         ListViewItem parent;
         List<string> folders;
         string folder;
         string path;

         foreach (ListViewItem item in _flatList)
         {
            parent = null;
            path = string.Empty;
            folders = new List<string>(item.path.Split(System.IO.Path.DirectorySeparatorChar));

            while (folders.Count > 1)
            {
               folder = folders[0];
               path += folder + "/";
               folders.RemoveAt(0);

               if (folderItemList.ContainsKey(path))
               {
                  parent = folderItemList[path];
//               Debug.Log("FOUND FOLDOUT \"" + parent.text + "\"\n");
               }
               else
               {
                  ListViewItem newParent = new ListViewItem(this, path + System.IO.Path.DirectorySeparatorChar + folder);
                  AddHierarchyChild(parent, newParent);

                  folderItemList.Add(path, newParent);

                  parent = newParent;
//               Debug.Log("CREATED FOLDOUT \"" + parent.text + "\"\n");
               }
//            Debug.Log("PATH: \"" + path + "\"\n\tITEM: \"" + item.text + "\"\n");
            }

//         item.name = item.path.Substring(path.Length);
//         Debug.Log("PATH: \"" + path + "\", ITEM: \"" + item.name + "\"\n");
            AddHierarchyChild(parent, item);
         }
      }

      private void AddHierarchyChild(ListViewItem parent, ListViewItem child)
      {
         int index = child.path.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1;
         if (index > 0 && child.path.Length > index)
         {
            child.name = child.path.Substring(index);
         }

         index = child.name.LastIndexOf(".uscript");
         if (index >= 0)
         {
            child.name = child.name.Substring(0, index);
         }

         if (parent != null)
         {
            if (parent.children == null)
            {
               parent.children = new List<ListViewItem>();
            }
            child.parent = parent;
            child.depth = parent.depth + 1;
            parent.children.Add(child);
         }
         else
         {
            _items.Add(child);
         }
      }

//   public void Layout(Rect rect)
//   {
//      if (Event.current.type != EventType.Layout)
//      {
//         throw new System.MethodAccessException("ListView.Layout() can only be called during the Layout event.");
//      }
//
//      // Examine each item
//      //    Get the maximum width among all items to determine the minimum scrollview content width
//      //    Get the total height of all items to determine the minimum scrollview content height
//      //    These two values will determine whether or not the vertical and/or horizontal scrollbars will be used
//
//      float x = 0;
//      float y = 100; // columnOffset.y;
//
//      ListViewColumn lastColumn = Columns[Columns.Count - 1];
//      foreach (ListViewColumn column in Columns)
//      {
//         if (column != lastColumn)
//         {
//            column.Position = new Rect(x, y, column.Width, uScriptGUIStyle.columnHeaderHeight);
//            x += column.Width;
//         }
//         else
//         {
//            // TODO: When the parent container is resized, update Layout manually.
//            //       Currently, it uses the Rect parameter, which is only updated
//            //       after the following Repaint, so there will be a Layout delay.
//            //       Of this should get the size of the parent container directly.
//
//            // Expanded width on the right-most column
//            column.Position = new Rect(x, y, Math.Max(column.MinWidth, rect.width - x), uScriptGUIStyle.columnHeaderHeight);
//         }
//      }
//   }

      public void ClickNewSelection(ListViewItem item)
      {
         SelectNone();
         SelectItem(item);
         FrameItem(item);
      }

      public void ClickToggleSelection(ListViewItem item)
      {
         if (_selectedItems.Contains(item))
         {
            DeselectItem(item);
            EditorWindow.Repaint();
         }
         else
         {
            SelectItem(item);
            FrameItem(item);
         }
      }

      private int CountTotalVisibleRows(List<ListViewItem> items)
      {
         int count = 0;
        
         for (int i = 0; i < items.Count; i++)
         {
            count++;
            
            if (items[i].children != null && items[i].expanded)
            {
               count += CountTotalVisibleRows(items[i].children);
            }
         }
        
         return count;
      }

      private void DrawColumnHeaders()
      {
         Event e = Event.current;

         Rect rectColumnHeaders = EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(false));
         {
            Vector2 headerPosition = new Vector2(_listPosition.x, 0);
            EditorGUILayout.BeginScrollView(headerPosition, false, false, GUIStyle.none, GUIStyle.none, "scrollview", GUILayout.ExpandHeight(false));
            {
               TotalColumnWidth = 0;
               foreach (ListViewColumn column in Columns)
               {
                  TotalColumnWidth += column.Width;
               }

               // The base column background claims space in the GUILayout system
               GUILayout.Box(GUIContent.none, Style.columnHeader, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true), GUILayout.MinWidth(TotalColumnWidth));

               if (e.type != EventType.Layout)
               {
                  Rect rectColumnHeader = new Rect(rectColumnHeaders.x, 0, rectColumnHeaders.width, rectColumnHeaders.height);

                  // Handle column resizing
                  foreach (ListViewColumn column in Columns)
                  {
                     // Allocate space for the current column and prepare for the next
                     rectColumnHeader.width = column.Width;
                     rectColumnHeader.x = rectColumnHeader.xMax;

                     if (column.IsResizeable == false)
                     {
                        continue;
                     }

                     // Set the area for the resize grab handle
                     Rect rectHandle = new Rect(rectColumnHeader);
                     rectHandle.x -= 2;
                     rectHandle.width = 5;

                     EditorGUIUtility.AddCursorRect(rectHandle, MouseCursor.ResizeHorizontal);

                     if (e.type == EventType.MouseDown && rectHandle.Contains(e.mousePosition))
                     {
                        draggedColumn = column;
                        e.Use();
                     }
                     else if (e.type == EventType.MouseUp && draggedColumn != null)
                     {
                        draggedColumn = null;
                        e.Use();
                     }
                     else if (e.type == EventType.MouseDrag && draggedColumn != null && draggedColumn == column)
                     {
                        if ((e.delta.x > 0 && e.mousePosition.x > rectHandle.x)
                           || (e.delta.x < 0 && e.mousePosition.x < rectHandle.xMax))
                        {
                           // TODO: Make column.Width a float to prevent un-synchronized mouse and column movement
                           column.Width += (int)e.delta.x;
//                           Debug.Log("RESIZING COLUMN: " + column.Content.text + "\n" + "WIDTH: " + column.Width.ToString());
                           EditorWindow.Repaint();
                        }
                        e.Use();
                     }
                  }


                  // Draw the headers now
                  rectColumnHeader = new Rect(rectColumnHeaders.x, 0, rectColumnHeaders.width, rectColumnHeaders.height);

                  bool isSelectedColumn;
                  GUIStyle columnStyle;

                  foreach (ListViewColumn column in Columns)
                  {
                     rectColumnHeader.width = column.Width;

                     if (SortByColumn)
                     {
                        isSelectedColumn = (SortColumn == column.Name);

                        if (isSelectedColumn)
                        {
                           columnStyle = (column.IsSortDescending ? Style.columnHeaderDescending : Style.columnHeaderAscending);
                        }
                        else
                        {
                           columnStyle = Style.columnHeaderButton;
                        }

                        if (GUI.Button(rectColumnHeader, column.Content.text, columnStyle))
                        {
                           if (isSelectedColumn)
                           {
                              column.IsSortDescending = !column.IsSortDescending;
                              Debug.Log("SELECTED COLUMN HEADER CLICKED: " + column.Name + "\n\tRE-SORT");
                           }
                           else
                           {
                              if (SortColumn != column.Name)
                              {
                                 SortColumn = column.Name;
                              }
                              Debug.Log("NEW COLUMN HEADER CLICKED: " + column.Name + "\n\tRE-SORT");
                           }
                        }
                     }
                     else
                     {
                        GUI.Label(rectColumnHeader, column.Content, Style.columnHeader);
                     }

                     rectColumnHeader.x = rectColumnHeader.xMax;
                  }

//                  // TEMP DEBUG DRAW
//                  rectColumnHeader = new Rect(rectColumnHeaders.x, 10, rectColumnHeaders.width, rectColumnHeaders.height-10);
//
//                  // Handle column resizing
//                  foreach (ListViewColumn column in Columns)
//                  {
//                     // Allocate space for the current column and prepare for the next
//                     rectColumnHeader.width = column.Width;
//                     rectColumnHeader.x = rectColumnHeader.xMax;
//
//                     // Set the area for the resize grab handle
//                     Rect rectHandle = new Rect(rectColumnHeader);
//                     rectHandle.x -= 2;
//                     rectHandle.width = 5;
//
//                     GUI.Box(rectHandle, GUIContent.none);
//                  }
               }
            }
            EditorGUILayout.EndScrollView();

            // If the vertical scrollbar is visible, display piece above it
            if (isVerticalScrollbarVisible)
            {
               GUILayout.Box(GUIContent.none, Style.columnHeader, GUILayout.Width(GUI.skin.verticalScrollbar.fixedWidth - 1));
            }
         }
         EditorGUILayout.EndHorizontal();
      }

      /// <summary>
      /// Draw the ListView.
      /// </summary>
      /// <param name='parentPanelRect'>
      /// Parent panel Rect specifies the bounds of the ListView focus. Clicking outside of this region will remove focus, while clicking inside will apply focus.
      /// </param>
      public void Draw(Rect parentPanelRect)
      {
         Event e = Event.current;

         UpdateCustomStyles();

//      hasFocus = EditorWindow.focusedWindow == EditorWindow;

         Rect rectListView = EditorGUILayout.BeginVertical();
         {
//            Dictionary<string, Texture2D> backgrounds = new Dictionary<string, Texture2D>();
//            backgrounds.Add("normal", EditorStyles.toolbarButton.normal.background);
//            backgrounds.Add("onNormal", EditorStyles.toolbarButton.onNormal.background);
//            backgrounds.Add("hover", EditorStyles.toolbarButton.hover.background);
//            backgrounds.Add("onHover", EditorStyles.toolbarButton.onHover.background);
//            backgrounds.Add("active", EditorStyles.toolbarButton.active.background);
//            backgrounds.Add("onActive", EditorStyles.toolbarButton.onActive.background);
//            backgrounds.Add("focused", EditorStyles.toolbarButton.focused.background);
//            backgrounds.Add("onFocused", EditorStyles.toolbarButton.onFocused.background);
//
//            GUILayout.Space(2);
//            EditorGUILayout.BeginHorizontal();
//            {
//               GUILayout.Space(4);
////               GUI.backgroundColor = new Color(0, 0, 1, 0.125f);
//               foreach (KeyValuePair<string, Texture2D> kvp in backgrounds)
//               {
//                  if (kvp.Value != null)
//                  {
//                     GUIStyle style = new GUIStyle(Style.columnHeader);
//                     style.normal.background = kvp.Value;
//                     style.hover.background = GUI.skin.button.normal.background;
//                     style.focused.background = GUI.skin.button.active.background;
//   
//                     GUILayout.Button(kvp.Key, style);
//                     GUILayout.Space(4);
//                  }
//               }
////               GUI.backgroundColor = Color.white;
//            }
//            EditorGUILayout.EndHorizontal();
//            GUILayout.Space(2);
//            EditorGUILayout.BeginHorizontal();
//            {
//               GUILayout.Space(20);
//               GUILayout.Button("button", Style.columnHeader, GUILayout.Width(100));
//               GUILayout.Space(20);
//            }
//            EditorGUILayout.EndHorizontal();
//            GUILayout.Space(2);
//            EditorGUILayout.BeginHorizontal();
//            {
//               GUILayout.Space(20);
//               GUILayout.Box("box", GUILayout.Width(100));
//               GUILayout.Space(20);
//            }
//            EditorGUILayout.EndHorizontal();
//            GUILayout.Space(2);


            if (ShowColumnHeaders)
            {
               DrawColumnHeaders();
            }

            if (e.type != EventType.Layout)
            {
               FirstVisibleRow = (int)(_listPosition.y / 16);
               LastVisibleRow = (int)((rectListView.height + _listPosition.y) / 16);

               Position = rectListView;

//            if (ParentPanelRect
//            Debug.Log("LIST VIEW RECT: " + rectListView.ToString() + "\n" + "SCROLL OFFSET: " + _listPosition.ToString());
//
//            Debug.Log("FIRST:\t" + _firstVisibleRow.ToString() + "\nLAST:\t\t" + _lastVisibleRow.ToString());
            }

            _listPosition = EditorGUILayout.BeginScrollView(_listPosition, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
            {
               int totalVisibleRows = CountTotalVisibleRows(_items);
               if (TotalVisibleItems != totalVisibleRows)
               {
                  TotalVisibleItems = totalVisibleRows;
                  EditorWindow.Repaint();
               }

//            Debug.Log("VISIBLE ROWS: " + totalVisibleRows.ToString() + "\n");

               GUIStyle style = new GUIStyle();
               style.normal.background = GUI.skin.box.normal.background;
               style.border = GUI.skin.box.border;

               // Determine the width

               //
               Rect rectListContent = new Rect();

               GUILayout.Box(string.Empty, GUIStyle.none, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MinHeight(totalVisibleRows * 16), GUILayout.MinWidth(TotalColumnWidth));
               if (e.type != EventType.Layout)
               {
                  rectListContent = GUILayoutUtility.GetLastRect();
                  MinRowWidth = Math.Max(TotalColumnWidth, (int)rectListContent.width);
//               Debug.Log("ROW WIDTH: " + MinRowWidth.ToString() + "\n");

                  rectListContent.y = Position.y;
               }

               if (Position != new Rect() && e.type != EventType.Layout)
               {
                  Rect rectScrollView = new Rect(Position);
                  rectScrollView.yMin += 16;

                  int MinContentHeight = totalVisibleRows * 16;

                  isHorizontalScrollbarVisible = false;
                  isVerticalScrollbarVisible = false;

                  if (rectScrollView.height < MinContentHeight)
                  {
                     isHorizontalScrollbarVisible = (rectScrollView.width < MinRowWidth + 15);
                     isVerticalScrollbarVisible = true;
                  }

                  if (rectScrollView.width < MinRowWidth)
                  {
                     isHorizontalScrollbarVisible = true;
                     isVerticalScrollbarVisible = (rectScrollView.height < MinContentHeight + 15);
                  }

//               Debug.Log("SCROLLBARS:  " + (isHorizontalScrollbarVisible && isVerticalScrollbarVisible ? "BOTH"
//                  : (isHorizontalScrollbarVisible ? "HORIZONTAL"
//                     : (isVerticalScrollbarVisible ? "VERTICAL"
//                        : "NONE"))) + "\n");
               }

               ItemRow = 0;

               if (_items.Count > 0)
               {
                  for (int i = 0; i < _items.Count; i++)
   //            for (int i = 0; i < _flatList.Count; i++)
                  {
                     //               _items[i].Draw();
                     //               DrawItemCallback(_flatList[i]);
                     //               DrawItem(_flatList[i]);
                     DrawItem(_items[i]);
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
            bool focus = ((GUIUtility.keyboardControl == 0) && parentPanelRect.Contains(e.mousePosition));
            if (this.hasFocus != focus)
            {
               EditorWindow.Repaint();
            }
            this.hasFocus = focus;
         }

         // Process keyboard input
         if (this.hasFocus)
         {
            if (e.type == EventType.KeyDown)
            {
               // SelectAll (Cmd+A / Ctrl+A) is handled differently

               if (e.modifiers == 0)
               {
                  switch (e.keyCode)
                  {
                     case KeyCode.Escape:
                        SelectNone();
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
                        SelectFirst();
                        e.Use();
                        break;
   
                     case KeyCode.End:
                        SelectLast();
                        e.Use();
                        break;
   
                     case KeyCode.UpArrow:
                        SelectPrevious();
                        e.Use();
                        break;
   
                     case KeyCode.DownArrow:
                        SelectNext();
                        e.Use();
                        break;
   
                     case KeyCode.PageUp:
                        SelectPageUp();
                        e.Use();
                        break;
   
                     case KeyCode.PageDown:
                        SelectPageDown();
                        e.Use();
                        break;
   
                     case KeyCode.RightArrow:
                        {
                           bool changed = false;
                           foreach (ListViewItem item in _selectedItems)
                           {
                              if (item.hasVisibleChildren && (item.expanded == false))
                              {
                                 item.expanded = true;
                                 changed = true;
                              }
                           }
   
                           if (changed == false)
                           {
                              SelectNext();
                           }
                           e.Use();
                           break;
                        }
   
                     case KeyCode.LeftArrow:
                        {
                           bool changed = false;
                           foreach (ListViewItem item in _selectedItems)
                           {
                              if (item.hasVisibleChildren && item.expanded)
                              {
                                 item.expanded = false;
                                 changed = true;
                              }
                           }
   
                           if ((changed == false) && (_selectedItems.Count == 1))
                           {
                              SelectParent();
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
               else
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
                        if (_selectedItems.Count == 1)
                        {
                           if (_selectedItems[0].hasVisibleChildren)
                           {
                              if (_selectedItems[0].expanded)
                              {
                                 _selectedItems[0].expanded = false;
                              }
                              else
                              {
                                 _selectedItems[0].expanded = true;
                              }
                           }
                           else
                           {
                              Debug.Log("ADDING PENDING EXECUTION\n");
                              PendingExecution = _selectedItems[0];
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


//      AssetDatabase.GetCachedIcon(
//      AssetDatabase.GetAssetPath(


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

      /// <summary>Draws the next menu item in the ListView.</summary>
      /// <param name='item'>The menu item to draw.</param>
      private void DrawItem(ListViewItem item)
      {
         Event e = Event.current;
         bool isRepaint = e.type == EventType.Repaint;

         int indentWidth = this.Style.foldout.padding.left;
         item.height = (int)this.Style.label.fixedHeight;

         item.rowRect = new Rect(0, item.row * item.height, this.MinRowWidth, item.height);
         Rect rect = item.rowRect;

         bool shouldDrawRow = (this.ItemRow >= this.FirstVisibleRow && this.ItemRow <= this.LastVisibleRow);

         if (shouldDrawRow)
         {
            if (isRepaint)
            {
               // Draw row background
               GUIStyle rowStyle = (item.selected ? this.Style.rowSelected : (this.ItemRow % 2 == 0 ? this.Style.rowEven : this.Style.rowOdd));
   
               // isHover, isActive, on, hasKeyboardFocus
               //    GREY (on)
               //    BLUE (on, hasKeyboardFocus)
               //    RING (isHover, isActive)
               rowStyle.Draw(item.rowRect, GUIContent.none, false, false, true, this.hasFocus);
            }

            if (this.DrawItemCallback != null)
            {
               this.DrawItemCallback(item);
            }
            else
            {
               int COLUMN_PADDING = 2;

               if (item.hasVisibleChildren)
               {
                  // foldout toggle
                  rect.x = 2 + (item.depth * indentWidth);
                  rect.y--;
                  rect.width = indentWidth;
                  item.expanded = GUI.Toggle(rect, item.expanded, GUIContent.none, this.Style.foldout);
   
                  rect.x = (item.depth * indentWidth);
                  rect.y++;
                  rect.width = item.rowRect.width;
   
                  if (isRepaint)
                  {
                     // icon
                     this.Style.icon.Draw(rect, this.Content.iconFolder, false, false, false, false);
                     rect.xMin += 16;
   
                     // text
                     this.Style.label.Draw(rect, item.name, false, false, false, false);
                  }
               }
               else
               {
                  if (isRepaint)
                  {
                     rect = item.rowRect;

                     // "Graph" Column
                     rect.width = Columns[0].Width - COLUMN_PADDING;
                     rect.xMin = (item.depth * indentWidth);

                     // icon
                     this.Style.icon.Draw(rect, this.Content.iconScript, false, false, false, false);
                     rect.xMin += 16;

                     // text
                     this.Style.label.Draw(rect, Ellipsis.Compact(item.name, this.Style.label, rect, Ellipsis.Format.Middle), false, false, false, false);

                     // "Scene" Column
                     rect.x += rect.width + (COLUMN_PADDING * 2);
                     rect.width = Columns[1].Width - (COLUMN_PADDING * 2);

                     // filePathAndName
                     this.Style.label.Draw(rect, item.instanceID.ToString(), false, false, false, false);
                     //               this.Style.label.Draw(rect, filePathAndName, false, false, false, false);
                     //               this.Style.label.Draw(rect, guid.ToString(), false, false, false, false);

                     // "State" Column
                     rect.x += rect.width + (COLUMN_PADDING * 2);
                     rect.width = Columns[2].Width - (COLUMN_PADDING * 2);

                     // scriptStateIcon
                     this.Style.label.Draw(rect, item.instanceID.ToString(), false, false, false, false);
                  }
               }
            }  // if (this.DrawItemCallback == null)

         }

         item.row = this.ItemRow++;

         if (shouldDrawRow)
         {
            if (item.rowRect.Contains(e.mousePosition))
            {
               if (e.type == EventType.MouseDown)
               {
                  if (e.button == 0)
                  {
                     if (EditorGUI.actionKey && this.MultiSelectEnabled)
                     {
                        // (Control or Command) + Left-Click
                        this.ClickToggleSelection(item);
                        e.Use();
                     }
                     else if (e.modifiers == EventModifiers.Alt)
                     {
                        // (Alt or Option) + Left-Click
                        Debug.Log("ALT LEFT-CLICK" + "\n");
                        // Ping source
                        e.Use();
                     }
                     else if (e.modifiers != EventModifiers.Control)
                     {
                        // Left-Click
                        if (e.clickCount == 1)
                        {
                           this.ClickNewSelection(item);
                        }
                        else if (e.clickCount == 2)
                        {
                           if (item.hasVisibleChildren)
                           {
                              item.expanded = !item.expanded;
                              this.EditorWindow.Repaint();
                           }
                           else
                           {
                              Debug.Log("DOUBLE CLICK - OPEN FILE\n");
                           }
                        }
                        e.Use();
                     }
                  }
                  else if (e.button == 2)
                  {
                     // Middle-Click
                     Debug.Log("MIDDLE-CLICK" + "\n");
                     // Ping source
                     e.Use();
                  }
               }
               else if (e.type == EventType.ContextClick)
               {
                  Debug.Log("CONTEXT CLICK\n" + "BUTTON: " + e.button.ToString() + ", MODIFIERS: " + e.modifiers.ToString());
                  this.DrawContextMenu(item);
                  e.Use();
               }
//                  // TODO: successive left and right clicks are combined in calculating the clickCount.
//                  //       They should be separate. We should be able to quickly left click an item, and
//                  //       then right click it to open the context menu.
            }

//         Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");


//                else
//                {
//                    this.EndNameEditing();
//                    this.m_CurrentDragSelectionIDs = this.GetSelection(newHierarchyProperty, true);
//                    GUIUtility.hotControl = controlID;
//                    GUIUtility.keyboardControl = 0;
//                    DragAndDropDelay stateObject = (DragAndDropDelay) GUIUtility.GetStateObject(typeof(DragAndDropDelay), controlID);
//                    stateObject.mouseDownPosition = Event.current.mousePosition;
//                }
//                current.Use();
//            }


         }

         if (item.hasVisibleChildren)
         {
            if (item.expanded)
            {
               foreach (ListViewItem child in item.children)
               {
//               child.Draw();
                  DrawItem(child);
               }
            }
            else if (shouldDrawRow && isRepaint)
            {
               // descendant count
               rect.xMin += 100;
               this.Style.label.Draw(rect, "(" + item.children.Count.ToString() + ")", false, false, false, false);
            }
         }
      }

      private ListViewItem GetVisibleItem(int index)
      {
         if (index < 0 || index > CountTotalVisibleRows(_items))
         {
            uScriptDebug.Log("The specified item index is out of range.", uScriptDebug.Type.Error);
            return null;
         }

         ListViewItem item = GetItem(index, _items);
         if (item == null)
         {
            uScriptDebug.Log("Could not find a ListViewItem using the specified index (" + index.ToString() + ")", uScriptDebug.Type.Error);
         }
         return item;
      }

      private ListViewItem GetItem(int index, List<ListViewItem> items)
      {
         for (int i = 0; i < items.Count; i++)
         {
            if (items[i].row == index)
            {
               return items[i];
            }

            if (items[i].children != null && items[i].expanded)
            {
               ListViewItem result = GetItem(index, items[i].children);
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

      /// <summary>Update ListView scroll offset to frame the specified item.</summary>
      /// <param name='item'>The menu item to frame.</param>
      public void FrameItem(ListViewItem item)
      {
//      int index = GetVisibleItemIndex(item);

         int yMin = (item.row * item.height);
         int yMax = (yMin + item.height);

         if (_listPosition.y > yMin)
         {
            _listPosition.y = yMin;
         }
         else if (_listPosition.y < yMax - Position.height)
         {
            _listPosition.y = yMax - Position.height;
         }

         EditorWindow.Repaint();
      }

      /// <summary>Adds the specified menu item to the selected item list.</summary>
      /// <param name='index'>The index of the visible menu item to add.</param>
      public ListViewItem SelectItem(int index)
      {
         ListViewItem item = GetVisibleItem(index);
         if (item == null)
         {
            uScriptDebug.Log("No item was found at the specified list index (" + index.ToString() + ").", uScriptDebug.Type.Error);
            return null;
         }
         SelectItem(item);
         return item;
      }

      /// <summary>Adds the specified menu item to the selected item list.</summary>
      /// <param name='item'>The menu item to add.</param>
      public void SelectItem(ListViewItem item)
      {
         item.selected = true;
         _selectedItems.Add(item);
      }

      /// <summary>Removes the specified menu item from the selected item list.</summary>
      /// <param name='item'>The menu item to remove.</param>
      public void DeselectItem(ListViewItem item)
      {
         item.selected = false;
         _selectedItems.Remove(item);
      }

      /// <summary>Update the selection to include only the first item in the list.</summary>
      public void SelectFirst()
      {
         SelectNone();

         if (_items.Count > 0)
         {
            ListViewItem item = _items[0];
            SelectItem(item);
            FrameItem(item);
         }
      }

      /// <summary>Update the selection to include only the last item in the list.</summary>
      public void SelectLast()
      {
         SelectNone();
         if (_items.Count > 0)
         {
            ListViewItem item = _items[_items.Count - 1];
            SelectItem(item);
            FrameItem(item);
         }
      }

      /// <summary>Selects the parent list item if only one item is selected. If multiple items are selected, nothing happens.</summary>
      public void SelectParent()
      {
         if (_selectedItems.Count == 1)
         {
            ListViewItem item = _selectedItems[0];
            if (item.parent != null)
            {
               DeselectItem(item);
               SelectItem(item.parent);
               FrameItem(item.parent);
            }
         }
      }

      /// <summary>Select the menu item below the most recent selected menu item, or the first item in the list.</summary>
      public void SelectNext()
      {
         if (_selectedItems.Count > 0)
         {
//         int index = GetVisibleItemIndex(_selectedItems[_selectedItems.Count - 1]) + 1;
            int index = _selectedItems[_selectedItems.Count - 1].row + 1;
//         Debug.Log("CURRENT INDEX: " + _selectedItems[_selectedItems.Count - 1].row.ToString()
//            + "\nNEW: " + index.ToString());
            int lastIndex = CountTotalVisibleRows(_items) - 1;
            if (index > lastIndex)
            {
//            Debug.Log("UPDATE: " + index.ToString() + " to " + lastIndex.ToString() + "\n");
               index = lastIndex;
            }

            SelectNone();
            ListViewItem item = SelectItem(index);
//         if (item == null)
//         {
//            Debug.Log("NULL\n");
//         }
            FrameItem(item);
         }
      }

      /// <summary>Select the menu item above the most recent selected menu item, or the first item in the list.</summary>
      public void SelectPrevious()
      {
         if (_selectedItems.Count > 0)
         {
//         int index = GetVisibleItemIndex(_selectedItems[_selectedItems.Count - 1]) - 1;
            int index = _selectedItems[_selectedItems.Count - 1].row - 1;
            if (index < 0)
            {
               index = 0;
            }
   
            SelectNone();
            FrameItem(SelectItem(index));
         }
      }

      public void SelectAll()
      {
         Debug.Log("SelectAll()\n");
      }

      /// <summary>Deselect all items.</summary>
      public void SelectNone()
      {
         for (int i = _selectedItems.Count - 1; i >= 0; i--)
         {
            DeselectItem(_selectedItems[i]);
         }

         // TODO: If needed, remove focus from the ListView.
         //       This might not be needed, as there are no items selected,
         //       and there will be no way to visibly determine focus.
         EditorWindow.Repaint();
      }

      /// <summary>Jump down in the list by a single page, or select the last item.</summary>
      public void SelectPageDown()
      {
      }

      /// <summary>Jump up in the list by a single page, or select the first item.</summary>
      public void SelectPageUp()
      {
      }

      private void ContextMenuCallback(object obj)
      {
         ContextMenuCallbackData data = obj as ContextMenuCallbackData;
         if (data == null)
         {
            uScriptDebug.Log("Invalid context menu callback data received.", uScriptDebug.Type.Error);
            return;
         }

         switch (data.command)
         {
            case ContextMenuCallbackData.Command.Collapse:
               foreach (ListViewItem item in _selectedItems)
               {
                  if (item.hasVisibleChildren && item.expanded)
                  {
                     item.expanded = false;
                  }
               }
               break;

            case ContextMenuCallbackData.Command.Expand:
               foreach (ListViewItem item in _selectedItems)
               {
                  if (item.hasVisibleChildren && (item.expanded == false))
                  {
                     item.expanded = true;
                  }
               }
               break;

            default:
               Debug.Log("COMMAND: " + data.command.ToString() + " on \"" + data.items[0].path + "\"\n");
               break;
         }
      }

      private class ContextMenuCallbackData
      {
         public enum Command
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

         public Command command;
         public ListViewItem[] items;

         public ContextMenuCallbackData(Command command, params ListViewItem[] items)
         {
            this.command = command;
            this.items = items;
         }
      }

      public void DrawContextMenu(ListViewItem item)
      {
         // If the item is not in the current selection,
         // replace the selection with the new item.
         if (_selectedItems.Contains(item) == false)
         {
            ClickNewSelection(item);
         }

         // TODO: Should we do some type of sorting?  The items appear
         //       in the order they were selected, otherwise.

         GenericMenu menu = new GenericMenu();

         // Add folder expand and collapse options, if needed
         int expandCount = 0;
         int collapseCount = 0;

         List<ListViewItem> files = new List<ListViewItem>();
         ContextMenuCallbackData data;

         foreach (ListViewItem currItem in _selectedItems)
         {
            if (currItem.hasVisibleChildren)
            {
               if (currItem.expanded)
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

//         Expand,
//         ExpandChildren,
//         ExpandAll,
//         Collapse,
//         CollapseChildren,
//         CollapseAll,

         data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Expand, _selectedItems.ToArray());
         menu.AddItem(new GUIContent("Test/Test/"), false, ContextMenuCallback, data);

         data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Expand, _selectedItems.ToArray());
         menu.AddItem(new GUIContent("Test/Test/Item1"), false, ContextMenuCallback, data);

         data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Expand, _selectedItems.ToArray());
         menu.AddItem(new GUIContent("Test/Test/Item2"), false, ContextMenuCallback, data);



         if (expandCount > 0)
         {
            data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Expand, _selectedItems.ToArray());
            menu.AddItem(new GUIContent(expandCount > 1 ? "Expand Folders" : "Expand Folder"), false, ContextMenuCallback, data);
         }

         if (collapseCount > 0)
         {
            data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Collapse, _selectedItems.ToArray());
            menu.AddItem(new GUIContent(collapseCount > 1 ? "Collapse Folders" : "Collapse Folder"), false, ContextMenuCallback, data);
         }

         // Add file-related options
         if (files.Count > 0)
         {
            if ((expandCount + collapseCount) > 0)
            {
               menu.AddSeparator(string.Empty);
            }

//         Load,
//         PingSource,
//         SaveQuick,
//         SaveDebug,
//         SaveRelease,
//         Clean,
//         CleanChildren,
//         CleanAll,
//         Rebuild,
//         RebulidChildren,
//         RebulidAll

            if (files.Count == 1)
            {
               data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Load, files[0]);
               menu.AddItem(new GUIContent("Load \"" + files[0].name + "\""), false, ContextMenuCallback, data);

               data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.PingSource, files[0]);
//            menu.AddItem(new GUIContent("Ping Source \"" + files[0].text + "\""), false, ContextMenuCallback, data);
               menu.AddDisabledItem(new GUIContent("Ping Source"));
            }
            else
            {
               for (int i = 0; i < files.Count; i++)
               {
                  data = new ContextMenuCallbackData(ContextMenuCallbackData.Command.Load, files[i]);
                  menu.AddItem(new GUIContent("Load/\"" + files[i].name + "\""), false, ContextMenuCallback, data);
               }
            }
         }

         menu.ShowAsContext();
      }



      public class CustomContent
      {
         public Texture2D iconFolder { get; private set; }

         public Texture2D iconFolderEmpty { get; private set; }

         public Texture2D iconScript { get; private set; }

         public Texture2D iconScriptNested { get; private set; }

         public Texture2D iconSourceDebug { get; private set; }

         public Texture2D iconSourceMissing { get; private set; }

         public Texture2D iconSourceRelease { get; private set; }

         public CustomContent()
         {
            // Attempt to get the built-in folder icon
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6
         iconFolder = EditorGUIUtility.FindTexture("_Folder");
         iconFolderEmpty = iconFolder;
#else
//         System.Reflection.Assembly asm = typeof(UnityEditorInternal.AssetStore).Assembly;
//         if (asm != null)
//         {
//            System.Type type = asm.GetType("UnityEditorInternal.EditorResourcesUtility");
//            if (type != null)
//            {
//               System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static;
//               System.Reflection.PropertyInfo property = type.GetProperty("folderIconName", flags);
//               if (property != null)
//               {
//                  iconFolder = EditorGUIUtility.FindTexture((string)property.GetValue(null, null));
//               }
//
//               property = type.GetProperty("emptyFolderIconName", flags);
//               if (property != null)
//               {
//                  iconFolderEmpty = EditorGUIUtility.FindTexture((string)property.GetValue(null, null));
//               }
//            }
//         }
            iconFolder = EditorGUIUtility.FindTexture("Folder Icon");
            iconFolderEmpty = EditorGUIUtility.FindTexture("FolderEmpty Icon");
#endif

            // TODO: These probably should be moved to uScriptGUIPanelScriptNew where the custom item renderer is located
//            uScriptGUIPanelScriptNew panel = uScriptGUIPanelScriptNew.Instance;
//            if (panel == null)
//            {
//               Debug.Log("PANEL INSTANCE IS NULL\n");
//            }
//
//            if (panel.Textures == null)
//            {
//               Debug.Log("PANEL TEXTURES ARE NULL\n");
//            }
//
//            Dictionary<string, Texture2D> textures = panel.Textures;
            Dictionary<string, Texture2D> textures = null;
            if (textures != null)
            {
               iconScript = textures["iconScript"];
               iconScriptNested = textures["iconScriptNested"];
   
               iconSourceDebug = textures["iconSourceDebug"];
               iconSourceMissing = textures["iconSourceMissing"];
               iconSourceRelease = textures["iconSourceRelease"];
            }

//            string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/";
//
//            iconScript = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile01.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
//            iconScriptNested = AssetDatabase.LoadAssetAtPath(skinPath + "iconScriptFile02.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
//
//            iconSourceDebug = null;
//            iconSourceMissing = null;
//            iconSourceRelease = null;
         }
      }

      private void UpdateCustomStyles()
      {
//         if (Style == null || Style.SkinName != uScriptGUIStyle.sk)
//         {
//            Style = CustomStyle;
//         }
      }

      public class CustomStyle
      {
         public const int COLUMN_HEADER_HEIGHT = 16;

         public GUIStyle rowEven { get; private set; }

         public GUIStyle rowOdd { get; private set; }

         public GUIStyle rowSelected { get; private set; }

         public GUIStyle foldout { get; private set; }

         public GUIStyle icon { get; private set; }

         public GUIStyle label { get; private set; }

         public GUIStyle columnHeader { get; private set; }

         public GUIStyle columnHeaderButton { get; private set; }

         public GUIStyle columnHeaderFirst { get; private set; }

         public GUIStyle columnHeaderSelected { get; private set; }

         public GUIStyle columnHeaderAscending { get; private set; }

         public GUIStyle columnHeaderDescending { get; private set; }

//      public GUIStyle styleButtonGroup { get; private set; }
//      public GUIStyle styleCurrentScriptNormal { get; private set; }
//      public GUIStyle styleCurrentScriptError { get; private set; }
//      public GUIStyle styleScriptListNormal { get; private set; }
//      public GUIStyle styleScriptListBold { get; private set; }
//      public GUIStyle styleMiniButtonLeft { get; private set; }
//      public GUIStyle styleMiniButtonRight { get; private set; }

         public CustomStyle()
         {
            // Reload all custom GUI textures to match the new skin
            string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + (uScriptGUI.IsProSkin ? "DarkSkin" : "LightSkin") + "_";

            rowEven = new GUIStyle();
            rowOdd = new GUIStyle();

            rowSelected = new GUIStyle("PR Label");
            rowSelected.contentOffset = new Vector2(0, -1);

            foldout = new GUIStyle("IN Foldout");

            icon = new GUIStyle("PR Label");
            icon.contentOffset = new Vector2(-2, -1);

            label = new GUIStyle(rowSelected);
//         label.border = GUI.skin.box.border;
//         label.normal.background = GUI.skin.box.normal.background;

//         uScriptGUIStyle.Information(label, 3);
//
//
//         uScriptGUIStyle.Information(foldout, 3);
//
//         uScriptGUIStyle.Information(EditorStyles.foldout, 3);
//
//
//         uScriptGUIStyle.Information(icon, 3);


            columnHeader = new GUIStyle(EditorStyles.toolbarButton);
            columnHeader.name = "uScript_ListViewColumn-BG";
            columnHeader.fontStyle = FontStyle.Bold;
            columnHeader.alignment = TextAnchor.MiddleLeft;
            columnHeader.padding = new RectOffset(5, 8, 0, 0);
            columnHeader.fixedHeight = COLUMN_HEADER_HEIGHT;
            columnHeader.contentOffset = new Vector2(0, -1);
            columnHeader.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-BG.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeader.active.background = null;

            columnHeaderButton = new GUIStyle(columnHeader);
            columnHeaderButton.name = "uScript_ListViewColumn-N";
            columnHeaderButton.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-N0.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderButton.active.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-N1.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

            columnHeaderFirst = new GUIStyle(columnHeader);
            columnHeaderFirst.name = "uScript_ListViewColumn-F";
            columnHeaderFirst.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-N2.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderFirst.active.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-N1.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

            columnHeaderSelected = new GUIStyle(columnHeader);
            columnHeaderSelected.name = "uScript_ListViewColumn-S";
            columnHeaderSelected.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-S0.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderSelected.active.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-S1.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;

            columnHeaderAscending = new GUIStyle(columnHeader);
            columnHeaderAscending.name = "uScript_ListViewColumn-A";
            columnHeaderAscending.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-A0.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderAscending.active.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-A1.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderAscending.border = new RectOffset(3, 12, 0, 0);

            columnHeaderDescending = new GUIStyle(columnHeader);
            columnHeaderDescending.name = "uScript_ListViewColumn-D";
            columnHeaderDescending.normal.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-D0.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderDescending.active.background = AssetDatabase.LoadAssetAtPath(skinPath + "ListViewColumn-D1.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
            columnHeaderDescending.border = new RectOffset(3, 12, 0, 0);


//            _texture_windowMenuDropDown = AssetDatabase.LoadAssetAtPath(skinPath + "MenuDropDown.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
//            _texture_windowMenuContext = AssetDatabase.LoadAssetAtPath(skinPath + "MenuContext.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
//            _texture_underline = AssetDatabase.LoadAssetAtPath(skinPath + "Underline.png", typeof(UnityEngine.Texture2D)) as Texture2D;
//            _texture_propertyRowEven = AssetDatabase.LoadAssetAtPath(skinPath + "LineItem.png", typeof(UnityEngine.Texture2D)) as Texture2D;




//         styleButtonGroup = new GUIStyle();
//         styleButtonGroup.margin.top = 2;
//
//         styleCurrentScriptNormal = new GUIStyle(EditorStyles.boldLabel);
//
//         styleCurrentScriptError = new GUIStyle(styleCurrentScriptNormal);
//         styleCurrentScriptError.normal.textColor = UnityEngine.Color.red;
//
//         styleScriptListNormal = new GUIStyle(EditorStyles.label);
//         styleScriptListNormal.margin = new RectOffset(4, 4, 1, 1);
//         styleScriptListNormal.padding = new RectOffset(2, 2, 0, 0);
//
//         styleScriptListBold = new GUIStyle(styleScriptListNormal);
//         styleScriptListBold.fontStyle = FontStyle.Bold;
//
//         styleMiniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
//         styleMiniButtonLeft.margin = new RectOffset(4, 0, 1, 1);
//
//         styleMiniButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
//         styleMiniButtonRight.margin = new RectOffset(0, 4, 1, 1);
         }
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
//
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



//   private void DrawListView()
//   {
//
//
//
//
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
//
//   }
//
//
//
//
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
//
//
//
//


}
