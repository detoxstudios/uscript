// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/ContactPoint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a ContactPoint.")]
[NodeDescription("Gets the components of a ContactPoint as floats.\n \nInput ContactPoint: The input vector to get components of.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_ContactPoint_Components")]

[FriendlyName("Get Components (ContactPoint)")]
public class uScriptAct_GetComponentsContactPoint : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input ContactPoint")]ContactPoint ContactPoint, 
      [FriendlyName("Point")]out Vector3 point, 
      [FriendlyName("Normal")]out Vector3 normal, 
      [FriendlyName("This Collider"), SocketState(false, false)]out Collider ThisCollider, 
      [FriendlyName("Other Collider"), SocketState(false, false)]out Collider OtherCollider)
   {
      normal = ContactPoint.normal;
      point  = ContactPoint.point;
      ThisCollider  = ContactPoint.thisCollider;
      OtherCollider = ContactPoint.otherCollider;
   }
}