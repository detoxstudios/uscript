// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Rect as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Rect)", "Gets the components of a Rect as floats.")]
public class uScriptAct_GetComponentsRect : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
                  [FriendlyName("Input Rect", "The input Rect to get components of.")]
                  Rect InputRect,

                  [FriendlyName("Left", "The Left value of the Input Rect.")]
                  out float Left,

                  [FriendlyName("Top", "The Top value of the Input Rect.")]
                  out float Top,

                  [FriendlyName("Width", "The Width value of the Input Rect.")]
                  out float Width,

                  [FriendlyName("Height", "The Height value of the Input Rect.")]
                  out float Height
                  )
   {
      Left = InputRect.xMin;
      Top = InputRect.yMin;
      Width = InputRect.width;
      Height = InputRect.height;
   }
}
