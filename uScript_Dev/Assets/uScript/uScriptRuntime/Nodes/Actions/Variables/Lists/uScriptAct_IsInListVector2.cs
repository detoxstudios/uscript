// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector2 is in a Vector2 List.")]
[NodeDescription("Checks to see if a Vector2 is in a Vector2 List.\n \nTarget: The target Vector2(s) to check for membership in the Vector2 List.\nVector2 List (in/out): The Vector2 List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Vector2)")]
public class uScriptAct_IsInListVector2 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      Vector2[] Target,
      [FriendlyName("Vector2 List")] ref Vector2[] List
      )
   {
      List<Vector2> list = new List<Vector2>(List);
      
      m_InList = false;
      foreach (Vector2 target in Target)
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
