// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Animation variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Animation", "Randomly sets the value of a Animation variable from a set of choices.")]
public class uScriptAct_SetRandomAnimation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Animation", "The Animation to randomly choose from. Connect an Animation List or individual Animation variables to this socket.")]
      Animation[] ObjectSet,

      [FriendlyName("Target Animation", "The Animation value that gets set.")]
      out Animation Target
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