// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a custom event with an Object variable.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Custom Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a custom event with an Object variable.")]
[NodeDescription("Sends a custom event with an Object variable.\n \nEvent Name: The string-based event name.\nEvent Value: The value to pass in the event.\nBraodcast To All: Whether or not to broadcast this event to all GameObjects. If false (which is the default), this event will only be sent to the ancestors of Event Sender (or the owner of this uScript).\nEvent Sender: The GameObject responsible for sending the event. If not specified, the sender will be the owner of this uScript.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Send_Custom_Event_.28Object.29")]

[FriendlyName("Send Custom Event (Object)")]
public class uScriptAct_SendCustomEventObject : uScriptLogic
{
   private GameObject m_Parent = null;

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent([FriendlyName("Event Name")] string EventName, [FriendlyName("Event Value")] Object EventValue, [FriendlyName("Broadcast To All"), DefaultValue(false)] bool Broadcast, [FriendlyName("Event Sender"), SocketState(false, false)] GameObject EventSender)
   {
      GameObject sender = m_Parent;
      if (EventSender != null) sender = EventSender;
      
      if (Broadcast)
      {
         uScriptCustomEvent.BroadcastCustomEvent(EventName, EventValue, sender);
      }
      else
      {
         uScriptCustomEvent.SendCustomEventUp(EventName, EventValue, sender);
      }
   }
   
   public override void SetParent(GameObject parent)
   {
      m_Parent = parent;
   }
}
