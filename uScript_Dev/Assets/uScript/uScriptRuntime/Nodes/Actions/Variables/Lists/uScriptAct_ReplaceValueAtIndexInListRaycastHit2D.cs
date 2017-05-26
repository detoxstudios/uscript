// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Replaces a value in the list with the new value at the specified index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value At Index In List (RaycastHit2D)", "Replaces a value in the list with the new value at the specified index.")]
public class uScriptAct_ReplaceValueAtIndexInListRaycastHit2D : uScriptLogic
{
    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target List", "The list to check.")]
      RaycastHit2D[] TargetList,

      [FriendlyName("Index", "The index of the item to replace.")]
      int Index,

      [FriendlyName("New Value", "The new value to replace at the index.")]
      RaycastHit2D NewValue,

      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out RaycastHit2D[] ModifiedList
      )
    {
        if (TargetList.Length > Index)
        {
            TargetList[Index] = NewValue;
        }

        ModifiedList = TargetList;
    }
}
