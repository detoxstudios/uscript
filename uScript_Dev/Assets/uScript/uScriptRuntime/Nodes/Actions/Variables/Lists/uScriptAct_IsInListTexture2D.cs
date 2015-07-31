// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a Texture2D is in a Texture2D List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (Texture2D)", "Checks to see if a Texture2D is in a Texture2D List.")]
public class uScriptAct_IsInListTexture2D : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyName("Target", "The target Texture2D(s) to check for membership in the Texture2D List.")]
      Texture2D[] Target,

      [FriendlyName("Texture2D List", "The Texture2D List to check.")]
      ref Texture2D[] List,

      [FriendlyName("Found Index", "The index in the Texture2D List that Target is at (-1 if not found or multiple Targets are specified).")]
      out int Index
      )
   {
      List<Texture2D> list = new List<Texture2D>(List);
      
      m_InList = false;
      Index = -1;
      foreach (Texture2D target in Target)
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
