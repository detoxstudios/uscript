// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Blend Weights on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Blend Weights", "Sets the Blend Weights on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetBlendWeights : uScriptLogic
{
   public bool Out { get { return true; } }

#if UNITY_2019
   public void In([FriendlyName("Value", "The value to set on this quality setting.")] SkinWeights Value)
   {
      QualitySettings.skinWeights = Value;
   }
#else
    public void In([FriendlyName("Value", "The value to set on this quality setting.")] BlendWeights Value)
   {
      QualitySettings.blendWeights = Value;
   }
#endif
}