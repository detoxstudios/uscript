// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of the specified Key from the preference.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Preference Key (Vector2)", "Sets the value of the specified Key from the preference.")]
public class uScriptAct_SetPreferenceKeyVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name", "The name of the preference key you wish to set the value for.")]
      string KeyName,

      [FriendlyName("Value", "The new value of the key.")]
      Vector2 Value
      )
   {

      // Break out the Vector components
      float Value_X = Value.x;
      float Value_Y = Value.y;
      
      string stringValue = Value_X.ToString() + "|" + Value_Y.ToString();
		
	  PlayerPrefs.SetString(KeyName, stringValue);

   }
}