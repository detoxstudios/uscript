// uScript Action Node
// (C) 2016 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Counter")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares (A) to (B), fires the appropriate output signal, then decrements (A) by 1 and outputs the results to 'Current Value'.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Int Counter (Down)", "Compares (A) to (B), fires the appropriate output signal, then decrements (A) by 1 and outputs the results to 'Current Value'.")]
public class uScriptCon_IntCounterDown : uScriptLogic
{
   private int m_IntTotal;
   private bool m_InitialPulse = true;

   private bool m_GreaterThan = false;
   private bool m_GreaterThanOrEqualTo = false;
   private bool m_EqualTo = false;
   private bool m_LessThanOrEqualTo = false;
   private bool m_LessThan = false;
   private bool m_StopAtZero = false;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   [FriendlyName("(Greater Than)   >")]
   public bool GreaterThan { get { return m_GreaterThan; } }

   [FriendlyName("(Greater Than or Equal To) >=")]
   public bool GreaterThanOrEqualTo { get { return m_GreaterThanOrEqualTo; } }

   [FriendlyName("(Equal To)   =")]
   public bool EqualTo { get { return m_EqualTo; } }

   [FriendlyName("(Less Than or Equal To) <=")]
   public bool LessThanOrEqualTo { get { return m_LessThanOrEqualTo; } }

   [FriendlyName("(Less Than)   <")]
   public bool LessThan { get { return m_LessThan; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Reset()
   public void In(int A, int B, bool StopAtZero, out int currentValue)
   {
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;
      m_StopAtZero = StopAtZero;

      if (m_InitialPulse)
      {
         m_IntTotal = A;
         m_InitialPulse = false;
      }

      

      if (m_IntTotal > B)
      {
         m_GreaterThan = true;
      }

      if (m_IntTotal >= B)
      {
         m_GreaterThanOrEqualTo = true;
      }

      if (m_IntTotal == B)
      {
         m_EqualTo = true;
      }

      if (m_IntTotal <= B)
      {
         m_LessThanOrEqualTo = true;
      }

      if (m_IntTotal < B)
      {
         m_LessThan = true;
      }

      if(!m_StopAtZero || m_StopAtZero == true && m_IntTotal > 0)
      {
         m_IntTotal--;
      }
      currentValue = m_IntTotal;
   }
		
   public void Reset(
      [FriendlyName("A", "Variable to compare, then decrement.")]
      int A,

      [FriendlyName("B", "Variable to compare against.")]
      int B,

      [FriendlyName("Stop At Zero", "Once A has reached zero, stop subtracting further.")]
      [SocketState(false, false)]
      bool StopAtZero,

      [FriendlyName("Current Value", "Value of A after decrementing has taken place.")]
      out int currentValue
      )
   {
      m_InitialPulse = true;
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;
      currentValue = A;
      m_StopAtZero = StopAtZero;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
