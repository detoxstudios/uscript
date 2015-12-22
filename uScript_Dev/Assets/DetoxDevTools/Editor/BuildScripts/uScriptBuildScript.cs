using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class uScriptBuildScript : MonoBehaviour
{
   [MenuItem("uScript/Internal/Rebuild All Graphs")]
   public static void RebuildAllGraphs()
   {
      uScript.Instance.RebuildAllScripts(true);
   }

#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
   [MenuItem("uScript/Internal/Fixup Example Scenes", false, 200)]
   public static void FixupExampleScenes()
   {
      string[] sceneFiles = uScript.FindAllFiles(Application.dataPath + "/Example_uScript_Scenes", ".unity");
      List<string> fixedScenes = new List<string>();
      foreach (string scene in sceneFiles)
      {
         if (EditorApplication.OpenScene(scene))
         {
            Debug.Log(string.Format("Opening scene: {0}...", scene));
            if (AddUScriptComponentsToOpenScene(scene))
            {
               // Save scene
               EditorApplication.SaveScene();
               fixedScenes.Add(scene);

               System.GC.Collect();
            }
         }
      }

      if (fixedScenes.Count > 0)
      {
         Debug.Log(string.Format("Found and updated {0} scenes with uScript references:", fixedScenes.Count));
         foreach (string sceneName in fixedScenes)
         {
            Debug.Log(sceneName);
         }
      }
   }
   #else
      [MenuItem("uScript/Internal/Fixup Example Scenes", false, 200)]
      public static void FixupExampleScenes()
      {
         string[] sceneFiles = uScript.FindAllFiles(Application.dataPath + "/Example_uScript_Scenes", ".unity");
         List<string> fixedScenes = new List<string>();
         foreach (string scene in sceneFiles)
         {
            UnityEngine.SceneManagement.Scene sceneObj = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scene);

            if (sceneObj != null)
            {
               Debug.Log(string.Format("Opening scene: {0}...", scene));
               if (AddUScriptComponentsToOpenScene(scene))
               {
                  // Save scene
                  UnityEditor.SceneManagement.EditorSceneManager.SaveScene(sceneObj);
                  fixedScenes.Add(scene);

                  System.GC.Collect();
               }
            }
         }

         if (fixedScenes.Count > 0)
         {
            Debug.Log(string.Format("Found and updated {0} scenes with uScript references:", fixedScenes.Count));
            foreach (string sceneName in fixedScenes)
            {
               Debug.Log(sceneName);
            }
         }
      }
#endif

#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
   [MenuItem("uScript/Internal/Add uScript Components to Open Scene", false, 100)]
   public static void AddUScriptComponentsToOpenScene_Menu()
   {
      AddUScriptComponentsToOpenScene(EditorApplication.currentScene);
   }
#else
   [MenuItem("uScript/Internal/Add uScript Components to Open Scene", false, 100)]
   public static void AddUScriptComponentsToOpenScene_Menu()
   {
      UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
      if (null != scene)
         AddUScriptComponentsToOpenScene(scene.name);
   }
#endif

   public static bool AddUScriptComponentsToOpenScene(string scene)
   {
      GameObject go = GameObject.Find("_uScript");
      if (go == null)
      {
         Debug.Log(string.Format("No '_uScript' game object found in scene: {0}, skipping...", scene));
         return false;
      }

      Selection.activeGameObject = go;

      // Add required components
      go.AddComponent<uScript_MasterComponent>();
      
      Selection.activeGameObject = null;

      return true;
   }

   [MenuItem("uScript/Internal/Build Example Builder Package", false, 200)]
   public static void BuildExampleBuilderPackage()
   {
      string[] directories = new string[] 
      { 
         "Assets\\DetoxDevTools\\Editor\\BuildScripts", 
         "Assets\\Example_uScript_Scenes", 
         "Assets\\Standard Assets", 
         "Assets\\uScriptProjectFiles\\uScripts" 
      };
      AssetDatabase.ExportPackage(directories, "ExampleBuilder.unitypackage", ExportPackageOptions.Recurse);
   }

   [MenuItem("uScript/Internal/Build Examples Package", false, 200)]
   public static void BuildExamplesPackage()
   {
      string[] directories = new string[]
      {
         "Assets\\Example_uScript_Scenes",
         "Assets\\Standard Assets",
         "Assets\\uScriptProjectFiles\\uScripts"
      };
      AssetDatabase.ExportPackage(directories, "Examples.unitypackage", ExportPackageOptions.Recurse);
   }

   [MenuItem("uScript/Internal/Stub uScript Code", false, 300)]
   public static void StubUScriptCode()
   {
      AssetDatabase.StartAssetEditing();
      uScript.Instance.StubGeneratedCode(uScript.Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
   }

   [MenuItem("uScript/Internal/Regenerate uScript Code", false, 300)]
   public static void RegenerateUScriptCode()
   {
      AssetDatabase.StartAssetEditing();
      uScript.Instance.RebuildScripts(uScript.Preferences.UserScripts, false);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
   }
}
