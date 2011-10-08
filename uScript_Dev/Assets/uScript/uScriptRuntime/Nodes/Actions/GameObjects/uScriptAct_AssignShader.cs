// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Assigns the specified Material (by name) to the GameObject on the specifed material channel.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the specified Shader to the GameObject.")]
[NodeDescription("Assigns the specified Shader (by name) to the GameObject on the specifed material.\n \nMaterial: The material of the object to assign the shader to. \nShader: The shader to assign.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Assign_Shader")]

[FriendlyName("Assign Shader")]
public class uScriptAct_AssignShader : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([RequiresLink, FriendlyName("Material"), SocketState(false, false)]Material material, [RequiresLink, FriendlyName("Shader")]Shader shader)
   {
      material.shader = shader;
   }
}