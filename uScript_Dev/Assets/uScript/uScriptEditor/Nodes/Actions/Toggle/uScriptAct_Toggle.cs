// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Toggles the active state of a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a GameObject.")]
[NodeDescription("Toggles the active state of a GameObject.\n \nTarget: The Target GameObject(s) to toggle state on.\nIgnore Children: Whether or not to also toggle the children of the Target GameObject(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Toggle")]
public class uScriptAct_Toggle : uScriptLogic
{
   [FriendlyName("Out (Turn On)")]
   public event System.EventHandler OnOut;

   [FriendlyName("Out (Turn Off)")]
   public event System.EventHandler OffOut;

   [FriendlyName("Out (Toggle)")]
   public event System.EventHandler ToggleOut;

   public bool Out { get { return true; } }

   [FriendlyName("Turn On")]
   public void TurnOn(GameObject[] Target, [FriendlyName("Ignore Children"), SocketState(false, false)] bool IgnoreChildren)
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

      OnOut(this, new System.EventArgs());
   }

   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, [FriendlyName("Ignore Children")] bool IgnoreChildren)
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

      OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(GameObject[] Target, [FriendlyName("Ignore Children")] bool IgnoreChildren)
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

      ToggleOut(this, new System.EventArgs());
   }
}
