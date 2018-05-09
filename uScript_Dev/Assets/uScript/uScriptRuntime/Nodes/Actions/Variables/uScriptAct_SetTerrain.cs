// uScript Action Node
// (C) 2018 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Terrain")]

[NodeCopyright("Copyright 2018 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Terrain variable using the value of another Terrain variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Terrain", "Sets the value of a Terrain variable using the value of another Terrain variable.")]
public class uScriptAct_SetTerrain : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Terrain Value,

      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Terrain TargetTerrain
      )
   {
      TargetTerrain = Value;
   }
}
