// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Outputs a string to the debug log. Optionally can add prefix and/or postfix strings.

using UnityEngine;
using System.Collections;

[NodePath("Action/Misc")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Outputs a string to the debug log.")]
[NodeDescription("Outputs a string to the debug log. Optionally can add prefix and/or postfix strings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Log")]
public class uScriptAct_Log : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(string Prefix, object[] Target, string Postfix)
   {
      if (Prefix == "" && Postfix == "")
      {
         foreach (object currentTarget in Target)
         {
            Debug.Log(currentTarget);
         }
      }
      else
      {
         foreach (object currentTarget in Target)
         {
            Debug.Log((Prefix + currentTarget.ToString() + Postfix));
         }
      }

   }
}