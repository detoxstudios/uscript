// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Begins a GUI control group with a local coordinate system.")]
[NodeDescription("NOTE: Each use of those node. must be matched with a call to \"GUI End Group\".\n\n" +
					"When you begin a group, the coordinate system for GUI controls are set so (0,0) is the top-left corner of the group.  All controls are clipped to the group.  Groups can be nested - if they are, children are clipped to their parents.\n\n" +
					"Position: The position and size of the control.\n\n" +
					"Text: The text you want to display.\n\n" +
					"Texture: The background image to display.\n\n" +
					"Tool Tip: The tool tip to display when the control is being hovered over.\n\n" +
//					"Control Name: Name to give to this GUI control.\n\n" +
					"GUI Style: The name of a custom GUI style to use when displaying this control.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Label")]

[FriendlyName("GUI Begin Group")]
public class uScriptAct_GUIBeginGroup : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Rect Position,
      string Text,
      Texture2D Texture,
      [FriendlyName("Tool Tip"), DefaultValue(""), SocketState(false, false)] string ToolTip,
//      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);

//      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
         GUI.BeginGroup(Position, content);
      }
      else
      {
         GUI.BeginGroup(Position, content, GUI.skin.GetStyle(guiStyle));
      }
   }
}
