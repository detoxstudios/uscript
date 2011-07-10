// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Switches to the Target GameObject's camera. Can optionally enable that camera's AudioListener component.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches to the Target GameObject's camera.")]
[NodeDescription("Switches to the Target GameObject's camera.\n \nTarget: The GameObject containing the camera to switch to.\nEnable AudioListener: Whether or not to enable that camera's AudioListener component (if it has one).\nDisable Other Cameras: Whether or not to disable all other cameras.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Switch_Camera")]

[NodeDeprecated(typeof(uScriptAct_SwitchCameras))]

[FriendlyName("Switch Camera")]
public class uScriptAct_SwitchCamera : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      GameObject Target,
      [FriendlyName("Enable AudioListener"), SocketState(false, false)] bool EnableAudioListener,
      [FriendlyName("Disable Other Cameras"), SocketState(false, false)] bool DisableOtherCameras)
   {
      if ( Target != null)
      {
			try
			{
            Component TargetCam = Target.GetComponent( "Camera" );
            
            if ( DisableOtherCameras )
            {
               Camera[] cameraList = FindObjectsOfType(typeof(Camera)) as Camera[];
               foreach (Camera tmpCamera in cameraList)
               {
                  tmpCamera.enabled = false;
               }
            }
            
            TargetCam.camera.enabled = true;
         }
         catch (System.Exception e)
         {
            uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
         }
         
         if ( EnableAudioListener )
         {
            AudioListener targetListener;
            targetListener = Target.GetComponent<AudioListener>();
            
            if ( targetListener != null)
            {
               try
               {
                  AudioListener[] listenerList = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
                  foreach (AudioListener tmpListener in listenerList)
                  {
                     tmpListener.enabled = false;
                  }
                  
                  targetListener.enabled = true;						
               }
               catch (System.Exception e)
               {
                  uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
               }
            }
         }
      }
   }
}