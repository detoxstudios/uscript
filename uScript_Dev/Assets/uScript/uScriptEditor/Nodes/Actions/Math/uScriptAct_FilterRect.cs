// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any Rect and outputs a low-pass filtered version.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any Rect and outputs a low-pass filtered version.")]
[NodeDescription("Takes any Rect and outputs a low-pass filtered version.\n \nTarget: Value to filter.\nFilter Constant: The strength of the filter (lower numbers mean more filtering, i.e. slower - default value = 0.1).\nValue (out): Filtered value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Filter_Rect")]

[FriendlyName("Filter Rect")]
public class uScriptAct_FilterRect : uScriptLogic
{
   private Rect m_PreviousValue = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
   
   public bool Out { get { return true; } }

   public void Reset(Rect Target, [FriendlyName("Filter Constant"), DefaultValue(0.1f)]float FilterConstant, out Rect Value)
   {
      Value = m_PreviousValue = Target;
   }

   public void Filter(Rect Target, [FriendlyName("Filter Constant"), DefaultValue(0.1f)]float FilterConstant, out Rect Value)
   {
      float x = m_PreviousValue.x = (Target.x * FilterConstant) + (m_PreviousValue.x * (1.0f - FilterConstant));
      float y = m_PreviousValue.y = (Target.y * FilterConstant) + (m_PreviousValue.y * (1.0f - FilterConstant));
      float width = m_PreviousValue.width = (Target.width * FilterConstant) + (m_PreviousValue.width * (1.0f - FilterConstant));
      float height = m_PreviousValue.height = (Target.height * FilterConstant) + (m_PreviousValue.height * (1.0f - FilterConstant));
      Value = new Rect(x, y, width, height);
      
      if (Mathf.Abs(m_PreviousValue.x - Target.x) < 0.001
       && Mathf.Abs(m_PreviousValue.y - Target.y) < 0.001
       && Mathf.Abs(m_PreviousValue.width - Target.width) < 0.001 
       && Mathf.Abs(m_PreviousValue.height - Target.height) < 0.001)
      {
         // if we're close enough, lock it to the target value
         m_PreviousValue = Value = Target;
      }
   }
}