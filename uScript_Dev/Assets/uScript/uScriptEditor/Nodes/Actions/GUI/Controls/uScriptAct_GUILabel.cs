// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUILabel on the screen.")]
[NodeDescription("Shows a GUILabel on the screen.\n \nText: The text you want to display. \nPosition: The position and size of the label.\nTexture: The background image to use for the label.\nControl Name: Name to give to this texture GUI control.\nTool Tip: The tool tip to display when the label is being hovered over.\nGUI Style: The name of a custom GUI style to use when displaying this label.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Label")]
public class uScriptAct_GUILabel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      string Text,
      Rect Position,
      Texture2D Texture,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("Tool Tip"), DefaultValue(""), SocketState(false, false)] string ToolTip,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);

      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
         GUI.Label(Position, content);
      }
      else
      {
         GUI.Label(Position, content, GUI.skin.GetStyle(guiStyle));
      }
   }
}
