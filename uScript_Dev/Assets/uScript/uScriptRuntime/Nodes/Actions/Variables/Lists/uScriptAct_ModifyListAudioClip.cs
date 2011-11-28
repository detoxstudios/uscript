// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds/removes AudioClips from a AudioClip List. Can also empty the AudioClip List.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes AudioClips from a AudioClip List. Can also empty the AudioClip List.")]
/* M */[NodeDescription("Adds/removes AudioClips from a AudioClip List. Can also empty the AudioClip List.\n \nTarget: The Target AudioClip(s) to add or remove from the AudioClip List.\nAudioClip List: The AudioClip List to modify.\nList Count (out): The remaining number of items in the AudioClip List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (AudioClip)")]
public class uScriptAct_ModifyListAudioClip : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      AudioClip[] Target,
      [FriendlyName("AudioClip List")] ref AudioClip[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<AudioClip> list = new List<AudioClip>(List);

      foreach (AudioClip item in Target)
      {
         list.Add(item);
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      AudioClip[] Target,
      [FriendlyName("AudioClip List")] ref AudioClip[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<AudioClip> list = new List<AudioClip>(List);

      foreach (AudioClip item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      List = list.ToArray();
      ListCount = List.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      AudioClip[] Target,
      [FriendlyName("AudioClip List")] ref AudioClip[] List,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List = new AudioClip[] { };
      ListCount = 0;
   }
}
