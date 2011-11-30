// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Target GameObject's camera's depth to the specified float value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Camera_Depth")]

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
				TargetCam.camera.depth = Depth;
			}
			catch (System.Exception e)
         {
            uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
         }
		}
   }
}