// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector4 variable using the value of another Vector4 variable.

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector4 variable using the value of another Vector4 variable.")]
[NodeDescription("Sets the value of a Vector4 variable using the value of another Vector4 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Vector4")]
public class uScriptAct_SetVector4 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector4 Value, [FriendlyName("Target Vector4")] out Vector4 TargetVector4)
   {

      TargetVector4 = Value;

   }
}