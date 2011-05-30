// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Tells a GameObject to look at another GameObject transform or Vector3 position.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells a GameObject to look at another GameObject transform or Vector3 position.")]
[NodeDescription("Tells a GameObject (target) to look at another GameObject (focus) transform or Vector3 position.\n \nTarget: The Target GameObject(s) whose look direction will be adjusted.\nFocus: The item to focus on - can be a Vector3 position or a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Look At")]
public class uScriptAct_LookAt : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, object Focus)
   {
      if (Focus != null)
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               if (typeof(GameObject) == Focus.GetType())
               {
                  GameObject tempGameObject = (GameObject)Focus;
                  currentTarget.transform.LookAt(tempGameObject.transform);
               }
               else if (typeof(Vector3) == Focus.GetType())
               {
                  Vector3 tempVector3 = (Vector3)Focus;
                  currentTarget.transform.LookAt(tempVector3);
               }
            }
         }
      }
   }
}
