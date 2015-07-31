// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes the red, green and blue values of the Value color variable and combines them with the specified alpha value, outputing the results to the target color variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Color Alpha", "Takes an existing Color variable and applies the specified Alpha value.  The results are returned to the Target variable.")]
public class uScriptAct_SetColorAlpha : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The color variable you wish to use as the source for the Target's Red, Green, and Blue color channels.")]
      Color Value,

      [FriendlyName("Alpha", "The new Alpha channel value.")]
      float Alpha,

      [FriendlyName("Use 8-bit Range", "If True, the Alpha channel will use a traditional 0-255 value range for specifying the alpha channel, otherwise it will use the normalized 0.0 to 1.0 value range.")]
      [SocketState(false,false)]
      bool Use8bitRange,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Color TargetColor
      )
   {
      if (Use8bitRange)
      {
         // Cap ranges
         if (Alpha < 0f) { Alpha = 0f; }
         if (Alpha > 255f) { Alpha = 255f; }

         // Set final ouput color
         TargetColor = new Color(Value.r, Value.g, Value.b, Alpha/255);
      }
      else
      {
         // Cap ranges
         if (Alpha < 0f) { Alpha = 0f; }
         if (Alpha > 1f) { Alpha = 1f; }

         // Set final ouput color
         TargetColor = new Color(Value.r, Value.g, Value.b, Alpha);
      }
   }
}
