// uScript uScript_Mouse.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the mouse enters, is over, exits, is pressed down, released, or dragged over Instance.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Mouse Cursor Events", "Fires an event signal when the mouse enters, is over, exits, is pressed down, released, or dragged over Instance.")]
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
