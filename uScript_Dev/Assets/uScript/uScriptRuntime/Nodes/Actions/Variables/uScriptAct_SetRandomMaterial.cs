// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Material")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Material variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Material", "Randomly sets the value of a Material variable from a set of choices.")]
public class uScriptAct_SetRandomMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to randomly choose from. Connect an Material List or individual Material variables to this socket.")]
      Material[] ObjectSet,

      [FriendlyName("Target Material", "The Material value that gets set.")]
      out Material Target
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