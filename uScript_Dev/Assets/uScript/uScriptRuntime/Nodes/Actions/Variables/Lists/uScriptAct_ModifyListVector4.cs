// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes Vector4 from a Vector4 List. Can also empty the Vector4 List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Vector4 from a Vector4 List. Can also empty the Vector4 List.")]
[NodeDescription("Adds/removes Vector4 from a Vector4 List. Can also empty the Vector4 List.\n \nTarget: The Target Vector4(s) to add or remove from the Vector4 List.\nVector4 List: The Vector4 List to modify.\nList Count (out): The remaining number of items in the Vector4 List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Vector4)")]
public class uScriptAct_ModifyListVector4 : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Vector4[] Target,
      [FriendlyName("Vector4 List")] ref Vector4[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector4> list = new List<Vector4>(List);

      foreach (Vector4 item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Vector4[] Target,
      [FriendlyName("Vector4 List")] ref Vector4[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Vector4> list = new List<Vector4>(List);

      foreach (Vector4 item in Target)
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
      Vector4[] Target,
      [FriendlyName("Vector4 List")] ref Vector4[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Vector4[] { };
      ListCount = 0;
   }
}
