// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down.

using UnityEngine;
using System.Collections;

public class uScriptAct_OnKeyPressFilter : uScriptLogic
{
   public bool m_KeyCode = false;

   public bool Out { get { return m_KeyCode; } }

   // @TODO: This is firing twice.
   public void In(string[] KeyCode)
   {
      m_KeyCode = false;
      bool shouldFire = false;

      foreach ( string keyCodeIstance in KeyCode)
      {
         if ( UnityEngine.Input.GetKeyDown(keyCodeIstance) )
         {
            shouldFire = true;
         }
      }

      m_KeyCode = shouldFire;
   }
}