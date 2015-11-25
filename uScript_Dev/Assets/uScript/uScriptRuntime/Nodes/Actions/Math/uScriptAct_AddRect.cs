// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Rect variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_AddRect_v2))]
[FriendlyName("Add Rect (OLD)", "Adds Rect variables together and returns the result." +
 "\n\n[ A + B ]" +
 "\n\nIf more than one variable is connected to A, they will be added together before being added to B." +
 "\n\nIf more than one variable is connected to B, they will be added together before being added to A.")]
public class uScriptAct_AddRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list.")]
      Rect[] A,

      [FriendlyName("B", "The second variable or variable list.")]
      Rect[] B,

      [FriendlyName("Result", "The Rect result of the operation.")]
      out Rect Result
      )
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
