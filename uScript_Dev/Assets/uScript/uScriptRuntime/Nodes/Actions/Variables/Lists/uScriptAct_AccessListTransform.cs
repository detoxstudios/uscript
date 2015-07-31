// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Transform")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a Transform List. Can access first, last, random or by index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Access List (Transform)", "Access the contents of a list. May return the first or last item, a random item, or the item at a specific index.")]
public class uScriptAct_AccessListTransform : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }
 

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in AtIndex()
   public void First(Transform[] TransformList, int Index, out Transform GameObj)
   {
      GameObj = TransformList[0];
   }

   // Parameter Attributes are applied below in AtIndex()
   public void Last(Transform[] TransformList, int Index, out Transform GameObj)
   {
      GameObj = TransformList[TransformList.Length - 1];
   }
   
   // Parameter Attributes are applied below in AtIndex()
   public void Random(Transform[] TransformList, int Index, out Transform GameObj)
   {
      int index = UnityEngine.Random.Range(0, TransformList.Length);
      GameObj = TransformList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex(
      [FriendlyName("List", "The list to operate on.")]
      Transform[] TransformList,

      [FriendlyName("Index", "The index or position of the item to return. If the list contains 5 items, the valid range is 0-4, where 0 is the first item. (this parameter is only used with the At Index input).")]
      int Index,

      [FriendlyName("Selected", "The selected variable.")]
      out Transform GameObj
      )
   {
      bool outOfRange = false;
      if (Index < 0 || Index >= TransformList.Length) { outOfRange = true; }

      if (outOfRange)
      {
         uScriptDebug.Log("[Access List (Transform)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         GameObj = TransformList[0];
      }
      else
      {
         GameObj = TransformList[Index];
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
