// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a int is in a Int List.")]
[NodeDescription("Checks to see if a int is in a Int List.\n \nTarget: The target int(s) to check for membership in the Int List.\nInt List (in/out): The Int List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Int)")]
public class uScriptAct_IsInListInt : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      int[] Target,
      [FriendlyName("Int List")] ref int[] List
      )
   {
      List<int> list = new List<int>(List);
      
      m_InList = false;
      foreach(int target in Target)
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
