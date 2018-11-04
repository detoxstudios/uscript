// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Moves a GameObject in the specified direction.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Control GameObject (Move)", "Moves a GameObject in the specified direction (local to the GameObject). Please note that this is a simple move node that brute-forces the movement of the GameObject's position-- it does not use the physics system. It is recomended you create your own game-specific character controller if you need more functionality.")]
public class uScriptAct_ControlGameObjectMove : uScriptLogic
{
   public enum Direction { Forward, Backward, Left, Right, Up, Down };
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject to be moved.")]
      GameObject Target,

      [FriendlyName("Direction", "The direction to move the target.")]
      [SocketState(false, false)]
      Direction moveDirection,

      [FriendlyName("Speed", "The speed you wish to move the target per tick. This uses a relativly small value for most cases.")]
      [DefaultValue(0.01f)]
      float Speed,
		
	  [FriendlyName("Use Local", "Move the GameObject in local coordinates. Not used if the GameObject is using a component called CharacterController.")]
      [SocketState(false, false)]
	  [DefaultValue(false)]
      bool useLocal,

      [FriendlyName("Use Delta Time", "Multiply speed by Time.deltaTime so that time scaling works.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool useDeltaTime = false
      )
   {
      if (null != Target && Speed != 0f)
      {
         Vector3 movement = Vector3.zero;
         float speed = useDeltaTime ? Speed * Time.deltaTime : Speed;

         switch (moveDirection)
         {
            case Direction.Forward:
               movement = useLocal ? Vector3.forward * speed : Target.transform.forward * speed;
               break;

            case Direction.Backward:
               movement = useLocal ? Vector3.back * speed : Target.transform.forward * -speed;
               break;

            case Direction.Left:
               movement = useLocal ? Vector3.left * speed : Target.transform.right * -speed;
               break;

            case Direction.Right:
               movement = useLocal ? Vector3.right * speed : Target.transform.right * speed;
               break;

            case Direction.Up:
               movement = useLocal ? Vector3.up * speed : Target.transform.up * speed;
               break;

            case Direction.Down:
               movement = useLocal ? Vector3.down * speed : Target.transform.up * -speed;
               break;

            default:
               break;
         }

         CharacterController cc = Target.GetComponent<CharacterController>();
         if (null != cc)
		 {
			cc.Move(movement);
		 }
         else
		 {
			if (useLocal)
			{
				Target.transform.localPosition += movement;
			}
			else
			{
				Target.transform.position += movement;
			}
			
		 }
      }
   }

   
}