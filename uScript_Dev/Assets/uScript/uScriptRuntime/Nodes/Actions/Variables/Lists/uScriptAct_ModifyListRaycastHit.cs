// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Adds/removes RaycastHits from a RaycastHit List. Can also empty the RaycastHit List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (RaycastHit)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListRaycastHit : uScriptLogic
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
    public void AddToList(RaycastHit[] Target, ref RaycastHit[] List, out int ListCount)
    {
        List<RaycastHit> list = new List<RaycastHit>(List);

        foreach (RaycastHit item in Target)
        {
            list.Add(item);
        }

        List = list.ToArray();
        ListCount = List.Length;
    }

    // Parameter Attributes are applied below in EmptyList()
    [FriendlyName("Remove From List")]
    public void RemoveFromList(RaycastHit[] Target, ref RaycastHit[] List, out int ListCount)
    {
        List<RaycastHit> list = new List<RaycastHit>(List);

        foreach (RaycastHit item in Target)
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
      RaycastHit[] Target,

       [FriendlyName("List", "The list to modify.")]
      ref RaycastHit[] List,

       [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
       )
    {
        List = new RaycastHit[] { };
        ListCount = 0;
    }


    // ================================================================================
    //    Miscellaneous Node Functionality
    // ================================================================================
    //
}
