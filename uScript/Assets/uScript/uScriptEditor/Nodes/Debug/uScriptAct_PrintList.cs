// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a float to the defined value.
using UnityEngine;
using System.Collections;

public class uScriptAct_PrintList : uScriptLogic
{
   // How many outputs defined here
   public bool Output { get { return true; } }

   // Do logic here
   public void Input(string []strings)
   {
      foreach ( object s in strings )
      {
         Debug.Log( "string = " + s );
      }
   }
}