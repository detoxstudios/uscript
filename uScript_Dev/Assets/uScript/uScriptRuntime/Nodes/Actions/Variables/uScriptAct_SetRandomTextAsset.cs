// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/TextAsset")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a TextAsset variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random TextAsset", "Randomly sets the value of a TextAsset variable from a set of choices.")]
public class uScriptAct_SetRandomTextAsset : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("TextAsset", "The TextAsset to randomly choose from. Connect an TextAsset List or individual TextAsset variables to this socket.")]
      TextAsset[] ObjectSet,

      [FriendlyName("Target TextAsset", "The TextAsset value that gets set.")]
      out TextAsset Target
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