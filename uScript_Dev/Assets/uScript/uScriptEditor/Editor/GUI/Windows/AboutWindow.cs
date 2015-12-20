// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the AboutWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI.Windows
{
#endif
   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class AboutWindow : EditorWindow
   {
      private const int WindowWidth = 320;

      private const int WindowHeight = 260;

      private static AboutWindow window;

      private bool isFirstRun;

#if UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
      private static string unityVersion = "on Unity 3";
#elif UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
      private static string unityVersion = "on Unity 4";
#elif UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
      private static string unityVersion = "on Unity 5";
#else
      private static string unityVersion = "on Unity ?";
#endif

   public static void Open()
      {
         window = GetWindow<AboutWindow>(true, "About uScript", true);
         window.isFirstRun = true;
         window.wantsMouseMove = true;
      }

      public void OnGUI()
      {
         if (this.isFirstRun)
         {
            this.isFirstRun = false;

            // Set the min and max window dimensions to prevent resizing
            this.minSize = new Vector2(WindowWidth, WindowHeight);
            this.maxSize = this.minSize;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
               window.Focus();
            }
         }

         if (Event.current.type == EventType.MouseMove)
         {
            this.Repaint();
         }

#if UNITY_3_5
         // There is a 10 pixel high gap between the top of the window and the first GUI element on early versions of Unity.
         // This is certainly needed for <= 3.5.7, but not >= 4.6.0. Early 4.x versions have not been tested.
         GUILayout.Space(-10);
#endif

         GUILayout.Label(Content.Header, Style.Header);

         GUILayout.Space(16);

         GUILayout.Label("uScript " + uScriptBuild.Name, Style.ProductName);
         GUILayout.Label("Build " + uScriptBuild.Number + " (" + unityVersion + ")", Style.ProductVersion);
         GUILayout.Label("\n" + uScriptBuild.Copyright + "\nAll rights reserved.\n", Style.ProductCopyright);

         if (GUILayout.Button("www.detoxstudios.com", Style.WebsiteLink))
         {
            Application.OpenURL("http://detoxstudios.com/");
         }
      }

      private static class Content
      {
         static Content()
         {
            Header = new GUIContent(uScriptGUI.GetTexture("AboutLogo"));
         }

         public static GUIContent Header { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            Header = new GUIStyle { padding = new RectOffset(0, 0, 0, 0), stretchWidth = false };

            ProductCopyright = new GUIStyle(EditorStyles.label)
                                  {
                                     alignment = TextAnchor.UpperCenter,
                                     padding = new RectOffset(2, 2, 2, 2)
                                  };

            ProductName = new GUIStyle(EditorStyles.boldLabel)
                             {
                                alignment = TextAnchor.UpperCenter,
                                padding = new RectOffset(2, 2, 0, 0)
                             };

            ProductVersion = new GUIStyle(EditorStyles.label)
                                {
                                   alignment = TextAnchor.UpperCenter,
                                   padding = new RectOffset(2, 2, 0, 0)
                                };

            WebsiteLink = new GUIStyle(GUI.skin.button)
                             {
                                alignment = TextAnchor.UpperCenter,
                                margin = new RectOffset(80, 80, 3, 3),
                                normal = { background = null },
                                hover =
                                   {
                                      background = GUI.skin.button.normal.background,
                                      textColor = GUI.skin.button.normal.textColor
                                   }
                             };
         }

         public static GUIStyle Header { get; private set; }

         public static GUIStyle ProductCopyright { get; private set; }

         public static GUIStyle ProductName { get; private set; }

         public static GUIStyle ProductVersion { get; private set; }

         public static GUIStyle WebsiteLink { get; private set; }
      }
   }
#if !UNITY_3_5
}
#endif

namespace Detox.Editor.GUI.Windows
{
   public static class Unity357Support
   {
      
   }
}
