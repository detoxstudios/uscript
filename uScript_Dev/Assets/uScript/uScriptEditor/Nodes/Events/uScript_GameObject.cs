// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/GameObject Events")]

[FriendlyName("GameObject Events")]
public class uScript_GameObject : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Enable")]
   public event uScriptEventHandler EnableEvent;

   [FriendlyName("On Disable")]
   public event uScriptEventHandler DisableEvent;

   [FriendlyName("On Destroy")]
   public event uScriptEventHandler DestroyEvent;

   void OnEnable()
   {
      if ( EnableEvent != null ) EnableEvent(this, new System.EventArgs());
   }
   
   void OnDisable()
   {
      if ( DisableEvent != null ) DisableEvent(this, new System.EventArgs());
   }

   void OnDestroy()
   {
      if ( DestroyEvent != null ) DestroyEvent(this, new System.EventArgs());
   }
}
