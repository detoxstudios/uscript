// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[NodePath("Actions/Variables/Lists/Int64")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Get the number of things currently in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get List Size (Int64)", "Get the number of things currently in the list.")]
public class uScriptAct_GetListSizeInt64 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The list to get the size on.")]
      Int64[] List,

      [FriendlyName("Size", "The size of the list specified.")]
      out int ListSize
      )
   {
      ListSize = List.Length;
   }

}
