// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Color variable using the value of another Color variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Color variable using the value of another Color variable.")]
[NodeDescription("Sets the value of a Color variable using the value of another Color variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Color")]

[FriendlyName("Set Color")]
public class uScriptAct_SetColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Color Value, [FriendlyName("Target")] out Color TargetColor)
   {
      TargetColor = Value;
   }
}