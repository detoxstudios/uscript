// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Web/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Encodes string into a URL-friendly format.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Escape String", "Encodes string into a URL-friendly format by replacing illegal" +
   " characters in the Target string with the correct URL-escaped code. Useful when building web page parameters.")]
public class uScriptAct_EscapeURL : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   [FriendlyName("Out")]
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Reset()
   public void In(
      [FriendlyName("Target", "The string to be escaped.")]
      string Target,

      [FriendlyName("Result", "A new string with all illegal characters replaced with %xx where xx is the hexadecimal code for the character code.")]
      out string Result
      )
   {
      if (Target == null)
      {
         Result = string.Empty;
      }
      else
      {
         Result = WWW.EscapeURL(Target);
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //

}
