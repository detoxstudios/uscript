// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Bool variable.

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Bool variable.")]
[NodeDescription("Randomly sets the value of a Bool variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Random Bool")]
public class uScriptAct_SetRandomBool : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Seed")] int Seed,
      [FriendlyName("Target Int")] out bool TargetBool)
   {
      int RndInt;

      if (Seed > 0) { Random.seed = Seed; }

      RndInt = Random.Range(0, 2);

      Debug.Log(RndInt.ToString());

      if (RndInt > 0)
      {
         TargetBool = true;
      }
      else
      {
         TargetBool = false;
      }

   }

}