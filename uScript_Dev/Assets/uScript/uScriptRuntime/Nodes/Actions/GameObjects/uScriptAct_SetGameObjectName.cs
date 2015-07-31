// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Sets a GameObject's name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set GameObject Name", "Sets the name of a GameObject.")]
public class uScriptAct_SetGameObjectName: uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject's name to change.")]
      GameObject Target,

      [FriendlyName("Name", "The new name.")]
      string Name
      )
   {
      Target.name = Name;
   }
}