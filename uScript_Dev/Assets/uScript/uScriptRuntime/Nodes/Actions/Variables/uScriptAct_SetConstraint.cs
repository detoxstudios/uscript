// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Constraint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value(s) of a Constraint variable using the value of another Constraint variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Constraint", "Sets the value(s) of a Constraint variable using the value of another Constraint variable.")]
public class uScriptAct_SetConstraint : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable(s) you wish to use to set the target's value.")]
      UnityEngine.RigidbodyConstraints[] Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out UnityEngine.RigidbodyConstraints Target
      )
   {
      Target = RigidbodyConstraints.None;

      foreach ( UnityEngine.RigidbodyConstraints c in Value )
      {
         Target |= c;
      }
   }
}
