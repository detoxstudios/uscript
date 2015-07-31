// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces a value in the list with the new value at the specified index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Value At Index In List (Rect)", "Replaces a value in the list with the new value at the specified index.")]
public class uScriptAct_ReplaceValueAtIndexInListRect : uScriptLogic
{
	public bool Out { get { return true; } }
   
	public void In(
      [FriendlyName("Target List", "The list to check.")]
      Rect[] TargetList,
      
      [FriendlyName("Index", "The index of the item to replace.")]
      int Index,
      
      [FriendlyName("New Value", "The new value to replace at the index.")]
      Rect NewValue,
      
      [FriendlyName("Modified list", "The List after the values have been changed.")]
      out Rect[] ModifiedList
      )
	{
      if (TargetList.Length > Index)
      {
         TargetList[Index] = NewValue;
      }

      ModifiedList = TargetList;
	}	
}
