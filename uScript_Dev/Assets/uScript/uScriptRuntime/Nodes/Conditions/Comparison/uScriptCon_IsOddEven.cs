using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[FriendlyName("Is Odd or Even", "Determines if the target Int is odd or even.")]
public class uScriptCon_IsOddEven : uScriptLogic
{

   private bool m_IsOe = false;

   [FriendlyName("Even")]
   public bool True { get { return m_IsOe; } }

   [FriendlyName("Odd")]
   public bool False { get { return !m_IsOe; } }
    
   public void In(
      [FriendlyName("Target", "The integer variable to test.")]
      int Target
      )
   {

  if (Target % 2 ==0) {
      	m_IsOe = true;
		}
  else
		{
		m_IsOe = false;
		}

   }

}
