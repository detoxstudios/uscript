// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a string to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a string to the defined value.")]
[NodeDescription("Sets a string to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set String")]
public class uScriptAct_SetString : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      string Value,
      [FriendlyName("To Upper Case")] bool ToUpperCase,
      [FriendlyName("To Lower Case")] bool ToLowerCase,
      [FriendlyName("Trim Whitespace")] bool TrimWhitespace,
      out string Target
      )
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