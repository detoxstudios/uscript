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

[FriendlyName("Set Preference Key (Rect)")]
public class uScriptAct_SetPreferenceKeyRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName,
      [FriendlyName("Value")] Rect Value)
   {

      // Break out the Vector components
      float Value_X = Value.xMin;
      float Value_Y = Value.yMin;
      float Value_Z = Value.width;
      float Value_W = Value.height;
      
      // Set X component
      string KeyName_X = KeyName + "_uSRC_X";
      PlayerPrefs.SetFloat(KeyName_X, Value_X);

      // Set Y component
      string KeyName_Y = KeyName + "_uSRC_Y";
      PlayerPrefs.SetFloat(KeyName_Y, Value_Y);

      // Set Z component
      string KeyName_Z = KeyName + "_uSRC_Z";
      PlayerPrefs.SetFloat(KeyName_Z, Value_Z);

      // Set W component
      string KeyName_W = KeyName + "_uSRC_Z";
      PlayerPrefs.SetFloat(KeyName_W, Value_W);

   }
}