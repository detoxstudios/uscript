// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Inverse a boolean variable to its opposite value. Example: true becomes false

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Inverse a boolean variable to its opposite value.")]
[NodeDescription("Inverse a boolean variable to its opposite value.\n \nTarget: Value to invert.\nValue (out): Inverted value (true -> false or false -> true).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert Bool")]
public class uScriptAct_InvertBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(bool Target, out bool Value)
   {
      Value = !Target;
   }
}