// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Transform")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if Transforms are in a Transform List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Is_In_Transform_List")]

[FriendlyName("Is In List (Transform)", "Checks to see if Transforms are in a Transform List.")]
public class uScriptAct_IsInListTransform : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      [FriendlyName("Target", "The target Transform(s) to check for membership in the Transform list.")]
      Transform[] Target,

      [FriendlyName("Transform List", "The Transform List to check.")]
      ref Transform[] TransformList
      )
   {
      List<Transform> list = new List<Transform>(TransformList);
      
      m_InList = false;
      foreach(Transform target in Target)
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
