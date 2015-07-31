// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a vertical slider that the user can drag to change a value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout Vertical Slider", "Shows a vertical slider that the user can drag to change a value.")]
public class uScriptAct_GUILayoutVerticalSlider : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The value the slider shows. This determines the position of the draggable thumb.")]
      ref float Value,

      [FriendlyName("Top Value", "The value at the top end of the slider.")]
      [DefaultValue(0f), SocketState(false, false)]
      float TopValue,

      [FriendlyName("Bottom Value", "The value at the bottom end of the slider.")]
      [DefaultValue(10f), SocketState(false, false)]
      float BottomValue,

      [FriendlyName("Slider Style", "The style to use for the dragging area. If left out, the \"verticalslider\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string SliderStyle,

      [FriendlyName("Thumb Style", "The style to use for the draggable thumb. If left out, the \"verticalsliderthumb\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string ThumbStyle,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIStyle sliderStyle = (string.IsNullOrEmpty(SliderStyle) ? GUI.skin.verticalSlider : GUI.skin.GetStyle(SliderStyle));
      GUIStyle thumbStyle = (string.IsNullOrEmpty(ThumbStyle) ? GUI.skin.verticalSliderThumb : GUI.skin.GetStyle(ThumbStyle));

      Value = GUILayout.VerticalSlider(Value, TopValue, BottomValue, sliderStyle, thumbStyle, Options);
   }
}
