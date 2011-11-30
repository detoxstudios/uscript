// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Vector3 in a Vector3 List (uScript events must drive each iteration).")]
/* M */[NodeDescription("Iterate through each Vector3 in a Vector3 List (uScript events must drive each iteration).\n \nVector3 List: The list of Vector3s to iterate over.\nCurrent Vector3 (out): The Vector3 for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List (Vector3)")]
public class uScriptAct_ForEachListVector3 : uScriptLogic
{
   private Vector3[] m_List = null;
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
   public void Reset([FriendlyName("Vector3 List")] Vector3[] List, [FriendlyName("Current Vector3")] out Vector3 Value)
   {
      Value = new Vector3(0,0,0);
      if (m_List == null)
      {
         uScriptDebug.Log("For Each List (Vector3) must go through 'Manual' input before 'Resetting'.", uScriptDebug.Type.Error);
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

   public void In([FriendlyName("Vector3 List")] Vector3[] List, [FriendlyName("Current Vector3")] out Vector3 Value)
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
      Value = new Vector3(0,0,0);
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
