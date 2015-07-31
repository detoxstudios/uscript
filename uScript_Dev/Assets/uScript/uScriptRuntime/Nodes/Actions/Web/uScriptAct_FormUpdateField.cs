// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Web/Form")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Add a simple field to the form.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Form Update Field", "Add a simple field to the form.")]
public class uScriptAct_FormUpdateField : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Form", "The Form to modify.")]
      ref WWWForm Form,

      [FriendlyName("Field Name", "The field name.")]
      string Field,

      [FriendlyName("Value", "The field value. Non-string objects will be convertd to a string using ToString().")]
      object Value
      )
   {
      if (Form == null)
      {
         Form = new WWWForm();
      }

      Form.AddField(Field, Value.ToString());
   }
}
