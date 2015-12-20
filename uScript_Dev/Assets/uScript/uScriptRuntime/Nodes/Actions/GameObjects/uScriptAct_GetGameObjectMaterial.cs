// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns a GameObject's material, material color, and material name assigned to the specified material index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Material", "Returns a GameObject's material, material color, and material name assigned to the specified material index.")]
public class uScriptAct_GetGameObjectMaterial : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject you wish to get the material information from.")]
      GameObject Target,

      [FriendlyName("Material Channel", "The index number of the material you wish to get from the Target. Zero (0) is the default and most common material index.")]
      [DefaultValue(0)]
      int MaterialIndex,
      
      [FriendlyName("Material", "Returns the material.")]
      out Material targetMaterial,
      
      [FriendlyName("Color", "Returns the color of the material.")]
      [SocketState(false, false)]
      out UnityEngine.Color materialColor,
      
      [FriendlyName("Name", "Returns the name of the material.")]
      [SocketState(false, false)]
      out string materialName
      )
   {

      if ( Target != null )
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
		 if (MaterialIndex <= Target.renderer.materials.Length - 1)
		 {
		    targetMaterial = Target.renderer.materials[MaterialIndex];
		    materialName = Target.renderer.materials[MaterialIndex].name;

            if (Target.renderer.material.HasProperty("_Color"))
                materialColor = Target.renderer.materials[MaterialIndex].color;
            else
                materialColor = UnityEngine.Color.white;
#else
         if (MaterialIndex <= Target.GetComponent<Renderer>().materials.Length - 1)
		 {
          targetMaterial = Target.GetComponent<Renderer>().materials[MaterialIndex];
          materialName = Target.GetComponent<Renderer>().materials[MaterialIndex].name;

          if (Target.GetComponent<Renderer>().material.HasProperty("_Color"))
             materialColor = Target.GetComponent<Renderer>().materials[MaterialIndex].color;
            else
                materialColor = UnityEngine.Color.white;
#endif
		 }
		 else
		 {
			uScriptDebug.Log("The specified Material Channel does not exist on " + Target.name, uScriptDebug.Type.Warning);
			targetMaterial = null;
		    materialColor = UnityEngine.Color.magenta;
		    materialName = "";
		 }
         
      }
      else
      {
		 uScriptDebug.Log("The specified Target GameObject does not exist.", uScriptDebug.Type.Warning);
         targetMaterial = null;
		 materialColor = UnityEngine.Color.magenta;
		 materialName = "";
      }

   }
}
