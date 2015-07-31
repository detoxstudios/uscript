// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Vector4 is in a Vector4 List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (Vector4)", "Checks to see if a Vector4 is in a Vector4 List.")]
public class uScriptAct_IsInListVector4 : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyName("Target", "The target Vector4(s) to check for membership in the Vector4 List.")]
      Vector4[] Target,
      
      [FriendlyName("Vector4 List", "The Vector4 List to check.")]
      ref Vector4[] List,

      [FriendlyName("Found Index", "The index in the Vector4 List that Target is at (-1 if not found or multiple Targets are specified).")]
      out int Index
      )
   {
      List<Vector4> list = new List<Vector4>(List);
      
      m_InList = false;
      Index = -1;
      foreach (Vector4 target in Target)
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
