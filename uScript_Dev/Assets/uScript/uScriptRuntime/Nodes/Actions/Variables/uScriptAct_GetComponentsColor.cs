// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the components of a color variable as floats.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a color variable as floats.")]
[NodeDescription("Gets the components of a color variable as floats. Unity uses a 0.0-1.0 range to specify color values.\n\nInput Color: The input color to get components of.\nRed: The red value of the Input Color.\nGreen: The green value of the Input Color.\nBlue: The blue value of the Input Color.\nAlpha: The alpha value of the Input Color.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector4_Components")]

[FriendlyName("Get Components (Color)")]
public class uScriptAct_GetComponentsColor : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In([FriendlyName("Input Color")] Color InputColor, out float Red, out float Green, out float Blue, out float Alpha)
   {
      Red = InputColor.r;
      Green = InputColor.g;
      Blue = InputColor.b;
      Alpha = InputColor.a;
   }
}