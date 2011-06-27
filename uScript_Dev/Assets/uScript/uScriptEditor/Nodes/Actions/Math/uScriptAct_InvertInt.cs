// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any non-zero target integer and outputs its inverse version. Example: -2 becomes 2

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any non-zero target integer and outputs its inverse version.")]
[NodeDescription("Takes any non-zero target integer and outputs its inverse version.\n \nTarget: Value to invert.\nValue (out): Inverted value (3 -> -3 or -1 -> 1).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Invert Int")]
public class uScriptAct_InvertInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Target, out int Value)
   {
      Value = -Target;
   }
}