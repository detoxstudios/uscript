// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector3 is in a Vector3 List.")]
[NodeDescription("Checks to see if a Vector3 is in a Vector3 List.\n \nTarget: The target Vector3(s) to check for membership in the Vector3 List.\nVector3 List (in/out): The Vector3 List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Vector3)")]
public class uScriptAct_IsInListVector3 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      Vector3[] Target,
      [FriendlyName("Vector3 List")] ref Vector3[] List
      )
   {
      List<Vector3> list = new List<Vector3>(List);
      
      m_InList = false;
      foreach (Vector3 target in Target)
      {
         if (!list.Contains(target))
         {
            return;
         }
      }
      
      // if we get here, all items were in the list
      m_InList = true;
   }
}
