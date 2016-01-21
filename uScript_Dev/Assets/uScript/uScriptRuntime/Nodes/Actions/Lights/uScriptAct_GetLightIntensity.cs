// uScript Action Node
// (C) 2016 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Lights")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the intensity (brightness) of the Light component on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Light Intensity", "Gets the intensity (brightness) of the Light component on the target GameObject.")]
public class uScriptAct_GetLightIntensity : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target light GameObject (Light component required).")]
      GameObject Target,
      
      [FriendlyName("Intensity", "The intensity (brightness) of the light.")]
      out float Intensity
      )
   {
      if (null != Target)
      {
         Light targetLight = Target.GetComponent<Light>();
         if (null != targetLight)
         {
            Intensity = targetLight.intensity;
         }
         else
         {
            uScriptDebug.Log("[Get Light Intensity] The target GameObject does not have a Light component. Returning 0.0", uScriptDebug.Type.Warning);
            Intensity = 0.0f;
         }
      }
      else
      {
         uScriptDebug.Log("[Get Light Intensity] The target GameObject is NULL. Returning 0.0", uScriptDebug.Type.Warning);
         Intensity = 0.0f;
      }
   }
}
