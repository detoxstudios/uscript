// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the value of the specified Key from the preference file if it exists.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeDescription("Returns the value of the specified Key from the preference file if it exists.\n\nKey Name: The name of the preference key you wish to get the value for.\nDefault Value: Optional. Allows you to specify a value to return if the actual value is not found. Will return (0,0,0,0) if not specified.\nValue: The returned key value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Get Preference Key (Vector4)")]
public class uScriptAct_GetPreferenceKeyVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName,
      [FriendlyName("Default Value")] Vector4 DefaultValue,
      [FriendlyName("Value")] out Vector4 Value)
   {
      // Get X component
      string KeyName_X = KeyName + "_uSV4C_X";
      float DefaultValue_X = DefaultValue.x;
      float Value_X = PlayerPrefs.GetFloat(KeyName_X, DefaultValue_X);

      // Get Y component
      string KeyName_Y = KeyName + "_uSV4C_Y";
      float DefaultValue_Y = DefaultValue.y;
      float Value_Y = PlayerPrefs.GetFloat(KeyName_Y, DefaultValue_Y);

      // Get Z component
      string KeyName_Z = KeyName + "_uSV4C_Z";
      float DefaultValue_Z = DefaultValue.z;
      float Value_Z = PlayerPrefs.GetFloat(KeyName_Z, DefaultValue_Z);

      // Get W component
      string KeyName_W = KeyName + "_uSV4C_W";
      float DefaultValue_W = DefaultValue.w;
      float Value_W = PlayerPrefs.GetFloat(KeyName_W, DefaultValue_W);

      // Return the Vector4 from all the components;
      Value = new Vector4(Value_X, Value_Y, Value_Z, Value_W);

   }
}