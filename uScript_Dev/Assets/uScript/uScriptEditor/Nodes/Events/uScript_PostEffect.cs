// uScript uScript_Input.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript_Input contains all global events related to input. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events")]

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
