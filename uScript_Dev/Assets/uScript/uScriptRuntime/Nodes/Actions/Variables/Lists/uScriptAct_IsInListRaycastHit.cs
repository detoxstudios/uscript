// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a RaycastHit is in a RaycastHit List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (RaycastHit)", "Checks to see if a RaycastHit is in a RaycastHit List.")]
public class uScriptAct_IsInListRaycastHit : uScriptLogic
{
    private bool m_InList = false;

    [FriendlyName("In List")]
    public bool InList { get { return m_InList; } }

    [FriendlyName("Not In List")]
    public bool NotInList { get { return !m_InList; } }

    [FriendlyName("Test If In List")]
    public void TestIfInList(
       [FriendlyName("Target", "The target RaycastHit(s) to check for membership in the RaycastHit List.")]
      RaycastHit[] Target,

       [FriendlyName("RaycastHit List", "The RaycastHit List to check.")]
      ref RaycastHit[] List,

       [FriendlyName("Found Index", "The index in the RaycastHit List that Target is at (-1 if not found or multiple Targets are specified).")]
      [SocketState(false, false)]
      out int Index
       )
    {
        List<RaycastHit> list = new List<RaycastHit>(List);

        m_InList = false;
        Index = -1;
        foreach (RaycastHit target in Target)
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
