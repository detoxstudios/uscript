// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Rect from a Rect List. Can also empty the Rect List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (Rect)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListRect : uScriptLogic
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
   public void AddToList(Rect[] Target, ref Rect[] List, out int ListCount)
   {
      List<Rect> list = new List<Rect>(List);

      foreach (Rect item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(Rect[] Target, ref Rect[] List, out int ListCount)
   {
      List<Rect> list = new List<Rect>(List);

      foreach (Rect item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      Rect[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref Rect[] List,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      List = new Rect[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
