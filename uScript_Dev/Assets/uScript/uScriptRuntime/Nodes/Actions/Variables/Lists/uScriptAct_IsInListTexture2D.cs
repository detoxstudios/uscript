// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if a Texture2D is in a Texture2D List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Texture2D is in a Texture2D List.")]
[NodeDescription("Checks to see if a Texture2D is in a Texture2D List.\n \nTarget: The target Texture2D(s) to check for membership in the Texture2D List.\nTexture2D List (in/out): The Texture2D List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Texture2D)")]
public class uScriptAct_IsInListTexture2D : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      Texture2D[] Target,
      [FriendlyName("Texture2D List")] ref Texture2D[] List
      )
   {
      List<Texture2D> list = new List<Texture2D>(List);
      
      m_InList = false;
      foreach (Texture2D target in Target)
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
