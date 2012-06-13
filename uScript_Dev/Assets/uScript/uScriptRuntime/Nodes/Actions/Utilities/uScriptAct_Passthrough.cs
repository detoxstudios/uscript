// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Dummy node that just allows the signal to pass through.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Pass", "Dummy node that just allows the signal to pass through. This can bu useful for routing connection lines in your graph.")]
public class uScriptAct_Passthrough : uScriptLogic
{
   public bool Out { get { return true; } }
   public void In() { }
}