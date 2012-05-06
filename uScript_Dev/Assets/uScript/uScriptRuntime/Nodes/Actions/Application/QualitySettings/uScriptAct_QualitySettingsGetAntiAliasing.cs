// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_4 || UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Anti-aliasing from the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Anti-aliasing", "Gets the Anti-aliasing setting from the current Quality Settings.")]
public class uScriptAct_QualitySettingsGetAntiAliasing : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The current value for this quality setting level.")] out int Value)
   {
      Value = QualitySettings.antiAliasing;
   }
}
#endif