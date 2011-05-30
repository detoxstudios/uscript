// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the Target GameObject's camera's depth to the specified float value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Target GameObject's camera's depth to the specified float value.")]
[NodeDescription("Sets the Target GameObject's camera's depth to the specified float value.\n \nTarget: The GameObject whose camera to set the depth of.\nDepth: The new depth of the specified GameObject's camera.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Camera Depth")]
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