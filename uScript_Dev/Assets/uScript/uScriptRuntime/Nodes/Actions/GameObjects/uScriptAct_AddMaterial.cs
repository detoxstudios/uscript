// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Adds a new Material to the existing set of materials on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Add Material", "Adds a new Material to the existing set of materials on the target GameObject. This new material will be appended to the GameObject's existing material channel array and be at the last index position.")]
public class uScriptAct_AddMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to assign add the new material to.")]
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
							List<Material> MatList = new List<Material>();
				            Material[] tmpMaterials = tmpTarget.renderer.materials;
							MatList.AddRange(tmpMaterials);
							Material newMaterial = new Material(tmpMaterialName);
							MatList.Add(newMaterial);
				
				            tmpTarget.renderer.materials = MatList.ToArray();
							tempIndex = tmpTarget.renderer.materials.Length - 1;
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