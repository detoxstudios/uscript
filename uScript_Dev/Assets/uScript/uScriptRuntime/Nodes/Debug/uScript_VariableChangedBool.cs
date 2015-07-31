// uScript Event Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Variables")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the specified variable(s) changed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Variable Changed (Bool)", "Fires an event signal when the specified variable(s) changed.")]
public class uScript_VariableChangedBool : uScriptEvent
{
#pragma warning disable 67
#pragma warning disable 414


   private bool m_VariableChanged = false;

   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);


   [FriendlyName("On Changed")]
   public event uScriptEventHandler OnChanged;
   
#pragma warning restore 414
#pragma warning restore 67

   void Update()
   {


      if (!m_VariableChanged)
      {

            if ( null != OnChanged ) OnChanged( this, new System.EventArgs() );     

      }
      
      //m_LastKeyboardOut = iPhoneKeyboard.visible;
   


   }
}
