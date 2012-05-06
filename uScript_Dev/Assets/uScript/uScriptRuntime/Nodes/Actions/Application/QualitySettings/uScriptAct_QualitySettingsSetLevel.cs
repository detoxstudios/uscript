// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a new graphics quality level.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Quality Level", "Sets a new graphics quality level.")]
public class uScriptAct_QualitySettingsSetLevel : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Quality Level", "Returns the names of the available Quality Settings as a string list. When building, quality levels that are not used for that platform are stripped. You should not expect a given quality setting to be at a given index. It is best to query the available quality settings first using by using the Get Index From Quality Name node and using the returned index.")]
      int qualityLevel,

      [FriendlyName("Should expensive changes be applied (Anti-aliasing, etc.). Applying some changes the quality level can be an expensive operation if the new level has a different anti-aliasing setting. It's fine to change the level when applying in-game quality options, but if you want to dynamically adjust quality level at runtime, it is best to have this unchecked so that expensive changes are not always applied.")]
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
#endif