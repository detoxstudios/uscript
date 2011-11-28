// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each int in a Int List (uScript events must drive each iteration).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each int in a Int List (uScript events must drive each iteration).")]
/* M */[NodeDescription("Iterate through each int in a Int List (uScript events must drive each iteration).\n \nInt List: The list of ints to iterate over.\nCurrent Int (out): The int for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List (Int)")]
public class uScriptAct_ForEachListInt : uScriptLogic
{
   private int[] m_List = null;
   private int m_CurrentIndex = 0;
   private bool m_Done = false;
   private bool m_ImmediateDone = false;

   public bool Immediate
   {
      get
      { 
         if (!m_ImmediateDone)
         {
            m_ImmediateDone = true;
            return true; 
         }
         
         return false;
      } 
   }
   
   [FriendlyName("Done Iterating")]
   public bool Done { get { return m_Done; } }

   [FriendlyName("Iteration")]
   public bool Iteration { get { return m_List != null && m_CurrentIndex <= m_List.Length && m_CurrentIndex != 0; } }

   [FriendlyName("Reset")]
   public void Reset([FriendlyName("Int List")] int[] List, [FriendlyName("Current Int")] out int Value)
   {
      Value = 0;
      if (m_List == null)
      {
         uScriptDebug.Log("For Each List (Int) must go through 'Manual' input before 'Resetting'.", uScriptDebug.Type.Error);
         return;
      }

      if (List.Length > 0)
      {
         m_List = List;
      }
      else
      {
         m_List = null;
      }
      m_CurrentIndex = 0;
      m_Done = false;

      m_ImmediateDone = false;
   }

   public void In([FriendlyName("Int List")] int[] List, [FriendlyName("Current Int")] out int Value)
   {
      if (m_List == null)
      {
         if (List.Length > 0)
         {
            m_List = List;
         }
         else
         {
            m_List = null;
         }
         m_CurrentIndex = 0;
         m_Done = false;
      }

      m_ImmediateDone = !(m_List != null && m_CurrentIndex == 0);
      Value = 0;
      if (m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            Value = m_List[m_CurrentIndex];
         }
         m_CurrentIndex++;

         // done iterating
         if (m_CurrentIndex > m_List.Length)
         {
            m_List = null;
            m_Done = true;
         }
      }
   }
}
