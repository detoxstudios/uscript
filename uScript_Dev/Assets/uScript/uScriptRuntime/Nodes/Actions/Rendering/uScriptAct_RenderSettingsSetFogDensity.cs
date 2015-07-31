// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the fog density the renderer should use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Fog Density", "Sets the fog density the renderer should use when using an exponential fog mode (0.0 - 1.0). Please note, that fog density is NOT used for the linear fog mode.")]
public class uScriptAct_RenderSettingsSetFogDensity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Density", "The value to set the fog density to.")] float fogDensity)
   {
      RenderSettings.fogDensity = fogDensity;
   }
}