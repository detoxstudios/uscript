// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Create (instantiate) an instance of a Prefab at the specified spawn point GameObject at runtime (must be in the Resources folder structure).

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Create an instance of a Prefab at the specified spawn point.")]
[NodeDescription("Create (instantiate) an instance of a Prefab at the specified Vector3 location at runtime (must be in the Resources folder structure).\n \nPrefab Name: The name of the prefab to spawn.\nResource Path: The resource path to look in for the prefab.\nSpawn Position: The position to spawn prefab(s) from.\nSpawn Rotation: The rotation to spawn prefab(s) from.\nSpawned Name: The name given to newly spawned prefab(s).\nLocation Offset: The offset from the Spawn Point to spawn prefab(s) from.\nSpawned GameObject (out): The GameObject that gets spawned.\nSpawned InstanceID: The instance ID of the spawned GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Spawn_Prefab_At_Location")]

[FriendlyName("Spawn Prefab At Location")]
public class uScriptAct_SpawnPrefabAtLocation : uScriptLogic
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

    [FriendlyName("Finished Spawning")]
   public event uScriptEventHandler FinishedSpawning;

   public void In(
      [FriendlyName("Prefab Name")] string PrefabName,
      [FriendlyName("Resource Path")] string ResourcePath,
      [FriendlyName("Spawn Position")] Vector3 SpawnPosition,
      [FriendlyName("Spawn Rotation")] Quaternion SpawnRotation,
      [FriendlyName("Spawned Name")] string SpawnedName,
      [FriendlyName("Spawned GameObject")] out GameObject SpawnedGameObject,
      [FriendlyName("Spawned InstancedID"), SocketState(false, false)] out int SpawnedInstancedID
      )
   {
      //Get Spawn point location and rotation

      Vector3 spawnPointPosition = SpawnPosition;
      Quaternion spawnPointRotation = SpawnRotation;

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
      if (!string.IsNullOrEmpty(PrefabName))
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
      if (!string.IsNullOrEmpty(ResourcePath))
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

         if (!string.IsNullOrEmpty(SpawnedName))
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

   public override void Update()
   {
      if (m_FinishedSpawning)
      {
         m_FinishedSpawning = false;
         if ( FinishedSpawning != null ) FinishedSpawning(this, new System.EventArgs());
      }
   }

}