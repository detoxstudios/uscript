// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes cameras from a Camera List. Can also empty the Camera List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes cameras from a Camera List. Can also empty the Camera List.")]
[NodeDescription("Adds/removes cameras from a Camera List. Can also empty the Camera List.\n \nTarget: The Target camera(s) to add or remove from the Camera List.\nCamera List: The Camera List to modify.\nList Count (out): The remaining number of items in the Camera List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Camera)")]
public class uScriptAct_ModifyListCamera : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      Camera[] Target,
      [FriendlyName("Camera List")] ref Camera[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Camera> list = new List<Camera>(List);

      foreach (Camera item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      Camera[] Target,
      [FriendlyName("Camera List")] ref Camera[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<Camera> list = new List<Camera>(List);

      foreach (Camera item in Target)
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
      Camera[] Target,
      [FriendlyName("Camera List")] ref Camera[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new Camera[] { };
      ListCount = 0;
   }
}
