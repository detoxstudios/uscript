// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the specified Key from the preference file if it exists.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Preference Key (Int)", "Returns the value of the specified Key from the preference file if it exists.")]
public class uScriptAct_GetPreferenceKeyInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name", "The name of the preference key you wish to get the value for.")]
      string KeyName,

      [FriendlyName("Default Value", "(optional) Allows you to specify a value to return if the actual value is not found. Will return 0 if not specified.")]
      [DefaultValue(0)]
      int DefaultValue,

      [FriendlyName("Value", "The returned key value.")]
      out int Value
      )
   {
      Value = PlayerPrefs.GetInt(KeyName, DefaultValue);
   }
}
