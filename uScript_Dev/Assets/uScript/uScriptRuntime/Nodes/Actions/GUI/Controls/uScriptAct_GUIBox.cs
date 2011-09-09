// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIBox on the screen.")]
[NodeDescription("Shows a GUIBox on the screen.\n\n" +
                  "Text: The text you want to display.\n\n" +
                  "Position: The position and size of the label.\n\n" +
                  "Texture: The background image to use for the label.\n\n" +
                  "Control Name: Name to give to this label GUI control.\n\n" +
                  "Tool Tip: The tool tip to display when the label is being hovered over.\n\n" +
                  "GUI Style: The name of a custom GUI style to use when displaying this box.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Box")]

[FriendlyName("GUI Box")]
public class uScriptAct_GUIBox : uScriptLogic
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
         GUI.Box(Position, content);
      }
      else
      {
         GUI.Box(Position, content, GUI.skin.GetStyle(guiStyle));
      }
   }
}
