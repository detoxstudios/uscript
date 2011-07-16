// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sends a custom event with a Vector2 variable.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Custom Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a custom event with a Vector2 variable.")]
[NodeDescription("Sends a custom event with a Vector2 variable.\n \nEvent Name: The string-based event name.\nEvent Value: The value to pass in the event.\nSend To: Where to send this event. Choices are Parents (which is the default), Children, or All (broadcast).\nEvent Sender: The GameObject responsible for sending the event. If not specified, the sender will be the owner of this uScript.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Send_Custom_Event_.28Vector2.29")]

[FriendlyName("Send Custom Event (Vector2)")]
public class uScriptAct_SendCustomEventVector2 : uScriptLogic
{
   private GameObject m_Parent = null;

   public bool Out { get { return true; } }
    
   [FriendlyName("Send Custom Event")]
   public void SendCustomEvent(
      [FriendlyName("Event Name")] string EventName,
      [FriendlyName("Event Value")] Vector2 EventValue,
      [FriendlyName("Send To"), SocketState(false, false)] uScriptCustomEvent.SendGroup sendGroup, 
      [FriendlyName("Event Sender"), SocketState(false, false)] GameObject EventSender
      )
   {
      GameObject sender = m_Parent;
      if (EventSender != null) sender = EventSender;
      
      if (sendGroup == uScriptCustomEvent.SendGroup.All)
      {
         uScriptCustomEvent.BroadcastCustomEvent(EventName, EventValue, sender);
      }
      else if (sendGroup == uScriptCustomEvent.SendGroup.Children)
      {
         uScriptCustomEvent.SendCustomEventDown(EventName, EventValue, sender);
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
