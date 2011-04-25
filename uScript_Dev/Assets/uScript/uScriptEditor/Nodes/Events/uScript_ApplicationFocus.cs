// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Application Focus Event")]
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

   [FriendlyName("On Focus Event")]
   public event uScriptEventHandler FocusEvent;

   void OnApplicationFocus(bool focus)
   {
      if ( null != FocusEvent ) FocusEvent( this, new ApplicationFocusEventArgs(focus) );     
   }
}
