// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Rect as floats.")]
[NodeDescription("Gets the components of a Rect as floats.\n \n\n \nInput Rect (in): The input Rect to get components of.\nLeft (out): The Left value of the Input Rect.\nTop (out): The Top value of the Input Rect.\nWidth (out): The Width value of the Input Rect.\nHeight (out): The Height value of the Input Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector4_Components")]

[FriendlyName("Get Components (Rect)")]
public class uScriptAct_GetComponentsRect : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In([FriendlyName("Input Rect")] Rect InputRect, out float Left, out float Top, out float Width, out float Height)
   {
      Left = InputRect.xMin;
      Top = InputRect.yMin;
      Width = InputRect.width;
      Height = InputRect.height;
   }
}