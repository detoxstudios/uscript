// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a new graphics quality level.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Quality Level", "Sets a new graphics quality level.")]
public class uScriptAct_QualitySettingsSetLevel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Quality Level", "The quality index to set.")]
      int qualityLevel,

      [FriendlyName("Apply Expensive Changes", "Should expensive changes be applied (Anti-aliasing, etc.). Applying some changes the quality level can be an expensive operation if the new level has a different anti-aliasing setting. It's fine to change the level when applying in-game quality options, but if you want to dynamically adjust quality level at runtime, it is best to have this unchecked so that expensive changes are not always applied.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool applyExpensiveChanges
      )
   {
      string[] qualityNames = QualitySettings.names;

      if (qualityLevel < qualityNames.Length || qualityLevel > -1)
      {
         QualitySettings.SetQualityLevel(qualityLevel, applyExpensiveChanges);
      }
      else
      {
         uScriptDebug.Log("[Set Quality Level] The index supplied is outside the index range of available quality settings.");
      }

      
   }
}