// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a AudioClip is in a AudioClip List.")]
[NodeDescription("Checks to see if a AudioClip is in a AudioClip List.\n \nTarget: The target AudioClip(s) to check for membership in the AudioClip List.\nAudioClip List (in/out): The AudioClip List to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Is In List (AudioClip)")]
public class uScriptAct_IsInListAudioClip : uScriptLogic
{
   private bool m_InList = false;
   
   [FriendlyName("In List")]
   public bool InList { get { return m_InList; } }
 
   [FriendlyName("Not In List")]
   public bool NotInList { get { return !m_InList; } }
    
   [FriendlyName("Test If In List")]
   public void TestIfInList(
      AudioClip[] Target,
      [FriendlyName("AudioClip List")] ref AudioClip[] List
      )
   {
      List<AudioClip> list = new List<AudioClip>(List);
      
      m_InList = false;
      foreach (AudioClip target in Target)
      {
         if (!list.Contains(target))
         {
            return;
         }
      }
      
      // if we get here, all items were in the list
      m_InList = true;
   }
}
