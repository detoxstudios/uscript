// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes floats from a Float List. Can also empty the Float List.")]
/* M */[NodeDescription("Adds/removes floats from a Float List. Can also empty the Float List.\n \nTarget: The Target floats(s) to add or remove from the Float List.\nFloat List: The Float List to modify.\nList Count (out): The remaining number of items in the Float List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (Float)")]
public class uScriptAct_ModifyListFloat : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      float[] Target,
      [FriendlyName("Float List")] ref float[] FloatList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<float> list = new List<float>(FloatList);
      
      foreach(float item in Target)
      {
         list.Add(item);
      }

      FloatList = list.ToArray();
      ListCount = FloatList.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      float[] Target,
      [FriendlyName("Float List")] ref float[] FloatList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<float> list = new List<float>(FloatList);
      
      foreach(float item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      FloatList = list.ToArray();
      ListCount = FloatList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      float[] Target,
      [FriendlyName("Float List")] ref float[] FloatList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      FloatList = new float[] { };
      ListCount = 0;
   }
}
