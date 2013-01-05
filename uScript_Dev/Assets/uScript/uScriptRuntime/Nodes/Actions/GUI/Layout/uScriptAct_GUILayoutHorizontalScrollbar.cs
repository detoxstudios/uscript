// uScript Action Node
// (C) 2013 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Shows a horizontal scrollbar that the user can drag.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_HorizontalScrollbar")]

[FriendlyName("GUILayout Horizontal Scrollbar", "Shows a horizontal scrollbar that the user can drag.")]
public class uScriptAct_GUILayoutHorizontalScrollbar : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The position of the draggable thumb, which can be changed by the user.")]
      ref float Value,

      [FriendlyName("Left Value", "The value at the left end of the scrollbar.")]
      [DefaultValue(0f), SocketState(false, false)]
      float LeftValue,

      [FriendlyName("Right Value", "The value at the right end of the scrollbar.")]
      [DefaultValue(10f), SocketState(false, false)]
      float RightValue,

      [FriendlyName("Thumb Size", "The size of the thumb relative to the scrollbar.")]
      [DefaultValue(1f), SocketState(false, false)]
      float ThumbSize,

      [FriendlyName("Style", "The style to use for the scrollbar background. If left out, the \"horizontalscrollbar\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIStyle scrollbarStyle = (string.IsNullOrEmpty(Style) ? GUI.skin.horizontalScrollbar : GUI.skin.GetStyle(Style));

      Value = GUILayout.HorizontalScrollbar(Value, ThumbSize, LeftValue, RightValue, scrollbarStyle, Options);
   }
}
