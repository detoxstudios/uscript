// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Color List. Can access first, last, random or by index.")]
/* M */[NodeDescription("Access different elements in a Color List. Can access first, last, random or by index.\n \nColor List: The list of Colors to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Color (out): The Color selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Access List (Color)")]
public class uScriptAct_AccessListColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void First([FriendlyName("Color List")] Color[] List, int Index, [FriendlyName("Selected Color")] out Color Value)
   {
      Value = List[0];
   }

   public void Last([FriendlyName("Color List")] Color[] List, int Index, [FriendlyName("Selected Color")] out Color Value)
   {
      Value = List[List.Length - 1];
   }

   public void Random([FriendlyName("Color List")] Color[] List, int Index, [FriendlyName("Selected Color")] out Color Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, List.Length);
      Value = List[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Color List")] Color[] List, int Index, [FriendlyName("Selected Color")] out Color Value)
   {
      bool outOfRange = false;
      if (Index < 0 || Index >= List.Length) { outOfRange = true; }

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Color)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = List[0];
      }
      else
      {
         Value = List[Index];
      }

   }

}

