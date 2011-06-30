// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to the master uScript GameObject.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Input Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Input Events fires out any time input is detected from the keyboard, mouse, or joystick.")]
[NodeDescription("Input Events fires out any time input is detected from the keyboard, mouse, or joystick.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Input_Events")]

[FriendlyName("Input Events")]
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
