// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes Vector2 from a Vector2 List. Can also empty the Vector2 List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Vector2 from a Vector2 List. Can also empty the Vector2 List.")]
[NodeDescription("Adds/removes Vector2 from a Vector2 List. Can also empty the Vector2 List.\n \nTarget: The Target Vector2(s) to add or remove from the Vector2 List.\nVector2 List: The Vector2 List to modify.\nList Count (out): The remaining number of items in the Vector2 List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Vector2)")]
public class uScriptAct_ModifyListVector2 : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Vector2[] Target,
      [FriendlyName("Vector2 List")] ref Vector2[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector2> list = new List<Vector2>(List);

      foreach (Vector2 item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Vector2[] Target,
      [FriendlyName("Vector2 List")] ref Vector2[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector2> list = new List<Vector2>(List);

      foreach (Vector2 item in Target)
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
      Vector2[] Target,
      [FriendlyName("Vector2 List")] ref Vector2[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Vector2[] { };
      ListCount = 0;
   }
}
