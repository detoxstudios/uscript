// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Increments the first attached integer variable and then performs a comparison with
//       the second attached integer variable and fires the appropriate output link based on
//       that comparison.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Counter")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Increments the first attached integer variable and then performs a comparison with the second attached integer variable and fires the appropriate output link based on that comparison.")]
[NodeDescription("Increments the first attached integer variable and then performs a comparison with the second attached integer variable and fires the appropriate output link based on that comparison.\n \nA: Variable to increment.\nB: Variable to compare with incremented variable.\nCurrent Value: Value of A after increment has taken place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Int_Counter")]

[FriendlyName("Int Counter")]
public class uScriptCon_IntCounter : uScriptLogic
{
   private int m_IntTotal;
   private bool m_InitialPulse = true;

   private bool m_GreaterThan = false;
   private bool m_GreaterThanOrEqualTo = false;
   private bool m_EqualTo = false;
   private bool m_LessThanOrEqualTo = false;
   private bool m_LessThan = false;

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

   public void In(int A, int B, [FriendlyName("Current Value")] out int currentValue)
   {
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;

      if (m_InitialPulse)
      {
         m_IntTotal = A;
         m_InitialPulse = false;
      }

      m_IntTotal++;
      currentValue = m_IntTotal;

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
	}
		
    public void Reset(int A, int B, [FriendlyName("Current Value")] out int currentValue)
    {
	  m_InitialPulse = true;
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;
	  currentValue = A;

    }
	
}