// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds/removes strings from a String List. Can also empty the String List.")]
/* M */[NodeDescription("Adds/removes strings from a String List. Can also empty the String List.\n \nTarget: The Target strings(s) to add or remove from the String List.\nString List: The String List to modify.\nList Count (out): The remaining number of items in the String List after modification has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List (String)")]
public class uScriptAct_ModifyListString : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Add To List")]
   public void AddToList(
      string[] Target,
      [FriendlyName("String List")] ref string[] StringList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<string> list = new List<string>(StringList);
      
      foreach(string item in Target)
      {
         list.Add(item);
      }

      StringList = list.ToArray();
      ListCount = StringList.Length;
   }

   [FriendlyName("Remove From List")]
   public void RemoveFromList(
      string[] Target,
      [FriendlyName("String List")] ref string[] StringList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      List<string> list = new List<string>(StringList);
      
      foreach(string item in Target)
      {
         if (list.Contains(item))
         {
            list.Remove(item);
         }
      }

      StringList = list.ToArray();
      ListCount = StringList.Length;
   }

   [FriendlyName("Empty List")]
   public void EmptyList(
      string[] Target,
      [FriendlyName("String List")] ref string[] StringList,
      [FriendlyName("List Count")] out int ListCount
      )
   {
      StringList = new string[] { };
      ListCount = 0;
   }
}
