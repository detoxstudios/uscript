// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.")]
[NodeDescription("Adds/removes GameObjects from a GameObject List. Can also empty the GameObject List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Modify GameObject List")]
public class uScriptAct_ModifyGameObjectList : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(GameObject[] Target, [FriendlyName("GameObject List")] ref GameObject[] GameObjectList, [FriendlyName("List Count")] out int ListCount)
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
   public void RemoveFromList(GameObject[] Target, [FriendlyName("GameObject List")] ref GameObject[] GameObjectList, [FriendlyName("List Count")] out int ListCount)
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
   public void EmptyList(GameObject[] Target, [FriendlyName("GameObject List")] ref GameObject[] GameObjectList,  [FriendlyName("List Count")] out int ListCount)
   {
      GameObjectList = new GameObject[] {};
      ListCount = 0;
   }
}
