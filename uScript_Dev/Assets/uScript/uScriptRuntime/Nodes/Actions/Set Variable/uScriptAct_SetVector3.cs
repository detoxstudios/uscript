// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector3 variable using the value of another Vector3 variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector3 variable using the value of another Vector3 variable.")]
[NodeDescription("Sets the value of a Vector3 variable using the value of another Vector3 variable.\n \nValue: The Vector3 variable to be set.\nTarget Vector3 (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector3")]

[FriendlyName("Set Vector3")]
public class uScriptAct_SetVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3 Value, [FriendlyName("Target Vector3")] out Vector3 TargetVector3)
   {
      TargetVector3 = Value;
   }
}