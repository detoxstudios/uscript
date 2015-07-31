// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Soft Vegetation on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Soft Vegetation", "Sets the Soft Vegetation on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetSoftVegetation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set on this quality setting. If enabled, vegetation will have smoothed edges, if disabled all plants will have hard edges but are rendered roughly twice as fast.")] bool Value)
   {
      QualitySettings.softVegetation = Value;
   }
}