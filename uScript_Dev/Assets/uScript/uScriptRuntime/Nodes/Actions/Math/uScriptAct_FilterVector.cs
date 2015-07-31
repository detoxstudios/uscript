// uScript Action Node
// (C) 2010 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes any Vector3 or Vector4 and outputs a low-pass filtered version.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Filter Vector", "Takes any Vector3 or Vector4 and outputs a low-pass filtered version.")]
public class uScriptAct_FilterVector : uScriptLogic
{
   private Vector4 m_PreviousValue = Vector4.zero;


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
   public void Reset(object Target, float FilterConstant, out Vector3 Value3, out Vector4 Value4)
   {
      if (typeof(Vector3) == Target.GetType())
      {
         Value3 = m_PreviousValue = Value4 = (Vector3)Target;
      }
      else if (typeof(Vector4) == Target.GetType())
      {
         Value3 = m_PreviousValue = Value4 = (Vector4)Target;
      }
      else
      {
         Value3 = Vector3.zero;
         Value4 = Vector4.zero;
         uScriptDebug.Log("Invalid Target for Filter Vector node Reset() - must be a Vector3 or Vector4", uScriptDebug.Type.Warning);
      }
   }

   public void Filter(
      [FriendlyName("Target", "Value to filter.")]
      object Target,

      [FriendlyName("Filter Constant", "The strength of the filter (lower numbers mean more filtering, i.e. slower - default value = 0.1).")]
      [DefaultValue(0.1f)]
      float FilterConstant,

      [FriendlyName("Value3", "Filtered value.")]
      out Vector3 Value3,

      [FriendlyName("Value4", "Filtered value.")]
      out Vector4 Value4
      )
   {
      if (typeof(Vector3) == Target.GetType() || typeof(Vector4) == Target.GetType())
      {
         Vector4 v4;
         if (typeof(Vector3) == Target.GetType())
         {
            v4 = (Vector4)(Vector3)Target;
         }
         else
         {
            v4 = (Vector4)Target;
         }
         Value3 = m_PreviousValue = Value4 = (v4 * FilterConstant) + (m_PreviousValue * (1.0f - FilterConstant));
         
         if ((m_PreviousValue - v4) == Vector4.zero)
         {
            // if we're close enough (vector4.operator == reports true for vectors that are very close 
            // as well as actually equal), lock it to the target value
            Value3 = m_PreviousValue = Value4 = v4;
         }
      }
      else
      {
         Value3 = Vector3.zero;
         Value4 = Vector4.zero;
         uScriptDebug.Log("Invalid Target for Filter Vector node Filter() - must be a Vector3 or Vector4", uScriptDebug.Type.Warning);
      }

   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}

#endif