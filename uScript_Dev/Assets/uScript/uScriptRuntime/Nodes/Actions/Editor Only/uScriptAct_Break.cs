// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Editor Only")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Pauses the game and spits out the game time and an optional text string to Unity's console.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Break", "Pauses the game and spits out the game time and an optional text string to Unity's console. Resume the game by pressing the Pause button in the Unity editor.")]
public class uScriptAct_Break : uScriptLogic
{
   private bool m_DelayedOut = false;

   [FriendlyName("Out")]
   public bool AfterDelay { get { return m_DelayedOut; } }

   public void In(
      [FriendlyName("Data", "Optional output for the Unity console when the break is triggered. Good for passing a vairable value or string at the time of the break.")]
      object LogOuput,

      [FriendlyName("Break Time", "The time when the break was triggered (Time.time).")]
      out float breakTime
      )
   {
      m_DelayedOut = false;

      float tmpBreakTime = Time.time;
      UnityEngine.Debug.Log("uScript BREAK (Time: " + tmpBreakTime.ToString() + ") (Data: " + LogOuput + ")");
      breakTime = tmpBreakTime;
      UnityEngine.Debug.Break();
      m_DelayedOut = true;
   }
}
