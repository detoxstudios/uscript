// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewColumn.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewColumn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;

   using UnityEngine;

   public class ListViewColumn
   {
      // Constant Fields
      private const int AbsoluteMinWidth = 18;
      private const int AbsoluteMaxWidth = 2000;

      // Fields
      private int maxWidth;
      private int minWidth;
      private float width;

      // Constructors
      public ListViewColumn(string id)
      {
         this.ID = id;
      }

      // Enums
      public enum LayoutMethodOption
      {
         Fixed,
         Fluid,
         Custom
      }

      // Properties
      public GUIContent Content { get; set; }

      public bool IsSelectable { get; set; }

      public bool IsSortDescending { get; set; }

      public bool IsSortDirectionFixed { get; set; }

      public bool IsFixed
      {
         get
         {
            return this.LayoutMethod == LayoutMethodOption.Fixed;
         }
      }

      public bool IsFluid
      {
         get
         {
            return this.LayoutMethod == LayoutMethodOption.Fluid;
         }
      }

      public bool IsResizeable
      {
         get
         {
            return this.LayoutMethod == LayoutMethodOption.Custom;
         }
      }

      ////public ListView ListView { get; private set; }

      public LayoutMethodOption LayoutMethod { get; set; }

      public int MaxWidth
      {
         get
         {
            return this.maxWidth;
         }

         set
         {
            this.maxWidth = Math.Min(value, AbsoluteMaxWidth);
            if (this.minWidth > this.maxWidth)
            {
               this.MinWidth = this.maxWidth;
            }
            else
            {
               this.Width = this.width;
            }
         }
      }

      public int MinWidth
      {
         get
         {
            return this.minWidth;
         }

         set
         {
            this.minWidth = Math.Max(value, AbsoluteMinWidth);
            if (this.maxWidth < this.minWidth)
            {
               this.MaxWidth = this.minWidth;
            }
            else
            {
               this.Width = this.width;
            }
         }
      }

      public string ID { get; private set; }

      public Rect Position { get; set; }

      public float Width
      {
         get
         {
            return this.width;
         }

         set
         {
            //this.width = Math.Max(this.MinWidth, Math.Min(this.MaxWidth, value));
            this.width = Math.Max(this.MinWidth, value);
         }
      }

      public float DynamicWidth { get; set; }

      // Indexers

      // Methods

      // Structs

      // Classes

      // TODO: setup flags or an enum to handle
      //    STRETCH, FIXED_WIDTH, RESIZABLE, LOCK-RIGHT (or have a property for this ... LastColumnIsRightJustified)

      // If the column needs to determine which style to use, store it here.
      // Perhaps the header object itself will be referenced by the column to
      // see how the column should behave (sort direction, etc)

      // Hopefully we can just use the GUIContent, but if we need more precise
      // positioning of labels and icons, they can be handled separately.

      // TODO: Add support for column texture and texture/label options

      // TODO: Add support for column reordering
      // TODO: Add support for column sorting

      // TODO: Add support for expanded width on the right-most column
   }
}
