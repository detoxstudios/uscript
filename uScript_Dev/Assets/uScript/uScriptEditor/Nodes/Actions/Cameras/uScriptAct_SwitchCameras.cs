// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Switches from the 'From' camera to the 'To' camera.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches from 'From Camera' to 'To Camera'.")]
[NodeDescription("Disables the 'From' GameObject camera and enables the 'To' GameObject camera. Good for switching from one main camera to another.\n\n\tFrom: The GameObject containing the camera to switch from.\n\n\tTo: The GameObject containing the camera to switch to.\n\n\tEnable AudioListener: Whether or not to enable the 'To' camera's AudioListener component (if it has one).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Switch Cameras")]
public class uScriptAct_SwitchCameras : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("From")] GameObject FromCamera,
      [FriendlyName("To")] GameObject Target,
      [FriendlyName("Enable AudioListener"), DefaultValue(true), SocketState(false, false)] bool EnableAudioListener
      )
   {
      if (FromCamera != null && Target != null)
      {
         try
         {
            Component FromCam = FromCamera.GetComponent("Camera");
            Component ToCam = Target.GetComponent("Camera");

            FromCam.camera.enabled = false;
            ToCam.camera.enabled = true;
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
                  AudioListener[] listenerList = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
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