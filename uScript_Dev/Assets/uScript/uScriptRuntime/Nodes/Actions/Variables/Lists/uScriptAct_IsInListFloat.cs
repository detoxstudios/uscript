// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if a int is in a Float List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a int is in a Float List.")]
[NodeDescription("Checks to see if a int is in a Float List.\n \nTarget: The target int(s) to check for membership in the Float List.\nFloat List (in/out): The Float List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Float)")]
public class uScriptAct_IsInListFloat : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      int[] Target,
      [FriendlyName("Float List")] ref float[] List
      )
   {
      List<float> list = new List<float>(List);
      
      m_InList = false;
      foreach(float target in Target)
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
