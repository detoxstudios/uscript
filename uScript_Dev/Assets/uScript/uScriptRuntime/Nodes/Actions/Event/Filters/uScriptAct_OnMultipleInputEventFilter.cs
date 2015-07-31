// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Multiple Input Events Filter", "Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
public class uScriptAct_OnMultipleInputEventFilter : uScriptLogic
{
   public bool m_InputHeld = false;
   public bool m_InputDown = false;
   public bool m_InputUp = false;

   [FriendlyName("Input Down")]
   public bool KeyDown { get { return m_InputDown; } }

   [FriendlyName("Input Held")]
   public bool KeyHeld { get { return m_InputHeld; } }

   [FriendlyName("Input Up")]
   public bool KeyUp { get { return m_InputUp; } }

   public void In(
      [FriendlyName("Key Code", "The key to listen for events from.")]
      UnityEngine.KeyCode []KeyCode
      )
   {
      m_InputDown = false;
      m_InputHeld = false;
      m_InputUp   = false;

      foreach ( UnityEngine.KeyCode key in KeyCode )
      {
         m_InputDown |= UnityEngine.Input.GetKeyDown(key);
         m_InputHeld |= UnityEngine.Input.GetKey(key);
         m_InputUp   |= UnityEngine.Input.GetKeyUp(key);
      }
   }
}