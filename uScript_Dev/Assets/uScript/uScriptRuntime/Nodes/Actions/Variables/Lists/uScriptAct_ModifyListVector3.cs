// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes Vector3 from a Vector3 List. Can also empty the Vector3 List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Vector3 from a Vector3 List. Can also empty the Vector3 List.")]
[NodeDescription("Adds/removes Vector3 from a Vector3 List. Can also empty the Vector3 List.\n \nTarget: The Target Vector3(s) to add or remove from the Vector3 List.\nVector3 List: The Vector3 List to modify.\nList Count (out): The remaining number of items in the Vector3 List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Vector3)")]
public class uScriptAct_ModifyListVector3 : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Vector3[] Target,
      [FriendlyName("Vector3 List")] ref Vector3[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector3> list = new List<Vector3>(List);

      foreach (Vector3 item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Vector3[] Target,
      [FriendlyName("Vector3 List")] ref Vector3[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector3> list = new List<Vector3>(List);

      foreach (Vector3 item in Target)
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
      Vector3[] Target,
      [FriendlyName("Vector3 List")] ref Vector3[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Vector3[] { };
      ListCount = 0;
   }
}
