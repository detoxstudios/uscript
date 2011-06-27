// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Play the specified animation on the target object. Animation must exist in the GameObject's AnimationClip.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Play the specified animation on the target object.")]
[NodeDescription("Play the specified animation on the target object.\n \nTarget: The Target GameObject(s) to play the animation on.\nAnimation: The name of the animation to play. Animation must exist in the GameObject's AnimationClip.\nSpeed Factor: The speed at which to play the animation.\nWrap Mode: Specifies what should happen at the end of the animation.\nStop Other Animation: Stop any currently playing animations before playing this one.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Play Animation")]
public class uScriptAct_PlayAnimation : uScriptLogic
{
   private GameObject m_GameObject = null;
   private AnimationClip m_Animation = null;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Finished")]
   public event uScriptEventHandler Finished;

   public void In(GameObject[] Target, AnimationClip Animation, [FriendlyName("Speed Factor"), DefaultValue(1f), SocketState(false, false)] float SpeedFactor, [FriendlyName("Wrap Mode"), SocketState(false, false)] WrapMode AnimWrapMode, [FriendlyName("Stop Other Animation"), DefaultValue(true), SocketState(false, false)] bool StopOtherAnimations)
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

            if ( null == currentTarget.animation[Animation.name] )
            {
               currentTarget.animation.AddClip(Animation, Animation.name);
            }

            if (SpeedFactor == 0F)
            {
               currentTarget.animation[Animation.name].speed = 1.0F;
            }
            else
            {
               currentTarget.animation[Animation.name].speed = SpeedFactor;
            }

            if (StopOtherAnimations)
            {
               currentTarget.animation.Play(PlayMode.StopAll);
            }

            if (SpeedFactor < 0)
            {
               // Needed to play in reverse with a negative speed
               currentTarget.animation[Animation.name].time = currentTarget.animation[Animation.name].length;
            }


            currentTarget.animation[Animation.name].wrapMode = AnimWrapMode;
            currentTarget.animation.Play(Animation.name);
         }
      }
   }

   public override void Update()
   {
      if ( null != m_GameObject )
      {
         if ( false == m_GameObject.animation.IsPlaying(m_Animation.name) )
         {
            m_GameObject = null;

            if ( null != Finished ) Finished( this, new System.EventArgs( ) );
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
         hashtable["Animation"] = ac;

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