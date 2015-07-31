// uScript uScript_DeviceOrientation.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Input Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when the screen orientation of a device happens.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Device Orientation Events", "Fires an event signal when the screen orientation of a device happens." +
 "\n\nSupported events: Portrait, Portrait Upside-Down, Landscape Left, Landscape Right, Face Up, Face Down.")]
public class uScript_DeviceOrientation : uScriptEvent
{
   private DeviceOrientation m_LastOrientation = DeviceOrientation.Unknown;
   
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
  
   [FriendlyName("On Portrait")]
   public event uScriptEventHandler OnDevicePortrait;
   [FriendlyName("On Portrait Upside-Down")]
   public event uScriptEventHandler OnDevicePortraitUpsideDown;
   [FriendlyName("On Landscape Left")]
   public event uScriptEventHandler OnDeviceLandscapeLeft;
   [FriendlyName("On Landscape Right")]
   public event uScriptEventHandler OnDeviceLandscapeRight;
   [FriendlyName("On Face Up")]
   public event uScriptEventHandler OnDeviceFaceUp;
   [FriendlyName("On Face Down")]
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
