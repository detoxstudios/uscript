// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Debug")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Prints out a list of string variables from a String list to the console.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Print String List", "Prints out a list of string variables from a String list to the console.")]
public class uScriptAct_PrintList : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Strings", "List of strings to print out, one line at a time.")]
      string []Strings
      )
   {
      foreach ( object s in Strings )
      {
         uScriptDebug.Log( "string = " + s );
      }
   }
}
