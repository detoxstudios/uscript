// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the specified Material to the GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Assign_Material")]

[FriendlyName("Assign Material", "Assigns the specified Material to the GameObject on the specifed material channel.")]
public class uScriptAct_AssignMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to assign the material to.")]
      GameObject[] Target,

      [FriendlyName("Material", "The material to assign.")]
      Material materialName,

      [FriendlyName("Material Channel", "The material channel of the object to assign the material to.")]
      [SocketState(false, false)]
      int MatChannel
      )
   {
      
      foreach (GameObject tmpTarget in Target)
      {
         try
         {
            // Get the materials on the Target
            Material[] tmpMaterials = tmpTarget.renderer.materials;

            tmpMaterials[MatChannel] = materialName;
            tmpTarget.renderer.materials = tmpMaterials;
         }
         catch (System.Exception e)
         {
            uScriptDebug.Log("(Node = Assign Material) Could not assign the material to '" + tmpTarget.name + "'. Please verify you are assigning to a valid material channel.\nError output: " + e.ToString(), uScriptDebug.Type.Error);
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