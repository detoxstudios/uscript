// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/KeyCode")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Adds/removes KeyCodes from a KeyCode List. Can also empty the KeyCode List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (KeyCode)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListKeyCode : uScriptLogic
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
   public void AddToList(KeyCode[] Target, ref KeyCode[] KeyCodeList, out int ListCount)
   {
      List<KeyCode> list = new List<KeyCode>(KeyCodeList);
      
      foreach(KeyCode item in Target)
      {
         list.Add(item);
      }

      KeyCodeList = list.ToArray();
      ListCount = KeyCodeList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(KeyCode[] Target, ref KeyCode[] KeyCodeList, out int ListCount)
   {
      List<KeyCode> list = new List<KeyCode>(KeyCodeList);
      
      foreach(KeyCode item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      KeyCodeList = list.ToArray();
      ListCount = KeyCodeList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      KeyCode[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref KeyCode[] KeyCodeList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      KeyCodeList = new KeyCode[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
