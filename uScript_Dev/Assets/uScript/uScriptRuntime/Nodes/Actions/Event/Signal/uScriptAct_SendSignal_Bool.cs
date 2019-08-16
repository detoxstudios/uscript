//Created with Detox Studios uScript, contains code copyright by Detox Studios. 

using UnityEngine;

[NodePath("Actions/Events/Signals")]

[FriendlyName("Send Signal (Bool)", "Sends a signal to a GameObject with a Boolean variable.")]
public class uScriptAct_SendSignal_Bool : uScriptLogic
{
	public bool Out { get { return true; } }
	
	public delegate void uScriptSendSignalDelegate(GameObject objectToSignal, GameObject SignalSender, bool SignalData, string signalName);
	
	private GameObject m_Parent;
	
	[FriendlyName("Send Signal")]
	public void SendCustomSignal(
		[FriendlyName("GameObject", "The GameObject to signal (null for the current GameObject).")]
		GameObject objectToSignal,
		
		[FriendlyName("Signal Sender", "The GameObject responsible for sending the signal. If not specified, the sender will be the owner of this uScript.")]
		[SocketState(false, false)]
		GameObject SignalSender,
		
		[FriendlyName("Signal Name", "The string-based signal name.")]
		string signalName,
		
		[FriendlyName("Signal Data", "The Boolean value to pass in the signal.")]
		bool SignalData
		)
	{
		if (null == objectToSignal)
			objectToSignal = m_Parent;
		
		uScript_ReceiveSignal_Bool receiver = objectToSignal.GetComponent<uScript_ReceiveSignal_Bool>();
		
		if (null != receiver)
			receiver.OnIncomingSignal(objectToSignal, SignalSender, SignalData, signalName);
	}
	
	public override void SetParent(GameObject parent)
	{
		m_Parent = parent;
	}
}