#if UNITY_5 || UNITY_2017
// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the shadow casting mode of this GameObject's renderer.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Shadow Casting Mode", "Sets the shadow casting mode of this GameObject's renderer.")]
public class uScriptAct_SetShadowCastingMode : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) you wish to set the shadow casting mode of."), 
       AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Mode", "The shadow casting mode to set this GameObject's renderer to.")]
      UnityEngine.Rendering.ShadowCastingMode mode
   )
   {
      foreach (GameObject go in Target)
      {
         Renderer r = go.GetComponent<Renderer>();
         if (r != null) r.shadowCastingMode = mode;
      }
   }
}
#endif
