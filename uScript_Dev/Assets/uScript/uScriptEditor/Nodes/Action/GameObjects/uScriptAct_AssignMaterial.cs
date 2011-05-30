// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Assigns the specified Material (by name) to the GameObject on the specifed material channel.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the specified Material to the GameObject.")]
[NodeDescription("Assigns the specified Material (by name) to the GameObject on the specifed material channel.\n \nTarget: The GameObject(s) to assign the material to.\nMaterial Name: The filename of the material to assign.\nResource Path: The path to the material file.\nMaterial Channel: The material channel of the object to assign the material to.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Assign Material")]
public class uScriptAct_AssignMaterial : uScriptLogic
{
   private Material m_NewMaterial;

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Material Name")]string materialName, [FriendlyName("Resource Path")]string resourcePath, [FriendlyName("Material Channel")]int MatChannel)
   {
      //Get the Material
      try
      {
         m_NewMaterial = Resources.Load(GetFullPath(materialName, resourcePath), typeof(Material)) as Material;
      }
      catch (System.Exception e)
      {
         uScriptDebug.Log("(Node = Assign Material) Could not load the specified material. Check your material name and path.\nError output: " + e.ToString(), uScriptDebug.Type.Error);
      }

      foreach (GameObject tmpTarget in Target)
      {
         try
         {
            // Get the materials on the Target
            Material[] tmpMaterials = tmpTarget.renderer.materials;

            tmpMaterials[MatChannel] = m_NewMaterial;
            tmpTarget.renderer.materials = tmpMaterials;
         }
         catch (System.Exception e)
         {
            uScriptDebug.Log("(Node = Assign Material) Could not assign the material to '" + tmpTarget.name + "'. Please verify you are assigning to a valid material channel.\nError output: " + e.ToString(), uScriptDebug.Type.Error);
         }
      }
   }

   string GetFullPath(string FileName, string ResourcePath)
   {
      // Build final ResourcePath string
      if (!string.IsNullOrEmpty(ResourcePath))
      {
         // Make sure all the slashes are correct
         if (ResourcePath.Contains("\\"))
         {
            ResourcePath = ResourcePath.Replace("\\", "/");
         }

         // Prune any begining or ending slashes
         if (ResourcePath.StartsWith("/") || ResourcePath.StartsWith(@"\"))
         {
            ResourcePath = ResourcePath.Remove(0, 1);
         }
         if (ResourcePath.EndsWith("/") || ResourcePath.EndsWith(@"\"))
         {
            int stringLength = ResourcePath.Length - 1;
            ResourcePath = ResourcePath.Remove(stringLength, 1);
         }

         //prune Assets text if user added it
         if (ResourcePath.StartsWith("Assets") || ResourcePath.StartsWith("assets"))
         {
            ResourcePath = ResourcePath.Remove(0, "Assets".Length);
         }

         //prune Resources text if user added it
         if (ResourcePath.StartsWith("Resources") || ResourcePath.StartsWith("resources"))
         {
            ResourcePath = ResourcePath.Remove(0, "Resources".Length);
         }
      }

      // Build final PrefabName string
      if (!string.IsNullOrEmpty(FileName))
      {
         // Make sure all the slashes are correct
         if (FileName.Contains("\\"))
         {
            FileName = FileName.Replace("\\", "/");
         }

         // Prune any begining or ending slashes
         if (FileName.StartsWith("/") || FileName.StartsWith(@"\"))
         {
            FileName = FileName.Remove(0, 1);
         }
         if (FileName.EndsWith("/") || FileName.EndsWith(@"\"))
         {
            int stringLength = FileName.Length - 1;
            FileName = FileName.Remove(stringLength, 1);
         }

         FileName = System.IO.Path.GetFileNameWithoutExtension(FileName);
      }

      // Build final fullPath
      string fullPath = "";

      if (!string.IsNullOrEmpty(ResourcePath))
      {
         fullPath = ResourcePath + "/" + FileName;
      }
      else
      {
         // Must be in the root of Resources
         fullPath = FileName;
      }

      return fullPath;
   }


}