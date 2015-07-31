// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/ContactPoint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value(s) of a ContactPoint variable using the value of another ContactPoint variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set ContactPoint", "Sets the value(s) of a ContactPoint variable using the value of another ContactPoint variable.")]
public class uScriptAct_SetContactPoint : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      object Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out ContactPoint Target
      )
   {
#if !UNITY_FLASH
      if ( Value.GetType() != typeof(ContactPoint) )
      {
         uScriptDebug.Log( "Set ContactPoint: Value is not a ContactPoint!", uScriptDebug.Type.Error );
         Target = new ContactPoint( );
      }
      else
      {
#endif
         Target = (ContactPoint) Value;
#if !UNITY_FLASH
      }
#endif
   }
}
