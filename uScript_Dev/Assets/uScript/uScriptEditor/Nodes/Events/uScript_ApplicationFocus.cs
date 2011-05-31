// uScript uScript_ApplicationFocus.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when the application's focus state changes.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Application Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the application's focus state changes.")]
[NodeDescription("Fires an event signal when the application's focus state changes.\n \nHas Focus: Whether the application gained or lost focus.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Application Focus")]
public class uScript_ApplicationFocus : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ApplicationFocusEventArgs args);
  
   public class ApplicationFocusEventArgs : System.EventArgs
   {
      [FriendlyName("Has Focus")]
      public bool HasFocus { get { return m_HasFocus; } }
      private bool m_HasFocus;
     
      public ApplicationFocusEventArgs(bool hasFocus)
      {
         m_HasFocus = hasFocus;
      }
   }

   [FriendlyName("On Focus")]
   public event uScriptEventHandler FocusEvent;

   void OnApplicationFocus(bool focus)
   {
      if ( null != FocusEvent ) FocusEvent( this, new ApplicationFocusEventArgs(focus) );     
   }
}