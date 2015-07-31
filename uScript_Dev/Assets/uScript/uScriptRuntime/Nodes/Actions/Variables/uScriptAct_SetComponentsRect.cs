// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Rect to the defined Left, Top, Width and Height float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Rect)", "Sets a Rect to the defined Left, Top, Width and Height float component values.")]
public class uScriptAct_SetComponentsRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Left", "Left value to use for the Output Rect.")]
      float Left,
      
      [FriendlyName("Top", "Top value to use for the Output Rect.")]
      float Top,
      
      [FriendlyName("Width", "Width value to use for the Output Rect.")]
      [DefaultValue(32f)]
      float Width,
      
      [FriendlyName("Height", "Height value to use for the Output Rect.")]
      [DefaultValue(32f)]
      float Height,
      
      [FriendlyName("Output Rect", "Rect variable built from the specified Left, Top, Width, and Height.")]
      out Rect OutputRect
      )
   {
      OutputRect = new Rect(Left, Top, Width, Height);
   }
}
