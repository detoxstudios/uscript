// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Anisotropic Filtering Mode from the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Anisotropic Filtering Mode", "Gets the Anisotropic Filtering Mode from the current Quality Settings.")]
public class uScriptAct_QualitySettingsGetAnisotropicFiltering : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The current value for this quality setting level.")] out AnisotropicFiltering Value)
   {
      Value = QualitySettings.anisotropicFiltering;
   }
}