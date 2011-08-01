// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Color variable. Min/Max ovverrides allow you to change the range on a per-channel basis. Values should be 0 - 1. Currently, an Alpha Min and Max of both 0 will 1 until default node properties are working. 

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Color variable.")]
[NodeDescription("Randomly sets the value of a Color variable.\n \nR Min: Minimum allowable Red component value for the random color.\nR Max: Maximum allowable Red component value for the random color.\nG Min: Minimum allowable Green component value for the random color.\nG Max: Maximum allowable Green component value for the random color.\nB Min: Minimum allowable Blue component value for the random color.\nB Max: Maximum allowable Blue component value for the random color.\nA Min: Minimum allowable Alpha component value for the random color.\nA Max: Maximum allowable Alpha component value for the random color.\nSeed: Optional. Seed value for the random number generator. Using a specific seed value will generate the same random number each time. A value of zero (the default) will generate random numbers each time.\nTarget Color (out): The random color that has been set.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Color")]

[FriendlyName("Set Random Color")]
public class uScriptAct_SetRandomColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("R Min"), SocketState(false, false)] float RedMin,
      [FriendlyName("R Max"), DefaultValue(1.0f), SocketState(false, false)] float RedMax,
      [FriendlyName("G Min"), SocketState(false, false)] float GreenMin,
      [FriendlyName("G Max"), DefaultValue(1.0f), SocketState(false, false)] float GreenMax,
      [FriendlyName("B Min"), SocketState(false, false)] float BlueMin,
      [FriendlyName("B Max"), DefaultValue(1.0f), SocketState(false, false)] float BlueMax,
      [FriendlyName("A Min"), DefaultValue(1.0f), SocketState(false, false)] float AlphaMin,
      [FriendlyName("A Max"), DefaultValue(1.0f), SocketState(false, false)] float AlphaMax,
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

      float RedOut = ReturnRandomFloat(RedMin, RedMax);
      float GreenOut = ReturnRandomFloat(GreenMin, GreenMax);
      float BlueOut = ReturnRandomFloat(BlueMin, BlueMax);
      float AlphaOut = ReturnRandomFloat(AlphaMin, AlphaMax);

      TargetColor = new Color(RedOut, GreenOut, BlueOut, AlphaOut);
   }

   private float ReturnRandomFloat(float min, float max)
   {
      // Make sure we don't have min > max (or other way around)
      if ( min > max ) { min = max; }
      if ( max < min ) { max = min; }

      return Random.Range(min, max);
   }
}