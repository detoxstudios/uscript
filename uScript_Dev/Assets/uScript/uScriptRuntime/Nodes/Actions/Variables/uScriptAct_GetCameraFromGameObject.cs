// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Camera component from the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Camera From GameObject", "Gets the Camera component from the target GameObject. This node will assign the main Camera if no existing Camera component is found on the target (or the target is null).")]
public class uScriptAct_GetCameraFromGameObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject you wish to get the Camera component from.")]
      GameObject Target,
      
      [FriendlyName("Camera", "The Target variable you wish to set.")]
      out Camera TargetCamera
      )
   {
		if (null != Target)
		{
			Camera tempCamera = Target.camera;

			if ( null != tempCamera)
			{
				TargetCamera = tempCamera;
			}
			else
			{
				uScriptDebug.Log("[Get Camera From GameObject] The target does not have a Camera component, using the main scene camera instead.", uScriptDebug.Type.Warning);
				TargetCamera = Camera.main;
			}
		}
		else
		{
			uScriptDebug.Log("[Get Camera From GameObject] The target was null, using the main scene camera instead.", uScriptDebug.Type.Warning);
			TargetCamera = Camera.main;
		}
		
   }
}
