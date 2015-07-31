// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIPasswordField on the screen and allows getting/setting of its string contents and repsonses to changed event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Password Field", "Shows a GUIPasswordField on the screen and allows getting/setting of its string contents and repsonses to changed event.")]
public class uScriptAct_GUIPasswordField : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;

   public void In(
      [FriendlyName("Value", "The value of this text field.")]
      ref string Value,

      [FriendlyName("Position", "The position and size of the text field.")]
      Rect Position,

      [FriendlyName("Max Length", "The maximum allowable string length for this text field.")]
      [DefaultValue(50)]
      int maxLength,

      [FriendlyName("Control Name", "Name to give to this text field GUI control.")]
      [DefaultValue(""), SocketState(false, false)]
      string ControlName,

      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this text field.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      string value;
      m_Changed = false;
      
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
         value = GUI.PasswordField(Position, Value, '*', maxLength);
      }
      else
      {
         value = GUI.PasswordField(Position, Value, '*', maxLength, GUI.skin.GetStyle(guiStyle));
      }
      
      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
