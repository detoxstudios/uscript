// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a Texture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Controllers")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Uses Unity's PlatfomerController")]
[NodeDescription("Wraps all of Unity's Platformer Controller code into a uScript friendly node, for a description of the parameters please refer to Unity's PlatformerController.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Platfomer_Controller")]

[FriendlyName("Platformer Controller")]
public class uScriptAct_PlatformerController : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Instance")]
      GameObject instance,
      [FriendlyName("Can Control")]
      bool canControl,
      [FriendlyName("Spawn Point")]
      Transform spawnPoint,
      [SocketState(false, false)]
      [FriendlyName("Walk Speed")]
      [DefaultValue(3)]
      float walkSpeed,
      [FriendlyName("Run Speed")]
      [SocketState(false, false)]
      [DefaultValue(10)]
      float runSpeed,
      [FriendlyName("In Air Control Acceleration")]
      [SocketState(false, false)]
      [DefaultValue(1)]
      float inAirControlAcceleration,
      [FriendlyName("Gravity")]
      [SocketState(false, false)]
      [DefaultValue(60)]
      float gravity,
      [FriendlyName("Max Fall Speed")]
      [SocketState(false, false)]
      [DefaultValue(20)]
      float maxFallSpeed,
      [FriendlyName("Speed Smooting")]
      [SocketState(false, false)]
      [DefaultValue(5)]
      float speedSmoothing,
      [FriendlyName("Rotation Smoothing")]
      [SocketState(false, false)]
      [DefaultValue(10)]
      float rotationSmoothing,
      [FriendlyName("Jump Enabled")]
      [SocketState(false, false)]
      [DefaultValue(true)]
      bool jumpEnabled,
      [FriendlyName("Jump Height")]
      [SocketState(false, false)]
      [DefaultValue(1)]
      float jumpHeight,
      [FriendlyName("Jump Extra Height")]
      [SocketState(false, false)]
      [DefaultValue(4.1)]
      float jumpExtraHeight
   )
   {
#if !(USCRIPT_DEV)
      Component c = instance.GetComponent( "PlatformerController" );

      if ( null == c ) 
      {
         uScriptDebug.Log( "PlatformerController.js must be added to " + instance.name + " (with a Transform set in the Inspector) for uScript's Platform Controller to work." + instance.name, uScriptDebug.Type.Warning );
         return;
      }

      PlatformerController controller = (PlatformerController) c;

      controller.canControl = canControl;

      if ( null != spawnPoint )
      {
         controller.spawnPoint.position = spawnPoint.position;
         controller.spawnPoint.rotation = spawnPoint.rotation;
      }

      controller.movement.walkSpeed  = walkSpeed;
      controller.movement.runSpeed   = runSpeed;

      controller.movement.inAirControlAcceleration = inAirControlAcceleration;
      
      controller.movement.gravity           = gravity;
      controller.movement.maxFallSpeed      = maxFallSpeed;
      controller.movement.speedSmoothing    = speedSmoothing;
      controller.movement.rotationSmoothing = rotationSmoothing;
      
      controller.jump.enabled     = jumpEnabled;
      controller.jump.height      = jumpHeight;
      controller.jump.extraHeight = jumpExtraHeight;
#endif
   }
}