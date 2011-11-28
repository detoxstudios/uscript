// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Allows the signal to pass through to the Out link depending on the state of the gate.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Gates")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows the signal to pass through to the Out link depending on the state of the gate.")]
/* M */[NodeDescription("Allows the signal to pass through to the Out link depending on the state of the gate.\n\nStart Open (in): If checked, the gate will be open initially.\nAuto Close Count (in): Allows you to specify how many signals the gate will pass through before it closes automatically. This value is re-checked and reset when the gate recieves a signal to the Open or Toggle signal sockets.\nIs Open (out): Sets a Boolean variable to true when the gate is open and false when it is closed. Note: This will always return False if accessed before the gate has recieved a signal.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Gate")]

[FriendlyName("Gate")]
public class uScriptCon_Gate : uScriptLogic
{
   private bool m_GateOpen = false;
   private int m_AutoCloseCount = 0;
   bool m_UseSignalCount = false;
   bool m_UseStartOpen = true;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;


   public void In(
      [FriendlyName("Start Open"), DefaultValue(false), SocketState(false, false)] bool StartOpen,
      [FriendlyName("Auto Close Count"), DefaultValue(false), SocketState(false, false)] int AutoCloseCount,
      [FriendlyName("Is Open"), SocketState(false, false)] out bool IsOpen
      )
   {
      // Initially open the Gate if OpenGate is true.
      if (StartOpen && m_UseStartOpen)
      {
         m_GateOpen = true;
         IsOpen = m_GateOpen;
      }
      m_UseStartOpen = false;


      // Decided if AutoCloseCount should be used by the gate.
      if (AutoCloseCount > 0 && !m_UseSignalCount)
      {
         m_UseSignalCount = true;
         m_AutoCloseCount = AutoCloseCount;
      }
      else if (AutoCloseCount <= 0)
      {
         m_UseSignalCount = false;
         m_AutoCloseCount = 0;
      }

      // Run the gate logic.
      if (m_GateOpen)
      {
         if (m_UseSignalCount)
         {
            if (m_AutoCloseCount > 0)
            {
               m_AutoCloseCount = m_AutoCloseCount - 1;
               if (Out != null) Out(this, new System.EventArgs());
               // Set to false now if needed so the value is correct on this run if it is now 0
               if (m_AutoCloseCount <= 0) { m_GateOpen = false; }
            }
            else
            {
               m_GateOpen = false;
            }

         }
         else
         {
            if (Out != null) Out(this, new System.EventArgs());
         }

      }

      // Update IsOpen with the current Gate state.
      IsOpen = m_GateOpen;

   }


   public void Open(
      [FriendlyName("Start Open"), DefaultValue(false), SocketState(false, false)] bool StartOpen,
      [FriendlyName("Auto Close Count"), DefaultValue(false), SocketState(false, false)] int AutoCloseCount,
      [FriendlyName("Is Open"), SocketState(false, false)] out bool IsOpen
      )
   {

      m_GateOpen = true;
      IsOpen = m_GateOpen;

      // Decided if AutoCloseCount should be used by the gate.
      if (AutoCloseCount > 0)
      {
         m_UseSignalCount = true;
         m_AutoCloseCount = AutoCloseCount;
      }
      else if (AutoCloseCount == 0)
      {
         m_UseSignalCount = false;
         m_AutoCloseCount = AutoCloseCount;
      }

   }


   public void Close(
      [FriendlyName("Start Open"), DefaultValue(false), SocketState(false, false)] bool StartOpen,
      [FriendlyName("Auto Close Count"), DefaultValue(false), SocketState(false, false)] int AutoCloseCount,
      [FriendlyName("Is Open"), SocketState(false, false)] out bool IsOpen
      )
   {
      m_GateOpen = false;
      IsOpen = m_GateOpen;
   }


   public void Toggle(
      [FriendlyName("Start Open"), DefaultValue(false), SocketState(false, false)] bool StartOpen,
      [FriendlyName("Auto Close Count"), DefaultValue(false), SocketState(false, false)] int AutoCloseCount,
      [FriendlyName("Is Open"), SocketState(false, false)] out bool IsOpen
      )
   {
      m_GateOpen = !m_GateOpen;
      IsOpen = m_GateOpen;

      // Decided if AutoCloseCount should be used by the gate if the toggle opened the gate.
      if (m_GateOpen)
      {
         if (AutoCloseCount > 0)
         {
            m_UseSignalCount = true;
            m_AutoCloseCount = AutoCloseCount;
         }
         else if (AutoCloseCount == 0)
         {
            m_UseSignalCount = false;
            m_AutoCloseCount = AutoCloseCount;
         }
      }
   }

}