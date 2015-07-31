// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the index number for a quality setting by its name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Index From Quality Name", "Gets the index number for a quality setting by its name.")]
public class uScriptAct_QualitySettingsGetIndexFromName : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name", "The name of the quality setting you wish to get the index for. Note: letter casing must match.")] string qualityName,
      [FriendlyName("Index", "Returns the index of the specified quality setting name. This will return -1 if the quality name specified was not found.")] out int qualityIndex
      )
   {
      if (qualityName != "")
      {
         int currentIndex = 0;
         bool matchFound = false;
         foreach (string currentName in QualitySettings.names)
         {
            if (currentName == qualityName)
            {
               matchFound = true;
               break;
            }
            currentIndex++;
         }

         if (matchFound)
         {
            qualityIndex = currentIndex;
         }
         else
         {
            qualityIndex = -1;
         }
      }
      else
      {
         uScriptDebug.Log("[Get Index From Quality Name] The name specified had zero characters in it (it was blank). Returning -1.");
         qualityIndex = -1;
      }

   }
}