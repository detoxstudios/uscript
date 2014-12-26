using Detox.Editor;

using UnityEngine;
using UnityEditor;
using System.Collections;


public class DetoxUtilities : EditorWindow
{
   [MenuItem("uScript/Internal/Setup TestBed Scene", false, 501)]
   public static void SetupScene()
   {
      Debug.Log("STARTING TESTBED REBUILD...\n");
         
      // Find old GameObjects and delte them if found.
      
      // _uScript GO:
      GameObject currentObject;
      currentObject = GameObject.Find("_uScript");
      if ( currentObject != null)
      {
         Debug.Log("Deleting old _uScript GameObject.\n");
         GameObject.DestroyImmediate(currentObject);
      }
      Debug.Log("Creating new _uScript GameObject.\n");
      GameObject new_uScript = new GameObject("_uScript");
      new_uScript.transform.position = new Vector3(0f, 0f, 0f);
      new_uScript.AddComponent(typeof(uScript_MasterComponent));

      System.Type type = uScriptUtils.GetAssemblyQualifiedType( "uScript_TestBed_Component" );
      if ( null != type )
      {
         new_uScript.AddComponent(type);
      }

      // Trigger GO:
      currentObject = null;
      currentObject = GameObject.Find("Trigger");
      if ( currentObject != null)
      {
         Debug.Log("Deleting old Trigger GameObject.\n");
         GameObject.DestroyImmediate(currentObject);
      }
      Debug.Log("Creating new Trigger GameObject.\n");
      GameObject new_Trigger = new GameObject("Trigger");
      BoxCollider newBoxCollider = new_Trigger.AddComponent(typeof(BoxCollider)) as BoxCollider;
      newBoxCollider.size = new Vector3(6f, 3f, 2f);
      newBoxCollider.isTrigger = true;
      new_Trigger.transform.parent = GameObject.Find("Trigger").transform;
      new_Trigger.transform.position = new Vector3(0, 1.5f, 8.5f);
      
      // Player GO:
      currentObject = null;
      currentObject = GameObject.Find("Player");
      if ( currentObject != null)
      {
         Debug.Log("Deleting old Player GameObject.\n");
         GameObject.DestroyImmediate(currentObject);
      }
      Debug.Log("Creating new Player GameObject.\n");
      GameObject new_Player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
      new_Player.name = "Player";
      new_Player.transform.position = new Vector3(0f, 1.0f, 0f);
      CapsuleCollider newCapsuleCollider = new_Player.GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
      newCapsuleCollider.center = new Vector3(0, 0, 0);
      MeshRenderer newMeshRenderer = new_Player.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
      newMeshRenderer.material = UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Game/Materials/Player_MAT.mat", typeof(UnityEngine.Material)) as UnityEngine.Material;
      Rigidbody newRigidbody = new_Player.AddComponent(typeof(Rigidbody)) as Rigidbody;
      newRigidbody.mass = 1f;
      newRigidbody.drag = 0f;
      newRigidbody.angularDrag = 0.05f;
      newRigidbody.useGravity = false;
      newRigidbody.isKinematic = false;
      newRigidbody.freezeRotation = true;
      new_Player.AddComponent(typeof(MovePlayer));

      // Assign Materials to level GameObjects
      
      // Floor:
      GameObject floorObject;
      floorObject = GameObject.Find("Floor");
      if ( floorObject != null)
      {
         Debug.Log("Assigning material to floor GameObject.\n");
         MeshRenderer floorMeshRenderer = floorObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
         floorMeshRenderer.material = UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Game/Materials/Floor_MAT.mat", typeof(UnityEngine.Material)) as UnityEngine.Material;
      }
      
      // Pillars:
      GameObject pillarOneObject;
      pillarOneObject = GameObject.Find("Pillar1");
      if ( pillarOneObject != null)
      {
         Debug.Log("Assigning material to pillar GameObjects.\n");
         MeshRenderer pillarOneMeshRenderer = pillarOneObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
         pillarOneMeshRenderer.material = UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Game/Materials/Pillars_MAT.mat", typeof(UnityEngine.Material)) as UnityEngine.Material;
      }
      
      GameObject pillarTwoObject;
      pillarTwoObject = GameObject.Find("Pillar2");
      if ( pillarTwoObject != null)
      {
         MeshRenderer pillarTwoMeshRenderer = pillarTwoObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
         pillarTwoMeshRenderer.material = UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Game/Materials/Pillars_MAT.mat", typeof(UnityEngine.Material)) as UnityEngine.Material;
      }
      
      Debug.Log("FINISHED TESTBED REBUILD!\n");

   }

   /*
   [MenuItem("uScript/Internal/Fix GUI Texture Settings")]
   public static void FixGUITextures()
   {
      Debug.Log("Fix GUI Texture Settings: Not Yet Working!");
      //UnityEditor.AssetDatabase.ImportAsset( "Assets/uScript/uScriptEditor/Editor/_GUI/uScriptDefault/uscript_background.png", ImportAssetOptions.ImportRecursive);
   }
   */
}
