// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUITextArea on the screen and allows getting/setting of its string contents and repsonses to changed event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Text Area", "Shows a GUITextArea on the screen and allows getting/setting of its string contents and repsonses to changed event.")]
public class uScriptAct_GUITextArea : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;
    
   public void In(
      [FriendlyName("Value", "The value of this text area.")]
      ref string Value,
      
      [FriendlyName("Position", "The position and size of the text area.")]
      Rect Position,

      [FriendlyName("Max Length", "The maximum allowable string length for this text area. A value of -1 means there is no limit.")]
      [DefaultValue(50)]
      int maxLength,
      
      [FriendlyName("Control Name", "Name to give to this text area GUI control.")]
      [DefaultValue(""), SocketState(false, false)]
      string ControlName,

      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this text aera.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      string value;
      m_Changed = false;
      
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
         value = GUI.TextArea(Position, Value, maxLength);
      }
      else
      {
         value = GUI.TextArea(Position, Value, maxLength, GUI.skin.GetStyle(guiStyle));
      }
      
      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
