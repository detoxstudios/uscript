// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Vector3 variables together and returns the result.")]
[NodeDescription("Adds two Vector3 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Add Vector3")]
public class uScriptAct_AddVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3[] A, Vector3[] B, out Vector3 Result)
   {
      Vector3 aTotals = new Vector3(0, 0, 0);
      Vector3 bTotals = new Vector3(0, 0, 0);

      foreach (Vector3 currentA in A)
      {
         aTotals = aTotals + currentA;
      }
      foreach (Vector3 currentB in B)
      {
         bTotals = bTotals + currentB;
      }

      Result = aTotals + bTotals;

   }
}