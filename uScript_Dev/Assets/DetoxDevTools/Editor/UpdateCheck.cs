// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCheck.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the UpdateCheck type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Detox.Editor;

using UnityEditor;

using UnityEngine;

public class UpdateCheck : EditorWindow
{
   private UpdateNotification.UpdateStatus updateStatus = UpdateNotification.UpdateStatus.None;

   [MenuItem("uScript/Internal/Check for Updates", false, 501)]
   internal static void Init()
   {
      // Get existing open window or if none, make a new one:
      //UpdateCheck window = (UpdateCheck)EditorWindow.GetWindow (typeof (UpdateCheck));
      EditorWindow.GetWindow<UpdateCheck>();
   }

   internal void OnGUI()
   {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
      EditorGUIUtility.LookLikeControls(110);
#else
      EditorGUIUtility.labelWidth = 110;
#endif

      GUILayout.Label("Unity", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Platform", Application.platform.ToString());
      EditorGUILayout.LabelField("Version", Application.unityVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      GUILayout.Label("uScript", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Product Name", uScriptBuild.Name);
      EditorGUILayout.LabelField("Product Type", UpdateNotification.ProductType);
      EditorGUILayout.LabelField("You are Using", uScriptBuild.Number);
      EditorGUILayout.LabelField("Latest Version", UpdateNotification.LatestVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      if (GUILayout.Button("Check for Updates"))
      {
         this.updateStatus = UpdateNotification.ManualCheck();
      }

      EditorGUILayout.Space();

      string message;
      switch (this.updateStatus)
      {
         case UpdateNotification.UpdateStatus.ClientBuildCurrent:
            message = "uScript is up to date.";
            break;

         case UpdateNotification.UpdateStatus.ClientBuildNewer:
            message = "Your build is newer than latest.";
            break;

         case UpdateNotification.UpdateStatus.ClientBuildOlder:
            message = "A new uScript build is available.";
            break;

         case UpdateNotification.UpdateStatus.UpdateClientError:
            message = "A client error occurred.";
            break;

         case UpdateNotification.UpdateStatus.UpdateServerError:
            message = "An update server error occurred.";
            break;

         default:
            message = "Latest build version is unknown.";
            break;
      }

      GUILayout.Label("Server Response", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Determination", message);
      EditorGUILayout.TextField("Raw Response", UpdateNotification.WebResponse ?? string.Empty);
      EditorGUI.indentLevel--;
   }
}
