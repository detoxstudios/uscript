// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Dummy node that just allows the signal to pass through.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Pass", "Dummy node that just allows the signal to pass through. This can be useful for routing connection lines in your graph.")]
public class uScriptAct_Passthrough : uScriptLogic
{
   public bool Out { get { return true; } }
   public void In() { }
}