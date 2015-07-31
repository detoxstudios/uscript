// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Color variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Color", "Randomly sets the value of a Color variable.")]
public class uScriptAct_SetRandomColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Red Min", "Minimum allowable Red component value.")]
      [SocketState(false, false)]
      float RedMin,

      [FriendlyName("Red Max", "Maximum allowable Red component value.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float RedMax,

      [FriendlyName("Green Min", "Minimum allowable Green component value.")]
      [SocketState(false, false)]
      float GreenMin,
      
      [FriendlyName("Green Max", "Maximum allowable Green component value.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float GreenMax,

      [FriendlyName("Blue Min", "Minimum allowable Blue component value.")]
      [SocketState(false, false)]
      float BlueMin,
      
      [FriendlyName("Blue Max", "Maximum allowable Blue component value.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float BlueMax,
      
      [FriendlyName("Alpha Min", "Minimum allowable Alpha component value.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float AlphaMin,
      
      [FriendlyName("Alpha Max", "Maximum allowable Alpha component value.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float AlphaMax,
      
      [FriendlyName("Target Color", "The random color that has been set.")]
      out Color TargetColor
      )
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

      return Random.Range(min, max);
   }
}
