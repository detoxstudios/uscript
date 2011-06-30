// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector3 to the defined X, Y, and Z float component values.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector3 to the defined X, Y, and Z float component values.")]
[NodeDescription("Sets a Vector3 to the defined X, Y, and Z float component values.\n \nX: X value to use for the Output Vector.\nY: Y value to use for the Output Vector.\nZ: Z value to use for the Output Vector.\nOutput Vector3 (out): Vector3 variable built from the specified X, Y, and Z.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector3_Components")]

[FriendlyName("Set Vector3 Components")]
public class uScriptAct_SetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, [FriendlyName("Output Vector3")] out Vector3 OutputVector3)
   {
      OutputVector3 = new Vector3(X, Y, Z);
   }
}