// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a string to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a string to the defined value.")]
[NodeDescription("Sets a string to the defined value.\n \nValue: The String variable to be set.\nTo Upper Case: If this is set to true, the string set will be all upper case.\nTo Lower Case: If this is set to true, the string set will be all lower case.\nTrim Whitespace: If this is set to true, the string's whitespace will be trimmed.\nTarget (out): The value that has been set for this variable.")]
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

      if (ToLowerCase)
      {
         tempString = Value.ToLower();
      }
      else if (ToUpperCase)
      {
         tempString = Value.ToUpper();
      }

      if (TrimWhitespace)
      {
         tempString = tempString.Trim();
      }

      Target = tempString;
   }
}