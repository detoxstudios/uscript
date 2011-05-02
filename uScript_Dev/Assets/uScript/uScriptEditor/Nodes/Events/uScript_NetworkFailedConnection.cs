// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[FriendlyName("Network Failed Connection")]
public class uScript_NetworkFailedConnection : uScriptEvent
{
   public class NetworkFailedConnectionEventArgs : System.EventArgs 
   {
      [FriendlyName("Connection Error")]
      public NetworkConnectionError Error { get { return m_Error; } }
      private NetworkConnectionError m_Error;

      public NetworkFailedConnectionEventArgs(NetworkConnectionError error)
      {
         m_Error = error;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkFailedConnectionEventArgs args);

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

#if UNITY_EDITOR
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptRuntimeConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
#endif

}
