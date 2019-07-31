//Created with Detox Studios uScript, contains code copyright by Detox Studios.
using UnityEngine;

[NodePath("Events/Signals")]

[FriendlyName("Receive Signal (Float)", "Receives a signal from a Send Signal with a Float variable node and continues execution.")]
public class uScript_ReceiveSignal_Float : uScriptEvent
{	
	public delegate void uScriptEventHandler(object Sender, ReceiveCustomSignalEventArgs args);
	
	public class ReceiveCustomSignalEventArgs : System.EventArgs
	{
		private GameObject m_Sender;
		private float m_SignalData;
		private string m_Signal;
		
		[FriendlyName("Sender", "The GameObject that sent this signal (if available).")]
		public GameObject Sender { get { return m_Sender; } }
		
		[FriendlyName("Signal Data", "The float variable that was sent with this signal.")]
		public float SignalData { get { return m_SignalData; } }
		
		[FriendlyName("Signal", "The name of the signal.")]
		[SocketState(true, false)]
		public string signalName{ get { return m_Signal; } }
		
		public ReceiveCustomSignalEventArgs(GameObject Sender, float SignalData, string signalName)
		{
			m_Signal = signalName;
			m_SignalData = SignalData;
			m_Sender = Sender;
		}		
	}
	
	[FriendlyName("Receive Signal")]
	public event uScriptEventHandler OnReceiveCustomSignal;
	
	public void OnIncomingSignal(GameObject objectToSignal, GameObject Sender, float SignalData, string signalName )
	{
		
		if (objectToSignal.gameObject == gameObject)
			OnReceiveCustomSignal(this, new ReceiveCustomSignalEventArgs(Sender, SignalData, signalName) );
	}
}
