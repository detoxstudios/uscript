   // uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Attaches a script component to a GameObject.

using UnityEngine;
using System.Collections;

public class uScriptAct_AttachScript : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In( GameObject[] Target, string[] ScriptName )
   {
      foreach ( string currentScript in ScriptName )
      {
         if ( currentScript != "" )
         {
            string tempScript = currentScript;

            // Remove the file exstention that may have been added by the user
            if (tempScript.EndsWith(".cs") || tempScript.EndsWith(".js"))
            {
               int stringLength = tempScript.Length - 3;
               tempScript = tempScript.Remove(stringLength, 3);
            }
            if (tempScript.EndsWith(".boo"))
            {
               int stringLength = tempScript.Length - 4;
               tempScript = tempScript.Remove(stringLength, 4);
            }

            //Debug.Log("ScriptName = " + tempScript);

            try
            {
               foreach ( GameObject currentGameObject in Target )
               {
                  if (currentGameObject != null)
                  {
                     currentGameObject.AddComponent(tempScript);
                  }
                  
               }
            }
            catch (System.Exception e)
            {
               uScriptDebug.Log(e.ToString(), uScriptDebug.Type.Error);
            }
         }
      }

   }
}