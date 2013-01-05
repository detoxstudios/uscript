// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Label on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_Label")]

[FriendlyName("GUILayout Label", "Shows a GUI Label on the screen using Unity's automatic layout system.")]
public class uScriptAct_GUILayoutLabel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "Text to display on the label.")]
      string Text,

      [FriendlyName("Texture", "Texture to display on the label.")]
      [SocketState(false, false)]
      Texture Texture,
      
      [FriendlyName("Tooltip", "The tooltip associated with this control.")]
      [DefaultValue(""), SocketState(false, false)]
      string Tooltip,

      [FriendlyName("Style", "The style to use. If left out, the \"label\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIContent content = new GUIContent(Text, Texture, Tooltip);
      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.label : GUI.skin.GetStyle(Style));

      GUILayout.Label(content, style, Options);
   }
}
