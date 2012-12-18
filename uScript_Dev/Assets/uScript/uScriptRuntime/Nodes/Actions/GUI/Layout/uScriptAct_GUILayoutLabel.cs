// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

using System.Reflection;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Label on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_Label")]

[FriendlyName("GUILayout Label", "Shows a GUI Label on the screen.")]
public class uScriptAct_GUILayoutLabel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "Text to display on the label.")]
      string Text,
      
      [FriendlyName("Texture", "Texture to display on the label.")]
      [SocketState(false, false)]
      Texture Texture,
      
      [FriendlyName("Tooltip", "The tool tip to display when the label is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string Tooltip,

      [FriendlyName("Style", "The style to use. If left out, the \"label\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] options,

      [FriendlyName("Control Name", "The name which will be assigned to the control.")]
      [DefaultValue(""), SocketState(false, false)]
      string ControlName
      )
   {
      GUIContent content = new GUIContent(Text, Texture, Tooltip);
      GUIStyle style = (string.IsNullOrEmpty(guiStyle) ? GUI.skin.label : GUI.skin.GetStyle(guiStyle));

      if (!string.IsNullOrEmpty(ControlName))
      {
         GUI.SetNextControlName(ControlName);
      }

      GUILayout.Label(content, style, options);
   }
}
