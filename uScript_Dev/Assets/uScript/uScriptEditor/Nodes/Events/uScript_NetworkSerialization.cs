// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

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

   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
}
