// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches from 'From Camera' to 'To Camera'.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Switch Cameras", "Disables the 'From' GameObject camera and enables the 'To' GameObject camera. Good for switching from one main camera to another.")]
public class uScriptAct_SwitchCameras : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("From", "The GameObject containing the camera to switch from.")]
      GameObject FromCamera,
      
      [FriendlyName("To", "The GameObject containing the camera to switch to.")]
      GameObject Target,
      
      [FriendlyName("Enable AudioListener", "Whether or not to enable the 'To' camera's AudioListener component (if it has one).")]
      [DefaultValue(true), SocketState(false, false)]
      bool EnableAudioListener
      )
   {
      if (FromCamera != null && Target != null)
      {
         try
         {
            Component FromCam = FromCamera.GetComponent("Camera");
            Component ToCam = Target.GetComponent("Camera");

#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            FromCam.camera.enabled = false;
            ToCam.camera.enabled = true;
#else
            FromCam.GetComponent<Camera>().enabled = false;
            ToCam.GetComponent<Camera>().enabled = true;
#endif
         }
         catch (System.Exception e)
         {
            uScriptDebug.Log((e.ToString()), uScriptDebug.Type.Error);
         }

         if (EnableAudioListener)
         {
            AudioListener toListener;

            toListener = Target.GetComponent<AudioListener>();

            if (toListener != null)
            {
               try
               {
                  AudioListener[] listenerList = ScriptableObject.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
                  foreach (AudioListener tmpListener in listenerList)
                  {
                     tmpListener.enabled = false;
                  }

                  toListener.enabled = true;
               }
               catch (System.Exception e)
               {
                  uScriptDebug.Log((e.ToString()), uScriptDebug.Type.Error);
               }
            }
         }
      }
   }
}