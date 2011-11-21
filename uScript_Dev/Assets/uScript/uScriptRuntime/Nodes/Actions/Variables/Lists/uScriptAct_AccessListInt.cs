// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Access different elements in a Int List. Can access first, last, random or by index.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Int List. Can access first, last, random or by index.")]
[NodeDescription("Access different elements in a Int List. Can access first, last, random or by index.\n \nInt List: The list of ints to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Int (out): The int selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Access_GameObject_List")]

[FriendlyName("Access List (Int)")]
public class uScriptAct_AccessListInt : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public void First([FriendlyName("Int List")] int[] IntList, int Index, [FriendlyName("Selected Int")] out int Value)
   {
      Value = IntList[0];
   }

   public void Last([FriendlyName("Int List")] int[] IntList, int Index, [FriendlyName("Selected Int")] out int Value)
   {
      Value = IntList[IntList.Length - 1];
   }

   public void Random([FriendlyName("Int List")] int[] IntList, int Index, [FriendlyName("Selected Int")] out int Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, IntList.Length);
      Value = IntList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Int List")] int[] IntList, int Index, [FriendlyName("Selected Int")] out int Value)
   {
      bool outOfRange = false;
      if(Index < 0 || Index >= IntList.Length) {outOfRange = true;}

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Int)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = IntList[0];
      }
      else
      {
         Value = IntList[Index];
      }

   }

}

