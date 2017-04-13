// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/ContactPoint")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Replaces a value in the list with the new value at the specified index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value At Index In List (ContactPoint)", "Replaces a value in the list with the new value at the specified index.")]
public class uScriptAct_ReplaceValueAtIndexInListContactPoint : uScriptLogic
{
    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target List", "The list to check.")]
      ContactPoint[] TargetList,

      [FriendlyName("Index", "The index of the item to replace.")]
      int Index,

      [FriendlyName("New Value", "The new value to replace at the index.")]
      ContactPoint NewValue,

      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out ContactPoint[] ModifiedList
      )
    {
        if (TargetList.Length > Index)
        {
            TargetList[Index] = NewValue;
        }

        ModifiedList = TargetList;
    }
}
