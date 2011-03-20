// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being used as a trigger (IsTrigger is checked/true).

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Trigger")]
public class uScript_Triggers : uScriptEvent
{
   public event uScriptEventHandler OnEnterTrigger;
   public event uScriptEventHandler OnExitTrigger;
   public event uScriptEventHandler WhileInsideTrigger;


   void OnTriggerEnter(Collider other)
   {
      uScript_EventHandler.DoEvent(this, OnEnterTrigger, new object[] { });
   }

   void OnTriggerExit(Collider other)
   {
      uScript_EventHandler.DoEvent(this, OnExitTrigger, new object[] { });
   }

   void OnTriggerStay(Collider other)
   {
      uScript_EventHandler.DoEvent(this, WhileInsideTrigger, new object[] { });
   }


}
