// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/ContactPoint")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a ContactPoint is in a ContactPoint List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is In List (ContactPoint)", "Checks to see if a ContactPoint is in a ContactPoint List.")]
public class uScriptAct_IsInListContactPoint : uScriptLogic
{
    private bool m_InList = false;

    [FriendlyName("In List")]
    public bool InList { get { return m_InList; } }

    [FriendlyName("Not In List")]
    public bool NotInList { get { return !m_InList; } }

    [FriendlyName("Test If In List")]
    public void TestIfInList(
       [FriendlyName("Target", "The target ContactPoint(s) to check for membership in the ContactPoint List.")]
      ContactPoint[] Target,

       [FriendlyName("ContactPoint List", "The ContactPoint List to check.")]
      ref ContactPoint[] List,

       [FriendlyName("Found Index", "The index in the ContactPoint List that Target is at (-1 if not found or multiple Targets are specified).")]
      [SocketState(false, false)]
      out int Index
       )
    {
        List<ContactPoint> list = new List<ContactPoint>(List);

        m_InList = false;
        Index = -1;
        foreach (ContactPoint target in Target)
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
