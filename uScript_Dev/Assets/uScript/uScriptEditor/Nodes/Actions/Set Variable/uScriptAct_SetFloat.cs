// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a float to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a float to the defined value.")]
[NodeDescription("Sets a float to the defined value.\n \nValue: The float variable to be set.\nTarget (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Float")]
public class uScriptAct_SetFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Value, out float Target)
   {
      Target = Value;
   }
}