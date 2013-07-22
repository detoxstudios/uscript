// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewItem.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.Collections.Generic;
   using UnityEngine;

   public class ListViewItem
   {
      // === Fields =====================================================================

      public readonly int InstanceID;

      protected readonly ListView ListView;

      private int height;

      // === Constructors ===============================================================

      public ListViewItem(ListView listView, string path)
      {
         this.ListView = listView;
         this.Path = path;
         this.Name = path;
         this.InstanceID = this.Name.GetHashCode();
      }

      // === Properties =================================================================

      public List<ListViewItem> Children { get; set; }

      public int ClickCount { get; set; }

      public int Depth { get; set; }

      public bool Expanded { get; set; }

      public bool HasChildren
      {
         get { return this.Children != null && this.Children.Count > 0; }
      }

      public bool HasVisibleChildren
      {
         get { return this.Children != null && this.Children.Count > 0; }
      }

      public int Height
      {
         get
         {
            if (this.height == 0)
            {
               this.height = this.CalculateHeight();
            }

            return this.height;
         }
      }

      public bool Hidden { get; set; }

      public string Name { get; set; }

      public ListViewItem Parent { get; set; }

      public string Path { get; private set; }

      // ListView row number (changes whenever the list size changes)
      // TODO: remove this when it is no longer needed
      public int Row { get; set; }

      public Rect Position { get; set; }

      public bool Selected { get; set; }

      public bool Visible
      {
         get
         {
            return !this.Hidden;
         }
      }

      // === Indexers ===================================================================

      // === Methods ====================================================================

      public virtual void Draw(ref Rect itemRowRect)
      {
         // TODO: TOP PRIORITY ... Delegate this to the subclass ListViewItemScript
         // All row drawing should take place there, including the foldouts, selected highlights, and column cells.
         // Mouse input related to row selection and GUI buttons should be handled there as well.

         // TODO: This method should be abstract and required to be implemented by subclasses.




         var rect = new Rect(itemRowRect);
         itemRowRect.height += this.Height;

         var e = Event.current;
         var isRepaint = e.type == EventType.Repaint;

         var indentWidth = Style.Foldout.padding.left;
         //         this.height = (int)this.style.label.fixedHeight;

         //Debug.Log("Default ListViewItem renderer: " + itemRowRect.ToString() + "\n"
         //            + "ROW: " + this._listView.ItemRow.ToString() + ", RECT: " + itemRowRect.ToString() + "\n");

         if (isRepaint)
         {
            if (this.Selected)
            {
               Style.Label.Draw(this.Position, GUIContent.none, false, false, true, this.ListView.HasFocus);
            }
         }

         if (this.HasVisibleChildren)
         {
            //Debug.Log("PARENT: " + this.Name + "\n");

            //// foldout toggle
            //rect.x = 2 + (this.Depth * indentWidth);
            //rect.y--;
            //rect.width = indentWidth;

            //this.Expanded = GUI.Toggle(rect, this.Expanded, GUIContent.none, Style.Foldout);

            //rect.x = this.Depth * indentWidth;
            //rect.y++;
            //rect.width = this.Position.width;

            //if (isRepaint)
            //{
            //   Style.Label.Draw(rect, this.Name, false, false, false, false);
            //}

            var rectToggle = this.Position;
            rectToggle.xMin = 2 + (this.Depth * indentWidth);
            rectToggle.width = 20;

            rectToggle.x += 20;

            this.Expanded = GUI.Toggle(rectToggle, this.Expanded, GUIContent.none, Style.Foldout);

            var rectRow = this.Position;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (GUI.Button(rectRow, Ellipsis.Compact(this.Name, Style.Label, rectRow, Ellipsis.Format.Middle), GUI.skin.label))
            {
               this.ListView.HandleMouseInput(this);
            }



            //var rectToggle = this.Position;
            //rectToggle.xMin = 2 + (this.Depth * indentWidth);
            //rectToggle.width = 20;

            //rect

            //this.Expanded = GUI.Toggle(rectToggle, this.Expanded, GUIContent.none, Style.Foldout);

            //var r2 = this.Position;
            //r2.xMin = rect.xMax;

            //if (e.type == EventType.MouseDown)
            //{
            //   this.ClickCount = Event.current.clickCount;
            //}

            //if (GUI.Button(r2, Ellipsis.Compact(this.Name, Style.Label, r2, Ellipsis.Format.Middle), GUI.skin.label))
            //{
            //   this.ListView.HandleMouseInput(this);
            //}
         }
         else
         {
            rect = this.Position;
            rect.xMin = this.Depth * indentWidth;

            //Style.Label.Draw(rect, Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle), false, false, false, false);
            //if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle)))
            //{
            //   Debug.Log("PRESSED: " + this.Name + "\n");
            //}

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle), GUI.skin.label))
            {
               this.ListView.HandleMouseInput(this);
            }

            //GUI.changed = false;
            //GUI.Toggle(
            //   rect,
            //   this.Selected,
            //   Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle),
            //   GUI.skin.label);
            //if (GUI.changed)
            //{
            //   GUI.changed = false;

            //   this.ListView.HandleMouseInput(this);
            //}
         }

         //uScriptGUI.DebugBox(this.Position, Color.blue, this.Name);
      }

      protected virtual int CalculateHeight()
      {
         return (int)Style.Label.fixedHeight;
      }

      // === Structs ====================================================================

      // === Classes ====================================================================

      private static class Style
      {
         static Style()
         {
            Foldout = new GUIStyle("IN Foldout");

            Label = new GUIStyle("PR Label") { contentOffset = new Vector2(0, -1) };
         }

         public static GUIStyle Foldout { get; private set; }

         public static GUIStyle Label { get; private set; }
      }

      // ================================================================================
      // ================================================================================
      // ================================================================================

      // Methods

//   public virtual void Draw() { }
      public void Draw(int top, int width)
      {
         //Event e = Event.current;
         //bool isRepaint = e.type == EventType.Repaint;

//         int indentWidth = this.style.foldout.padding.left;
//         this.height = (int)this.style.label.fixedHeight;

         uScriptGUI.DebugBox(this.Position, Color.green, this.Name);

/*
         this.rowRect = new Rect(0, this.row * this.height, this._listView.MinRowWidth, this.height);
         Rect rect = this.rowRect;

         bool shouldDrawRow = (this._listView.ItemRow >= this._listView.FirstVisibleRow && this._listView.ItemRow <= this._listView.LastVisibleRow);

         if (shouldDrawRow)
         {
            if (isRepaint)
            {
               // Draw row background
               GUIStyle rowStyle = (this.selected ? this.style.rowSelected : (this._listView.ItemRow % 2 == 0 ? this.style.rowEven : this.style.rowOdd));

               // isHover, isActive, on, hasKeyboardFocus
               //    GREY (on)
               //    BLUE (on, hasKeyboardFocus)
               //    RING (isHover, isActive)
               rowStyle.Draw(this.rowRect, GUIContent.none, false, false, true, this._listView.hasFocus);
            }

            int COLUMN_PADDING = 2;

            if (this.hasVisibleChildren)
            {
               // foldout toggle
               rect.x = 2 + (this.depth * indentWidth);
               rect.y--;
               rect.width = indentWidth;
               this.expanded = GUI.Toggle(rect, this.expanded, GUIContent.none, this.style.foldout);

               rect.x = (this.depth * indentWidth);
               rect.y++;
               rect.width = this.rowRect.width;

               if (isRepaint)
               {
                  // icon
                  this.style.icon.Draw(rect, this.Content.iconFolder, false, false, false, false);
                  rect.xMin += 16;

                  // text
                  this.style.label.Draw(rect, this.name, false, false, false, false);
               }
            }
            else
            {
               if (isRepaint)
               {
                  rect = this.rowRect;

                  // "Graph" Column
                  rect.width = Columns[0].Width - COLUMN_PADDING;
                  rect.xMin = (this.depth * indentWidth);

                  // icon
                  this.style.icon.Draw(rect, this.Content.iconScript, false, false, false, false);
                  rect.xMin += 16;

                  // text
                  this.style.label.Draw(rect, Ellipsis.Compact(this.name, this.style.label, rect, Ellipsis.Format.Middle), false, false, false, false);

                  // "Scene" Column
                  rect.x += rect.width + (COLUMN_PADDING * 2);
                  rect.width = Columns[1].Width - (COLUMN_PADDING * 2);

                  // filePathAndName
                  this.style.label.Draw(rect, this.instanceID.ToString(), false, false, false, false);
                  //               this.Style.label.Draw(rect, filePathAndName, false, false, false, false);
                  //               this.Style.label.Draw(rect, guid.ToString(), false, false, false, false);

                  // "State" Column
                  rect.x += rect.width + (COLUMN_PADDING * 2);
                  rect.width = Columns[2].Width - (COLUMN_PADDING * 2);

                  // scriptStateIcon
                  GUI.skin.label.Draw(rect, this.Content.iconSourceRelease, false, false, false, false);
               }
            }
         }

         this.row = this._listView.ItemRow++;

         if (shouldDrawRow)
         {
            if (this.rowRect.Contains(e.mousePosition))
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
                           if (this.hasVisibleChildren)
                           {
                              this.expanded = !this.expanded;
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

         if (this.hasVisibleChildren)
         {
            if (this.expanded)
            {
               foreach (ListViewItem child in this.children)
               {
//               child.Draw();
                  DrawItem(child);
               }
            }
            else if (shouldDrawRow && isRepaint)
            {
               // descendant count
               rect.xMin += 100;
               this.style.label.Draw(rect, "(" + this.children.Count.ToString() + ")", false, false, false, false);
            }
         }
*/

//         Event e = Event.current;
//         bool isRepaint = e.type == EventType.Repaint;
//
//         int indentWidth = _listView.Style.foldout.padding.left;
//         height = (int)_listView.Style.label.fixedHeight;
//
//         Rect rowRect = new Rect(0, row * height, _listView.MinRowWidth, height);
//         Rect rect = rowRect;
//
//         bool shouldDrawRow = (_listView.ItemRow >= _listView.FirstVisibleRow && _listView.ItemRow <= _listView.LastVisibleRow);
//
//         if (shouldDrawRow)
//         {
//            if (isRepaint)
//            {
//               // Draw row background
//               GUIStyle rowStyle = (selected ? _listView.Style.rowSelected : (_listView.ItemRow % 2 == 0 ? _listView.Style.rowEven : _listView.Style.rowOdd));
//   
//               // isHover, isActive, on, hasKeyboardFocus
//               //    GREY (on)
//               //    BLUE (on, hasKeyboardFocus)
//               //    RING (isHover, isActive)
//               rowStyle.Draw(rowRect, GUIContent.none, false, false, true, _listView.hasFocus);
//            }
//   
//            if (hasVisibleChildren)
//            {
//               // foldout toggle
//               rect.x = 2 + (depth * indentWidth);
//               rect.y--;
//               rect.width = indentWidth;
//               expanded = GUI.Toggle(rect, expanded, GUIContent.none, _listView.Style.foldout);
//
//               rect.x = (depth * indentWidth);
//               rect.y++;
//               rect.width = rowRect.width;
//
//               if (isRepaint)
//               {
//                  // icon
//                  _listView.Style.icon.Draw(rect, _listView.Content.iconFolder, false, false, false, false);
//                  rect.xMin += 16;
//
//                  // text
//                  _listView.Style.label.Draw(rect, name, false, false, false, false);
//               }
//            }
//            else
//            {
//               if (isRepaint)
//               {
//                  rect = rowRect;
//                  rect.xMin = (depth * indentWidth);
//
//                  // icon
//                  _listView.Style.icon.Draw(rect, _listView.Content.iconScript, false, false, false, false);
//                  rect.xMin += 16;
//
//                  // text
//                  _listView.Style.label.Draw(rect, name, false, false, false, false);
//
////               // filePathAndName
////               rect.xMin += 100;
////               _listView.Style.label.Draw(rect, filePathAndName, false, false, false, false);
////               _listView.Style.label.Draw(rect, guid.ToString(), false, false, false, false);
//
//                  // filePathAndName
//                  rect.xMin += 100;
//                  _listView.Style.label.Draw(rect, instanceID.ToString(), false, false, false, false);
//
//                  // scriptStateIcon
//
//               }
//            }
//         }
//
//         row = _listView.ItemRow++;
//
//         if (shouldDrawRow)
//         {
//            if (rowRect.Contains(e.mousePosition))
//            {
//               if (e.type == EventType.MouseDown)
//               {
//                  if (e.button == 0)
//                  {
//                     if (EditorGUI.actionKey && _listView.MultiSelectEnabled)
//                     {
//                        // (Control or Command) + Left-Click
//                        _listView.ClickToggleSelection(this);
//                        e.Use();
//                     }
//                     else if (e.modifiers == EventModifiers.Alt)
//                     {
//                        // (Alt or Option) + Left-Click
//                        Debug.Log("ALT LEFT-CLICK" + "\n");
//                        // Ping source
//                        e.Use();
//                     }
//                     else if (e.modifiers != EventModifiers.Control)
//                     {
//                        // Left-Click
//                        if (e.clickCount == 1)
//                        {
//                           _listView.ClickNewSelection(this);
//                        }
//                        else if (e.clickCount == 2)
//                        {
//                           if (hasVisibleChildren)
//                           {
//                              expanded = !expanded;
//                              _listView.EditorWindow.Repaint();
//                           }
//                           else
//                           {
//                              Debug.Log("DOUBLE CLICK - OPEN FILE\n");
//                           }
//                        }
//                        e.Use();
//                     }
//                  }
//                  else if (e.button == 2)
//                  {
//                     // Middle-Click
//                     Debug.Log("MIDDLE-CLICK" + "\n");
//                     // Ping source
//                     e.Use();
//                  }
//               }
//               else if (e.type == EventType.ContextClick)
//               {
//                  Debug.Log("CONTEXT CLICK\n" + "BUTTON: " + e.button.ToString() + ", MODIFIERS: " + e.modifiers.ToString());
//                  _listView.DrawContextMenu(this);
//                  e.Use();
//               }
////                  // TODO: successive left and right clicks are combined in calculating the clickCount.
////                  //       They should be separate. We should be able to quickly left click an item, and
////                  //       then right click it to open the context menu.
//            }
//
////         Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");
//
//
////                else
////                {
////                    this.EndNameEditing();
////                    this.m_CurrentDragSelectionIDs = this.GetSelection(newHierarchyProperty, true);
////                    GUIUtility.hotControl = controlID;
////                    GUIUtility.keyboardControl = 0;
////                    DragAndDropDelay stateObject = (DragAndDropDelay) GUIUtility.GetStateObject(typeof(DragAndDropDelay), controlID);
////                    stateObject.mouseDownPosition = Event.current.mousePosition;
////                }
////                current.Use();
////            }
//
//
//         }
//
//         if (hasVisibleChildren)
//         {
//            if (expanded)
//            {
//               foreach (ListViewItem item in children)
//               {
//                  this.Draw();
//               }
//            }
//            else if (shouldDrawRow && isRepaint)
//            {
//               // descendant count
//               rect.xMin += 100;
//               _listView.Style.label.Draw(rect, "(" + children.Count.ToString() + ")", false, false, false, false);
//            }
//         }
      }
   }

//public class ScriptListViewItem : ListViewItem
//{
//   public string filePathAndName;
//
//   public ScriptListViewItem(ListView listView, string scriptName, string filePath) : base (listView, scriptName)
//   {
////      this._listView = listView;
////      this.text = scriptName;
//      this.filePathAndName = filePath;
//   }
//
//   public override void Draw()
//   {
//      Event e = Event.current;
//      bool isRepaint = e.type == EventType.Repaint;
//
//      int indentWidth = _listView.Style.foldout.padding.left;
//      height = (int)_listView.Style.label.fixedHeight;
//
//      Rect rowRect = new Rect(0, row * height, _listView.MinRowWidth, height);
//      Rect rect = rowRect;
//
//      bool shouldDrawRow = (_listView.ItemRow >= _listView.FirstVisibleRow && _listView.ItemRow <= _listView.LastVisibleRow);
//
//      if (shouldDrawRow)
//      {
//         if (isRepaint)
//         {
//            // Draw row background
//            GUIStyle rowStyle = (selected ? _listView.Style.rowSelected : (_listView.ItemRow % 2 == 0 ? _listView.Style.rowEven : _listView.Style.rowOdd));
//   
//            // isHover, isActive, on, hasKeyboardFocus
//            //    GREY (on)
//            //    BLUE (on, hasKeyboardFocus)
//            //    RING (isHover, isActive)
//            rowStyle.Draw(rowRect, GUIContent.none, false, false, true, _listView.hasFocus);
//         }
//   
//         if (hasVisibleChildren)
//         {
//            // foldout toggle
//            rect.x = 2 + (depth * indentWidth);
//            rect.y--;
//            rect.width = indentWidth;
//            expanded = GUI.Toggle(rect, expanded, GUIContent.none, _listView.Style.foldout);
//
//            rect.x = (depth * indentWidth);
//            rect.y++;
//            rect.width = rowRect.width;
//
//            if (isRepaint)
//            {
//               // icon
//               _listView.Style.icon.Draw(rect, _listView.Content.iconFolder, false, false, false, false);
//               rect.xMin += 16;
//
//               // text
//               _listView.Style.label.Draw(rect, text, false, false, false, false);
//            }
//         }
//         else
//         {
//            if (isRepaint)
//            {
//               rect = rowRect;
//               rect.xMin = (depth * indentWidth);
//
//               // icon
//               _listView.Style.icon.Draw(rect, _listView.Content.iconScript, false, false, false, false);
//               rect.xMin += 16;
//
//               // text
//               _listView.Style.label.Draw(rect, text, false, false, false, false);
//
//               // filePathAndName
//               rect.xMin += 100;
//               _listView.Style.label.Draw(rect, filePathAndName, false, false, false, false);
////               _listView.Style.label.Draw(rect, guid.ToString(), false, false, false, false);
//
//               // filePathAndName
//               rect.xMin += 100;
//               _listView.Style.label.Draw(rect, instanceID.ToString(), false, false, false, false);
//
//               // scriptStateIcon
//
//            }
//         }
//      }
//
//      row = _listView.ItemRow++;
//
//      if (shouldDrawRow)
//      {
//         if (rowRect.Contains(e.mousePosition))
//         {
//            if (e.type == EventType.MouseDown)
//            {
//               if (e.button == 0)
//               {
//                  if (EditorGUI.actionKey && _listView.MultiSelectEnabled)
//                  {
//                     // (Control or Command) + Left-Click
//                     _listView.ToggleSelection(this);
//                     e.Use();
//                  }
//                  else if (e.modifiers == EventModifiers.Alt)
//                  {
//                     // (Alt or Option) + Left-Click
//                     Debug.Log("ALT LEFT-CLICK" + "\n");
//                     // Ping source
//                     e.Use();
//                  }
//                  else if (e.modifiers != EventModifiers.Control)
//                  {
//                     // Left-Click
//                     if (e.clickCount == 1)
//                     {
//                        _listView.NewSelection(this);
//                     }
//                     else if (e.clickCount == 2)
//                     {
//                        if (hasVisibleChildren)
//                        {
//                           expanded = !expanded;
//                           _listView.EditorWindow.Repaint();
//                        }
//                        else
//                        {
//                           Debug.Log("DOUBLE CLICK - OPEN FILE\n");
//                        }
//                     }
//                     e.Use();
//                  }
//               }
//               else if (e.button == 2)
//               {
//                  // Middle-Click
//                  Debug.Log("MIDDLE-CLICK" + "\n");
//                  // Ping source
//                  e.Use();
//               }
//            }
//            else if (e.type == EventType.ContextClick)
//            {
//               Debug.Log("CONTEXT CLICK\n" + "BUTTON: " + e.button.ToString() + ", MODIFIERS: " + e.modifiers.ToString());
//               _listView.DrawContextMenu(this);
//               e.Use();
//            }
////                  // TODO: successive left and right clicks are combined in calculating the clickCount.
////                  //       They should be separate. We should be able to quickly left click an item, and
////                  //       then right click it to open the context menu.
//         }
//
////         Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");
//
//
////                else
////                {
////                    this.EndNameEditing();
////                    this.m_CurrentDragSelectionIDs = this.GetSelection(newHierarchyProperty, true);
////                    GUIUtility.hotControl = controlID;
////                    GUIUtility.keyboardControl = 0;
////                    DragAndDropDelay stateObject = (DragAndDropDelay) GUIUtility.GetStateObject(typeof(DragAndDropDelay), controlID);
////                    stateObject.mouseDownPosition = Event.current.mousePosition;
////                }
////                current.Use();
////            }
//
//
//      }
//
//      if (hasVisibleChildren)
//      {
//         if (expanded)
//         {
//            foreach (ListViewItem item in children)
//            {
//               this.Draw();
//            }
//         }
//         else if (shouldDrawRow && isRepaint)
//         {
//            // descendant count
//            rect.xMin += 100;
//            _listView.Style.label.Draw(rect, "(" + children.Count.ToString() + ")", false, false, false, false);
//         }
//      }
//   }
//}
}
