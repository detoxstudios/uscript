//Created with Detox Studios uScript, contains code copyright by Detox Studios.
using UnityEngine;

[NodePath("Events/Signals")]

[FriendlyName("Receive Signal (GameObject)", "Receives a signal from a Send Signal node  with a GameObject variable and continues execution.")]
public class uScript_ReceiveSignal_GameObject : uScriptEvent
{
	public delegate void uScriptEventHandler(object Sender, ReceiveCustomSignalEventArgs args);
	
	public class ReceiveCustomSignalEventArgs : System.EventArgs
	{
		private GameObject m_Sender;
		private GameObject m_SignalData;
		private string m_Signal;
		
		[FriendlyName("Sender", "The GameObject that sent this signal (if available).")]
		public GameObject Sender { get { return m_Sender; } }
		
		[FriendlyName("Signal Data", "The GameObject variable that was sent with this signal.")]
		public GameObject SignalData { get { return m_SignalData; } }
		
		[FriendlyName("Signal", "The name of the signal.")]
		[SocketState(true, false)]
		public string signalName{ get { return m_Signal; } }
		
		public ReceiveCustomSignalEventArgs(GameObject Sender, GameObject SignalData, string signalName)
		{
			m_Signal = signalName;
			m_SignalData = SignalData;
			m_Sender = Sender;
		}
	}
	
	[FriendlyName("Receive Signal")]
	public event uScriptEventHandler OnReceiveCustomSignal;
	
	public void OnIncomingSignal(GameObject objectToSignal, GameObject Sender, GameObject SignalData, string signalName )
	{
		if (objectToSignal.gameObject == gameObject)
			OnReceiveCustomSignal(this, new ReceiveCustomSignalEventArgs(Sender, SignalData, signalName) );
	}
}
