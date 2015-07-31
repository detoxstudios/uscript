// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a string to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set String", "Sets a string to the defined value.")]
public class uScriptAct_SetString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      string Value,
      
      [FriendlyName("To Upper Case", "If True, the string set will be all upper case.")]
      [SocketState(false, false)]
      bool ToUpperCase,
      
      [FriendlyName("To Lower Case", "If True, the string set will be all lower case.")]
      [SocketState(false, false)]
      bool ToLowerCase,
      
      [FriendlyName("Trim Whitespace", "If True, the string's whitespace will be trimmed.")]
      [SocketState(false, false)]
      bool TrimWhitespace,

      [FriendlyName("Target", "The Target variable you wish to set.")]
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
