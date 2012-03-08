// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a player connects or disconnects from a server.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Network_Server_Player")]

[FriendlyName("Network Server Player", "Fires an event signal when a player connects or disconnects from a server.")]
public class uScript_NetworkServerPlayer : uScriptEvent
{
   public class NetworkServerPlayerEventArgs : System.EventArgs 
   {
      [FriendlyName("Network Player", "The player who connected or disconnected")]
      public NetworkPlayer NetworkPlayer { get { return m_NetworkPlayer; } }
      private NetworkPlayer m_NetworkPlayer;

      public NetworkServerPlayerEventArgs(NetworkPlayer netPlayer)
      {
         m_NetworkPlayer = netPlayer;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkServerPlayerEventArgs args);

#if !(UNITY_FLASH)
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
#endif
}
