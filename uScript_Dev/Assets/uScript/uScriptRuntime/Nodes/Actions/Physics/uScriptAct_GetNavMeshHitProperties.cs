using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the properties of a NavMeshHit structure.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get NavMeshHit Properties", "Gets the properties of a NavMeshHit structure.")]
public class uScriptAct_GetNavMeshHitProperties : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("NavMeshHit", "The input NavMeshHit to get the properties of.")]
#if UNITY_5_5_OR_NEWER || UNITY_2017
      UnityEngine.AI.NavMeshHit navMeshHit,
#else
      NavMeshHit navMeshHit,
#endif
      [FriendlyName("Distance", "Distance to the point of hit.")]
      out float distance,
      [FriendlyName("Hit", "Flag set when hit.")]
      out bool hit,
      [FriendlyName("Mask", "Mask specifying NavMeshLayers at point of hit.")]
      out int mask,
      [FriendlyName("Normal", "Normal at the point of hit.")]
      out Vector3 normal,
      [FriendlyName("Position", "Position of hit.")]
      out Vector3 position
      )
   {
      distance = navMeshHit.distance;
      hit = navMeshHit.hit;
      mask = navMeshHit.mask;
      normal = navMeshHit.normal;
      position = navMeshHit.position;      
   }
}
