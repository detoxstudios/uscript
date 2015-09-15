// uScript Action Node
// (C) 2011 Detox Studios LLC

#if !(UNITY_WP8 || UNITY_WP8_1 || UNITY_WINRT_8_1)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Network")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by John on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]


[NodeDescription("Reports the application's current network status.")]

[FriendlyName("Get Network Status", "Returns the status of the current network interface peer type and fires the correct output socket. It also returns the current status as a string.")]
public class uScriptAct_GetNetworkStatus : uScriptLogic
{
   private bool m_NotConnected = false;
   private bool m_Connecting = false;
   private bool m_ConnectedHost = false;
   private bool m_ConnectedClient = false;

   [FriendlyName("Out", "Standard out socket. This socket will always output a signal as soon as the node recieves an input signal.")]
   public bool Out { get { return true; } }

   [FriendlyName("Not Connected", "No client connection running. Server not initialized.")]
   public bool NotConnected { get { return m_NotConnected; } }

   [FriendlyName("Connecting", "Attempting to connect to a server.")]
   public bool Connecting { get { return m_Connecting; } }

   [FriendlyName("Connected Host", "Connected and running as the server.")]
   public bool ConnectedHost { get { return m_ConnectedHost; } }

   [FriendlyName("Connected Client", "Connected and running as a client.")]
   public bool ConnectedClient { get { return m_ConnectedClient; } }
   
   public void In(
         [FriendlyName("Network Status", "Returns the current network status as a string. String will be one of the following: Not Connected, Connecting, Connected (host), Connected (client)")] out string netStatus
      	)
   
   {
      m_NotConnected = false;
      m_Connecting = false;
      m_ConnectedHost = false;
      m_ConnectedClient = false;

   		string temp = "";

         if (Network.peerType == NetworkPeerType.Disconnected)
         {
            temp = "Not Connected";
            m_NotConnected = true;
         }
         else if (Network.peerType == NetworkPeerType.Connecting)
         {
            temp = "Connecting";
            m_Connecting = true;
         }
         else if (Network.peerType == NetworkPeerType.Server)
         {
            temp = "Connected (host)";
            m_ConnectedHost = true;
         }
         else if (Network.peerType == NetworkPeerType.Client)
         {
            temp = "Connected (client)";
            m_ConnectedClient = true;
         }
                
        netStatus = temp;
   }
}
#endif

