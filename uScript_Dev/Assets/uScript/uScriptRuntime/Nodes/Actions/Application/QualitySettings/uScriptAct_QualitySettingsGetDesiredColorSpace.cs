// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Desired Color Space from the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Desired Color Space", "Gets the Desired Color Space setting from the current Quality Settings.")]
public class uScriptAct_QualitySettingsGetDesiredColorSpace : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The current value for this quality setting level.")] out ColorSpace Value)
   {
      Value = QualitySettings.desiredColorSpace;
   }
}