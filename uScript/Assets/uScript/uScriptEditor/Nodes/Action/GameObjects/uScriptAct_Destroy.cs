// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Destroys the target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Destroys the target GameObject.")]
[NodeDescription("Destroys the target GameObject. Can optionally set a delay.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Destroy")]
public class uScriptAct_Destroy : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Delay")] float DelayTime)
   {

      if (DelayTime > 0F)
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               Destroy(currentTarget, DelayTime);
            }
         }

      }
      else
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               Destroy(currentTarget);
            }
         }
      }

   }
}