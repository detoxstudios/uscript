// uScript uScript_Accelerometer.cs
// (C) 2010 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an accelerometer event happens.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Accelerometer Events", "Fires an event signal when an accelerometer event happens.")]
public class uScript_Accelerometer : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, AccelerometerEventArgs args);
  
   public class AccelerometerEventArgs : System.EventArgs
   {
      private AccelerationEvent m_AccelEvent;

      [FriendlyName("Acceleration", "The accelerometer value of this event.")]
      public Vector3 Acceleration { get { return m_AccelEvent.acceleration; } }

      [FriendlyName("Delta Time", "Amount of time (in seconds) that has passed since the last acceleraton measurement.")]
      [SocketState(false, false)]
      public float DeltaTime { get { return m_AccelEvent.deltaTime; } }

      public AccelerometerEventArgs(AccelerationEvent accelEvent)
      {
         m_AccelEvent = accelEvent;
      }
   }

   [FriendlyName("On Acceleration")]
   public event uScriptEventHandler OnAccelerationEvent;

   void Update()
   {
      foreach (UnityEngine.AccelerationEvent accelEvent in Input.accelerationEvents)
      {
         if ( null != OnAccelerationEvent ) OnAccelerationEvent( this, new AccelerometerEventArgs(accelEvent) );     
      }
   }
}

#endif