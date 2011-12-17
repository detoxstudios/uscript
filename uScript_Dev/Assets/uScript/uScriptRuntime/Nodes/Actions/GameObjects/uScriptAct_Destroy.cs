// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Destroys the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Destroy")]

[FriendlyName("Destroy", "Destroys the target GameObject.")]
public class uScriptAct_Destroy : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject(s) to destroy.")]
      GameObject[] Target,

      [FriendlyName("Delay", "The time to wait before destroying the target object(s).")]
      [SocketState(false, false)]
      float DelayTime
      )
   {
      if (DelayTime > 0F)
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               ScriptableObject.Destroy(currentTarget, DelayTime);
            }
         }
      }
      else
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               ScriptableObject.Destroy(currentTarget);
            }
         }
      }
   }
}