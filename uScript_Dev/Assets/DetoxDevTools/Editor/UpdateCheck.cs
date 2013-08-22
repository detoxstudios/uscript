// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCheck.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the UpdateCheck type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEditor;

using UnityEngine;

public class UpdateCheck : EditorWindow
{
   private UpdateNotification.UpdateStatus updateStatus = UpdateNotification.UpdateStatus.None;

   // Add menu named "My Window" to the Window menu
   [MenuItem("Tools/Detox Studios/Internal/Check for Updates")]
   internal static void Init()
   {
      // Get existing open window or if none, make a new one:
      //UpdateCheck window = (UpdateCheck)EditorWindow.GetWindow (typeof (UpdateCheck));
      EditorWindow.GetWindow<UpdateCheck>();
   }

   internal void OnGUI()
   {
      EditorGUIUtility.LookLikeControls(110);

      GUILayout.Label("Unity", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Platform", Application.platform.ToString());
      EditorGUILayout.LabelField("Version", Application.unityVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      GUILayout.Label("uScript", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Product Build", uScript.FullVersionName);
      EditorGUILayout.LabelField("Product Name", uScript.ProductName);
      EditorGUILayout.LabelField("Product Type", uScript.ProductType);
      EditorGUILayout.LabelField("You are Using", uScript.BuildNumber);
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
