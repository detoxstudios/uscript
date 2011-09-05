// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Outputs a string to the debug log. Optionally can add prefix and/or postfix strings.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Editor Only")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Outputs a string to the debug log.")]
[NodeDescription("Outputs a string to the debug log.\n \nPrefix: String to print ahead of each attached Target object.\nTarget: Objects to be printed to the console. If multiple are attached, they will all be printed 1 per line as Prefix + Target + Postfix.\nPostfix: String to print after each attached Target object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Log")]
public class uScriptAct_Log : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([SocketState(false, false)] object Prefix, object[] Target, [SocketState(false, false)] object Postfix)
   {
      foreach (object currentTarget in Target)
      {
         Debug.Log(( (Prefix == null ? string.Empty : Prefix.ToString())
                     + currentTarget.ToString()
                     + (Postfix == null ? string.Empty : Postfix.ToString())
                     + "\n" ));
      }
   }
}
