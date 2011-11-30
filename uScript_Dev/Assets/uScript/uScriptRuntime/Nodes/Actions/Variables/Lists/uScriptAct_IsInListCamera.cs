// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a camera is in a Camera List.")]
[NodeDescription("Checks to see if a camera is in a Camera List.\n \nTarget: The target camera(s) to check for membership in the Camera List.\nCamera List (in/out): The Camera List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (Camera)")]
public class uScriptAct_IsInListCamera : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      Camera[] Target,
      [FriendlyName("Camera List")] ref Camera[] List
      )
   {
      List<Camera> list = new List<Camera>(List);
      
      m_InList = false;
      foreach (Camera target in Target)
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
