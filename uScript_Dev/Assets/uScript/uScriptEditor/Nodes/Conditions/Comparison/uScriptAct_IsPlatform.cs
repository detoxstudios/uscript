// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Outputs true if the current platform is one of the attached platform variables.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Action/Misc")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Outputs true if the current platform is one of the attached platform variables.")]
[NodeDescription("Outputs true if the current platform is one of the attached platform variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Is Platform")]
public class uScriptAct_IsPlatform : uScriptLogic
{
   private bool m_IsPlatform = false;

   [FriendlyName("Is Platform")]
   public bool IsPlatform { get { return m_IsPlatform; } }
   [FriendlyName("Is Not Platform")]
   public bool IsNotPlatform { get { return !m_IsPlatform; } }
    
   public void In([FriendlyName("Valid Platforms")] UnityEngine.RuntimePlatform[] ValidPlatforms)
   {
      List<UnityEngine.RuntimePlatform> list = new List<UnityEngine.RuntimePlatform>(ValidPlatforms);
      m_IsPlatform = list.Contains(Application.platform);
   }
}
