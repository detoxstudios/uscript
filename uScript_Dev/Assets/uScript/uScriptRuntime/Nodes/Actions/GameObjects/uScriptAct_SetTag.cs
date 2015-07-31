// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the tag of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Tag", "Sets the tag of a GameObject. The tag must be created in Unity's tag manager before using them with this node. Use \"Untagged\" for the tag name if you wish to remove an existing tag.")]
public class uScriptAct_SetTag : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) you wish to assign the existing tag to."), AutoLinkType(typeof(GameObject))]GameObject[] Target, 
      [FriendlyName("Tag", "The tag(s) you wish to assign to the Target GameObject(s)")] string Tags)
   {
      foreach (GameObject obj in Target)
      {
         if (null != obj)
         {
            obj.tag = Tags;
         }
      }
   }
}