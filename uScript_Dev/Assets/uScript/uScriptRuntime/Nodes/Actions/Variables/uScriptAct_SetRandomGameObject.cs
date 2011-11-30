// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a GameObject variable from a set of choices.")]
[NodeDescription("Randomly sets the value of a GameObject variable from a set of choices.\n \nGameObjects: The GameObjects to randomly choose from. Connect GameObject variables to this socket.\nTarget GameObject (out): The GameObject value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_GameObject")]

[FriendlyName("Set Random GameObject")]
public class uScriptAct_SetRandomGameObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("GameObjects")] GameObject[] ObjectSet,
      [FriendlyName("Target GameObject")] out GameObject TargetGameObject)
   {
      if (ObjectSet == null)
      {
         TargetGameObject = null;
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      TargetGameObject = ObjectSet[index];
   }
}