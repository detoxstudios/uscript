// uScript uScript_Button.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a button is clicked.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI Button Events", "Fires an event signal when Instance Button receives a click event.")]
public class uScript_Button : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ClickEventArgs args);

   public class ClickEventArgs : System.EventArgs
   {
      public ClickEventArgs()
      {
      }
   }

   [FriendlyName("On Button Click")]
   public event uScriptEventHandler OnButtonClick;

   private UnityEngine.UI.Button m_Button;

   public void Start()
   {
      m_Button = GetComponent<UnityEngine.UI.Button>();
      m_Button.onClick.RemoveAllListeners();
      m_Button.onClick.AddListener(HandleButton);
   }

   void HandleButton()
   {
      if ( OnButtonClick != null ) OnButtonClick( this, new ClickEventArgs() ); 
   }
}

#endif
