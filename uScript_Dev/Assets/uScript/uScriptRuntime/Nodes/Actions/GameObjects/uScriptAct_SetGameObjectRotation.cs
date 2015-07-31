// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the rotation in degrees (float) of a GameObject in local or world coordinates.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Rotation", "Sets the rotation of a GameObject in local or world coordinates. Optionally, can set rotation as offest from the target's current rotation.")]
public class uScriptAct_SetGameObjectRotation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to rotate"), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("X Degrees", "Rotation amount on the X axis")]
      float XDegrees,
      
      [FriendlyName("Y Degrees", "Rotation amount on the Y axis")]
      float YDegrees,
      
      [FriendlyName("Z Degrees", "Rotation amount on the Z axis")]
      float ZDegrees,
      
      [FriendlyName("Ignore X", "Do not apply this rotation to the X axis")]
      [SocketState(false, false)]
      bool IgnoreX,
      
      [FriendlyName("Ignore Y", "Do not apply this rotation to the Y axis")]
      [SocketState(false, false)]
      bool IgnoreY,
      
      [FriendlyName("Ignore Z", "Do not apply this rotation to the Z axis")]
      [SocketState(false, false)]
      bool IgnoreZ,
      
      [FriendlyName("Space", "Space to apply rotation")]
      [SocketState(false, false)]
      UnityEngine.Space CoordinateSystem,
      
      [FriendlyName("As Offset", "Treat this rotation as an offset of the current GameObject's rotation")]
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
            eq = currentTarget.transform.rotation * Quaternion.Euler( euler );
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
