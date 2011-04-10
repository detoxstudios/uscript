// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down.

using UnityEngine;
using System.Collections;

[NodePath("Action/Event")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Filters the On Key Press event to a specific key when the key is pressed down.")]
[NodeDescription("Filters the On Key Press event to a specific key when the key is pressed down.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Filter On Key Press")]
public class uScriptAct_OnKeyPressFilter : uScriptLogic
{
   public bool m_KeyCode = false;

   public bool Out { get { return m_KeyCode; } }

   // @TODO: This is firing twice.
   public void In([FriendlyName("Key Code")] string[] KeyCode)
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