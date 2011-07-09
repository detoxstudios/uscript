// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUIToggle on the screen and allows responses when changed.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIToggle on the screen and allows responses when changed.")]
[NodeDescription("Shows a GUIToggle on the screen and allows responses when changed.\n \nValue (in/out): The value of this toggle.\nText: The text you want to display with the toggle. \nPosition: The position and size of the toggle.\nTexture: The background image to use for the toggle.\nControl Name: Name to give to this toggle GUI control.\nTool Tip: The tool tip to display when the toggle is being hovered over.\nGUI Style: The name of a custom GUI style to use when displaying this toggle.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Toggle")]

[FriendlyName("GUI Toggle")]
public class uScriptAct_GUIToggle : uScriptLogic
{
   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   public void In(
      ref bool Value,
      string Text,
      Rect Position,
      Texture2D Texture,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("Tool Tip"), DefaultValue(""), SocketState(false, false)] string ToolTip,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);
      bool value = false;
      m_Changed = false;
      
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

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
