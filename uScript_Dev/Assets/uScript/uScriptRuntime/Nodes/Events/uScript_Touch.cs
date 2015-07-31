// uScript uScript_Touch.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a touch event(s) happens. Supported Touch events are: Touch Began, Touch Moved, Touch Stationary, Touch Ended, Touch Canceled.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Touch Events", "Fires an event signal when a touch event(s) happens. Supported Touch events are: Touch Began, Touch Moved, Touch Stationary, Touch Ended, Touch Canceled.")]
public class uScript_Touch : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TouchEventArgs args);
  
   public class TouchEventArgs : System.EventArgs
   {
      private Touch m_Touch;
      
      [FriendlyName("Finger ID", "ID of this Touch event.")]
      [SocketState(false, false)]
      public int FingerId { get { return m_Touch.fingerId; } }

      [FriendlyName("Position", "2D screen position where the Touch event occured.")]
      public Vector2 Position { get { return m_Touch.position; } }
     
      [FriendlyName("Delta Position", "Change in position of the Touch event.")]
      public Vector2 DeltaPosition { get { return m_Touch.deltaPosition; } }

      [FriendlyName("Delta Time", "Amount of time (in seconds) that has passed since the last state change.")]
      [SocketState(false, false)]
      public float DeltaTime { get { return m_Touch.deltaTime; } }

      [FriendlyName("Tap Count", "The number of times the user has tapped the screen without moving away from the original tap spot. [This parameter is unsupported on Android, and will always return 1]")]
      [SocketState(false, false)]
      public int TapCount { get { return m_Touch.tapCount; } }

      public TouchEventArgs(Touch touch)
      {
         m_Touch = touch;
      }
   }

   [FriendlyName("On Touch Began")]
   public event uScriptEventHandler OnTouchBegan;
   [FriendlyName("On Touch Moved")]
   public event uScriptEventHandler OnTouchMoved;
   [FriendlyName("On Touch Stationary")]
   public event uScriptEventHandler OnTouchStationary;
   [FriendlyName("On Touch Ended")]
   public event uScriptEventHandler OnTouchEnded;
   [FriendlyName("On Touch Canceled")]
   public event uScriptEventHandler OnTouchCanceled;

   void Update()
   {
      foreach (UnityEngine.Touch touch in Input.touches)
      {
         if (touch.phase == TouchPhase.Began)
         {
            if ( null != OnTouchBegan ) OnTouchBegan( this, new TouchEventArgs(touch) );     
         }
         else if (touch.phase == TouchPhase.Moved)
         {
            if ( null != OnTouchMoved ) OnTouchMoved( this, new TouchEventArgs(touch) );     
         }
         else if (touch.phase == TouchPhase.Stationary)
         {
            if ( null != OnTouchStationary ) OnTouchStationary( this, new TouchEventArgs(touch) );     
         }
         else if (touch.phase == TouchPhase.Ended)
         {
            if ( null != OnTouchEnded ) OnTouchEnded( this, new TouchEventArgs(touch) );     
         }
         else if (touch.phase == TouchPhase.Canceled)
         {
            if ( null != OnTouchCanceled ) OnTouchCanceled( this, new TouchEventArgs(touch) );     
         }
      }
   }
}
