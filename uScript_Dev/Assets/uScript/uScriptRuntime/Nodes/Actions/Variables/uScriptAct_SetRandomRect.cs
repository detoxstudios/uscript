// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Rect variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Rect", "Randomly sets the value of a Rect variable from a set of choices.")]
public class uScriptAct_SetRandomRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Rect", "The Rect to randomly choose from. Connect an Rect List or individual Rect variables to this socket.")]
      Rect[] ObjectSet,

      [FriendlyName("Target Rect", "The Rect value that gets set.")]
      out Rect Target
      )
   {
      if (ObjectSet == null)
      {
         Target = new Rect(0, 0, 0, 0);
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      Target = ObjectSet[index];
   }
}