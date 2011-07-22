// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Perform various floating point functions.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating point functions.")]
[NodeDescription("Perform various floating point functions.\n \nInput: The input value to the function.\nOutput: The output value of the function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Trigonometry")]

[FriendlyName("Floating Point Functions")]
public class uScriptAct_FloatFunctions : uScriptLogic
{
   public bool Out { get { return true; } }

   public void Abs([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Abs(input);
   }

   public void Ceiling([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Ceil(input);
   }
   
   public void Floor([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Floor(input);
   }

   public void Round([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Round(input);
   }

   public void Sign([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Sign(input);
   }

   public void Sqrt([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Sqrt(input);
   }
}