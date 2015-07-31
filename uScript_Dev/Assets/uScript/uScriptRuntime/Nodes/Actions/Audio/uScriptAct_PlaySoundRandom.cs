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

[FriendlyName("Play Sound (Random)", "Plays a single random AudioClip on a single random Target GameObject from those specified. You can only specify a single target GameObject or AudioClip if you wish to just have one of the two things be random (either AudioClips or GameObjects).")]
public class uScriptAct_PlaySoundRandom : uScriptLogic
{
   GameObject m_ChosenTarget = null;
   AudioClip m_ChosenClip = null;

   private List<AudioSource> m_AudioSources = new List<AudioSource>( );

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   // Parameter Attributes are applied below in Stop()
   public void Play(AudioClip[] audioClips, GameObject[] targets, float volume, bool loop, out GameObject chosenTarget, out AudioClip chosenClip)
   {
      if (targets.Length > 0 && audioClips.Length > 0)
      {
         // Pick a random Target
         GameObject target = PickRandomTarget(targets);
         
         // Pick a random AudioClip
         AudioClip clip = PickRandomAudioClip(audioClips);

         if (null != target && null != clip)
         {
            AudioSource source = target.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = volume;
            source.loop = loop;

            source.Play();

            m_AudioSources.Add(source);

         }
         else
         {
            uScriptDebug.Log("[Play Sound (Random)] A valid (non-null) GameObject and AudioClip combination could not be found. Please make sure you have at least one valid Target GameObject and AudioClip for the node to use.", uScriptDebug.Type.Warning);
         }

      }

      chosenTarget = m_ChosenTarget;
      chosenClip = m_ChosenClip;
   }

   // Parameter Attributes are applied below in Stop()
   [FriendlyName("Update Volume")]
   public void UpdateVolume(AudioClip[] audioClips, GameObject[] targets, float volume, bool loop, out GameObject chosenTarget, out AudioClip chosenClip)
   {
      foreach (AudioSource a in m_AudioSources)
      {
         a.volume = volume;
      }

      chosenTarget = m_ChosenTarget;
      chosenClip = m_ChosenClip;
   }

   public void Stop(
      [FriendlyName("Audio Clips", "The list of AudioClips to choose from.")]
      [RequiresLink]
      AudioClip[] audioClips,

      [FriendlyName("Targets", "The list of GameObjects to choose from."), AutoLinkType(typeof(GameObject))]
      GameObject[] targets,

      [FriendlyName("Volume", "The volume level (0.0-1.0) to play the audio clip at.")]
      [DefaultValue(1f), SocketState(false, false)]
      float volume,

      [FriendlyName("Loop", "Whether or not to loop the sound.")]
      [SocketState(false, false)]
      bool loop,

      [FriendlyName("Chosen Target", "The target GameObject that was chosen.")]
      [SocketState(false, false)]
      out GameObject chosenTarget,

      [FriendlyName("Chosen AudioClip", "The target AudioClip that was chosen.")]
      [SocketState(false, false)]
      out AudioClip chosenClip
   )
   {
      if (null != m_AudioSources)
      {
         foreach (AudioSource a in m_AudioSources)
         {
            a.Stop();
         }
      }

      chosenTarget = m_ChosenTarget;
      chosenClip = m_ChosenClip;
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

   private GameObject PickRandomTarget(GameObject[] Targets)
   {
      // Make sure there is at least one non-null item in the array
      bool validChoices = false;
      foreach (GameObject go in Targets)
      {
         if (null != go) { validChoices = true; };
      }

      if (validChoices)
      {
         // Pick the item randomly
         GameObject chosenItem = null;
         while (chosenItem == null)
         {
            chosenItem = Targets[UnityEngine.Random.Range(0, Targets.Length)];
         }

         m_ChosenTarget = chosenItem;
         return chosenItem;
      }
      else
      {
         return null;
      }
   }

   private AudioClip PickRandomAudioClip(AudioClip[] AudioClips)
   {
      // Make sure there is at least one non-null item in the array
      bool validChoices = false;
      foreach (AudioClip clip in AudioClips)
      {
         if (null != clip) { validChoices = true; };
      }

      if (validChoices)
      {
         // Pick the item randomly
         AudioClip chosenItem = null;
         while (chosenItem == null)
         {
            chosenItem = AudioClips[UnityEngine.Random.Range(0, AudioClips.Length)];
         }

         m_ChosenClip = chosenItem;
         return chosenItem;
      }
      else
      {
         return null;
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