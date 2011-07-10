// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a basic custom event.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Custom Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a basic custom event.")]
[NodeDescription("Sends a basic custom event.\n \nEvent Name: The string-based event name.\nBraodcast To All: Whether or not to broadcast this event to all GameObjects. If false (which is the default), this event will only be sent to the ancestors of Event Sender (or the owner of this uScript).\nEvent Sender: The GameObject responsible for sending the event. If not specified, the sender will be the owner of this uScript.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Send_Custom_Event")]

[FriendlyName("Send Custom Event")]
public class uScriptAct_SendCustomEvent : uScriptLogic
{
   private GameObject m_Parent = null;

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent(
      [FriendlyName("Event Name")] string EventName,
      [FriendlyName("Broadcast To All"), DefaultValue(false), SocketState(false, false)] bool Broadcast, 
      [FriendlyName("Event Sender"), SocketState(false, false)] GameObject EventSender
      )
   {
      GameObject sender = m_Parent;
      if (EventSender != null) sender = EventSender;
      
      if (Broadcast)
      {
         uScriptCustomEvent.BroadcastCustomEvent(EventName, null, sender);
      }
      else
      {
         uScriptCustomEvent.SendCustomEventUp(EventName, null, sender);
      }
   }
   
   public override void SetParent(GameObject parent)
   {
      m_Parent = parent;
   }
}
