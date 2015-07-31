// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Removes the specified Component from the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Destroy Component", "Removes the specified Component from the target GameObject.")]
public class uScriptAct_DestroyComponent : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject(s) that will be affected."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Component Name", "The name of the component(s) to destroy from all target GameObject(s).")]
      string[] ComponentName,
      
      [FriendlyName("Delay", "The time to wait before destroying the target component(s).")]
      [SocketState(false, false)]
      float DelayTime
      )
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
                     ScriptableObject.Destroy(component, DelayTime);
                  }
                  else
                  {
                     ScriptableObject.Destroy(component);
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