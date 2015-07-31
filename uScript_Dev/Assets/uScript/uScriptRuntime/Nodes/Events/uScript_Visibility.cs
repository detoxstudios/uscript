// uScript uScript_Visibility.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/GameObject Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various GameObject visibility events (Became Visible, Became Invisible) take place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Visibility Events", "Fires an event signal when various GameObject visibility events (Became Visible, Became Invisible) take place.")]
public class uScript_Visibility : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Became Visible")]
   public event uScriptEventHandler BecameVisible;

   [FriendlyName("On Became Invisible")]
   public event uScriptEventHandler BecameInvisible;

   void OnBecameVisible()
   {
      if ( BecameVisible != null ) BecameVisible(this, new System.EventArgs());
   }
   
   void OnBecameInvisible()
   {
      if ( BecameInvisible != null ) BecameInvisible(this, new System.EventArgs());
   }
}
