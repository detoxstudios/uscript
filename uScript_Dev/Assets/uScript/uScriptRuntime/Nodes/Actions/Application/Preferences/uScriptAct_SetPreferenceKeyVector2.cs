// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the value of the specified Key from the preference.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of the specified Key from the preference.")]
[NodeDescription("Sets the value of the specified Key from the preference.\n\nKey Name: The name of the preference key you wish to set the value for.\nValue: The new value of the key.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Set Preference Key (Vector2)")]
public class uScriptAct_SetPreferenceKeyVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName,
      [FriendlyName("Value")] Vector2 Value)
   {

      // Break out the Vector components
      float Value_X = Value.x;
      float Value_Y = Value.y;
      
      // Set X component
      string KeyName_X = KeyName + "_uSV2C_X";
      PlayerPrefs.SetFloat(KeyName_X, Value_X);

      // Set Y component
      string KeyName_Y = KeyName + "_uSV2C_Y";
      PlayerPrefs.SetFloat(KeyName_Y, Value_Y);

   }
}