// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each AudioClip in a AudioClip List (node will automatically iterate through the list).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each AudioClip in a AudioClip List (node will automatically iterate through the list).")]
[NodeDescription("Iterate through each AudioClip in a AudioClip List (node will automatically iterate through the list).\n \nAudioClip List: The list of AudioClips to iterate over.\nCurrent AudioClip (out): The AudioClip for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("For Each In List Auto (AudioClip)")]
public class uScriptAct_ForEachListAudioClipAuto : uScriptLogic
{
   private AudioClip[] m_List = null;
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

   public void In([FriendlyName("AudioClip List")] AudioClip[] List, [FriendlyName("Current AudioClip")] out AudioClip Value)
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
   public bool Driven(out AudioClip Value)
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
