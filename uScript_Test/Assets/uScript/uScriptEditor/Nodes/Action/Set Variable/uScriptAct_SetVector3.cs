// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector3 variable using the value of another Vector3 variable.

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector3 variable using the value of another Vector3 variable.")]
[NodeDescription("Sets the value of a Vector3 variable using the value of another Vector3 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Vector3")]
public class uScriptAct_SetVector3 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector3 Value, [FriendlyName("Target Vector3")] out Vector3 TargetVector3)
   {

      TargetVector3 = Value;

   }
}