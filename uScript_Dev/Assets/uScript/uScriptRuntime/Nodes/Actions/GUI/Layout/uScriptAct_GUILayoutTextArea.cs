// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Text Area on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout Text Area", "Shows a GUI Text Area on the screen using Unity's automatic layout system.\n"
   + "\n"
   + "This control creates a multi-line text field where the user can edit a string. The Changed event will fire when the string value changes.")]
public class uScriptAct_GUILayoutTextArea : uScriptLogic
{
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }

   public void In(
      [FriendlyName("Value", "The value of the text field.")]
      ref string Value,

      [FriendlyName("Max Length", "The maximum allowable string length for this text field.")]
      [DefaultValue(50)]
      int MaxLength,

      [FriendlyName("Style", "The style to use. If left out, the \"textarea\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options,

      [FriendlyName("Control Name", "The name which will be assigned to the control.")]
      [DefaultValue(""), SocketState(false, false)]
      string ControlName
      )
   {
      string value;
      m_Changed = false;

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.textArea : GUI.skin.GetStyle(Style));

      if (string.IsNullOrEmpty(ControlName) == false)
      {
         GUI.SetNextControlName(ControlName);
      }

      value = GUILayout.TextArea(Value, MaxLength, style, Options);

      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
