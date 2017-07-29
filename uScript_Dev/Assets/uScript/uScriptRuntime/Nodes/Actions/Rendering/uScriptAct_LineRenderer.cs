// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios LLC" file="uScriptAct_LineRenderer.cs">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#if UNITY_5 || UNITY_2017

using UnityEngine;
using UnityEngine.Rendering;

// ReSharper disable ForCanBeConvertedToForeach

[NodePath("Actions/Rendering")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("The line renderer is used to draw free-floating lines in 3D space.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Line Renderer",
   "The line renderer is used to draw free-floating lines in 3D space.\n\nNote: This node will create a new GameObject with a LineRenderer component when enabled. The GameObject is destroyed when the node is disabled."
   )]
public class uScriptAct_LineRenderer : uScriptLogic
{
   private LineRenderer lineRenderer;

   public bool Out
   {
      get
      {
         return true;
      }
   }

   // Parameter attributes are applied below in Disable()
   public void Enable(
      Vector3[] positions,
      float startWidth,
      float endWidth,
      Color startColor,
      Color endColor,
      ShadowCastingMode shadowCastingMode,
      bool receiveShadows,
      bool useWorldSpace)
   {
      if (this.lineRenderer == null)
      {
         this.lineRenderer = new GameObject("LineRenderer", typeof(LineRenderer)).GetComponent<LineRenderer>();
      }

      this.UpdateLine(positions, startWidth, endWidth, startColor, endColor, shadowCastingMode, receiveShadows, useWorldSpace);
   }

   // Parameter attributes are applied below in Disable()
   [FriendlyName("Update")]
   public void UpdateLine(
      Vector3[] positions,
      float startWidth,
      float endWidth,
      Color startColor,
      Color endColor,
      ShadowCastingMode shadowCastingMode,
      bool receiveShadows,
      bool useWorldSpace)
   {
      if (this.lineRenderer == null)
      {
         return;
      }

      if (positions.Length < 2)
      {
         positions = new[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1) };
      }

      this.lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

#if UNITY_5_5_OR_NEWER || UNITY_2017
      this.lineRenderer.SetPositions(positions);
#else
      for (int i = 0; i < positions.Length; i++)
      {
         this.lineRenderer.SetPosition(i, positions[i]);
      }
#endif

#if UNITY_5_5_OR_NEWER || UNITY_2017
      this.lineRenderer.startColor = startColor;
      this.lineRenderer.endColor = endColor;
      this.lineRenderer.startWidth = startWidth;
      this.lineRenderer.endWidth = endWidth;
#else
      this.lineRenderer.SetColors(startColor, endColor);
      this.lineRenderer.SetWidth(startWidth, endWidth);
#endif

      this.lineRenderer.shadowCastingMode = shadowCastingMode;
      this.lineRenderer.receiveShadows = receiveShadows;
      this.lineRenderer.useWorldSpace = useWorldSpace;
   }

   public void Disable(
      [FriendlyName("Positions", "These properties describe an array of Vector3 points to connect.")] Vector3[]
         positions,

      [FriendlyName("StartWidth", "Width at the first line position.")] [DefaultValue(1), SocketState(false, false)] float startWidth,
      [FriendlyName("EndWidth", "Width at the last line position.")] [DefaultValue(1), SocketState(false, false)] float
         endWidth,
      [FriendlyName("Start Color",
         "Color at the first line position. Note: This has no effect unless the attached material uses a vertex shader."
         )] [DefaultValue(typeof(Color), new float[] { 1, 1, 1 }), SocketState(false, false)] Color startColor,
      [FriendlyName("End Color",
         "Color at the last line position. Note: This has no effect unless the attached material uses a vertex shader.")
      ] [DefaultValue(typeof(Color), new float[] { 1, 1, 1 }), SocketState(false, false)] Color endColor,

      //[FriendlyName("Materials", "These properties describe an array of Materials used for rendering the line.The line will be drawn once for each material in the array.")]
      [FriendlyName("Cast Shadows",
         "Determines whether the line casts shadows, whether they should be cast from one or both sides of the line, or whether the line should only cast shadows and not otherwise be drawn."
         )] [DefaultValue(ShadowCastingMode.On), SocketState(false, false)] ShadowCastingMode shadowCastingMode,
      [FriendlyName("Receive Shadows", "If enabled, the line receives shadows.")] [DefaultValue(true), SocketState(false, false)] bool
         receiveShadows,

      //[FriendlyName("Use Light Probes", "Check this box to enable Light Probes on the line.")] [DefaultValue(true)] 
      //[FriendlyName("Light Probe Anchor", "If set, this will be used as the interpolation point instead of the Transform position.")]

      [FriendlyName("Use World Space",
         "If enabled, the points are considered as world-space coordinates, instead of being subject to the transform of the GameObject to which this component is attached."
         )] [DefaultValue(true), SocketState(false, false)] bool useWorldSpace
      )
   {
      if (this.lineRenderer == null)
      {
         return;
      }

      // ReSharper disable once AccessToStaticMemberViaDerivedType
      GameObject.Destroy(this.lineRenderer.gameObject);
   }
}

#endif
