// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/ContactPoint")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Adds/removes ContactPoints from a ContactPoint List. Can also empty the ContactPoint List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (ContactPoint)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListContactPoint : uScriptLogic
{
    // ================================================================================
    //    Output Sockets
    // ================================================================================
    //
    public bool Out { get { return true; } }


    // ================================================================================
    //    Input Sockets and Node Parameters
    // ================================================================================
    //
    // Parameter Attributes are applied below in EmptyList()
    [FriendlyName("Add To List")]
    public void AddToList(ContactPoint[] Target, ref ContactPoint[] List, out int ListCount)
    {
        List<ContactPoint> list = new List<ContactPoint>(List);

        foreach (ContactPoint item in Target)
        {
            list.Add(item);
        }

        List = list.ToArray();
        ListCount = List.Length;
    }

    // Parameter Attributes are applied below in EmptyList()
    [FriendlyName("Remove From List")]
    public void RemoveFromList(ContactPoint[] Target, ref ContactPoint[] List, out int ListCount)
    {
        List<ContactPoint> list = new List<ContactPoint>(List);

        foreach (ContactPoint item in Target)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
            }
        }

        List = list.ToArray();
        ListCount = List.Length;
    }

    [FriendlyName("Empty List")]
    public void EmptyList(
       [FriendlyName("Target", "The Target variable(s) to add or remove from the list.")]
      ContactPoint[] Target,

       [FriendlyName("List", "The list to modify.")]
      ref ContactPoint[] List,

       [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
       )
    {
        List = new ContactPoint[] { };
        ListCount = 0;
    }


    // ================================================================================
    //    Miscellaneous Node Functionality
    // ================================================================================
    //
}
