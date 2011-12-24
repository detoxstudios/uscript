// uScript uScript_NetworkInstantiate.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network is instantiated.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Network_Instantiate")]

[FriendlyName("Network Instantiate", "Fires an event signal when the network is instantiated.")]
public class uScript_NetworkInstantiate : uScriptEvent
{
   public class NetworkInstantiateEventArgs : System.EventArgs
   {
      [FriendlyName("Network Message Info", "Contains information about the network that has been instantiated.")]
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
