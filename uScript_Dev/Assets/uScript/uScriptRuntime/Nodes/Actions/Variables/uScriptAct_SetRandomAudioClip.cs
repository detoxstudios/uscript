// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a AudioClip variable from a set of choices.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a AudioClip variable from a set of choices.")]
[NodeDescription("Randomly sets the value of a AudioClip variable from a set of choices.\n \nAudioClips: The AudioClip to randomly choose from. Connect AudioClip variables to this socket.\nTarget AudioClip (out): The AudioClip value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random AudioClip")]
public class uScriptAct_SetRandomAudioClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("AudioClips")] AudioClip[] ObjectSet,
      [FriendlyName("Target AudioClip")] out AudioClip TargetAudioClip)
   {
      if (ObjectSet == null)
      {
         TargetAudioClip = null;
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      TargetAudioClip = ObjectSet[index];
   }
}