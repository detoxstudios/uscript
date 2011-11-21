// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes ints from a Int List. Can also empty the Int List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes ints from a Int List. Can also empty the Int List.")]
[NodeDescription("Adds/removes ints from a Int List. Can also empty the Int List.\n \nTarget: The Target ints(s) to add or remove from the Int List.\nInt List: The Int List to modify.\nList Count (out): The remaining number of items in the Int List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Int)")]
public class uScriptAct_ModifyListInt : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      int[] Target,
      [FriendlyName("Int List")] ref int[] IntList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<int> list = new List<int>(IntList);
      
      foreach(int item in Target)
      {
         list.Add(item);
      }

      IntList = list.ToArray();
      ListCount = IntList.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      int[] Target,
      [FriendlyName("Int List")] ref int[] IntList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<int> list = new List<int>(IntList);
      
      foreach(int item in Target)
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
      int[] Target,
      [FriendlyName("Int List")] ref int[] IntList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      IntList = new int[] { };
      ListCount = 0;
   }
}
