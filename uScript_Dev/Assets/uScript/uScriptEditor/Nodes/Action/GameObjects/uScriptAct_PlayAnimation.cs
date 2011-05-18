// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Play the specified animation on the target object. Animation must exist in the GameObject's AnimationClip.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Play the specified animation on the target object.")]
[NodeDescription("Play the specified animation on the target object. Animation must exist in the GameObject's AnimationClip.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Play Animation")]
public class uScriptAct_PlayAnimation : uScriptLogic
{
   private GameObject m_GameObject = null;
   private string     m_Animation  = null;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Finished")]
   public event uScriptEventHandler Finished;

   public void In(GameObject[] Target, string Animation, [FriendlyName("Speed Factor")] float SpeedFactor, [FriendlyName("Stop Other Animation")] bool StopOtherAnimations)
   {
      m_GameObject = null;

      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            //only save one so we can ask about the animation state
            //i don't need to save all of them in the array
            m_GameObject = currentTarget;
            m_Animation  = Animation;

            if (SpeedFactor == 0F)
            {
               currentTarget.animation[Animation].speed = 1.0F;
            }
            else
            {
               
               currentTarget.animation[Animation].speed = SpeedFactor;
            }

            if (StopOtherAnimations)
            {
               currentTarget.animation.Play(PlayMode.StopAll);
            }

            if (SpeedFactor < 0)
            {
               // Needed to play in reverse with a negative speed
               currentTarget.animation[Animation].time = currentTarget.animation[Animation].length;
            }

            currentTarget.animation[Animation].wrapMode = WrapMode.Once;
            currentTarget.animation.Play(Animation);
         }
      }
   }

   public override void Update()
   {
      if ( null != m_GameObject )
      {
         if ( false == m_GameObject.animation.IsPlaying(m_Animation) )
         {
            m_GameObject = null;

            if ( null != Finished ) Finished( this, new System.EventArgs( ) );
         }
      }
   }
}