// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Texture2D")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Texture2D to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Texture2D", "Sets a Texture2D to the defined value.")]
public class uScriptAct_SetTexture2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The source texture data")]
      Texture2D Value,

      [FriendlyName("Target", "The value that has been set for this variable.")]
      out Texture2D Target
      )
   {
      Target = Value;
   }
}
