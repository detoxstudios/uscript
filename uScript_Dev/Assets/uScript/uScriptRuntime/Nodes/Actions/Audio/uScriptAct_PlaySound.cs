// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Audio")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the specified AudioClip on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Play Sound", "Plays the specified AudioClip on the target GameObject.\n\nNote: This node will create a new instance of an AudioSource component when playing. If you wish to play a soud using a GameObjects existing AudioSource component, please use the Play AudioSource or Play AudioSource (OneShot) nodes instead.")]
public class uScriptAct_PlaySound : uScriptLogic
{
   private List<AudioSource> m_AudioSources = new List<AudioSource>( );

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   // Parameter Attributes are applied below in Stop()
   public void Play(AudioClip audioClip, GameObject[] target, float volume, bool loop)
   {
      if (target.Length > 0 && null != audioClip)
      {
         for (int i = 0; i < target.Length; i++)
         {
            AudioSource source = target[i].AddComponent<AudioSource>();
            source.clip = audioClip;
            source.volume = volume;
            source.loop = loop;

            source.Play();

            m_AudioSources.Add( source );
         }
      }
   }

   // Parameter Attributes are applied below in Stop()
   [FriendlyName("Update Volume")]
   public void UpdateVolume(AudioClip audioClip, GameObject[] target, float volume, bool loop)
   {
      foreach (AudioSource a in m_AudioSources)
      {
         a.volume = volume;
      }
   }

   public void Stop(
      [FriendlyName("Audio Clip", "The AudioClip to play.")]
      [RequiresLink]
      AudioClip audioClip,

      [FriendlyName("Target", "The GameObject to emit the sound from."), AutoLinkType(typeof(GameObject))]
      GameObject[] target,

      [FriendlyName("Volume", "The volume level (0.0-1.0) to play the audio clip at.")]
      [DefaultValue(1f), SocketState(false, false)]
      float volume,

      [FriendlyName("Loop", "Whether or not to loop the sound.")]
      [SocketState(false, false)]
      bool loop
   )
   {
      if (null != m_AudioSources)
      {
         foreach (AudioSource a in m_AudioSources)
         {
            a.Stop();
         }
      }
   }

   public void Update()
   {
      if (0 == m_AudioSources.Count) return;

      int i;

      for (i = 0; i < m_AudioSources.Count; i++)
      {
         if (false == m_AudioSources[i].isPlaying)
         {
            AudioSource finishedSource = m_AudioSources[i];
            ScriptableObject.Destroy( finishedSource );

            m_AudioSources.RemoveAt( i );

            --i;
         }
      }

      if ( 0 == m_AudioSources.Count )
      {
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
      {
         GameObject go = (GameObject) o;

         Hashtable hashtable = new Hashtable( );
         hashtable[ "Target" ] = go.name;

         return hashtable;
      }

      return null;
   }
#endif

}