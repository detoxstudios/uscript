// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current delta time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get Delta Time", "Gets the current delta time.")]
public class uScriptAct_GetDeltaTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Delta Time", "Returns the current delta time.")]
      out float DeltaTime,
      
      [FriendlyName("Smooth Delta Time", "Returns a smoothed out delta time.")]
      [SocketState(false, false)]
      out float SmoothDeltaTime,
      
      [FriendlyName("Fixed Delta Time", "Returns the current fixed delta time.")]
      [SocketState(false, false)]
      out float FixedDeltaTime
      )
   {
      DeltaTime = Time.deltaTime;
	  SmoothDeltaTime = Time.smoothDeltaTime;
	  FixedDeltaTime = Time.fixedDeltaTime;
   }
}


