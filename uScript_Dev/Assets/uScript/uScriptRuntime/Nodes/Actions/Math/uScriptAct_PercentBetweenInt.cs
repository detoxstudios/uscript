// uScript Action Node
// (C) 2018 Detox Studios LLC

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2018 by Detox Studios LLC")]
[NodeToolTip( "Outputs a floating point value between 0 and 1, indicating the percentage value t is between min and max.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Percent Between Ints", "Outputs a floating point value between 0 and 1, indicating the percentage value t is between min (0) and max (1).")]
public class uScriptAct_PercentBetweenInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("t", "The sample point.")]
      int t,

      [FriendlyName("Min", "The minimum value.")]
      int Min,

      [FriendlyName("Max", "The maximum value.")]
      int Max,

      [FriendlyName("Result", "The floating-point value between 0 and 1, indicating the percentage value t is between min (0) and max (1).")]
      out float FloatResult
      )
   {
      FloatResult = -1.0f;

      if (Min > t || t > Max) uScriptDebug.Log(string.Format("{0} is not between {1} and {2}, can't calculate a percentage between them!", t, Min, Max), uScriptDebug.Type.Error);
      else
      {
         float range = Max - Min;
         FloatResult = (float)(t - Min) / range;
      }
   }
}
