// uScript Action Node
// (C) 2016 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Lights")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Sets the color of the Light component on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Light Color", "Sets the color of the Light component on the target GameObject.")]
public class uScriptAct_SetLightColor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target light GameObject (Light component required).")]
      GameObject Target,
      
      [FriendlyName("Color", "The color you wish to assign to the light.")]
      Color LightColor
      )
   {
      if (null != Target)
      {
         Light targetLight = Target.GetComponent<Light>();
         if (null != targetLight)
         {
            targetLight.color = LightColor;
         }
         else
         {
            uScriptDebug.Log("[Set Light Color] The target GameObject does not have a Light component. Skipping.", uScriptDebug.Type.Warning);
         }
      }
      else
      {
         uScriptDebug.Log("[Set Light Color] The target GameObject is NULL. Skipping.", uScriptDebug.Type.Warning);
      }
   }
}
