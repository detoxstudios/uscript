// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a ContactPoint variable using the value of another ContactPoint variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/ContactPoint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value(s) of a ContactPoint variable using the value of another ContactPoint variable.")]
[NodeDescription("Sets the value(s) of a ContactPoint variable using the value of another ContactPoint variable.n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set ContactPoint")]
public class uScriptAct_SetContactPoint : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object Value, [FriendlyName("Target")] out ContactPoint Target)
   {
      if ( Value.GetType() != typeof(ContactPoint) )
      {
         uScriptDebug.Log( "Set ContactPoint: Value is not a ContactPoint!", uScriptDebug.Type.Error );
         Target = new ContactPoint( );
      }
      else
      {
         Target = (ContactPoint) Value;
      }
   }
}