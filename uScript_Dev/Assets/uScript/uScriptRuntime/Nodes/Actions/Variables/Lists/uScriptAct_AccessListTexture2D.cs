// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Access different elements in a Texture2D List. Can access first, last, random or by index.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Texture2D List. Can access first, last, random or by index.")]
[NodeDescription("Access different elements in a Texture2D List. Can access first, last, random or by index.\n \nTexture2D List: The list of Texture2Ds to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected Texture2D (out): The Texture2D selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Access List (Texture2D)")]
public class uScriptAct_AccessListTexture2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void First([FriendlyName("Texture2D List")] Texture2D[] List, int Index, [FriendlyName("Selected Texture2D")] out Texture2D Value)
   {
      Value = List[0];
   }

   public void Last([FriendlyName("Texture2D List")] Texture2D[] List, int Index, [FriendlyName("Selected Texture2D")] out Texture2D Value)
   {
      Value = List[List.Length - 1];
   }

   public void Random([FriendlyName("Texture2D List")] Texture2D[] List, int Index, [FriendlyName("Selected Texture2D")] out Texture2D Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, List.Length);
      Value = List[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("Texture2D List")] Texture2D[] List, int Index, [FriendlyName("Selected Texture2D")] out Texture2D Value)
   {
      bool outOfRange = false;
      if (Index < 0 || Index >= List.Length) { outOfRange = true; }

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (Texture2D)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = List[0];
      }
      else
      {
         Value = List[Index];
      }

   }

}

