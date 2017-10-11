// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Switches")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Manually pick an Output to fire the signal to.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Manual Switch", "Manually pick an Output to fire the signal to.\n\nThe specified Output To Use value will be clamped within the range of 1 to 8.")]
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
   [FriendlyName("Output 7")]
   public event uScriptEventHandler Output7;
   [FriendlyName("Output 8")]
   public event uScriptEventHandler Output8;

   public void In(
      [FriendlyName("Output To Use", "The output switch to use.")]
      int CurrentOutput
      )
   {
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

            case 7:
               Output7(this, new System.EventArgs());
               break;

            case 8:
               Output8(this, new System.EventArgs());
               break;

            default:
               break;
         }
      }
   }
}