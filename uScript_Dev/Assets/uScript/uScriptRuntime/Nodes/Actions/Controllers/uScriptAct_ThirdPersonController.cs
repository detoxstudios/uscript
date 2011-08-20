// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a Texture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Controllers")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Uses Unity's ThirdPersonController")]
[NodeDescription("Wraps all of Unity's Third Person Controller code into a uScript friendly node, for a description of the parameters please refer to Unity's ThirdPersonController.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Third_Person_Controller")]

[FriendlyName("Third Person Controller")]
public class uScriptAct_ThirdPersonController : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Instance")]
      GameObject instance,
      [FriendlyName("Idle Animation")]
      AnimationClip idleAnimation,
      [FriendlyName("Walk Animation")]
      AnimationClip walkAnimation,
      [FriendlyName("Run Animation")]
      AnimationClip runAnimation,
      [FriendlyName("Jump Pose Animation")]
      AnimationClip jumpPoseAnimation,
      [FriendlyName("Walk Max Animation Speed")]
      [SocketState(false, false)]
      [DefaultValue(0.75f)]
      float walkMaxAnimationSpeed,
      [FriendlyName("Trot Max Animation Speed")]
      [SocketState(false, false)]
      [DefaultValue(1)]
      float trotMaxAnimationSpeed,
      [FriendlyName("Run Max Animation Speed")]
      [SocketState(false, false)]
      [DefaultValue(1)]
      float runMaxAnimationSpeed,
      [FriendlyName("Jump Animation Speed")]
      [SocketState(false, false)]
      [DefaultValue(1.15)]
      float jumpAnimationSpeed,
      [FriendlyName("Land Animation Speed")]
      [SocketState(false, false)]
      [DefaultValue(1)]
      float landAnimationSpeed,
      [FriendlyName("Walk Speed")]
      [SocketState(false, false)]
      [DefaultValue(2)]
      float walkSpeed,
      [FriendlyName("Trot Speed")]
      [SocketState(false, false)]
      [DefaultValue(4)]
      float trotSpeed,
      [FriendlyName("Run Speed")]
      [SocketState(false, false)]
      [DefaultValue(6)]
      float runSpeed,
      [FriendlyName("In Air Control Acceleration")]
      [SocketState(false, false)]
      [DefaultValue(3)]
      float inAirControlAcceleration,
      [FriendlyName("Jump Height")]
      [SocketState(false, false)]
      [DefaultValue(0.5)]
      float jumpHeight,
      [FriendlyName("Gravity")]
      [SocketState(false, false)]
      [DefaultValue(20)]
      float gravity,
      [FriendlyName("Speed Smooting")]
      [SocketState(false, false)]
      [DefaultValue(10)]
      float speedSmoothing,
      [FriendlyName("Rotate Speed")]
      [SocketState(false, false)]
      [DefaultValue(500)]
      float rotateSpeed,
      [FriendlyName("Trot After Seconds")]
      [SocketState(false, false)]
      [DefaultValue(3)]
      float trotAfterSeconds,
      [FriendlyName("Can Jump")]
      [SocketState(false, false)]
      [DefaultValue(true)]
      bool canJump
   )
   {
#if !(USCRIPT_DEV)
      Component c = instance.GetComponent( "ThirdPersonController" );

      if ( null == c ) 
      {
         c = instance.AddComponent( "ThirdPersonController" );
      
         if ( null == c )
         {
            uScriptDebug.Log( "Could not add ThirdPersonController to " + instance.name, uScriptDebug.Type.Error );
            return;
         }
      }

      ThirdPersonController controller = (ThirdPersonController) c;

      controller.idleAnimation     = idleAnimation;
      controller.walkAnimation     = walkAnimation;
      controller.runAnimation      = runAnimation;
      controller.jumpPoseAnimation = jumpPoseAnimation;

      controller.walkMaxAnimationSpeed   = walkMaxAnimationSpeed;
      controller.trotMaxAnimationSpeed   = trotMaxAnimationSpeed;
      controller.runMaxAnimationSpeed    = runMaxAnimationSpeed;
      controller.jumpAnimationSpeed      = jumpAnimationSpeed;
      controller.landAnimationSpeed      = landAnimationSpeed;
      controller.walkSpeed               = walkSpeed;
      controller.trotSpeed               = trotSpeed;
      controller.runSpeed                = runSpeed;
      controller.inAirControlAcceleration= inAirControlAcceleration;
      controller.jumpHeight              = jumpHeight;
      controller.gravity                 = gravity;
      controller.speedSmoothing          = speedSmoothing;
      controller.rotateSpeed             = rotateSpeed;
      controller.trotAfterSeconds        = trotAfterSeconds;
      controller.canJump                 = canJump;
#endif
   }
}