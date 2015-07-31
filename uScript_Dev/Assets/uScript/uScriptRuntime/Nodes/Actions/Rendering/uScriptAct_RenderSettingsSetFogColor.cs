// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the color of the fog the renderer should use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Fog Color", "Sets the color of the fog the renderer should use.")]
public class uScriptAct_RenderSettingsSetFogColor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In([FriendlyName("Color", "The color to set the fog to.")] UnityEngine.Color fogColor)
   {
      RenderSettings.fogColor = fogColor;
   }
}