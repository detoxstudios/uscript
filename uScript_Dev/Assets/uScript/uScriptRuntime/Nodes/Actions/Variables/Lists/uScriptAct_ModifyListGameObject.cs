// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (GameObject)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListGameObject : uScriptLogic
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
   public void AddToList(GameObject[] Target, ref GameObject[] GameObjectList, out int ListCount)
   {
      List<GameObject> list = new List<GameObject>(GameObjectList);
      
      foreach(GameObject go in Target)
      {
         list.Add(go);
      }
 
      GameObjectList = list.ToArray();
      ListCount = GameObjectList.Length;
   }

   // Parameter Attributes are applied below in EmptyList()
   [FriendlyName("Remove From List")]
   public void RemoveFromList(GameObject[] Target, ref GameObject[] GameObjectList, out int ListCount)
   {
      List<GameObject> list = new List<GameObject>(GameObjectList);
      
      foreach(GameObject go in Target)
      {
         if (list.Contains(go))
         {
            list.Remove(go);
         }
      }
      
      GameObjectList = list.ToArray();
      ListCount = GameObjectList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      GameObject[] Target,

      [FriendlyName("List", "The list to modify.")]
      ref GameObject[] GameObjectList,

      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
   {
      GameObjectList = new GameObject[] {};
      ListCount = 0;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
