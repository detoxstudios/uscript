// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Get the number of things currently in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get List Size (RaycastHit2D)", "Get the number of things currently in the list.")]
public class uScriptAct_GetListSizeRaycastHit2D : uScriptLogic
{

    public bool Out { get { return true; } }

    public void In(
       [FriendlyName("Target", "The list to get the size on.")]
      RaycastHit2D[] List,

       [FriendlyName("Size", "The size of the list specified.")]
      out int ListSize
       )
    {
        ListSize = List.Length;
    }

}
