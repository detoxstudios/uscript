// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Switches to the Target GameObject's camera. Can optionally enable that camera's AudioListener component.

using UnityEngine;
using System.Collections;

[NodePath("Action/Camera")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches to the Target GameObject's camera.")]
[NodeDescription("Switches to the Target GameObject's camera. Can optionally enable that camera's AudioListener component.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Switch Camera")]
public class uScriptAct_SwitchCamera : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, [FriendlyName("Enable AudioListener")] bool EnableAudioListener, [FriendlyName("Disable Other Cameras")] bool DisableOtherCameras)
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