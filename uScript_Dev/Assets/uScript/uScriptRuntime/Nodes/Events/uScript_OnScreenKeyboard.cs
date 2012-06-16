// uScript uScript_OnScreenKeyboard.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an on-screen keyboard event happens.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#On-Screen_Keyboard_Events")]

[FriendlyName("On-Screen Keyboard Events", "Fires an event signal when an on-screen keyboard event happens.")]
public class uScript_OnScreenKeyboard : uScriptEvent
{
#pragma warning disable 67
#pragma warning disable 414

   private bool showLog = true;

   private bool m_LastKeyboardOut = false;

   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);


   [FriendlyName("On Keyboard Slid Out")]
   public event uScriptEventHandler OnKeyboardSlidOut;
   
#pragma warning restore 414
#pragma warning restore 67

   void Update()
   {

#if UNITY_3_5

   #if UNITY_IPHONE || UNITY_ANROID
      if (!m_LastKeyboardOut)
      {
         if (TouchScreenKeyboard.visible)
         {
            if ( null != OnKeyboardSlidOut ) OnKeyboardSlidOut( this, new System.EventArgs() );     
         }
      }

      m_LastKeyboardOut = TouchScreenKeyboard.visible;
   #else
      if (showLog)
      {
         uScriptDebug.Log("The 'On-Screen Keyboard Events' node will only work with mobile devices!", uScriptDebug.Type.Warning);
         showLog = false;
      }
   #endif

#else

   #if UNITY_IPHONE
      if (!m_LastKeyboardOut)
      {
         if (iPhoneKeyboard.visible)
         {
            if ( null != OnKeyboardSlidOut ) OnKeyboardSlidOut( this, new System.EventArgs() );     
         }
      }
      
      m_LastKeyboardOut = iPhoneKeyboard.visible;
   #else
      if (showLog)
      {
         uScriptDebug.Log("The 'On-Screen Keyboard Events' node will only work with iOS devices! Upgrade to Unity 3.5+ for Android support.", uScriptDebug.Type.Warning);
         showLog = false;
      }
   #endif

#endif


   }
}
