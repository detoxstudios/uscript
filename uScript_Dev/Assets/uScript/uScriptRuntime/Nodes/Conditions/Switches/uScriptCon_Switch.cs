// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows the signal to pass through each output socket in order.")]
/* M */[NodeDescription("Allows the signal to pass through each output socket in order.\n \nMax Output Used: Highest valid output switch to use.\nCurrent Output (out): The output switch that last executed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Switch")]

[FriendlyName("Switch")]
public class uScriptCon_Switch : uScriptLogic
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
      bool Loop,
      [FriendlyName("Max Output Used"), DefaultValue(6), SocketState(false, false)] int MaxOutputUsed,
      [FriendlyName("Current Output")] out int CurrentOutput)
   {
      m_Output1 = false;
      m_Output2 = false;
      m_Output3 = false;
      m_Output4 = false;
      m_Output5 = false;
      m_Output6 = false;

      // Check bounds on MaxOutputUsed
      Mathf.Clamp(MaxOutputUsed, 1, 6);

      // Set correct output socket to true
      if (m_SwitchOpen)
      {
         switch (m_CurrentOutput)
         {
            case 1:
               CurrentOutput = m_CurrentOutput;
               m_Output1 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 2;
               }
               else
               {
                  if (Loop)
                  {
                     m_CurrentOutput = 1;
                  }
                  else
                  {
                     m_SwitchOpen = false;
                  }
               }
               break;

            case 2:
               CurrentOutput = m_CurrentOutput;
               m_Output2 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 3;
               }
               else
               {
                  if (Loop)
                  {
                     m_CurrentOutput = 1;
                  }
                  else
                  {
                     m_SwitchOpen = false;
                  }
               }
               break;

            case 3:
               CurrentOutput = m_CurrentOutput;
               m_Output3 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 4;
               }
               else
               {
                  if (Loop)
                  {
                     m_CurrentOutput = 1;
                  }
                  else
                  {
                     m_SwitchOpen = false;
                  }
               }
               break;

            case 4:
               CurrentOutput = m_CurrentOutput;
               m_Output4 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 5;
               }
               else
               {
                  if (Loop)
                  {
                     m_CurrentOutput = 1;
                  }
                  else
                  {
                     m_SwitchOpen = false;
                  }
               }
               break;

            case 5:
               CurrentOutput = m_CurrentOutput;
               m_Output5 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 6;
               }
               else
               {
                  if (Loop)
                  {
                     m_CurrentOutput = 1;
                  }
                  else
                  {
                     m_SwitchOpen = false;
                  }
               }
               break;

            case 6:
               CurrentOutput = m_CurrentOutput;
               m_Output6 = true;
               if (Loop)
               {
                  m_CurrentOutput = 1;
               }
               else
               {
                  m_SwitchOpen = false;
               }
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

   public void Reset(bool Loop, [FriendlyName("Max Output Used"), DefaultValue(6)] int MaxOutputUsed, [FriendlyName("Current Output")] out int CurrentOutput)
   {
      m_Output1 = false;
      m_Output2 = false;
      m_Output3 = false;
      m_Output4 = false;
      m_Output5 = false;
      m_Output6 = false;

      m_CurrentOutput = 1;
      CurrentOutput = 1;
      m_SwitchOpen = true;
   }
}