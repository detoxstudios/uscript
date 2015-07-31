// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current fog density used for exponential fog modes.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Fog Density", "Returns the current fog density used for exponential fog modes.")]
public class uScriptAct_RenderSettingsGetFogDensity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Density", "The current fog density used by the renderer.")] out float currentFogDensity)
   {
      currentFogDensity = RenderSettings.fogDensity;
   }
}