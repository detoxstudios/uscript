// uScript Action Node
// (C) 2020 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2020 by Detox Studios LLC")]
[NodeToolTip("Check if there are any Colliders inside a box.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Overlap Box", "Check for colliders within a box volume specified by center, extents and orientation.")]
public class uScriptAct_OverlapBox : uScriptLogic
{
   private bool m_NotIntersecting = false;
   private bool m_Intersecting = false;

   public bool NotIntersecting { get { return m_NotIntersecting; } }
   public bool Intersecting { get { return m_Intersecting; } }

   public void In(
      [FriendlyName("Center", "The center of the box.")]
      Vector3 center,

      [FriendlyName("Extents", "The extents of the box.")]
      Vector3 extents,

      [FriendlyName("Orientation", "The orientation of the box.")]
      Quaternion orientation,

      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when performing the overlap box test.")]
      [SocketState(false, false)]
      LayerMask layerMask,

      [FriendlyName("Include Masked Layers", "If true, the box will test against the masked layers, otherwise it will test against all layers excluding the masked layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool include,

      [FriendlyName("Trigger Interaction", "How to deal with triggers when doing the overlap test (Use Global Setting, Ignore, or Collide).")]
      [SocketState(false, false)]
      QueryTriggerInteraction triggerInteraction,

      [FriendlyName("Intersecting GameObjects", "The GameObjects that were intersecting with the box.")]
      out GameObject[] HitObjects
   )
   {
      bool hitTrue = false;

      if (!include) layerMask = ~layerMask;

      List<GameObject> tmpHitObjects = new List<GameObject>();

      Collider[] collisions = Physics.OverlapBox(center, extents, orientation, layerMask, triggerInteraction);
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