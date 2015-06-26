#if UNITY_5_0 || UNITY_5_1
// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the shadow casting mode of this GameObject's renderer.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Shadow_Casting_Mode")]

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