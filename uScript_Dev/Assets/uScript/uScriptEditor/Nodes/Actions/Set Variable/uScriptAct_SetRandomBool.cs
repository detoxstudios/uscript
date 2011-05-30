// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Bool variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Bool variable.")]
[NodeDescription("Randomly sets the value of a Bool variable.\n \nSeed: Seed value for the random number generator.\nTarget Bool (out): The bool value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Random Bool")]
public class uScriptAct_SetRandomBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Target Bool")] out bool TargetBool)
   {
      if (Seed > 0) { Random.seed = Seed; }

      TargetBool = Random.Range(0, 2) > 0;
   }
}