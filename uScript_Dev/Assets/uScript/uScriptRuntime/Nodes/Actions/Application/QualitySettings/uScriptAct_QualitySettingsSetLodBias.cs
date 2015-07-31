// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the LOD Bias on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set LOD Bias", "Sets the LOD Bias on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetLodBias : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set on this quality setting. A larger value leads to a longer view distance before a lower resolution LOD is picked.")] float Value)
   {
      QualitySettings.lodBias = Value;
   }
}