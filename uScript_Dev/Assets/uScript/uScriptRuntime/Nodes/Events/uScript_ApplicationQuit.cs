// uScript uScript_ApplicationQuit.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Application Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the application is going to quit.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Application Quit", "Fires an event signal when the application is going to quit.")]
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