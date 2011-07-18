// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Color variable by using RGBA float component values.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Color variable by using RGBA float component values.")]
[NodeDescription("Sets the value of a Color variable by using RGBA float component values. Unity uses a 0.0 - 1.0 color range to determine color. Set \"Use 8-bit Range\" to true to use the tradition 0-255 color range with this node instead. \n \nRed: The red color channel.\nGreen: The green color channel.\nBlue: The blue color channel.\nAlpha: The alpha color channel.\nUse 8-bit Range: Setting this to true will tell the node to use a traditional 0-255 value range for specifying the color channels.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Color")]

[FriendlyName("Set Components (Color)")]
public class uScriptAct_SetComponentsColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	               [FriendlyName("Red")] float RedValue, 
	               [FriendlyName("Green")] float GreenValue, 
	               [FriendlyName("Blue")] float BlueValue, 
	               [FriendlyName("Alpha")] float AlphaValue,
	               [FriendlyName("Use 8-bit Range")] bool Use8bitRange,
	               [FriendlyName("Target")] out Color TargetColor)
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