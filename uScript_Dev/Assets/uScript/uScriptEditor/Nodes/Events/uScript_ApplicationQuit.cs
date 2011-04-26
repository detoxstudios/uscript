// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Application Quit Event")]
public class uScript_ApplicationQuit : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
  
   [FriendlyName("On Quit")]
   public event uScriptEventHandler QuitEvent;

   void OnApplicationQuit( )
   {
      if ( null != QuitEvent ) QuitEvent( this, new System.EventArgs( ) );     
   }
}
