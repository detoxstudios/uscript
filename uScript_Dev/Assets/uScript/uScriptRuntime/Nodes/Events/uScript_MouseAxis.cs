// uScript uScript_MouseAxis.cs
// (C) 2013 Detox Studios LLC

using UnityEngine;
using System;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Fires when there are changes to any of the axis for the mouse (X, Y, or the Mouse Wheel).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]

[FriendlyName("Mouse Axis", "Fires when there are changes to any of the axis for the mouse (X, Y, or the Mouse Wheel).")]
public class uScript_MouseAxis : uScriptEvent
{

   public delegate void uScriptEventHandler(object sender, CustomMouseAxisArgs args);

   [FriendlyName("On Mouse Axis")]
   public event uScriptEventHandler AxisEvent;

   public float xInput = 0f;
   public float yInput = 0f;
   public float wheelInput = 0f;

   void Update()
   {
      // Poll the axes
      xInput = Input.GetAxis("Mouse X");
      yInput = Input.GetAxis("Mouse Y");
      wheelInput = Input.GetAxis("Mouse ScrollWheel");
      //Debug.Log("[script] Wheel: " + wheelInput.ToString());

      // Fire an event if there is input
      if (xInput != 0f || yInput != 0f || wheelInput != 0f)
      {
         if (AxisEvent != null)
         {
            AxisEvent(this, new CustomMouseAxisArgs(xInput, yInput, wheelInput));
         }
      }
   }


   public class CustomMouseAxisArgs : System.EventArgs
   {
      private float xIn = 0f;
      private float yIn = 0f;
      private float wheelIn = 0f;

      [FriendlyName("X Input")]
      public float MouseX
      {
         get { return (xIn); }
      }

      [FriendlyName("Y Input")]
      public float MouseY
      {
         get { return (yIn); }
      }

      [FriendlyName("Wheel")]
      public float Wheel
      {
         get { return (wheelIn); }
      }

      public CustomMouseAxisArgs(float x, float y, float w)
      {
         xIn = x;
         yIn = y;
         wheelIn = w;
      }
   }

}