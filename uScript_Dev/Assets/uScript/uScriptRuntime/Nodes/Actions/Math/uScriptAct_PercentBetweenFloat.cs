// uScript Action Node
// (C) 2016 Detox Studios LLC

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip( "Outputs a floating point value between 0 and 1, indicating the percentage value t is between min and max.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Percent Between Floats", "Outputs a floating point value between 0 and 1, indicating the percentage value t is between min (0) and max (1).")]
public class uScriptAct_PercentBetweenFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("t", "The sample point.")]
      float t,

      [FriendlyName("Min", "The minimum value.")]
      float Min,

      [FriendlyName("Max", "The maximum value.")]
      float Max,

      [FriendlyName("Result", "The floating-point value between 0 and 1, indicating the percentage value t is between min (0) and max (1).")]
      out float FloatResult
      )
   {
      if (Min > t || t > Max) uScriptDebug.Log(string.Format("{0} is not between {1} and {2}, can't calculate a percentage between them!", t, Min, Max), uScriptDebug.Type.Error);
      else
      {
         float range = Max - Min;
         FloatResult = (t - Min) / range;
         return;
      }

      FloatResult = -1.0f;
   }
}
