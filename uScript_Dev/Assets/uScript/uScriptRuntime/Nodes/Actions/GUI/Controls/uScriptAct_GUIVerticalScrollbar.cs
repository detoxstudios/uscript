// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIVerticalScrollbar on the screen.")]
[NodeDescription("Shows a GUIVerticalScrollbar on the screen.\n\n" +
                  "Position: The position and size of the label.\n\n" +
                  "Value: The position between min and max.\n\n" +
                  "Size: How much can we see?\n\n" +
                  "Top Value: The value at the top of the scrollbar.\n\n" +
                  "Bottom Value: The value at the bottom of the scrollbar.\n\n" +
                  "Control Name: Name to give to this label GUI control.\n\n" +
                  "GUI Style: The name of a custom GUI style to use when displaying this label.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Label")]

[FriendlyName("GUI Vertical Scrollbar")]
public class uScriptAct_GUIVerticalScrollbar : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Rect Position,
      float Value,
      [SocketState(false, false)]float Size,
      [FriendlyName("Top Value"), DefaultValue(0), SocketState(false, false)] float topValue,
      [FriendlyName("Bottom Value"), DefaultValue(1), SocketState(false, false)] float bottomValue,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);

      if (string.IsNullOrEmpty(guiStyle))
      {
         GUI.VerticalScrollbar(Position, Value, Size, topValue, bottomValue);
      }
      else
      {
         GUI.VerticalScrollbar(Position, Value, Size, topValue, bottomValue, GUI.skin.GetStyle(guiStyle));
      }
   }
}
