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

[FriendlyName("Get Network Player Info", "Returns network information regarding the player.")]
public class uScriptAct_GetNetworkPlayerInfo : uScriptLogic
{
   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("IP Address", "Returns the IP address of this player.")] out string networkIP,
      [FriendlyName("External IP", "Returns the external IP address of the network interface.")] out string extNetworkIP,
      [FriendlyName("Port", "Returns the port of this player.")] out int networkPort,
      [FriendlyName("External Port", "Returns the external port of the network interface.")] out int extPort,
      [FriendlyName("GUID", "Returns the GUID for this player, used when connecting with NAT punchthrough.")] out string playerGUID
      )
   
   {
   	networkIP = Network.player.ipAddress;
      extNetworkIP = Network.player.externalIP;
      networkPort = Network.player.port;
      extPort = Network.player.externalPort;
      playerGUID = Network.player.guid;
   }
}


#endif