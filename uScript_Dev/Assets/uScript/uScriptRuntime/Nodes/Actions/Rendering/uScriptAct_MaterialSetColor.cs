// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Rendering/Materials")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Sets a Color property on a Material.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Material Set Color", "Sets a Color property on a Material.")]
public class uScriptAct_MaterialSetColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to set the Color on.")]
      Material material,
      [FriendlyName("Property", "The name of the Color variable on the Material.")]
      string name,
      [FriendlyName("Value", "The property's value.")]
      Color value
   )
   {
      material.SetColor( name, value );
   }
}