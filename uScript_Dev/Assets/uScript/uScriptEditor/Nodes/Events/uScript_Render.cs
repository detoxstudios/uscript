// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Renderer))]

[NodePath("Events/Renderer Events")]

[FriendlyName("Render Events")]
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
