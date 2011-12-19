// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Rendering")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a Material")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Material_Set_Float")]

[FriendlyName("Material Set Float", "Sets a float property on a Material.")]
public class uScriptAct_MaterialSetFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The Material to set the float.")]
      Material material,
      [FriendlyName("Property", "The name of the float variable on the Material.")]
      string name,
      [FriendlyName("Value", "The property's value.")]
      float value
   )
   {
      material.SetFloat( name, value );
   }
}