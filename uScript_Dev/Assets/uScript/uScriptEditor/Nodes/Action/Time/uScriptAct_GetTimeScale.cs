// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current time scale of the game.

using UnityEngine;
using System.Collections;

[NodePath("Action/Time")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current time scale of the game.")]
[NodeDescription("Gets the current time scale of the game.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Time Scale")]
public class uScriptAct_GetTimeScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In([FriendlyName("Time")] out float CurrentScale, [FriendlyName("Fixed Delta")] out float FixedDelta)
   {
      CurrentScale = Time.timeScale;
      FixedDelta = Time.fixedDeltaTime;
   }
}