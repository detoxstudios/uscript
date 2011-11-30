// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Play the specified animation on the target object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Play_Animation")]

[FriendlyName("Play Animation", "Play the specified animation on the target object.")]
public class uScriptAct_PlayAnimation : uScriptLogic
{
   private GameObject m_GameObject = null;
   private string m_Animation = null;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Finished")]
   public event uScriptEventHandler Finished;

   public void In(
      [FriendlyName("Target", "The target GameObject(s) to play the animation on.")]
      GameObject[] Target,

      [FriendlyName("Animation", "The name of the animation to play. Animation must exist in the GameObject's AnimationClip.")]
      string Animation,

      [FriendlyName("Speed Factor", "The speed at which to play the animation.")]
      [DefaultValue(1f), SocketState(false, false)]
      float SpeedFactor,

      [FriendlyName("Wrap Mode", "Specifies what should happen at the end of the animation.")]
      [SocketState(false, false)]
      WrapMode AnimWrapMode,

      [FriendlyName("Stop Other Animation", "Stop any currently playing animations before playing this one.")]
      [DefaultValue(true), SocketState(false, false)]
      bool StopOtherAnimations)
   {
      m_GameObject = null;

      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            if(currentTarget.animation.GetClip(Animation))
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
               currentTarget.animation.Play(Animation);
            }
         }
         else
         {
   			uScriptDebug.Log("The specified Target " + currentTarget.name + " doesn't contain animation " + Animation, uScriptDebug.Type.Warning);
         }
      }
   }

   public void Update()
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