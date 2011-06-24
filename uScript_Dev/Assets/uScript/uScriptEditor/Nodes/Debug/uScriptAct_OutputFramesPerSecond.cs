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
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Output FPS")]
public class uScriptAct_OutputFramesPerSecond : uScriptLogic
{

   private float m_UpdateInterval = 0.25f;
   private float m_TimeRemaining = 0f;
   private float m_FramesAccumulated = 0f; // FPS accumulated over the interval
   private float m_FramesRendered = 0f; // Frames drawn over the interval
   private float m_FPS = 0f;

   public bool Out { get { return true; } }

   public void In([FriendlyName("FPS")] out float FPS)
   {

      m_TimeRemaining = m_UpdateInterval;
      FPS = m_FPS;

   }

   public override void Update ()
   {
      m_TimeRemaining -= Time.deltaTime;
      m_FramesAccumulated += Time.timeScale/Time.deltaTime;
      ++m_FramesRendered;
    
       // Interval ended - update GUI text and start new interval
       if( m_TimeRemaining <= 0.0f )
       {
           m_FPS = m_FramesAccumulated / m_FramesRendered;
           m_TimeRemaining = m_UpdateInterval;
           m_FramesAccumulated = 0f;
           m_FramesRendered = 0f;
       }

   }
}
