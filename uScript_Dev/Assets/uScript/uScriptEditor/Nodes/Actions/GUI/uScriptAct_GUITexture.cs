// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUITexture on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUITexture on the screen.")]
[NodeDescription("Shows a GUITexture on the screen.\n \nPosition: The position and size of the texture.\nTexture: The background image to use for the texture.\nScale Mode: The scale mode to use when drawing the texture.\nAlpha Blend: Whether or not to enable alpha blending when drawing the texture (default is true).\nImage Aspect: Aspect ratio to use for the source image. If 0 (default), the aspect ratio from the image is used. Otherwise, pass width/height.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Texture")]
public class uScriptAct_GUITexture : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Rect Position,
      Texture2D Texture,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("Scale Mode")] ScaleMode scaleMode,
      [FriendlyName("Alpha Blend"), DefaultValue(true), SocketState(false, false)] bool alphaBlend,
      [FriendlyName("Image Aspect"), DefaultValue(1.0f), SocketState(false, false)] float aspect
      )
   {
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            
      GUI.DrawTexture(Position, Texture, scaleMode, alphaBlend, aspect);
   }
}
