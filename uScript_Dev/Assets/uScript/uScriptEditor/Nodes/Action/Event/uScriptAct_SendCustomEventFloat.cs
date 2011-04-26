// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a custom event with a float variable.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Action/Event/Custom Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a custom event with a float variable.")]
[NodeDescription("Sends a custom event with a float variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Send Custom Event (Float)")]
public class uScriptAct_SendCustomEventFloat : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent([FriendlyName("Event Name")] string EventName, [FriendlyName("Event Value")] float EventValue, [FriendlyName("Event Sender")] GameObject EventSender)
   {
      uScriptCustomEvent.BroadcastCustomEvent(EventName, EventValue, EventSender);
   }
}
