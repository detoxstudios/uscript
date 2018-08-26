// uScript uScript_Button.cs
// (C) 2015 Detox Studios LLC

using System;
using UnityEngine.EventSystems;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a button is clicked.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI Button Events", "Fires an event signal when Instance Button receives a click event.")]
public class uScript_Button : uScriptEvent, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
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

   [FriendlyName("On Button Down")]
   public event uScriptEventHandler OnButtonDown;

   [FriendlyName("On Button Up")]
   public event uScriptEventHandler OnButtonUp;

   [FriendlyName("On Button Enter")]
   public event uScriptEventHandler OnButtonEnter;

   [FriendlyName("On Button Exit")]
   public event uScriptEventHandler OnButtonExit;

   [FriendlyName("On Button Drag")]
   public event uScriptEventHandler OnButtonDrag;

   public void Start()
   {
      UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
      if (button != null)
      {
         button.onClick.RemoveAllListeners();
         button.onClick.AddListener(HandleButton);
      }
   }

   void HandleButton()
   {
      if ( OnButtonClick != null ) OnButtonClick( this, new ClickEventArgs() ); 
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      if ( OnButtonDown != null ) OnButtonDown( this, new ClickEventArgs() ); 
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      if ( OnButtonUp != null ) OnButtonUp( this, new ClickEventArgs() ); 
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
      if ( OnButtonEnter != null ) OnButtonEnter( this, new ClickEventArgs() );
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      if ( OnButtonExit != null ) OnButtonExit( this, new ClickEventArgs() );
   }

   public void OnDrag(PointerEventData eventData)
   {
      if ( OnButtonDrag != null ) OnButtonDrag( this, new ClickEventArgs() );
   }
}

#endif
