// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Create the inverse of characters in a string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Invert String", "Returns the inverse order of characters in a String variable." +
 "\n\nExample:" +
 "\n\t\"ABCDE123\" -> \"321EDCBA\"")]
public class uScriptAct_InvertString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      string Target,

      [FriendlyName("Value", "The inverted value.")]
      out string Value
      )
   {
      if (!string.IsNullOrEmpty(Target))
      {
         Value = ReverseString(Target);
      }
      else
      {
         Value = Target;
      }
   }

   private static string ReverseString(string s)
   {
      char[] gnirts = s.ToCharArray();
      int length = gnirts.Length;
      int halfLength = length / 2;
      for (int i = 0; i < halfLength; i++)
      {
         char temp = gnirts[i];
         gnirts[i] = gnirts[length - i - 1];
         gnirts[length - i - 1] = temp;
      }
      return new string(gnirts);
   }
}