// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the time scale of the game.

using UnityEngine;
using System.Collections;

[NodePath("Action/Time")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the time scale of the game.")]
[NodeDescription("Sets the time scale of the game.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Time Scale")]
public class uScriptAct_SetTimeScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In([FriendlyName("Time Scale")] float TimeScale, [FriendlyName("Change Delta Time?"), DefaultValue(true)] bool ChangeDeltaTime)
   {

      if (TimeScale < 0.0f) TimeScale = 0;

      Time.timeScale = TimeScale;

      if (ChangeDeltaTime) Time.fixedDeltaTime = TimeScale;

   }
}