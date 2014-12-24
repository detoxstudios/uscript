// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewItem.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
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
      public readonly int InstanceID;

      protected readonly ListView ListView;

      private int height;

      public ListViewItem(ListView listView, string itemPath)
      {
         this.ListView = listView;
         this.ItemPath = itemPath;
         this.ItemName = System.IO.Path.GetFileNameWithoutExtension(itemPath);
         this.InstanceID = itemPath.GetHashCode();
      }

      public List<ListViewItem> Children { get; set; }

      public int ClickCount { get; set; }

      public int Depth { get; set; }

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

      public bool IsFiltered { get; set; }

      public bool IsFolder { get; set; }

      public bool IsVisible { get; set; }

      public string ItemName { get; private set; }

      public ListViewItem Parent { get; set; }

      public string ItemPath { get; private set; }

      // ListView row number (changes whenever the list size changes)
      // TODO: remove this when it is no longer needed
      public int Row { get; set; }

      public Rect Position { get; set; }

      public bool Selected { get; set; }

      public virtual void Draw(ref Rect itemRowRect)
      {
         // TODO: TOP PRIORITY ... Delegate this to the subclass ListViewItemScript
         // All row drawing should take place there, including the foldouts, selected highlights, and column cells.
         // Mouse input related to row selection and GUI buttons should be handled there as well.

         // TODO: This method should be abstract and required to be implemented by subclasses.

         itemRowRect.height += this.Height;

         var e = Event.current;
         var isRepaint = e.type == EventType.Repaint;

         var indentWidth = Style.Foldout.padding.left;

         if (isRepaint)
         {
            if (this.Selected)
            {
               Style.Label.Draw(this.Position, GUIContent.none, false, false, true, this.ListView.HasFocus);
            }
         }

         if (this.HasVisibleChildren)
         {
            var rectToggle = this.Position;
            rectToggle.xMin = 2 + (this.Depth * indentWidth);
            rectToggle.width = 20;

            rectToggle.x += 20;

            var originalState = this.ListView.IsFolderExpanded(this);
            if (originalState != GUI.Toggle(rectToggle, originalState, GUIContent.none, Style.Foldout))
            {
               this.ListView.ToggleFolder(this);
            }

            var rectRow = this.Position;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (GUI.Button(rectRow, Ellipsis.Compact(this.ItemName, Style.Label, rectRow, Ellipsis.Format.Middle), GUI.skin.label))
            {
               this.ListView.HandleMouseInput(this);
            }
         }
         else
         {
            Rect rect = this.Position;
            rect.xMin = this.Depth * indentWidth;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (GUI.Button(rect, Ellipsis.Compact(this.ItemName, Style.Label, rect, Ellipsis.Format.Middle), GUI.skin.label))
            {
               this.ListView.HandleMouseInput(this);
            }
         }
      }

      public void Draw(int top, int width)
      {
         uScriptGUI.DebugBox(this.Position, Color.green, this.ItemName);
      }

      protected virtual int CalculateHeight()
      {
         return (int)Style.Label.fixedHeight;
      }

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
   }
}
