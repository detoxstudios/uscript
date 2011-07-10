// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Removes the specified Component from the target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Removes the specified Component from the target GameObject.")]
[NodeDescription("Removes the specified Component from the target GameObject.\n \nTarget: The target GameObject(s) to destroy the components of.\nComponent Name: The name of the component to destroy from all target GameObject(s).\nDelay: The time to wait before destroying the target component(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Destroy_Component")]

[FriendlyName("Destroy Component")]
public class uScriptAct_DestroyComponent : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName, [FriendlyName("Delay"), SocketState(false, false)]float DelayTime)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               Component component = currentTarget.GetComponent(currentComponentName);
               if (component != null)
               {
                  if (DelayTime > 0F)
                  {
                     Destroy(component, DelayTime);
                  }
                  else
                  {
                     Destroy(component);
                  }
               }
               else
               {
                  uScriptDebug.Log("Component '" + currentComponentName + "' not found on GameObject '" + currentTarget.name + "'.", uScriptDebug.Type.Warning);
               }
            }
         }
      }

   }
}