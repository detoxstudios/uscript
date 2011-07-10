// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Allows the signal to pass through each output socket in order.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows the signal to pass through each output socket in order.")]
[NodeDescription("Allows the signal to pass through each output socket in order.\n \nMax Output Used: Highest valid output switch to use.\nCurrent Output (out): The output switch that last executed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Switch")]

[FriendlyName("Switch")]
public class uScriptCon_Switch : uScriptLogic
{
   private int m_CurrentOutput = 1;
   private bool m_SwitchOpen = true;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   [FriendlyName("Output 1")]
   public event uScriptEventHandler Output1;
   [FriendlyName("Output 2")]
   public event uScriptEventHandler Output2;
   [FriendlyName("Output 3")]
   public event uScriptEventHandler Output3;
   [FriendlyName("Output 4")]
   public event uScriptEventHandler Output4;
   [FriendlyName("Output 5")]
   public event uScriptEventHandler Output5;
   [FriendlyName("Output 6")]
   public event uScriptEventHandler Output6;

   public void In(
      bool Loop,
      [FriendlyName("Max Output Used"), DefaultValue(6), SocketState(false, false)] int MaxOutputUsed,
      [FriendlyName("Current Output")] out int CurrentOutput)
   {
      // Check bounds on MaxOutputUsed
      Mathf.Clamp(MaxOutputUsed, 1, 6);

      // Set correct output socket to true
      if (m_SwitchOpen)
      {
         switch (m_CurrentOutput)
         {
            case 1:
               CurrentOutput = m_CurrentOutput;
               Output1(this, new System.EventArgs());
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
               Output2(this, new System.EventArgs());
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
               Output3(this, new System.EventArgs());
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
               Output4(this, new System.EventArgs());
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
               Output5(this, new System.EventArgs());
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
               Output6(this, new System.EventArgs());
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
      m_CurrentOutput = 1;
      CurrentOutput = 1;
      m_SwitchOpen = true;
   }
}