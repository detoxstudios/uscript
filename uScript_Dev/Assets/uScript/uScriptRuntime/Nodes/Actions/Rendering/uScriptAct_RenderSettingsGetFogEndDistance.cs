// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current fog end distance used for the linear fog mode.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Fog End Distance", "Returns the current fog end distance used for the linear fog mode.")]
public class uScriptAct_RenderSettingsGetFogEndDistance : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The current fog end distance used by the renderer.")] out float currentFogEndDistance)
   {
      currentFogEndDistance = RenderSettings.fogEndDistance;
   }
}