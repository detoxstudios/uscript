// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/GameObject")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Reverses the order of GameObjects in a GameObject List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Reverse List (GameObject)", "Reverses the order of GameObjects in a GameObject List.")]
public class uScriptAct_ReverseListGameObject : uScriptLogic
{
   private bool m_Done = false;

   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   //public bool Out { get { return true; } }

   [FriendlyName("Done Reversing")]
   public bool Done { get { return m_Done; } }

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   [FriendlyName("Create Reverse List")]
   public void ReverseList(
      [FriendlyName("Target", "The list to modify.")]
      ref GameObject[] TargetList,

      [FriendlyName("Reverse Original List", "If set to true, the Target List will be modified directly (to match Reversed List).")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool ReverseOriginalList,

      [FriendlyName("Reversed List", "A new list with the reversed order of TargetList.")]
      out GameObject[] ReversedList
      )
   {
      // Reverse the array
      if (TargetList != null && TargetList.Length > 0)
      {
         if (ReverseOriginalList == true)
         {
            for (int i = 0; i < TargetList.Length / 2; i++)
            {
               GameObject tmp = TargetList[i];
               TargetList[i] = TargetList[TargetList.Length - i - 1];
               TargetList[TargetList.Length - i - 1] = tmp;
            }
            ReversedList = TargetList;
         }
         else
         {
            GameObject[] tmpList = new GameObject[TargetList.Length];
            TargetList.CopyTo(tmpList, 0);
            for (int i = 0; i < tmpList.Length / 2; i++)
            {
               GameObject tmp = tmpList[i];
               tmpList[i] = tmpList[tmpList.Length - i - 1];
               tmpList[tmpList.Length - i - 1] = tmp;
            }
            ReversedList = tmpList;
         }
      }
      else
      {
         uScriptDebug.Log("[Reverse List (GameObject)] Supplied Target List was null or empty, skipping.", uScriptDebug.Type.Warning);
         ReversedList = new GameObject[0];
      }

      m_Done = true;
   }

}
