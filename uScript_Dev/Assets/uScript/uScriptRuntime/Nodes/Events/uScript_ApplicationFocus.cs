// uScript uScript_ApplicationFocus.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Application Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the application's focus state changes.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Application Focus", "Fires an event signal when the application's focus state changes.")]
public class uScript_ApplicationFocus : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ApplicationFocusEventArgs args);
  
   public class ApplicationFocusEventArgs : System.EventArgs
   {
      [FriendlyName("Has Focus", "When True, the application has focus.")]
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