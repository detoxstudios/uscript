// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Property type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   public static class Property
   {
      public class State
      {
         public readonly bool IsLocked;

         public readonly bool IsReadOnly;

         public State(bool isSocketExposed, bool isLocked, bool isReadOnly)
         {
            this.IsSocketExposed = isSocketExposed;
            this.IsLocked = isLocked;
            this.IsReadOnly = isReadOnly;
         }

         public bool IsSocketExposed { get; set; }
      }
   }
}
