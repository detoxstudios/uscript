// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Resolution")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value In List (Resolution)", "Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.")]
public class uScriptAct_ReplaceValueInListResolution : uScriptLogic
{
	public bool Out { get { return true; } }
   
	public void In(
      [FriendlyName("Target List", "The list to check.")]
      Resolution[] TargetList,
      
      [FriendlyName("Old Value", "The value to be replaced.")]
      Resolution OldValue,
      
      [FriendlyName("New Value", "The new value to replace the old one.")]
      Resolution NewValue,
      
      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out Resolution[] ModifiedList,
      
      [FriendlyName("Found", "The number of values that were found and replaced in the list.")]
      [SocketState(false, false)]
      out int ValuesFound
      )
	{
      List<Resolution> tempList = new List<Resolution>();
      int foundCount = 0;

      if (TargetList.Length > 0)
      {
         foreach (Resolution item in TargetList)
         {
            if (item.width == OldValue.width &&
                item.height == OldValue.height &&
                item.refreshRate == OldValue.refreshRate)
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
