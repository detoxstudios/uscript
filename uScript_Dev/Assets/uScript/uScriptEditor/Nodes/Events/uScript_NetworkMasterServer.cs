// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Network))]

[NodePath("Events/Network Events")]

[FriendlyName("Network Master Server")]
public class uScript_NetworkMasterServer : uScriptEvent
{
   public class NetworkMasterServerEventArgs : System.EventArgs
   {
      public MasterServerEvent MasterServerEvent { get { return m_Event; } }
      private MasterServerEvent m_Event;

      public NetworkMasterServerEventArgs(MasterServerEvent mse)
      {
         m_Event = mse;
      }
   }

   public delegate void uScriptEventHandler(object sender, NetworkMasterServerEventArgs args);

   [FriendlyName("On Server Initialized")]
   public event uScriptEventHandler OnEvent;

   void OnMasterServerEvent(MasterServerEvent mse)
   {
      if (OnEvent != null) OnEvent(this, new NetworkMasterServerEventArgs(mse));
   }
}
