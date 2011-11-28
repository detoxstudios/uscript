// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Rect to the defined Left, Top, Width and Height float component values.

using UnityEngine;
using System.Collections;

[NodeDeprecated(typeof(uScriptAct_SetComponentsRect))]

[NodePath("Actions/Set Variable")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Rect to the defined Left, Top, Width and Height float component values.")]
/* D */[NodeDescription("Sets a Rect to the defined Left, Top, Width and Height float component values.\n \nLeft (in): Left value to use for the Output Rect.\nTop (in): Top value to use for the Output Rect.\nWidth (in): Width value to use for the Output Rect.\nHeight (in): Height value to use for the Output Rect.\nOutput Rect (out): Rect variable built from the specified Left, Top, Width, and Height.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector4_Components")]

[FriendlyName("Set Rect Components")]
public class uScriptAct_SetRectComponents : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Left, float Top, [DefaultValue(32f)] float Width, [DefaultValue(32f)] float Height, [FriendlyName("Output Rect")] out Rect OutputRect)
   {
      OutputRect = new Rect(Left, Top, Width, Height);
   }
}