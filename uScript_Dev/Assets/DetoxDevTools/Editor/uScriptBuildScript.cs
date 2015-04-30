﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class uScriptBuildScript : MonoBehaviour
{
   [MenuItem("uScript/Internal/Fixup Example Scenes")]
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

   [MenuItem("uScript/Internal/Add uScript Components to Open Scene")]
   public static void AddUScriptComponentsToOpenScene_Menu()
   {
      AddUScriptComponentsToOpenScene(EditorApplication.currentScene);
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
      go.AddComponent<uScript_UndoComponent>();

      Selection.activeGameObject = null;

      return true;
   }
}