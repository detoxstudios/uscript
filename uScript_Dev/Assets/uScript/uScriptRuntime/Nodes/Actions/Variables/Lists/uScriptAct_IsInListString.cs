// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if a string is in a String List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a string is in a String List.")]
[NodeDescription("Checks to see if a string is in a String List.\n \nTarget: The target string(s) to check for membership in the String List.\nString List (in/out): The String List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (String)")]
public class uScriptAct_IsInListString : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      string[] Target,
      [FriendlyName("String List")] ref string[] List
      )
   {
      List<string> list = new List<string>(List);
      
      m_InList = false;
      foreach(string target in Target)
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
