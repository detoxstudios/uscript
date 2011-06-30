// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Allows the signal to pass through to the Out link depending on the state of the gate.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Gates")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows the signal to pass through to the Out link depending on the state of the gate.")]
[NodeDescription("Allows the signal to pass through to the Out link depending on the state of the gate.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Gate")]

[FriendlyName("Gate")]
public class uScriptCon_Gate : uScriptLogic
{
   private bool m_GateOpen = false;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;

   public void In()
   {
      if (m_GateOpen)
      {
         if ( Out != null ) Out(this, new System.EventArgs( ));
      }
   }

   public void Open()
   {
      m_GateOpen = true;
   }

   public void Close()
   {
      m_GateOpen = false;
   }

   public void Toggle()
   {
      m_GateOpen = !m_GateOpen;
   }
}