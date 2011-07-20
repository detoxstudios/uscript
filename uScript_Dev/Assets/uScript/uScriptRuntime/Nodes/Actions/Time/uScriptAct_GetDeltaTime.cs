// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current delta time.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current delta time.")]
[NodeDescription("Gets the current delta time.\n \nDelta Time (out): Returns the current delta time.\nSmooth Delta Time (out): Returns a smoothed out delta time.\nFixed Delta Time (out): Returns the current fixed delta time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get Delta Time")]
public class uScriptAct_GetDeltaTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Delta Time")] out float DeltaTime,
	  [FriendlyName("Smooth Delta Time"), SocketState(false, false)] out float SmoothDeltaTime,
	  [FriendlyName("Fixed Delta Time"), SocketState(false, false)] out float FixedDeltaTime
      )
   {
      DeltaTime = Time.deltaTime;
	  SmoothDeltaTime = Time.smoothDeltaTime;
	  FixedDeltaTime = Time.fixedDeltaTime;
   }
}


