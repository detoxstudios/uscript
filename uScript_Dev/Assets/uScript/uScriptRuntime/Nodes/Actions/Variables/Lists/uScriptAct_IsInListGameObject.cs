// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if GameObjects are in a GameObject List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if GameObjects are in a GameObject List.")]
[NodeDescription("Checks to see if GameObjects are in a GameObject List.\n \nTarget: The target GameObject(s) to check for membership in the GameObject list.\nGameObject List (in/out): The list of GameObjects to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_In_GameObject_List")]

[FriendlyName("Is In List (GameObject)")]
public class uScriptAct_IsInListGameObject : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      GameObject[] Target,
      [FriendlyName("GameObject List")] ref GameObject[] GameObjectList
      )
   {
      List<GameObject> list = new List<GameObject>(GameObjectList);
      
      m_InList = false;
      foreach(GameObject target in Target)
      {
         if (!list.Contains(target))
         {
            return;
         }
      }
      
      // if we get here, all items were in the list
      m_InList = true;
   }
}
