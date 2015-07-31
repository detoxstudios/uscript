// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the rotation in quaternion format of a GameObject in local or world coordinates.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Rotation Quaternion", "Sets the rotation of a GameObject in local or world coordinates as a quaternion. Optionally, can set rotation as offest from the target's current rotation.")]
public class uScriptAct_SetGameObjectRotationQ : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to rotate"), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Rotation", "Quaternion rotation to set")]
      Quaternion Rotation,
      
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
         Quaternion eq;
         
         if ( CoordinateSystem == Space.World )
         {
            eq = Rotation;
         }
         else
         {
            eq = currentTarget.transform.rotation * Rotation;
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
