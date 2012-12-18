// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Begin a vertical control group using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_BeginVertical")]

[FriendlyName("GUILayout Begin Vertical", "Begin a vertical control group using Unity's automatic layout system.\n"
   + "\n"
   + "All controls rendered inside this element will be placed vertically below each other.\n"
   + "\n"
   + "NOTE: The group must be closed using a \"GUILayout End Vertical\" node.")]
public class uScriptAct_GUILayoutBeginVertical : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
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
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
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

      GUILayout.BeginVertical(content, style, Options);
   }
}
