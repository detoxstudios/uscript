// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Int variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Int", "Randomly sets the value of a Int variable.")]
public class uScriptAct_SetRandomInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min", "Minimum allowable integer value.")]
      [SocketState(false, false)]
      int Min,

      [FriendlyName("Max", "Maximum allowable integer value. This value is inclusive and may be returned.")]
      [SocketState(false, false)]
      int Max,
      
      [FriendlyName("Target Int", "The integer value that gets set.")]
      out int TargetInt
      )
   {
      TargetInt = Random.Range(Min, Max + 1);
   }
}
