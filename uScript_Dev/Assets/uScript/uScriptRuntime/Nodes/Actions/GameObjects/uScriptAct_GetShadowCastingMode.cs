#if UNITY_5 || UNITY_2017
// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the shadow casting mode of the specified GameObject's renderer.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Shadow Casting Mode", "Gets the shadow casting mode of the specified GameObject's renderer.")]
public class uScriptAct_GetShadowCastingMode : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject you wish to get the shadow casting mode of."), 
       AutoLinkType(typeof(GameObject))]
      GameObject Target,
      
      [FriendlyName("Mode", "The shadow casting mode of the specified GameObject's renderer.")]
      out UnityEngine.Rendering.ShadowCastingMode mode
   )
   {
      mode = UnityEngine.Rendering.ShadowCastingMode.On; // this is not the most efficient default, but it is what unity uses as the default

      Renderer r = Target.GetComponent<Renderer>();
      if (r != null) mode = r.shadowCastingMode;
   }
}
#endif
