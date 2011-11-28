// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes Texture2D from a Texture2D List. Can also empty the Texture2D List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Texture2D from a Texture2D List. Can also empty the Texture2D List.")]
/* M */[NodeDescription("Adds/removes Texture2D from a Texture2D List. Can also empty the Texture2D List.\n \nTarget: The Target Texture2D(s) to add or remove from the Texture2D List.\nTexture2D List: The Texture2D List to modify.\nList Count (out): The remaining number of items in the Texture2D List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Texture2D)")]
public class uScriptAct_ModifyListTexture2D : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Texture2D[] Target,
      [FriendlyName("Texture2D List")] ref Texture2D[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Texture2D> list = new List<Texture2D>(List);

      foreach (Texture2D item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Texture2D[] Target,
      [FriendlyName("Texture2D List")] ref Texture2D[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Texture2D> list = new List<Texture2D>(List);

      foreach (Texture2D item in Target)
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
      Texture2D[] Target,
      [FriendlyName("Texture2D List")] ref Texture2D[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Texture2D[] { };
      ListCount = 0;
   }
}
