// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes the red, green and blue values of the Value color variable and combines them with the specified alpha value, outputing the results to the target color variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes the red, green and blue values of the Value color variable and combines them with the specified alpha value, outputing the results to the target color variable.")]
[NodeDescription("Takes the red, green and blue values of the Value color variable and combines them with the specified alpha value, outputing the results to the target color variable.\n \nValue: The color variable you wish to use to set the target variable's red, green and blue values.\nAlpha: Used to specify the alpha value used for the target color variable. Unity uses a 0.0 - 1.0 color range to determine color. Set \"Use 8-bit Range\" to true to use the tradition 0-255 alpha range with this node instead.\nUse 8-bit Range: Setting this to true will tell the node to use a traditional 0-255 value range for specifying the alpha channel.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Color")]

[FriendlyName("Set Color Alpha")]
public class uScriptAct_SetColorAlpha : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Color Value,
      float Alpha,
      [FriendlyName("Use 8-bit Range"), SocketState(false,false)] bool Use8bitRange,
      [FriendlyName("Target")] out Color TargetColor
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