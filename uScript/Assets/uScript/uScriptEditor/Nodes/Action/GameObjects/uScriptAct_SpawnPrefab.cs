// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Create (instantiate) an instance of a Prefab at the specified spawn point GameObject
//       at runtime (must be in the Resources folder structure).

using UnityEngine;
using System.Collections;

public class uScriptAct_SpawnPrefab : uScriptLogic
{
   // @TODO: Needed functionality includes:
   // 1. Ability to spawn multiple Prefabs at once with an optional delay between spawns.
   // 2. Ability to put spawned object into a GameObject variable or list.
   // 3. Ability to set multiple spawn point locations.
   // 4. Ability to set a Vector3 location in option of GameObject location.
   // 5. Multiple inputs (Spawn Prefab, Enable, Disable, and Toggle).
   // 6. Logic to check for a legal spawn collision check before doing a spwan Prefab (would have Aborted out).
   // 7. Would it be better to have another master uScript script to hold an array of prefabs to spawn (instead of Resources folder)? Both?

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   private bool m_FinishedSpawning = false;

   public bool Immediate { get { return true; } }
   public event uScriptEventHandler FinishedSpawning;

   public void In(string PrefabName, string ResourcePath, GameObject SpawnPoint, string SpawnedName, Vector3 LocationOffset, out GameObject SpawnedGameObject, out int SpawnedInstancedID)
   {
      //Get Spawn point location and rotation

      Vector3 spawnPointPosition = SpawnPoint.transform.position + LocationOffset;
      Quaternion spawnPointRotation = SpawnPoint.transform.rotation;

      // Build final ResourcePath string
      if (ResourcePath != "")
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
            ResourcePath = ResourcePath.Remove(0, 6);
         }

         //prune Resources text if user added it
         if (ResourcePath.StartsWith("Resources") || ResourcePath.StartsWith("resources"))
         {
            ResourcePath = ResourcePath.Remove(0, 9);
         }

         
      }

      // Build final PrefabName string
      if (PrefabName != "")
      {
         // Make sure all the slashes are correct
         if (PrefabName.Contains("\\"))
         {
            PrefabName = PrefabName.Replace("\\", "/");
         }

         // Prune any begining or ending slashes
         if (PrefabName.StartsWith("/") || PrefabName.StartsWith(@"\"))
         {
            PrefabName = PrefabName.Remove(0, 1);
         }
         if (PrefabName.EndsWith("/") || PrefabName.EndsWith(@"\"))
         {
            int stringLength = PrefabName.Length - 1;
            PrefabName = PrefabName.Remove(stringLength, 1);
         }
      }

      // Build final fullPrefabPath
      string fullPrefabPath = "";
      if (ResourcePath != "")
      {
         fullPrefabPath = ResourcePath + "/" + PrefabName;
      }
      else
      {
         // Must be in the root of Resources
         fullPrefabPath = PrefabName;
      }
      
      // Spawn the Prefab
      try
      {
         GameObject spawnedPrefab = Instantiate(Resources.Load(fullPrefabPath), spawnPointPosition, spawnPointRotation) as GameObject;

         if (SpawnedName != "")
         {
            spawnedPrefab.name = SpawnedName;
         }

         SpawnedGameObject = spawnedPrefab;
         SpawnedInstancedID = spawnedPrefab.GetInstanceID();

         m_FinishedSpawning = true;
      }
      catch (System.Exception e)
      {
         uScriptDebug.Log(e.ToString(), uScriptDebug.Type.Error);
         SpawnedGameObject = null;
         SpawnedInstancedID = 0;
      }

   }

   public override void _InternalUpdate()
   {
      if (m_FinishedSpawning)
      {
         m_FinishedSpawning = false;
         if ( FinishedSpawning != null ) FinishedSpawning(this, new System.EventArgs());
      }
   }

}