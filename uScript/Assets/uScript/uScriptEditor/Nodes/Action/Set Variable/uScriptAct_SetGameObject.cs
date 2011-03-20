// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a GameObject variable using the value of another GameOject variable.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetGameObject : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Value, out GameObject TargetGameObject)
   {
      // @TODO: I'm worried this won't assign the correct object.
      // uScript might need to be using InstanceIDs instead of by the name?

      TargetGameObject = Value;
   }

}