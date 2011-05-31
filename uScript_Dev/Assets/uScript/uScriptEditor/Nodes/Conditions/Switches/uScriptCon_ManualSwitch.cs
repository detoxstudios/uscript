// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Manually pick an Output to fire the signal to.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Manually pick an Output to fire the signal to.")]
[NodeDescription("Manually pick an Output to fire the signal to. Providing an Output To Use number smaller than 1 caps to 1 and larger than 6 caps to 6.\n \nOutput To Use: The output switch to use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Manual Switch")]
public class uScriptCon_ManualSwitch : uScriptLogic
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
      [FriendlyName("Output To Use")] int CurrentOutput
      )
   {
      // Check bounds on MaxOutputUsed
      CurrentOutput = Mathf.Clamp(CurrentOutput, 1, 6);

      m_CurrentOutput = CurrentOutput;

      // Set correct output socket to true
      if (m_SwitchOpen)
      {
         switch (m_CurrentOutput)
         {
            case 1:
               Output1(this, new System.EventArgs());
               break;

            case 2:
               Output2(this, new System.EventArgs());
               break;

            case 3:
               Output3(this, new System.EventArgs());
               break;

            case 4:
               Output4(this, new System.EventArgs());
               break;

            case 5:
               Output5(this, new System.EventArgs());
               break;

            case 6:
               Output6(this, new System.EventArgs());
               break;

            default:
               break;
         }
      }
   }
}