// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Begin a scrollview control group using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_ScrollView")]

[FriendlyName("GUILayout Begin ScrollView", "Begin a scrollview control group using Unity's automatic layout system.\n"
   + "\n"
   + "Automatically laid out scrollviews will take whatever content you have inside them and display normally. If it"
   + " doesn't fit, scrollbars will appear.\n"
   + "\n"
   + "NOTE: The group must be closed using a \"GUILayout End ScrollView\" node.")]
public class uScriptAct_GUILayoutBeginScrollView : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Scroll Position", "The position to use display.")]
      [SocketState(false, false)]
      ref Vector2 ScrollPosition,

      [FriendlyName("Always Show Horizontal", "If False, the scrollbar is only shown when the content inside the ScrollView is wider than the scrollview itself.")]
      [SocketState(false, false)]
      bool AlwaysShowHorizontal,

      [FriendlyName("Always Show Vertical", "If false, the scrollbar is only shown when content inside the ScrollView is taller than the scrollview itself.")]
      [SocketState(false, false)]
      bool AlwaysShowVertical,

      [FriendlyName("Style", "The style to use. If left out, the \"scrollview\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Horizontal Scrollbar Style", "The style to use. If left out, the \"horizontalscrollbar\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string HorizontalScrollbarStyle,

      [FriendlyName("Vertical Scrollbar Style", "The style to use. If left out, the \"verticalscrollbar\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string VerticalScrollbarStyle,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.scrollView : GUI.skin.GetStyle(Style));
      GUIStyle horizontalScrollbarStyle = (string.IsNullOrEmpty(Style) ? GUI.skin.horizontalScrollbar : GUI.skin.GetStyle(HorizontalScrollbarStyle));
      GUIStyle verticalScrollbarStyle = (string.IsNullOrEmpty(Style) ? GUI.skin.verticalScrollbar : GUI.skin.GetStyle(VerticalScrollbarStyle));

      ScrollPosition = GUILayout.BeginScrollView(ScrollPosition, AlwaysShowHorizontal, AlwaysShowVertical, horizontalScrollbarStyle, verticalScrollbarStyle, style, Options);
   }
}
