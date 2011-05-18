// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Removes the specified Component from the target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Removes the specified Component from the target GameObject.")]
[NodeDescription("Removes the specified Component from the target GameObject. Can optionally set a delay.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Destroy Component")]
public class uScriptAct_DestroyComponent : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName, [FriendlyName("Delay")]float DelayTime)
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