// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current graphics quality level.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Quality Level", "Returns the current graphics quality level.")]
public class uScriptAct_QualitySettingsGetLevel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Names", "Returns the names of the available Quality Settings as a string list.")] out int qualityLevel)
   {
      qualityLevel = QualitySettings.GetQualityLevel();
   }
}
#endif