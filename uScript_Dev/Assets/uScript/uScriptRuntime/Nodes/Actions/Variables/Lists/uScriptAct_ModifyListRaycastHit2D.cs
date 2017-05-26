// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Adds/removes RaycastHit2Ds from a RaycastHit2D List. Can also empty the RaycastHit2D List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modify List (RaycastHit2D)", "Modify a list by adding/removing the specified variable(s), or by emptying it entirely.")]
public class uScriptAct_ModifyListRaycastHit2D : uScriptLogic
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
    public void AddToList(RaycastHit2D[] Target, ref RaycastHit2D[] List, out int ListCount)
    {
        List<RaycastHit2D> list = new List<RaycastHit2D>(List);

        foreach (RaycastHit2D item in Target)
        {
            list.Add(item);
        }

        List = list.ToArray();
        ListCount = List.Length;
    }

    // Parameter Attributes are applied below in EmptyList()
    [FriendlyName("Remove From List")]
    public void RemoveFromList(RaycastHit2D[] Target, ref RaycastHit2D[] List, out int ListCount)
    {
        List<RaycastHit2D> list = new List<RaycastHit2D>(List);

        foreach (RaycastHit2D item in Target)
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
      RaycastHit2D[] Target,

       [FriendlyName("List", "The list to modify.")]
      ref RaycastHit2D[] List,

       [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
       )
    {
        List = new RaycastHit2D[] { };
        ListCount = 0;
    }


    // ================================================================================
    //    Miscellaneous Node Functionality
    // ================================================================================
    //
}
