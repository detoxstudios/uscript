namespace Detox.Editor.GUI
{
   using System.Collections.Generic;
   using UnityEditor;
   using UnityEngine;

   public delegate void ListViewItemDraw(ListViewItem item);

   public class ListViewItem
   {
      // Variables
      protected readonly ListView _listView;

      public ListView listView { get; private set; }

      public readonly int instanceID;
      public readonly string path;
      public string name;
      public ListViewItemData data;
      public bool selected;
      public int depth;
      public bool expanded;
      public bool hidden;
      public ListViewItem parent;
      public List<ListViewItem> children;

//   public int[] ancestors;
      public int row;    // ListView row number (changes whenever the list size changes)
      public int height;
      public Rect rowRect;

      // Properties
      public bool hasChildren { get { return (children != null && children.Count > 0); } }

      public bool hasVisibleChildren { get { return (children != null && children.Count > 0); } }

      public bool visible { get { return !hidden; } }

      // Methods
      public ListViewItem(ListView listView, string path) : this(listView, path, null)
      {
      }

      public ListViewItem(ListView listView, string path, ListViewItemData data)
      {
         this._listView = listView;
         this.path = path;
         this.name = path;
         this.instanceID = name.GetHashCode();

         this.data = data;
      }


//   public virtual void Draw() { }
      public void Draw()
      {
         Event e = Event.current;
         bool isRepaint = e.type == EventType.Repaint;

         int indentWidth = _listView.Style.foldout.padding.left;
         height = (int)_listView.Style.label.fixedHeight;

         Rect rowRect = new Rect(0, row * height, _listView.MinRowWidth, height);
         Rect rect = rowRect;

         bool shouldDrawRow = (_listView.ItemRow >= _listView.FirstVisibleRow && _listView.ItemRow <= _listView.LastVisibleRow);

         if (shouldDrawRow)
         {
            if (isRepaint)
            {
               // Draw row background
               GUIStyle rowStyle = (selected ? _listView.Style.rowSelected : (_listView.ItemRow % 2 == 0 ? _listView.Style.rowEven : _listView.Style.rowOdd));
   
               // isHover, isActive, on, hasKeyboardFocus
               //    GREY (on)
               //    BLUE (on, hasKeyboardFocus)
               //    RING (isHover, isActive)
               rowStyle.Draw(rowRect, GUIContent.none, false, false, true, _listView.hasFocus);
            }
   
            if (hasVisibleChildren)
            {
               // foldout toggle
               rect.x = 2 + (depth * indentWidth);
               rect.y--;
               rect.width = indentWidth;
               expanded = GUI.Toggle(rect, expanded, GUIContent.none, _listView.Style.foldout);

               rect.x = (depth * indentWidth);
               rect.y++;
               rect.width = rowRect.width;

               if (isRepaint)
               {
                  // icon
                  _listView.Style.icon.Draw(rect, _listView.Content.iconFolder, false, false, false, false);
                  rect.xMin += 16;

                  // text
                  _listView.Style.label.Draw(rect, name, false, false, false, false);
               }
            }
            else
            {
               if (isRepaint)
               {
                  rect = rowRect;
                  rect.xMin = (depth * indentWidth);

                  // icon
                  _listView.Style.icon.Draw(rect, _listView.Content.iconScript, false, false, false, false);
                  rect.xMin += 16;

                  // text
                  _listView.Style.label.Draw(rect, name, false, false, false, false);

//               // filePathAndName
//               rect.xMin += 100;
//               _listView.Style.label.Draw(rect, filePathAndName, false, false, false, false);
//               _listView.Style.label.Draw(rect, guid.ToString(), false, false, false, false);

                  // filePathAndName
                  rect.xMin += 100;
                  _listView.Style.label.Draw(rect, instanceID.ToString(), false, false, false, false);

                  // scriptStateIcon

               }
            }
         }

         row = _listView.ItemRow++;

         if (shouldDrawRow)
         {
            if (rowRect.Contains(e.mousePosition))
            {
               if (e.type == EventType.MouseDown)
               {
                  if (e.button == 0)
                  {
                     if (EditorGUI.actionKey && _listView.MultiSelectEnabled)
                     {
                        // (Control or Command) + Left-Click
                        _listView.ClickToggleSelection(this);
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
                           _listView.ClickNewSelection(this);
                        }
                        else if (e.clickCount == 2)
                        {
                           if (hasVisibleChildren)
                           {
                              expanded = !expanded;
                              _listView.EditorWindow.Repaint();
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
                  _listView.DrawContextMenu(this);
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

         if (hasVisibleChildren)
         {
            if (expanded)
            {
               foreach (ListViewItem item in children)
               {
                  item.Draw();
               }
            }
            else if (shouldDrawRow && isRepaint)
            {
               // descendant count
               rect.xMin += 100;
               _listView.Style.label.Draw(rect, "(" + children.Count.ToString() + ")", false, false, false, false);
            }
         }
      }
   }

//
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
//               item.Draw();
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
