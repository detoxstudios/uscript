// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Begin a GUILayout block of GUI controls in a fixed screen area.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_BeginArea")]

[FriendlyName("GUILayout Begin Area", "Begin a GUILayout block of GUI controls in a fixed screen area.\n"
   + "\n"
   + "By default, any GUI controls made using GUILayout are placed in the top-left corner of the screen. If"
   + " you want to place a series of automatically laid out controls in an arbitrary area, use this node"
   + " to define a new area for the automatic layout system to use.\n"
   + "\n"
   + "NOTE: The group must be closed using a \"GUILayout End Area\" node.")]
public class uScriptAct_GUILayoutBeginArea : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position", "Position and size of the area.")]
      [SocketState(true, false)]
      Rect Position,

      [FriendlyName("Text", "Text to display on group.")]
      [SocketState(false, false)]
      string Text,

      [FriendlyName("Texture", "Texture to display on group.")]
      [SocketState(false, false)]
      Texture Texture,

      [FriendlyName("Tooltip", "The tooltip associated with this control.")]
      [DefaultValue(""), SocketState(false, false)]
      string Tooltip,

      [FriendlyName("Style", "The style to use. If left out, none will be used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style
      )
   {
      GUIContent content = GUIContent.none;
      if (string.IsNullOrEmpty(Text) == false
         || string.IsNullOrEmpty(Tooltip) == false
         || Texture != null)
      {
         content = new GUIContent(Text, Texture, Tooltip);
      }

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUIStyle.none : GUI.skin.GetStyle(Style));

      GUILayout.BeginArea(Position, content, style);
   }
}
