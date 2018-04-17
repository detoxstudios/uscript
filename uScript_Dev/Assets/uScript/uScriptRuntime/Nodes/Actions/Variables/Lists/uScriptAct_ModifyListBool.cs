// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes bools from a Bool List. Can also empty the Bool List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (Bool)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListBool : uScriptLogic
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
   public void AddToList(bool[] Target, ref bool[] BoolList, out int ListCount)
   {
      List<bool> list = new List<bool>(BoolList);
      
      foreach(bool item in Target)
      {
         list.Add(item);
      }

      BoolList = list.ToArray();
      ListCount = BoolList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(bool[] Target, ref bool[] BoolList, out int ListCount)
   {
      List<bool> list = new List<bool>(BoolList);
      
      foreach(bool item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      BoolList = list.ToArray();
      ListCount = BoolList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      bool[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref bool[] BoolList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      BoolList = new bool[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
