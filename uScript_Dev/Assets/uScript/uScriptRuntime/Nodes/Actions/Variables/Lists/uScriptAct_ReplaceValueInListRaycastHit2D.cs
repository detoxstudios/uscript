// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value In List (RaycastHit2D)", "Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.")]
public class uScriptAct_ReplaceValueInListRaycastHit2D : uScriptLogic
{
    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target List", "The list to check.")]
      RaycastHit2D[] TargetList,

      [FriendlyName("Old Value", "The value to be replaced.")]
      RaycastHit2D OldValue,

      [FriendlyName("New Value", "The new value to replace the old one.")]
      RaycastHit2D NewValue,

      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out RaycastHit2D[] ModifiedList,

      [FriendlyName("Found", "The number of values that were found and replaced in the list.")]
      [SocketState(false, false)]
      out int ValuesFound
      )
    {
        List<RaycastHit2D> tempList = new List<RaycastHit2D>();
        int foundCount = 0;

        if (TargetList.Length > 0)
        {
            foreach (RaycastHit2D item in TargetList)
            {
                if (item.Equals(OldValue))
                {
                    tempList.Add(NewValue);
                    foundCount++;
                }
                else
                {
                    tempList.Add(item);
                }
            }
            ModifiedList = tempList.ToArray();
            ValuesFound = foundCount;
        }
        else
        {
            ModifiedList = TargetList;
            ValuesFound = foundCount;
        }
    }
}
