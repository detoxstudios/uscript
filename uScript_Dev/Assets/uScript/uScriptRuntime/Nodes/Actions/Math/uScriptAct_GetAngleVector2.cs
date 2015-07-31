// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Angles")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the angle in degrees between target A and target B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Angle (Vector2)", "Returns the angle in degrees between target A and target B.")]
public class uScriptAct_GetAngleVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first target.")] Vector2 A,
      [FriendlyName("B", "The second target.")] Vector2 B,
      [FriendlyName("Angle", "The resulting angle between the two targets in degrees.")] out float Angle)
   {
      Angle = Vector2.Angle(A, B);
   }
}