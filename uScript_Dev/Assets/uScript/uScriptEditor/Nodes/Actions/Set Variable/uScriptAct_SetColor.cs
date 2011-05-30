// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Color variable using the value of another Color variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Color variable using the value of another Color variable.")]
[NodeDescription("Sets the value of a Color variable using the value of another Color variable.\n \nValue: The Color variable to be set.\nTarget Color (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Color")]
public class uScriptAct_SetColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Color Value, [FriendlyName("Target Color")] out Color TargetColor)
   {
      TargetColor = Value;
   }
}