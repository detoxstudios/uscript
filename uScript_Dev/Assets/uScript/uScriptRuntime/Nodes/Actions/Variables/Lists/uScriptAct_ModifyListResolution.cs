// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Resolution")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes resolutions from a Resolution List. Can also empty the Resolution List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (Resolution)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListResolution : uScriptLogic
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
   public void AddToList(Resolution[] Target, ref Resolution[] ResolutionList, out int ListCount)
   {
      List<Resolution> list = new List<Resolution>(ResolutionList);
      
      foreach(Resolution item in Target)
      {
         list.Add(item);
      }

      ResolutionList = list.ToArray();
      ListCount = ResolutionList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(Resolution[] Target, ref Resolution[] ResolutionList, out int ListCount)
   {
      List<Resolution> list = new List<Resolution>(ResolutionList);
      
      foreach(Resolution item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      ResolutionList = list.ToArray();
      ListCount = ResolutionList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      Resolution[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref Resolution[] ResolutionList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      ResolutionList = new Resolution[] { };
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
