// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any non-zero target float and outputs its inverse version. Example: 3.25 becomes -3.25

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any non-zero target float and outputs its inverse version.")]
[NodeDescription("Takes any non-zero float integer and outputs its inverse version.\n \nTarget: Value to invert.\nValue (out): Inverted value (3.25 -> -3.25 or -1.0 -> 1.0).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert Float")]
public class uScriptAct_InvertFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Target, out float Value)
   {
      Value = -Target;
   }
}