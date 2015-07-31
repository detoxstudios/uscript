// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a String variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random String", "Randomly sets the value of a String variable from a set of choices.")]
public class uScriptAct_SetRandomString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("String", "The String to randomly choose from. Connect an String List or individual String variables to this socket.")]
      string[] ObjectSet,

      [FriendlyName("Target String", "The String value that gets set.")]
      out string Target
      )
   {
      if (ObjectSet == null)
      {
         Target = null;
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      Target = ObjectSet[index];
   }
}