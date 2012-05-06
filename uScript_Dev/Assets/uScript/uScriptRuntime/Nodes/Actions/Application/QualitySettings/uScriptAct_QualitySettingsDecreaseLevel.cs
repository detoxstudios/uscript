// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Decreases the current quality to the next lower level.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Decrease Quality Level", "Decreases the current quality to the next lower level.")]
public class uScriptAct_QualitySettingsDecreaseLevel : uScriptLogic
{
   public bool Out { get { return true; } }

#if UNITY_3_5
   public void In(
      [FriendlyName("Apply Expensive Changes", "Should expensive changes be applied (Anti-aliasing, etc.). Applying some changes the quality level can be an expensive operation if the new level has a different anti-aliasing setting. It's fine to change the level when applying in-game quality options, but if you want to dynamically adjust quality level at runtime, it is best to have this unchecked so that expensive changes are not always applied.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool applyExpensiveChanges
      )
   {
      QualitySettings.DecreaseLevel(applyExpensiveChanges);
   }
#else
   public void In()
   {
      QualitySettings.DecreaseLevel();
   }
#endif
}