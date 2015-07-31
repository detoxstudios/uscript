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

[FriendlyName("Play AudioSource (One Shot)", "Plays the specified AudioSource on the target GameObject(s) using Unity's PlayOneShot option (fire and forget). If you wish to change settings on the AudioSource (such as volume or pitch) at runtime, use the reflected properties to do so.\n\nNOTE: To use this node, you must have already setup an AudioSource component on the target GameObject(s). If you want to simply play a sound with default AudioSource settings without needing to have an existing AudioSource component on the GameObject, use the Play Sound node.")]
public class uScriptAct_PlayAudioSourceOneShot : uScriptLogic
{
   public bool Out { get { return true; } }

   // Parameter Attributes are applied below in Stop()
   public void Play(
      [FriendlyName("Target", "The GameObject with the AudioSource component to play."), AutoLinkType(typeof(GameObject))]
      GameObject[] target,

      [FriendlyName("Audio Clip", "(optional) You can specify an AudioClip to play instead of the deault AudioClip assigned to the target's component.")]
      [RequiresLink]
      AudioClip audioClip
      )
   {
      if (target.Length > 0)
      {
         AudioClip[] localClip = new AudioClip[target.Length];

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
                     localClip[i] = audioClip;
                  }
                  else
                  {
                     localClip[i] = source.clip;
                  }

                  source.PlayOneShot(localClip[i], source.volume);

               }
               else
               {
                  uScriptDebug.Log("[Play AudioSource (One Shot)] The target GameObject (" + target[i].name + ") does not have an existing AudioSource. Please add an AudioSource component to the target or try using the Play Sound node instead.", uScriptDebug.Type.Warning);
               }
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