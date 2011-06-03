// uScript uScript_Touch.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when a touch event(s) happens.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Input Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a touch event(s) happens.")]
[NodeDescription("Fires an event signal when a touch event(s) happens.\n \nTouches: Array of UnityEngine.Touch objects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Touch Events")]
public class uScript_Touch : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TouchEventArgs args);
  
   public class TouchEventArgs : System.EventArgs
   {
      public Touch[] Touches { get { return m_Touches; } }
      private Touch [] m_Touches;
     
      public TouchEventArgs(Touch []touches)
      {
         m_Touches = touches;
      }
   }

   [FriendlyName("On Touch Event")]
   public event uScriptEventHandler OnTouches;

   void Update()
   {
      if ( Input.touchCount > 0 )
      {
         if ( null != OnTouches ) OnTouches( this, new TouchEventArgs(Input.touches) );     
      }
   }
}
