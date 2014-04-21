// uScript uScript_Collision.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Signals")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Receives a signal from a Send Signal node and continues execution.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#On_Receive_Signal")]

[FriendlyName("Receive Signal", "Receives a signal from a Send Signal node and continues execution.")]
public class uScript_ReceiveSignal : uScriptEvent
{
   public class ReceiveSignalEventArgs : System.EventArgs
   {
      [FriendlyName("Signal", "The name of the signal.")]
      [SocketState(true, false)]
      public string Signal{ get { return m_Signal; } }

      private string m_Signal;

      public ReceiveSignalEventArgs(string signal)
      {
         m_Signal = signal;
      }
   }

   public delegate void uScriptEventHandler(object sender, ReceiveSignalEventArgs args);

   private GameObject m_Parent;

   [FriendlyName("Receive Signal")]
   public event uScriptEventHandler OnReceiveSignal;

   public void OnIncomingSignal(GameObject o, string name)
   {
      if (o.gameObject == gameObject && OnReceiveSignal != null) 
         OnReceiveSignal(this, new ReceiveSignalEventArgs(name));
   }
}
