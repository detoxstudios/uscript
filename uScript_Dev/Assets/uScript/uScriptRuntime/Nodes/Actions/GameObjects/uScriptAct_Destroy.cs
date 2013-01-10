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
   bool m_GuaranteedOneTick = false;
   bool m_ObjectsDestroyed = false;
   bool m_Out = false;
   private float m_DelayTime = 0.0f;

   public bool Out { get { return m_Out; } }

   [FriendlyName("Objects Destroyed")]
   public bool ObjectsDestroyed { get { return m_ObjectsDestroyed; } }

   public void In(
      [FriendlyName("Target", "The target GameObject(s) to destroy.")]
      GameObject[] Target,

      [FriendlyName("Delay", "The time to wait before destroying the target object(s).")]
      [SocketState(false, false)]
      float DelayTime
      )
   {
      m_Out = true;
      m_ObjectsDestroyed = false;
      m_GuaranteedOneTick = false;

      m_DelayTime = Time.time + DelayTime;

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

   [Driven]
   public bool WaitOneTick()
   {
      m_Out = false;

      if (Time.time <= m_DelayTime) return true;

      //we don't know if the first time will be called
      //in the same update as In, so the first time return
      if (false == m_GuaranteedOneTick) 
      {
         m_GuaranteedOneTick = true;
         return true;
      }
      
      //next return true that objects were destroyed
      //because we know one tick went by
      if (false == m_ObjectsDestroyed)
      {
         m_ObjectsDestroyed = true;
         return true;
      }

      return false;
   }
}