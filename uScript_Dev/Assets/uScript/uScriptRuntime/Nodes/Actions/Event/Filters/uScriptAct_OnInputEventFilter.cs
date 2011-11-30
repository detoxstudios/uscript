// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Input_Events_Filter")]

[FriendlyName("Input Events Filter", "Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
public class uScriptAct_OnInputEventFilter : uScriptLogic
{
   public bool m_InputHeld = false;
   public bool m_InputDown = false;
   public bool m_InputUp = false;

   [FriendlyName("Input Held")]
   public bool KeyHeld { get { return m_InputHeld; } }

   [FriendlyName("Input Down")]
   public bool KeyDown { get { return m_InputDown; } }

   [FriendlyName("Input Up")]
   public bool KeyUp { get { return m_InputUp; } }

   public void In(
      [FriendlyName("Key Code", "The key to listen for events from.")]
      UnityEngine.KeyCode KeyCode
      )
   {
      m_InputDown = UnityEngine.Input.GetKeyDown(KeyCode);
      m_InputHeld = UnityEngine.Input.GetKey(KeyCode);
      m_InputUp = UnityEngine.Input.GetKeyUp(KeyCode);
   }
}