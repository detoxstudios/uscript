// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.
//       Optionally you can compare by a GameObject's tag.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.")]
[NodeDescription("Compares the unique InstanceID of the attached GameObject variables and outputs accordingly. Optionally you can compare by a GameObject's tag.\n \nA: The first GameObject to compare.\nB: The seconds GameObject to compare.\nCompare By Tag: Whether or not to compare the GameObjects' tags instead of the objects themselves.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Compare_GameObjects")]

[FriendlyName("Compare GameObjects")]
public class uScriptCon_CompareGameObjects : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool Same { get { return m_CompareValue; } }
   public bool Different { get { return !m_CompareValue; } }

   public void In(GameObject A, GameObject B, [FriendlyName("Compare By Tag"), SocketState(false, false)] bool CompareByTag)
   {
      if (!CompareByTag)
      {
         m_CompareValue = A.GetInstanceID() == B.GetInstanceID();
      }
      else
      {
         m_CompareValue = A.tag == B.tag;
      }
   }
}