// uScript Action Node
// (C) 2011 Detox Studios LLC
#if UNITY_3_4 || UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Writes all modified preferences to the device's storage/disk.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Save Preferences", "Writes all modified preferences to the device's storage/disk. Unity will automatically save preferences from memory to the device on quiting the application. Only use this if you wish to force Unity to save preferences to the device at other specified times while your product is running. This may cause a performance stall while saving the preferences.")]
public class uScriptAct_SavePreferences : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In( )
   {
      PlayerPrefs.Save();
   }
}
#endif
