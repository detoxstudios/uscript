// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Toggle")]

[FriendlyName("Toggle", "Toggles the active state of a GameObject.")]
public class uScriptAct_Toggle : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   [FriendlyName("Turned On")]
   public event System.EventHandler OnOut;

   [FriendlyName("Turned Off")]
   public event System.EventHandler OffOut;

   [FriendlyName("Toggled")]
   public event System.EventHandler ToggleOut;

   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn On")]
   public void TurnOn(GameObject[] Target, bool IgnoreChildren)
   {
      foreach ( GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (false == currentTarget.active)
               {
                  currentTarget.active = true;
               }
            }
            else
            {
               if (false == currentTarget.active)
               {
                  currentTarget.SetActiveRecursively(true);
               }
            }
         }
      }

      if ( null != OnOut ) OnOut(this, new System.EventArgs());
   }

   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, bool IgnoreChildren)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (currentTarget.active)
               {
                  currentTarget.active = false;
               }
            }
            else
            {
               if (currentTarget.active)
               {
                  currentTarget.SetActiveRecursively(false);
               }
            }
         }
      }

      if ( null != OffOut ) OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(
      [FriendlyName("Target", "The Target GameObject(s) to toggle state on.")]
      GameObject[] Target,

      [FriendlyName("Ignore Children", "If True, the state change will not affect the Target's children.")]
      [SocketState(false, false)]
      bool IgnoreChildren
      )
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (currentTarget.active)
               {
                  currentTarget.active = false;
               }
               else
               {
                  currentTarget.active = true;
               }
            }
            else
            {
               if (currentTarget.active)
               {
                  currentTarget.SetActiveRecursively(false);
               }
               else
               {
                  currentTarget.SetActiveRecursively(true);
               }
            }
         }
      }

      if ( null != ToggleOut ) ToggleOut(this, new System.EventArgs());
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
