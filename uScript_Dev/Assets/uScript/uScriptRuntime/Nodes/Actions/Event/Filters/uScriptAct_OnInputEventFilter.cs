// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down, being held, or released.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
[NodeDescription("Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.\n \nKey Code: The key to listen for events from.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Input_Events_Filter")]

[FriendlyName("Input Events Filter")]
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

   public void In([FriendlyName("Key Code")] UnityEngine.KeyCode[] KeyCodes) 
   { 
      m_InputHeld = false;
      m_InputDown = false;
      m_InputUp   = false;

      foreach (KeyCode code in KeyCodes) 
      { 
         m_InputDown |= UnityEngine.Input.GetKeyDown(code); 
         m_InputHeld |= UnityEngine.Input.GetKey(code); 
         m_InputUp   |= UnityEngine.Input.GetKeyUp(code); 
      } 
   }
}