// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_Component_Active")]

[FriendlyName("Is Component Active", "Gets the active state of a Component.")]
public class uScriptAct_IsComponentActive : uScriptLogic
{
   private bool m_IsActive;
   
   public bool Out { get { return true; } }
   
   public bool Active   { get { return m_IsActive; } }
   public bool Inactive { get { return !m_IsActive; } }

   public void In(
      [FriendlyName("Target", "GameObject which contains the component.")]
      GameObject Target,
      [FriendlyName("Component", "Component type which to check.")]
      string component
      )
   {
      Component comp = Target.GetComponent( component );

      m_IsActive = false;
      
      if (null != comp )
      {
         if (typeof(Behaviour).IsAssignableFrom(comp.GetType()))
         {
            m_IsActive = ((Behaviour)comp).enabled;
         }
         else if (typeof(ParticleEmitter).IsAssignableFrom(comp.GetType()))
         {
            m_IsActive = ((ParticleEmitter)comp).enabled;
         }
      }
   }
}

#endif