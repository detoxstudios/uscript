// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Editor only. Pauses the game and spits out the game time and an optional text string to Unity's console.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Editor Only")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Pauses the game and spits out the game time and an optional text string to Unity's console.")]
[NodeDescription("Pauses the game and spits out the game time and an optional text string to Unity's console. Restart the game by pressing the Play button in the Unity editor.\nData: Optional output for the Unity console when the break is triggered. Good for passing a vairable value or string at the time of the break.\nBreak Time: The time when the break was triggered (Time.time).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Break")]
public class uScriptAct_Break : uScriptLogic
{
   private bool m_DelayedOut = false;

   [FriendlyName("Out")]
   public bool AfterDelay { get { return m_DelayedOut; } }

   public void In([FriendlyName("Data")] object LogOuput, [FriendlyName("Break Time")] out float breakTime)
   {
      m_DelayedOut = false;

      float tmpBreakTime = Time.time;
      UnityEngine.Debug.Log("uScript BREAK (Time: " + tmpBreakTime.ToString() + ") (Data: " + LogOuput + ")");
      breakTime = tmpBreakTime;
      UnityEngine.Debug.Break();
      m_DelayedOut = true;
   }
}
