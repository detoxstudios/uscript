// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUITexture on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Texture")]

[FriendlyName("GUI Texture", "Shows a GUITexture on the screen.")]
public class uScriptAct_GUITexture : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position", "The position and size of the texture.")]
      Rect Position,

      [FriendlyName("Texture", "The background image to use for the texture.")]
      Texture2D Texture,

      [FriendlyName("Scale Mode", "The scale mode to use when drawing the texture.")]
      ScaleMode scaleMode,

      [FriendlyName("Alpha Blend", "Whether or not to enable alpha blending when drawing the texture (default is true).")]
      [DefaultValue(true), SocketState(false, false)]
      bool alphaBlend,

      [FriendlyName("Image Aspect", "Aspect ratio to use for the source image. If 0 (default), the aspect ratio from the image is used. Otherwise, pass width/height.")]
      [DefaultValue(1.0f), SocketState(false, false)]
      float aspect
      )
   {
      GUI.DrawTexture(Position, Texture, scaleMode, alphaBlend, aspect);
   }
}
