// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Turns a GameObject in the specified direction.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Control GameObject (Rotate)", "Turns a GameObject in the specified direction (on the local axis of the GameObject). Please note that this is a simple move node that brute-forces the rotation of the GameObject-- it does not use the physics system. It is recomended you create your own game-specific character controller if you need more functionality.")]
public class uScriptAct_ControlGameObjectRotate : uScriptLogic
{
   public enum Direction { Forward, Backward, Left, Right, TiltLeft, TiltRight };
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject to be rotated.")]
      GameObject Target,

      [FriendlyName("Direction", "The direction to rotated the target.")]
      [SocketState(false, false)]
      Direction rotateDirection,

      [FriendlyName("Speed", "The speed you wish to rotated the target per tick. This uses a relativly small value for most cases.")]
      [DefaultValue(0.1f)]
      float Speed
      )
   {
      if (null != Target && Speed != 0f)
      {
         switch (rotateDirection)
         {
            case Direction.Forward:
               Target.transform.Rotate(Vector3.left * Speed);
               break;

            case Direction.Backward:
               Target.transform.Rotate(Vector3.right * Speed);
               break;

            case Direction.Left:
               Target.transform.Rotate(Vector3.down * Speed);
               break;

            case Direction.Right:
               Target.transform.Rotate(Vector3.up * Speed);
               break;

            case Direction.TiltLeft:
               Target.transform.Rotate(Vector3.forward * Speed);
               break;

            case Direction.TiltRight:
               Target.transform.Rotate(Vector3.back * Speed);
               break;

            default:
               break;
         }
      }
   }
}