// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if the target variable is empty/null.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is Empty", "Checks to see if the target variable is empty/null. If more than one variable is hooked up to the Target socket, it will only return Not Empty if all the provided targets are not empty.")]
public class uScriptCon_IsEmpty : uScriptLogic
{
   private bool m_Empty = false;
   private bool m_NotEmpty = false;

   [FriendlyName("Empty")]
   public bool Empty { get { return m_Empty; } }
   [FriendlyName("Not Empty")]
   public bool NotEmpty { get { return m_NotEmpty; } }
    
   public void In(
      [FriendlyName("Target", "The variable(s) you wish to check.")]
      object[] Targets
      )
   {
		m_NotEmpty = false;
		m_Empty = false;
		
		bool nullFound = false;
		
		foreach ( object obj in Targets )
		{
			
			if ( null == obj )
			{
				nullFound = true;
				break;
				//fix
			}
			
		}
		
		// Fire out the correct output socket
		if ( nullFound )
		{
			m_Empty = true;
		}
		else
		{
			m_NotEmpty = true;
		}
      
   }
}
