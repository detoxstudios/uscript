// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current ambient light color used by the renderer.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Ambient Light Color", "Returns the current ambient light color used by the renderer.")]
public class uScriptAct_RenderSettingsGetAmbientLightColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color", "The current color of the ambient light used by the renderer.")] out UnityEngine.Color currentAmbientLightColor)
   {
      currentAmbientLightColor = RenderSettings.ambientLight;
   }
}