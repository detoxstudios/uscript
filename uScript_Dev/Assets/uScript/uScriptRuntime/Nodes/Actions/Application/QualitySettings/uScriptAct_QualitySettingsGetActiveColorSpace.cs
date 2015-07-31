// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the active color space.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Active Color Space", "Gets the active color space.")]
public class uScriptAct_QualitySettingsGetActiveColorSpace : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color Space", "Returns the active color space.")] out ColorSpace activeColorSpace)
   {
      activeColorSpace = QualitySettings.activeColorSpace;
   }
}
