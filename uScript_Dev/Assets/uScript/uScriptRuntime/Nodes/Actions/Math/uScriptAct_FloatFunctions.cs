// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating-point functions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Floating Point Functions", "Perform various floating-point functions.")]
public class uScriptAct_FloatFunctions : uScriptLogic
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
   // Parameter Attributes are applied below in Sqrt()
   public void Abs(float input, out float output)
   {
      output = Mathf.Abs(input);
   }

   // Parameter Attributes are applied below in Sqrt()
   public void Ceiling(float input, out float output)
   {
      output = Mathf.Ceil(input);
   }
   
   // Parameter Attributes are applied below in Sqrt()
   public void Floor(float input, out float output)
   {
      output = Mathf.Floor(input);
   }

   // Parameter Attributes are applied below in Sqrt()
   public void Round(float input, out float output)
   {
      output = Mathf.Round(input);
   }

   // Parameter Attributes are applied below in Sqrt()
   public void Sign(float input, out float output)
   {
      output = Mathf.Sign(input);
   }

   public void Sqrt(
      [FriendlyName("Input", "The input value to the function.")]
      float input,
      
      [FriendlyName("Output", "The output value of the function.")]
      out float output
      )
   {
      output = Mathf.Sqrt(input);
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}