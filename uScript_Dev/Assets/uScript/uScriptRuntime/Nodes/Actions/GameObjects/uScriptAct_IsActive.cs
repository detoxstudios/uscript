// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_Active")]

[FriendlyName("Is GameObject Active", "Gets the active state of a GameObject.")]
public class uScriptAct_IsActive : uScriptLogic
{
   private bool m_IsActive;
   
   public bool Out { get { return true; } }
   
   public bool Active { get { return m_IsActive; } }

   public bool Inactive { get { return !m_IsActive; } }

   public void In(
      [FriendlyName("Target", "GameObject to get the active state of.")]
      GameObject Target
      )
   {
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6
      m_IsActive = Target.active;
#else
		m_IsActive = Target.activeSelf;
#endif
   }
}