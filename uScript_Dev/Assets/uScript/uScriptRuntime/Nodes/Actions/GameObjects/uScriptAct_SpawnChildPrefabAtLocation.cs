// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Create an instance of a Prefab as a child of the parent GameObject at the specified spawn point.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Spawn Child Prefab At Location", "Create (instantiate) an instance of a Prefab as a child of the parent GameObject at the specified Vector3 location at runtime (must be in the Resources folder structure).")]
public class uScriptAct_SpawnChildPrefabAtLocation : uScriptLogic
{

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   private bool m_FinishedSpawning = false;

   public bool Immediate { get { return true; } }

   [FriendlyName("Finished Spawning")]
   public event uScriptEventHandler FinishedSpawning;

   public void In(
      [FriendlyName("Prefab Name", "The name of the prefab to spawn.")]
      string PrefabName,

      [FriendlyName("Resource Path", "The resource path to look in for the prefab.")]
      [SocketState(false, false)]
      string ResourcePath,

      [FriendlyName("Spawn Position", "The position to spawn prefab(s) from.")]
      Vector3 SpawnPosition,

      [FriendlyName("Spawn Rotation", "The rotation to spawn prefab(s) from.")]
      [SocketState(false, false)]
      Quaternion SpawnRotation,

      [FriendlyName("Spawned Name", "The name given to newly spawned prefab(s).")]
      [SocketState(false, false)]
      string SpawnedName,
		
		[FriendlyName("Parent", "The parent GameObject you wish the newly spawned GameObject to be a child of. If left blank, the spawned GameObject will have no parent.")]
      GameObject Parent,

// The offset from the Spawn Point to spawn prefab(s) from.

      [FriendlyName("Spawned GameObject", "The GameObject that gets spawned.")]
      out GameObject SpawnedGameObject,

      [FriendlyName("Spawned InstancedID", "The instance ID of the spawned GameObject.")]
      [SocketState(false, false)]
      out int SpawnedInstancedID
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
         GameObject spawnedPrefab = ScriptableObject.Instantiate(Resources.Load(fullPrefabPath), spawnPointPosition, spawnPointRotation) as GameObject;
			
			if (null != Parent)
			{
				spawnedPrefab.transform.parent = Parent.transform;
			}
			

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

   public void Update()
   {
      if (m_FinishedSpawning)
      {
         m_FinishedSpawning = false;
         if ( FinishedSpawning != null ) FinishedSpawning(this, new System.EventArgs());
      }
   }

}