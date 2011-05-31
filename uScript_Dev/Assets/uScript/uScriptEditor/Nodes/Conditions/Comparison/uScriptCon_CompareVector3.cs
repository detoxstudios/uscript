// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two Vector3 variables and outputs accordingly.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares two Vector3 variables and outputs accordingly.")]
[NodeDescription("Compares two Vector3 variables and outputs accordingly.\n \nA: First Vector3 to compare.\nB: Second Vector3 to compare.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Compare Vector3")]
public class uScriptCon_CompareVector3 : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool Same { get { return m_CompareValue; } }
   public bool Different { get { return !m_CompareValue; } }

   public void In(Vector3 A, Vector3 B)
   {
      m_CompareValue = A == B;
   }
}