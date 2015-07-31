// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current time scale and delta time (fixed timestep) of the game.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Game Time", "Gets the current time scale and delta time (fixed timestep) of the game.")]
public class uScriptAct_GetGameTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Time Scale", "The current global time scale.")]
      out float CurrentScale,
      
      [FriendlyName("Fixed Timestep", "The current global fixed timestep.")]
      out float FixedDelta,
      
      [FriendlyName("Max Allowed Timestep", "The current global allowed timestep.")]
      out float MaxAllowedTimestep
      )
   {
      CurrentScale = Time.timeScale;
      FixedDelta = Time.fixedDeltaTime;
      MaxAllowedTimestep = Time.maximumDeltaTime;
   }
}