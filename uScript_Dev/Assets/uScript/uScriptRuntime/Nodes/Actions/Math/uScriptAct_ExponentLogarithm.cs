// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Perform various floating point exponent and logarithmic functions.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating point exponent and logarithmic functions.")]
/* M */[NodeDescription("Perform various floating point exponent and logarithmic functions.\n \nInput: The input value to the function.\nPower: The power to use for the Pow function. (Only used for Pow function.)\nOutput: The output value of the function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#ExponentLogarithm")]

[FriendlyName("Exponent & Logarithmic Functions")]
public class uScriptAct_ExponentLogarithm : uScriptLogic
{
   public bool Out { get { return true; } }

   public void Exp([FriendlyName("Input")]float input, float Power, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Exp(input);
   }

   public void Log([FriendlyName("Input")]float input, float Power, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Log(input);
   }
   
   public void Log10([FriendlyName("Input")]float input, float Power, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Log10(input);
   }

   public void Pow([FriendlyName("Input")]float input, float Power, [FriendlyName("Output")]out float output)
   {
      output = Mathf.Pow(input, Power);
   }
}