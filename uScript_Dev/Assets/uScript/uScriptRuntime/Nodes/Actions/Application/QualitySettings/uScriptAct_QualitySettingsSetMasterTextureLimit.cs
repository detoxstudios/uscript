// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Master Texture Limit on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Master Texture Limit", "Sets the Master Texture Limit on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetMasterTextureLimit : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set on this quality setting. Setting this to one uses the first mipmap of each texture (so all textures are half size), setting this to two uses the second mipmap of each texture (so all textures are quarter size), etc.. This can be used to decrease video memory requirements on low-end computers. The default value is zero.")] int Value)
   {
      QualitySettings.masterTextureLimit = Value;
   }
}