// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIWindow on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Window", "Shows a GUIWindow on the screen.")]
public class uScriptAct_GUIWindow : uScriptLogic
{
	private const int WINDOW_ID = 0;
	
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   [FriendlyName("Draw Window")]
   public event uScriptEventHandler DrawWindow;

   public void In(
	  [FriendlyName("Name", "The name displayed at the top of the window.")]
	  string Name,
      
      [FriendlyName("Position", "The position and size of the window.")]
      Rect Position,
	               
      [FriendlyName("Texture", "The background image to use for the label.")]
	  [DefaultValue(""), SocketState(false, false)]
      Texture2D Texture,
	               
      [FriendlyName("Control Name", "Name to give to this label GUI control.")]
      [DefaultValue(""), SocketState(false, false)]
      string ControlName,
      
      [FriendlyName("Tool Tip", "The tool tip to display when the label is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string ToolTip,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this box.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {	  
      GUIContent content = new GUIContent(Name, Texture, ToolTip);

      if (!string.IsNullOrEmpty(ControlName)) GUI.SetNextControlName(ControlName);            

      if (string.IsNullOrEmpty(guiStyle))
      {
		GUI.Window(
			WINDOW_ID,
		    Position,
		    Window,
		    content);
      }
      else
      {
		GUI.Window(
			WINDOW_ID,
		    Position,
		    Window,
		    content,
			GUI.skin.GetStyle(guiStyle));
      }
	}
	private void Window(int id) 
   {
      if (null != DrawWindow) DrawWindow(this, System.EventArgs.Empty);
	}
}