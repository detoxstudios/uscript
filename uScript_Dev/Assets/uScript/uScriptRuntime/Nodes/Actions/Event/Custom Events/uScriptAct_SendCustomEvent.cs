// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Custom Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a basic custom event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Send Custom Event", "Sends a basic custom event.")]
public class uScriptAct_SendCustomEvent : uScriptLogic
{
   private GameObject m_Parent = null;

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent(
      [FriendlyName("Event Name", "The string-based event name.")]
      string EventName,
      
      [FriendlyName("Send To", "Where to send this event. Choices are Parents (which is the default), Children, or All (broadcast).")]
      [SocketState(false, false)]
      uScriptCustomEvent.SendGroup sendGroup,

      [FriendlyName("Event Sender", "The GameObject responsible for sending the event. If not specified, the sender will be the owner of this uScript.")]
      [SocketState(false, false)]
      GameObject EventSender
      )
   {
      GameObject sender = m_Parent;
      if (EventSender != null) sender = EventSender;
      
      if (sendGroup == uScriptCustomEvent.SendGroup.All)
      {
         uScriptCustomEvent.BroadcastCustomEvent(EventName, null, sender);
      }
      else if (sendGroup == uScriptCustomEvent.SendGroup.Children)
      {
         uScriptCustomEvent.SendCustomEventDown(EventName, null, sender);
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
