// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a color variable as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Color)", "Returns the individual components of a Color variable. The component values are normalized using the range of 0.0 (none) to 1.0 (full).")]
public class uScriptAct_GetComponentsColor : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input Color", "The input color to get components of.")]
      Color InputColor,

      [FriendlyName("Red", "The Red value of the Input Color.")]
      out float Red,
      
      [FriendlyName("Green", "The Green value of the Input Color.")]
      out float Green,
      
      [FriendlyName("Blue", "The Blue value of the Input Color.")]
      out float Blue,
      
      [FriendlyName("Alpha", "The Alpha value of the Input Color.")]
      out float Alpha
      )
   {
      Red = InputColor.r;
      Green = InputColor.g;
      Blue = InputColor.b;
      Alpha = InputColor.a;
   }
}
