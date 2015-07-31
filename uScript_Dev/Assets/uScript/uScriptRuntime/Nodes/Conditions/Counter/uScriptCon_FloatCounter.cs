// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Counter")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output link based on that comparison.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Float Counter", "Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output link based on that comparison.")]
public class uScriptCon_FloatCounter : uScriptLogic
{
   private float m_FloatTotal;
   private bool m_InitialPulse = true;

   private bool m_GreaterThan = false;
   private bool m_GreaterThanOrEqualTo = false;
   private bool m_EqualTo = false;
   private bool m_LessThanOrEqualTo = false;
   private bool m_LessThan = false;


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
   // Parameter Attributes are applied below in Filter()
   public void In(float A, float B, out float currentValue)
   {
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;

      if (m_InitialPulse)
      {
         m_FloatTotal = A;
         m_InitialPulse = false;
      }

      m_FloatTotal++;
      currentValue = m_FloatTotal;

      if (m_FloatTotal > B)
      {
         m_GreaterThan = true;
      }

      if (m_FloatTotal >= B)
      {
         m_GreaterThanOrEqualTo = true;
      }

      if (m_FloatTotal == B)
      {
         m_EqualTo = true;
      }

      if (m_FloatTotal <= B)
      {
         m_LessThanOrEqualTo = true;
      }

      if (m_FloatTotal < B)
      {
         m_LessThan = true;
      }
   }
	
   public void Reset(
      [FriendlyName("A", "Variable to increment.")]
      float A,

      [FriendlyName("B", "Variable to compare with incremented variable.")]
      float B,

      [FriendlyName("Current Value", "Value of A after increment has taken place.")]
      out float currentValue
      )
   {
      m_InitialPulse = true;
      m_GreaterThan = false;
      m_GreaterThanOrEqualTo = false;
      m_EqualTo = false;
      m_LessThanOrEqualTo = false;
      m_LessThan = false;
      currentValue = A;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
