// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Destroys the target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Destroys the target GameObject.")]
[NodeDescription("Destroys the target GameObject.\n \nTarget: The target GameObject(s) to destroy.\nDelay: The time to wait before destroying the target object(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Destroy")]

[FriendlyName("Destroy")]
public class uScriptAct_Destroy : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Delay"), SocketState(false, false)] float DelayTime)
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