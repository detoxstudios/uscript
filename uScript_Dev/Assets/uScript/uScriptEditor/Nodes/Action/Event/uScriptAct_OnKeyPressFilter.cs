// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down, being held, or released.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.")]
[NodeDescription("Filters the On Input Event output from the Input Events node to a specific input (key, mouse, joystick) pressed down, held, or released.\n \nKey Code: The key to listen for events from.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Input Events Filter")]
public class uScriptAct_OnKeyPressFilter : uScriptLogic
{
   public bool m_KeyHeld = false;
   public bool m_KeyDown = false;
   public bool m_KeyUp   = false;

   public bool KeyHeld  { get { return m_KeyHeld; } }
   public bool KeyDown  { get { return m_KeyDown; } }
   public bool KeyUp    { get { return m_KeyUp; } }

   public void In([FriendlyName("Key Code")] UnityEngine.KeyCode KeyCode)
   {  
      m_KeyDown = UnityEngine.Input.GetKeyDown(KeyCode);
      m_KeyHeld = UnityEngine.Input.GetKey    (KeyCode);
      m_KeyUp   = UnityEngine.Input.GetKeyUp  (KeyCode);
   }
}