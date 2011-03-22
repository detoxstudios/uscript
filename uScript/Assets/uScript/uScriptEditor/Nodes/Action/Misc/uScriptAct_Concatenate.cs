// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Concatenates two objects as a string for output.

using UnityEngine;
using System.Collections;

[NodePath("Action/Misc")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Concatenates two objects as a string for output.")]
[NodeDescription("Concatenates two objects as a string for output.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Concatenate")]
public class uScriptAct_Concatenate : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object[] A, object[] B, string Separator, out string Result)
   {
      string aTotal = "";
      string bTotal = "";

      foreach (object currentA in A)
      {
         aTotal = (aTotal + currentA.ToString() + Separator);
      }

      foreach (object currentB in B)
      {
         bTotal = (bTotal + currentB.ToString() + Separator);
      }

      string tmpResults = aTotal + bTotal;

      // Trim bogus string end Separator characters.
      if ( Separator != "" )
      {
         int separatorCount = Separator.Length;
         int stringLength = tmpResults.Length - separatorCount;

         tmpResults = tmpResults.Substring(0, stringLength);
      }

      Result = tmpResults;
   }
}
