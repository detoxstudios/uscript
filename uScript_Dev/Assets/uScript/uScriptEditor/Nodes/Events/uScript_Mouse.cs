// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Collider), typeof(GUIElement))]

[NodePath("Events")]
[FriendlyName("Mouse Events")]
public class uScript_Mouse : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Mouse Enter")]
   public event uScriptEventHandler OnEnter;
   
   [FriendlyName("On Mouse Over")]
   public event uScriptEventHandler OnOver;

   [FriendlyName("On Mouse Exit")]
   public event uScriptEventHandler OnExit;

   [FriendlyName("On Mouse Down")]
   public event uScriptEventHandler OnDown;

   [FriendlyName("On Mouse Up")]
   public event uScriptEventHandler OnUp;

   [FriendlyName("On Mouse Drag")]
   public event uScriptEventHandler OnDrag;

   void OnMouseEnter()
   {
      if ( OnEnter != null ) OnEnter(this, new System.EventArgs());
   }

   void OnMouseOver()
   {
      if ( OnOver != null ) OnOver(this, new System.EventArgs());
   }

   void OnMouseExit()
   {
      if ( OnExit != null ) OnExit(this, new System.EventArgs());
   }

   void OnMouseDown()
   {
      if ( OnDown != null ) OnDown(this, new System.EventArgs());
   }

   void OnMouseUp()
   {
      if ( OnUp != null ) OnUp(this, new System.EventArgs());
   }

   void OnMouseDrag()
   {
      if ( OnDrag != null ) OnDrag(this, new System.EventArgs());
   }
}
