// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Toggle on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout Toggle", "Shows a GUI Toggle on the screen using Unity's automatic layout system. The Changed event will fire when the control state changes.")]
public class uScriptAct_GUILayoutToggle : uScriptLogic
{
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }

   public void In(
      [FriendlyName("Value", "The value of the toggle.")]
      ref bool Value,

      [FriendlyName("Text", "Text to display on the toggle.")]
      string Text,

      [FriendlyName("Texture", "Texture to display on the toggle.")]
      [SocketState(false, false)]
      Texture Texture,

      [FriendlyName("Tooltip", "The tooltip associated with this control.")]
      [DefaultValue(""), SocketState(false, false)]
      string Tooltip,

      [FriendlyName("Style", "The style to use. If left out, the \"toggle\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
      )
   {
      GUIContent content = new GUIContent(Text, Texture, Tooltip);
      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.toggle : GUI.skin.GetStyle(Style));

      bool value = false;
      m_Changed = false;

      value = GUILayout.Toggle(Value, content, style, Options);

      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
