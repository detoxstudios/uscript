// uScript Action Node
// (C) 2016 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Lights")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the color of the Light component on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Light Color", "Gets the color of the Light component on the target GameObject.")]
public class uScriptAct_GetLightColor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target light GameObject (Light component required).")]
      GameObject Target,
      
      [FriendlyName("Color", "The color of the light.")]
      out Color LightColor
      )
   {
      if (null != Target)
      {
         Light targetLight = Target.GetComponent<Light>();
         if (null != targetLight)
         {
            LightColor = targetLight.color;
         }
         else
         {
            uScriptDebug.Log("[Get Light Color] The target GameObject does not have a Light component. Returning Color.black.", uScriptDebug.Type.Warning);
            LightColor = Color.black;
         }
      }
      else
      {
         uScriptDebug.Log("[Get Light Color] The target GameObject is NULL. Returning Color.black.", uScriptDebug.Type.Warning);
         LightColor = Color.black;
      }
   }
}
