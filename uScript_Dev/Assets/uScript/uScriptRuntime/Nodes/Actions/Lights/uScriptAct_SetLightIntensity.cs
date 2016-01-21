// uScript Action Node
// (C) 2016 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Lights")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Sets the intensity (brightness) of the Light component on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Light Intensity", "Sets the intensity (brightness) of the Light component on the target GameObject.")]
public class uScriptAct_SetLightIntensity : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target light GameObject (Light component required).")]
      GameObject Target,
      
      [FriendlyName("Intensity", "The intensity (brightness) you wish to assign to the light.")]
      float Intensity
      )
   {
      if (null != Target)
      {
         Light targetLight = Target.GetComponent<Light>();
         if (null != targetLight)
         {
            targetLight.intensity = Intensity;
         }
         else
         {
            uScriptDebug.Log("[Set Light Intensity] The target GameObject does not have a Light component. Skipping.", uScriptDebug.Type.Warning);
         }
      }
      else
      {
         uScriptDebug.Log("[Set Light Intensity] The target GameObject is NULL. Skipping.", uScriptDebug.Type.Warning);
      }
   }
}
