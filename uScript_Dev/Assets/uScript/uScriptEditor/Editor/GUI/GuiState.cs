// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuiState.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;

   using UnityEngine;

   using GUI = UnityEngine.GUI;

   public class GuiState
   {
      public readonly Func<bool> EnableCondition;

      private readonly Stack<bool> storedEnableState = new Stack<bool>();

      public GuiState()
         : this(null)
      {
      }

      public GuiState(Func<bool> enableCondition)
      {
         this.EnableCondition = enableCondition;
         this.Enable();
      }

      /// <summary>
      /// Gets or sets a value indicating whether the GUI is enabled. This method should
      /// be called instead of GUI.enabled when the state needs to change during OnGUI.
      /// </summary>
      public bool Enabled
      {
         get
         {
            return GUI.enabled;
         }

         set
         {
            if (value)
            {
               this.Enable();

            }
            else
            {
               this.Disable();
            }
         }
      }

      public void Disable()
      {
         GUI.enabled = false;
      }

      public void Enable()
      {
         if (GUI.enabled)
         {
            return;
         }

         // Only enable if the conditions are right for the EditorWindow that instantiated this object
         GUI.enabled = this.EnableCondition == null || this.EnableCondition();
      }

      public void RestoreState()
      {
         if (this.storedEnableState.Count < 1)
         {
            Debug.LogWarning("There is no GUI.enable state to restore.\n ");
            return;
         }

         GUI.enabled = this.storedEnableState.Pop();
      }

      public void StoreState()
      {
         if (this.storedEnableState.Count == 0)
         {
            this.storedEnableState.Push(GUI.enabled);
         }
         else
         {
            Debug.LogWarning("The GUI.enable state is already being stored.\n");
         }
      }
   }
}
