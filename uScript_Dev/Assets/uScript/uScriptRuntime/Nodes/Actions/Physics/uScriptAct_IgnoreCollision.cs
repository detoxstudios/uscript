// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells the collision detection system ignore all collisions between the two specified GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Ignore_Collision")]

[FriendlyName("Ignore Collision", "Tells the collision detection system ignore all collisions between the two specified GameObjects. This setting is lost if you ever deactivate either the collider or rigid body on one of the specified GameObjects (even if you activate them again at a later time).")]
public class uScriptAct_IgnoreCollision : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first GameObject.")]
      GameObject A,
      
      [FriendlyName("B", "The second GameObject.")]
      GameObject B,
      
      [FriendlyName("Ignore", "True = Ignore collisions between the GameObjects, False = Enable collisions between the GameObjects.")]
      [DefaultValue(true), SocketState(false, false)]
      bool Ignore
      )
   {
      if (A.collider != null && B.collider != null)
      {
         Physics.IgnoreCollision(A.collider, B.collider, Ignore);
      }
   }
}