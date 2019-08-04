// uScript Action Node
// (C) 2011 Detox Studios LLC

#if UNITY_2019
using UnityEngine.Networking;
#else
using UnityEngine;
#endif

[NodePath("Actions/Web/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Decodes string from a URL-friendly format.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

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
#if UNITY_2019
         Result = UnityWebRequest.UnEscapeURL(Target);
#else
         Result = WWW.UnEscapeURL(Target);
#endif
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //

}
