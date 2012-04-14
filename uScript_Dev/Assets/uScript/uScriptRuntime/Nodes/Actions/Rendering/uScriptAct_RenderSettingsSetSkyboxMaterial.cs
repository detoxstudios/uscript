// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering/Render Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the material for the renderer's global skybox.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Skybox Material", "Sets the material for the renderer's global skybox.")]
public class uScriptAct_RenderSettingsSetSkyboxMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Material", "The material to set the global skybox to.")] Material newSkybox)
   {
      RenderSettings.skybox = newSkybox;
   }
}