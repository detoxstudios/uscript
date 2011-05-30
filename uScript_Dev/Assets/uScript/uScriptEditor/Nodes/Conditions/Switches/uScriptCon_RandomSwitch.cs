// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly picks an Output to fire the signal to.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly picks an Output to fire the signal to.")]
[NodeDescription("Randomly picks an Output to fire the signal to.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Random Switch")]
public class uScriptCon_RandomSwitch : uScriptLogic
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
      [FriendlyName("Max Output Used"), DefaultValue(6)] int MaxOutputUsed,
      [FriendlyName("Seed"), DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Current Output")] out int CurrentOutput
      )
   {

      // Check bounds on MaxOutputUsed
      if ( MaxOutputUsed < 1 ) MaxOutputUsed = 1;
      if ( MaxOutputUsed > 6 ) MaxOutputUsed = 6;

      if (Seed > 0) { Random.seed = Seed; }

      m_CurrentOutput = Random.Range(1, MaxOutputUsed);

      // Set correct output socket to true
      if (m_SwitchOpen)
      {
         switch (m_CurrentOutput)
         {
            case 1:
               CurrentOutput = m_CurrentOutput;
               Output1(this, new System.EventArgs());
               
               break;
            case 2:
               CurrentOutput = m_CurrentOutput;
               Output2(this, new System.EventArgs());
               
               break;
            case 3:
               CurrentOutput = m_CurrentOutput;
               Output3(this, new System.EventArgs());
               
               break;
            case 4:
               CurrentOutput = m_CurrentOutput;
               Output4(this, new System.EventArgs());
               
               break;
            case 5:
               CurrentOutput = m_CurrentOutput;
               Output5(this, new System.EventArgs());
               
               break;
            case 6:
               CurrentOutput = m_CurrentOutput;
               Output6(this, new System.EventArgs());
               
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