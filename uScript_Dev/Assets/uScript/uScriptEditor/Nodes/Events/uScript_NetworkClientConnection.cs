// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[FriendlyName("Network Client Connection")]
public class uScript_NetworkClientConnection : uScriptEvent
{
   public class NetworkClientConnectionEventArgs : System.EventArgs 
   {
      [FriendlyName("Reason for Failure")]
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

   [FriendlyName("On Disconnected from Server")]
   public event uScriptEventHandler DisconnectedFromServer;

   void OnConnectedToServer( )
   {
      if (ConnectedToServer != null) ConnectedToServer(this, new NetworkClientConnectionEventArgs());
   }

   void OnDisconnectedFromServer(NetworkDisconnection disconnection)
   {
      if (DisconnectedFromServer != null) DisconnectedFromServer(this, new NetworkClientConnectionEventArgs(disconnection));
   }

#if UNITY_EDITOR
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
#endif

}
