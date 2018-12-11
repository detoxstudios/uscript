// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutWindow.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI.Windows
{
   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class AboutWindow : EditorWindow
   {
      private const int WindowWidth = 320;

      private const int WindowHeight = 260;

#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2
      private const string UnityVersion = "for Unity 5.0-5.2";
#elif UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6
      private const string UnityVersion = "for Unity 5.3-5.6";
#else
      private const string UnityVersion = "for Unity 2017.1+";
#endif

      private static AboutWindow window;

      private bool isFirstRun;

      public static void Open()
      {
         // ReSharper disable once ArrangeStaticMemberQualifier
         window = EditorWindow.GetWindow<AboutWindow>(true, "About uScript", true);
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

         GUILayout.Label(Content.Header, Style.Header);

         GUILayout.Space(16);

         GUILayout.Label(string.Format("uScript {0}", uScriptBuild.Name), Style.ProductName);
         GUILayout.Label(string.Format("Build {0} ({1})", uScriptBuild.Number, UnityVersion), Style.ProductVersion);
         GUILayout.Label(string.Format("\n{0}\nAll rights reserved.\n", uScriptBuild.Copyright), Style.ProductCopyright);

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
}

namespace Detox.Editor.GUI.Windows
{
   public static class Unity357Support
   {
      
   }
}
