// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each Vector3 in a Vector3 List (node will automatically iterate through the list).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Vector3 in a Vector3 List (node will automatically iterate through the list).")]
[NodeDescription("Iterate through each Vector3 in a Vector3 List (node will automatically iterate through the list).\n \nVector3 List: The list of Vector3s to iterate over.\nCurrent Vector3 (out): The Vector3 for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List Auto (Vector3)")]
public class uScriptAct_ForEachListVector3Auto : uScriptLogic
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

   public void In([FriendlyName("Vector3 List")] Vector3[] List, [FriendlyName("Current Vector3")] out Vector3 Value)
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

      Value = new Vector3(0,0,0);
      if (m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            Value = m_List[m_CurrentIndex];
         }
         m_CurrentIndex++;
      }

      m_ImmediateDone = false;
   }
 
   [Driven]
   public bool Driven(out Vector3 Value)
   {
      Value = new Vector3(0,0,0);
      if (!m_Done && m_List != null)
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

         return true;
      }

      return false;
   }
}
