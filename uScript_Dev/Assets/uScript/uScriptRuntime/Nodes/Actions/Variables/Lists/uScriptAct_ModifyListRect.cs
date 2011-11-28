// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes Rect from a Rect List. Can also empty the Rect List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Rect from a Rect List. Can also empty the Rect List.")]
/* M */[NodeDescription("Adds/removes Rect from a Rect List. Can also empty the Rect List.\n \nTarget: The Target Rect(s) to add or remove from the Rect List.\nRect List: The Rect List to modify.\nList Count (out): The remaining number of items in the Rect List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Rect)")]
public class uScriptAct_ModifyListRect : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Rect[] Target,
      [FriendlyName("Rect List")] ref Rect[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Rect> list = new List<Rect>(List);

      foreach (Rect item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Rect[] Target,
      [FriendlyName("Rect List")] ref Rect[] List,
      [FriendlyName("List Count")] out int ListCount
      )
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
      Rect[] Target,
      [FriendlyName("Rect List")] ref Rect[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Rect[] { };
      ListCount = 0;
   }
}
