// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any non-zero target float and outputs its inverse version.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Float")]

[FriendlyName("Invert Float", "Returns the inverse value of a floating point variable." +
 "\n\nExamples:" +
 "\n\t3.25 -> -3.25" +
 "\n\t-1.0 -> 1.0")]
public class uScriptAct_InvertFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      float Target,

      [FriendlyName("Value", "The inverted value.")]
      out float Value
      )
   {
      Value = -Target;
   }
}