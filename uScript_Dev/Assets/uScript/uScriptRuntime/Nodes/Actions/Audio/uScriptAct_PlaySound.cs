// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Plays the specified AudioClip on the target GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Audio")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the specified AudioClip on the target GameObject.")]
[NodeDescription("Plays the specified AudioClip on the target GameObject.\n \nAudio Clip: The AudioClip to play.\nTarget: The GameObject to emit the sound from.\nVolume: The volume level (0.0-1.0) to play the audio clip at.\nLoop: Whether or not to loop the sound.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Play_Sound")]

[FriendlyName("Play Sound")]
public class uScriptAct_PlaySound : uScriptLogic
{
   private AudioSource []m_AudioSources;

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   public void Play(
      [RequiresLink][FriendlyName("Audio Clip")] AudioClip audioClip,
      [FriendlyName("Target")] GameObject []target,
      [FriendlyName("Volume"), DefaultValue(1f), SocketState(false, false)] float volume,
      [FriendlyName("Loop"), SocketState(false, false)] bool loop
   )
   {
      m_AudioSources = null;

      if ( target.Length > 0 && null != audioClip )
      {
         m_AudioSources = new AudioSource[ target.Length ];

         for ( int i = 0; i < target.Length; i++ )
         {
            m_AudioSources[ i ]       = target[ i ].AddComponent<AudioSource>( );
            m_AudioSources[ i ].clip  = audioClip;
            m_AudioSources[ i ].volume= volume;
            m_AudioSources[ i ].loop  = loop;

            m_AudioSources[ i ].Play();
         }
      }
   }

   [FriendlyName("Update Volume")]
   public void UpdateVolume(
      [RequiresLink][FriendlyName("Audio Clip")] AudioClip audioClip,
      [FriendlyName("Target")] GameObject []target,
      [FriendlyName("Volume"), DefaultValue(1f), SocketState(false, false)] float volume, 
      [FriendlyName("Loop")] bool loop
   )
   {
      foreach ( AudioSource a in m_AudioSources )
      {
         a.volume = volume;
      }
   }

   public void Stop(
      [RequiresLink][FriendlyName("Audio Clip")] AudioClip audioClip,
      [FriendlyName("Target")] GameObject []target,
      [FriendlyName("Volume"), DefaultValue(1f), SocketState(false, false)] float volume, 
      [FriendlyName("Loop")] bool loop
   )
   {
      foreach ( AudioSource a in m_AudioSources )
      {
         a.Stop( );
      }
   }

   public void Update()
   {
      // Called every tick
      if ( null == m_AudioSources ) return;

      int i;

      for ( i = 0; i < m_AudioSources.Length; i++ )
      {
         if ( m_AudioSources[ i ] != null && true == m_AudioSources[ i ].isPlaying ) break;
      }

      if ( i == m_AudioSources.Length )
      {
         if (Finished != null)
         {
            Finished(this, new System.EventArgs());
         }

         for ( i = 0; i < m_AudioSources.Length; i++ )
         {
            Destroy( m_AudioSources[i] );
         }

         m_AudioSources = null;
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