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

[FriendlyName("Play AudioSource", "Plays the specified AudioSource on the target GameObject(s). Playing the AudioSource will immediately replace any existing sound playing from it. If you wish to change settings on the AudioSource (such as volume or pitch) at runtime, use the reflected properties to do so.\n\nNOTE: To use this node, you must have already setup an AudioSource component on the target GameObject(s). If you want to simply play a sound with default AudioSource settings without needing to have an existing AudioSource component on the GameObject, use the Play Sound node. Also, for the Stop input, the node will stop any sounds that were originally attached when Play was fired and ALSO any new/different sources that are attached at the time Stop is fired.")]
public class uScriptAct_PlayAudioSource : uScriptLogic
{
   private List<AudioSource> m_AudioSources = new List<AudioSource>();

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   // Parameter Attributes are applied below in Stop()
   public void Play(GameObject[] target, AudioClip audioClip)
   {
      if (target.Length > 0)
      {

         for (int i = 0; i < target.Length; i++)
         {
            if (null != target[i])
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
   }

   public void Stop(
      [FriendlyName("Target", "The GameObject to emit the sound from."), AutoLinkType(typeof(GameObject))]
      GameObject[] target,

      [FriendlyName("Audio Clip", "(optional) You can specify an AudioClip to play instead of the default AudioClip assigned to the target's AudioSource component.")]
      [RequiresLink]
      AudioClip audioClip
      )
   {
      // stop all cached sources first
      if (null != m_AudioSources)
      {
         foreach (AudioSource a in m_AudioSources)
         {
            a.Stop();
         }
      }
  
      // stop any attached sources
      if (target.Length > 0)
      {

         for (int i = 0; i < target.Length; i++)
         {
            if (null != target[i])
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

                  source.Stop();

               }
               else
               {
                  uScriptDebug.Log("[Play AudioSource] The target GameObject (" + target[i].name + ") does not have an existing AudioSource. Please add an AudioSource component to the target or try using the Play Sound node instead.", uScriptDebug.Type.Warning);
               }
            }

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