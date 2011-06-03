// uScript uScript_PostEffect.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when a post-effect is rendered.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Renderer Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a post-effect is rendered.\n \nSource Texture: The source texture used in the post-effect.\nDestination Texture: The destination texture used in the post-effect.")]
[NodeDescription("Fires an event signal when a post-effect is rendered.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Post Effect Events")]
public class uScript_PostEffect : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, PostEffectEventArgs args);
  
   public class PostEffectEventArgs : System.EventArgs
   {
      [FriendlyName("Source Texture")]
      public RenderTexture SourceTexture { get { return m_SourceTexture; } }

      [FriendlyName("Destination Texture")]
      public RenderTexture DestinationTexture { get { return m_DestinationTexture; } }

      private RenderTexture m_SourceTexture;
      private RenderTexture m_DestinationTexture;
     
      public PostEffectEventArgs(RenderTexture source, RenderTexture dest)
      {
         m_SourceTexture      = source;
         m_DestinationTexture = dest;
      }
   }

   [FriendlyName("On Render Image")]
   public event uScriptEventHandler RenderImage;

   void OnRenderImage(RenderTexture source, RenderTexture dest)
   {
      if ( null != RenderImage ) RenderImage( this, new PostEffectEventArgs(source, dest) );     
   }
}
