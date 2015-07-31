// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any non-zero target integer and outputs its inverse version.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Invert Int", "Returns the inverse value of an integer variable." +
 "\n\nExamples:" +
 "\n\t3 -> -3" +
 "\n\t-1 -> 1")]
public class uScriptAct_InvertInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      int Target,

      [FriendlyName("Value", "The inverted value.")]
      out int Value
      )
   {
      Value = -Target;
   }
}