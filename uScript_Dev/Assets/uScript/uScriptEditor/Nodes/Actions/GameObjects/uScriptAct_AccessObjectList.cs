// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Access different elements in a GameObject List. Can access first, last, random or by index.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a GameObject List. Can access first, last, random or by index.")]
[NodeDescription("Access different elements in a GameObject List. Can access first, last, random or by index.\n \nGameObject List: The list of GameObjects to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected GameObject (out): The GameObject selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Access GameObject List")]
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
      int index = random.Next(0, GameObjectList.Length - 1);
      GameObj = GameObjectList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("GameObject List")] GameObject[] GameObjectList, int Index, [FriendlyName("Selected GameObject")] out GameObject GameObj)
   {
      GameObj = GameObjectList[Index];
   }
}
