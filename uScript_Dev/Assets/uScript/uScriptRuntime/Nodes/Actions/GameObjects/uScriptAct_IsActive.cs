// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the active state of a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the active state of a GameObject.")]
[NodeDescription("Gets the active state of a GameObject.\n \nTarget: GameObject to get the active state of.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_Active")]

[FriendlyName("Is GameObject Active")]
public class uScriptAct_IsActive : uScriptLogic
{
   private bool m_IsActive;
   
   public bool Out { get { return true; } }
   
   public bool Active { get { return m_IsActive; } }

   public bool Inactive { get { return !m_IsActive; } }

   public void In(GameObject Target)
   {
      m_IsActive = Target.active;
   }
}