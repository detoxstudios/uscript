// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current graphics quality level.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Quality Level", "Returns the current graphics quality level.")]
public class uScriptAct_QualitySettingsGetLevel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Names", "Returns the names of the available Quality Settings as a string list.")] out int qualityLevel)
   {
      qualityLevel = QualitySettings.GetQualityLevel();
   }
}