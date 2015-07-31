// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector2 as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Vector2)", "Gets the components of a Vector2 as floats.")]
public class uScriptAct_GetComponentsVector2 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Input Vector2", "The input vector to get components of.")]
      Vector2 InputVector2,
      
      [FriendlyName("X", "The X value of the Input Vector2.")]
      out float X,
      
      [FriendlyName("Y", "The Y value of the Input Vector2.")]
      out float Y
      )
   {
      X = InputVector2.x;
      Y = InputVector2.y;
   }
}
