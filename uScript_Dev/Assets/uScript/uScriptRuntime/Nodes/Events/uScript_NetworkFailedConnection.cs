// uScript uScript_NetworkFailedConnection.cs
// (C) 2010 Detox Studios LLC

#if !(UNITY_WP8 || UNITY_WP8_1 || UNITY_WINRT_8_1)

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network client fails to connect to the server.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

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

#endif