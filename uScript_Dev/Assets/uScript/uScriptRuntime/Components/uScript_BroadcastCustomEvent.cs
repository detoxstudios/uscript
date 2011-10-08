// Copyright 2011 Detox Studios LLC
// Desc: Assign this component to GameObjects you wish to have broadcast
// Custom Events that uScript can listen for.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Events/Broadcast Custom Event")]
public class uScript_BroadcastCustomEvent : MonoBehaviour
{
   void uScript_Broadcast_Custom_Event(string eventName)
   {
      uScriptCustomEvent.BroadcastCustomEvent(eventName, null, gameObject);
   }
}
