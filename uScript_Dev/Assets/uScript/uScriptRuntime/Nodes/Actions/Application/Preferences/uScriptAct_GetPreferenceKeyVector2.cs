// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Preference Key (Vector2)", "Returns the value of the specified Key from the preference file if it exists.")]
public class uScriptAct_GetPreferenceKeyVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name", "The name of the preference key you wish to get the value for.")]
      string KeyName,

      [FriendlyName("Default Value", "(optional) Allows you to specify a value to return if the actual value is not found. Will return (0,0) if not specified.")]
      Vector2 DefaultValue,

      [FriendlyName("Value", "The returned key value.")]
      out Vector2 Value
      )
   {
      string stringValue = PlayerPrefs.GetString(KeyName);
		string[] values = stringValue.Split('|');
		
	    if (values.Length != 2)
		{
			uScriptDebug.Log("The specified Preference Key was not found or not of type Vector2!", uScriptDebug.Type.Warning );
			
			// Return empty Vector2
			Value = DefaultValue;
		}
		else
		{
		   float Value_X = 0F;
		   float Value_Y = 0F;
		
		   int counter = 0;
		   foreach (string componentValue in values)
		   {
		      if (counter == 0) { Value_X = float.Parse(componentValue); }
		      if (counter == 1) { Value_Y = float.Parse(componentValue); }
				
			  counter++;
		   }

           // Return the Vector2
           Value = new Vector2(Value_X, Value_Y);
			
		}

   }
}