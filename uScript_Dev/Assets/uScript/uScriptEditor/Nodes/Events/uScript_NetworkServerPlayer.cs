// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when a player connects or disconnects from a server.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Network Events/Network Server Player")]
[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a player connects or disconnects from a server.")]
[NodeDescription("Fires an event signal when a player connects or disconnects from a server.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

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
}
