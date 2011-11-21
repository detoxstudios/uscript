// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Access different elements in a Float List. Can access first, last, random or by index.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Float List. Can access first, last, random or by index.")]
[NodeDescription("Access different elements in a Float List. Can access first, last, random or by index.\n \nFloat List: The list of floats to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Float (out): The float selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Access_GameObject_List")]

[FriendlyName("Access List (Float)")]
public class uScriptAct_AccessListFloat : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public void First([FriendlyName("Float List")] float[] FloatList, int Index, [FriendlyName("Selected Float")] out float Value)
   {
      Value = FloatList[0];
   }

   public void Last([FriendlyName("Float List")] float[] FloatList, int Index, [FriendlyName("Selected Float")] out float Value)
   {
      Value = FloatList[FloatList.Length - 1];
   }

   public void Random([FriendlyName("Float List")] float[] FloatList, int Index, [FriendlyName("Selected Float")] out float Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, FloatList.Length);
      Value = FloatList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Float List")] float[] FloatList, int Index, [FriendlyName("Selected Float")] out float Value)
   {
      bool outOfRange = false;
      if(Index < 0 || Index >= FloatList.Length) {outOfRange = true;}

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Float)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = FloatList[0];
      }
      else
      {
         Value = FloatList[Index];
      }

   }

}

