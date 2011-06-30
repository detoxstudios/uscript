// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Rect variable using the value of another Rect variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Rect variable using the value of another Rect variable.")]
[NodeDescription("Sets the value of a Rect variable using the value of another Rect variable.\n \nValue: The Rect variable to be set.\nTarget Rect (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Rect")]

[FriendlyName("Set Rect")]
public class uScriptAct_SetRect : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Rect Value, [FriendlyName("Target Rect")] out Rect TargetRect)
   {
      TargetRect = Value;
   }
}