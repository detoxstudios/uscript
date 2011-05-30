// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a custom event with a Vector4 variable.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Custom Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a basic custom event.")]
[NodeDescription("Sends a basic custom event.\n \nEvent Name: The string-based event name.\nEvent Sender: The GameObject responsible for sending the event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Send Custom Event")]
public class uScriptAct_SendCustomEvent : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent([FriendlyName("Event Name")] string EventName, [FriendlyName("Event Sender")] GameObject EventSender)
   {
      uScriptCustomEvent.BroadcastCustomEvent(EventName, null, EventSender);
   }
}
