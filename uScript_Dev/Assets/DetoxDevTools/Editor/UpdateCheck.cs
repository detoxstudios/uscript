using UnityEngine;
using UnityEditor;
public class UpdateCheck : EditorWindow
{
   Vector2 _scrollviewPosition;

   string myString = "Hello World";
   bool groupEnabled;
   bool myBool = true;
   float myFloat = 1.23f;
   
   // Add menu named "My Window" to the Window menu
   [MenuItem ("Detox Tools/Internal/Check for Updates")]
   static void Init()
   {
      // Get existing open window or if none, make a new one:
      UpdateCheck window = (UpdateCheck)EditorWindow.GetWindow (typeof (UpdateCheck));
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
      EditorGUILayout.LabelField("Product", uScript.FullVersionName);
      EditorGUILayout.LabelField("Current Version", uScript.BuildNumber);
      EditorGUILayout.LabelField("Latest Version", UpdateNotification.LatestVersion);
      EditorGUI.indentLevel--;

      EditorGUILayout.Space();

      if (GUILayout.Button("Check for Updates"))
      {
         UpdateNotification.CheckForUpdate();
      }

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
