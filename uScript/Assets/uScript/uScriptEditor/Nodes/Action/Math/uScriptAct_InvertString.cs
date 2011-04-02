// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Create the inverse of characters in a string. Example: "ABCDE123" becomes "321EDCBA"

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Create the inverse of characters in a string.")]
[NodeDescription("Create the inverse of characters in a string. Example: 'ABCDE123' becomes '321EDCBA'")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert String")]
public class uScriptAct_InvertString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(string Target, out string Value)
   {

      if (Target != "")
      {

         Value = ReverseString(Target);

      }
      else
      {
         Value = Target;
      }

   }

   public static string ReverseString(string s)
   {

      char[] gnirts = s.ToCharArray();
      System.Array.Reverse(gnirts);
      return new string(gnirts);

   }
}