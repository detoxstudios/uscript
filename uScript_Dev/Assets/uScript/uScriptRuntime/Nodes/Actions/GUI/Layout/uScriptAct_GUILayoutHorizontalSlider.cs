// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a horizontal slider that the user can drag to change a value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_HorizontalSlider")]

[FriendlyName("GUILayout Horizontal Slider", "Shows a horizontal slider that the user can drag to change a value.")]
public class uScriptAct_GUILayoutHorizontalSlider : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The value the slider shows. This determines the position of the draggable thumb.")]
      ref float Value,

      [FriendlyName("Left Value", "The value at the left end of the slider.")]
      [DefaultValue(0f), SocketState(false, false)]
      float LeftValue,

      [FriendlyName("Right Value", "The value at the right end of the slider.")]
      [DefaultValue(10f), SocketState(false, false)]
      float RightValue,

      [FriendlyName("Slider Style", "The style to use for the dragging area. If left out, the \"horizontalslider\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string SliderStyle,

      [FriendlyName("Thumb Style", "The style to use for the draggable thumb. If left out, the \"horizontalsliderthumb\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string ThumbStyle,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIStyle sliderStyle = (string.IsNullOrEmpty(SliderStyle) ? GUI.skin.horizontalSlider : GUI.skin.GetStyle(SliderStyle));
      GUIStyle thumbStyle = (string.IsNullOrEmpty(ThumbStyle) ? GUI.skin.horizontalSliderThumb : GUI.skin.GetStyle(ThumbStyle));

      Value = GUILayout.HorizontalSlider(Value, LeftValue, RightValue, sliderStyle, thumbStyle, Options);
   }
}
