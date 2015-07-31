// uScript uScript_NetworkServerInitialized.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a network server is initialized.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Network Server Initialized", "Fires an event signal when a network server is initialized.")]
public class uScript_NetworkServerInitialized: uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnInitialized;

   void OnServerInitialized( )
   {
      if (OnInitialized != null) OnInitialized(this, new System.EventArgs());
   }
}
