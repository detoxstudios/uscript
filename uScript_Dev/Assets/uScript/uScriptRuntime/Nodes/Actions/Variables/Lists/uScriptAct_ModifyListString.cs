// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes strings from a String List. Can also empty the String List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (String)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListString : uScriptLogic
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
   public void AddToList(string[] Target, ref string[] StringList, out int ListCount)
   {
      List<string> list = new List<string>(StringList);
      
      foreach(string item in Target)
      {
         list.Add(item);
      }

      StringList = list.ToArray();
      ListCount = StringList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(string[] Target, ref string[] StringList, out int ListCount)
   {
      List<string> list = new List<string>(StringList);
      
      foreach(string item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      StringList = list.ToArray();
      ListCount = StringList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      string[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref string[] StringList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      StringList = new string[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
