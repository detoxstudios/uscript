// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUITextArea on the screen and allows getting/setting of its string contents and repsonses to changed event.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUITextArea on the screen and allows getting/setting of its string contents and repsonses to changed event.")]
[NodeDescription("Shows a GUITextArea on the screen and allows getting/setting of its string contents and repsonses to changed event.\n \nValue (in/out): The value of this text area.\nPosition: The position and size of the text area.\nMax Length: The maximum allowable string length for this text area.\nControl Name: Name to give to this text area GUI control.\nGUI Style: The name of a custom GUI style to use when displaying this text aera.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Text Area")]
public class uScriptAct_GUITextArea : uScriptLogic
{
   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   public void In(
      ref string Value,
      Rect Position,
      [FriendlyName("Max Length"), DefaultValue(50)] int maxLength,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
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
