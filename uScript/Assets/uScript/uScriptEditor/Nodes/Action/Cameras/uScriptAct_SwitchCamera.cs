// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Switches to the Target GameObject's camera. Can optionally enable that camera's AudioListener component.

using UnityEngine;
using System.Collections;

public class uScriptAct_SwitchCamera : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, bool EnableAudioListener, bool DisableOtherCameras)
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