// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: create the inverse of characters in a string. Example: "ABCDE123" becomes "321EDCBA"

using UnityEngine;
using System.Collections;

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