// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each Texture2D in a Texture2D List (node will automatically iterate through the list).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each Texture2D in a Texture2D List (node will automatically iterate through the list).")]
[NodeDescription("Iterate through each Texture2D in a Texture2D List (node will automatically iterate through the list).\n \nTexture2D List: The list of Texture2Ds to iterate over.\nCurrent Texture2D (out): The Texture2D for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List Auto (Texture2D)")]
public class uScriptAct_ForEachListTexture2DAuto : uScriptLogic
{
   private Texture2D[] m_List = null;
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

   public void In([FriendlyName("Texture2D List")] Texture2D[] List, [FriendlyName("Current Texture2D")] out Texture2D Value)
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

      Value = null;
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
   public bool Driven(out Texture2D Value)
   {
      Value = null;
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
