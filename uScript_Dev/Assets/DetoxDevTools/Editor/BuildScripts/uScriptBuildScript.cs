using UnityEngine;
using UnityEditor;
using Detox.Editor;
using System.Collections.Generic;

public class uScriptBuildScript : MonoBehaviour
{
   [MenuItem("uScript/Internal/Rebuild All Graphs")]
   public static void RebuildAllGraphs()
   {
      Debug.Log("Start Rebuild All Graphs...");
      // first stub out all uscripts
      AssetDatabase.StartAssetEditing();
      uScript.Instance.StubGeneratedCode(Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();

      int i = 0;
      while (i++ < 1000000 && EditorApplication.isCompiling == true) { }

      // now build any scripts which are used as nested nodes
      // when these are done we will then build any scripts which references these
      AssetDatabase.StartAssetEditing();
      {
         uScript.Instance.RebuildScripts(Preferences.UserScripts, false);
      }
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
      Debug.Log("End Rebuild All Graphs...");
   }

   [MenuItem("uScript/Internal/Fixup Example Scenes", false, 200)]
   public static void FixupExampleScenes()
   {
      string[] sceneFiles = uScript.FindAllFiles(Application.dataPath + "/Example_uScript_Scenes", ".unity");
      List<string> fixedScenes = new List<string>();
      foreach (string scene in sceneFiles)
      {
         UnityEngine.SceneManagement.Scene sceneObj = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scene);
         if (sceneObj.isLoaded)
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

   [MenuItem("uScript/Internal/Add uScript Components to Open Scene", false, 100)]
   public static void AddUScriptComponentsToOpenScene_Menu()
   {
      UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
      AddUScriptComponentsToOpenScene(scene.name);
   }

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
      uScript.Instance.StubGeneratedCode(Preferences.UserScripts);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
   }

   [MenuItem("uScript/Internal/Regenerate uScript Code", false, 300)]
   public static void RegenerateUScriptCode()
   {
      AssetDatabase.StartAssetEditing();
      uScript.Instance.RebuildScripts(Preferences.UserScripts, false);
      AssetDatabase.StopAssetEditing();
      AssetDatabase.Refresh();
   }
}
