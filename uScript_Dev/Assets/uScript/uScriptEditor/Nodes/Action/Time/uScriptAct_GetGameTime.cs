// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current time scale and delta time (fixed timestep) of the game.

using UnityEngine;
using System.Collections;

[NodePath("Action/Time")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current time scale and delta time (fixed timestep) of the game.")]
[NodeDescription("Gets the current time scale and delta time (fixed timestep) of the game.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Game Time")]
public class uScriptAct_GetGameTime : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Time Scale")] out float CurrentScale,
      [FriendlyName("Fixed Timestep")] out float FixedDelta,
      [FriendlyName("Max Allowed Timestep")] out float MaxAllowedTimestep
      )
   {
      CurrentScale = Time.timeScale;
      FixedDelta = Time.fixedDeltaTime;
      MaxAllowedTimestep = Time.maximumDeltaTime;
   }
}