// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/SpriteRenderer")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Gets SpriteRenderer bounds")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("SpriteRenderer Get Bounds", "Gets various Vector3's describing the bounds of a SpriteRenderer.")]
public class uScriptAct_GetSpriteRendererBounds : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Sprite", "The SpriteRenderer to get the bounds of.")]
      GameObject sprite,
      [FriendlyName("Center", "The center of the bounds box.")]
      out Vector3 center,
      [FriendlyName("Extents", "The extents of the bounds box.")]
      out Vector3 extents,
      [FriendlyName("Min", "The minimal point of the bounds box - equal to center - extents.")]
      out Vector3 min,
      [FriendlyName("Max", "The maximal point of the bounds box - equal to center + extents.")]
      out Vector3 max,
      [FriendlyName("Size", "The size of the bounds box - equal to twice the extents.")]
      out Vector3 size
   )
   {
      SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
      if (renderer != null)
      {
         Bounds bounds = renderer.bounds;
         center = bounds.center;
         extents = bounds.extents;
         min = bounds.min;
         max = bounds.max;
         size = bounds.size;
      }
      else
      {
         center = Vector3.zero;
         extents = Vector3.zero;
         min = Vector3.zero;
         max = Vector3.zero;
         size = Vector3.zero;
      }
   }
}