// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Blend Weights on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Blend Weights", "Sets the Blend Weights on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetBlendWeights : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set on this quality setting.")] BlendWeights Value)
   {
      QualitySettings.blendWeights = Value;
   }
}
#endif