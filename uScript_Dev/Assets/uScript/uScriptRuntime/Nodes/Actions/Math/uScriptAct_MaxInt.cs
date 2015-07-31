// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the largest integer variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Max Int", "Returns the value of the largest integer variable.")]
public class uScriptAct_MaxInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Values", "The variables to compare."), AutoLinkType(typeof(int))]
      int[] Values,

      [FriendlyName("Result", "Largest value passed in. If no variables are passed in, -2147483648 will be returned.")]
      out int Result
      )
   {
      Result = int.MinValue;

      foreach(int value in Values)
      {
         Result = Mathf.Max(Result, value);
      }
   }
}
