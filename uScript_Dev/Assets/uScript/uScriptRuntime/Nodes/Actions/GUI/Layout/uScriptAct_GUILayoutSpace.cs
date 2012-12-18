// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Insert a space in the current layout group.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_Space")]

[FriendlyName("GUILayout Space", "Insert a space in the current layout group.  The direction of the space is dependent on the layout group the node is in when called. For example, if in a vertical group, the space will be vertical.")]
public class uScriptAct_GUILayoutSpace : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width", "The width of the space. \n\nNote: This will override the ExpandWidth and ExpandHeight layout options in the group.")]
      float Width,
      
      [FriendlyName("Flexible", "When True, inserts a flexible space element and ignores any specified Width. Flexible spaces use up any leftover space in a layout.")]
      bool Flexible
      )
   {
      if (Flexible)
      {
         GUILayout.FlexibleSpace();
      }
      else
      {
         GUILayout.Space(Width);
      }
   }
}
