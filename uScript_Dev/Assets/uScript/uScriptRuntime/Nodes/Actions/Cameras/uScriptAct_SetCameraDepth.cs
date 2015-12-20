// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Target GameObject's camera's depth to the specified float value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Camera Depth", "Sets the Target GameObject's camera's depth to the specified float value.")]
public class uScriptAct_SetCameraDepth : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject whose camera to set the depth of.")]
      GameObject Target,
      
      [FriendlyName("Depth", "The new depth of the specified GameObject's camera.")]
      float Depth
      )
   {
      if ( Target != null)
      {
			try
			{
				Component TargetCam = Target.GetComponent( "Camera" );
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
				TargetCam.camera.depth = Depth;
#else
            TargetCam.GetComponent<Camera>().depth = Depth;
#endif
			}
			catch (System.Exception e)
         {
            uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
         }
		}
   }
}