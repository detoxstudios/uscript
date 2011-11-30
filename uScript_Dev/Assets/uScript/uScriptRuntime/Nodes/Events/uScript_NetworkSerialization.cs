// uScript uScript_NetworkSerialization.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when network serialization takes place.\n \nBitStream: The serialized data.\nNetwork Message Info (out): Contains information about the network serialization.")]
[NodeDescription("Fires an event signal when network serialization takes place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Network_Serialization")]

[FriendlyName("Network Serialization")]
public class uScript_NetworkSerialization : uScriptEvent
{
   public class NetworkSerializationEventArgs : System.EventArgs
   {
      public BitStream BitStream { get { return m_BitStream; } }
      private BitStream m_BitStream;

      [FriendlyName("Network Message Info")]
      public NetworkMessageInfo MessageInfo { get { return m_MessageInfo; } }
      private NetworkMessageInfo m_MessageInfo;

      public NetworkSerializationEventArgs(BitStream bs, NetworkMessageInfo info)
      {
         m_BitStream   = bs;
         m_MessageInfo = info;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkSerializationEventArgs args);

   [FriendlyName("On Serialize Network View")]
   public event uScriptEventHandler OnSerialize;

   void OnSerializeNetworkView(BitStream bs, NetworkMessageInfo info)
   {
      if (OnSerialize != null) OnSerialize(this, new NetworkSerializationEventArgs(bs, info));
   }
}
