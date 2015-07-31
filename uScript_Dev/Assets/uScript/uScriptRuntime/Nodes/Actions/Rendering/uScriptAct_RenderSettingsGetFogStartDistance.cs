// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current fog start distance used for the linear fog mode.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Fog Start Distance", "Returns the current fog start distance used for the linear fog mode.")]
public class uScriptAct_RenderSettingsGetFogStartDistance : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The current fog start distance used by the renderer.")] out float currentFogStartDistance)
   {
      currentFogStartDistance = RenderSettings.fogStartDistance;
   }
}