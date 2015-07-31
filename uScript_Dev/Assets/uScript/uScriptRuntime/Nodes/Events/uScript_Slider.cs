// uScript uScript_Slider.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a slider's value has changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI Slider Events", "Fires an event signal when Instance Slider receives a value changed event.")]
public class uScript_Slider : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, SliderEventArgs args);

   public class SliderEventArgs : System.EventArgs
   {
      private float m_SliderValue;
      [FriendlyName("Slider Value")]
      public float SliderValue
      {
         get { return m_SliderValue; }
         set { m_SliderValue = value; }
      }

      public SliderEventArgs(float sliderValue)
      {
         m_SliderValue = sliderValue;
      }
   }

   [FriendlyName("On Slider Value Changed")]
   public event uScriptEventHandler OnSliderValueChanged;

   public void Start()
   {
      UnityEngine.UI.Slider slider = GetComponent<UnityEngine.UI.Slider>();
      slider.onValueChanged.RemoveAllListeners();
      slider.onValueChanged.AddListener(HandleSlider);
   }

   void HandleSlider(float value)
   {
      if ( OnSliderValueChanged != null ) OnSliderValueChanged( this, new SliderEventArgs(value) ); 
   }
}

#endif
