// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Plays the specified AudioClip on the target GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Action/Audio")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the specified AudioClip on the target GameObject.")]
[NodeDescription("Plays the specified AudioClip on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Play Sound Direct")]
public class uScriptAct_PlaySoundDirect : uScriptLogic
{
   private AudioSource m_AudioSource;
   private AudioClip m_AudioClip;

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   public void Play(
      [FriendlyName("Audio Clip")] AudioClip audioClip,
      [FriendlyName("Target")] GameObject target, 
      [FriendlyName("Volume")] float volume, 
      [FriendlyName("Loop")] bool loop
   )
   {
       m_AudioClip = audioClip;

      Debug.Log( "audioclip " + m_AudioClip );
      Debug.Log( "target " + target );

      if ( null != m_AudioClip && null != target )
      {
         m_AudioSource = target.AddComponent<AudioSource>( );
         m_AudioSource.clip = m_AudioClip;
         m_AudioSource.volume = volume;
         m_AudioSource.loop = loop;

         m_AudioSource.Play();

      }
   }

   public void Stop(
      [FriendlyName("Audio Clip")] AudioClip audioClip,
      [FriendlyName("Target")] GameObject target, 
      [FriendlyName("Volume")] float volume, 
      [FriendlyName("Loop")] bool loop
   )
   {
      if (null != m_AudioSource)
      {
         m_AudioSource.Stop();
      }

   }

   public override void Update()
   {
      // Called every tick
      if (m_AudioSource != null)
      {
         if (m_AudioSource.isPlaying == false)
         {
            if (Finished != null)
            {
               Finished(this, new System.EventArgs());
            }


            Destroy(m_AudioSource);
         }

      }

   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(AudioClip).IsAssignableFrom(o.GetType()) )
      {
         AudioClip ac = (AudioClip) o;

         Hashtable hashtable = new Hashtable( );
         hashtable[ "Audio Clip" ] = UnityEditor.AssetDatabase.GetAssetPath( ac.GetInstanceID( ) );

         return hashtable;
      }
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