// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Inverse a boolean variable to its opposite value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Bool")]

[FriendlyName("Invert Bool", "Returns the inverse value of a boolean variable." +
 "\n\nExamples:" +
 "\n\tTrue -> False" +
 "\n\tFalse -> True")]
public class uScriptAct_InvertBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      bool Target,

      [FriendlyName("Value", "The inverted value.")]
      out bool Value
      )
   {
      Value = !Target;
   }
}