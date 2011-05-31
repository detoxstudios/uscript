// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Prints out a list of string variables from a String list to the console.

using UnityEngine;
using System.Collections;

[NodePath("Debug")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Prints out a list of string variables from a String list to the console.")]
[NodeDescription("Prints out a list of string variables from a String list to the console.\n \nStrings: List of strings to print out, one line at a time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Print String List")]
public class uScriptAct_PrintList : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(string []Strings)
   {
      foreach ( object s in Strings )
      {
         uScriptDebug.Log( "string = " + s );
      }
   }
}