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

[FriendlyName("Play AudioSource (One Shot)", "Plays the specified AudioSource on the target GameObject(s) using Unity's PlayOneShot option (fire and forget).\n\nNOTE: To use this node, you must have already setup an AudioSource component on the target GameObject(s). If you want to simply play a sound with default AudioSource settings without needing to have an existing AudioSource component on the GameObject, use the Play Sound node.")]
public class uScriptAct_PlayAudioSourceOneShot : uScriptLogic
{
   public bool Out { get { return true; } }

   // Parameter Attributes are applied below in Stop()
   public void Play(
      [FriendlyName("Target", "The GameObject with the AudioSource component to play.")]
      GameObject[] target,

      [FriendlyName("Audio Clip", "(optional) You can specify an AudioClip to play instead of the deault AudioClip assigned to the target's component.")]
      [RequiresLink]
      AudioClip audioClip,

      [FriendlyName("Volume", "(optional) The volume level to play the audio clip at (0.0 - 1.0). Set to -1 to use the assigned volume value set on the AudioSource component.")]
      [DefaultValue(-1f), SocketState(false, false)]
      float volume
      )
   {
      if (target.Length > 0)
      {
         AudioClip[] localClip = new AudioClip[target.Length];
         float[] localVolume = new float[target.Length];

         for (int i = 0; i < target.Length; i++)
         {
            AudioSource source;
            if (null != target[i].GetComponent<AudioSource>())
            {
               source = target[i].GetComponent<AudioSource>();

               // Override the AudioSources AudioClip if one is specified.
               if (null != audioClip)
               {
                  localClip[i] = audioClip;
               }
               else
               {
                  localClip[i] = source.clip;
               }

               // Use the volume specified if not the default -1
               if (volume >= 0f)
               {
                  localVolume[i] = volume;
               }
               else
               {
                  localVolume[i] = source.volume;
               }

               source.PlayOneShot(localClip[i], localVolume[i]);

            }
            else
            {
               uScriptDebug.Log("[Play AudioSource (One Shot)] The target GameObject (" + target[i].name + ") does not have an existing AudioSource. Please add an AudioSource component to the target or try using the Play Sound node instead.", uScriptDebug.Type.Warning);
            }

         }
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