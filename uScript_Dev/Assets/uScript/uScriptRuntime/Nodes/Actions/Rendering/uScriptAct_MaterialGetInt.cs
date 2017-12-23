// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Rendering/Materials")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Gets an int Material property")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Material Get Int", "Gets an int property of a Material.")]
public class uScriptAct_MaterialGetInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to get the int from.")]
      Material material,
      [FriendlyName("Property", "The name of the int variable on the Material.")]
      string name,
      [FriendlyName("Value", "The property's value.")]
      out int value
   )
   {
      value = material.GetInt(name);
   }
}