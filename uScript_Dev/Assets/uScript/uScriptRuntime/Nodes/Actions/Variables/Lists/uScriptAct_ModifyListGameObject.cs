// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.")]
/* M */[NodeDescription("Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.\n \nTarget: The Target GameObject(s) to add or remove from the GameObject list.\nGameObject List: The GameObject list to modify.\nList Count (out): The remaining number of items in the GameObject List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Modify_GameObject_List")]

[FriendlyName("Modify List (GameObject)")]
public class uScriptAct_ModifyListGameObject : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList
      (GameObject[] Target, 
      [FriendlyName("GameObject List")] ref GameObject[] GameObjectList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<GameObject> list = new List<GameObject>(GameObjectList);
      
      foreach(GameObject go in Target)
      {
         list.Add(go);
      }
 
      GameObjectList = list.ToArray();
      ListCount = GameObjectList.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      GameObject[] Target, 
      [FriendlyName("GameObject List")] ref GameObject[] GameObjectList,
      [FriendlyName("List Count")] out int ListCount
      )
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
      GameObject[] Target,
      [FriendlyName("GameObject List")] ref GameObject[] GameObjectList, 
      [FriendlyName("List Count")] out int ListCount
      )
   {
      GameObjectList = new GameObject[] {};
      ListCount = 0;
   }
}
