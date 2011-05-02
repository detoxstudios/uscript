// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

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

#if UNITY_EDITOR
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if (this.name != uScriptRuntimeConfig.MasterObjectName)
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }
#endif

}
