// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/KeyCode")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Get the number of things currently in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get List Size (KeyCode)", "Get the number of things currently in the list.")]
public class uScriptAct_GetListSizeKeyCode : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The list to get the size on.")]
      KeyCode[] List,

      [FriendlyName("Size", "The size of the list specified.")]
      out int ListSize
      )
   {
      ListSize = List.Length;
   }

}
