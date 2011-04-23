// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

[FriendlyName("Global Update")]
public class uScript_Update : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Update")]
   public event uScriptEventHandler OnUpdate;
   
   [FriendlyName("On LateUpdate")]
   public event uScriptEventHandler OnLateUpdate;

   [FriendlyName("On FixedUpdate")]
   public event uScriptEventHandler OnFixedUpdate;

   void Update()
   {
      if ( OnUpdate != null ) OnUpdate(this, new System.EventArgs());
   }

   void LateUpdate()
   {
      if ( OnLateUpdate != null ) OnLateUpdate(this, new System.EventArgs());
   }

   void FixedUpdate()
   {
      if ( OnFixedUpdate != null ) OnFixedUpdate(this, new System.EventArgs());
   }
}
