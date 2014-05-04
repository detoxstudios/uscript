// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Outputs True if the target GameObjects are not null (unassigned/empty).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is GameObject Null", "Outputs True if the target GameObjects are not null (unassigned/empty). If checking multiple GameObjects at once, the node will fire the Is Null socket if ANY of the target GameObjects are null.")]
public class uScriptCon_IsNull : uScriptLogic
{
   private bool m_IsNull = false;

   [FriendlyName("Is Null")]
   public bool IsNull { get { return m_IsNull; } }
   [FriendlyName("Is Not Null")]
   public bool IsNotNull { get { return !m_IsNull; } }
    
   public void In(
      [FriendlyName("Target", "The GameObject you wish to see is null or not. Will also except multiple GameObject variables or a GameObject List variable.")]
      GameObject[] Target
      )
   {
      bool nullFound = false;
      foreach (GameObject go in Target)
      {
         if ( null == go )
         {
            nullFound = true;
         }
      }

      // Send out signal
      m_IsNull = nullFound;
          
    }
}
