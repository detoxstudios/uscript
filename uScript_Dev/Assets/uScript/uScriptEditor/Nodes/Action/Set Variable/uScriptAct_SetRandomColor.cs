// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Color variable. Min/Max ovverrides allow you to change the range on a per-channel basis. Values should be 0 - 1. Currently, an Alpha Min and Max of both 0 will 1 until default node properties are working. 

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Color variable.")]
[NodeDescription("Randomly sets the value of a Color variable. Min/Max ovverrides allow you to change the range on a per-channel basis. Values should be 0 - 1. Currently, an Alpha Min and Max of both 0 will become 1 until default node properties are working.")]
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
      [FriendlyName("A Min")] float AlphaMin,
      [FriendlyName("A Max")] float AlphaMax,
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

      // @TODO: This can go away once we have default propertys working (Alpha Min/Max would be set to 1 by default)
      float AlphaOut;
      if (0f != AlphaMin && 0f != AlphaMax)
      {
         AlphaOut = ReturnRandomFloat(AlphaMin, AlphaMax);
      }
      else
      {
         AlphaOut = 1f;
      }

      TargetColor = new Color(RedOut, GreenOut, BlueOut, AlphaOut);

   }

   private float ReturnRandomFloat(float Min, float Max)
   {
      float RndFloat;

      // Make sure we don't have min > max (or other way around)
      if ( Min > Max ) { Min = Max; }
      if ( Max < Min ) { Max = Min; }

      RndFloat = Random.Range(Min, Max);

      return RndFloat;
   }





}