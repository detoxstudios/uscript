// uScript uScript_NetworkFailedConnection.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network client fails to connect to the server.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Network_Failed_Connection")]

[FriendlyName("Network Failed Connection", "Fires an event signal when the network client fails to connect to the server.")]
public class uScript_NetworkFailedConnection : uScriptEvent
{
   public class NetworkFailedConnectionEventArgs : System.EventArgs 
   {
      [FriendlyName("Connection Error", "The UnityEngine.NetworkConnectionError result.")]
      public NetworkConnectionError Error { get { return m_Error; } }
      private NetworkConnectionError m_Error;

      public NetworkFailedConnectionEventArgs(NetworkConnectionError error)
      {
         m_Error = error;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkFailedConnectionEventArgs args);

#if !(UNITY_FLASH)
   [FriendlyName("On Failed to Connect")]
   public event uScriptEventHandler FailedToConnect;

   [FriendlyName("On Failed to Connect to Master Server")]
   public event uScriptEventHandler FailedToConnectToMaster;

   void OnFailedToConnect(NetworkConnectionError error)
   {
      if (FailedToConnect != null) FailedToConnect(this, new NetworkFailedConnectionEventArgs(error));
   }

   void OnFailedToConnectToMasterServer(NetworkConnectionError error)
   {
      if (FailedToConnectToMaster != null) FailedToConnectToMaster(this, new NetworkFailedConnectionEventArgs(error));
   }
#endif
}
