// uScript Action Node
// (C) 2013 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Text Field on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout Text Field", "Shows a GUI Text Field on the screen using Unity's automatic layout system.\n"
   + "\n"
   + "This control creates a single-line text field where the user can edit a string. Special events are triggered when the string value changes, the user presses the Return key, and the control focus state changes.\n"
   + "\n"
   + "NOTE: An individual GUILayout Text Field node should not be used in a loop or triggered multiple times per frame.  Multiple nodes should be used if you wish to display more than one text field.\n"
   + "\n"
   + "NOTE: Only the Out socket should be used to call additional GUI nodes.  Events such as Changed, Submitted, and Received Focus are not triggered every frame, and errors will be generated if other GUI nodes are changed to them.")]
public class uScriptAct_GUILayoutTextField : uScriptLogic
{
   private bool _changed;
   private bool _submited;
   private bool _hadFocus;
   private string _initialValue;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return _changed; } }

   [FriendlyName("Submitted")]
   public bool Submitted { get { return _submited; } }

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

      [FriendlyName("Mask Character", "Character to mask the string with.  Allows the control to be used as a password field that masks the keyboard input.  While this parameter accepts a String variable, only the first character in the string will be used.  For exapmle, if the Mask is \"XYZ\", and you enter a 5-letter password, it will appear as \"XXXXX\".")]
      [DefaultValue("")]
      [SocketState(false, true)]
      string MaskCharacter,

      [FriendlyName("Style", "The style to use. If left out, the \"textfield\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options,

      [FriendlyName("Control Name", "The name which will be assigned to the control.  If no name is specified, one will be dynamically generated and assigned.")]
      [DefaultValue(""), SocketState(false, false)]
      ref string ControlName
      )
   {
      _changed = false;
      _submited = false;

      string value = string.Empty;

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.textField : GUI.skin.GetStyle(Style));

      // Generate a control name if one wasn't already specified
      if (string.IsNullOrEmpty(ControlName))
      {
         ControlName = System.Guid.NewGuid().ToString();
      }

      GUI.SetNextControlName(ControlName);

      if (GUI.GetNameOfFocusedControl() == ControlName)
      {
         if (Event.current.type == EventType.KeyDown)
         {
            bool useEvent = false;

            if (Event.current.keyCode == KeyCode.Escape)
            {
               if (ResetOnEscape)
               {
                  Value = _initialValue;
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
                  _initialValue = Value;
                  useEvent = true;
               }
   
               _submited = true;
            }
   
            if (useEvent)
            {
               Event.current.Use();
            }
         }
      }

      System.Text.RegularExpressions.Regex.Replace(MaskCharacter, @"\s+", string.Empty);

      if (string.IsNullOrEmpty(MaskCharacter))
      {
         value = GUILayout.TextField(Value, MaxLength, style, Options);
      }
      else
      {
         value = GUILayout.PasswordField(Value, MaskCharacter[0], MaxLength, style, Options);
      }
      value = value.Replace("\n", "");

      if (Event.current.type == EventType.Repaint)
      {
         // Save state now just incase events cause recursive logic
         bool hadFocus = _hadFocus;

         _hadFocus = GUI.GetNameOfFocusedControl() == ControlName;

         // Focus events
         if (!hadFocus && _hadFocus && OnReceivedFocus != null)
         {
            _initialValue = Value;
            OnReceivedFocus(this, new System.EventArgs());
         }

         if (hadFocus && _hadFocus && OnHasFocus != null)
         {
            OnHasFocus(this, new System.EventArgs());
         }

         if (hadFocus && !_hadFocus && OnLostFocus != null)
         {
            OnLostFocus(this, new System.EventArgs());
         }
      }
//      else if (Event.current.type == EventType.Used)
//      {
//         if (Value != value)
//         {
//            OnChanged(this, new System.EventArgs());
//         }
//      }

      // Changed event
      if (Value != value)
      {
         _changed = true;
      }

      Value = value;
   }
}

#endif