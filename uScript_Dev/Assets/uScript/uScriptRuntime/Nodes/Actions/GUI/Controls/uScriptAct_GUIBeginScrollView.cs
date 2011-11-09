// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Begins a GUI group view which can be scrolled.")]
[NodeDescription("NOTE: Each use of those node. must be matched with a call to \"GUI End ScrollView\".\n\n" +
					"Position: Rectangle on the screen to use for the ScrollView.\n\n" +
					"ViewRect: The rectangle used inside the scrollview.\n\n" +
					"Scroll Position: The position to use display.\n\n" +
					"Always Show Horizontal: Always show vertical scrollbar regardless if it is required.\n\n" +
					"Always Show Vertical: Always show horizontal scrollbar regardless if it is required.\n\n" +
					"Horizontal Style: GUI Style for the horizontal scroll bar.\n\n" +
               "Vertical Style: GUI Style for the vertical scroll bar.\n\n"+
					"(out) Scroll Position: The new position of the scroll bar.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Begin_Scroll_View")]

[FriendlyName("GUI Begin ScrollView")]
public class uScriptAct_GUIBeginScrollView : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Rect Position,
      Rect ViewRect,
      [FriendlyName("Scroll Position")] Vector2 startingScrollPosition,
      [FriendlyName("Always Show Horizontal"), SocketState(false, false)] bool alwaysShowHorizontal,
      [FriendlyName("Always Show Vertical"), SocketState(false, false)] bool alwaysShowVertical,
      [FriendlyName("Horizontal Style"), DefaultValue(""), SocketState(false, false)] string horizontalStyle,
      [FriendlyName("Vertical Style"), DefaultValue(""), SocketState(false, false)] string verticalStyle,
      [FriendlyName("Scroll Position"), SocketState(false, false)] out Vector2 scrollPosition
      )
   {
      if (string.IsNullOrEmpty(horizontalStyle) && string.IsNullOrEmpty(verticalStyle))
      {
         scrollPosition = GUI.BeginScrollView( Position, startingScrollPosition, ViewRect, alwaysShowHorizontal, alwaysShowVertical );
      }
      else
      {
         scrollPosition = GUI.BeginScrollView( Position, startingScrollPosition, ViewRect, alwaysShowHorizontal, alwaysShowVertical, GUI.skin.GetStyle(horizontalStyle), GUI.skin.GetStyle(verticalStyle) );
      }
   }
}
