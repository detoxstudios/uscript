// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the rotation in degrees (float) of a GameObject in local or world coordinates.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Position")]

[FriendlyName("Set Rotation", "Sets the rotation of a GameObject in local or world coordinates. Optionally, can set rotation as offest from the target's current rotation.")]
public class uScriptAct_SetGameObjectRotation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "?")]
      GameObject[] Target,
      
      [FriendlyName("X Degrees", "?")]
      float XDegrees,
      
      [FriendlyName("Y Degrees", "?")]
      float YDegrees,
      
      [FriendlyName("Z Degrees", "?")]
      float ZDegrees,
      
      [FriendlyName("Ignore X", "?")]
      [SocketState(false, false)]
      bool IgnoreX,
      
      [FriendlyName("Ignore Y", "?")]
      [SocketState(false, false)]
      bool IgnoreY,
      
      [FriendlyName("Ignore Z", "?")]
      [SocketState(false, false)]
      bool IgnoreZ,
      
      [FriendlyName("Space", "?")]
      [SocketState(false, false)]
      UnityEngine.Space CoordinateSystem,
      
      [FriendlyName("As Offset", "?")]
      [SocketState(false, false)]
      bool AsOffset
      )
   {
		foreach (GameObject currentTarget in Target)
		{			
         Vector3 euler = Vector3.zero;         

         if ( true == AsOffset )
         {
            //if it's an offset we will concatentate our rotation
            //which means only fill in the axis they want to rotate on
		      if ( false == IgnoreX ) euler.x = XDegrees;
            if ( false == IgnoreY ) euler.y = YDegrees;
		      if ( false == IgnoreZ ) euler.z = ZDegrees;
         }
         else
         {
            //if it's not an offset then we want to start with
            //their current rotation and override only the new
            //specified parameters
            euler = currentTarget.transform.rotation.eulerAngles;
		      
            if ( false == IgnoreX ) euler.x = XDegrees;
            if ( false == IgnoreY ) euler.y = YDegrees;
		      if ( false == IgnoreZ ) euler.z = ZDegrees;
         }

         Quaternion eq;
         
         if ( CoordinateSystem == Space.World )
         {
            eq = Quaternion.Euler( euler );
         }
         else
         {
            //unity applies eulers as x then y then z
            //so i'm attempting to do the same through quaternions based on the object's local angle axis
            Quaternion qx = Quaternion.AngleAxis( euler.x, currentTarget.transform.right );
            Quaternion qy = Quaternion.AngleAxis( euler.y, currentTarget.transform.up );
            Quaternion qz = Quaternion.AngleAxis( euler.z, currentTarget.transform.forward );
         
            //quaternion multiplication is reversed A rotation followed by B rotation is B*A
            //so I was x followed by y followed by z
            //q = y * x  (x followed by y)
            //q = z * q  (xy followed by z)
            eq = qy * qx;
            eq = qz * eq;
         }

         if (true == AsOffset) 
         {   
            //existing rotation followed by new rotation
            currentTarget.transform.rotation = eq * currentTarget.transform.rotation;
         }
         else
         {
            currentTarget.transform.rotation = eq;
         }
      }
   }
}
