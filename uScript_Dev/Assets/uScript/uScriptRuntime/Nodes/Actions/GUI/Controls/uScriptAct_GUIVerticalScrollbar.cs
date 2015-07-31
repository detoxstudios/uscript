// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIVerticalScrollbar on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Vertical Scrollbar", "Shows a GUIVerticalScrollbar on the screen.")]
public class uScriptAct_GUIVerticalScrollbar : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position", "The position and size of the label.")]
      Rect Position,
      
      [FriendlyName("Value", "The position between min and max.")]
      float Value,
      
      [FriendlyName("Size", "How much can we see?")]
      [SocketState(false, false)]
      float Size,
      
      [FriendlyName("Top Value", "The value at the top of the scrollbar.")]
      [DefaultValue(0), SocketState(false, false)]
      float topValue,
      
      [FriendlyName("Bottom Value", "The value at the bottom of the scrollbar.")]
      [DefaultValue(1), SocketState(false, false)]
      float bottomValue,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this label.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
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
