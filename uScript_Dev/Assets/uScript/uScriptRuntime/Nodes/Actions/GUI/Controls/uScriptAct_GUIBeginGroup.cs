// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Begins a GUI control group with a local coordinate system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Begin Group", "When you begin a group, the coordinate system for GUI controls are set so (0,0) is the top-left corner of the group.  All controls are clipped to the group.  Groups can be nested - if they are, children are clipped to their parents.\n\nNOTE: Each use of this node must be matched with a call to \"GUI End Group\".")]
public class uScriptAct_GUIBeginGroup : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position", "The position and size of the control.")]
      Rect Position,
      
      [FriendlyName("Text", "The text you want to display.")]
      string Text,
      
      [FriendlyName("Texture", "The background image to display.")]
      Texture2D Texture,
      
      [FriendlyName("Tool Tip", "The tool tip to display when the control is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string ToolTip,

      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this control.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
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
