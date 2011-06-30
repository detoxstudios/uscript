// uScript uScript_Accelerometer.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when an accelerometer event happens.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an accelerometer event happens.")]
[NodeDescription("Fires an event signal when an accelerometer event happens.\n \nAcceleration (out): The accelerometer value of this event.\nDelta Time (out): Amount of time (in seconds) that has passed since the last acceleraton measurement.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Accelerometer_Events")]

[FriendlyName("Accelerometer Events")]
public class uScript_Accelerometer : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, AccelerometerEventArgs args);
  
   public class AccelerometerEventArgs : System.EventArgs
   {
      private AccelerationEvent m_AccelEvent;
      
      public Vector3 Acceleration { get { return m_AccelEvent.acceleration; } }

      [FriendlyName("Delta Time"), SocketState(false, false)]
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