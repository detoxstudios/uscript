// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Outputs the current frames per second.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Output FPS", "Outputs the current frames per second.")]
public class uScriptAct_OutputFramesPerSecond : uScriptLogic
{
   private float m_FPS = 0f;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("FPS", "Returns the current frames per second.")]
      out float FPS
      )
   {
      FPS = m_FPS;
   }

   public void Update ()
   {
      m_FPS = (1.0f / Time.deltaTime) / Time.timeScale;
   }
}
