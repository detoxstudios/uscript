// uScript uScript_InputField.cs
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

//Unity 4.6 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when an input field's value has changed or editing has ended.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#UI_Input_Field_Events")]

[FriendlyName("UI Input Field Events", "Fires an event signal when Instance InputField receives a value change event or when editing has ended.")]
public class uScript_InputField : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, InputFieldEventArgs args);

   public class InputFieldEventArgs : System.EventArgs
   {
      private string m_InputFieldValue;
      [FriendlyName("Input Field Value")]
      public string InputFieldValue
      {
         get { return m_InputFieldValue; }
         set { m_InputFieldValue = value; }
      }

      public InputFieldEventArgs(string inputFieldValue)
      {
         m_InputFieldValue = inputFieldValue;
      }
   }

   [FriendlyName("On Input Field Value Change")]
   public event uScriptEventHandler OnInputFieldValueChange;

   [FriendlyName("On Input Field Editing Ended")]
   public event uScriptEventHandler OnInputFieldEditingEnded;

   public void Start()
   {
      UnityEngine.UI.InputField inputField = GetComponent<UnityEngine.UI.InputField>();
      inputField.onValueChange.RemoveAllListeners();
      inputField.onValueChange.AddListener(HandleValueChange);
      inputField.onEndEdit.RemoveAllListeners();
      inputField.onEndEdit.AddListener(HandleEndEdit);
   }

   void HandleValueChange(string value)
   {
      if ( OnInputFieldValueChange != null ) OnInputFieldValueChange( this, new InputFieldEventArgs(value) ); 
   }

   void HandleEndEdit(string value)
   {
      if ( OnInputFieldEditingEnded != null ) OnInputFieldEditingEnded( this, new InputFieldEventArgs(value) ); 
   }
}

#endif