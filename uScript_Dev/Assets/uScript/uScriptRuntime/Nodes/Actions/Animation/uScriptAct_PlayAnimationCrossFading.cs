// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Blend animations from one to the other.")]
[NodeAuthor("Detox Studios LLC. Original node by Krillbite", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Play Animation (Cross Fading)", "Blend animations from one to the other. Use the Fire Before value to determine when to trigger the Play Next output socket.")]
public class uScriptAct_PlayAnimationCrossFading : uScriptLogic
{
   private GameObject m_GameObject = null;
   private float m_playNextTime = 0.0f;
   private string m_Animation = null;
   private bool m_PlayNextFired = false;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Finished")]
   public event uScriptEventHandler Finished;

   [FriendlyName("Play Next", "Fired when the animation has reached the time remaining specified in Play Next Time.")]
   public event uScriptEventHandler PlayNext;

   public void In(
      [FriendlyName("Target", "The target GameObject to play the animation on."), AutoLinkType(typeof(GameObject))] GameObject[] Target,
      [FriendlyName("Animation", "The name of the animation to play. Animation must exist in the GameObject's AnimationClip.")] string Animation,
      [FriendlyName("Speed Factor", "The speed at which to play the animation."), DefaultValue(1f), SocketState(false, false)] float SpeedFactor,
	   [FriendlyName("Fade Length", "How long (in seconds) the blend should take to reach the Blend Weight"), DefaultValue(1f), SocketState(false, false)] float FadeLength,
      [FriendlyName("Play Next Time", "The time remaining (in seconds) in the current animation to fire the Play Next output socket."), DefaultValue(0.0f), SocketState(false, false)] float PlayNextTime,
      [FriendlyName("Wrap Mode", "Specifies what should happen at the end of the animation."), SocketState(false, false)] WrapMode AnimWrapMode,
      [FriendlyName("Stop Other Animation", "Stop any currently playing animations before playing this one."), DefaultValue(true), SocketState(false, false)] bool StopOtherAnimations
      )
   {
      m_GameObject = null;
      m_playNextTime = PlayNextTime;
      m_PlayNextFired = false;

      foreach ( GameObject currentTarget in Target )
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
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


            currentTarget.animation[Animation].wrapMode = AnimWrapMode;
            currentTarget.animation.CrossFade(Animation, FadeLength);
         }
#else
         if (currentTarget != null)
         {
            //only save one so we can ask about the animation state
            //i don't need to save all of them in the array
            m_GameObject = currentTarget;
            m_Animation  = Animation;

            if (SpeedFactor == 0F)
            {
               currentTarget.GetComponent<Animation>()[Animation].speed = 1.0F;
            }
            else
            {
               currentTarget.GetComponent<Animation>()[Animation].speed = SpeedFactor;
            }

            if (StopOtherAnimations)
            {
               currentTarget.GetComponent<Animation>().Play(PlayMode.StopAll);
            }

            if (SpeedFactor < 0)
            {
               // Needed to play in reverse with a negative speed
               currentTarget.GetComponent<Animation>()[Animation].time = currentTarget.GetComponent<Animation>()[Animation].length;
            }


            currentTarget.GetComponent<Animation>()[Animation].wrapMode = AnimWrapMode;
            currentTarget.GetComponent<Animation>().CrossFade(Animation, FadeLength);
         }
#endif
      }
   }

   public void Update()
   {
      if (m_GameObject != null)
      {
         if (m_playNextTime > 0.0f)
         {
            // Check if play time is longer then the total play length minus pre fire time or if the animation isn't playing.
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            if (m_GameObject.animation[m_Animation].time >= m_GameObject.animation[m_Animation].length - m_playNextTime)
#else
            if (m_GameObject.GetComponent<Animation>()[m_Animation].time >= m_GameObject.GetComponent<Animation>()[m_Animation].length - m_playNextTime)
#endif
            {
               m_GameObject = null;

               if (null != PlayNext)
               {
                  m_PlayNextFired = true;
                  PlayNext(this, new System.EventArgs());
               }
            }
         }

#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         if (m_GameObject != null && false == m_GameObject.animation.IsPlaying(m_Animation))
#else
         if (m_GameObject != null && false == m_GameObject.GetComponent<Animation>().IsPlaying(m_Animation))
#endif
         {
            m_GameObject = null;

            if (null != Finished) Finished(this, new System.EventArgs());

            if ( !m_PlayNextFired && m_playNextTime > 0.0f )
            {
               if (null != PlayNext)
               {
                  m_PlayNextFired = true;
                  PlayNext(this, new System.EventArgs());
               }
            }
         }

      }
   }


#if UNITY_EDITOR
   public override Hashtable EditorDragDrop(object o)
   {
      if (typeof(AnimationClip).IsAssignableFrom(o.GetType()))
      {
         AnimationClip ac = (AnimationClip)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Animation"] = ac.name;

         return hashtable;
      }
      if (typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()))
      {
         GameObject go = (GameObject)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Target"] = go.name;

         return hashtable;
      }

      return null;
   }
#endif



}