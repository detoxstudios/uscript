namespace Detox.Editor.GUI
{
   using System;
   using System.Collections;
   using UnityEngine;

   public class ListViewColumn
   {
      // Constant Fields
      private const int MIN_WIDTH = 20;
      private const int MAX_WIDTH = 2000;

      // Fields
      private int _maxWidth;
      private int _minWidth;
      private int _width;
      private Rect _position;

      // Constructors
      public ListViewColumn(string name, GUIContent content, int width, int minWidth, int maxWidth, bool isResizeable)
      {
         Name = name;

         Content = (content != null ? content : GUIContent.none);

         MinWidth = minWidth;
         MaxWidth = maxWidth;
         Width = (width == 0 ? MaxWidth : width);
         IsResizeable = isResizeable;
      }

      // Finalizers (Destructors)

      // Delegates

      // Events

      // Enums

      // Interfaces

      // Properties
      public GUIContent Content { get; private set; }

      public bool IsSortDescending { get; set; }
      public bool IsResizeable { get; set; }

//      public ListView ListView { get; private set; }

      public int MaxWidth
      {
         get { return _maxWidth; }
         set
         {
            _maxWidth = Math.Min(value, MAX_WIDTH);
            if (_minWidth > _maxWidth)
            {
               MinWidth = _maxWidth;
            }
         }
      }

      public int MinWidth
      {
         get { return _minWidth; }
         set
         {
            _minWidth = Math.Max(value, MIN_WIDTH);
            if (_maxWidth < _minWidth)
            {
               MaxWidth = _minWidth;
            }
         }
      }

      public string Name { get; private set; }

      public Rect Position
      {
         get { return _position; }
         set { _position = value; }
      }

      public bool Selectable { get; set; }

      public int Width
      {
         get { return _width; }
         set
         {
            _width = Math.Max(MinWidth, Math.Min(MaxWidth, value));
         }
      }

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
