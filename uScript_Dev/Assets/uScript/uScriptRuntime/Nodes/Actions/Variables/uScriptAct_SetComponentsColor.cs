// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Color variable by using RGBA float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Color)", "Sets the value of a Color variable by using RGBA float component values.")]
public class uScriptAct_SetComponentsColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Red", "The Red color channel.")]
      float RedValue,
      
      [FriendlyName("Green", "The Green color channel.")]
      float GreenValue,

      [FriendlyName("Blue", "The Blue color channel.")]
      float BlueValue,
      
      [FriendlyName("Alpha", "The Alpha channel.")]
      float AlphaValue,

      [FriendlyName("Use 8-bit Range", "If True, the channels will use a traditional 0-255 value range for specifying the channel value, otherwise the normalized range of 0.0 to 1.0 will be used.")]
      [SocketState(false,false)]
      bool Use8bitRange,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Color TargetColor
      )
   {
		Color finalColor = new Color(0f,0f,0f,0f);
		
		if (Use8bitRange)
		{
			// Cap ranges
			if (RedValue < 0f) {RedValue = 0f;}
			if (GreenValue < 0f) {GreenValue = 0f;}
			if (BlueValue < 0f) {BlueValue = 0f;}
			if (AlphaValue < 0f) {AlphaValue = 0f;}
			if (RedValue > 255f) {RedValue = 255f;}
			if (GreenValue > 255f) {GreenValue = 255f;}
			if (BlueValue > 255f) {BlueValue = 255f;}
			if (AlphaValue > 255f) {AlphaValue = 255f;}
			
			// Set final ouput color
			finalColor = new Color(RedValue/255, GreenValue/255, BlueValue/255, AlphaValue/255);
		}
		else
		{
			// Cap ranges
			if (RedValue < 0f) {RedValue = 0f;}
			if (GreenValue < 0f) {GreenValue = 0f;}
			if (BlueValue < 0f) {BlueValue = 0f;}
			if (AlphaValue < 0f) {AlphaValue = 0f;}
			if (RedValue > 1f) {RedValue = 1f;}
			if (GreenValue > 1f) {GreenValue = 1f;}
			if (BlueValue > 1f) {BlueValue = 1f;}
			if (AlphaValue > 1f) {AlphaValue = 1f;}
			
			// Set final ouput color
			finalColor = new Color(RedValue, GreenValue, BlueValue, AlphaValue);
		}

      TargetColor = finalColor;
   }
}
