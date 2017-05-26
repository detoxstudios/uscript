// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/RaycastHit")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value In List (RaycastHit)", "Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.")]
public class uScriptAct_ReplaceValueInListRaycastHit : uScriptLogic
{
    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target List", "The list to check.")]
      RaycastHit[] TargetList,

      [FriendlyName("Old Value", "The value to be replaced.")]
      RaycastHit OldValue,

      [FriendlyName("New Value", "The new value to replace the old one.")]
      RaycastHit NewValue,

      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out RaycastHit[] ModifiedList,

      [FriendlyName("Found", "The number of values that were found and replaced in the list.")]
      [SocketState(false, false)]
      out int ValuesFound
      )
    {
        List<RaycastHit> tempList = new List<RaycastHit>();
        int foundCount = 0;

        if (TargetList.Length > 0)
        {
            foreach (RaycastHit item in TargetList)
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
