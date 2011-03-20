// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Allows the signal to pass through to the Out link depending on the state of the gate.

using UnityEngine;
using System.Collections;

public class uScriptAct_Gate : uScriptLogic
{
   private bool m_gateOpen = false;

   public event uScriptEventHandler Out;

   public void In()
   {
      if (m_gateOpen)
      {
         uScript_EventHandler.DoEvent(this, Out, new object[] { });
      }

   }

   public void Open()
   {
      m_gateOpen = true;
   }

   public void Close()
   {
      m_gateOpen = false;
   }

   public void Toggle()
   {
      if (m_gateOpen)
      {
         m_gateOpen = false;
      }
      else
      {
         m_gateOpen = true;
      }
   }

}