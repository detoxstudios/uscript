// uScript uScript_ApplicationQuit.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when the application is going to quit.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Application Quit")]
[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Application Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the application is going to quit.")]
[NodeDescription("Fires an event signal when the application is going to quit.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Application Quit")]
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