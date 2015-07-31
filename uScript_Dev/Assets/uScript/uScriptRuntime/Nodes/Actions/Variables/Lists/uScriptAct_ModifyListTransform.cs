// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Transform")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes Transforms from a Transform List. Can also empty the Transform List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (Transform)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListTransform : uScriptLogic
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
   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Add To List")]
   public void AddToList(Transform[] Target, ref Transform[] TransformList, out int ListCount)
   {
      List<Transform> list = new List<Transform>(TransformList);
      
      foreach(Transform go in Target)
      {
         list.Add(go);
      }
 
      TransformList = list.ToArray();
      ListCount = TransformList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(Transform[] Target, ref Transform[] TransformList, out int ListCount)
   {
      List<Transform> list = new List<Transform>(TransformList);
      
      foreach(Transform go in Target)
      {
         if (list.Contains(go))
         {
            list.Remove(go);
         }
      }
      
      TransformList = list.ToArray();
      ListCount = TransformList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      Transform[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref Transform[] TransformList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      TransformList = new Transform[] {};
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
