// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Password Field on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_PasswordField")]

[FriendlyName("GUILayout Password Field", "Shows a GUI Password Field on the screen using Unity's automatic layout system.\n"
   + "\n"
   + "This control creates a masked single-line password field where the user can edit a string. The Changed event will fire when the string value changes.")]
public class uScriptAct_GUILayoutPasswordField : uScriptLogic
{
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }

   public void In(
      [FriendlyName("Value", "The value of the password field.")]
      ref string Value,

      [FriendlyName("Max Length", "The maximum allowable string length for this password field.")]
      [DefaultValue(20), SocketState(false, false)]
      int MaxLength,

//      [FriendlyName("Mask Character", "???.")]
//      [DefaultValue('*')]
//      [SocketState(false, true)]
//      char MaskChar,
//
      [FriendlyName("Style", "The style to use. If left out, the \"textfield\" style from the current GUISkin is used.")]
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

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.textField : GUI.skin.GetStyle(Style));

      if (string.IsNullOrEmpty(ControlName) == false)
      {
         GUI.SetNextControlName(ControlName);
      }

      value = GUILayout.PasswordField(Value, '*', MaxLength, style, Options);

      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
