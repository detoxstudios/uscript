// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Input Events fires out any time input is detected from the keyboard, mouse, or joystick.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Input Events", "Input Events fires out any time input is detected from the keyboard, mouse, or joystick.")]
public class uScript_Input : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Input Event")]
   public event uScriptEventHandler KeyEvent;

   private bool m_AnyKeyWasDown = false;

   void Update()
   {
      if (Input.anyKey)
      {
         m_AnyKeyWasDown = true;

         if (KeyEvent != null) KeyEvent(this, new System.EventArgs());
      }
      else if ( true == m_AnyKeyWasDown )
      {
         //no key is down now but it was the last frame
         //so send a key up
         m_AnyKeyWasDown = false;

         if (KeyEvent != null) KeyEvent(this, new System.EventArgs());
      }
   }
}
