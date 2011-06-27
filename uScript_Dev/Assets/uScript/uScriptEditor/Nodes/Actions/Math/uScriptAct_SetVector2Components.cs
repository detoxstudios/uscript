// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets a Vector2 to the defined X, Y, and Z float component values.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector2 to the defined X and Y float component values.")]
[NodeDescription("Sets a Vector2 to the defined X and Y float component values.\n \nX: X value to use for the Output Vector.\nY: Y value to use for the Output Vector.\nOutput Vector2 (out): Vector2 variable built from the specified X and Y.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Vector2 Components")]
public class uScriptAct_SetVector2Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, [FriendlyName("Output Vector2")] out Vector2 OutputVector2)
   {
      OutputVector2 = new Vector2(X, Y);
   }
}