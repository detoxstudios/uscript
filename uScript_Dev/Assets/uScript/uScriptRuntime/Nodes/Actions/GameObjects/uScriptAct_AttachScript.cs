// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios LLC" file="uScriptAct_AttachScript.cs">
//   Copyright 2010-2016 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

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
      
      [FriendlyName("Component Name", "Requires the component's complete assembly qualified name. For example, \"UnityEngine.BoxCollider, UnityEngine\".")]
      string[] ScriptName
      )
   {
      for (var i = 0; i < ScriptName.Length; i++)
      {
         var componentName = ScriptName[i].Trim();

         if (string.IsNullOrEmpty(componentName))
         {
            continue;
         }

         // Remove the file exstention that may have been added by the user
         if (componentName.EndsWith(".cs") || componentName.EndsWith(".js"))
         {
            componentName = componentName.Remove(componentName.Length - 3, 3);
         }
         if (componentName.EndsWith(".boo"))
         {
            componentName = componentName.Remove(componentName.Length - 4, 4);
         }

         try
         {
            // If this is null they must pass in the full assembly qualified name:
            // http://blogs.unity3d.com/2015/01/21/addcomponentstring-api-removal-in-unity-5-0/
            // We used to create this automatically but that caused compatibility issues with Windows 8 Store Compatibility

            for (var j = 0; j < Target.Length; j++)
            {
               if (Target[j] != null)
               {
                  Target[j].AddComponent(Type.GetType(componentName));
               }
            }
         }
         catch (Exception e)
         {
            uScriptDebug.Log("[Attach Component] " + e, uScriptDebug.Type.Error);
         }
      }
   }
}
