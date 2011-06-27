// uScript uScript_Visibility.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when various GameObject visibility events (Became Visible, Became Invisible) take place.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Visibility")]
[NodeComponentType(typeof(Renderer))]

[NodePath("Events/GameObject Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various GameObject visibility events (Became Visible, Became Invisible) take place.")]
[NodeDescription("Fires an event signal when various GameObject visibility events (Became Visible, Became Invisible) take place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Visibility Events")]
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
