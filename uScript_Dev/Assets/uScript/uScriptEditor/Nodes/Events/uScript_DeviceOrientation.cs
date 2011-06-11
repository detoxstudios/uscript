// uScript uScript_DeviceOrientation.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when the screen orientation of a device happens. Supported events: Device Portrait, Device Portrait Upside-Down, Device Landscape Left, Device Landscape Right, Device Face Up, Device Face Down.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the screen orientation of a device happens. Supported events: Device Portrait, Device Portrait Upside-Down, Device Landscape Left, Device Landscape Right, Device Face Up, Device Face Down.")]
[NodeDescription("Fires an event signal when the screen orientation of a device happens. Supported events: Device Portrait, Device Portrait Upside-Down, Device Landscape Left, Device Landscape Right, Device Face Up, Device Face Down.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Device Orientation Events")]
public class uScript_DeviceOrientation : uScriptEvent
{
   private DeviceOrientation m_LastOrientation = DeviceOrientation.Unknown;
   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
  
   [FriendlyName("On Device Portrait")]
   public event uScriptEventHandler OnDevicePortrait;
   [FriendlyName("On Device Portrait Upside-Down")]
   public event uScriptEventHandler OnDevicePortraitUpsideDown;
   [FriendlyName("On Device Landscape Left")]
   public event uScriptEventHandler OnDeviceLandscapeLeft;
   [FriendlyName("On Device Landscape Right")]
   public event uScriptEventHandler OnDeviceLandscapeRight;
   [FriendlyName("On Device Face Up")]
   public event uScriptEventHandler OnDeviceFaceUp;
   [FriendlyName("On Device Face Down")]
   public event uScriptEventHandler OnDeviceFaceDown;

   void Update()
   {
      if (Input.deviceOrientation == DeviceOrientation.FaceDown && m_LastOrientation != DeviceOrientation.FaceDown)
      {
         if ( null != OnDeviceFaceDown ) OnDeviceFaceDown( this, new System.EventArgs() );     
      }

      if (Input.deviceOrientation == DeviceOrientation.FaceUp && m_LastOrientation != DeviceOrientation.FaceUp)
      {
         if ( null != OnDeviceFaceUp ) OnDeviceFaceUp( this, new System.EventArgs() );     
      }

      if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && m_LastOrientation != DeviceOrientation.LandscapeLeft)
      {
         if ( null != OnDeviceLandscapeLeft ) OnDeviceLandscapeLeft( this, new System.EventArgs() );     
      }

      if (Input.deviceOrientation == DeviceOrientation.LandscapeRight && m_LastOrientation != DeviceOrientation.LandscapeRight)
      {
         if ( null != OnDeviceLandscapeRight ) OnDeviceLandscapeRight( this, new System.EventArgs() );     
      }

      if (Input.deviceOrientation == DeviceOrientation.Portrait && m_LastOrientation != DeviceOrientation.Portrait)
      {
         if ( null != OnDevicePortrait ) OnDevicePortrait( this, new System.EventArgs() );     
      }

      if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown && m_LastOrientation != DeviceOrientation.PortraitUpsideDown)
      {
         if ( null != OnDevicePortraitUpsideDown ) OnDevicePortraitUpsideDown( this, new System.EventArgs() );     
      }
      
      m_LastOrientation = Input.deviceOrientation;
   }
}
