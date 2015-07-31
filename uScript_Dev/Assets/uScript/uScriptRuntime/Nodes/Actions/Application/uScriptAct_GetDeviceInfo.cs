// uScript Action Node
// (C) 2011 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the device's information.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Device Info", "Gets the device's information found in Systeminfo.")]
public class uScriptAct_GetDeviceInfo : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Model", "The model of the device.")]
      out string currentDeviceModel,
      
      [FriendlyName("Name", "The name of the device as assigned by the user.")]
      out string currentDeviceName
      
#if UNITY_IPHONE
      
#else
	  ,	
      [FriendlyName("Unique ID", "The unique device identifier of the device. NOTE: This will be compiled out (not used) for iOS devices as Apple will reject Apps found using the devices UDID. Do not use the Unique ID if you plan to compile your application for Apple iOS devices.")]
      out string currentDeviceID
#endif
      )
   {
		currentDeviceModel = SystemInfo.deviceModel;
		currentDeviceName = SystemInfo.deviceName;
		#if UNITY_IPHONE
      
#else
		currentDeviceID = SystemInfo.deviceUniqueIdentifier;
#endif
   }
}
