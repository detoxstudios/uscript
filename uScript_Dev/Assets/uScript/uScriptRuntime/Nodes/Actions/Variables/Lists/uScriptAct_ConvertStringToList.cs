// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a string into int, float and string lists.")]
[NodeAuthor("Detox Studios LLC. Original node by John on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]


[FriendlyName("Convert String to List", "Converts a string into int, float and string lists dependent on the content of the input string.\n\nFor example, the input string 'apple,orange,27,1.66' will output a string list containing all four items, a float list containing two items (27, 1.66) and an int list with a single item (27).\n\nYou can opt to preserve the length of the lists and a padding value (0 unless you specify otherwise) will be insertedwhere an appropriate value isn't in the original string.\n\nIn the example above this would mean that the float list would be (0,0,27,1.66) and the int list (0,0,27,0)\n\nInput: A string with each item separated by a comma.")]
public class uScriptAct_ConvertStringToList : uScriptLogic
{
	public bool Out { get { return true; } }

   public void In([FriendlyName("Target", "A string variable containing the comma delimited text to create the lists from (each item is separated with a comma character).")]string Target,
      [FriendlyName("Preserve Length", "Used for the float and int output lists. If set to true, a padding value (0 unless you specify otherwise) will be inserted into lists where an appropriate value isn't in the original string."), DefaultValue(true), SocketState(false, false)] ref bool preserveLength,
      [FriendlyName("Padding Value", "Used with Preserve Length. If a float value is used, it will be truncated for the int list."), DefaultValue(0), SocketState(false, false)] ref float paddingValue,
      [FriendlyName("String Count", "Number of items in the output string list."), SocketState(false, false)] out int stringCount,
      [FriendlyName("Int Count", "Number of items in the output int list."), SocketState(false, false)] out int intCount,
      [FriendlyName("Float Count", "Number of items in the output float list."), SocketState(false, false)] out int floatCount,
      [FriendlyName("String List", "A string list variable containing each item from the Target string.")] out string[] theString,
      [FriendlyName("Int List", "A int list variable containing any ints from the Target string."), SocketState(false, false)] out int[] theIntList,
      [FriendlyName("Float List", "A float list variable containing any floats from the Target string.")] out float[] theFloatList
      )
	{
   	
		theString = Target.Split(',');
		string[] tempString = theString;
		stringCount = theString.Length;
		int anInt;
		float aFloat;
		int intPad = (int) paddingValue;
				   
		List<int> tempIntList = new List<int>();
		List<float> tempFloatList = new List<float>();
		
		if (preserveLength)
		{
   		   	foreach (string item in tempString)
			{
				if (int.TryParse(item, out anInt))
				{
					tempIntList.Add(anInt);
				}
				else 
				{
					tempIntList.Add(intPad);
				}
				
				if (float.TryParse(item, out aFloat))
				{
					tempFloatList.Add(aFloat);
				} 
				else 
				{
					tempFloatList.Add(paddingValue);
				}
				
	   	   	}
   	   		
			theIntList = tempIntList.ToArray();
   	   		theFloatList = tempFloatList.ToArray();
		
			intCount = theIntList.Length;
			floatCount = theFloatList.Length;
		} 
		else 
		{
			foreach (string item in tempString)
			{
				if (int.TryParse(item, out anInt))
				{
					tempIntList.Add(anInt);
				}
				
				if (float.TryParse(item, out aFloat))
				{
					tempFloatList.Add(aFloat);
				}
	   	   	}
   	   		
			theIntList = tempIntList.ToArray();
   	   		theFloatList = tempFloatList.ToArray();
			
			intCount = theIntList.Length;
			floatCount = theFloatList.Length;
		}	
   	}
}
