// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Color variable. Min/Max ovverrides allow you to change the range on a per-channel basis. Values should be 0 - 1. Currently, an Alpha Min and Max of both 0 will 1 until default node properties are working. 

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Color variable.")]
[NodeDescription("Randomly sets the value of a Color variable.\n \nR Min: Minimum allowable Red component value for the random color.\nR Max: Maximum allowable Red component value for the random color.\nG Min: Minimum allowable Green component value for the random color.\nG Max: Maximum allowable Green component value for the random color.\nB Min: Minimum allowable Blue component value for the random color.\nB Max: Maximum allowable Blue component value for the random color.\nA Min: Minimum allowable Alpha component value for the random color.\nA Max: Maximum allowable Alpha component value for the random color.\nSeed: Seed value for the random number generator.\nTarget Color (out): The random color that has been set.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Random Color")]
public class uScriptAct_SetRandomColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("R Min")] float RedMin,
      [FriendlyName("R Max")] float RedMax,
      [FriendlyName("G Min")] float GreenMin,
      [FriendlyName("G Max")] float GreenMax,
      [FriendlyName("B Min")] float BlueMin,
      [FriendlyName("B Max")] float BlueMax,
      [FriendlyName("A Min"), DefaultValue(1.0f)] float AlphaMin,
      [FriendlyName("A Max"), DefaultValue(1.0f)] float AlphaMax,
      [DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Target Color")] out Color TargetColor)
   {
      // Make sure values are in range, if not assign defaults that are
      if (RedMin < 0f) { RedMin = 0f; }
      if (RedMax > 1f) { RedMax = 1f; }
      if (GreenMin < 0f) { GreenMin = 0f; }
      if (GreenMax > 1f) { GreenMax = 1f; }
      if (BlueMin < 0f) { BlueMin = 0f; }
      if (BlueMax > 1f) { BlueMax = 1f; }
      if (AlphaMin < 0f) { AlphaMin = 0f; }
      if (AlphaMax > 1f) { AlphaMax = 1f; }

      float RedOut = ReturnRandomFloat(RedMin, RedMax, Seed);
      float GreenOut = ReturnRandomFloat(GreenMin, GreenMax, Seed);
      float BlueOut = ReturnRandomFloat(BlueMin, BlueMax, Seed);
      float AlphaOut = ReturnRandomFloat(AlphaMin, AlphaMax, Seed);

      TargetColor = new Color(RedOut, GreenOut, BlueOut, AlphaOut);
   }

   private float ReturnRandomFloat(float min, float max, int seed)
   {
      // Make sure we don't have min > max (or other way around)
      if ( min > max ) { min = max; }
      if ( max < min ) { max = min; }
      
      if (seed > 0) Random.seed = seed;

      return Random.Range(min, max);
   }
}