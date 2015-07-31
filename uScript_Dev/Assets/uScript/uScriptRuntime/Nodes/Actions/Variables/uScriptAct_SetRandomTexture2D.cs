// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Texture2D variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Texture2D", "Randomly sets the value of a Texture2D variable from a set of choices.")]
public class uScriptAct_SetRandomTexture2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Texture2D", "The Texture2D to randomly choose from. Connect an Texture2D List or individual Texture2D variables to this socket.")]
      Texture2D[] ObjectSet,

      [FriendlyName("Target Texture2D", "The Texture2D value that gets set.")]
      out Texture2D Target
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