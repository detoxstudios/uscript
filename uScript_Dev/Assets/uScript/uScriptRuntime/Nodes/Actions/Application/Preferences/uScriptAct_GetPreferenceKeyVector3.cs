// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Preference Key (Vector3)", "Returns the value of the specified Key from the preference file if it exists.")]
public class uScriptAct_GetPreferenceKeyVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name", "The name of the preference key you wish to get the value for.")]
      string KeyName,

      [FriendlyName("Default Value", "(optional) Allows you to specify a value to return if the actual value is not found. Will return (0,0,0) if not specified.")]
      Vector3 DefaultValue,

      [FriendlyName("Value", "The returned key value.")]
      out Vector3 Value
      )
   {
      string stringValue = PlayerPrefs.GetString(KeyName);
		string[] values = stringValue.Split('|');
		
	    if (values.Length != 3)
		{
			uScriptDebug.Log("The specified Preference Key was not found or not of type Vector3!", uScriptDebug.Type.Warning );
			
			// Return empty Vector3
			Value = DefaultValue;
		}
		else
		{
		   float Value_X = 0F;
		   float Value_Y = 0F;
		   float Value_Z = 0F;
		
		   int counter = 0;
		   foreach (string componentValue in values)
		   {
		      if (counter == 0) { Value_X = float.Parse(componentValue); }
		      if (counter == 1) { Value_Y = float.Parse(componentValue); }
		      if (counter == 2) { Value_Z = float.Parse(componentValue); }
				
			  counter++;
		   }

           // Return the Vector3
           Value = new Vector3(Value_X, Value_Y, Value_Z);
			
		}

   }
}