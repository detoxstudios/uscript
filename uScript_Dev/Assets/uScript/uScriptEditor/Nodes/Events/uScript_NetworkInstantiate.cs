// uScript uScript_NetworkInstantiate.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when the network is instantiated.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Network Events/Network Instantiate")]
[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network is instantiated.\n \nNetwork Message Info (out): Contains information about the network that has been instantiated.")]
[NodeDescription("Fires an event signal when the network is instantiated.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Network Instantiate")]
public class uScript_NetworkInstantiate : uScriptEvent
{
   public class NetworkInstantiateEventArgs : System.EventArgs
   {
      [FriendlyName("Network Message Info")]
      public NetworkMessageInfo MessageInfo { get { return m_MessageInfo; } }
      private NetworkMessageInfo m_MessageInfo;

      public NetworkInstantiateEventArgs(NetworkMessageInfo info)
      {
         m_MessageInfo = info;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkInstantiateEventArgs args);

   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnInstantiate;

   void OnNetworkInstantiate(NetworkMessageInfo info)
   {
      if (OnInstantiate != null) OnInstantiate(this, new NetworkInstantiateEventArgs(info));
   }
}
