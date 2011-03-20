// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a string to the defined value.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetString : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(string Value, bool ToUpperCase, bool ToLowerCase, bool TrimWhitespace, out string Target)
   {

      string tempString = Value;

      if (ToLowerCase || ToUpperCase)
      {
         if (ToLowerCase)
         {
            tempString = Value.ToLower();
         }
         if (ToUpperCase)
         {
            tempString = Value.ToUpper();
         }
      }
      else
      {
         tempString = Value;
      }

      if (TrimWhitespace)
      {
         tempString = tempString.Trim();
      }

      Target = tempString;

   }
}