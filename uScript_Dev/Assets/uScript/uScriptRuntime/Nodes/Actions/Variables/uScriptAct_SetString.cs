// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a string to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a string to the defined value.")]
[NodeDescription("Sets a string to the defined value.\n \nValue: The variable you wish to use to set the target's value.\nTo Upper Case: If this is set to true, the string set will be all upper case.\nTo Lower Case: If this is set to true, the string set will be all lower case.\nTrim Whitespace: If this is set to true, the string's whitespace will be trimmed.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_String")]

[FriendlyName("Set String")]
public class uScriptAct_SetString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      string Value,
      [FriendlyName("To Upper Case"), SocketState(false, false)] bool ToUpperCase,
      [FriendlyName("To Lower Case"), SocketState(false, false)] bool ToLowerCase,
      [FriendlyName("Trim Whitespace"), SocketState(false, false)] bool TrimWhitespace,
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