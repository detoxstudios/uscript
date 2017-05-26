// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a RaycastHit2D is in a RaycastHit2D List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (RaycastHit2D)", "Checks to see if a RaycastHit2D is in a RaycastHit2D List.")]
public class uScriptAct_IsInListRaycastHit2D : uScriptLogic
{
    private bool m_InList = false;

    [FriendlyName("In List")]
    public bool InList { get { return m_InList; } }

    [FriendlyName("Not In List")]
    public bool NotInList { get { return !m_InList; } }

    [FriendlyName("Test If In List")]
    public void TestIfInList(
       [FriendlyName("Target", "The target RaycastHit2D(s) to check for membership in the RaycastHit2D List.")]
      RaycastHit2D[] Target,

       [FriendlyName("RaycastHit2D List", "The RaycastHit2D List to check.")]
      ref RaycastHit2D[] List,

       [FriendlyName("Found Index", "The index in the RaycastHit2D List that Target is at (-1 if not found or multiple Targets are specified).")]
      [SocketState(false, false)]
      out int Index
       )
    {
        List<RaycastHit2D> list = new List<RaycastHit2D>(List);

        m_InList = false;
        Index = -1;
        foreach (RaycastHit2D target in Target)
        {
            if (!list.Contains(target))
            {
                return;
            }
        }

        // if we get here, all items were in the list
        m_InList = true;

        // if there is only 1 target, return its index in the list
        if (Target.Length == 1)
        {
            Index = list.IndexOf(Target[0]);
        }
    }
}
