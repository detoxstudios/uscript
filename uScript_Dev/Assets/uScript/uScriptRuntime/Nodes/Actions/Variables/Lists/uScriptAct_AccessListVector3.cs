// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Vector3 List. Can access first, last, random or by index.")]
/* M */[NodeDescription("Access different elements in a Vector3 List. Can access first, last, random or by index.\n \nVector3 List: The list of Vector3s to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Vector3 (out): The Vector3 selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Access List (Vector3)")]
public class uScriptAct_AccessListVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void First([FriendlyName("Vector3 List")] Vector3[] List, int Index, [FriendlyName("Selected Vector3")] out Vector3 Value)
   {
      Value = List[0];
   }

   public void Last([FriendlyName("Vector3 List")] Vector3[] List, int Index, [FriendlyName("Selected Vector3")] out Vector3 Value)
   {
      Value = List[List.Length - 1];
   }

   public void Random([FriendlyName("Vector3 List")] Vector3[] List, int Index, [FriendlyName("Selected Vector3")] out Vector3 Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, List.Length);
      Value = List[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Vector3 List")] Vector3[] List, int Index, [FriendlyName("Selected Vector3")] out Vector3 Value)
   {
      bool outOfRange = false;
      if (Index < 0 || Index >= List.Length) { outOfRange = true; }

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Vector3)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = List[0];
      }
      else
      {
         Value = List[Index];
      }

   }

}

