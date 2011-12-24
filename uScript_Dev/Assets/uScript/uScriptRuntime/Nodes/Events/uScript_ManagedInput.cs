// uScript uScript_ManagedInput.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Monitors Unity's Input Manager and returns the current state of each named input axis.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Managed_Input_Events")]

[FriendlyName("Managed Input Events", "Monitors Unity's Input Manager and returns the current state of each named input axis." +
   "\n\nThis node only works with the default Input Manager settings that Unity provides.  If you have" +
   " removed or renamed any of the default axes, runtime errors will be generated.  Furthermore, any" +
   " new items added to the Input Manager will be ignored by this node." +
   "\n\nIf you wish to customize the Input Manager entries, you should create a custom node to handle" +
   " the modified Input Manager settings, using this node as a template.")]
public class uScript_ManagedInput : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);


   public class CustomEventBoolArgs : System.EventArgs
   {
      float _Horizontal;   // left (a) / right (d) / X axis on all joysticks
      float _Vertical;     // down (s) / up (w)    / Y axis on all joysticks

      bool _Fire1;         // "left ctrl" (mouse 0)   / Joystick button 0
      bool _Fire2;         // "left alt" (mouse 1)    / Joystick button 1
      bool _Fire3;         // "left cmd" (mouse 2)    / Joystick button 2
      bool _Jump;          // "space"                 / Joystick button 3

      float _MouseX;
      float _MouseY;
      float _MouseScrollWheel;

      float _WindowShakeX;
      float _WindowShakeY;


      [FriendlyName("Horizontal", "Horizontal joystick axis, including the keys \"left\" and \"a\" for negative values and \"right\" and \"d\" for positive values.")]
      public float Horizontal { get { return _Horizontal; } }

      [FriendlyName("Vertical", "Vertical joystick axis, including the keys \"down\" and \"s\" for negative values and \"up\" and \"w\" for positive values.")]
      public float Vertical { get { return _Vertical; } }

      [FriendlyName("Fire 1", "Joystick button 0, \"left ctrl\", and Mouse button 0.")]
      public bool Fire1 { get { return _Fire1; } }

      [FriendlyName("Fire 2", "Joystick button 1, \"left alt\", and Mouse button 1.")]
      public bool Fire2 { get { return _Fire2; } }

      [FriendlyName("Fire 3", "Joystick button 2, \"left cmd\", and Mouse button 2.")]
      public bool Fire3 { get { return _Fire3; } }

      [FriendlyName("Jump", "Joystick button 3, and \"space\".")]
      public bool Jump { get { return _Jump; } }

      [FriendlyName("Mouse X", "Horizontal mouse movement delta.")]
      [SocketState(false, false)]
      public float MouseX { get { return _MouseX; } }

      [FriendlyName("Mouse Y", "Vertical mouse movement delta.")]
      [SocketState(false, false)]
      public float MouseY { get { return _MouseY; } }

      [FriendlyName("Mouse ScrollWheel", "Mouse scroll wheel delta.")]
      [SocketState(false, false)]
      public float MouseScrollWheel { get { return _MouseScrollWheel; } }

      [FriendlyName("Window Shake X", "Horizontal window movement delta.")]
      [SocketState(false, false)]
      public float WindowShakeX { get { return _WindowShakeX; } }

      [FriendlyName("Window Shake Y", "Vertical window movement delta.")]
      [SocketState(false, false)]
      public float WindowShakeY { get { return _WindowShakeY; } }


      public CustomEventBoolArgs()
      {
         // Update the input variables
         _Horizontal = Input.GetAxis("Horizontal");
         _Vertical = Input.GetAxis("Vertical");

         _Fire1 = (Input.GetAxis("Fire1") == 1);
         _Fire2 = (Input.GetAxis("Fire2") == 1);
         _Fire3 = (Input.GetAxis("Fire3") == 1);
         _Jump = (Input.GetAxis("Jump") == 1);

         _MouseX = Input.GetAxis("Mouse X");
         _MouseY = Input.GetAxis("Mouse Y");
         _MouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

         _WindowShakeX = Input.GetAxis("Window Shake X");
         _WindowShakeY = Input.GetAxis("Window Shake Y");
      }
   }


   [FriendlyName("On Input Event")]
   public event uScriptEventHandler OnInputEvent;


   void Update()
   {
      if (OnInputEvent != null)
      {
         OnInputEvent( this, new CustomEventBoolArgs() );
      }
   }

}
