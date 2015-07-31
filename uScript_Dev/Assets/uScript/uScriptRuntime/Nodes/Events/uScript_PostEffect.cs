// uScript uScript_PostEffect.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Renderer Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a post-effect is rendered.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Post Effect Events", "Fires an event signal when a post-effect is rendered.")]
public class uScript_PostEffect : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, PostEffectEventArgs args);
  
   public class PostEffectEventArgs : System.EventArgs
   {
      [FriendlyName("Source Texture", "The source texture used in the post-effect.")]
      public RenderTexture SourceTexture { get { return m_SourceTexture; } }

      [FriendlyName("Destination Texture", "The destination texture used in the post-effect.")]
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
