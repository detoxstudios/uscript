// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two Rect variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Rect variables together and returns the result.")]
[NodeDescription("Adds two Rect variables together and returns the result.\n \nA: The first Rect addend.  If more than one Rect variable is connected to A, they will be added together before being added to B.\nB: The second Rect addend.  If more than one Rect variable is connected to B, they will be added together before being added to A.\nResult (out): The Rect result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Add_Rect")]

[FriendlyName("Add Rect")]
public class uScriptAct_AddRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Rect[] A, Rect[] B, out Rect Result)
   {
      Rect total = new Rect(0, 0, 0, 0);

      foreach (Rect rect in A)
      {
         total.xMin += rect.xMin;
         total.xMax += rect.xMax;
         total.yMin += rect.yMin;
         total.yMax += rect.yMax;
      }

      foreach (Rect rect in B)
      {
         total.xMin += rect.xMin;
         total.xMax += rect.xMax;
         total.yMin += rect.yMin;
         total.yMax += rect.yMax;
      }

      Result = total;
   }
}