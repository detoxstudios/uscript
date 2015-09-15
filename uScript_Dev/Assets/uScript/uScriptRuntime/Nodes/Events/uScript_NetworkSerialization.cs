// uScript uScript_NetworkSerialization.cs
// (C) 2010 Detox Studios LLC

#if !(UNITY_WP8 || UNITY_WP8_1 || UNITY_WINRT_8_1)
using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Network Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when network serialization takes place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Network Serialization", "Fires an event signal when network serialization takes place.")]
public class uScript_NetworkSerialization : uScriptEvent
{
   public class NetworkSerializationEventArgs : System.EventArgs
   {
      [FriendlyName("Bit Steam", "The serialized data.")]
      public BitStream BitStream { get { return m_BitStream; } }
      private BitStream m_BitStream;

      [FriendlyName("Network Message Info", "Contains information about the network serialization.")]
      public NetworkMessageInfo MessageInfo { get { return m_MessageInfo; } }
      private NetworkMessageInfo m_MessageInfo;

      public NetworkSerializationEventArgs(BitStream bs, NetworkMessageInfo info)
      {
         m_BitStream   = bs;
         m_MessageInfo = info;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkSerializationEventArgs args);

#if !(UNITY_FLASH)
   [FriendlyName("On Serialize Network View")]
   public event uScriptEventHandler OnSerialize;

   void OnSerializeNetworkView(BitStream bs, NetworkMessageInfo info)
   {
      if (OnSerialize != null) OnSerialize(this, new NetworkSerializationEventArgs(bs, info));
   }
#endif
}
#endif