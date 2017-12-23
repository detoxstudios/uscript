// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Rendering/Materials")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector property on a Material.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Material Set Vector", "Sets a Vector property on a Material.")]
public class uScriptAct_MaterialSetVector : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to set the Vector on.")]
      Material material,
      [FriendlyName("Property", "The name of the ector variable on the Material.")]
      string name,
      [FriendlyName("Value", "The property's value.")]
      Vector3 value
   )
   {
      material.SetVector( name, value );
   }
}