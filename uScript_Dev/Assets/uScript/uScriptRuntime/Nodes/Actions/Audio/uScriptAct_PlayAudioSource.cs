// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Audio")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the specified AudioClip on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Play AudioSource", "Plays the specified AudioSource on the target GameObject(s). Playing the AudioSource will immediately replace any existing sound playing from it.\n\nNOTE: To use this node, you must have already setup an AudioSource component on the target GameObject(s). If you want to simply play a sound with default AudioSource settings without needing to have an existing AudioSource component on the GameObject, use the Play Sound node.")]
public class uScriptAct_PlayAudioSource : uScriptLogic
{
   private List<AudioSource> m_AudioSources = new List<AudioSource>();

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   // Parameter Attributes are applied below in Stop()
   public void Play(GameObject[] target, AudioClip audioClip, float volume)
   {
      if (target.Length > 0)
      {

         for (int i = 0; i < target.Length; i++)
         {
            AudioSource source;
            if (null != target[i].GetComponent<AudioSource>())
            {
               source = target[i].GetComponent<AudioSource>();

               // Override the AudioSources AudioClip if one is specified.
               if (null != audioClip)
               {
                  source.clip = audioClip;
               }

               // Use the volume specified if not the default -1
               if (volume >= 0f)
               {
                  source.volume = volume;
               }

               source.Play();
               m_AudioSources.Add(source);

            }
            else
            {
               uScriptDebug.Log("[Play AudioSource] The target GameObject (" + target[i].name + ") does not have an existing AudioSource. Please add an AudioSource component to the target or try using the Play Sound node instead.", uScriptDebug.Type.Warning);
            }



         }
      }
   }

   // Parameter Attributes are applied below in Stop()
   [FriendlyName("Update Volume")]
   public void UpdateVolume(GameObject[] target, AudioClip audioClip, float volume)
   {
      foreach (AudioSource a in m_AudioSources)
      {
         a.volume = volume;
      }
   }

   public void Stop(
      [FriendlyName("Target", "The GameObject to emit the sound from.")]
      GameObject[] target,

      [FriendlyName("Audio Clip", "(optional) You can specify an AudioClip to play instead of the deault AudioClip assigned to the target's AudioSource component.")]
      [RequiresLink]
      AudioClip audioClip,

      [FriendlyName("Volume", "(optional) The volume level to play the audio clip at (0.0 - 1.0). Set to -1 to use the assigned volume value set on the AudioSource component.")]
      [DefaultValue(-1f), SocketState(false, false)]
      float volume
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
         // Remove an AudioSource from the list of those playing once it is finished.
         if (false == m_AudioSources[i].isPlaying)
         {
            m_AudioSources.RemoveAt(i);
            --i;
         }
      }

      if (0 == m_AudioSources.Count)
      {
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop(object o)
   {
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