// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a custom event with a Color variable.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Action/Event/Custom Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a custom event with a Color variable.")]
[NodeDescription("Sends a custom event with a Color variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Send Custom Event (Color)")]
public class uScriptAct_SendCustomEventColor : uScriptLogic
{

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent([FriendlyName("Event Name")] string EventName, [FriendlyName("Event Value")] Color EventValue, [FriendlyName("Event Sender")] GameObject EventSender)
   {
      uScriptCustomEvent.BroadcastCustomEvent(EventName, EventValue, EventSender);
   }
}
