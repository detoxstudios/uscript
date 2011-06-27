// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two Vector4 variables and outputs accordingly.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares two Vector4 variables and outputs accordingly.")]
[NodeDescription("Compares two Vector4 variables and outputs accordingly.\n \nA: First Vector4 to compare.\nB: Second Vector4 to compare.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Compare Vector4")]
public class uScriptCon_CompareVector4 : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool Same { get { return m_CompareValue; } }
   public bool Different { get { return !m_CompareValue; } }

   public void In(Vector4 A, Vector4 B)
   {
      m_CompareValue = A == B;
   }
}