// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the ambient light color the renderer should use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Ambient Light Color", "Sets the ambient light color the renderer should use.")]
public class uScriptAct_RenderSettingsSetAmbientLightColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color", "The color to set the ambient light to.")] UnityEngine.Color ambientLightColor)
   {
      RenderSettings.ambientLight = ambientLightColor;
   }
}