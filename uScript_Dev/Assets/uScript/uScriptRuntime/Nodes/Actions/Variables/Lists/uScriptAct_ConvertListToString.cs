// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a list variable into a delimited string.")]
[NodeAuthor("Detox Studios LLC. Original node by John on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Convert List to String", "Converts a list variable into a delimited string.")]
public class uScriptAct_ConvertListToString : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public void In(
      [FriendlyName("Target", "The target list variable to convert into a string.")] object[] Target,
      [FriendlyName("Delimiter", "The character(s) you wish to use to seperate the elements of the list variable."), DefaultValue(",")] string Delimiter,
      [FriendlyName("Clean Names", "Should the extra Unity text be stripped from the strings."), DefaultValue(true)] bool CleanNames,
      [FriendlyName("Result", "The resulting string variable that contains all the list strings")] out string Result
      )
   {
      string tempString = "";
      if (Target.Length > 0)
      {
#if !UNITY_FLASH
         if (Target[0].GetType() == typeof(string))
         {
            int counter = 0;
            foreach (string item in Target)
            {
               if (counter == Target.Length - 1)
               {
                  if (CleanNames)
                  {
                     tempString = tempString + CleanString(item);
                  }
                  else
                  {
                     tempString = tempString + item;
                  }

               }
               else
               {
                  if (CleanNames)
                  {
                     tempString = tempString + CleanString(item) + Delimiter;
                  }
                  else
                  {
                     tempString = tempString + item + Delimiter;
                  }

                  
               }
               counter++;
            }

         }
         else
         {
#endif
            int counter = 0;
            foreach (var item in Target)
            {
               if (counter == Target.Length - 1)
               {
                  if (CleanNames)
                  {
                     tempString = tempString + CleanString(item.ToString());
                  }
                  else
                  {
                     tempString = tempString + item;
                  }
               }
               else
               {
                  if (CleanNames)
                  {
                     tempString = tempString + CleanString(item.ToString()) + Delimiter;
                  }
                  else
                  {
                     tempString = tempString + item + Delimiter;
                  }
               }
               counter++;
            }
#if !UNITY_FLASH
         }
#endif

         Result = tempString;
      }
      else
      {
         Result = "";
      }

   }

   // Used to filter out the extra Unity string information.
   private string CleanString(string stringToClean)
   {
      string tmpString = stringToClean;
      tmpString = tmpString.Replace(" (UnityEngine.GameObject)", "");
      tmpString = tmpString.Replace(" (UnityEngine.Camera)", "");
      tmpString = tmpString.Replace(" (UnityEngine.Color)", "");
      tmpString = tmpString.Replace(" (UnityEngine.AudioClip)", "");
      return tmpString;
   }
}