// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access different elements in a String List. Can access first, last, random or by index.")]
/* M */[NodeDescription("Access different elements in a String List. Can access first, last, random or by index.\n \nString List: The list of strings to operate on.\nIndex: The desired index to select (only used for the At Index input).\nSelected String (out): The string selected by this node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Access_GameObject_List")]

[FriendlyName("Access List (String)")]
public class uScriptAct_AccessListString : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public void First([FriendlyName("String List")] string[] StringList, int Index, [FriendlyName("Selected String")] out string Value)
   {
      Value = StringList[0];
   }

   public void Last([FriendlyName("String List")] string[] StringList, int Index, [FriendlyName("Selected String")] out string Value)
   {
      Value = StringList[StringList.Length - 1];
   }

   public void Random([FriendlyName("String List")] string[] StringList, int Index, [FriendlyName("Selected String")] out string Value)
   {
      System.Random random = new System.Random();
      int index = random.Next(0, StringList.Length);
      Value = StringList[index];
   }
 
   [FriendlyName("At Index")]
   public void AtIndex([FriendlyName("String List")] string[] StringList, int Index, [FriendlyName("Selected String")] out string Value)
   {
      bool outOfRange = false;
      if(Index < 0 || Index >= StringList.Length) {outOfRange = true;}

      if(outOfRange)
      {
         uScriptDebug.Log("[Access List (String)] You are trying to use an index number that is out of range for this list variable. Index 0 was returned instead.", uScriptDebug.Type.Error);
         Value = StringList[0];
      }
      else
      {
         Value = StringList[Index];
      }

   }

}

