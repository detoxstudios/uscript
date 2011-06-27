// uScript Condition Node
// (C) 2010 Detox Studios LLC
// Desc: Fires the appropriate output link depending on the comparison of the attached bool variable.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate output link depending on the comparison of the attached bool variable.")]
[NodeDescription("Fires the appropriate output link depending on the comparison of the attached bool variable.\n \nBool: The boolean value to compare.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Compare Bool")]
public class uScriptCon_CompareBool : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool True { get { return m_CompareValue; } }
   public bool False { get { return !m_CompareValue; } }

   public void In(bool Bool)
   {
      m_CompareValue = Bool;
   }
}
