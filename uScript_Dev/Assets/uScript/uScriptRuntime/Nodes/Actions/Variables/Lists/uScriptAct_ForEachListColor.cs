// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each Color in a Color List (uScript events must drive each iteration).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Color in a Color List (uScript events must drive each iteration).")]
/* M */[NodeDescription("Iterate through each Color in a Color List (uScript events must drive each iteration).\n \nColor List: The list of Colors to iterate over.\nCurrent Color (out): The Color for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List (Color)")]
public class uScriptAct_ForEachListColor : uScriptLogic
{
   private Color[] m_List = null;
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
   public void Reset([FriendlyName("Color List")] Color[] List, [FriendlyName("Current Color")] out Color Value)
   {
      Value = UnityEngine.Color.white;
      if (m_List == null)
      {
         uScriptDebug.Log("For Each List (Color) must go through 'Manual' input before 'Resetting'.", uScriptDebug.Type.Error);
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

   public void In([FriendlyName("Color List")] Color[] List, [FriendlyName("Current Color")] out Color Value)
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
      Value = UnityEngine.Color.white;
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
