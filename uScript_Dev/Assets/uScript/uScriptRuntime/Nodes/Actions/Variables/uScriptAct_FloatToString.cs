// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a float to a string with the abiliy to limit the decimal places.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Float")]

[FriendlyName("Float To String", "Converts a float to a string with the abiliy to limit the decimal places.")]
public class uScriptAct_FloatToString : uScriptLogic
{
   public bool Out { get { return true; } }
	
	public enum m_DecimalPlaces { All, None, One, Two, Three };

   public void In(
	               [FriendlyName("Target", "The float you wish to convert to a string.")] float Target,
	               [FriendlyName("Decimals", "The number of decimal places you want to maintain in the conversion. Note that if the float value has less decimal places, only those that exist will be shown.")] m_DecimalPlaces DecimalPlaces,
	               [FriendlyName("Result", "The Target string variable to contain the resulting conversion.")] out string Result)
   {
		if (DecimalPlaces == m_DecimalPlaces.All)
		{
			Result = Target.ToString();
		}
		else if (DecimalPlaces == m_DecimalPlaces.None)
		{
			Result = Target.ToString("#");
		}
		else if (DecimalPlaces == m_DecimalPlaces.One)
		{
			Result = Target.ToString("#.#");
		}
		else if (DecimalPlaces == m_DecimalPlaces.Two)
		{
			Result = Target.ToString("#.##");
		}
		else if (DecimalPlaces == m_DecimalPlaces.Three)
		{
			Result = Target.ToString("#.###");
		}
		else
		{
			Result = Target.ToString();
		}
		
      
   }
}