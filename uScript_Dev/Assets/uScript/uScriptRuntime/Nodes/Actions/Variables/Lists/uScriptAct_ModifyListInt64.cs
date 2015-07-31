// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Int64")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Int64s from a Int64 List. Can also empty the Int64 List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (Int64)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListInt64 : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }
    

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Add To List")]
   public void AddToList(Int64[] Target, ref Int64[] IntList, out int ListCount)
   {
      List<Int64> list = new List<Int64>(IntList);
      
      foreach(Int64 item in Target)
      {
         list.Add(item);
      }

      IntList = list.ToArray();
      ListCount = IntList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(Int64[] Target, ref Int64[] IntList, out int ListCount)
   {
      List<Int64> list = new List<Int64>(IntList);
      
      foreach(Int64 item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      IntList = list.ToArray();
      ListCount = IntList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      Int64[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref Int64[] IntList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      IntList = new Int64[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
