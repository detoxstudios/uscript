// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the smallest integer variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Min Int", "Returns the value of the smallest integer variable.")]
public class uScriptAct_MinInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Values", "The variables to compare."), AutoLinkType(typeof(int))]
      int[] Values,

      [FriendlyName("Result", "Smallest value passed in. If no variables are passed in, 2147483647 will be returned.")]
      out int Result
      )
   {
      Result = int.MaxValue;

      foreach(int value in Values)
      {
         Result = Mathf.Min(Result, value);
      }
   }
}
