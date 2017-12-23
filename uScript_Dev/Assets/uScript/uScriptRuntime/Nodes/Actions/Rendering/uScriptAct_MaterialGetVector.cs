// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Rendering/Materials")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Gets a Vector Material property")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Material Get Vector", "Gets a Vector property of a Material.")]
public class uScriptAct_MaterialGetVector : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to get the Vector from.")]
      Material material,
      [FriendlyName("Property", "The name of the Vector variable on the Material.")]
      string name,
      [FriendlyName("Value", "The property's value.")]
      out Vector4 value
   )
   {
      value = material.GetVector(name);
   }
}