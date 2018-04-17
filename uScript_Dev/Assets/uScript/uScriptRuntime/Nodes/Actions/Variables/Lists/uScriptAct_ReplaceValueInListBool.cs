// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value In List (Bool)", "Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.")]
public class uScriptAct_ReplaceValueInListBool : uScriptLogic
{
	public bool Out { get { return true; } }
   
	public void In(
      [FriendlyName("Target List", "The list to check.")]
      bool[] TargetList,
      
      [FriendlyName("Old Value", "The value to be replaced.")]
      bool OldValue,
      
      [FriendlyName("New Value", "The new value to replace the old one.")]
      bool NewValue,
      
      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out bool[] ModifiedList,
      
      [FriendlyName("Found", "The number of values that were found and replaced in the list.")]
      [SocketState(false, false)]
      out int ValuesFound
      )
	{
		List<bool> tempList = new List<bool>();
      int foundCount = 0;

      if (TargetList.Length > 0)
      {
         foreach (bool item in TargetList)
         {
            if (item == OldValue)
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
