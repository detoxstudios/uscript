// uScript uScript_NetworkClientConnection.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network client connects or disconnects from the server.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Network_Client_Connection")]

[FriendlyName("Network Client Connection", "Fires an event signal when the network client connects or disconnects from the server.")]
public class uScript_NetworkClientConnection : uScriptEvent
{
   public class NetworkClientConnectionEventArgs : System.EventArgs 
   {
      [FriendlyName("Reason for Failure", "What happened if there is a connection failure - can be 'Disconnected', 'Lost Connection', or 'Unknown'.")]
      public string Failure { get { return m_Failure; } }

      private string m_Failure;

      public NetworkClientConnectionEventArgs(NetworkDisconnection disconnection)
      {
         if ( disconnection == NetworkDisconnection.Disconnected )
         {
            m_Failure = "Disconnected";
         }
         else if ( disconnection == NetworkDisconnection.LostConnection )
         {
            m_Failure = "Lost Connection";
         }
         else
         {
            m_Failure = "Unknown";
         }
      }

      public NetworkClientConnectionEventArgs()
      {
         m_Failure = "";
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkClientConnectionEventArgs args);

   [FriendlyName("On Connected to Server")]
   public event uScriptEventHandler ConnectedToServer;

#if !(UNITY_FLASH)
   [FriendlyName("On Disconnected from Server")]
   public event uScriptEventHandler DisconnectedFromServer;
#endif
   
   void OnConnectedToServer( )
   {
      if (ConnectedToServer != null) ConnectedToServer(this, new NetworkClientConnectionEventArgs());
   }

#if !(UNITY_FLASH)
   void OnDisconnectedFromServer(NetworkDisconnection disconnection)
   {
      if (DisconnectedFromServer != null) DisconnectedFromServer(this, new NetworkClientConnectionEventArgs(disconnection));
   }
#endif
}
