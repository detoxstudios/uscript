// uScript uScript_Triggers.cs
// (C) 2016 Matt Glanville

using UnityEngine;
using System.Collections;

[NodePath("Events")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC / Matt Glanville / John Gray")]
[NodeToolTip("Fires an event signal when a GameObject enters or exits a trigger. Does NOT call when an object stays in a trigger.")]
[NodeAuthor("Matt Glanville / John Gray", "http://www.mglanville.co.uk / johnny@johnnygray.co.uk")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodePropertiesPath("Properties/Triggers")]
[FriendlyName("Trigger Event - No Stay", "Fires an event signal when a GameObject enters or exits a trigger. Does NOT call when an object stays in a trigger (this gives a performance boost over the nodes that DO check). The Instance GameObject must have a collider component on it set to be a trigger. Also, only other Gameobjects with a rigidbody component will trigger this event (the 'Triggered By' GameObject).")]
public class uScript_Trigger_NoStay : uScriptEvent
{
	public delegate void uScriptEventHandler(object sender, TriggerEventArgs args);

	public class TriggerEventArgs : System.EventArgs
	{
		[FriendlyName("Triggered By", "The GameObject that interacted with this GameObject's (the Instance) collider component. ")]
		[SocketState(true, false)]
		public GameObject GameObject { get { return m_GameObject; } }
		private GameObject m_GameObject;

		public TriggerEventArgs(GameObject gameObject)
		{
			m_GameObject = gameObject;
		}
	}

	[FriendlyName("On Trigger Enter")]
	public event uScriptEventHandler OnEnterTrigger;
	[FriendlyName("On Trigger Exit")]
	public event uScriptEventHandler OnExitTrigger;

	void OnTriggerEnter(Collider other)
	{
		if ( OnEnterTrigger != null ) OnEnterTrigger( this, new TriggerEventArgs(other.gameObject) ); 
	}

	void OnTriggerExit(Collider other)
	{
		if ( OnExitTrigger != null ) OnExitTrigger( this, new TriggerEventArgs(other.gameObject) ); 
	}
		
}
