// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Quaternion")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Quaternion variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Quaternion", "Randomly sets the value of a Quaternion variable from a set of choices.")]
public class uScriptAct_SetRandomQuaternion : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Quaternion", "The Quaternion to randomly choose from. Connect an Quaternion List or individual Quaternion variables to this socket.")]
      Quaternion[] ObjectSet,

      [FriendlyName("Target Quaternion", "The Quaternion value that gets set.")]
      out Quaternion Target
      )
   {
      if (ObjectSet == null)
      {
         Target = new Quaternion(0, 0, 0, 0);
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      Target = ObjectSet[index];
   }
}