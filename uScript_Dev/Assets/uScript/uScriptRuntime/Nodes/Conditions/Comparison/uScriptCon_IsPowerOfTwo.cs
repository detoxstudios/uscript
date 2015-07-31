// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Determines if the target Int is a power of two number.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is Power of Two", "Determines if the target Int is a power of two number.")]
public class uScriptCon_IsPowerOfTwo : uScriptLogic
{

   private bool m_IsPOT = false;

   [FriendlyName("True")]
   public bool True { get { return m_IsPOT; } }

   [FriendlyName("False")]
   public bool False { get { return !m_IsPOT; } }
    
   public void In(
      [FriendlyName("Target", "The integer variable to compare.")]
      int Target
      )
   {

#if (!UNITY_3_0 && !UNITY_3_1)
      m_IsPOT = Mathf.IsPowerOfTwo(Target);
#else
      uScriptDebug.Log("The 'Is Power Of Two' action node will only work with Unity version 3.2.0 and higher! It will always report false in older versions.", uScriptDebug.Type.Warning);
#endif

   }

}
