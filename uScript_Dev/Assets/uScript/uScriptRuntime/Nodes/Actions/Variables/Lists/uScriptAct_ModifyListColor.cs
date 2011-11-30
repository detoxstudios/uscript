// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Colors from a Color List. Can also empty the Color List.")]
/* M */[NodeDescription("Adds/removes Colors from a Color List. Can also empty the Color List.\n \nTarget: The Target Color(s) to add or remove from the Color List.\nColor List: The Color List to modify.\nList Count (out): The remaining number of items in the Color List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Color)")]
public class uScriptAct_ModifyListColor : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Color[] Target,
      [FriendlyName("Color List")] ref Color[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Color> list = new List<Color>(List);

      foreach (Color item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Color[] Target,
      [FriendlyName("Color List")] ref Color[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Color> list = new List<Color>(List);

      foreach (Color item in Target)
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
      Color[] Target,
      [FriendlyName("Color List")] ref Color[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Color[] { };
      ListCount = 0;
   }
}
