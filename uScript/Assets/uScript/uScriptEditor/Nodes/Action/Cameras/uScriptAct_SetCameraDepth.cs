// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the Target GameObject's camera's depth to the specified float value.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetCameraDepth : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, float Depth)
   {

      	if ( Target != null)
		{
			try
			{
				Component TargetCam = Target.GetComponent( "Camera" );				
				TargetCam.camera.depth = Depth;
			}
			catch (System.Exception e)
	        {
	           uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
	        }
		}

   }
}