// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIToggle on the screen and allows responses when changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Toggle", "Shows a GUIToggle on the screen and allows responses when changed.")]
public class uScriptAct_GUIToggle : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;
    
   public void In(
      [FriendlyName("Value", "The value of this toggle.")]
      ref bool Value,

      [FriendlyName("Text", "The text you want to display with the toggle.")]
      string Text,

      [FriendlyName("Position", "The position and size of the toggle.")]
      Rect Position,

      [FriendlyName("Texture", "The background image to use for the toggle.")]
      Texture2D Texture,
      
      [FriendlyName("Tool Tip", "The tool tip to display when the toggle is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string ToolTip,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this toggle.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);
      bool value = false;
      m_Changed = false;
      
      if (string.IsNullOrEmpty(guiStyle))
      {
         value = GUI.Toggle(Position, Value, content);
      }
      else
      {
         value = GUI.Toggle(Position, Value, content, GUI.skin.GetStyle(guiStyle));
      }
      
      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
