// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the value of the specified Key from the preference file if it exists.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeDescription("Returns the value of the specified Key from the preference file if it exists.\n\nKey Name: The name of the preference key you wish to get the value for.\nDefault Value: Optional. Allows you to specify a value to return if the actual value is not found. Will return (0,0) if not specified.\nValue: The returned key value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Get Preference Key (Vector2)")]
public class uScriptAct_GetPreferenceKeyVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName,
      [FriendlyName("Default Value")] Vector2 DefaultValue,
      [FriendlyName("Value")] out Vector2 Value)
   {
      // Get X component
      string KeyName_X = KeyName + "_uSV2C_X";
      float DefaultValue_X = DefaultValue.x;
      float Value_X = PlayerPrefs.GetFloat(KeyName_X, DefaultValue_X);

      // Get Y component
      string KeyName_Y = KeyName + "_uSV2C_Y";
      float DefaultValue_Y = DefaultValue.y;
      float Value_Y = PlayerPrefs.GetFloat(KeyName_Y, DefaultValue_Y);

      // Return the Vector2 from all the components;
      Value = new Vector2(Value_X, Value_Y);

   }
}