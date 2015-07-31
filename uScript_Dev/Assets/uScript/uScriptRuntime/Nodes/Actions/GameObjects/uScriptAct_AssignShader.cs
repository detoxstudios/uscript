// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the specified Shader to the GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Assign Shader", "Assigns the specified Shader (by name) to the GameObject on the specifed material.")]
public class uScriptAct_AssignShader : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Material", "The material of the object to assign the shader to.")]
      [RequiresLink, SocketState(false, false)]
      Material material,
      
      [FriendlyName("Shader", "The shader to assign.")]
      [RequiresLink]
      Shader shader
      )
   {
      material.shader = shader;
   }
}