   // uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Attaches a script component to a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches a script component to a GameObject.")]
[NodeDescription("Attaches a script component to a GameObject.\n \nTarget: The GameObject(s) to attach the script to.\nScript Name: The name of the script to attach to the specified object(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Attach Script")]
public class uScriptAct_AttachScript : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Script Name")] string[] ScriptName)
   {
      foreach ( string currentScript in ScriptName )
      {
         if ( !string.IsNullOrEmpty(currentScript) )
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

            //uScriptDebug.Log("ScriptName = " + tempScript);

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