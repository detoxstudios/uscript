// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires out any socket where the target matches its corresponding socket value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("String Switch", "Fires out any socket where the target matches its corresponding socket value.")]
public class uScriptCon_StringSwitch : uScriptLogic
{
   private bool m_CompareValueNone = false;
   private bool m_CompareValueAny = false;
   private bool m_CompareValueAll = false;

   private bool m_CompareValueA = false;
   private bool m_CompareValueB = false;
   private bool m_CompareValueC = false;
   private bool m_CompareValueD = false;

   [FriendlyName("None", "Will fire if no output socket value matches a target value.")]
   public bool None { get { return m_CompareValueNone; } }

   [FriendlyName("Any", "Will fire if any output socket value matches a target value.")]
   public bool Any { get { return m_CompareValueAny; } }

   [FriendlyName("All", "Will fire if all the output socket values matches a target value.")]
   public bool All { get { return m_CompareValueAll; } }

   [FriendlyName("A Matched", "Will fire if the A output socket value matches a target value.")]
   public bool AMatch { get { return m_CompareValueA; } }

   [FriendlyName("B Matched", "Will fire if the B output socket value matches a target value.")]
   public bool BMatch { get { return m_CompareValueB; } }

   [FriendlyName("C Matched", "Will fire if the C output socket value matches a target value.")]
   public bool CMatch { get { return m_CompareValueC; } }

   [FriendlyName("D Matched", "Will fire if the D output socket value matches a target value.")]
   public bool DMatch { get { return m_CompareValueD; } }

   public void In(
      [FriendlyName("Target", "The string value to compare against the socket values to determine which out sockets should fire.")]
      string[] Targets,

      [FriendlyName("A", "A ouput socket value.")]
      string A,

      [FriendlyName("B", "B ouput socket value.")]
      string B,

      [FriendlyName("C", "C ouput socket value.")]
      string C,

      [FriendlyName("D", "D ouput socket value.")]
      string D
      )
   {
      bool tmpA = false;
      bool tmpB = false;
      bool tmpC = false;
      bool tmpD = false;
      bool tmpNone = false;
      bool tmpAny = false;
      bool tmpAll = false;

      foreach (string target in Targets)
      {
         if (!tmpA)
         {
            tmpA = target == A;
         }
         if (!tmpB)
         {
            tmpB = target == B;
         }
         if (!tmpC)
         {
            tmpC = target == C;
         }
         if (!tmpD)
         {
            tmpD = target == D;
         }
      }

      if (tmpA || tmpB || tmpC || tmpD)
      {
         tmpAny = true;
      }
      else
      {
         tmpNone = true;
      }

      if (tmpA && tmpB && tmpC && tmpD)
      {
         tmpAll = true;
      }

      m_CompareValueA = tmpA;
      m_CompareValueB = tmpB;
      m_CompareValueC = tmpC;
      m_CompareValueD = tmpD;

      m_CompareValueNone = tmpNone;
      m_CompareValueAny = tmpAny;
      m_CompareValueAll = tmpAll;
   }
}
