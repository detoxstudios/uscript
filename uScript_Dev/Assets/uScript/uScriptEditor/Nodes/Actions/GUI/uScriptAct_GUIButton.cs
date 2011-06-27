// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUIButton on the screen and allows responses when clicked and hovered in/out.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIButton on the screen and allows responses when clicked and hovered in/out.")]
[NodeDescription("Shows a GUIButton on the screen and allows responses when clicked and hovered in/out.\n \nText: The text you want to display on the button. \nPosition: The position and size of the button.\nTexture: The background image to use for the button.\nTool Tip: The tool tip to display when the button is being hovered over.\nGUI Style: The name of a custom GUI style to use when displaying this button.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Button")]
public class uScriptAct_GUIButton : uScriptLogic
{
   [FriendlyName("Button Clicked")]
   public bool OnButtonClicked { get { return m_ButtonClicked; } }
   private bool m_ButtonClicked = false;

   public bool Out { get { return true; } }

   public void In(
      string Text,
      Rect Position,
      Texture2D Texture,
      [FriendlyName("Tool Tip"), DefaultValue(""), SocketState(false, false)] string ToolTip,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);

      if (string.IsNullOrEmpty(guiStyle))
      {
         m_ButtonClicked = GUI.Button(Position, content);
      }
      else
      {
         m_ButtonClicked = GUI.Button(Position, content, GUI.skin.GetStyle(guiStyle));
      }
   }
}
