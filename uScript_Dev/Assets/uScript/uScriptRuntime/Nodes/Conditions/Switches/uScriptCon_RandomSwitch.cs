// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly picks an Output to fire the signal to.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Random Switch", "Randomly picks an Output to fire the signal to.")]
public class uScriptCon_RandomSwitch : uScriptLogic
{
   private int m_CurrentOutput = 1;
   private bool m_SwitchOpen = true;

   private bool m_Output1 = false;
   private bool m_Output2 = false;
   private bool m_Output3 = false;
   private bool m_Output4 = false;
   private bool m_Output5 = false;
   private bool m_Output6 = false;

   [FriendlyName("Output 1")]
   public bool Output1 { get { return m_Output1; } }

   [FriendlyName("Output 2")]
   public bool Output2 { get { return m_Output2; } }

   [FriendlyName("Output 3")]
   public bool Output3 { get { return m_Output3; } }

   [FriendlyName("Output 4")]
   public bool Output4 { get { return m_Output4; } }

   [FriendlyName("Output 5")]
   public bool Output5 { get { return m_Output5; } }

   [FriendlyName("Output 6")]
   public bool Output6 { get { return m_Output6; } }

   public void In(
      [FriendlyName("Max Output Used", "Highest valid output switch to use.")]
      [DefaultValue(6), SocketState(false, false)]
      int MaxOutputUsed,
      
      [FriendlyName("Current Output", "The output switch that was randomly chosen.")]
      out int CurrentOutput
      )
   {
      m_Output1 = false;
      m_Output2 = false;
      m_Output3 = false;
      m_Output4 = false;
      m_Output5 = false;
      m_Output6 = false;

      // Check bounds on MaxOutputUsed
      MaxOutputUsed = Mathf.Clamp(MaxOutputUsed, 1, 6);

      //Unity's int version of Random is exclusive for Max, not inclusive
      m_CurrentOutput = Random.Range(1, MaxOutputUsed + 1);

      // Set correct output socket to true
      if (m_SwitchOpen)
      {
         switch (m_CurrentOutput)
         {
            case 1:
               CurrentOutput = m_CurrentOutput;
               m_Output1 = true;
               break;

            case 2:
               CurrentOutput = m_CurrentOutput;
               m_Output2 = true;
               break;

            case 3:
               CurrentOutput = m_CurrentOutput;
               m_Output3 = true;
               break;

            case 4:
               CurrentOutput = m_CurrentOutput;
               m_Output4 = true;
               break;

            case 5:
               CurrentOutput = m_CurrentOutput;
               m_Output5 = true;
               break;

            case 6:
               CurrentOutput = m_CurrentOutput;
               m_Output6 = true;
               break;

            default:
               CurrentOutput = 0;
               break;
         }
      }
      else
      {
         CurrentOutput = m_CurrentOutput;
      }
   }
}