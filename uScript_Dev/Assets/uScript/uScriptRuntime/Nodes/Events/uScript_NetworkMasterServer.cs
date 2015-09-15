// uScript uScript_NetworkMasterServer.cs
// (C) 2010 Detox Studios LLC

#if !(UNITY_WP8 || UNITY_WP8_1 || UNITY_WINRT_8_1)
using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a master server event takes place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Network Master Server", "Fires an event signal when a master server event takes place.")]
public class uScript_NetworkMasterServer : uScriptEvent
{
   public class NetworkMasterServerEventArgs : System.EventArgs
   {
      [FriendlyName("Master Server Event", "Describes status messages from the master server.")]
      public MasterServerEvent MasterServerEvent { get { return m_Event; } }
      private MasterServerEvent m_Event;

      public NetworkMasterServerEventArgs(MasterServerEvent mse)
      {
         m_Event = mse;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkMasterServerEventArgs args);

#if !(UNITY_FLASH)
   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnEvent;

   void OnMasterServerEvent(MasterServerEvent mse)
   {
      if (OnEvent != null) OnEvent(this, new NetworkMasterServerEventArgs(mse));
   }
#endif
}
#endif