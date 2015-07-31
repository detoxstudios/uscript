// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current state of the renderer's fog.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Fog", "Gets the current state of the renderer's fog.")]
public class uScriptAct_RenderSettingsGetFog : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("State", "Returns the current state of the renderer's fog value (true = on, false = off).")] out bool fogState)
   {
      fogState = RenderSettings.fog;
   }
}