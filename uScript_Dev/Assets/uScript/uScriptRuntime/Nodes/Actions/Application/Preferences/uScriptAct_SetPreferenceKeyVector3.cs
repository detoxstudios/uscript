// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of the specified Key from the preference.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Preference Key (Vector3)", "Sets the value of the specified Key from the preference.")]
public class uScriptAct_SetPreferenceKeyVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name", "The name of the preference key you wish to set the value for.")]
      string KeyName,

      [FriendlyName("Value", "The new value of the key.")]
      Vector3 Value
      )
   {

      // Break out the Vector components
      float Value_X = Value.x;
      float Value_Y = Value.y;
      float Value_Z = Value.z;
      
      string stringValue = Value_X.ToString() + "|" + Value_Y.ToString() + "|" + Value_Z.ToString();
		
	  PlayerPrefs.SetString(KeyName, stringValue);

   }
}
