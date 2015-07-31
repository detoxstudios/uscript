// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the fog end distance the renderer should use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Fog End Distance", "Sets the fog end distance the renderer should use when using the linear fog mode. Please note, that the fog end distance is NOT used for the exponential fog modes.")]
public class uScriptAct_RenderSettingsSetFogEndDistance : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set the fog end distance to.")] float fogEndDistance)
   {
      RenderSettings.fogEndDistance = fogEndDistance;
   }
}