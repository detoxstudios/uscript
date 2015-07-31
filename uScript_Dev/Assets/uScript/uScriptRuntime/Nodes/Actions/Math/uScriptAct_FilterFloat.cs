// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any float and outputs a low-pass filtered version.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Filter Float", "Takes any float and outputs a low-pass filtered version.")]
public class uScriptAct_FilterFloat : uScriptLogic
{
   private float m_PreviousValue = 0.0f;
   

   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Filter()
   public void Reset(float Target, float FilterConstant, out float Value)
   {
      m_PreviousValue = Value = Target;
   }

   public void Filter(
      [FriendlyName("Target", "Value to filter.")]
      float Target,

      [FriendlyName("Filter Constant", "The strength of the filter (lower numbers mean more filtering, i.e. slower - default value = 0.1).")]
      [DefaultValue(0.1f)]
      float FilterConstant,

      [FriendlyName("Value", "Filtered value.")]
      out float Value
      )
   {
      m_PreviousValue = Value = (Target * FilterConstant) + (m_PreviousValue * (1.0f - FilterConstant));
      
      if (Mathf.Abs(m_PreviousValue - Target) < 0.001)
      {
         // if we're close enough, lock it to the target value
         m_PreviousValue = Value = Target;
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}