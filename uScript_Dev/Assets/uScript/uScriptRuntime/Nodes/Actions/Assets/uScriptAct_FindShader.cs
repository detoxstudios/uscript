// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns a Shader")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Find Shader", "Finds a shader with the given name.")]
public class uScriptAct_FindShader : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name", "The shader to find")]
      string name,

      [FriendlyName("Shader Asset", "The Shader of the specified name.")]
      out Shader asset
   )
   {
      asset = Shader.Find(name);

      if ( null == asset )
      {
         uScriptDebug.Log( "Shader " + name + " couldn't be found, are you sure it is loaded?", uScriptDebug.Type.Warning );
      }
   }
}