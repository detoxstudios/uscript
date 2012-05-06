// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the smallest float variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Min_Float")]

[FriendlyName("Min Float", "Returns the value of the smallest float variable.")]
public class uScriptAct_MinFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Values", "The variables to compare.")]
      float[] Values,

      [FriendlyName("Result", "Smallest value passed in. If no variables are passed in, 3.402823E+38 will be returned.")]
      out float Result
      )
   {
      Result = float.MaxValue;

      foreach(float value in Values)
      {
         Result = Mathf.Min(Result, value);
      }
   }
}
