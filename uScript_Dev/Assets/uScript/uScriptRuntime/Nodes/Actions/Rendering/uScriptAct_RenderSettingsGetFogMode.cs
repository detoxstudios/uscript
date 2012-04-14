// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the current fog mode of the renderer's fog.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Fog Mode", "Returns the current fog mode of the renderer's fog.")]
public class uScriptAct_RenderSettingsGetFogMode : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Mode", "The current fog mode of the renderer.")] out FogMode currentFogMode)
   {
      currentFogMode = RenderSettings.fogMode;
   }
}