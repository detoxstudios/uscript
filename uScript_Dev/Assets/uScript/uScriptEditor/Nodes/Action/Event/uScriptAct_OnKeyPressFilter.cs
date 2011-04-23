// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down.

using UnityEngine;
using System.Collections;

[NodePath("Action/Event")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Filters the On Key Press event to a specific key when the key is pressed down.")]
[NodeDescription("Filters the On Key Press event to a specific key when the key is pressed down.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Filter On Key Press")]
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