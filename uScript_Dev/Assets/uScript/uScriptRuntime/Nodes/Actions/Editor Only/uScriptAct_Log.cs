// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Editor Only")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Outputs a string to the debug log.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Log", "Outputs a string to the debug log.")]
public class uScriptAct_Log : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Prefix", "String to print ahead of each attached Target object.")]
      [SocketState(false, false)]
      object Prefix,

      [FriendlyName("Target", "Objects to be printed to the console. If multiple are attached, they will all be printed 1 per line as Prefix + Target + Postfix.")]
      object[] Target,

      [FriendlyName("Postfix", "String to print after each attached Target object.")]
      [SocketState(false, false)]
      object Postfix
      )
   {
      if (Target != null && Target.Length > 0)
      {
         foreach (object currentTarget in Target)
         {
            Debug.Log(((Prefix == null ? string.Empty : Prefix.ToString())
                        + (currentTarget != null ? currentTarget.ToString() : "(null)")
                        + (Postfix == null ? string.Empty : Postfix.ToString())
                        + "\n"));
         }
      }
      else
      {
         Debug.Log(((Prefix == null ? string.Empty : Prefix.ToString())
                        + (Postfix == null ? string.Empty : Postfix.ToString())
                        + "\n"));
      }
   }
}
