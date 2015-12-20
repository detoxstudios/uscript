// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Blend animations from specific bodyparts using a mixing transform.")]
[NodeAuthor("Detox Studios LLC. Original node by Krillbite", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Play Animation (Additive)", "Blend animations from specific bodyparts using a mixing transform.")]
public class uScriptAct_PlayAnimationAdditive : uScriptLogic
{
   private GameObject m_GameObject = null;
   private string m_Animation = null;
   private float m_playNextTime = 0.0f;
   private bool m_PlayNextFired = false;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Finished", "Fired when the animation is done playing.")]
   public event uScriptEventHandler Finished;

   [FriendlyName("Play Next", "Fired when the animation has reached the time remaining specified in Play Next Time.")]
   public event uScriptEventHandler PlayNext;
	
   [FriendlyName("Stopped", "Fired when the animaiton is stopped.")]
   public event uScriptEventHandler Stopped;

   public void In(
      [FriendlyName("Target", "The target GameObject to play the animation on.")] GameObject Target,
      [FriendlyName("Animation", "The name of the animation to play. Animation must exist in the GameObject's AnimationClip.")] string Animation,
      [FriendlyName("Mixing Transform", "The target GameObject in the character's hierarchy where the blending should occur."), AutoLinkType(typeof(GameObject))] GameObject[] MixingTransform,
      [FriendlyName("Speed Factor", "The speed at which to play the animation."), DefaultValue(1f), SocketState(false, false)] float SpeedFactor, 
      [FriendlyName("Blend Weight", "The strength of the blending between animations."), DefaultValue(1f), SocketState(false, false)] float BlendWeight,
	   [FriendlyName("Fade Length", "How long (in seconds) the blend should take to reach the Blend Weight"), DefaultValue(1f), SocketState(false, false)] float FadeLength,
      [FriendlyName("Play Next Time", "The time remaining (in seconds) in the current animation to fire the Play Next output socket."), DefaultValue(0.0f), SocketState(false, false)] float PlayNextTime,
	   [FriendlyName("Set to layer", "The animaiton layer to use for the blend."), DefaultValue(2), SocketState(false, false)] int setLayer,
      [FriendlyName("Wrap Mode", "Specifies what should happen at the end of the animation."), SocketState(false, false)] WrapMode AnimWrapMode
      )
   {
        m_GameObject = null;
        m_playNextTime = PlayNextTime;
        m_PlayNextFired = false;

        if (Target != null)
        {
            //only save one so we can ask about the animation state
            //i don't need to save all of them in the array
            m_GameObject = Target;
            m_Animation  = Animation;

#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            if (SpeedFactor == 0F)
            {
                Target.animation[m_Animation].speed = 1.0F;
            }
            else
            {
                Target.animation[m_Animation].speed = SpeedFactor;
            }

            if (SpeedFactor < 0)
            {
                // Needed to play in reverse with a negative speed
                Target.animation[m_Animation].time = Target.animation[m_Animation].length;
            }
            else
            {
                Target.animation[m_Animation].time = 0.0f;
            }

            Target.animation[m_Animation].wrapMode = AnimWrapMode;

            foreach (GameObject t in MixingTransform)
            {
                Target.animation[m_Animation].AddMixingTransform(t.transform);
                Target.animation[m_Animation].layer = setLayer;
                Target.animation.Blend(m_Animation, BlendWeight, FadeLength);
            }
#else
            if (SpeedFactor == 0F)
            {
                Target.GetComponent<Animation>()[m_Animation].speed = 1.0F;
            }
            else
            {
                Target.GetComponent<Animation>()[m_Animation].speed = SpeedFactor;
            }

            if (SpeedFactor < 0)
            {
                // Needed to play in reverse with a negative speed
                Target.GetComponent<Animation>()[m_Animation].time = Target.GetComponent<Animation>()[m_Animation].length;
            }
            else
            {
                Target.GetComponent<Animation>()[m_Animation].time = 0.0f;
            }

            Target.GetComponent<Animation>()[m_Animation].wrapMode = AnimWrapMode;

            foreach (GameObject t in MixingTransform)
            {
                Target.GetComponent<Animation>()[m_Animation].AddMixingTransform(t.transform);
                Target.GetComponent<Animation>()[m_Animation].layer = setLayer;
                Target.GetComponent<Animation>().Blend(m_Animation, BlendWeight, FadeLength);
            }
#endif
        }
    }

   public void Stop(
      [FriendlyName("Target", "The target GameObject to play the animation on.")] GameObject Target,
      [FriendlyName("Animation", "The name of the animation to play. Animation must exist in the GameObject's AnimationClip.")] string Animation,
      [FriendlyName("Mixing Transform", "The target GameObject in the character's hierarchy where the blending should occur."), AutoLinkType(typeof(GameObject))] GameObject[] MixingTransform,
      [FriendlyName("Speed Factor", "The speed at which to play the animation."), DefaultValue(1f), SocketState(false, false)] float SpeedFactor,
      [FriendlyName("Blend Weight", "The strength of the blending between animations."), DefaultValue(1f), SocketState(false, false)] float BlendWeight,
      [FriendlyName("Fade Length", "How long (in seconds) the blend should take to reach the Blend Weight"), DefaultValue(1f), SocketState(false, false)] float FadeLength,
      [FriendlyName("Play Next Time", "The time remaining (in seconds) in the current animation to fire the Play Next output socket."), DefaultValue(0.0f), SocketState(false, false)] float PlayNextTime,
      [FriendlyName("Set to layer", "The animaiton layer to use for the blend."), DefaultValue(2), SocketState(false, false)] int setLayer,
      [FriendlyName("Wrap Mode", "Specifies what should happen at the end of the animation."), SocketState(false, false)] WrapMode AnimWrapMode
      )
   {
       m_GameObject = null;
       m_PlayNextFired = true; // Don't fire out the Play Next is the node was stopped.

       if (Target != null)
       {
#pragma warning disable 0219
          foreach (GameObject t in MixingTransform)
           {
               //TODO: Make the blend complete before removing mixing transform.
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
              Target.animation[m_Animation].RemoveMixingTransform(t.transform);
              Target.animation[m_Animation].layer = setLayer;
              Target.animation.Blend(m_Animation, 0.0f, FadeLength);
#else
              Target.GetComponent<Animation>()[m_Animation].RemoveMixingTransform(t.transform);
              Target.GetComponent<Animation>()[m_Animation].layer = setLayer;
              Target.GetComponent<Animation>().Blend(m_Animation, 0.0f, FadeLength);
#endif
           }
#pragma warning restore 0219
       }
		
		Stopped(this, new System.EventArgs());
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
         if (false == m_GameObject.animation.IsPlaying(m_Animation))
#else
         if (false == m_GameObject.GetComponent<Animation>().IsPlaying(m_Animation))
#endif
         {
            m_GameObject = null;

            if (null != Finished) Finished(this, new System.EventArgs());

            if (!m_PlayNextFired && m_playNextTime > 0.0f)
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