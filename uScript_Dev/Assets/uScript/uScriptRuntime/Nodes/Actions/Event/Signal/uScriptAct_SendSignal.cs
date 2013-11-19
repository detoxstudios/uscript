// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Events/Signals")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sends a signal to a Receive Signal node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Send_Signal")]

[FriendlyName("Send Signal", "Sends a signal to a Receive Signal node.")]
public class uScriptAct_SendSignal : uScriptLogic
{
   public bool Out { get { return true; } }

   public delegate void uScriptSendSignalDelegate(GameObject objectToSignal, string name);

   private GameObject m_Parent;

   [FriendlyName("Send Signal")]
   public void SendSignal(
      [FriendlyName("GameObject", "The GameObject to signal (null for the current GameObject).")]
      [SocketState(false, false)]
      GameObject objectToSignal,
      [FriendlyName("Signal Name", "The string-based signal name.")]
      string signalName
      )
   {
      if (null == objectToSignal)
         objectToSignal = m_Parent;

      uScript_ReceiveSignal receiver = objectToSignal.GetComponent<uScript_ReceiveSignal>();
      
      if (null != receiver)
         receiver.OnIncomingSignal(objectToSignal, signalName);
   }

   public override void SetParent(GameObject parent)
   {
      m_Parent = parent;
   }
}
