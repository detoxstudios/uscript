// uScript uScript_NetworkInstantiate.cs
// (C) 2010 Detox Studios LLC

#if !(UNITY_WP8 || UNITY_WP8_1 || UNITY_WINRT_8_1)

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the network is instantiated.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

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

#if !(UNITY_FLASH)
   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnInstantiate;

   void OnNetworkInstantiate(NetworkMessageInfo info)
   {
      if (OnInstantiate != null) OnInstantiate(this, new NetworkInstantiateEventArgs(info));
   }
#endif
}

#endif