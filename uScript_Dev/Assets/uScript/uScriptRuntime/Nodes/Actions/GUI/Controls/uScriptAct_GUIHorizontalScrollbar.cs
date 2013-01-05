// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIHorizontalScrollbar on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Label")]

[FriendlyName("GUI Horizontal Scrollbar", "Shows a GUIHorizontalScrollbar on the screen.")]
public class uScriptAct_GUIHorizontalScrollbar : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position", "The position and size of the GUI control.")]
      Rect Position,
      
      [FriendlyName("Value", "The position between min and max.")]
      float Value,

      [FriendlyName("Size", "How much can we see?")]
      [SocketState(false, false)]
      float Size,
      
      [FriendlyName("Left Value", "The value at the left end of the scrollbar.")]
      [DefaultValue(0), SocketState(false, false)]
      float leftValue,
      
      [FriendlyName("Right Value", "The value at the right end of the scrollbar.")]
      [DefaultValue(1), SocketState(false, false)]
      float rightValue,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this label.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      if (string.IsNullOrEmpty(guiStyle))
      {
         GUI.HorizontalScrollbar(Position, Value, Size, leftValue, rightValue);
      }
      else
      {
         GUI.HorizontalScrollbar(Position, Value, Size, leftValue, rightValue, GUI.skin.GetStyle(guiStyle));
      }
   }
}
