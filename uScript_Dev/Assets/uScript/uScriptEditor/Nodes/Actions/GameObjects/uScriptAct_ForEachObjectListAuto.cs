// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Iterate through each GameObject in a GameObject list (node will automatically iterate through the list).

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Iterate through each GameObject in a GameObject list (node will automatically iterate through the list).")]
[NodeDescription("Iterate through each GameObject in a GameObject list (node will automatically iterate through the list).\n \nGameObject List: The list of GameObjects to iterate over.\nCurrent GameObject (out): The GameObject for the current loop iteration.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("For Each GameObject In List (Auto)")]
public class uScriptAct_ForEachObjectListAuto : uScriptLogic
{
   private GameObject[] m_List = null;
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

   public void In([FriendlyName("GameObject List")] GameObject[] GameObjectList, [FriendlyName("Current GameObject")] out GameObject go)
   {
      if (GameObjectList.Length > 0)
      {
         m_List = GameObjectList;
      }
      else
      {
         m_List = null;
      }
      m_CurrentIndex = 0;
      m_Done = false;

      go = null;
      if (m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            go = m_List[m_CurrentIndex];
         }
         m_CurrentIndex++;
      }

      m_ImmediateDone = false;
   }
 
   [Driven]
   public bool Driven(out GameObject go)
   {
      go = null;
      if (!m_Done && m_List != null)
      {
         if (m_CurrentIndex < m_List.Length)
         {
            go = m_List[m_CurrentIndex];
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
