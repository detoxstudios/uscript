// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Perform various floating-point trigonometric functions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Trigonometry", "Perform various floating-point trigonometric functions.")]
public class uScriptAct_Trigonometry : uScriptLogic
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
   // Parameter Attributes are applied below in Tan()
   public void Acos(float input, out float output)
   {
      output = Mathf.Acos(input);
   }

   // Parameter Attributes are applied below in Tan()
   public void Asin(float input, out float output)
   {
      output = Mathf.Asin(input);
   }
   
   // Parameter Attributes are applied below in Tan()
   public void Atan(float input, out float output)
   {
      output = Mathf.Atan(input);
   }

   // Parameter Attributes are applied below in Tan()
   public void Cos(float input, out float output)
   {
      output = Mathf.Cos(input);
   }

   // Parameter Attributes are applied below in Tan()
   public void Sin(float input, out float output)
   {
      output = Mathf.Sin(input);
   }

   // Parameter Attributes are applied below in Tan()
   public void Tan(
      [FriendlyName("Input", "The input value to the trigonometric function.")]
      float input,
      
      [FriendlyName("Output", "The output value of the trigonometric function.")]
      out float output
      )
   {
      output = Mathf.Tan(input);
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
