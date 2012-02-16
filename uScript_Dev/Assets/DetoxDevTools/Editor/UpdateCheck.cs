using UnityEngine;
using UnityEditor;
public class UpdateCheck : EditorWindow
{
   Vector2 _scrollviewPosition;
   UpdateNotification.Result _updateResult = UpdateNotification.Result.CheckNeeded;

   // Add menu named "My Window" to the Window menu
   [MenuItem ("Detox Tools/Internal/Check for Updates")]
   static void Init()
   {
      // Get existing open window or if none, make a new one:
//      UpdateCheck window = (UpdateCheck)EditorWindow.GetWindow (typeof (UpdateCheck));
      EditorWindow.GetWindow (typeof (UpdateCheck));
   }
   
   void OnGUI()
   {
      EditorGUIUtility.LookLikeControls(110);

      GUILayout.Label("Unity", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Version", Application.unityVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      GUILayout.Label("uScript", EditorStyles.boldLabel);
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Product Build", uScript.FullVersionName);
      EditorGUILayout.LabelField("Product Name", uScript.ProductName);
      EditorGUILayout.LabelField("Product Type", uScript.ProductType);
      EditorGUILayout.LabelField("Current Version", uScript.BuildNumber);
      EditorGUILayout.LabelField("Latest Version", UpdateNotification.LatestVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      if (GUILayout.Button("Check for Updates"))
      {
         _updateResult = UpdateNotification.CheckForUpdate();
      }

      EditorGUILayout.LabelField("Result", (_updateResult == UpdateNotification.Result.CheckNeeded
                                            ? "Latest build version is unknown"
                                            : (_updateResult == UpdateNotification.Result.ClientBuildCurrent
                                               ? "uScript is up to date"
                                               : (_updateResult == UpdateNotification.Result.ClientBuildOlder
                                                  ? "A new uScript build is available"
                                                  : (_updateResult == UpdateNotification.Result.ClientBuildNewer
                                                     ? "Your build is newer than latest"
                                                     : "An update server error occurred")))));

      GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandHeight(true));
      {
         _scrollviewPosition = GUILayout.BeginScrollView(_scrollviewPosition);
         {
            GUILayout.TextArea(UpdateNotification.WebResponse);
         }
         GUILayout.EndScrollView();
      }
      GUILayout.EndVertical();
   }
}
