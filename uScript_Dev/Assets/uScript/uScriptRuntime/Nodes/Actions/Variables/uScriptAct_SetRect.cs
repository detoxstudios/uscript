// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Rect variable using the value of another Rect variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Rect", "Sets the value of a Rect variable using the value of another Rect variable.")]
public class uScriptAct_SetRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Rect Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Rect TargetRect
      )
   {
      TargetRect = Value;
   }
}
