// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches a script or component to a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Attach Component", "Attaches a script or component to a GameObject. To remove Components, use the Destroy Component node.")]
public class uScriptAct_AttachScript : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to attach the script to.")]
      GameObject[] Target,
      
      [FriendlyName("Component Name", "The names of the components or script filenames to attach to the specified GameObject(s).")]
      string[] ScriptName
      )
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
               uScriptDebug.Log("[Attach Component] " + e.ToString(), uScriptDebug.Type.Error);
            }
         }
      }
   }
}