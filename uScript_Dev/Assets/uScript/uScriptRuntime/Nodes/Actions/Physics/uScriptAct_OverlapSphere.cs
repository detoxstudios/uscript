// uScript Action Node
// (C) 2020 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2020 by Detox Studios LLC")]
[NodeToolTip("Check if there are any Colliders inside a sphere.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Overlap Sphere", "Check for colliders within a sphere volume specified by position and radius.")]
public class uScriptAct_OverlapSphere : uScriptLogic
{
   private bool m_NotIntersecting = false;
   private bool m_Intersecting = false;

   public bool NotIntersecting { get { return m_NotIntersecting; } }
   public bool Intersecting { get { return m_Intersecting; } }

   public void In(
      [FriendlyName("Position", "The position of the sphere.")]
      Vector3 Position,

      [FriendlyName("Radius", "The radius of the sphere.")]
      [DefaultValue(1f)]
      float radius,

      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when performing the overlap sphere test.")]
      [SocketState(false, false)]
      LayerMask layerMask,

      [FriendlyName("Include Masked Layers", "If true, the sphere will test against the masked layers, otherwise it will test against all layers excluding the masked layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool include,

      [FriendlyName("Trigger Interaction", "How to deal with triggers when doing the overlap test (Use Global Setting, Ignore, or Collide).")]
      [SocketState(false, false)]
      QueryTriggerInteraction triggerInteraction,

      [FriendlyName("Intersecting GameObjects", "The GameObjects that were intersecting with the sphere.")]
      out GameObject[] HitObjects
   )
   {
      bool hitTrue = false;

      if (!include) layerMask = ~layerMask;

      List<GameObject> tmpHitObjects = new List<GameObject>();

      Collider[] collisions = Physics.OverlapSphere(Position, radius, layerMask, triggerInteraction);
      for (int i = 0; i < collisions.Length; i++)
      {
         tmpHitObjects.Add(collisions[i].gameObject);
         hitTrue = true;
      }

      HitObjects = tmpHitObjects.ToArray();

      m_Intersecting = hitTrue;
      m_NotIntersecting = !m_Intersecting;
   }
}