// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Vector3 in a Vector3 List (node will automatically iterate through the list).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("For Each In List Auto (Vector3)", "Iterate through each Vector3 in a Vector3 List (node will automatically iterate through the list).")]
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

   public void In(
      [FriendlyName("Vector3 List", "The list of Vector3 variables to iterate over.")]
      Vector3[] List,
      
      [FriendlyName("Current Vector3", "The Vector3 for the current loop iteration.")]
      out Vector3 Value,

      [FriendlyName("Current Index", "The index value for the current loop iteration.")]
      [SocketState(false, false)]
      out int currentIndex
      )
   {
      m_List = List;
      m_CurrentIndex = 0;
      m_Done = false;

      Value = new Vector3(0,0,0);
      currentIndex = m_CurrentIndex;
      if (m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            Value = m_List[m_CurrentIndex];
            currentIndex = m_CurrentIndex;
         }
         m_CurrentIndex++;
      }

      m_ImmediateDone = false;
   }
 
   [Driven]
   public bool Driven(out Vector3 Value, out int CurrentIndex)
   {
      Value = new Vector3(0,0,0);
      CurrentIndex = m_CurrentIndex;
      if (!m_Done && m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            Value = m_List[m_CurrentIndex];
            CurrentIndex = m_CurrentIndex;
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
