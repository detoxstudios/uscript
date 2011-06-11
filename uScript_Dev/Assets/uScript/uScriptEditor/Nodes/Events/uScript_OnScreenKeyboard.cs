// uScript uScript_OnScreenKeyboard.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when an on-screen keyboard event happens.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an on-screen keyboard event happens.")]
[NodeDescription("Fires an event signal when an on-screen keyboard event happens. iOS - Supported. Android - Unsupported.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("On-Screen Keyboard Event")]
public class uScript_OnScreenKeyboard : uScriptEvent
{
   private bool m_LastKeyboardOut = false;
   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Keyboard Slid Out")]
   public event uScriptEventHandler OnKeyboardSlidOut;

   void Update()
   {
      if (!m_LastKeyboardOut)
      {
         if (iPhoneKeyboard.visible)
         {
            if ( null != OnKeyboardSlidOut ) OnKeyboardSlidOut( this, new System.EventArgs() );     
         }
      }
      
      m_LastKeyboardOut = iPhoneKeyboard.visible;
   }
}
