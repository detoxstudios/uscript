// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector3 is in a Vector3 List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (Vector3)", "Checks to see if a Vector3 is in a Vector3 List.")]
public class uScriptAct_IsInListVector3 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyName("Target", "The target Vector3(s) to check for membership in the Vector3 List.")]
      Vector3[] Target,
      
      [FriendlyName("Vector3 List", "The Vector3 List to check.")]
      ref Vector3[] List,

      [FriendlyName("Found Index", "The index in the Vector3 List that Target is at (-1 if not found or multiple Targets are specified).")]
      out int Index
      )
   {
      List<Vector3> list = new List<Vector3>(List);
      
      m_InList = false;
      Index = -1;
      foreach (Vector3 target in Target)
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
