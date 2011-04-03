// This script will move the GameObject it is assigned to around.
using UnityEngine;
using System.Collections;
using System.ComponentModel;

[System.Serializable]
public class keyMovement
{
   public float unitsToMove = 2;
   public bool lerpMovement = true;
};

[System.Serializable]
public class mouseMovement
{

   public bool useFixedUpdate = true;
   public int smooth = 2; // Determines how quickly object moves towards position

};

public class MovePlayer : MonoBehaviour
{

   public bool useKeyBasedMovement = true;
   // Variables for key-based movement
   private Vector3 targetKeys;
   private float smoothKeys = 5.0F;
   private Vector3 moveDistance;
   public keyMovement keyBasedMovementSettings;

   // Variables for mouse-based movement
   public mouseMovement mouseBasedMovementSettings;
   private Vector3 targetPosition;

   void Update()
   {
      if (!useKeyBasedMovement)
      {
         if (!mouseBasedMovementSettings.useFixedUpdate)
         {

            // Move the GameObject to the location of the mouse click.
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               Plane playerPlane = new Plane(Vector3.up, transform.position);
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               float hitdist = 0.0f;

               if (playerPlane.Raycast(ray, out hitdist))
               {
                  Vector3 targetPoint = ray.GetPoint(hitdist);
                  targetPosition = ray.GetPoint(hitdist);
                  Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                  transform.rotation = targetRotation;
               }
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * mouseBasedMovementSettings.smooth);
         }
      }
      else
      {
         //Use arrow keys to move the player
         if (Input.GetKeyUp("up"))
         {
            moveDistance = new Vector3(0, 0, keyBasedMovementSettings.unitsToMove);
            targetKeys = transform.position + moveDistance;
         }

         if (Input.GetKeyUp("down"))
         {
            moveDistance = new Vector3(0, 0, -keyBasedMovementSettings.unitsToMove);
            targetKeys = transform.position + moveDistance;
         }

         if (Input.GetKeyUp("left"))
         {
            moveDistance = new Vector3(-keyBasedMovementSettings.unitsToMove, 0, 0);
            targetKeys = transform.position + moveDistance;
         }

         if (Input.GetKeyUp("right"))
         {
            moveDistance = new Vector3(keyBasedMovementSettings.unitsToMove, 0, 0);
            targetKeys = transform.position + moveDistance;
         }

         if (keyBasedMovementSettings.lerpMovement)
         {
            transform.position = Vector3.Lerp(transform.position, targetKeys, Time.deltaTime * smoothKeys);
         }
         else
         {
            transform.position = targetKeys;
         }
      }

   }


   void FixedUpdate()
   {
      if (!useKeyBasedMovement)
      {
         if (mouseBasedMovementSettings.useFixedUpdate)
         {

            // Move the GameObject to the location of the mouse click.
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               Plane playerPlane = new Plane(Vector3.up, transform.position);
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               float hitdist = 0.0f;

               if (playerPlane.Raycast(ray, out hitdist))
               {
                  Vector3 targetPoint = ray.GetPoint(hitdist);
                  targetPosition = ray.GetPoint(hitdist);
                  Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                  transform.rotation = targetRotation;
               }
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * mouseBasedMovementSettings.smooth);
         }

      }
   }
}

