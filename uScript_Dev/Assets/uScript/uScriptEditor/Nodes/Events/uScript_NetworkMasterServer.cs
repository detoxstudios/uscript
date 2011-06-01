// uScript uScript_NetworkMasterServer.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when a master server event takes place.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a master server event takes place.\n \nMaster Server Event (out): Describes status messages from the master server.")]
[NodeDescription("Fires an event signal when a master server event takes place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Network Master Server")]
public class uScript_NetworkMasterServer : uScriptEvent
{
   public class NetworkMasterServerEventArgs : System.EventArgs
   {
      public MasterServerEvent MasterServerEvent { get { return m_Event; } }
      private MasterServerEvent m_Event;

      public NetworkMasterServerEventArgs(MasterServerEvent mse)
      {
         m_Event = mse;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkMasterServerEventArgs args);

   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnEvent;

   void OnMasterServerEvent(MasterServerEvent mse)
   {
      if (OnEvent != null) OnEvent(this, new NetworkMasterServerEventArgs(mse));
   }
}
