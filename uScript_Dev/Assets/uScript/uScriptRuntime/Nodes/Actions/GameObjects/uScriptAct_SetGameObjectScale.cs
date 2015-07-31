// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the scale of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Scale", "Sets the scale of a GameObject.")]
public class uScriptAct_SetGameObjectScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to set the position of."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Scale", "The new X, Y and Z scale as a Vector3(X, Y, Z)")]
      Vector3 Scale
      )
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
