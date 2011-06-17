// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the scale of a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the scale of a GameObject.")]
[NodeDescription("Sets the scale of a GameObject.\n \nTarget: The Target GameObject(s) to set the position of.\nScale: The new X, Y and Z scale as a Vector3(X, Y, Z)")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Scale")]
public class uScriptAct_SetGameObjectScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, Vector3 Scale)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if ( currentTarget != null )
         {
            currentTarget.transform.localScale = Scale;
         }
      }

   }
}
