// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.
//       Optionally you can compare by a GameObject's tag.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares the unique tag, name and InstanceID of the attached GameObject variables and outputs accordingly.")]
[NodeDescription("Compares the unique InstanceID of the attached GameObject variables and outputs accordingly. Optionally you can compare by a GameObject's tag and/or name instead.\n \n" +
                 "A: The first GameObject to compare.\n" +
                 "B: The seconds GameObject to compare.\n" +
                 "Compare By Tag: Whether or not to compare the GameObjects' tags instead of the objects themselves.\n" +
                 "Compare By Name: Whether or not to compare the GameObjects' names instead of the objects themselves.\n\n" +
                 "Please note, if Compare By Name and Compare By Tag are both checked, they both much match for the 'Same' signal to fire.")]


[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Compare_GameObjects")]

[FriendlyName("Compare GameObjects")]
public class uScriptCon_CompareGameObjects : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool Same { get { return m_CompareValue; } }
   public bool Different { get { return !m_CompareValue; } }

   public void In(GameObject A, GameObject B, [FriendlyName("Compare By Tag"), SocketState(false, false)] bool CompareByTag, [FriendlyName("Compare By Name"), SocketState(false, false)] bool CompareByName)
   {
      m_CompareValue = false;
   
      if (true == CompareByTag || CompareByName)
      {
         m_CompareValue = true;
   
         if (true == CompareByTag)
         {
            m_CompareValue = m_CompareValue && A.tag == B.tag;
         }
         if (true == CompareByName)
         {
            m_CompareValue = m_CompareValue && A.name == B.name;
         }
      }
      else
      {
         m_CompareValue = A.GetInstanceID() == B.GetInstanceID();
      }
   }
}