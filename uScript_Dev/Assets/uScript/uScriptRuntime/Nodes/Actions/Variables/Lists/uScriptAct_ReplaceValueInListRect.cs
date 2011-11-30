// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeDescription("Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.\n\nTarget List: The list to check.\nOld Value: The value to be replaced.\nNew Value: The new value to replace the old one.\nModified List: The List after the values have been changed.\nFound (out): The number of values that were found and replaced in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Replace Value In List (Rect)")]
public class uScriptAct_ReplaceValueInListRect : uScriptLogic
{
	public bool Out { get { return true; } }
   
	public void In(
      [FriendlyName("Target List")] Rect[] TargetList,
      [FriendlyName("Old Value")] Rect OldValue,
      [FriendlyName("New Value")]  Rect NewValue,
      [FriendlyName("Modified list")] out Rect[] ModifiedList,
      [FriendlyName("Found"), SocketState(false, false)] out int ValuesFound)
	{
      List<Rect> tempList = new List<Rect>();
      int foundCount = 0;

      if (TargetList.Length > 0)
      {
         foreach (Rect item in TargetList)
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
