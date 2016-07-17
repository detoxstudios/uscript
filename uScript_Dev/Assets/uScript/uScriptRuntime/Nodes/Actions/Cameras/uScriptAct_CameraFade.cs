// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Allows you to fade to or from a color with the Target Camera.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Camera Fade", "Allows you to fade to or from a color with the Target Camera. This node works by creating a temporary primitive plane GameObject containing the specified material in front of the camera. The GameObject is removed after the fade is completed.")]
public class uScriptAct_CameraFade : uScriptLogic
{
	public enum FadeDirection { To, From };

	private float m_TimeToTrigger;
    private float m_TotalTime;
	private float m_HoldTime;
	private bool m_HoldFinished;
	private bool m_FadeTo = true;
	private Camera m_TargetCamera;
	private GameObject m_CameraPlane;
	private Color m_OriginalColor;
	private Material m_FadeMaterial;
	private bool m_ColorOverride;
	
	private bool m_ImmediateOut = false;
	[FriendlyName("Immediate Out")]
    public bool Immediate { get { return m_ImmediateOut; } }
	
	private bool m_fadeFinished = false;
	[FriendlyName("Finished")]
	public bool FadeFinished { get { return m_fadeFinished; } }

    public void In(
		  [FriendlyName("Camera", "The Camera you wish to apply the fade to.")]
		  Camera TargetCamera,
		  
		  [FriendlyName("Direction", "The direction of the fade. To will fade in the color over the camera. From will start at full color and fade out.")]
		  FadeDirection Direction,
		  
		  [FriendlyName("Material", "The material you wish to use for the fade. Note: You will need to use a material with a shader that supports transparency.")]
		  Material FadeMaterial,
		  
		  [FriendlyName("Fade Time", "The time period (in seconds) you wish the fade to occur.")]
		  [DefaultValue(1F)]
		  float FadeTime,
	               
	      [FriendlyName("Hold Time", "The time period (in seconds) you wish to hold the material in the camera before destroying the temporary plane. This is only used when the fade direction is set to \"To\". A value less than 0 will be ignored.")]
		  [DefaultValue(0F)]
		  [SocketState(false, false)]
	      float HoldTime,
		               
		  [FriendlyName("Override Color", "Will override the material's main color with the one specified in the Color property.")]
		  [SocketState(false, false)]
		  bool ColorOverride,
		               
		  [FriendlyName("Color", "The material color you wish to use when Color Override is set to true.")]
		  [SocketState(false, false)]
		  Color FadeColor,

         [FriendlyName("Scale", "Set this to greater than the default of '1' if you can see the edges of the plane in the camera's view during the fade.")]
         [SocketState(false, false)]
         [DefaultValue(1.0f)]
         float Scale
      	  )
   {
		
      if (TargetCamera != null && FadeMaterial != null && FadeTime > 0F)
      {
			m_ImmediateOut  = true;
			m_fadeFinished  = false;
			m_TargetCamera  = TargetCamera;
			m_FadeMaterial  = FadeMaterial;
			m_ColorOverride = ColorOverride;
			
			if (ColorOverride)
			{
				m_OriginalColor = m_FadeMaterial.color;
				m_FadeMaterial.color = FadeColor;
			}
			
			if(Direction == uScriptAct_CameraFade.FadeDirection.From)
			{
				m_FadeTo = false;
			}
			else
			{
				m_FadeMaterial.color = new Color(m_FadeMaterial.color.r, m_FadeMaterial.color.g, m_FadeMaterial.color.b, 0F);
			}

         if (m_CameraPlane == null)
         {
            // Create a primitive in front of the camera.
            m_CameraPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            m_CameraPlane.name = "uScriptRuntimeGenerated_CameraFadePlane";
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            m_CameraPlane.collider.enabled = false;
			   m_CameraPlane.renderer.material       = m_FadeMaterial;
#else
            m_CameraPlane.GetComponent<Collider>().enabled = false;
            m_CameraPlane.GetComponent<Renderer>().material = m_FadeMaterial;
#endif
            m_CameraPlane.transform.position = m_TargetCamera.transform.position;
            m_CameraPlane.transform.rotation = m_TargetCamera.transform.rotation;
            m_CameraPlane.transform.parent = m_TargetCamera.transform;
            m_CameraPlane.transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            m_CameraPlane.transform.localPosition = new Vector3(0, 0, 0.5F);
         }

         if (Scale > 1.0f)
         {
            Vector3 scaleVector = new Vector3(Scale, Scale, Scale);
            m_CameraPlane.transform.localScale = scaleVector; 
         }
			
			// Start Fade
			
			if (HoldTime < 0 ) HoldTime = 0;
			
			m_TimeToTrigger = FadeTime;
		    m_TotalTime     = FadeTime;
			m_HoldFinished = false;
			if(Direction != uScriptAct_CameraFade.FadeDirection.To)
			{
				m_HoldTime = 0f;
			}
			else
			{
				m_HoldTime = HoldTime + m_TotalTime;
			}
      }
	  else
	  {
			uScriptDebug.Log("[Camera Fade] One or more of the sockets contains null data. Please check your specified Camera and Material to be sure they are not null. Also check to make sure your specified Time is greater than 0.", uScriptDebug.Type.Warning);
	  }
   }
	
	
   [Driven]
   public bool DrivenFade( )
   {
      m_ImmediateOut = false;
      m_fadeFinished = false;
		
	
	  if(m_HoldTime > 0f)
	  {
		m_HoldTime -= UnityEngine.Time.deltaTime;
		if(m_HoldTime < 0f) m_HoldTime = 0f;
	  }
		
      if ( m_TimeToTrigger > 0f )
      { // Do the fade
			
         m_TimeToTrigger -= UnityEngine.Time.deltaTime;
		 if (m_TimeToTrigger < 0f) m_TimeToTrigger = 0f;  
         float t = 1.0f - (m_TimeToTrigger / m_TotalTime);

#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
		 if (m_FadeTo)
		 {
			m_CameraPlane.renderer.material.color = new Color(m_FadeMaterial.color.r, m_FadeMaterial.color.g, m_FadeMaterial.color.b, Mathf.Lerp(0F, 1F, t));
		 }
		 else
		 {
			m_CameraPlane.renderer.material.color = new Color(m_FadeMaterial.color.r, m_FadeMaterial.color.g, m_FadeMaterial.color.b, Mathf.Lerp(1F, 0F, t));
		 }
#else
         if (m_FadeTo)
		 {
          m_CameraPlane.GetComponent<Renderer>().material.color = new Color(m_FadeMaterial.color.r, m_FadeMaterial.color.g, m_FadeMaterial.color.b, Mathf.Lerp(0F, 1F, t));
		 }
		 else
		 {
          m_CameraPlane.GetComponent<Renderer>().material.color = new Color(m_FadeMaterial.color.r, m_FadeMaterial.color.g, m_FadeMaterial.color.b, Mathf.Lerp(1F, 0F, t));
		 }
#endif
      
         if ( m_TimeToTrigger <= 0f ) m_TimeToTrigger = 0f;

         return true;
			
      }
		else if (m_TimeToTrigger <= 0f && m_HoldFinished == false)
		{ // Do the hold
			
			if (m_HoldTime <= 0f)
			{
				m_HoldFinished = true;
				if(m_ColorOverride)
				{
					m_FadeMaterial.color = m_OriginalColor;
				}

				GameObject.Destroy(m_CameraPlane);
        		m_fadeFinished = true;
			}
			
			
			return true;
		}
		else
		{ // End the driven loop
			
			return false;	
		}
  
   }
	
}
