// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Camera List. Can access first, last, random or by index.")]
/* M */[NodeDescription("Access different elements in a Camera List. Can access first, last, random or by index.\n \nCamera List: The list of cameras to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Camera (out): The camera selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Access List (Camera)")]
public class uScriptAct_AccessListCamera : uScriptLogic
{
   public bool Out { get { return true; } }

   public void First([FriendlyName("Camera List")] Camera[] List, int Index, [FriendlyName("Selected Camera")] out Camera Value)
   {
      Value = List[0];
   }

   public void Last([FriendlyName("Camera List")] Camera[] List, int Index, [FriendlyName("Selected Camera")] out Camera Value)
   {
      Value = List[List.Length - 1];
   }

   public void Random([FriendlyName("Camera List")] Camera[] List, int Index, [FriendlyName("Selected Camera")] out Camera Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, List.Length);
      Value = List[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Camera List")] Camera[] List, int Index, [FriendlyName("Selected Camera")] out Camera Value)
   {
      bool outOfRange = false;
      if (Index < 0 || Index >= List.Length) { outOfRange = true; }

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Camera)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = List[0];
      }
      else
      {
         Value = List[Index];
      }

   }

}

