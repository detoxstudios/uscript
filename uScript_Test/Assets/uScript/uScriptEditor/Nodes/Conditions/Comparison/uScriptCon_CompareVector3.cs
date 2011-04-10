// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two Vector3 variables and outputs accordingly.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares two Vector3 variables and outputs accordingly.")]
[NodeDescription("Compares two Vector3 variables and outputs accordingly.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Compare Vector3")]
public class uScriptCon_CompareVector3 : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(Vector3 A, Vector3 B)
   {
      compareSame = false;
      compareDifferent = false;

      if (A == B)
      {
         compareSame = true;
      }
      else
      {
         compareDifferent = true;
      }

   }

}