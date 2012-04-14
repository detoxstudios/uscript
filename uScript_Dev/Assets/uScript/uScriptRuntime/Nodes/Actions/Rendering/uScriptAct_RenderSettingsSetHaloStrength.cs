// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the size of the light halos the renderer should use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Halo Strength", "Sets the size of the light halos the renderer should use.")]
public class uScriptAct_RenderSettingsSetHaloStrength : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set the light halo strength to.")] float haloStrength)
   {
      RenderSettings.haloStrength = haloStrength;
   }
}