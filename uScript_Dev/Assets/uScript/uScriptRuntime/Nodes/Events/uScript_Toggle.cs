// uScript uScript_Toggle.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a toggle's value has changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#UI_Toggle_Events")]

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
