// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches a script or component to a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Attach Component", "Attaches a script or component to a GameObject. To remove Components, use the Destroy Component node.")]
public class uScriptAct_AttachScript : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to attach the script to."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Component Name", "Requires the component or script assembly fully qualified name.")]
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
               // If this is null they must pass in the full assembly qualified name:
               // http://blogs.unity3d.com/2015/01/21/addcomponentstring-api-removal-in-unity-5-0/
               // We used to create this automatically but that caused compatibility issues with Windows 8 Store Compatibility
               System.Type type = System.Type.GetType(tempScript);
               foreach ( GameObject currentGameObject in Target )
               {
                  if (currentGameObject != null)
                  {
                     currentGameObject.AddComponent(type);
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
