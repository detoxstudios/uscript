// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Web/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Decodes string from a URL-friendly format.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#UnEscapeString")]

[FriendlyName("UnEscape String", "Decodes string from a URL-friendly format.")]
public class uScriptAct_UnEscapeURL : uScriptLogic
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
      [FriendlyName("Target", "The URL-escaped string to be converted.")]
      string Target,

      [FriendlyName("Result", "A new string with all occurrences of %xx replaced with the corresponding character.")]
      out string Result
      )
   {
      if (Target == null)
      {
         Result = string.Empty;
      }
      else
      {
         Result = WWW.UnEscapeURL(Target);
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //

}
