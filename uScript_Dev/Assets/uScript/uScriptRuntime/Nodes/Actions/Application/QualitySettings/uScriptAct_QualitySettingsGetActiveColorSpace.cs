// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the active color space.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Active Color Space", "Gets the active color space.")]
public class uScriptAct_QualitySettingsGetActiveColorSpace : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color Space", "Returns the active color space.")] out ColorSpace activeColorSpace)
   {
      activeColorSpace = QualitySettings.activeColorSpace;
   }
}
#endif