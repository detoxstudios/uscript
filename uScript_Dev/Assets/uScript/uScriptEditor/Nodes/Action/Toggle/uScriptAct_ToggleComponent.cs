// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Toggles the active state of a component on the Target GameObjects.

using UnityEngine;
using System.Collections;

[NodePath("Action/Toggle")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a component on the Target GameObjects.")]
[NodeDescription("Toggles the active state of a component on the Target GameObjects. Ignores GameObjects missing the specified component.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Toggle Component")]
public class uScriptAct_ToggleComponent : uScriptLogic
{
   [FriendlyName("Out (Turn On)")]
   public event System.EventHandler OnOut;

   [FriendlyName("Out (Turn Off)")]
   public event System.EventHandler OffOut;

   [FriendlyName("Out (Toggle)")]
   public event System.EventHandler ToggleOut;

   public bool Out { get { return true; } }

   [FriendlyName("Turn On")]
   public void TurnOn( GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName )
   {

      foreach ( GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentTarget.GetComponent(currentComponentName))
               {
                  ((Behaviour)currentTarget.GetComponent(currentComponentName)).enabled = true;
               }
            }
         }
      }

      OnOut(this, new System.EventArgs());

   }

   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName)
   {

      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentTarget.GetComponent(currentComponentName))
               {
                  ((Behaviour)currentTarget.GetComponent(currentComponentName)).enabled = false;
               }
            }
         }
      }

      OffOut(this, new System.EventArgs());

   }

   [FriendlyName("Toggle")]
   public void Toggle(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName)
   {

      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentTarget.GetComponent(currentComponentName))
               {

                  if ( ((Behaviour)currentTarget.GetComponent(currentComponentName)).enabled )
                  {
                     ((Behaviour)currentTarget.GetComponent(currentComponentName)).enabled = false;
                  }
                  else
                  {
                     ((Behaviour)currentTarget.GetComponent(currentComponentName)).enabled = true;
                  }
               }
            }
         }
      }

      ToggleOut(this, new System.EventArgs());

   }





}
