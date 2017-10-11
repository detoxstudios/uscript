// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows the signal to pass through each output socket in order.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Switch", "Allows the signal to pass through each output socket in order.")]
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
   private bool m_Output7 = false;
   private bool m_Output8 = false;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
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

   [FriendlyName("Output 7")]
   public bool Output7 { get { return m_Output7; } }

   [FriendlyName("Output 8")]
   public bool Output8 { get { return m_Output8; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Reset()
   public void In(bool Loop,  int MaxOutputUsed,  out int CurrentOutput)
   {
      m_Output1 = false;
      m_Output2 = false;
      m_Output3 = false;
      m_Output4 = false;
      m_Output5 = false;
      m_Output6 = false;
      m_Output7 = false;
      m_Output8 = false;

      // Check bounds on MaxOutputUsed
      Mathf.Clamp(MaxOutputUsed, 1, 8);

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
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 7;
               }
               if (Loop)
               {
                  m_CurrentOutput = 1;
               }
               else
               {
                  m_SwitchOpen = false;
               }
               break;

            case 7:
               CurrentOutput = m_CurrentOutput;
               m_Output7 = true;
               if (m_CurrentOutput < MaxOutputUsed)
               {
                  m_CurrentOutput = 8;
               }
               if (Loop)
               {
                  m_CurrentOutput = 1;
               }
               else
               {
                  m_SwitchOpen = false;
               }
               break;

            case 8:
               CurrentOutput = m_CurrentOutput;
               m_Output8 = true;
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

   public void Reset(
      [FriendlyName("Loop", "If True, the switch will loop back to 1 once the Max Output value has been reached.")]
      bool Loop,
      
      [FriendlyName("Max Output Used", "Highest valid output switch to use.")]
      [DefaultValue(8), SocketState(false, false)]
      int MaxOutputUsed,
      
      [FriendlyName("Current Output", "The output switch that last executed.")]
      out int CurrentOutput
      )
   {
      m_Output1 = false;
      m_Output2 = false;
      m_Output3 = false;
      m_Output4 = false;
      m_Output5 = false;
      m_Output6 = false;
      m_Output7 = false;
      m_Output8 = false;

      m_CurrentOutput = 1;
      CurrentOutput = 1;
      m_SwitchOpen = true;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}
