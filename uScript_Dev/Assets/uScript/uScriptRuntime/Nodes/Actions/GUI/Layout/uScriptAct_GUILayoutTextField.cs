// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Text Field on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_TextField")]

[FriendlyName("GUILayout Text Field", "Shows a GUI Text Field on the screen using Unity's automatic layout system.\n"
   + "\n"
   + "This control creates a single-line text field where the user can edit a string. Special events are triggered when the string value changes, the user presses the Return key, and the control focus state changes.")]
public class uScriptAct_GUILayoutTextField : uScriptLogic
{
   private bool m_Changed = false;
   private bool m_Submited = false;
   private bool m_HadFocus = false;
   private string m_InitialValue;
   private string m_ControlName;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }

   [FriendlyName("Submitted")]
   public bool Submitted { get { return m_Submited; } }

   [FriendlyName("Received Focus")]
   public event uScriptEventHandler OnReceivedFocus;
   [FriendlyName("Has Focus")]
   public event uScriptEventHandler OnHasFocus;
   [FriendlyName("Lost Focus")]
   public event uScriptEventHandler OnLostFocus;

   public void In(
      [FriendlyName("Value", "The value of the text field.")]
      ref string Value,

      [FriendlyName("Max Length", "The maximum allowable string length for this text field.")]
      [DefaultValue(50), SocketState(false, false)]
      int MaxLength,

      [FriendlyName("Reset Value on Escape", "When True, the value will be set to what it was when the control first received focus.")]
      [DefaultValue(true), SocketState(false, false)]
      bool ResetOnEscape,

      [FriendlyName("Drop Focus on Escape", "When True, the control will lose focus when the Escape key is pressed.")]
      [DefaultValue(true), SocketState(false, false)]
      bool DropFocusOnEscape,

      [FriendlyName("Drop Focus on Return", "When True, the control will lose focus when the Return key is pressed.")]
      [DefaultValue(true), SocketState(false, false)]
      bool DropFocusOnReturn,

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
      m_Submited = false;

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.textField : GUI.skin.GetStyle(Style));

      if (string.IsNullOrEmpty(m_ControlName)
         || (string.IsNullOrEmpty(ControlName) == false && m_ControlName != ControlName))
      {
         m_ControlName = (string.IsNullOrEmpty(ControlName) ? System.Guid.NewGuid().ToString() : ControlName);
      }

      GUI.SetNextControlName(m_ControlName);

      if (Event.current.type == EventType.KeyDown)
      {
         bool useEvent = false;

         if (Event.current.keyCode == KeyCode.Escape)
         {
            if (ResetOnEscape)
            {
               Value = m_InitialValue;
               useEvent = true;
            }

            if (DropFocusOnEscape)
            {
               GUI.FocusControl(string.Empty);
               useEvent = true;
            }
         }

         if (Event.current.keyCode == KeyCode.Return)
         {
            if (DropFocusOnReturn)
            {
               GUI.FocusControl(string.Empty);
               useEvent = true;
            }
            else
            {
               // The user has at least commited to the changes, so update the reset value
               m_InitialValue = Value;
               useEvent = true;
            }

            m_Submited = true;
         }

         if (useEvent)
         {
            Event.current.Use();
         }
      }

      value = GUILayout.TextField(Value, MaxLength, style, Options);
      value = value.Replace("\n", "");

      if (Event.current.type == EventType.Repaint)
      {
         // Save state now just incase events cause recursive logic
         bool hadFocus = m_HadFocus;

         m_HadFocus = GUI.GetNameOfFocusedControl() == m_ControlName;

         // Focus events
         if (!hadFocus && m_HadFocus && OnReceivedFocus != null)
         {
            m_InitialValue = Value;
            OnReceivedFocus(this, new System.EventArgs());
         }

         if (hadFocus && m_HadFocus && OnHasFocus != null)
            OnHasFocus(this, new System.EventArgs());

         if (hadFocus && !m_HadFocus && OnLostFocus != null)
            OnLostFocus(this, new System.EventArgs());
      }

      // Changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
