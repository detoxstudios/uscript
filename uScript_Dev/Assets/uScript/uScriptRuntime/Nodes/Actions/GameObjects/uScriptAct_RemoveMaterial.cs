// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Removes an existing Material at the specified index on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Remove Material", "Remove an existing Material at the specified index on the target GameObject.")]
public class uScriptAct_RemoveMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to remove the material from."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Material Index", "The index of the material you wish to remove on the Target.")]
      int materialIndex
      )
   {

      foreach (GameObject tmpTarget in Target)
      {
         if (null != tmpTarget)
         {
            try
            {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
               List<Material> MatList = new List<Material>();
               Material[] tmpMaterials = tmpTarget.renderer.materials;

               // Check to make sure the specified index is in range
               if (materialIndex < tmpMaterials.Length && materialIndex > -1)
               {
                  foreach (Material tmpMat in tmpMaterials)
                  {
                     MatList.Add(tmpMat);
                  }

                  MatList.RemoveAt(materialIndex);

                  tmpTarget.renderer.materials = MatList.ToArray();
#else
               List<Material> MatList = new List<Material>();
               Material[] tmpMaterials = tmpTarget.GetComponent<Renderer>().materials;

               // Check to make sure the specified index is in range
               if (materialIndex < tmpMaterials.Length && materialIndex > -1)
               {
                  foreach (Material tmpMat in tmpMaterials)
                  {
                     MatList.Add(tmpMat);
                  }

                  MatList.RemoveAt(materialIndex);

                  tmpTarget.GetComponent<Renderer>().materials = MatList.ToArray();
#endif
               }
               else
               {
                  uScriptDebug.Log("(Node = Remove Material) The index supplied is outside the material index range on the specified Target GameObject (" + tmpTarget.name + ").");
               }


            }
            catch (System.Exception e)
            {
               uScriptDebug.Log("(Node = Remove Material) Could not remove the material on '" + tmpTarget.name + "'. " + e.ToString(), uScriptDebug.Type.Error);
            }
         }
      }
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