// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Toggles the active state of a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Action/Toggle")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a GameObject.")]
[NodeDescription("Toggles the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Toggle")]
public class uScriptAct_Toggle : uScriptLogic
{

   public bool Out { get { return true; } }

   [FriendlyName("Turn On")]
   public void TurnOn(GameObject[] Target, [FriendlyName("Ignore Children")] bool IgnoreChildren)
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

   }





}
