// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Replaces all instances of a value in the list with the new value.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces all instances of a value in the list with the new value.")]
[NodeDescription("Replaces all instances of a value in the list with the new value. It will also return the number of values replaced.\n\nTarget List: The list to check.\nOld Value: The value to be replaced.\nNew Value: The new value to replace the old one.\nModified List: The List after the values have been changed.\nFound (out): The number of values that were found and replaced in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Replace Value In List (AudioClip)")]
public class uScriptAct_ReplaceValueInListAudioClip : uScriptLogic
{
	public bool Out { get { return true; } }
   
	public void In(
      [FriendlyName("Target List")] AudioClip[] TargetList,
      [FriendlyName("Old Value")] AudioClip OldValue,
      [FriendlyName("New Value")]  AudioClip NewValue,
      [FriendlyName("Modified list")] out AudioClip[] ModifiedList,
      [FriendlyName("Found"), SocketState(false, false)] out int ValuesFound)
	{
      List<AudioClip> tempList = new List<AudioClip>();
      int foundCount = 0;

      if (TargetList.Length > 0)
      {
         foreach (AudioClip item in TargetList)
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
