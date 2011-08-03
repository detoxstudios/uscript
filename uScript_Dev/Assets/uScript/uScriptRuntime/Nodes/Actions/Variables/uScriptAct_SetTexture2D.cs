// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a texture2d to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Texture2D to the defined value.")]
[NodeDescription("Sets a Texture2D to the defined value.\n \nTarget (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Texture2D")]

[FriendlyName("Set Texture2D")]
public class uScriptAct_SetTexture2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Texture2D Value, out Texture2D Target)
   {
      Target = Value;
   }
}
