// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any non-zero target integer and outputs its inverse version. Example: -2 becomes 2

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any non-zero target integer and outputs its inverse version.")]
[NodeDescription("Takes any non-zero target integer and outputs its inverse version. Example: -2 becomes 2")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert Int")]
public class uScriptAct_InvertInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Target, out int Value)
   {
      if (Target != 0)
      {
         int newInt;

         if (Target > 0)
         {
            newInt = System.Math.Abs(Target) * (-1);
         }
         else
         {
            newInt = System.Math.Abs(Target);
         }

         Value = newInt;
      }
      else
      {
         Value = 0;
      }

   }
}