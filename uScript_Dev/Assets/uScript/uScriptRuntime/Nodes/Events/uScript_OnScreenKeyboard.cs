// uScript uScript_OnScreenKeyboard.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when an on-screen keyboard event happens.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an on-screen keyboard event happens.")]
[NodeDescription("Fires an event signal when an on-screen keyboard event happens. iOS - Supported. Android - Unsupported.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#On-Screen_Keyboard_Events")]

[FriendlyName("On-Screen Keyboard Events")]
public class uScript_OnScreenKeyboard : uScriptEvent
{
#pragma warning disable 67
#pragma warning disable 414

   private bool m_LastKeyboardOut = false;

   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);


   [FriendlyName("On Keyboard Slid Out")]
   public event uScriptEventHandler OnKeyboardSlidOut;
   
#pragma warning restore 414
#pragma warning restore 67

   void Update()
   {
#if UNITY_IPHONE
      if (!m_LastKeyboardOut)
      {
         if (iPhoneKeyboard.visible)
         {
            if ( null != OnKeyboardSlidOut ) OnKeyboardSlidOut( this, new System.EventArgs() );     
         }
      }
      
      m_LastKeyboardOut = iPhoneKeyboard.visible;
#endif
   }
}
