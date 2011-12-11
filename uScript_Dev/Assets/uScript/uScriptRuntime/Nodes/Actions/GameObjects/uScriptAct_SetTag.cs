// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the tag of a GameObject.")]
[NodeAuthor("Detox Studios LLC. Original node by SvdV on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Tag", "Sets the tag of a GameObject. Tags must be declared in the tag manager before using them with this node.")]
public class uScriptAct_SetTag : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) you wish to assign the existing tag to.")]GameObject[] Target, 
      [FriendlyName("Tag", "The tag(s) you wish to assign to the Target GameObject(s)")] string[] Tags)
   {
      foreach (GameObject obj in Target)
      {
         if (null != obj)
         {
            foreach (string Tag in Tags)
            {
               obj.tag = Tag;
            }
            
         }
         
      }
		
   }
}