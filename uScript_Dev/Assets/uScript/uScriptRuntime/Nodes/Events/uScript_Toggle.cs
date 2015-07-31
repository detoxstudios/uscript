// uScript uScript_Toggle.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a toggle's value has changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI Toggle Events", "Fires an event signal when Instance Toggle receives a value changed event.")]
public class uScript_Toggle : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ToggleEventArgs args);

   public class ToggleEventArgs : System.EventArgs
   {
      private bool m_ToggleValue;
      [FriendlyName("Toggle Value")]
      public bool ToggleValue
      {
         get { return m_ToggleValue; }
         set { m_ToggleValue = value; }
      }

      public ToggleEventArgs(bool toggleValue)
      {
         m_ToggleValue = toggleValue;
      }
   }

   [FriendlyName("On Toggle Value Changed")]
   public event uScriptEventHandler OnToggleValueChanged;

   public void Start()
   {
      UnityEngine.UI.Toggle toggle = GetComponent<UnityEngine.UI.Toggle>();
      toggle.onValueChanged.RemoveAllListeners();
      toggle.onValueChanged.AddListener(HandleToggle);
   }

   void HandleToggle(bool value)
   {
      if ( OnToggleValueChanged != null ) OnToggleValueChanged( this, new ToggleEventArgs(value) ); 
   }
}

#endif
