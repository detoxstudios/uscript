// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Blend Weights from the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Blend Weights", "Gets the Blend Weights setting from the current Quality Settings.")]
public class uScriptAct_QualitySettingsGetBlendWeights : uScriptLogic
{
   public bool Out { get { return true; } }

#if UNITY_2019
   public void In([FriendlyName("Value", "The current value for this quality setting level.")] out SkinWeights Value)
   {
      Value = QualitySettings.skinWeights;
   }
#else
   public void In([FriendlyName("Value", "The current value for this quality setting level.")] out BlendWeights Value)
   {
      Value = QualitySettings.blendWeights;
   }
#endif
}
