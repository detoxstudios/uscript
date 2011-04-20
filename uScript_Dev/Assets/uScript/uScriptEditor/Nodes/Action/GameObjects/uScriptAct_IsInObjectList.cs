// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if GameObjects are in a GameObject List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if GameObjects are in a GameObject List.")]
[NodeDescription("Checks to see if GameObjects are in a GameObject List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Is In GameObject List")]
public class uScriptAct_IsInObjectList : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList([FriendlyName("GameObject")] GameObject GameObj, [FriendlyName("GameObject List")] ref GameObject[] GameObjectList)
   {
      List<GameObject> list = new List<GameObject>(GameObjectList);
      m_InList = list.Contains(GameObj);
   }
}
