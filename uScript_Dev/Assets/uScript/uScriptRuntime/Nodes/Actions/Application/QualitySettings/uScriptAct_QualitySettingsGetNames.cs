// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the names of the available Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Quality Names", "Gets the names of the available Quality Settings.")]
public class uScriptAct_QualitySettingsGetNames : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Names", "Returns the names of the available Quality Settings as a string list.")] out string[] qualityNames)
   {
      qualityNames = QualitySettings.names;
   }
}