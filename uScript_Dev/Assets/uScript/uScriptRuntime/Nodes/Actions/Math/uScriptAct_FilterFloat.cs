// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any float and outputs a low-pass filtered version.")]
/* M */[NodeDescription("Takes any float and outputs a low-pass filtered version.\n \nTarget: Value to filter.\nFilter Constant: The strength of the filter (lower numbers mean more filtering, i.e. slower - default value = 0.1).\nValue (out): Filtered value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Filter_Float")]

[FriendlyName("Filter Float")]
public class uScriptAct_FilterFloat : uScriptLogic
{
   private float m_PreviousValue = 0.0f;
   
   public bool Out { get { return true; } }

   public void Reset(float Target, [FriendlyName("Filter Constant"), DefaultValue(0.1f)]float FilterConstant, out float Value)
   {
      m_PreviousValue = Value = Target;
   }

   public void Filter(float Target, [FriendlyName("Filter Constant"), DefaultValue(0.1f)]float FilterConstant, out float Value)
   {
      m_PreviousValue = Value = (Target * FilterConstant) + (m_PreviousValue * (1.0f - FilterConstant));
      
      if (Mathf.Abs(m_PreviousValue - Target) < 0.001)
      {
         // if we're close enough, lock it to the target value
         m_PreviousValue = Value = Target;
      }
   }
}