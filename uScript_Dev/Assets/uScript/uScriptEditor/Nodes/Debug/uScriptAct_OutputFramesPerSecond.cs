// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Outputs the current frames per second.


using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Outputs the current frames per second.")]
[NodeDescription("Outputs the current frames per second.\n\nFPS: Returns the current frames per second.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Output FPS")]
public class uScriptAct_OutputFramesPerSecond : uScriptLogic
{
   private float m_FPS = 0f;

   public bool Out { get { return true; } }

   public void In([FriendlyName("FPS")] out float FPS)
   {
      FPS = m_FPS;
   }

   public override void Update ()
   {
      m_FPS = (1.0f / Time.deltaTime) / Time.timeScale;
   }
}
