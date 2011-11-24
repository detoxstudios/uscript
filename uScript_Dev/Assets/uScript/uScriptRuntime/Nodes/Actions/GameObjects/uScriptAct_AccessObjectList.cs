// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Access different elements in a GameObject List. Can access first, last, random or by index.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodeDeprecated(typeof(uScriptAct_AccessListGameObject))]

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a GameObject List. Can access first, last, random or by index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Access_GameObject_List")]

//[NodeDescription("GameObject List: The list of GameObjects to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected GameObject (out): The GameObject selected by this node.")]

[FriendlyName("Access GameObject List", "Access different elements in a GameObject List. Can access first, last, random or by index.")]
public class uScriptAct_AccessObjectList : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public void First([FriendlyName("GameObject List")] GameObject[] GameObjectList, int Index, [FriendlyName("Selected GameObject")] out GameObject GameObj)
   {
      GameObj = GameObjectList[0];
   }

   public void Last([FriendlyName("GameObject List")] GameObject[] GameObjectList, int Index, [FriendlyName("Selected GameObject")] out GameObject GameObj)
   {
      GameObj = GameObjectList[GameObjectList.Length - 1];
   }
   
   public void Random([FriendlyName("GameObject List")] GameObject[] GameObjectList, int Index, [FriendlyName("Selected GameObject")] out GameObject GameObj)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, GameObjectList.Length);
      GameObj = GameObjectList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("GameObject List")] GameObject[] GameObjectList, int Index, [FriendlyName("Selected GameObject")] out GameObject GameObj)
   {
      GameObj = GameObjectList[Index];
   }
}
