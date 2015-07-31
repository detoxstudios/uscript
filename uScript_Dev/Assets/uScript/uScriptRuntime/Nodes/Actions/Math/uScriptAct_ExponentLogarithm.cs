// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating-point exponent and logarithmic functions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Exponent & Logarithmic Functions", "Perform various floating-point exponent and logarithmic functions.")]
public class uScriptAct_ExponentLogarithm : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Pow()
   public void Exp(float input, float Power, out float output)
   {
      output = Mathf.Exp(input);
   }

   // Parameter Attributes are applied below in Pow()
   public void Log(float input, float Power, out float output)
   {
      output = Mathf.Log(input);
   }
   
   // Parameter Attributes are applied below in Pow()
   public void Log10(float input, float Power, out float output)
   {
      output = Mathf.Log10(input);
   }

   public void Pow(
      [FriendlyName("Input", "The input value to the function.")]
      float input,
      
      [FriendlyName("Power", "The power to use for the Pow function. (only used with the Pow function)")]
      float Power,
      
      [FriendlyName("Output", "The output value of the function.")]
      out float output
      )
   {
      output = Mathf.Pow(input, Power);
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
