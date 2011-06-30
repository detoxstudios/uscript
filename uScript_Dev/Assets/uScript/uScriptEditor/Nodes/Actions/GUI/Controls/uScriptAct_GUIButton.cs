// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUIButton on the screen and allows responses when held down, released, and clicked.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIButton on the screen and allows responses when held down, released, and clicked.")]
[NodeDescription("Shows a GUIButton on the screen and allows responses when held down, released, and clicked.\n \nText: The text you want to display on the button. \nPosition: The position and size of the button.\nTexture: The background image to use for the button.\nControl Name: Name to give to this button GUI control.\nTool Tip: The tool tip to display when the button is being hovered over.\nGUI Style: The name of a custom GUI style to use when displaying this button.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Button")]
public class uScriptAct_GUIButton : uScriptLogic
{
   private bool m_ButtonDown = false;
   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("Button Down")]
   public event uScriptEventHandler OnButtonDown;
 
   [FriendlyName("Button Held")]
   public event uScriptEventHandler OnButtonHeld;
 
   [FriendlyName("Button Up")]
   public event uScriptEventHandler OnButtonUp;
 
   [FriendlyName("Button Clicked")]
   public event uScriptEventHandler OnButtonClicked;

   public bool Out { get { return true; } }

   public void In(
      string Text,
      Rect Position,
      Texture2D Texture,
      [FriendlyName("Control Name"), DefaultValue(""), SocketState(false, false)] string ControlName,
      [FriendlyName("Tool Tip"), DefaultValue(""), SocketState(false, false)] string ToolTip,
      [FriendlyName("GUI Style"), DefaultValue(""), SocketState(false, false)] string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);
      bool buttonDown = false;
      
      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
         buttonDown = GUI.RepeatButton(Position, content);
      }
      else
      {
         buttonDown = GUI.RepeatButton(Position, content, GUI.skin.GetStyle(guiStyle));
      }
         
      if (Event.current.type == EventType.Repaint || Event.current.isMouse)
      {
         // down event
         if (!m_ButtonDown && buttonDown && OnButtonDown != null) OnButtonDown( this, new System.EventArgs() );
     
         // held event
         if (m_ButtonDown && buttonDown && OnButtonHeld != null) OnButtonHeld( this, new System.EventArgs() );
     
         // up/clicked event
         if (m_ButtonDown && !buttonDown)
         {
            if (OnButtonUp != null) OnButtonUp( this, new System.EventArgs() );
            if (OnButtonClicked != null) OnButtonClicked( this, new System.EventArgs() );
         }
         
         m_ButtonDown = buttonDown;
      }
   }
}
