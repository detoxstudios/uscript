// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if the Target float is between a minimum and maximum range.")]
[NodeAuthor("Detox Studios LLC. Original node by SvdV on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Between Floats", "Checks to see if the Target float is between a minimum and maximum range.")]
public class uScriptCon_BetweenFloats : uScriptLogic
{
   private bool m_Between = false;

   public bool True { get { return m_Between; } }
   public bool False { get { return !m_Between; } }

   public void In(
      [FriendlyName("Target", "The target float variable to compare against the range.")] float Target,
      [FriendlyName("Min", "The minimum value of the range. This value is inclusive.")] float Min,
      [FriendlyName("Max", "The maximum value of the range. This value is inclusive.")] float Max)
   {

      if (Min > Max || Min == Max)
      {
         m_Between = false;
      }
      else
      {
         if (Target >= Min && Target <= Max)
         {
            m_Between = true;
         }
         else
         {
            m_Between = false;
         }
      }
		
   }
}