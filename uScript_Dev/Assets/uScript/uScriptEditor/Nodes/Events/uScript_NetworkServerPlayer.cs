// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[FriendlyName("Network Server Player")]
public class uScript_NetworkServerPlayer : uScriptEvent
{
   public class NetworkServerPlayerEventArgs : System.EventArgs 
   {
      public NetworkPlayer NetworkPlayer { get { return m_NetworkPlayer; } }

      private NetworkPlayer m_NetworkPlayer;

      public NetworkServerPlayerEventArgs(NetworkPlayer netPlayer)
      {
         m_NetworkPlayer = netPlayer;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkServerPlayerEventArgs args);

   [FriendlyName("On Player Connected")]
   public event uScriptEventHandler PlayerConnected;

   [FriendlyName("On Player Disconnected")]
   public event uScriptEventHandler PlayerDisconnected;

   void OnPlayerConnected(NetworkPlayer netPlayer)
   {
      if (PlayerConnected != null) PlayerConnected(this, new NetworkServerPlayerEventArgs(netPlayer));
   }

   void OnPlayerDisconnected(NetworkPlayer netPlayer)
   {
      if (PlayerDisconnected != null) PlayerDisconnected(this, new NetworkServerPlayerEventArgs(netPlayer));
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
