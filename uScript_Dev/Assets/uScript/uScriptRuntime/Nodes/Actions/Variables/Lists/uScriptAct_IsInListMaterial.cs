// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Material")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Material is in a Material List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (Material)", "Checks to see if a Material is in a Material List.")]
public class uScriptAct_IsInListMaterial : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyName("Target", "The target Material(s) to check for membership in the Material List.")]
      Material[] Target,

      [FriendlyName("Material List", "The Material List to check.")]
      ref Material[] List,

      [FriendlyName("Found Index", "The index in the Material List that Target is at (-1 if not found or multiple Targets are specified).")]
      out int Index
      )
   {
      List<Material> list = new List<Material>(List);
      
      m_InList = false;
      Index = -1;
      foreach (Material target in Target)
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
