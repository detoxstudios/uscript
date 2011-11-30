// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector4 is in a Vector4 List.")]
[NodeDescription("Checks to see if a Vector4 is in a Vector4 List.\n \nTarget: The target Vector4(s) to check for membership in the Vector4 List.\nVector4 List (in/out): The Vector4 List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Vector4)")]
public class uScriptAct_IsInListVector4 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      Vector4[] Target,
      [FriendlyName("Vector4 List")] ref Vector4[] List
      )
   {
      List<Vector4> list = new List<Vector4>(List);
      
      m_InList = false;
      foreach (Vector4 target in Target)
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
