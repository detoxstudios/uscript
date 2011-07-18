// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the value of the specified Key from the preference file if it exists.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeDescription("Returns the value of the specified Key from the preference file if it exists.\n\nKey Name: The name of the preference key you wish to get the value for.\nDefault Value: Optional. Allows you to specify a value to return if the actual value is not found. Will return 0 if not specified.\nValue: The returned key value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Get Preference Key (Float)")]
public class uScriptAct_GetPreferenceKeyFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName,
      [FriendlyName("Default Value"), DefaultValue(0f)] float DefaultValue,
      [FriendlyName("Value")] out float Value)
   {
      Value = PlayerPrefs.GetFloat(KeyName, DefaultValue);
   }
}