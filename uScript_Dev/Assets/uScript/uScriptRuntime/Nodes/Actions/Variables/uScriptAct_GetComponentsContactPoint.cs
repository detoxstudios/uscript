// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/ContactPoint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a ContactPoint.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (ContactPoint)", "Gets the components of a ContactPoint as floats.")]
public class uScriptAct_GetComponentsContactPoint : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input ContactPoint", "The input vector to get components of.")]
      ContactPoint ContactPoint,
      
      [FriendlyName("Point", "The point of contact.")]
      out Vector3 point,

      [FriendlyName("Normal", "Normal of the contact point.")]
      out Vector3 normal,
      
      [FriendlyName("This Collider", "The first collider in contact.")]
      [SocketState(false, false)]
      out Collider ThisCollider,
      
      [FriendlyName("Other Collider", "The other collider in contact.")]
      [SocketState(false, false)]
      out Collider OtherCollider
      )
   {
      normal = ContactPoint.normal;
      point  = ContactPoint.point;
      ThisCollider  = ContactPoint.thisCollider;
      OtherCollider = ContactPoint.otherCollider;
   }
}
