
// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Delays the AfterDelay output signal by x seconds.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Gets the name of a GameObject.")]
[NodeDescription("Gets the name of a GameObject.\n \nTarget: The GameObject.\nName: The returned name of the GameObject")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Object_Name")]

[FriendlyName("Get GameObject Name")]
public class uScriptAct_GetGameObjectName : uScriptLogic
{
   [FriendlyName("Out")]
   public bool Out { get { return true; } }
  
   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target")] GameObject gameObject,
      [FriendlyName("Name")] out string name
   )
   {
      name = gameObject.name;
   }

}

