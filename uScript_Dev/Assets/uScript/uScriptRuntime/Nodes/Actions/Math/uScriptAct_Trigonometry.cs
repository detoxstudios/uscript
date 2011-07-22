// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Perform various floating point trigonometric functions.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating point trigonometric functions.")]
[NodeDescription("Perform various floating point trigonometric functions.\n \nInput: The input value to the trigonometric function.\nOutput: The output value of the trigonometric function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Trigonometry")]

[FriendlyName("Trigonometry")]
public class uScriptAct_Trigonometry : uScriptLogic
{
   public bool Out { get { return true; } }

   public void Acos([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Acos(input);
   }

   public void Asin([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Asin(input);
   }
   
   public void Atan([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Atan(input);
   }

   public void Cos([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Cos(input);
   }

   public void Sin([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Sin(input);
   }

   public void Tan([FriendlyName("Input")]float input, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Tan(input);
   }
}