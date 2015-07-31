// uScript uScript_Scrollbar.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a scrollbar's value has changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI Scrollbar Events", "Fires an event signal when Instance Scrollbar receives a value changed event.")]
public class uScript_Scrollbar : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ScrollbarEventArgs args);

   public class ScrollbarEventArgs : System.EventArgs
   {
      private float m_ScrollbarValue;
      [FriendlyName("Scrollbar Value")]
      public float ScrollbarValue
      {
         get { return m_ScrollbarValue; }
         set { m_ScrollbarValue = value; }
      }

      public ScrollbarEventArgs(float scrollbarValue)
      {
         m_ScrollbarValue = scrollbarValue;
      }
   }

   [FriendlyName("On Scrollbar Value Changed")]
   public event uScriptEventHandler OnScrollbarValueChanged;

   public void Start()
   {
      UnityEngine.UI.Scrollbar scrollbar = GetComponent<UnityEngine.UI.Scrollbar>();
      scrollbar.onValueChanged.RemoveAllListeners();
      scrollbar.onValueChanged.AddListener(HandleScrollbar);
   }

   void HandleScrollbar(float value)
   {
      if ( OnScrollbarValueChanged != null ) OnScrollbarValueChanged( this, new ScrollbarEventArgs(value) ); 
   }
}

#endif
