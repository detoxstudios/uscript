// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds a new Material to the existing set of materials on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Material", "Adds a new Material to the existing set of materials on the target GameObject. This new material will be appended to the GameObject's existing material channel array and be at the last index position.")]
public class uScriptAct_AddMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to assign add the new material to."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Material", "The material(s) to add to the Target. If material channel index order is important and you are adding more than one material at once, use a Material List or add one material at a time.")]
      Material[] materialName,
	               
	  [FriendlyName("Index", "Returns the index to which the new material was assigned in the Materials array. If adding the material to more than one GameObject at a time, this will return the index from the last GameObject to have the material added.")]
      [SocketState(false, false)]
	  out int materialIndex
      )
   {
      int tempIndex = -1;
		
      foreach (GameObject tmpTarget in Target)
      {
			if(null != tmpTarget)
			{
		         try
		         {
					foreach(Material tmpMaterialName in materialName)
					{
						if(null != tmpMaterialName)
						{
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
							List<Material> MatList = new List<Material>();
				            Material[] tmpMaterials = tmpTarget.renderer.materials;
							MatList.AddRange(tmpMaterials);
							Material newMaterial = new Material(tmpMaterialName);
							MatList.Add(newMaterial);
				
				            tmpTarget.renderer.materials = MatList.ToArray();
							tempIndex = tmpTarget.renderer.materials.Length - 1;
#else
                     List<Material> MatList = new List<Material>();
                     Material[] tmpMaterials = tmpTarget.GetComponent<Renderer>().materials;
                     MatList.AddRange(tmpMaterials);
                     Material newMaterial = new Material(tmpMaterialName);
                     MatList.Add(newMaterial);

                     tmpTarget.GetComponent<Renderer>().materials = MatList.ToArray();
                     tempIndex = tmpTarget.GetComponent<Renderer>().materials.Length - 1;
#endif
						}
					}
		         }
		         catch (System.Exception e)
		         {
		            uScriptDebug.Log("(Node = Add Material) Could not add the material to '" + tmpTarget.name + "'. Returning -1 for the Index if this was the last GameObject to have the material added." + e.ToString(), uScriptDebug.Type.Error);
					tempIndex = -1;
		         }
			}
      }
		materialIndex = tempIndex;
   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop(object o)
   {
      if (typeof(Material).IsAssignableFrom(o.GetType()))
      {
         Material ac = (Material)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Material"] = UnityEditor.AssetDatabase.GetAssetPath(ac.GetInstanceID());

         return hashtable;
      }
      if (typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()))
      {
         GameObject go = (GameObject)o;

         Hashtable hashtable = new Hashtable();
         hashtable["Target"] = go.name;

         return hashtable;
      }

      return null;
   }
#endif


}