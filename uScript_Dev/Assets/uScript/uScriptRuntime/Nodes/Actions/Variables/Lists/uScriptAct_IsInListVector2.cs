// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector2 is in a Vector2 List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (Vector2)", "Checks to see if a Vector2 is in a Vector2 List.")]
public class uScriptAct_IsInListVector2 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyNameAttribute("Target", "The target Vector2(s) to check for membership in the Vector2 List.")]
      Vector2[] Target,
      
      [FriendlyName("Vector2 List", "The Vector2 List to check.")]
      ref Vector2[] List,

      [FriendlyName("Found Index", "The index in the Vector2 List that Target is at (-1 if not found or multiple Targets are specified).")]
      out int Index
      )
   {
      List<Vector2> list = new List<Vector2>(List);
      
      m_InList = false;
      Index = -1;
      foreach (Vector2 target in Target)
      {
         if (!list.Contains(target))
         {
            return;
         }
      }
      
      // if we get here, all items were in the list
      m_InList = true;

      // if there is only 1 target, return its index in the list
      if (Target.Length == 1)
      {
         Index = list.IndexOf(Target[0]);
      }
   }
}
