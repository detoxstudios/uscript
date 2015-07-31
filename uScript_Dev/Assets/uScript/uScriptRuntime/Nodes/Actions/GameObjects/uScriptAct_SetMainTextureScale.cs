// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the main texture scale of a Material.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Texture Scale", "Applys a texture scale to the specified Material.")]
public class uScriptAct_SetMainTextureScale : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The material to set the main texture scale.")]
      Material material,

      [FriendlyName("Texture Scale", "The texture scale to apply.")]
      Vector2 textureScale
      )
   {
      material.mainTextureScale = textureScale;
   }
}