// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the components of a Vector3 as floats.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector3 as floats.")]
[NodeDescription("Gets the components of a Vector3 as floats.\n \nInput Vector3: The input vector to get components of.\nX: The x value of the Input Vector3.\nY: The y value of the Input Vector3.\nZ: The z value of the Input Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector3_Components")]

[FriendlyName("Get Vector3 Components")]
public class uScriptAct_GetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In([FriendlyName("Input Vector3")]Vector3 InputVector3, out float X, out float Y, out float Z)
   {
      X = InputVector3.x;
      Y = InputVector3.y;
      Z = InputVector3.z;
   }
}