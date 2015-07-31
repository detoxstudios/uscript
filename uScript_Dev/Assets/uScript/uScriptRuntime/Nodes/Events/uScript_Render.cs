// uScript uScript_Render.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Renderer Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various render events take place.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Render Events", "Fires an event signal when various render events (Pre Cull, Pre Render, Post Render, Render Object, and Will Render Object) take place.")]
public class uScript_Render : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   
   [FriendlyName("On Pre Cull")]
   public event uScriptEventHandler PreCull;

   [FriendlyName("On Pre Render")]
   public event uScriptEventHandler PreRender;

   [FriendlyName("On Post Render")]
   public event uScriptEventHandler PostRender;

   [FriendlyName("On Render Object")]
   public event uScriptEventHandler RenderObject;

   [FriendlyName("On Will Render Object")]
   public event uScriptEventHandler WillRenderObject;

   void OnPreCull()
   {
      if ( PreCull != null ) PreCull(this, new System.EventArgs());
   }

   void OnPreRender()
   {
      if ( PreRender != null ) PreRender(this, new System.EventArgs());
   }

   void OnPostRender()
   {
      if ( PostRender != null ) PostRender(this, new System.EventArgs());
   }

   void OnRenderObject()
   {
      if ( RenderObject != null ) RenderObject(this, new System.EventArgs());
   }

   void OnWillRenderObject()
   {
      if ( WillRenderObject != null ) WillRenderObject(this, new System.EventArgs());
   }
}
