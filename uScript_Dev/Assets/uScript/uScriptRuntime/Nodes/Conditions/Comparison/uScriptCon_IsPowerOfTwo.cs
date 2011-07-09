// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Determines if the target Int is a power of two number.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Determines if the target Int is a power of two number.")]
[NodeDescription("Determines if the target Int is a power of two number.\n\nTarget: The target Int variable to compare.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_Power_of_Two")]

[FriendlyName("Is Power of Two")]
public class uScriptCon_IsPowerOfTwo : uScriptLogic
{
   private bool m_IsPOT = false;

   [FriendlyName("True")]
   public bool True { get { return m_IsPOT; } }

   [FriendlyName("False")]
   public bool False { get { return !m_IsPOT; } }
    
   public void In(int Target)
   {
      m_IsPOT = Mathf.IsPowerOfTwo(Target);
   }
}
