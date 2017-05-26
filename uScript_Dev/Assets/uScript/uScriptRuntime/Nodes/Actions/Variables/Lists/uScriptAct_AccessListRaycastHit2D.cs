// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a RaycastHit2D List. Can access first, last, random or by index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Access List (RaycastHit2D)", "Access the contents of a list. May return the first or last item, a random item, or the item at a specific index.")]
public class uScriptAct_AccessListRaycastHit2D : uScriptLogic
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
    // Parameter Attributes are applied below in AtIndex()
    public void First(RaycastHit2D[] List, int Index, out RaycastHit2D Value)
    {
        Value = List[0];
    }

    // Parameter Attributes are applied below in AtIndex()
    public void Last(RaycastHit2D[] List, int Index, out RaycastHit2D Value)
    {
        Value = List[List.Length - 1];
    }

    // Parameter Attributes are applied below in AtIndex()
    public void Random(RaycastHit2D[] List, int Index, out RaycastHit2D Value)
    {
        int index = UnityEngine.Random.Range(0, List.Length);
        Value = List[index];
    }

    [FriendlyName("At Index")]
    public void AtIndex(
       [FriendlyName("List", "The list to operate on.")]
      RaycastHit2D[] List,

       [FriendlyName("Index", "The index or position of the item to return. If the list contains 5 items, the valid range is 0-4, where 0 is the first item. (this parameter is only used with the At Index input).")]
      int Index,

       [FriendlyName("Selected", "The selected variable.")]
      out RaycastHit2D Value
       )
    {
        bool outOfRange = false;
        if (Index < 0 || Index >= List.Length) { outOfRange = true; }

        if (outOfRange)
        {
            uScriptDebug.Log("[Access List (RaycastHit2D)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
            Value = List[0];
        }
        else
        {
            Value = List[Index];
        }
    }


    // ================================================================================
    //    Miscellaneous Node Functionality
    // ================================================================================
    //
}
