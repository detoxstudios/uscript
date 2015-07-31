// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector2 to the defined X and Y float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Vector2)", "Sets a Vector2 to the defined X and Y float component values.")]
public class uScriptAct_SetComponentsVector2 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("X", "X value to use for the Output Vector.")]
      float X,
      
      [FriendlyName("Y", "Y value to use for the Output Vector.")]
      float Y,
      
      [FriendlyName("Output Vector2", "Vector2 variable built from the specified X and Y.")]
      out Vector2 OutputVector2
      )
   {
      OutputVector2 = new Vector2(X, Y);
   }
}
